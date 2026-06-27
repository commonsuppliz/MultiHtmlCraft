using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Remote.Protocol.Input;
using Avalonia.Threading;
using Avalonia.VisualTree;
using MultiHtmlCraft.Core;
using MultiHtmlCraft.Interfaces;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace MultiHtmlCraft.AvaroniaControl
{
    public class MultiversalAvaroniaControl : Control, ICHtmlMultiversalControlInterface, ILogicalScrollable
    {
        // Cache SKFont / SKPaint per typeface+size to avoid repeated allocations and reflection
        private static readonly object _skCacheLock = new object();
        private static readonly System.Collections.Generic.Dictionary<(SkiaSharp.SKTypeface, float), SkiaSharp.SKFont> _skFontCache = new System.Collections.Generic.Dictionary<(SkiaSharp.SKTypeface, float), SkiaSharp.SKFont>();
        private static readonly System.Collections.Generic.Dictionary<(SkiaSharp.SKTypeface, float), SkiaSharp.SKPaint> _skPaintCache = new System.Collections.Generic.Dictionary<(SkiaSharp.SKTypeface, float), SkiaSharp.SKPaint>();
        CHtmlGraphicContainer? _avaloniaGraphicContainer = null;

        private static SkiaSharp.SKFont GetOrCreateSkFont(SkiaSharp.SKTypeface tf, float size)
        {
            var key = (tf, size);
            lock (_skCacheLock)
            {
                if (_skFontCache.TryGetValue(key, out var existing) && existing != null)
                    return existing;
                var nf = new SkiaSharp.SKFont(tf, size);
                _skFontCache[key] = nf;
                return nf;
            }
        }
        public bool skipWebAuthorityCheck
        {
            get
            {
                if (___multiversalWindow != null)
                {
                    return ___multiversalWindow.skipWebAuthorityCheck;
                }
                return false;
            }
            set
            {
                if (___multiversalWindow != null)
                {
                    ___multiversalWindow.skipWebAuthorityCheck = value;
                }
            }
        }
        // shared list of registered font files (populated on demand)
        private static readonly object _fontFilesLock = new object();
        private static readonly System.Collections.Generic.List<string> ___fontFiles = new System.Collections.Generic.List<string>();

        private static SkiaSharp.SKPaint GetOrCreateSkPaint(SkiaSharp.SKTypeface tf, float size)
        {
            var key = (tf, size);
            lock (_skCacheLock)
            {
                if (_skPaintCache.TryGetValue(key, out var existing) && existing != null)
                    return existing;
                var np = new SkiaSharp.SKPaint { Typeface = tf, TextSize = size, IsAntialias = true };
                _skPaintCache[key] = np;
                return np;
            }
        }
        private MultiHtmlCraft.Core.CHtmlMultiversalWindow? ___multiversalWindow;
        private MultiHtmlCraft.Core.CHtmlDocument? ___document;
        // paint counter used for debug/log throttling
        private int _documentPaintCount = 0;

        public event EventHandler? DocumentLoaded;

        public MultiversalAvaroniaControl()
        {
            Focusable = true;
            // create a multiversal window instance similar to WinForms control
            try
            {
                ___multiversalWindow = new MultiHtmlCraft.Core.CHtmlMultiversalWindow(null, true, IMultiversalWindowType.NormalWindow);

                if (___multiversalWindow != null)
                {
                    ___multiversalWindow.setMultiversalControl(this);
                    setMultiversalScriptScriptEngineType(IMultiversalScriptScriptEngineType.ClearScriptV8);
                }
            }
            catch
            {
                // keep constructor lightweight - failures will be surfaced when navigate is called
            }
            try
            {                 // ensure shared HttpClient is initialized similar to WinForms control behavior
                if (___multiversalWindow != null && ___multiversalWindow.hasHttpClient == false)
                {
                    var handler = new System.Net.Http.HttpClientHandler
                    {
                        AutomaticDecompression = System.Net.DecompressionMethods.All
                    };
                    var httpClient = new System.Net.Http.HttpClient(handler);
                    commonHTML.setHttpClientDefalutRequestHeaders(httpClient);
                    httpClient.Timeout = TimeSpan.FromMilliseconds(30000);
                    MultiHtmlCraft.Core.CHtmlMultiversalWindow.setHttpClient(httpClient);
                }
            }
            catch (Exception e)
            {
                if (commonLog.LoggingEnabled)
                {
                    commonLog.LogEntry("MultiversalAvaroniaControl constructor HttpClient init exception: {0}", e);
                }

            }
            try
            {
                CHtmlSkiaFontsCache.InitSkiaFontsCache();
            }
            catch (Exception e)
            {
                if (commonLog.LoggingEnabled)
                {
                    commonLog.LogEntry("MultiversalAvaroniaControl constructor exception: {0}", e);
                }
            }

            this.AttachedToVisualTree += MultiversalAvaroniaControl_AttachedToVisualTree;
            this.DetachedFromVisualTree += MultiversalAvaroniaControl_DetachedFromVisualTree;
        }

        private void MultiversalAvaroniaControl_AttachedToVisualTree(object? sender, Avalonia.VisualTreeAttachmentEventArgs e)
        {
            Debug.WriteLine($"Attached. Bounds={Bounds}");
            FindAndCacheScrollViewer();
            CacheRenderScaling();
            InvalidateVisual();
        }

        private void MultiversalAvaroniaControl_DetachedFromVisualTree(object? sender, Avalonia.VisualTreeAttachmentEventArgs e)
        {
            ClearAllCache();
        }

        // Minimal navigate implementation: creates document via core library and raises DocumentLoaded when done.
        public async Task navigate(string URL, params object[] args)
        {
            if (string.IsNullOrWhiteSpace(URL))
                throw new ArgumentException("URL is null or empty", nameof(URL));

            string strUrl = URL.Trim();
            if (!strUrl.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            {
                // not throwing here to be tolerant, but log if available
                if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
                {
                    MultiHtmlCraft.Core.commonLog.LogEntry($"MultiversalAvaroniaControl.navigate: invalid url {strUrl}");
                }
                return;
            }

            if (___multiversalWindow == null)
            {
                ___multiversalWindow = new MultiHtmlCraft.Core.CHtmlMultiversalWindow(null, true, IMultiversalWindowType.NormalWindow);
                ___multiversalWindow.setMultiversalControl(this);
            }

            // preserve last requested url
            ___multiversalWindow.___URL_Request_Current = URL;

            // ensure shared HttpClient is initialized similar to WinForms control behavior
            if (___multiversalWindow.hasHttpClient == false)
            {
                var handler = new System.Net.Http.HttpClientHandler
                {
                    AutomaticDecompression = System.Net.DecompressionMethods.All
                };
                var httpClient = new System.Net.Http.HttpClient(handler);
                commonHTML.setHttpClientDefalutRequestHeaders(httpClient);
                httpClient.Timeout = TimeSpan.FromMilliseconds(30000);
                MultiHtmlCraft.Core.CHtmlMultiversalWindow.setHttpClient(httpClient);
            }

            try
            {
                // call into core to create document
                var requestData = (args != null && args.Length > 0 && args[0] is CHtmlRequestData rd) ? rd : null;
                ___document = await MultiHtmlCraft.Core.CHtmlDocument.createDocument(CHtmlDomModeType.HTMLDOM, strUrl, ___multiversalWindow, requestData);

                // notify listeners that a document was loaded
                DocumentLoaded?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
                {
                    MultiHtmlCraft.Core.commonLog.LogEntry("MultiversalAvaroniaControl.navigate exception: {0}", ex);
                }
                throw;
            }
        }

        // synchronous helper
        public void NavigateSync(string URL)
        {
            navigate(URL).GetAwaiter().GetResult();
        }

        // Interface implementations - provide simple, non-UI stubs so core can call into this control.
        public void Invalidate()
        {
            // schedule visual invalidation on the UI thread
            try
            {
                Dispatcher.UIThread.Post(() => InvalidateVisual());
            }
            catch
            {
                // ignore dispatcher exceptions
            }
            if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
            {
                MultiHtmlCraft.Core.commonLog.LogEntry("MultiversalAvaroniaControl.Invalidate called");
            }
        }

        public void Invalidate(RectangleFSpec rectFSpec)
        {
            // For now just invalidate the whole control; rectangle-based invalidation could be mapped
            // to InvalidateVisual with a clip in a more advanced implementation.
            try
            {
                Dispatcher.UIThread.Post(() => InvalidateVisual());
            }
            catch
            {
                // ignore
            }
            if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
            {
                MultiHtmlCraft.Core.commonLog.LogEntry("MultiversalAvaroniaControl.Invalidate(RectangleFSpec) called: {0}", rectFSpec);
            }
        }

        public void DrawImage(object imagde, RectangleFSpec rectFSpec)
        {
            // Core may provide System.Drawing.Image for WinForms; Avalonia uses its own types.
            // For now, accept the call and log. UI-specific drawing must be implemented in an Avalonia control wrapper.
            if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
            {
                MultiHtmlCraft.Core.commonLog.LogEntry("MultiversalAvaroniaControl.DrawImage called with image type: {0}, rect: {1}", imagde?.GetType().FullName, rectFSpec);
            }

            // trigger a visual update; a real implementation would convert the provided image to an Avalonia Bitmap
            try
            {
                Dispatcher.UIThread.Post(() => InvalidateVisual());
            }
            catch
            {
                // ignore
            }
        }



        private static readonly Random _rand = new Random();



        public override void Render(DrawingContext context)
        {
            var grCon = this.CreateGraphicContainer(context);
            if (grCon == null) return;
            grCon.IsUIThreadPaint = true;
            grCon.AvaloniaDrawingContext = context;
            grCon.PaintRectangle = commonTypeConverter.ToRectangleFSpec(this.GetPaintRectScrollbar());
            if (___document != null && ___document.documentElement is CHtmlElement documentRootElement)
            {
                if (_documentPaintCount >= int.MaxValue)
                    _documentPaintCount = 0;
                _documentPaintCount++;
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 15 && _documentPaintCount == 1)
                {
                    commonUtils.LogElementDOMTree(documentRootElement, "", commonUtils.CJHtmlDOMElementLogModeType.ElementWidthAndHeight);
                }

                ___document.drawRootElementRecursively(documentRootElement, ref grCon);

            }
        }

        private CHtmlGraphicContainer? CreateGraphicContainer(DrawingContext context)
        {
            try
            {
                if (_avaloniaGraphicContainer == null)
                    _avaloniaGraphicContainer = new CHtmlGraphicContainer(GraphicAPIType.Avalonia);

                _avaloniaGraphicContainer.AvaloniaDrawingContext = context;
                _avaloniaGraphicContainer.PaintRectangle = commonTypeConverter.ToRectangleFSpec(this.GetPaintRectScrollbar());
                _avaloniaGraphicContainer.ControlBounds = commonTypeConverter.ToRectangleFSpec(this.GetPaintRectScrollbar());
                return _avaloniaGraphicContainer;
            }
            catch
            {
                return null;
            }
        }

        public System.Drawing.Rectangle GetPaintRectScrollbar()
        {
            double width = this.Bounds.Width;
            double height = this.Bounds.Height;
            double scale = 1.0;
            double offsetX = 0.0;
            double offsetY = 0.0;

            try
            {
                // キャッシュされた RenderScaling を使用
                if (_isRenderScalingCacheValid)
                {
                    scale = _cachedRenderScaling;
                }
                else
                {
                    CacheRenderScaling();
                    scale = _cachedRenderScaling;
                }

                // キャッシュされた ScrollViewer から Offset を取得
                if (_isScrollViewerCacheValid && _cachedScrollViewer != null)
                {
                    offsetX = _cachedScrollOffset.X;
                    offsetY = _cachedScrollOffset.Y;
                }
                else
                {
                    // キャッシュが無効な場合は再探索
                    FindAndCacheScrollViewer();
                    if (_isScrollViewerCacheValid)
                    {
                        offsetX = _cachedScrollOffset.X;
                        offsetY = _cachedScrollOffset.Y;
                    }
                }
            }
            catch (Exception ex)
            {
                if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
                {
                    MultiHtmlCraft.Core.commonLog.LogEntry($"MultiversalAvaroniaControl.GetPaintRectScrollbar error: {ex.Message}");
                }
                // エラーの場合は既定値を使用
            }

            int pixelWidth = Math.Max(0, (int)System.Math.Ceiling(width * scale));
            int pixelHeight = Math.Max(0, (int)System.Math.Ceiling(height * scale));

            int pixelOffsetX = (int)System.Math.Floor(offsetX * scale);
            int pixelOffsetY = (int)System.Math.Floor(offsetY * scale);

            return new System.Drawing.Rectangle(pixelOffsetX, pixelOffsetY, pixelWidth, pixelHeight);
        }
        // Expose the loaded document for consumers
        public MultiHtmlCraft.Core.CHtmlDocument? Document => ___document;

        // Allow setting/getting script engine type as WinForms control provides
        public void setMultiversalScriptScriptEngineType(IMultiversalScriptScriptEngineType value)
        {
            if (___multiversalWindow != null)
            {
                ___multiversalWindow.___muultiversalScriptScriptEngineType = value;
            }
        }

        public object? getMultiversalScriptScriptEngineType()
        {
            return ___multiversalWindow != null ? ___multiversalWindow.___muultiversalScriptScriptEngineType : null;
        }

        // Focus notifications for UI integration - these will write to the common log when focus changes.
        public void NotifyGotFocus()
        {
            if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
            {
                MultiHtmlCraft.Core.commonLog.LogEntry("MultiversalAvaroniaControl: Got focus");
            }
        }

        public void NotifyLostFocus()
        {
            if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
            {
                MultiHtmlCraft.Core.commonLog.LogEntry("MultiversalAvaroniaControl: Lost focus");
            }
        }

        // ScrollViewer キャッシュ用のフィールド
        private ScrollViewer? _cachedScrollViewer = null;
        private Vector _cachedScrollOffset = new Vector(0, 0);
        private double _cachedRenderScaling = 1.0;
        private bool _isScrollViewerCacheValid = false;
        private bool _isRenderScalingCacheValid = false;

        // Minimal ILogicalScrollable / IScrollable implementation so the control can participate
        // in logical scrolling. These provide safe defaults; behavior can be extended later.
        private bool _canHorizontallyScroll = false;
        private bool _canVerticallyScroll = false;
        private bool _isLogicalScrollEnabled = false;
        private Avalonia.Size _scrollSize = new Avalonia.Size(16, 16);
        private Avalonia.Size _pageScrollSize = new Avalonia.Size(100, 100);
        private Avalonia.Size _extent = new Avalonia.Size(0, 0);
        private Avalonia.Vector _offset = new Avalonia.Vector(0, 0);
        private Avalonia.Size _viewport = new Avalonia.Size(0, 0);

        // ILogicalScrollable
        public bool CanHorizontallyScroll
        {
            get => _canHorizontallyScroll;
            set => _canHorizontallyScroll = value;
        }
        public bool CanVerticallyScroll
        {
            get => _canVerticallyScroll;
            set => _canVerticallyScroll = value;
        }
        public bool IsLogicalScrollEnabled => _isLogicalScrollEnabled;
        public Avalonia.Size ScrollSize => _scrollSize;
        public Avalonia.Size PageScrollSize => _pageScrollSize;

        public event EventHandler? ScrollInvalidated;

        public void RaiseScrollInvalidated(EventArgs e)
        {
            ScrollInvalidated?.Invoke(this, e);
        }

        public Control? GetControlInDirection(NavigationDirection direction, Control? from)
        {
            // Default: no logical navigation support
            return null;
        }

        public bool BringIntoView(Control control, Avalonia.Rect rect)
        {
            // No special bring-into-view handling; return false to indicate not handled.
            return false;
        }

        // IScrollable
        public Avalonia.Size Extent => _extent;
        public Avalonia.Vector Offset
        {
            get => _offset;
            set => _offset = value;
        }
        public Avalonia.Size Viewport => _viewport;

        // キャッシュ関連メソッド
        // RenderScaling をキャッシュするメソッド（リフレクションなし）
        private void CacheRenderScaling()
        {
            try
            {
                var visualRoot = this.VisualRoot;
                if (visualRoot is TopLevel topLevel)
                {
                    _cachedRenderScaling = topLevel.RenderScaling;
                    _isRenderScalingCacheValid = true;
                }
                else if (visualRoot is Window window)
                {
                    _cachedRenderScaling = window.RenderScaling;
                    _isRenderScalingCacheValid = true;
                }
                else
                {
                    // フォールバック：デフォルト値を使用
                    _cachedRenderScaling = 1.0;
                    _isRenderScalingCacheValid = true;
                }
            }
            catch
            {
                _cachedRenderScaling = 1.0;
                _isRenderScalingCacheValid = true;
            }
        }

        // ScrollViewer を探してキャッシュするメソッド
        private void FindAndCacheScrollViewer()
        {
            try
            {
                Visual? parent = this.GetVisualParent();
                while (parent != null)
                {
                    if (parent is ScrollViewer sv)
                    {
                        // 前のScrollViewerからイベントハンドラを削除
                        if (_cachedScrollViewer != null)
                        {
                            _cachedScrollViewer.PropertyChanged -= CachedScrollViewer_PropertyChanged;
                        }

                        _cachedScrollViewer = sv;
                        _cachedScrollOffset = sv.Offset;
                        _isScrollViewerCacheValid = true;

                        // Offsetの変更を監視
                        _cachedScrollViewer.PropertyChanged += CachedScrollViewer_PropertyChanged;

                        if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
                        {
                            MultiHtmlCraft.Core.commonLog.LogEntry($"MultiversalAvaroniaControl: ScrollViewer cached with offset {_cachedScrollOffset}");
                        }
                        return;
                    }
                    parent = parent.GetVisualParent();
                }

                // ScrollViewer が見つからなかった場合
                ClearScrollViewerCache();
            }
            catch (Exception ex)
            {
                if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
                {
                    MultiHtmlCraft.Core.commonLog.LogEntry($"MultiversalAvaroniaControl: Error caching ScrollViewer: {ex.Message}");
                }
                ClearScrollViewerCache();
            }
        }


        private void CachedScrollViewer_PropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (e.Property.Name == "Offset" && sender is ScrollViewer sv)
            {
                _cachedScrollOffset = sv.Offset;

                InvalidateVisual();
            }
        }


        private void ClearScrollViewerCache()
        {
            if (_cachedScrollViewer != null)
            {
                _cachedScrollViewer.PropertyChanged -= CachedScrollViewer_PropertyChanged;
            }
            _cachedScrollViewer = null;
            _cachedScrollOffset = new Vector(0, 0);
            _isScrollViewerCacheValid = false;
        }

        // すべてのキャッシュをクリアするメソッド
        private void ClearAllCache()
        {
            ClearScrollViewerCache();
            _cachedRenderScaling = 1.0;
            _isRenderScalingCacheValid = false;
        }


        public (double HOffset, double VOffset) GetScrollOffsets()
        {
            if (_isScrollViewerCacheValid)
            {
                return (_cachedScrollOffset.X, _cachedScrollOffset.Y);
            }

            FindAndCacheScrollViewer();
            return (_cachedScrollOffset.X, _cachedScrollOffset.Y);
        }

        public double GetRenderScaling()
        {
            if (_isRenderScalingCacheValid)
            {
                return _cachedRenderScaling;
            }

            CacheRenderScaling();
            return _cachedRenderScaling;
        }


        public void InvalidateScrollViewerCache()
        {
            _isScrollViewerCacheValid = false;
            FindAndCacheScrollViewer();
        }

        public void InvalidateRenderScalingCache()
        {
            _isRenderScalingCacheValid = false;
            CacheRenderScaling();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
     
            bool isShift = e.KeyModifiers.HasFlag(KeyModifiers.Shift);


            bool isCtrl = e.KeyModifiers.HasFlag(KeyModifiers.Control);


            bool isAlt = e.KeyModifiers.HasFlag(KeyModifiers.Alt);


            bool isMeta = e.KeyModifiers.HasFlag(KeyModifiers.Meta);
            base.OnKeyDown(e);
            if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
            {
                MultiHtmlCraft.Core.commonLog.LogEntry($"MultiversalAvaroniaControl: KeyDown - {e.Key}");
            }
            if (this.___multiversalWindow != null)
            {
                var keyboardEventArgsSpec = new CHtmlMultiversalKeyboardEventArgsSpec()
                {
                    Key = ToJsCode(e.Key),
                    code = ToJsCode(e.Key),
                    KeyCode = ToJavaScriptKeyCode(e.Key),

                    AltKey = isAlt,
                    CtrlKey = isCtrl,
                    ShiftKey = isShift,
                    MetaKey = isMeta,
                };
                ___fireWindoworDocumentEvent("keydown", null, keyboardEventArgsSpec);
            }
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            bool isShift = e.KeyModifiers.HasFlag(KeyModifiers.Shift);


            bool isCtrl = e.KeyModifiers.HasFlag(KeyModifiers.Control);


            bool isAlt = e.KeyModifiers.HasFlag(KeyModifiers.Alt);


            bool isMeta = e.KeyModifiers.HasFlag(KeyModifiers.Meta);
            if (MultiHtmlCraft.Core.commonLog.LoggingEnabled)
            {
                MultiHtmlCraft.Core.commonLog.LogEntry($"MultiversalAvaroniaControl: KeyUp - {e.Key}");
            }
            if (this.___multiversalWindow != null)
            {
                var keyboardEventArgsSpec = new CHtmlMultiversalKeyboardEventArgsSpec()
                {
                    Key = ToJsCode(e.Key),
                    code = ToJsCode(e.Key),
                    KeyCode = ToJavaScriptKeyCode(e.Key),
                    AltKey = isAlt,
                    CtrlKey = isCtrl,
                    ShiftKey = isShift,
                    MetaKey = isMeta,




                };
                
                
               ___fireWindoworDocumentEvent("keyup", null, keyboardEventArgsSpec);   
            }


        }
        

        private void ___fireWindoworDocumentEvent(string eventName, CHtmlMultiversalMouseEventArgsSpec? mouseArgSpec)
        {
            ___fireWindoworDocumentEvent(eventName, mouseArgSpec, null);
        }
        private void ___fireWindoworDocumentEvent(string eventName, CHtmlMultiversalMouseEventArgsSpec? mouseArgSpec, CHtmlMultiversalKeyboardEventArgsSpec? keyArgSpec)
        {
            string logPrefix = "___fireWindoworDocumentEvent";
            if (mouseArgSpec != null)
            {
                logPrefix = ($"{logPrefix} called with eventName: {eventName}, x: {mouseArgSpec.X}, y: {mouseArgSpec.Y}, button: {mouseArgSpec.Button}, clicks: {mouseArgSpec.Clicks} delta {mouseArgSpec.DeltaY}");
                this.___multiversalWindow?.___updateMousePosition(mouseArgSpec);
            }
            if (keyArgSpec != null)
            {

                logPrefix = ($"{logPrefix} called with eventName: {eventName}, keyArgSpec.Keys :{keyArgSpec.Key} keyArgs.Shift :{keyArgSpec.ShiftKey} keyCode : {keyArgSpec.KeyCode}");
                this.___multiversalWindow?.___updateKeyboardState(keyArgSpec.Key, keyArgSpec.ShiftKey, keyArgSpec.CtrlKey, keyArgSpec.AltKey, keyArgSpec.MetaKey);
            }
            try
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry($"{logPrefix}");
                }
                    switch (eventName)
                {
                    case "mousemove":
                    case "mousedown":
                    case "mouseleave":
                    case "mouseup":
                    case "click":
                    case "dblclick":
                    case "mousewheel":
                    case "wheel":
                    case "contextmenu":
                    case "mousehover":
                    case "mouseover":
                    case "mouseout":
                    case "mouseenter":

                        ___executeWindowDocumentEventFunction(eventName, mouseArgSpec);
                        this.___multiversalWindow?.___event.___resetToDefaults();
                        return;
                        break;
                    case "keydown":
                    case "keypress":
                    case "keyup":

                        var keyEvent = keyArgSpec;
                        ___executeWindowDocumentEventFunction(eventName, keyArgSpec);
                        this.___multiversalWindow?.___event.___resetToDefaults();
                        return;
                        break;
                    default:

                        break;
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                {
                    commonLog.LogEntry($"___fireWindoworDocumentEvent Not Implemented {logPrefix}, {ex}");
                }
            }
            return;
        }
        
        private void ___executeWindowDocumentEventFunction(string eventType, object eventObj)
        {

            var window = this.___multiversalWindow;
            var doc = window?.___document;
            if (doc == null || doc.___IsHtmlParseCompleted == false)
                return;
            bool isWindowFuncExist = false;
            bool isDocumentFuncExist = false;
            object? winFunc = null;
            object? docFunc = null;
            switch (eventType)
            {
                case "dblclick":
                    winFunc = doc.ondblclick;
                    break;
                case "keydown":

                     winFunc = doc.___WindowKeyDownFunctionWeakReference != null ? doc.___WindowKeyDownFunctionWeakReference.Target : null;
                    if (winFunc == null)
                    {
                        winFunc = doc.___WindowKeyDownFunctionStrongRef;
                    }
                    break;
                case "keypress":
                    winFunc = doc.___WindowKeyDownFunctionWeakReference != null ? doc.___WindowKeyDownFunctionWeakReference.Target : null;
                    break;
                case "keyup":
                    winFunc = doc.___WindowKeyUpFunctionWeakReference != null ? doc.___WindowKeyUpFunctionWeakReference.Target : null;
                    if (winFunc == null)
                    {
                        winFunc = doc.___WindowKeyUpFunctionStrongRef;
                    }
                    break;

                case "click":

                    winFunc = doc.onclick;

                    break;
                case "mouseleave":
                    winFunc = doc.onmousedown;
                    break;


                case "mousemove":


                    winFunc = doc.onmousemove;
                    if (winFunc != null)
                    {
                        isWindowFuncExist = true;
                        goto WindowOrDocumentFunctionFound;
                        break;
                    }
                    docFunc = doc.___WindowMouseMoveFunctionWeakReference != null ? doc.___WindowMouseMoveFunctionWeakReference.Target : null;
                    if (docFunc != null)
                    {
                        isDocumentFuncExist = true;
                        goto WindowOrDocumentFunctionFound;
                        break;
                    }
                    break;



                case "mousedown":

                    docFunc = doc.___WindowMouseDownFunctionWeakReference != null ? doc.___WindowMouseDownFunctionWeakReference.Target : null;
                    break;
                case "mousewheel":

                    docFunc = doc.___WindowMouseWheelFunctionWeakReference != null ? doc.___WindowMouseWheelFunctionWeakReference.Target : null;
                    break;
                case "mouseup":
                    winFunc = doc.onmouseup;
                    docFunc = doc.___WindowMouseUpFunctionWeakReference != null ? doc.___WindowMouseUpFunctionWeakReference.Target : null;
                    break;


                default:
                    break;
            }


        WindowOrDocumentFunctionFound:

            try
            {
                if (winFunc != null)
                {
                    window.___executeEventFunction(eventType, null, winFunc, new object[] { eventObj }, 1);
                }
                else if (docFunc != null)
                {
                    window.___executeEventFunction(eventType, null, docFunc, new object[] { eventObj }, 1);
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                {
                    commonLog.LogEntry("___executeWindowDocumentEventFunction Exception: {0}", ex);
                }
            }
            return;
        }

        protected override void OnPointerMoved(PointerEventArgs e)
        {
            base.OnPointerMoved(e);
            CHtmlMultiversalMouseEventArgsSpec mouseArg = new CHtmlMultiversalMouseEventArgsSpec();
            var pos = e.GetPosition(this);
            mouseArg.X = (int)Math.Round(pos.X);
            mouseArg.Y = (int)Math.Round(pos.Y);


            if (this.___multiversalWindow != null && this.___multiversalWindow.document != null &&      
              this.___multiversalWindow.___document.___WindowMouseMoveFunctionWeakReference != null)
            {
                ___fireWindoworDocumentEvent("mousemove", mouseArg);
            
            }
        }
        protected override void OnPointerCaptureLost(PointerCaptureLostEventArgs e)
        {
            base.OnPointerCaptureLost(e);
        }
        protected override void OnPointerEntered(PointerEventArgs e)
        {
            base.OnPointerEntered(e);
        }
        protected override void OnPointerExited(PointerEventArgs e)
        {
            base.OnPointerExited(e);
            CHtmlMultiversalMouseEventArgsSpec mouseArg = new CHtmlMultiversalMouseEventArgsSpec();
            var pos = e.GetPosition(this);
            mouseArg.X = (int)pos.X;
            mouseArg.Y = (int)pos.Y;

            ___fireWindoworDocumentEvent("mouseleave", mouseArg);
        }
        protected override void OnPointerReleased(PointerReleasedEventArgs e)
        {
            base.OnPointerReleased(e);
        }
        protected override void OnPointerWheelChanged(PointerWheelEventArgs e)
        {
            base.OnPointerWheelChanged(e);
        }
        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);
        }
        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);
            
            this.Focus();
             CHtmlMultiversalMouseEventArgsSpec mouseArg = new CHtmlMultiversalMouseEventArgsSpec();
            var mouseInfo = e.GetCurrentPoint(this);
            mouseArg.X = (int)mouseInfo.Position.X;
            mouseArg.Y = (int)mouseInfo.Position.Y;
            if(mouseInfo.Properties.IsLeftButtonPressed)
            {
                   mouseArg.Button = 0;
            }else if(mouseInfo.Properties.IsMiddleButtonPressed)
            {
                    mouseArg.Button = 1;
            }
            else if(mouseInfo.Properties.IsRightButtonPressed)
            {
                    mouseArg.Button = 2;
            }

            ___fireWindoworDocumentEvent("mousedown", mouseArg);

        }


        public static int ToJavaScriptKeyCode(Avalonia.Input.Key key)
        {
            // 計算用に数値を保持
            int kv = (int)key;

            return key switch
            {
                Avalonia.Input.Key.LeftShift => 16,
                Avalonia.Input.Key.RightShift => 16,
                Avalonia.Input.Key.LeftCtrl => 17,
                Avalonia.Input.Key.RightCtrl => 17,
                Avalonia.Input.Key.LeftAlt => 18,
                Avalonia.Input.Key.RightAlt => 18,

                // 特殊キー
                Avalonia.Input.Key.Back => 8,
                Avalonia.Input.Key.Tab => 9,
                Avalonia.Input.Key.Enter => 13,
                Avalonia.Input.Key.Pause => 19,
                Avalonia.Input.Key.CapsLock => 20,
                Avalonia.Input.Key.Escape => 27,
                Avalonia.Input.Key.Space => 32,
                Avalonia.Input.Key.PageUp => 33,
                Avalonia.Input.Key.PageDown => 34,
                Avalonia.Input.Key.End => 35,
                Avalonia.Input.Key.Home => 36,
                Avalonia.Input.Key.Left => 37,
                Avalonia.Input.Key.Up => 38,
                Avalonia.Input.Key.Right => 39,
                Avalonia.Input.Key.Down => 40,
                Avalonia.Input.Key.PrintScreen => 44,
                Avalonia.Input.Key.Insert => 45,
                Avalonia.Input.Key.Delete => 46,

                // 数字 (0-9) : keyCode 48-57
                _ when key >= Avalonia.Input.Key.D0 && key <= Avalonia.Input.Key.D9
                    => kv - (int)Avalonia.Input.Key.D0 + 48,

                // アルファベット (A-Z) : keyCode 65-90
                _ when key >= Avalonia.Input.Key.A && key <= Avalonia.Input.Key.Z
                    => kv - (int)Avalonia.Input.Key.A + 65,

                // テンキー (0-9) : keyCode 96-105
                _ when key >= Avalonia.Input.Key.NumPad0 && key <= Avalonia.Input.Key.NumPad9
                    => kv - (int)Avalonia.Input.Key.NumPad0 + 96,

                // F1-F12 : keyCode 112-123
                _ when key >= Avalonia.Input.Key.F1 && key <= Avalonia.Input.Key.F12
                    => kv - (int)Avalonia.Input.Key.F1 + 112,

                // 記号類
                Avalonia.Input.Key.OemSemicolon => 186,
                Avalonia.Input.Key.OemPlus => 187,
                Avalonia.Input.Key.OemComma => 188,
                Avalonia.Input.Key.OemMinus => 189,
                Avalonia.Input.Key.OemPeriod => 190,
                Avalonia.Input.Key.OemQuestion => 191,
                Avalonia.Input.Key.OemTilde => 192,
                Avalonia.Input.Key.OemOpenBrackets => 219,
                Avalonia.Input.Key.OemPipe => 220,
                Avalonia.Input.Key.OemCloseBrackets => 221,
                Avalonia.Input.Key.OemQuotes => 222,

                _ => 0
            };
        }
        public static string ToJsCode(Avalonia.Input.Key key)
        {
            return key switch
            {
                // 矢印キー
                Avalonia.Input.Key.Left => "ArrowLeft",
                Avalonia.Input.Key.Right => "ArrowRight",
                Avalonia.Input.Key.Up => "ArrowUp",
                Avalonia.Input.Key.Down => "ArrowDown",

                // 特殊キー
                Avalonia.Input.Key.Back => "Backspace",
                Avalonia.Input.Key.Escape => "Escape",
                Avalonia.Input.Key.Tab => "Tab",
                Avalonia.Input.Key.Enter => "Enter",
                Avalonia.Input.Key.Space => " ",
                Avalonia.Input.Key.Delete => "Delete",

                // 修飾キー
                Avalonia.Input.Key.LWin => "MetaLeft",
                Avalonia.Input.Key.RWin => "MetaRight",
                Avalonia.Input.Key.LeftShift => "ShiftLeft",
                Avalonia.Input.Key.RightShift => "ShiftRight",
                Avalonia.Input.Key.LeftCtrl => "ControlLeft",
                Avalonia.Input.Key.RightCtrl => "ControlRight",
                Avalonia.Input.Key.LeftAlt => "AltLeft",
                Avalonia.Input.Key.RightAlt => "AltRight",

               
                _ when key >= Avalonia.Input.Key.D0 && key <= Avalonia.Input.Key.D9
                    => $"Digit{key.ToString().Substring(1)}",

     
                _ when key >= Avalonia.Input.Key.A && key <= Avalonia.Input.Key.Z
                    => $"Key{key}",

               
                _ when key >= Avalonia.Input.Key.NumPad0 && key <= Avalonia.Input.Key.NumPad9
                    => key.ToString().Replace("NumPad", "Numpad"),

               
                _ => key.ToString()
            };
        }
    }
}
