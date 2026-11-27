using Microsoft.ClearScript.V8;
using MultiHtmlCraft.Core;
using MultiHtmlCraft.Interfaces;
using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/// <summary>
/// MultiHtmlCore imprementation of RFC 6455 with System.Net.WebSockets
/// </summary>
public sealed class CHtmlWebSocket : ICommonObjectInterface, ICHtmlWebSocket, IDynamicMetaObjectProvider
{
    public const int MethodSend = 1;
    public const int MethodClose = 2;
    public const int MethodAddEventListener = 3;
    public const int MethodRemoveEventListener = 4;
    public const int MethodDispatchEvent = 5;

    public const int PropUrl = 1;
    public const int PropReadyState = 2;
    public const int PropBufferedAmount = 3;
    public const int PropExtensions = 4;
    public const int PropProtocol = 5;
    public const int PropBinaryType = 6;
    public const int PropOnOpen = 7;
    public const int PropOnMessage = 8;
    public const int PropOnError = 9;
    public const int PropOnClose = 10;
   

    public static readonly Dictionary<string, int> CHtmlWebSocketMethodList = new Dictionary<string, int>(StringComparer.Ordinal)
    {
        ["send"] = MethodSend,
        ["close"] = MethodClose,
        ["addEventListener"] = MethodAddEventListener,
        ["removeEventListener"] = MethodRemoveEventListener,
        ["dispatchEvent"] = MethodDispatchEvent
    };

    public static readonly Dictionary<string, int> CHtmlWebSocketProperties = new Dictionary<string, int>(StringComparer.Ordinal)
    {
        ["url"] = PropUrl,
        ["readyState"] = PropReadyState,
        ["bufferedAmount"] = PropBufferedAmount,
        ["extensions"] = PropExtensions,
        ["protocol"] = PropProtocol,
        ["binaryType"] = PropBinaryType,
        ["onopen"] = PropOnOpen,
        ["onmessage"] = PropOnMessage,
        ["onerror"] = PropOnError,
        ["onclose"] = PropOnClose
    };
    private readonly ClientWebSocket _socket = new();
    private readonly SemaphoreSlim _sendLock = new(1, 1);
    private CancellationTokenSource? _receiveCts;
    private Task? _receiveTask;
    private bool _disposed;
    private string _websocketUrl = "";
    private WeakReference? ___WebSocketSendFunctionWeakReference = null;
    private WeakReference? ___WebSocketCloseunctionWeakReference = null;

    private WeakReference? ___WebSocketOpenFunctionWeakReference = null;
    private WeakReference? ___WebSocketMessageFunctionWeakReference = null;
    private WeakReference? ___WebSocketErrorFunctionWeakReference = null;
    private WeakReference? ___WebSocketCloseFunctionWeakReference = null;
    private WeakReference? ___WebSocketCustomFunctionWeakReference = null;

    private WeakReference? ___WebSocketDispatchFunctionWeakReference = null;
    private readonly string[] _protocols;
    public IReadOnlyList<string> Protocols => _protocols;
    public CHtmlWebSocket(params object[] args)
    {
       
        _protocols = Array.Empty<string>();

        if (args != null && args.Length > 0)
        {
            _websocketUrl = args[0] as string;
            if (!string.IsNullOrWhiteSpace(_websocketUrl))
            {
                if (Uri.TryCreate(_websocketUrl, UriKind.Absolute, out Uri? parsedUri))
                {
                    Url = parsedUri;
                }
                else
                {
                    throw new ArgumentException($"Invalid WebSocket URL: {_websocketUrl}", nameof(args));
                }
            }

            if (args.Length > 1 && args[1] != null)
            {
                _protocols = ExtractProtocols(args[1]);
            }
        }
        if(commonLog.LoggingEnabled && commonLog.LogLevel >= 7)
        {
            commonLog.LogEntry($"WebSocket construtor is called with {_websocketUrl} protocols : {_protocols}");
        }
        if (Url != null)
        {
            _ = Task.Run(() => StartConnectAsync(Url, CancellationToken.None));
        }
    }
    private async Task StartConnectAsync(Uri uri, CancellationToken cancellationToken)
    {
        if(commonLog.LoggingEnabled && commonLog.LogLevel >= 7)
        {
            commonLog.LogEntry($"enter {this}.StartConnectAsync url : {uri}");
        }
        try
        {
            if (_disposed)
            {
                return;
            }

            
            if (_protocols != null)
            {
                foreach (var protocol in _protocols)
                {
                    if (!string.IsNullOrWhiteSpace(protocol) && _socket.State == WebSocketState.None)
                    {
                        _socket.Options.AddSubProtocol(protocol);
                    }
                }
            }

            await ConnectAsync(uri, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            if (commonLog.LoggingEnabled)
            {
                commonLog.LogEntry("WebSocket StartConnectAsync failed for {0}: {1}", uri, ex.Message);
            }

            if (!_disposed)
            {
                ErrorOccurred?.Invoke(ex);
                Closed?.Invoke(1006, ex.Message, false);
            }
        }
    }
    public void send(params object[] args)
    {
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 7)
        {
            commonLog.LogEntry("TODO: Webocket send is called with: {args}");
        }
    }
    public void close(params object[] args)
    {
        int closeCode = 1000;
        string reason = string.Empty;

        if (args != null && args.Length > 0 && args[0] != null)
        {
            var rawCode = args[0] ;
            if (rawCode != null && TryConvertToInt32(rawCode, out int parsedCode))
            { 
               
                if (parsedCode != 1000 && (parsedCode < 3000 || parsedCode > 4999))
                {
                    if (commonLog.LoggingEnabled)
                    {
                        commonLog.LogEntry("WebSocket close invalid code: {0}", parsedCode);
                    }
                    throw new ArgumentOutOfRangeException(nameof(args), $"Invalid WebSocket close code: {parsedCode}");
                }
                closeCode = parsedCode;
            }
        }

        if (args != null && args.Length > 1 && args[1] != null)
        {
            var rawReason = args[1];
            if (rawReason != null)
            {
                reason = rawReason.ToString() ?? string.Empty;
                if (Encoding.UTF8.GetByteCount(reason) > 123)
                {
                    if (commonLog.LoggingEnabled)
                    {
                        commonLog.LogEntry("WebSocket close reason too long: {0}", reason);
                    }
                    throw new ArgumentException("WebSocket close reason must not exceed 123 UTF-8 bytes.", nameof(args));
                }
            }
        }

        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 7)
        {
            commonLog.LogEntry("WebSocket close() is called: code={0}, reason={1}, state={2}", closeCode, reason, _socket.State);
        }

        if (_disposed)
        {
            return;
        }

        if (_socket.State == WebSocketState.Open || _socket.State == WebSocketState.CloseReceived)
        {
            WebSocketCloseStatus status = Enum.IsDefined(typeof(WebSocketCloseStatus), closeCode)
                ? (WebSocketCloseStatus)closeCode
                : WebSocketCloseStatus.NormalClosure;

            _ = Task.Run(async () =>
            {
                try
                {
                    await CloseAsync((int)status, reason, CancellationToken.None).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled)
                    {
                        commonLog.LogEntry("WebSocket close async error: {0}", ex.Message);
                    }
                }
            });
        }
    }

    private static bool TryConvertToInt32(object value, out int result)
    {
        switch (value)
        {
            case int i:
                result = i;
                return true;
            case long l when l >= int.MinValue && l <= int.MaxValue:
                result = (int)l;
                return true;
            case double d when !double.IsNaN(d) && !double.IsInfinity(d) && d >= int.MinValue && d <= int.MaxValue:
                result = (int)d;
                return true;
            default:
                return int.TryParse(value.ToString(), out result);
        }
    }
    public void addEventListener(params object[] args)
    {
        bool ___addEventListenerFunctionWerkReferenceSet = false;
        if (args is null || args.Length < 2)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 7)
            {
                commonLog.LogEntry("WebSocket addEventListener called with insufficient arguments: count={0}", args?.Length ?? 0);
            }
            return;
        }

        if (args[0] is not string eventType || string.IsNullOrEmpty(eventType))
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 7)
            {
                commonLog.LogEntry("WebSocket addEventListener ignored non-string eventType: {0}", args[0]);
            }
            return;
        }

        object? listener = args[1];
        WeakReference? targetRef = listener is not null ? new WeakReference(listener) : null;

        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 7)
        {
            commonLog.LogEntry("WebSocket addEventListener type={0}, hasListener={1}", eventType, listener is not null);
        }

        switch (eventType)
        {
            case "open":
                ___WebSocketOpenFunctionWeakReference = targetRef;
                ___addEventListenerFunctionWerkReferenceSet = true;
                break;

            case "message":
                ___WebSocketMessageFunctionWeakReference = targetRef;
                ___addEventListenerFunctionWerkReferenceSet = true;
                break;

            case "error":
                ___WebSocketErrorFunctionWeakReference = targetRef;
                ___addEventListenerFunctionWerkReferenceSet = true;
                break;

            case "close":
                ___WebSocketCloseFunctionWeakReference = targetRef;
                ___addEventListenerFunctionWerkReferenceSet = true;
                break;

            default:
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 7)
                {
                    commonLog.LogEntry("WebSocket addEventListener  is set to     this.___WebSocketCustomFunctionWeakReference  eventType:  {0}", eventType);
                }
                this.___WebSocketCustomFunctionWeakReference = targetRef;
                ___addEventListenerFunctionWerkReferenceSet = true;
                break;
        }
        if(commonLog.LoggingEnabled && commonLog.LogLevel >= 7)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 7)
            {
                commonLog.LogEntry($"{this}.addEventListener  is set eventType:  {eventType} isSuccess: {___addEventListenerFunctionWerkReferenceSet}  ");
            }
        }
    }
    public void removeEventListener(params object[] args)
    {
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 7)
        {
            commonLog.LogEntry("TODO: Webocket removeEventListener is called with: {args}");
        }
    }

    public bool dispatchEvent(params object[] args)
    {
        bool ___dispatchEventIsCalled = false;
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 7)
        {
            commonLog.LogEntry("enter Webocket dispathEvent is called with: {args}");
            

        }



        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 7)
        {
            commonLog.LogEntry("exit Webocket dispathEvent is called with: {args}");
            if (___dispatchEventIsCalled == false)
            {
                commonLog.LogEntry($"TODO: exit Webocket dispathEvent is not called with: {args} isWebSocketDispatchCalled : {___dispatchEventIsCalled}");
            }

        }

        return ___dispatchEventIsCalled;
    }


    private static string[] ExtractProtocols(object rawProtocols)
    {
        if (rawProtocols is string single && !string.IsNullOrWhiteSpace(single))
        {
            return new[] { single };
        }

        if (rawProtocols is IEnumerable enumerable and not string)
        {
            List<string> result = new List<string>();
            foreach (object? item in enumerable)
            {
                string? value = item?.ToString();
                if (!string.IsNullOrWhiteSpace(value))
                {
                    result.Add(value!);
                }
            }
            return result.ToArray();
        }

        string? fallback = rawProtocols.ToString();
        return string.IsNullOrWhiteSpace(fallback) ? Array.Empty<string>() : new[] { fallback! };
    }

    public Uri? Url { get; private set; }

    public string? SubProtocol => _socket.SubProtocol;

    public bool IsOpen => !_disposed && _socket.State == WebSocketState.Open;

    public event Action? Opened;
    public event Action<string>? TextReceived;
    public event Action<byte[]>? BinaryReceived;
    public event Action<Exception>? ErrorOccurred;
    public event Action<int, string?, bool>? Closed;
    private void InvokeJsListener(WeakReference? listenerRef, params object?[] args)
    {
        if (listenerRef?.Target is not { } target)
        {
            return;
        }

        try
        {
            if (target is Delegate del)
            {
                del.DynamicInvoke(args);
                return;
            }

            dynamic dyn = target;
            if (args.Length == 0)
            {
                dyn();
            }
            else if (args.Length == 1)
            {
                dyn(args[0]);
            }
            else
            {
                dyn(args);
            }
        }
        catch (Exception ex)
        {
            if (commonLog.LoggingEnabled)
            {
                commonLog.LogEntry("WebSocket InvokeJsListener error: {0}", ex.Message);
            }
        }
    }
    public async Task ConnectAsync(Uri uri, CancellationToken cancellationToken = default)
    {
        if(commonLog.LoggingEnabled && commonLog.LogLevel >=7)
        {
            commonLog.LogEntry($"enter {this}.ConnectAsync({uri}");
        }
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(uri);

        Url = uri;
        await _socket.ConnectAsync(uri, cancellationToken).ConfigureAwait(false);

        _receiveCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        _receiveTask = Task.Run(() => ReceiveLoopAsync(_receiveCts.Token), CancellationToken.None);


        Opened?.Invoke();
        if (___WebSocketOpenFunctionWeakReference != null)
        {
            InvokeJsListener(___WebSocketOpenFunctionWeakReference);
        }
    }

    public async Task SendTextAsync(string message, CancellationToken cancellationToken = default)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(message);

        byte[] bytes = Encoding.UTF8.GetBytes(message);
        await SendInternalAsync(bytes, WebSocketMessageType.Text, cancellationToken).ConfigureAwait(false);
    }

    public async Task SendBinaryAsync(ReadOnlyMemory<byte> data, CancellationToken cancellationToken = default)
    {
        ThrowIfDisposed();
        await SendInternalAsync(data, WebSocketMessageType.Binary, cancellationToken).ConfigureAwait(false);
    }

    private async Task SendInternalAsync(
        ReadOnlyMemory<byte> data,
        WebSocketMessageType messageType,
        CancellationToken cancellationToken)
    {
        if (_socket.State != WebSocketState.Open)
        {
            throw new InvalidOperationException($"WebSocket is not open. Current state: {_socket.State}");
        }

        await _sendLock.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            await _socket.SendAsync(data, messageType, endOfMessage: true, cancellationToken)
                .ConfigureAwait(false);
        }
        finally
        {
            _sendLock.Release();
        }
    }

    public async Task CloseAsync(int code = 1000, string? reason = null, CancellationToken cancellationToken = default)
    {
        if (_disposed)
        {
            return;
        }

        var status = (WebSocketCloseStatus)code;
        if (_socket.State is WebSocketState.Open or WebSocketState.CloseReceived)
        {
            try
            {
                await _socket.CloseOutputAsync(status, reason, cancellationToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                
            }
            catch (WebSocketException)
            {
                
            }
        }

        await StopReceiveLoopAsync().ConfigureAwait(false);
    }

    private async Task ReceiveLoopAsync(CancellationToken cancellationToken)
    {
        const int bufferSize = 8192;
        byte[] buffer = ArrayPool<byte>.Shared.Rent(bufferSize);

        int closeCode = 1006;
        string? closeReason = null;
        bool wasClean = false;

        try
        {
            while (!cancellationToken.IsCancellationRequested && _socket.State == WebSocketState.Open)
            {
                WebSocketReceiveResult result = await _socket.ReceiveAsync(buffer, cancellationToken)
                    .ConfigureAwait(false);
                 if(commonLog.LoggingEnabled && commonLog.LogLevel >= 7)
                {
                    commonLog.LogEntry($"[this] ReceiveLoopAsync is called with {result.MessageType} {result.ToString()}");
                }
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    closeCode = result.CloseStatus.HasValue ? (int)result.CloseStatus.Value : 1000;
                    closeReason = result.CloseStatusDescription;
                    wasClean = result.CloseStatus.HasValue;

                    if (_socket.State == WebSocketState.CloseReceived)
                    {
                        await _socket.CloseAsync(
                            WebSocketCloseStatus.NormalClosure,
                            "Acknowledged close",
                            CancellationToken.None).ConfigureAwait(false);
                    }
                    break;
                }

                // 1メッセージがバッファを超える場合は EndOfMessage が true になるまで連結
                if (result.EndOfMessage)
                {
                    DispatchMessage(buffer.AsSpan(0, result.Count), result.MessageType);
                }
                else
                {
                    using var ms = new MemoryStream();
                    ms.Write(buffer, 0, result.Count);

                    WebSocketReceiveResult part;
                    do
                    {
                        part = await _socket.ReceiveAsync(buffer, cancellationToken).ConfigureAwait(false);
                        if (part.MessageType == WebSocketMessageType.Close)
                        {
                            closeCode = part.CloseStatus.HasValue ? (int)part.CloseStatus.Value : 1000;
                            closeReason = part.CloseStatusDescription;
                            wasClean = part.CloseStatus.HasValue;
                            break;
                        }
                        ms.Write(buffer, 0, part.Count);
                    } while (!part.EndOfMessage);

                    if (part.MessageType != WebSocketMessageType.Close)
                    {
                        DispatchMessage(ms.GetBuffer().AsSpan(0, (int)ms.Length), result.MessageType);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        catch (OperationCanceledException)
        {
            wasClean = true;
        }
        catch (Exception ex)
        {
            if (!_disposed)
            {
                ErrorOccurred?.Invoke(ex);
            }
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
            if (!_disposed)
            {
                Closed?.Invoke(closeCode, closeReason, wasClean);
            }
        }
    }

    private void DispatchMessage(ReadOnlySpan<byte> payload, WebSocketMessageType messageType)
    {
        if (messageType == WebSocketMessageType.Text)
        {
            string text = Encoding.UTF8.GetString(payload);
            TextReceived?.Invoke(text);
            InvokeMessageListener(text);
        }
        else if (messageType == WebSocketMessageType.Binary)
        {
            byte[] bytes = payload.ToArray();
            BinaryReceived?.Invoke(bytes);
            InvokeMessageListener(bytes);
        }
    }

    private void InvokeMessageListener(object data)
    {
        if (___WebSocketMessageFunctionWeakReference?.Target is not { } messageListener)
        {
            return;
        }

        try
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 7)
            {
                commonLog.LogEntry("WebSocket invoking message listener");
            }

            if (messageListener is Delegate del)
            {
                del.DynamicInvoke(data);
            }
            else
            {
                dynamic dyn = messageListener;
                dyn(data);
            }
        }
        catch (Exception ex)
        {
            if (commonLog.LoggingEnabled)
            {
                commonLog.LogEntry("WebSocket message listener error: {0}", ex.Message);
            }
        }
    }

    private async Task StopReceiveLoopAsync()
    {
        if (_receiveCts is not null)
        {
            await _receiveCts.CancelAsync().ConfigureAwait(false);
        }

        if (_receiveTask is not null)
        {
            try
            {
                await _receiveTask.ConfigureAwait(false);
            }
            catch (Exception)
            {
                // 受信ループ内の例外は ErrorOccurred で通知済み
            }
            _receiveTask = null;
        }

        _receiveCts?.Dispose();
        _receiveCts = null;
    }
    private async Task<IDisposable> AcquireSendLockAsync(CancellationToken cancellationToken)
    {
        await _sendLock.WaitAsync(cancellationToken).ConfigureAwait(false);
        return new Releaser(_sendLock);
    }


    private sealed class Releaser : IDisposable
    {
        private readonly SemaphoreSlim _semaphore;
        private bool _released;

        public Releaser(SemaphoreSlim semaphore)
        {
            _semaphore = semaphore;
        }

        public void Dispose()
        {
            if (_released)
            {
                return;
            }

            _released = true;
            _semaphore.Release();
        }
    }

    private void ThrowIfDisposed()
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
    }

    public async ValueTask DisposeAsync()
    {
        if (_disposed)
        {
            return;
        }

        _disposed = true;
        await StopReceiveLoopAsync().ConfigureAwait(false);
        _socket.Dispose();
        _sendLock.Dispose();
    }

    public DynamicMetaObject GetMetaObject(Expression parameter)
    {
        return new CHtmlClearScriptDynamicMetaObject<CHtmlWebSocket>(parameter, this);
    }

    #region IPropertBox メンバ

    public void ___setPropertyByIndex(int ___index, object val)
    {
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
        {
            commonLog.LogEntry("TODO: {0}._x__SetProppertyByIndex({1}) called...", this, ___index);
        }
    }

    public void ___setPropertyByName(string name, object val)
    {
        return;
    }

    public bool ___hasPropertyByIndex(int ___index)
    {
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
        {
            commonLog.LogEntry("{0}._x__HasProppertyByIndex({1}) called...", this, ___index);
        }
        return true;
    }

    public bool ___hasPropertyByName(string ___name)
    {
        if (string.IsNullOrEmpty(___name) == true)
        {
            return false;
        }
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
        {
            commonLog.LogEntry("{0}._x__HasProperty({1}) called...", this, ___name);
        }
        if (___name.Length == 6 && string.Equals(___name, "length", StringComparison.Ordinal) == true)
        {
            return true;
        }

            return false;
        

    }

    public object ___getPropertyByIndex(int ___index)
    {
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
        {
            commonLog.LogEntry("{0}._x__GetPropertyValueByIndex({1}) called...", this, ___index);
        }
        return null;
    }

    public object ___getPropertyByName(string ___name)
    {
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
        {
            commonLog.LogEntry("{0}.___getPropertyByName({1}) called...", this, ___name);
        }
        switch (___name)
        {

            default:
                return null;
        }

    }
    public object ___common_object_clone()
    {
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
        {
            commonLog.LogEntry("x__Clone {0} {1} called", this.GetType(), this);
        }
        return this;
    }
    public void ___deleteByIndex(int ___index)
    {
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
        {
            commonLog.LogEntry("___deleteByIndex {0} {1} called : {2}", this.GetType(), this, ___index);
        }
    }
    public void ___deleteByName(string ___name)
    {
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
        {
            commonLog.LogEntry("___deleteByName {0} {1} called : {2}", this.GetType(), this, ___name);
        }

    }
    public object[] ___getByIds()
    {
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
        {
            commonLog.LogEntry("___getByIds() {0} {1} called", this.GetType(), this);
        }
        return null;

    }
    public string ___getClassName()
    {
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
        {
            commonLog.LogEntry("___getClassName {0} {1} called", this.GetType(), this);
        }
        return this.GetType().Name;
    }
    public object ___getDefaultValue()
    {
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
        {
            commonLog.LogEntry("___getDefaultValue {0} {1} called", this.GetType(), this);
        }
        return null;
    }
    public object ___getParentScope()
    {
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
        {
            commonLog.LogEntry("___getParentScope {0} {1} called", this.GetType(), this);
        }
        return null;
    }
    public void ___setParentScope(object ___object)
    {
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
        {
            commonLog.LogEntry("___setParentScope {0} {1} called : {2}", this.GetType(), this, ___object);
        }
    }
    public object ___getProtoType()
    {
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
        {
            commonLog.LogEntry("___getProtoType {0} {1} called", this.GetType(), this);
        }
        return null;
    }
    public bool ___hasInstance(object ___object)
    {
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
        {
            commonLog.LogEntry("___hasInstance {0} {1} called : {2}", this.GetType(), this, ___object);
        }
        return false;
    }
    public bool ___instanceEquals(object ___object)
    {
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
        {
            commonLog.LogEntry("___instanceEquals {0} {1} called : {2}", this.GetType(), this, ___object);
        }
        return object.ReferenceEquals(this, ___object);
    }
    public void ___setProtoType(object ___object)
    {
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
        {
            commonLog.LogEntry("___setProtoType {0} {1} called : {2}", this.GetType(), this, ___object);
        }
    }
    public new IMutilversalObjectType multiversalClassType
    {
        get
        {
            return IMutilversalObjectType.WebSocket;
        }
    }
    public override string ToString()
    {
        return "[object WebSocket]";
    }
    #endregion
}