using ClearScriptProcessor;
using Microsoft.ClearScript;
using Microsoft.ClearScript.JavaScript;
using Microsoft.ClearScript.V8;
using MultiHtmlCraft.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClearScriptProcessor
{

    public class ClearScriptProcessorScope : IMultiversalScriptScope, IDisposable
    {
        private V8ScriptEngine? _v8Engine = null;
        private bool _isInitCompleted = false;
        private bool _isDisposed = false;
        private IMultiversalWindow _multiversalWindow = null;
        private ICHtmlDocumentInterface _document = null;
        private ClearScriptProcessor? processor = null;
        private object? _consoleInstance = null;
        // Delegates used to dispatch ScriptObject overloads when document is available
        private Action<string, ScriptObject>? _docAddSoHandler = null;
        private Action<string, ScriptObject, object>? _docAdd3SoHandler = null;
        // Map ScriptObject -> HandlerWrapper instance so we pass a stable object with public Invoke method to host
        private readonly System.Collections.Concurrent.ConcurrentDictionary<ScriptObject, HandlerWrapper> _handlerWrappers = new System.Collections.Concurrent.ConcurrentDictionary<ScriptObject, HandlerWrapper>(ReferenceEqualityComparer<ScriptObject>.Default);

        // Reference equality comparer helper
        private class ReferenceEqualityComparer<T> : IEqualityComparer<T> where T : class
        {
            public static ReferenceEqualityComparer<T> Default { get; } = new ReferenceEqualityComparer<T>();
            public bool Equals(T x, T y) => object.ReferenceEquals(x, y);
            public int GetHashCode(T obj) => System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(obj);
        }

        // Handler wrapper with a public Invoke method so host reflection can call it safely
        private class HandlerWrapper
        {
            private readonly ScriptObject _so;
            private readonly V8ScriptEngine _engine;
            public HandlerWrapper(ScriptObject so, V8ScriptEngine engine)
            {
                _so = so;
                _engine = engine;
            }
            // public method intentionally named Invoke to be discovered by Call Function Internal reflection
            public object Invoke(object[] args)
            {
                try
                {
                    // First, prefer ClearScript's direct invoke on ScriptObject which is safe
                    try
                    {
                        return _so.InvokeAsFunction(args ?? Array.Empty<object>());
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"HandlerWrapper.Invoke: InvokeAsFunction failed: {ex.GetType().Name} {ex.Message}");
                    }

                    // Fallback: check for a global helper without triggering the dynamic binder
                    bool exists = false;
                    try
                    {
                        var eval = _engine.Evaluate("(typeof ___universalApply !== 'undefined')");
                        if (eval is bool b && b) exists = true;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"HandlerWrapper.Invoke: evaluate presence check failed: {ex.GetType().Name} {ex.Message}");
                        exists = false;
                    }

                    if (!exists)
                    {
                        try
                        {
                            _engine.Execute("function ___universalApply(f, args){ if(typeof f === 'function') { return f.apply(null, args || []); } else if (f && typeof f.Invoke === 'function'){ return f.Invoke(args); } throw new Error('Target is not a function'); }");
                            exists = true;
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"HandlerWrapper.Invoke: failed to inject ___universalApply: {ex.GetType().Name} {ex.Message}");
                        }
                    }

                    if (exists)
                    {
                        try
                        {
                            return _engine.Invoke("___universalApply", _so, args ?? Array.Empty<object>());
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"HandlerWrapper.Invoke fallback engine.Invoke failed: {ex.GetType().Name} {ex.Message}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"HandlerWrapper.Invoke failed: {ex.GetType().Name} {ex.Message}");
                }
                return null;
            }
        }

        public ClearScriptProcessorScope()
        {

            _isDisposed = false;
            processor = new ClearScriptProcessor();
            processor.multiversalscope = this;
            processor.clearscriptengine = _v8Engine;

        }
        public void Dispose()
        {
            try
            {
                _v8Engine?.Dispose();
            }
            catch (ObjectDisposedException)
            {
                // already disposed - swallow
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Dispose engine failed: {ex.GetType().Name} - {ex.Message}");
            }
            _isDisposed = true;
        }
        public V8ScriptEngine engine
        {
            get { return _v8Engine; }
        }
        public void disposeScriptEngine()
        {
            try
            {
                _v8Engine?.Dispose();
            }
            catch (ObjectDisposedException) { }
            catch (Exception ex) { Debug.WriteLine($"disposeScriptEngine failed: {ex}"); }
            _isDisposed = true;
        }

        public string getMultivasalScopeName()
        {
            return nameof(ClearScriptProcessorScope);
        }
        private bool _enableDebug = false;
        private bool _enableScriptLogging = false;
        public bool EnableScriptLogging
        {
            get
            {
                return _enableScriptLogging;
            }
            set
            {
                _enableScriptLogging = value;

            }
        }
        public bool EnableDebug
        {
            get
            {
                return _enableDebug;
            }
            set
            {
                _enableDebug = value;
            }
        }

        private static List<string> _multiversalInvokeScriptNames = createNames();
        private static List<string> createNames()
        {
            List<string> names = new List<string>();
            names.Add("text/javascript");
            names.Add("text/json");
            names.Add("javascript");
            names.Add("Javascript");
            names.Add("application/javascript");
            names.Add("application/json");
            names.Add("application/x-javascript");
            names.Add("application/x-javascript; charset=UTF-8");
            names.Add("application/x-javascript; charset=ISO-8859-1");
            names.Add("application/x-javascript; charset=ISO-8859-15");
            names.Add("application/x-javascript; charset=windows-1252");
            names.Add("application/x-javascript; charset=windows-1251");
            names.Add("application/x-javascript; charset=windows-1250");
            names.Add("application/x-javascript; charset=windows-1253");
            names.Add("application/x-javascript; charset=windows-1254");
            names.Add("application/x-javascript; charset=windows-1255");
            names.Add("application/x-javascript; charset=windows-1256");
            names.Add("application/x-javascript; charset=windows-1257");
            names.Add("application/x-javascript; charset=gb2312");
            names.Add("application/x-javascript; charset=sjis");
            names.Add("application/x-javascript; charset=shift_jis");
            names.Add("application/x-javascript; charset=shiftjis");

            return names;
        }
        public string[] getMultiversalInvokeScriptNames()
        {
            return _multiversalInvokeScriptNames.ToArray();
        }

        public IMultiversalScriptProcessor getMultiversalScriptProcessor()
        {
            if (processor.multiversalscope == null)
            {
                processor.multiversalscope = this;
            }
            if (processor.clearscriptengine == null)
            {
                processor.clearscriptengine = _v8Engine;

            }
            return processor;
        }

        public IMultiversalWindow getMultiversalWindow()
        {
            return _multiversalWindow;
        }

        public IMultiversalWindowType getMutilversalWindowType()
        {
            throw new NotImplementedException();
        }

        public void initScriptEngine()
        {
            if (!_isInitCompleted)
            {
                if (this._multiversalWindow == null)
                {
                    throw new InvalidOperationException("MultiversalWindow is not set before initializing script engine. its instance should be created be before initScriptEngine()");
                }
#if DEBUG
                _v8Engine = new V8ScriptEngine(
   V8ScriptEngineFlags.EnableDebugging

)
                {
                    // AllowReflection true to improve interop with hosted dynamic objects (reduces DynamicHelpers errors)
                    AllowReflection = true,

                };

#else
                _v8Engine = new V8ScriptEngine(
)
                {
                    // AllowReflection true to improve interop with hosted dynamic objects (reduces DynamicHelpers.errors)
                    AllowReflection = true

                };
            
#endif

                _v8Engine.DisableExtensionMethods = false;
                // Register placeholder host functions for ScriptObject overloads early so JS can call them before document is bound.
                // These placeholders dispatch to delegates that are assigned when setDcoument is called.
                _v8Engine.AddHostObject("__doc_addEventListener_so", new Action<string, ScriptObject>((eventName, handler) =>
                {
                    try
                    {
                        if (_docAddSoHandler != null)
                        {
                            _docAddSoHandler(eventName, handler);
                            return;
                        }
                        Debug.WriteLine("__doc_addEventListener_so called but no handler assigned yet.");
                    }
                    catch (Exception ex) { Debug.WriteLine($"__doc_addEventListener_so dispatch failed: {ex}"); }
                }));

                _v8Engine.AddHostObject("__doc_addEventListener3_so", new Action<string, ScriptObject, object>((eventName, handler, options) =>
                {
                    try
                    {
                        if (_docAdd3SoHandler != null)
                        {
                            _docAdd3SoHandler(eventName, handler, options);
                            return;
                        }
                        Debug.WriteLine("__doc_addEventListener3_so called but no handler assigned yet.");
                    }
                    catch (Exception ex) { Debug.WriteLine($"__doc_addEventListener3_so dispatch failed: {ex}"); }
                }));

                // Release モードでも window, self, globalThis を設定する
                engine.Execute(@"
            // グローバルオブジェクトを this として扱う
            (function() {
                // window, self, globalThis をグローバルオブジェクトに設定
                this.window = this;
                this.self = this;
                this.globalThis = this;
            })();
        ");

                createStandardObjects();

                // Provide safe JS stubs for timer functions so scripts can call them even
                // before the real window proxy (__host_window) is attached. If the host
                // window is later provided, these stubs will attempt to delegate to it.
                _v8Engine.Execute(@"
                    (function(){
                        try {
                            if (typeof setTimeout === 'undefined') {
                                setTimeout = function(){
                                    try {
                                        if (typeof __host_window !== 'undefined' && __host_window && typeof __host_window.setTimeout === 'function') {
                                            return __host_window.setTimeout.apply(__host_window, arguments);
                                        }
                                    } catch(e) {}
                                    return 0;
                                };
                            }
                            if (typeof setInterval === 'undefined') {
                                setInterval = function(){
                                    try {
                                        if (typeof __host_window !== 'undefined' && __host_window && typeof __host_window.setInterval === 'function') {
                                            return __host_window.setInterval.apply(__host_window, arguments);
                                        }
                                    } catch(e) {}
                                    return 0;
                                };
                            }
                            if (typeof clearTimeout === 'undefined') {
                                clearTimeout = function(id){
                                    try {
                                        if (typeof __host_window !== 'undefined' && __host_window && typeof __host_window.clearTimeout === 'function') {
                                            return __host_window.clearTimeout(id);
                                        }
                                    } catch(e) {}
                                    return undefined;
                                };
                            }
                            if (typeof clearInterval === 'undefined') {
                                clearInterval = function(id){
                                    try {
                                        if (typeof __host_window !== 'undefined' && __host_window && typeof __host_window.clearInterval === 'function') {
                                            return __host_window.clearInterval(id);
                                        }
                                    } catch(e) {}
                                    return undefined;
                                };
                            }
                            if (typeof requestAnimationFrame === 'undefined') {
                                requestAnimationFrame = function(){
                                    try {
                                        if (typeof __host_window !== 'undefined' && __host_window && typeof __host_window.requestAnimationFrame === 'function') {
                                            return __host_window.requestAnimationFrame.apply(__host_window, arguments);
                                        }
                                    } catch(e) {}
                                    return 0;
                                };
                            }
                            if (typeof cancelAnimationFrame === 'undefined') {
                                cancelAnimationFrame = function(id){
                                    try {
                                        if (typeof __host_window !== 'undefined' && __host_window && typeof __host_window.cancelAnimationFrame === 'function') {
                                            return __host_window.cancelAnimationFrame(id);
                                        }
                                    } catch(e) {}
                                    return undefined;
                                };
                            }
                        } catch(e) {}
                    })();
                ");
                _v8Engine.Evaluate(@"
    (function() {
        var status = {
            hasModule: typeof module !== 'undefined',
            hasDefine: typeof define !== 'undefined',
            moduleType: typeof module,
            defineType: typeof define,
            exportsType: typeof exports,
            requireType: typeof require,
            windowExists: typeof window !== 'undefined'
        };


        console.log('[ClearScript Debug] Current Environment:', JSON.stringify(status, null, 2));

        
        globalThis._originalModule = typeof module !== 'undefined' ? module : undefined;
        globalThis._originalDefine = typeof define !== 'undefined' ? define : undefined;
        
      
        globalThis.module = undefined;
        globalThis.define = undefined;
        globalThis.require = undefined;
        window.module = undefined;
        window.define = undefined;
        window.require = undefined;
        console.log('[ClearScript Debug] module/define/require have been disabled for jQuery loading.');
    })();
");
                createWindowFunctionSortedList();

#if DEBUG
                // テスト: 各参照が同じオブジェクトを指しているか確認 (console が登録された後に実行)
                // Note: console.log を使用せず、代わりに Debug.WriteLine を使用
                try
                {
                    var result1 = engine.Evaluate("window === self");
                    var result2 = engine.Evaluate("self === globalThis");
                    Debug.WriteLine($"window === self: {result1}");
                    Debug.WriteLine($"self === globalThis: {result2}");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"initScriptEngine debug test failed: {ex.Message}");
                }
#endif

                _isInitCompleted = true;
                // 重要: もし window が先にセットされている場合、ここで proxy 作成処理を確実に実行する
                try
                {
                    if (this._multiversalWindow != null)
                    {
                        Debug.WriteLine("initScriptEngine: multiversalWindow already set — calling setMultiversalWindow to create proxy.");
                        // 呼び出し順に関係なくプロキシが作られるようにする
                        setMultiversalWindow(this._multiversalWindow);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"initScriptEngine: failed to finalize window proxy creation: {ex.GetType().Name} - {ex.Message}");
                }
            }
        }

        public bool isDefaultMultiversalProcessor()
        {
            return true;
        }

        public bool isInitCompleted()
        {
            return _isInitCompleted;
        }

        public void relaseMultiversal()
        {
            _multiversalWindow = null;
        }
        private int _timeout = -1;
        public void setTimeout(int timeout)
        {
            _timeout = timeout;
        }

        public void setMultiversalWindow(IMultiversalWindow window)
        {
            this._multiversalWindow = window;

            Debug.WriteLine($"setMultiversalWindow called. window: {window?.ToString() ?? "null"}, isInitCompleted: {_isInitCompleted}");

            if (!_isInitCompleted || _v8Engine == null)
            {
                Debug.WriteLine("setMultiversalWindow: engine not initialized yet - proxy will be created later.");
                return;
            }

            try
            {
                
                //_v8Engine.AddHostObject("__host_window", HostItemFlags.GlobalMembers, window);
                _v8Engine.AddHostObject("__host_window",  window);
                // Provide host-side delegate shims for timer functions. The window implementation
                // often implements timers as explicit interface methods which are not visible as
                // public members to ClearScript's host lookup. Expose small delegates that call
                // through the IMultiversalWindow interface so JS can always call timers.
                // Use object-typed parameter and normalize JS arrays/ScriptObject into object[] to
                // avoid ClearScript argument conversion ArgumentException.
                object[] normalizeHostDelegateArgs(object maybeArray)
                {
                    try
                    {
                        if (maybeArray == null) return Array.Empty<object>();
                        if (maybeArray is object[] oa) return oa;
                        if (maybeArray is ScriptObject so)
                        {
                            try
                            {
                                var lenObj = so.GetProperty("length");
                                int len = 0; try { len = Convert.ToInt32(lenObj); } catch { len = 0; }
                                var list = new object[len];
                                for (int i = 0; i < len; i++)
                                {
                                    try { list[i] = so.GetProperty(i.ToString()); } catch { list[i] = null; }
                                }
                                return list;
                            }
                            catch { }
                        }
                        if (maybeArray is System.Collections.IEnumerable ie && !(maybeArray is string))
                        {
                            var l = new List<object>();
                            foreach (var o in ie) l.Add(o);
                            return l.ToArray();
                        }
                        return new object[] { maybeArray };
                    }
                    catch { return new object[] { maybeArray }; }
                }

                try
                {
                    _v8Engine.AddHostObject("__host_window_setInterval_delegate", new Func<object, object>((arg) =>
                    {
                        try { var a = normalizeHostDelegateArgs(arg); return ((IMultiversalWindow)window).setInterval(a); } catch { return null; }
                    }));
                }
                catch { }
                try
                {
                    _v8Engine.AddHostObject("__host_window_setTimeout_delegate", new Func<object, object>((arg) =>
                    {
                        try { var a = normalizeHostDelegateArgs(arg); return ((IMultiversalWindow)window).setTimeout(a); } catch { return null; }
                    }));
                }
                catch { }
                try
                {
                    _v8Engine.AddHostObject("__host_window_requestAnimationFrame_delegate", new Func<object, object>((arg) =>
                    {
                        try { var a = normalizeHostDelegateArgs(arg); return ((IMultiversalWindow)window).requestAnimationFrame(a); } catch { return null; }
                    }));
                }
                catch { }
                try
                {
                    _v8Engine.AddHostObject("__host_window_cancelAnimationFrame_delegate", new Func<object, object>((arg) =>
                    {
                        try { var a = normalizeHostDelegateArgs(arg); return ((IMultiversalWindow)window).cancelAnimationFrame(a); } catch { return null; }
                    }));
                }
                catch { }

                // Additionally, try to call document-level interval/timeouts which ultimately
                // should delegate to CHtmlDocument.setIntervalInner / setTimeoutInner. This
                // helps in cases where the window implementation does not directly forward to
                // the document or implements explicit interface members that behave differently.
                try
                {
                    _v8Engine.AddHostObject("__host_window_document_setInterval_delegate", new Func<object, object>((arg) =>
                    {
                        try
                        {
                            var a = normalizeHostDelegateArgs(arg);
                            Debug.WriteLine($"__host_window_document_setInterval_delegate called, args.Length={a?.Length}");
                            if (_v8Engine != null)
                            {
                                try
                                {
                                    // Use engine.Invoke to call the host document method in the engine context so ClearScript
                                    // marshaling handles ScriptObject and function invocation correctly.
                                    if (_v8Engine.Evaluate("typeof __host_document !== 'undefined'") is bool b && b)
                                    {
                                        try
                                        {
                                            var func = _v8Engine.Evaluate("__host_document.setInterval_viaWindow");
                                            if (func != null)
                                            {
                                                return _v8Engine.Invoke("___universalApply", func, a);
                                            }
                                        }
                                        catch { }
                                    }
                                }
                                catch { }
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("__host_window_document_setInterval_delegate error: " + ex.Message);
                        }
                        return null;
                    }));
                }
                catch { }
                try
                {
                    _v8Engine.AddHostObject("__host_window_document_setTimeout_delegate", new Func<object, object>((arg) =>
                    {
                        try
                        {
                            var a = normalizeHostDelegateArgs(arg);
                            Debug.WriteLine($"__host_window_document_setTimeout_delegate called, args.Length={a?.Length}");
                            if (_v8Engine != null)
                            {
                                try
                                {
                                    if (_v8Engine.Evaluate("typeof __host_document !== 'undefined'") is bool b && b)
                                    {
                                        try
                                        {
                                            var func = _v8Engine.Evaluate("__host_document.setTimeout_viaWindow");
                                            if (func != null)
                                            {
                                                return _v8Engine.Invoke("___universalApply", func, a);
                                            }
                                        }
                                        catch { }
                                    }
                                }
                                catch { }
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("__host_window_document_setTimeout_delegate error: " + ex.Message);
                        }
                        return null;
                    }));
                }
                catch { }

                _v8Engine.Execute(@"
            (function(){
                var host = __host_window;
                var target = {};

                // Basic window methods delegated to host (guarded in case host doesn't implement them)
                target.setTimeout = function(){ try { if (typeof __host_window_setTimeout_delegate !== 'undefined') return __host_window_setTimeout_delegate(Array.prototype.slice.call(arguments)); if (host && typeof host.setTimeout === 'function') return host.setTimeout.apply(host, arguments); } catch(e){} return undefined; };
                target.setInterval = function(){ try { if (typeof __host_window_setInterval_delegate !== 'undefined') return __host_window_setInterval_delegate(Array.prototype.slice.call(arguments)); if (host && typeof host.setInterval === 'function') return host.setInterval.apply(host, arguments); } catch(e){} return undefined; };
                target.clearTimeout = function(id){ try { if (host && typeof host.clearTimeout === 'function') return host.clearTimeout(id); } catch(e){} return undefined; };
                target.clearInterval = function(id){ try { if (host && typeof host.clearInterval === 'function') return host.clearInterval(id); } catch(e){} return undefined; };
                target.requestAnimationFrame = function(){ try { if (typeof __host_window_requestAnimationFrame_delegate !== 'undefined') return __host_window_requestAnimationFrame_delegate(Array.prototype.slice.call(arguments)); if (host && typeof host.requestAnimationFrame === 'function') return host.requestAnimationFrame.apply(host, arguments); } catch(e){} return undefined; };
                target.cancelAnimationFrame = function(){ try { if (typeof __host_window_cancelAnimationFrame_delegate !== 'undefined') return __host_window_cancelAnimationFrame_delegate(Array.prototype.slice.call(arguments)); if (host && typeof host.cancelAnimationFrame === 'function') return host.cancelAnimationFrame.apply(host, arguments); } catch(e){} return undefined; };
                target.alert = function(){ try { if (host && typeof host.alert === 'function') return host.alert.apply(host, arguments); } catch(e){} return undefined; };
                target.confirm = function(){ try { if (host && typeof host.confirm === 'function') return host.confirm.apply(host, arguments); } catch(e){} return undefined; };
                target.prompt = function(){ try { if (host && typeof host.prompt === 'function') return host.prompt.apply(host, arguments); } catch(e){} return undefined; };
                target.open = function(){ try { if (host && typeof host.open === 'function') return host.open.apply(host, arguments); } catch(e){} return undefined; };

                target.addEventListener = function(name, handler, options){
                    if (arguments.length >= 3) return host.addEventListener(name, handler, options);
                    if (arguments.length == 2) return host.addEventListener(name, handler);
                    return host.addEventListener(name);
                };
                target.removeEventListener = function(name, handler, options){
                    if (arguments.length >= 3) return host.removeEventListener(name, handler, options);
                    if (arguments.length == 2) return host.removeEventListener(name, handler);
                    return host.removeEventListener(name);
                };

                var proxy = new Proxy(target, {
                    get: function(t, prop) {
                        if (prop in t) return t[prop];
                        // Check globalThis first for properties set by scripts (preserves variables like Phoria)
                        try {
                            var globalVal = globalThis[prop];
                            if (globalVal !== undefined) return globalVal;
                        } catch(e) {}
                        try {
                            var v;
                            try { v = host.get(prop); } catch(e) { v = undefined; }
                            if (v === null || v === undefined || v === globalThis.undefined) return v;
                            if (typeof v === 'function') {
                                return function(){ return v.apply(host, arguments); };
                            }
                            return v;
                        } catch(e) { return undefined; }
                    },
                    set: function(t, prop, value) {
                        // IMPORTANT: If value is a function, store it in the target object (pure JS)
                        // AND do NOT pass it to host.put() which corrupts V8 function callable nature.
                        // Also try to define a getter on globalThis that returns the function from target,
                        // so bare $ access works correctly.
                        if (typeof value === 'function') {
                            // Store in pure JS target object - this preserves callable nature
                            t[prop] = value;
                            // Define a getter on globalThis that returns from target
                            // This preserves callable nature for bare $ access
                            try {
                                var localTarget = t;
                                var localProp = prop;
                                Object.defineProperty(globalThis, prop, {
                                    get: function() { return localTarget[localProp]; },
                                    set: function(v) { 
                                        if (typeof v === 'function') {
                                            localTarget[localProp] = v;
                                        } else {
                                            // Handle reassignment to non-function
                                            delete globalThis[localProp];
                                            globalThis[localProp] = v;
                                        }
                                    },
                                    configurable: true,
                                    enumerable: true
                                });
                            } catch(e) {
                                // Fallback: direct assignment (may corrupt but better than nothing)
                                try { globalThis[prop] = value; } catch(e2) {}
                            }
                            // Do NOT call host.put for functions - it corrupts callable nature
                            return true;
                        }
                        // CRITICAL: Store 'document' and other JS Proxy objects in pure JS target
                        // to preserve method callable nature. Passing them to host.put() corrupts them.
                        if (prop === 'document') {
                            t[prop] = value;
                            try { globalThis.document = value; } catch(e) {}
                            return true;
                        }
                        // Also store pure JS objects (Proxies) in target to preserve their methods
                        // Check if value is an object that might be a JS Proxy (has methods defined)
                        if (value !== null && typeof value === 'object' && !(value.constructor && value.constructor.name && value.constructor.name.indexOf('V8') >= 0)) {
                            // Check if it has JS-defined function properties (indicating it's a Proxy or pure JS object)
                            try {
                                if (typeof value.createElement === 'function' || typeof value.getElementById === 'function') {
                                    t[prop] = value;
                                    try { globalThis[prop] = value; } catch(e) {}
                                    return true;
                                }
                            } catch(e) {}
                        }
                        if (prop in t) { t[prop] = value; try { globalThis[prop] = value; } catch(e) {} return true; }
                        try {
                            if ((typeof prop === 'string') && prop.length > 2 && prop.indexOf('on') === 0) {
                                try { host.___set_onfunction_property(prop, value); return true; } catch(e) {}
                            }
                            // Sync standard variables with globalThis
                            try { globalThis[prop] = value; } catch(e) {}
                            try { host.put(prop, value); return true; } catch(e) { t[prop] = value; return true; }
                        } catch(e) { t[prop] = value; return true; }
                    },
                    has: function(t, prop) { try { return (prop in t) || !!host.has(prop); } catch(e) { return (prop in t); } },
                    ownKeys: function(t) { try { return Reflect.ownKeys(t); } catch(e) { return Reflect.ownKeys(t); } }
                });

                Object.defineProperty(proxy, '__host__', { value: host });
                globalThis.window = proxy;
                if (typeof self !== 'undefined') self.window = proxy;

                var globals = ['setTimeout', 'setInterval', 'clearTimeout', 'clearInterval', 'requestAnimationFrame', 'cancelAnimationFrame', 'alert', 'confirm', 'prompt', 'open'];
                for (var i = 0; i < globals.length; i++) {
                    try { globalThis[globals[i]] = proxy[globals[i]]; } catch(e) {}
                }
            })();

        ");
                engine.Execute(@"
(function(){
    // グローバル addEventListener と removeEventListener を定義
    // document プロキシの委譲関数を使用
    if (typeof window !== 'undefined' && typeof window.addEventListener === 'function') {
        window.addEventListener_global = window.addEventListener;
        window.removeEventListener_global = window.removeEventListener;
    }
    
    // グローバル addEventListener: document へ委譲（window ではなく document に）
    addEventListener = function(name, handler, options) {
        try {
            if (arguments.length >= 3) {
                if (typeof __doc_addEventListener3 === 'function') {
                    __doc_addEventListener3(name, handler, options);
                    return;
                }
            } else if (arguments.length >= 2) {
                if (typeof __doc_addEventListener === 'function') {
                    __doc_addEventListener(name, handler);
                    return;
                }
            }
            // フォールバック: window.addEventListener へ委譲
            if (window && typeof window.addEventListener === 'function') {
                if (arguments.length >= 3) {
                    window.addEventListener(name, handler, options);
                } else {
                    window.addEventListener(name, handler);
                }
            }
        } catch(e) {
            try { console.error('Global addEventListener error:', e && e.message ? e.message : e); } catch(_) {}
        }
    };
    
    removeEventListener = function(name, handler, options) {
        try {
            if (arguments.length >= 3) {
                if (typeof __doc_removeEventListener3 === 'function') {
                    __doc_removeEventListener3(name, handler, options);
                    return;
                }
            } else if (arguments.length >= 2) {
                if (typeof __doc_removeEventListener === 'function') {
                    __doc_removeEventListener(name, handler);
                    return;
                }
            }
            // フォールバック: window.removeEventListener へ委譲
            if (window && typeof window.removeEventListener === 'function') {
                if (arguments.length >= 3) {
                    window.removeEventListener(name, handler, options);
                } else {
                    window.removeEventListener(name, handler);
                }
            }
        } catch(e) {
            try { console.error('Global removeEventListener error:', e && e.message ? e.message : e); } catch(_) {}
        }
    };
    
    console.log('Global addEventListener and removeEventListener bound successfully');
})();
");

                engine.Execute(@"
(function(){
    if (typeof window !== 'undefined' && typeof window.addEventListener === 'undefined') {
        console.log('Ensuring window.addEventListener exists...');
        if (typeof __host_window !== 'undefined' && typeof __host_window.addEventListener === 'function') {
            window.addEventListener = function() {
                return __host_window.addEventListener.apply(__host_window, arguments);
            };
        }
    }
})();
");

                Debug.WriteLine("setMultiversalWindow: window proxy created.");

                engine.AddHostObject("_windowHost", window);
                //engine.AddHostObject("_host", window); // use __host_window instead

                string bootstrapScript = @"



    // 2. C# の _windowHost にあるメソッドを window に紐付ける (必要に応じて)
    // これにより window.___createObject() が呼べるようになります
    if (typeof _windowHost !== 'undefined') {
        window.___createObject = function(name, args) {
            return _windowHost.___createObject(name, args);
        };
        // 他に window.console などが必要ならここでコピー
        window.console = console;
    }

    // 3. クラス登録関数
        var defineCustomClass = function(className) {
        // window はただの JS オブジェクトになったので、
        // className という名前のプロパティを自由に動的追加できます。
        window[className] = function() {
            var args = Array.prototype.slice.call(arguments);
            return _windowHost.___createObject(className, args);
        };
    }

    // 登録対象
    const classNames = [
        'Image', 'Audio', 'Video', 'Canvas', 'DOMParser', 'XMLHttpRequest',
        'EventSource', 'WebSocket', 'FileReader', 'Blob', 'URL', 'AudioContext'
    ];

    classNames.forEach(defineCustomClass);
";
                // engine.Execute(bootstrapScript);
                string[] classNames = {
    "Image", "Audio", "Video", "Canvas", "DOMParser", "AudioContext",
    "XMLHttpRequest", "EventSource", "WebSocket", "Option", "FileReader",
    "Blob", "File", "MutationObserver", "ImageData", "TextDecoder",
    "TextEncoder", "URL", "FormData", "CustomEvent", "Event",
    "MouseEvent", "KeyboardEvent", "TouchEvent", "MessageEvent",
    "Worker", "SharedWorker", "SpeechSynthesisUtterance", "SpeechRecognition"
};
                engine.AddHostObject("_classNames", classNames);
                // JS 側で plain の window オブジェクトを作る（ホストを変更しない）
                engine.Execute(@"
   (function() {
        var defineCustomClass = function(className) {
            var ctor = function() {
                var args = Array.prototype.slice.call(arguments);
                // 優先: _windowHost、次に _host を試す。どちらも無ければエラーを投げて分かりやすくする。
                if (typeof _windowHost !== 'undefined' && typeof _windowHost.___createObject === 'function') {
                    return _windowHost.___createObject(className, args);
                } else if (typeof _host !== 'undefined' && typeof _host.___createObject === 'function') {
                    return _host.___createObject(className, args);
                }
                throw new Error('createObject host not available: ' + className);
            };
            
            // window[className] に代入することで 'new className()' を可能にする
            window[className] = ctor;
            this[className] = ctor; // グローバルスコープにも一応登録
        }

        // _classNames の長さを安全に取得
        var len = 0;
        try {
            if (_classNames && typeof _classNames.Length === 'number') len = _classNames.Length;
            else if (_classNames && typeof _classNames.length === 'number') len = _classNames.length;
        } catch(e) { len = 0; }

        for (var i = 0; i < len; i++) {
            try { defineCustomClass(_classNames[i]); } catch(e) { /* ログ等必要ならここで扱う */ }
        }
    })();
");
                // エンジン初期化時に実行
                this._v8Engine.Execute(@"
    function ___universalApply(func, args) {
        if (typeof func === 'function') {
            return func.apply(null, args);
        } else if (func && typeof func.Invoke === 'function') {
            // C#側のデリゲートなどが混ざっている場合
            return func.Invoke(args);
        }
        throw new Error('Target is not a function');
    }
");
                /* verify createObject works 
                string strCreateObjectScript = @"
(function() {
    // C#でバインドしたクラス名リスト
    const classNames = [
        ""Image"",
        ""Audio"",
        ""Video"",
        ""Canvas"",
        ""DOMParser"",
        ""AudioContext"",
        ""XMLHttpRequest"",
        ""EventSource"",
        ""WebSocket"",
        ""Option"",
        ""FileReader"",
        ""Blob"",
        ""File"",
        ""MutationObserver"",
        ""ImageData"",
        ""TextDecoder"",
        ""TextEncoder"",
        ""URL"",
        
        ""MessageEvent"",
        ""Worker"",
        ""SharedWorker"",
        ""AudioContext"",
        ""SpeechSynthesisUtterance"",
        ""SpeechRecognition""
    ];

    classNames.forEach(function(className) {
        try {
            // 引数なしでインスタンス化を試みる
            var obj = new (window[className])();
            // インスタンス生成成功
            console.log(""new "" + className + ""() : OK"", obj);
        } catch (e) {
            // 失敗した場合
            console.log(""new "" + className + ""() : NG"", e && e.message ? e.message : e);
        }
    });
})();";
                Debug.WriteLine($"Test Script: {strCreateObjectScript}");
                engine.Execute(strCreateObjectScript);
                */
            }

            catch (Exception ex)
            {
                Debug.WriteLine($"setMultiversalWindow: failed to create window proxy: {ex.GetType().Name} - {ex.Message}");
            }
        }
        public void setMultiversalWindowType(IMultiversalWindowType windowType)
        {
            throw new NotImplementedException();
        }
        public void setDcoument(ICHtmlDocumentInterface document)
        {
            if (_isInitCompleted)
            {
                try
                {
                    _v8Engine.AddHostObject("__host_document", document);
                    _v8Engine.Execute("window.document = __host_document;");
                    _v8Engine.Execute("console.log('Checks setDcoument typeof document :' + typeof document);");
                    _v8Engine.Execute("console.log('setDcoument window.document === __host_document :' + (window.document === __host_document));");
                    _v8Engine.Execute("console.log('setDcoument window.document === document :' + (window.document === document));");
                    _v8Engine.Execute(@"
    Object.defineProperty(window.document, 'title', {
        value: 'Protected',
        writable: false,
        configurable: false
    });
");
                  //  _v8Engine.Execute("document= null;"); // Attempt to overwrite document to test protection
                    _v8Engine.Execute("console.log('Checks setDcoument typeof document :' + typeof document);");
                    _v8Engine.Execute("console.log('Checks setDcoument typeof document.createElement :' + typeof document.createElement);");
                    System.Diagnostics.Debug.WriteLine($"setDocument Success!");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"setDocument Error :{ex.ToString()}");
                }


                if (document is ICHtmlDocumentInterface)
                {
                    this._v8Engine.AddHostObject("location", ((ICHtmlDocumentInterface)document).location);
                }

                // Do not assign functions onto host document to avoid SetMember on host object
                // dynamic dynDoc = document;
                // Avoid dynamic: use reflection-based invoker for host document methods
                object docTarget = document;
                Func<string, object[], object> invokeDocMethod = (name, margs) =>
                {
                    try
                    {
                        var t = docTarget.GetType();
                        object[] callArgs = margs ?? Array.Empty<object>();

                        // Avoid Type.GetMethod(name) as it can throw AmbiguousMatchException when multiple overloads exist.
                        // Instead enumerate candidates and pick best match.
                        var candidates = t.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                                          .Where(m => string.Equals(m.Name, name, StringComparison.Ordinal)).ToArray();

                        // If there's an exact single match, use it.
                        if (candidates.Length == 1)
                        {
                            var single = candidates[0];
                            var ps = single.GetParameters();
                            if (ps.Length == callArgs.Length)
                            {
                                try { return single.Invoke(docTarget, callArgs); } catch { }
                            }
                            if (ps.Length == 1 && (ps[0].ParameterType == typeof(object[]) || ps[0].ParameterType == typeof(System.Array)))
                            {
                                try { return single.Invoke(docTarget, new object[] { callArgs }); } catch { }
                            }
                        }

                        // Prefer candidate with exact parameter count
                        foreach (var cand in candidates)
                        {
                            var ps = cand.GetParameters();
                            if (ps.Length == callArgs.Length)
                            {
                                try { return cand.Invoke(docTarget, callArgs); } catch { }
                            }
                        }

                        // Next prefer single object[] parameter
                        foreach (var cand in candidates)
                        {
                            var ps = cand.GetParameters();
                            if (ps.Length == 1 && (ps[0].ParameterType == typeof(object[]) || ps[0].ParameterType == typeof(System.Array)))
                            {
                                try { return cand.Invoke(docTarget, new object[] { callArgs }); } catch { }
                            }
                        }

                        // Fallback: try any candidate where parameters are assignable from provided args
                        foreach (var cand in candidates)
                        {
                            var ps = cand.GetParameters();
                            if (ps.Length == callArgs.Length)
                            {
                                bool ok = true;
                                for (int i = 0; i < ps.Length; i++)
                                {
                                    if (callArgs[i] != null && !ps[i].ParameterType.IsAssignableFrom(callArgs[i].GetType())) { ok = false; break; }
                                }
                                if (ok)
                                {
                                    try { return cand.Invoke(docTarget, callArgs); } catch { }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"invokeDocMethod error: {ex.Message}");
                    }
                    return null;
                };

                // Assign delegates that wrap ScriptObject handlers to avoid native access violations
                _docAddSoHandler = (eventName, handler) =>
                {
                    try
                    {
                        if (handler is ScriptObject so && _v8Engine != null)
                        {
                            if (!_handlerWrappers.TryGetValue(so, out var existing))
                            {
                                var wrapper = new HandlerWrapper(so, _v8Engine);
                                _handlerWrappers[so] = wrapper;
                                existing = wrapper;
                            }
                            // Pass the wrapper object (has public Invoke) to host via reflection
                            // Call with 2 parameters only (eventName, handler)
                            invokeDocMethod("addEventListener", new object[] { eventName, existing });
                            return;
                        }
                        // invokeDocMethod("addEventListener", new object[] { eventName, handler, null });
                        invokeDocMethod("addEventListener", new object[] { eventName, handler });
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"__doc_addEventListener_so dispatch failed: {ex}");
                    }
                };

                _docAdd3SoHandler = (eventName, handler, options) =>
                {
                    try
                    {
                        if (handler is ScriptObject so && _v8Engine != null)
                        {
                            if (!_handlerWrappers.TryGetValue(so, out var existing))
                            {
                                var wrapper = new HandlerWrapper(so, _v8Engine);
                                _handlerWrappers[so] = wrapper;
                                existing = wrapper;
                            }
                            invokeDocMethod("addEventListener", new object[] { eventName, existing, options });
                            return;
                        }
                        invokeDocMethod("addEventListener", new object[] { eventName, handler, options });
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"__doc_addEventListener3_so dispatch failed: {ex}");
                    }
                };

                // update removeEventListener to use wrapper lookup
                _v8Engine.AddHostObject("__doc_removeEventListener", new Action<string, object>((eventName, handler) =>
                {
                    try
                    {
                        if (handler is ScriptObject so && _handlerWrappers.TryRemove(so, out var wrapper))
                        {
                            invokeDocMethod("removeEventListener", new object[] { eventName, wrapper });
                            return;
                        }
                        // If handler passed is actually a wrapper, remove directly
                        if (handler != null && _handlerWrappers.Values.Contains(handler))
                        {
                            invokeDocMethod("removeEventListener", new object[] { eventName, handler });
                            return;
                        }
                        invokeDocMethod("removeEventListener", new object[] { eventName, handler });
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"__doc_removeEventListener dispatch failed: {ex}");
                    }
                }));

                _v8Engine.AddHostObject("__doc_removeEventListener3", new Action<string, object, object>((eventName, handler, options) =>
                {
                    try
                    {
                        if (handler is ScriptObject so && _handlerWrappers.TryRemove(so, out var wrapper))
                        {
                            invokeDocMethod("removeEventListener", new object[] { eventName, wrapper, options });
                            return;
                        }
                        if (handler != null && _handlerWrappers.Values.Contains(handler))
                        {
                            invokeDocMethod("removeEventListener", new object[] { eventName, handler, options });
                            return;
                        }
                        invokeDocMethod("removeEventListener", new object[] { eventName, handler, options });
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"__doc_removeEventListener3 dispatch failed: {ex}");
                    }
                }));

                _v8Engine.AddHostObject("__doc_createElement", new Func<string, object>((tagName) => invokeDocMethod("createElement", new object[] { tagName })));
                _v8Engine.AddHostObject("__doc_getElementById", new Func<string, object>((id) => invokeDocMethod("getElementById", new object[] { id })));
                _v8Engine.AddHostObject("__doc_getElementsByTagName", new Func<string, object>((tagName) => invokeDocMethod("getElementsByTagName", new object[] { tagName })));
                _v8Engine.AddHostObject("__doc_getElementsByClassName", new Func<string, object>((className) => invokeDocMethod("getElementsByClassName", new object[] { className })));
                _v8Engine.AddHostObject("__doc_querySelector", new Func<string, object>((selector) => invokeDocMethod("querySelector", new object[] { selector })));
                _v8Engine.AddHostObject("__doc_querySelectorAll", new Func<string, object>((selector) => invokeDocMethod("querySelectorAll", new object[] { selector })));
                _v8Engine.AddHostObject("__doc_createEvent", new Func<string, object>((eventType) => invokeDocMethod("createEvent", new object[] { eventType })));
                _v8Engine.AddHostObject("__doc_createTextNode", new Func<object, object>((text) => invokeDocMethod("createTextNode", new object[] { text })));
                _v8Engine.AddHostObject("__doc_createDocumentFragment", new Func<object>(() => invokeDocMethod("createDocumentFragment", Array.Empty<object>())));
                _v8Engine.AddHostObject("__doc_addEventListener", new Action<string, object>((eventName, handler) => invokeDocMethod("addEventListener", new object[] { eventName, handler })));
                _v8Engine.AddHostObject("__doc_addEventListener3", new Action<string, object, object>((eventName, handler, options) => invokeDocMethod("addEventListener", new object[] { eventName, handler, options })));
                // Create a JS proxy object that exposes JS wrappers for methods but forwards property access to __host_document when missing
                _v8Engine.Execute(@"
                    (function(){
                        var host = __host_document;
                        var target = {};
                        target.createElement = function(tagName){ return __doc_createElement(tagName); };
                        target.getElementById = function(id){ return __doc_getElementById(id); };
                        target.getElementsByTagName = function(tag){ return __doc_getElementsByTagName(tag); };
                        target.getElementsByClassName = function(cls){ return __doc_getElementsByClassName(cls); };
                        target.querySelector = function(sel){ return __doc_querySelector(sel); };
                        target.querySelectorAll = function(sel){ return __doc_querySelectorAll(sel); };
                        target.createEvent = function(type){ return __doc_createEvent(type); };
                        target.createTextNode = function(text){ return __doc_createTextNode(text); };
                        target.createDocumentFragment = function(){ return __doc_createDocumentFragment(); };

                        target.addEventListener = function(name, handler, options){
                            try {
                                if (typeof __doc_addEventListener3_so === 'function' && arguments.length >= 3) {
                                    __doc_addEventListener3_so(name, handler, options);
                                    return;
                                }
                                if (typeof __doc_addEventListener_so === 'function' && arguments.length < 3) {
                                    __doc_addEventListener_so(name, handler);
                                    return;
                                }
                                if (arguments.length >= 3) { __doc_addEventListener3(name, handler, options); }
                                else { __doc_addEventListener(name, handler); }
                            } catch(e) {
                                try { console.error('addEventListener dispatch error:', e && e.message ? e.message : e); } catch(_) {}
                            }
                        };

                        target.removeEventListener = function(name, handler, options){
                            try {
                                if (typeof __doc_removeEventListener3 === 'function' && arguments.length >= 3) {
                                    __doc_removeEventListener3(name, handler, options);
                                    return;
                                }
                                if (typeof __doc_removeEventListener === 'function' && arguments.length < 3) {
                                    __doc_removeEventListener(name, handler);
                                    return;
                                }
                            } catch(e) {
                                try { console.error('removeEventListener dispatch error:', e && e.message ? e.message : e); } catch(_) {}
                            }
                        };

                        var docProxy = new Proxy(target, {
                            get: function(t, prop) {
                                // Removed verbose console logging to avoid triggering host property access repeatedly
                                if (prop in t) return t[prop];
                                try {
                                    var v = host[prop];
                                    if (typeof v === 'function') {
                                        return function() { return v.apply(host, arguments); };
                                    }
                                    return v;
                                } catch(e) { return undefined; }
                            },
                            set: function(t, prop, value) {
                                // Removed verbose console logging to avoid triggering host property access repeatedly
                                if (prop in t) { t[prop] = value; return true; }
                                try { host[prop] = value; return true; } catch(e) { t[prop] = value; return true; }
                            },
                            has: function(t, prop) { return (prop in t) || (prop in host); },
                            ownKeys: function(t) { try { return Reflect.ownKeys(t).concat(Reflect.ownKeys(host)); } catch(e) { return Reflect.ownKeys(t); } },
                            getOwnPropertyDescriptor: function(t, prop) {
                                if (prop in t) return Object.getOwnPropertyDescriptor(t, prop);
                                if (prop in host) return Object.getOwnPropertyDescriptor(host, prop);
                                return undefined;
                            }
                        });

                        Object.defineProperty(docProxy, '__host__', { value: host });
                        if (typeof window !== 'undefined') window.document = docProxy;
                        globalThis.document = docProxy;
                    })();
                ");
            }
            /*======================================================================================*/
            /*                         JQuery Bypass Script                                         */
            /*======================================================================================*/
            _v8Engine.Execute(@"
// jQuery互換性のための document スタブ（window.addEventListener の後に安全に定義）
if (typeof document === 'undefined' || document === null) {
    document = {
        createElement: function(tag) {
            return {
                nodeType: 1,
                style: {},
                ownerDocument: document,
                getElementsByTagName: function() { return []; },
                querySelectorAll: function() { return []; }
            };
        },
        documentElement: { style: {}, ownerDocument: document },
        getElementsByTagName: function() { return []; },
        addEventListener: function() {},
        removeEventListener: function() {},
        body: { appendChild: function() {}, style: {} }
    };
}
");


            _v8Engine.Execute("console.log('--- Debug Check ---');");
            _v8Engine.Execute("console.log('window: ' + typeof window);");
            _v8Engine.Execute("console.log('document: ' + typeof document);");
            _v8Engine.Execute("console.log('document.createElement: ' + typeof document.createElement);");
            _v8Engine.Execute("console.log('--- Debug Check End ---');");


            /*======================================================================================*/
            _document = document as ICHtmlDocumentInterface;
        }

        public void setMutilversalWindowType(IMultiversalWindowType windowType)
        {
            throw new NotImplementedException();
        }
        public void AddHostType(string _className, Type targetType)
        {
            _v8Engine.AddHostType(_className, targetType);
        }
        public void AddHostObject(string _className, object obj)
        {
            _v8Engine.AddHostObject(_className, obj);
        }

        private static System.Collections.Generic.SortedList<string, ushort> createWindowFunctionSortedList()
        {
            System.Collections.Generic.SortedList<string, ushort> list = new SortedList<string, ushort>(StringComparer.Ordinal);
            list["ondeviceorientation"] = 0;
            list["ondevicemotion"] = 0;
            list["onunload"] = 0;
            list["onstorage"] = 0;
            list["onpopstate"] = 0;
            list["onhashchange"] = 0;
            list["onpageshow"] = 0;
            list["onpagehide"] = 0;
            list["ononline"] = 0;
            list["onoffline"] = 0;
            list["onmessage"] = 0;
            list["onbeforeunload"] = 0;
            list["onwaiting"] = 0;
            list["onvolumechange"] = 0;
            list["ontimeupdate"] = 0;
            list["onsuspend"] = 0;
            list["onsubmit"] = 0;
            list["onstalled"] = 0;
            list["onshow"] = 0;
            list["onselect"] = 0;
            list["onseeking"] = 0;
            list["onseeked"] = 0;
            list["onscroll"] = 0;
            list["onresize"] = 0;
            list["onreset"] = 0;
            list["onratechange"] = 0;
            list["onprogress"] = 0;
            list["onplaying"] = 0;
            list["onplay"] = 0;
            list["onpause"] = 0;
            list["onmousewheel"] = 0;
            list["onmouseup"] = 0;
            list["onmouseover"] = 0;
            list["onmouseout"] = 0;
            list["onmousemove"] = 0;
            list["onmouseleave"] = 0;
            list["onmouseenter"] = 0;
            list["onmousedown"] = 0;
            list["onloadstart"] = 0;
            list["onloadedmetadata"] = 0;
            list["onloadeddata"] = 0;
            list["  "] = 0;
            list["onkeyup"] = 0;
            list["onkeypress"] = 0;
            list["onkeydown"] = 0;
            list["oninvalid"] = 0;
            list["oninput"] = 0;
            list["onfocus"] = 0;
            list["onfocusin"] = 0;
            list["onfocusout"] = 0;
            list["onerror"] = 0;
            list["onended"] = 0;
            list["onemptied"] = 0;
            list["ondurationchange"] = 0;
            list["ondrop"] = 0;
            list["ondragstart"] = 0;
            list["ondragover"] = 0;
            list["ondragleave"] = 0;
            list["ondragenter"] = 0;
            list["ondragend"] = 0;
            list["ondrag"] = 0;
            list["ondblclick"] = 0;
            list["oncuechange"] = 0;
            list["oncontextmenu"] = 0;
            list["onclose"] = 0;
            list["onclick"] = 0;
            list["onchange"] = 0;
            list["oncanplaythrough"] = 0;
            list["oncanplay"] = 0;
            list["oncancel"] = 0;
            list["onblur"] = 0;
            list["onabort"] = 0;
            list["onwheel"] = 0;
            list["onwebkittransitione"] = 0;
            list["onwebkitanimationstart"] = 0;
            list["onwebkitanimationiteration"] = 0;
            list["onwebkitanimationend"] = 0;
            list["ontransitionend"] = 0;
            list["onsearch"] = 0;
            list["onhelp"] = 0;
            list["onpointercancel"] = 0;
            list["onpointerdown"] = 0;
            list["onpointerenter"] = 0;
            list["onpointerleave"] = 0;
            list["onpointermove"] = 0;
            list["onpointerout"] = 0;
            list["onpointerover"] = 0;
            list["onpointerup"] = 0;
            list["onmsgesturechange"] = 0;
            list["onmsgesturedoubletap"] = 0;
            list["onmsgestureend"] = 0;
            list["onmsgesturehold"] = 0;
            list["onmsgesturestart"] = 0;
            list["onmsgesturetap"] = 0;
            list["onmsinertiastart"] = 0;
            list["onmspointercancel"] = 0;
            list["onmspointerdown"] = 0;
            list["onmspointerenter"] = 0;
            list["onmspointerleave"] = 0;
            list["onmspointermove"] = 0;
            list["onmspointerout"] = 0;
            list["onmspointerover"] = 0;
            list["onmspointerup"] = 0;
            list["ongotpointercapture"] = 0;
            list["onlostpointercapture"] = 0;
            list["onbeforescriptexecute"] = 0;
            list["onafterscriptexecute"] = 0;
            list["onmozfullscreenchange"] = 0;
            list["onmozfullscreenerror"] = 0;
            list["onmozpointerlockchange"] = 0;
            list["onmozpointerlockerror"] = 0;
            list["ondeviceproximity"] = 0;
            list["onuserproximity"] = 0;
            list["ondevicelight"] = 0;
            list["ontouchstart"] = 0;
            list["ontouchend"] = 0;
            list["ontouchmove"] = 0;
            list["ontouchcancel"] = 0;

            return list;
        }
        const string getClassNameString = "object";
        public string getClasName()
        {
            return getClassNameString;

        }
        // fetch実装
        [ScriptMember("fetch")]
        public async Task<object> FetchImpl(object input, object options = null)
        {
#if DEBUG

            Debug.WriteLine($"FetchImpl called with input: {input}, options: {options}");
#endif 
            string url = null;
            string method = "GET";
            IDictionary<string, string> headers = new Dictionary<string, string>();
            object body = null;

            // RequestオブジェクトまたはURL文字列を受け取る
            if (input is string s)
            {
                url = s;
            }
            else if (input != null && input.GetType().GetProperty("Url") != null)
            {
                var urlProp = input.GetType().GetProperty("Url");
                url = urlProp?.GetValue(input)?.ToString();
                var methodProp = input.GetType().GetProperty("Method");
                if (methodProp != null) method = methodProp.GetValue(input)?.ToString() ?? "GET";
                var headersProp = input.GetType().GetProperty("Headers");
                if (headersProp != null)
                {
                    var h = headersProp.GetValue(input) as IDictionary<string, string>;
                    if (h != null) headers = h;
                }
                var bodyProp = input.GetType().GetProperty("Body");
                if (bodyProp != null) body = bodyProp.GetValue(input);
            }
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException("fetch: url is required");
            var handler = new HttpClientHandler
            {
                // 全てを有効にしておくと、サーバーがサポートする最適なものを自動でネゴシエーションします
                AutomaticDecompression = DecompressionMethods.All
            };
            using var client = new HttpClient(handler);
            var req = new HttpRequestMessage(new HttpMethod(method), url);
            foreach (var kv in headers)
                req.Headers.TryAddWithoutValidation(kv.Key, kv.Value);
            if (body != null && method != "GET" && method != "HEAD")
                req.Content = new StringContent(body.ToString());
            var resp = await client.SendAsync(req);
            var content = await resp.Content.ReadAsStringAsync();
            // JSON文字列で返す
            var result = new Dictionary<string, object>
            {
                ["status"] = (int)resp.StatusCode,
                ["ok"] = resp.IsSuccessStatusCode,
                ["text"] = content
            };
            var fetchImplResult = System.Text.Json.JsonSerializer.Serialize(result);
#if DEBUG

            Debug.WriteLine($"FetchImpl returns : {fetchImplResult}");
#endif 
            return fetchImplResult;
        }

        public void createStandardObjects()
        {
            if (_v8Engine == null) return;

            // 最低限の継承対応スタブ（スクリプトが class extends を行う前に注入）
            _v8Engine.Execute(@"
(function(){
    // 最低限の継承対応スタブ
    if (typeof Event === 'undefined') {
        function Event(type, init) { this.type = type || ''; }
        Event.prototype = Object.create(Object.prototype);
        Event.prototype.constructor = Event;
        Object.defineProperty(globalThis, 'Event', { value: Event, writable: false, configurable: false });
    }
    if (typeof CustomEvent === 'undefined') {
        function CustomEvent(type, opts) { Event.call(this, type, opts); this.detail = opts && opts.detail; }
        CustomEvent.prototype = Object.create(Event.prototype);
        CustomEvent.prototype.constructor = CustomEvent;
        Object.defineProperty(globalThis, 'CustomEvent', { value: CustomEvent, writable: false, configurable: false });
    }
    if (typeof Node === 'undefined') {
        function Node() {}
        Node.prototype = Object.create(Object.prototype);
        Node.prototype.constructor = Node;
        Object.defineProperty(globalThis, 'Node', { value: Node, writable: false, configurable: false });
    }
    if (typeof Element === 'undefined') {
        function Element() { Node.call(this); }
        Element.prototype = Object.create(Node.prototype);
        Element.prototype.constructor = Element;
        Object.defineProperty(globalThis, 'Element', { value: Element, writable: false, configurable: false });
    }
    if (typeof HTMLElement === 'undefined') {
        function HTMLElement() { Element.call(this); }
        HTMLElement.prototype = Object.create(Element.prototype);
        HTMLElement.prototype.constructor = HTMLElement;
        Object.defineProperty(globalThis, 'HTMLElement', { value: HTMLElement, writable: false, configurable: false });
    }
    if (typeof DocumentFragment === 'undefined') {
        function DocumentFragment() { Node.call(this); }
        DocumentFragment.prototype = Object.create(Node.prototype);
        DocumentFragment.prototype.constructor = DocumentFragment;
        Object.defineProperty(globalThis, 'DocumentFragment', { value: DocumentFragment, writable: false, configurable: false });
    }
})();
");
            // Strong bootstrap: ensure a functional console exists and lock the binding to prevent overwrite
            _v8Engine.Execute(@"
                (function(){
                    var lockConsole = function(obj){
                        try {
                            Object.defineProperty(globalThis, 'console', { value: obj, writable: false, configurable: false, enumerable: true });
                            if (typeof window !== 'undefined') Object.defineProperty(window, 'console', { value: obj, writable: false, configurable: false, enumerable: true });
                            if (typeof self !== 'undefined') Object.defineProperty(self, 'console', { value: obj, writable: false, configurable: false, enumerable: true });
                        } catch(e) {
                            try { globalThis.console = obj; } catch(_){ }
                            try { if (typeof window !== 'undefined') window.console = obj; } catch(_){ }
                            try { if (typeof self !== 'undefined') self.console = obj; } catch(_){ }
                        }
                    };
                    var ensureConsole = function(){
                        var needSetup = false;
                        try { needSetup = (!console) || (typeof console.log !== 'function'); } catch(e) { needSetup = true; }
                        if (needSetup) {
                            var jsConsole = {
                                log: function(){},
                                warn: function(){},
                                error: function(){},
                                debug: function(){}
                            };
                            Object.defineProperty(jsConsole, '__isJsConsole', { value: true });
                            lockConsole(jsConsole);
                        }
                    };
                    ensureConsole();
                })();
            ");

            // Always register host console bridge so console.log works even when multiversalWindow/console not set yet.
            // Helper: normalize host arg into object[]
            Func<object, object[]> normalizeArgsGlobal = (arg) =>
            {
                if (arg == null) return Array.Empty<object>();
                if (arg is object[] oa) return oa;
                if (arg is ScriptObject so)
                {
                    try
                    {
                        if (so.PropertyNames?.Contains("length") == true)
                        {
                            var lenObj = so.GetProperty("length");
                            int len = 0; try { len = Convert.ToInt32(lenObj); } catch { len = 0; }
                            var list = new List<object>(len);
                            for (int i = 0; i < len; i++) { try { list.Add(so.GetProperty(i.ToString())); } catch { list.Add(null); } }
                            return list.ToArray();
                        }
                        var outList = new List<object>();
                        var props = so.PropertyNames ?? Array.Empty<string>();
                        foreach (var k in props) { if (int.TryParse(k, out _)) { try { outList.Add(so.GetProperty(k)); } catch { outList.Add(null); } } }
                        if (outList.Count > 0) return outList.ToArray();
                        outList.Clear();
                        foreach (var k in props) { try { var v = so.GetProperty(k); if (!(v is Delegate)) outList.Add(v); } catch { } }
                        if (outList.Count > 0) return outList.ToArray();
                    }
                    catch { }
                }
                if (arg is System.Collections.IEnumerable ie && !(arg is string)) { var list = new List<object>(); foreach (var o in ie) list.Add(o); return list.ToArray(); }
                return new object[] { arg };
            };

            Action<string, string> invokeConsoleGlobal = (method, text) =>
            {
                try
                {
                    object ci = null;
                    try { ci = _multiversalWindow?.console; } catch { ci = null; }
                    if (ci != null)
                    {
                        var tci = ci.GetType();

                        // Try to find an appropriate method to invoke. Prefer string, then object, then object[] (params)
                        try
                        {
                            var methods = tci.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                                             .Where(m => string.Equals(m.Name, method, StringComparison.Ordinal))
                                             .ToArray();

                            // 1) exact string parameter
                            var bestMethod = methods.FirstOrDefault(m =>
                            {
                                var ps = m.GetParameters();
                                return ps.Length == 1 && ps[0].ParameterType == typeof(string);
                            });

                            // 2) single object parameter (most common for console implementations)
                            if (bestMethod == null)
                            {
                                bestMethod = methods.FirstOrDefault(m =>
                                {
                                    var ps = m.GetParameters();
                                    return ps.Length == 1 && (ps[0].ParameterType == typeof(object) || ps[0].ParameterType.IsAssignableFrom(typeof(string)));
                                });
                            }

                            // 3) single object[] parameter (params object[])
                            if (bestMethod == null)
                            {
                                bestMethod = methods.FirstOrDefault(m =>
                                {
                                    var ps = m.GetParameters();
                                    return ps.Length == 1 && ps[0].ParameterType.IsArray && ps[0].ParameterType.GetElementType() == typeof(object);
                                });
                            }

                            if (bestMethod != null)
                            {
                                try
                                {
                                    var ps = bestMethod.GetParameters();
                                    if (ps.Length == 1 && ps[0].ParameterType.IsArray && ps[0].ParameterType.GetElementType() == typeof(object))
                                    {
                                        // method expects object[] -> pass as single argument containing the array
                                        bestMethod.Invoke(ci, new object[] { new object[] { text } });
                                        return;
                                    }
                                    else
                                    {
                                        // single value param -> pass string (will be accepted by object param)
                                        bestMethod.Invoke(ci, new object[] { text });
                                        return;
                                    }
                                }
                                catch { /* fall through to property/delegate fallback */ }
                            }
                        }
                        catch { }

                        // Fallback: try property that is a delegate
                        try
                        {
                            var properties = tci.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                                                .Where(p => string.Equals(p.Name, method, StringComparison.Ordinal))
                                                .ToArray();
                            if (properties.Length > 0)
                            {
                                var val = properties[0].GetValue(ci);
                                if (val is Delegate d)
                                {
                                    try { d.DynamicInvoke(new object[] { text }); return; } catch { }
                                }
                            }
                        }
                        catch { }
                    }
                    // Fallback: Debug.WriteLine so we still see console output even when host console not ready
                    Debug.WriteLine(text);
                }
                catch { }
            };

            _v8Engine.AddHostObject("__host_console_log", new Action<object>((arg) =>
            {
                try
                {
                    var args = normalizeArgsGlobal(arg);
                    var sb = new StringBuilder();
                    for (int i = 0; i < args.Length; i++)
                    {
                        try
                        {
                            var str = (_multiversalWindow != null) ? _multiversalWindow.___convertScriptObjectToString(new object[] { args[i] })?.ToString() ?? string.Empty : (args[i]?.ToString() ?? string.Empty);
                            if (i > 0) sb.Append(' ');
                            sb.Append(str);
                        }
                        catch { }
                    }
                    invokeConsoleGlobal("log", sb.ToString());
                }
                catch { }
            }));

            _v8Engine.AddHostObject("__host_console_warn", new Action<object>((arg) =>
            {
                try
                {
                    var args = normalizeArgsGlobal(arg);
                    var sb = new StringBuilder();
                    for (int i = 0; i < args.Length; i++)
                    {
                        try
                        {
                            var str = (_multiversalWindow != null) ? _multiversalWindow.___convertScriptObjectToString(new object[] { args[i] })?.ToString() ?? string.Empty : (args[i]?.ToString() ?? string.Empty);
                            if (i > 0) sb.Append(' ');
                            sb.Append(str);
                        }
                        catch { }
                    }
                    invokeConsoleGlobal("warn", sb.ToString());
                }
                catch { }
            }));

            _v8Engine.AddHostObject("__host_console_error", new Action<object>((arg) =>
            {
                try
                {
                    var args = normalizeArgsGlobal(arg);
                    var sb = new StringBuilder();
                    for (int i = 0; i < args.Length; i++)
                    {
                        try
                        {
                            var str = (_multiversalWindow != null) ? _multiversalWindow.___convertScriptObjectToString(new object[] { args[i] })?.ToString() ?? string.Empty : (args[i]?.ToString() ?? string.Empty);
                            if (i > 0) sb.Append(' ');
                            sb.Append(str);
                        }
                        catch { }
                    }
                    invokeConsoleGlobal("error", sb.ToString());
                }
                catch { }
            }));

            _v8Engine.AddHostObject("__host_console_debug", new Action<object>((arg) =>
            {
                try
                {
                    var args = normalizeArgsGlobal(arg);
                    var sb = new StringBuilder();
                    for (int i = 0; i < args.Length; i++)
                    {
                        try
                        {
                            var str = (_multiversalWindow != null) ? _multiversalWindow.___convertScriptObjectToString(new object[] { args[i] })?.ToString() ?? string.Empty : (args[i]?.ToString() ?? string.Empty);
                            if (i > 0) sb.Append(' ');
                            sb.Append(str);
                        }
                        catch { }
                    }
                    invokeConsoleGlobal("debug", sb.ToString());
                }
                catch { }
            }));

            // JS 側で引数配列を渡すように変更（既存の JS glue をそのまま使う）
            _v8Engine.Execute(@"
                        (function(){
                            var lockConsole = function(obj){
                                try {
                                    Object.defineProperty(globalThis, 'console', { value: obj, writable: false, configurable: false, enumerable: true });
                                    if (typeof window !== 'undefined') Object.defineProperty(window, 'console', { value: obj, writable: false, configurable: false, enumerable: true });
                                    if (typeof self !== 'undefined') Object.defineProperty(self, 'console', { value: obj, writable: false, configurable: false, enumerable: true });
                                } catch(e) {
                                    try { globalThis.console = obj; } catch(_){ }
                                    try { if (typeof window !== 'undefined') window.console = obj; } catch(_){ }
                                    try { if (typeof self !== 'undefined') self.console = obj; } catch(_){ }
                                }
                            };
                            var jsConsole = (typeof console !== 'undefined' && console && console.__isJsConsole) ? console : { };
                            jsConsole.log = function(){ __host_console_log(Array.prototype.slice.call(arguments)); };
                            jsConsole.warn = function(){ __host_console_warn(Array.prototype.slice.call(arguments)); };
                            jsConsole.error = function(){ __host_console_error(Array.prototype.slice.call(arguments)); };
                            jsConsole.debug = function(){ __host_console_debug(Array.prototype.slice.call(arguments)); };
                            Object.defineProperty(jsConsole, '__wired', { value: true });
                            try { Object.freeze(jsConsole); } catch(e){}
                            lockConsole(jsConsole);
                        })();
                    ");




        }

        private bool _enableDebugLog = false;
        [ScriptMember("enableDebugLog")]
        public void EnableDebugLog(bool enable)
        {
            _enableDebugLog = enable;
        }

        // 優先度低めのデバッグ用（通常は無効）
        public void DebugLog(string message)
        {
            if (_enableDebugLog)
            {
                try
                {
                    // スペース圧縮のため、messageに連結する形で複数行ログを出力可能
                    var msg = message.Trim().Replace("\r", "").Replace("\n", " ");
                    // 先頭に[dbg]を付与
                    msg = "[dbg] " + msg;
                    // 実行コンテキストに応じて出力先を変更
                    if (_multiversalWindow != null)
                    {
                        // MultiversalWindowがセットされている場合はそこに出力
#if DEBUG

                        System.Diagnostics.Debug.WriteLine(msg);
#endif
                    }
                    else
                    {
                        // それ以外はとりあえずDebug.WriteLine
                        Debug.WriteLine(msg);
                    }
                }
                catch { /* swallow */ }
            }
        }

        // ScriptMemberとしては無名関数で登録
        [ScriptMember("debugLog")]
        public void DebugLog_Invoke(object arg)
        {
            // 引数は無視して常に true に
            DebugLog("Debugger: " + (arg?.ToString() ?? "null"));
        }

        // 特定のオブジェクトに対するプロキシ用デバッグ
        [ScriptMember("debugDumpProxy")]
        public void DebugDumpProxy(object obj)
        {
            try
            {
                if (obj == null) { DebugLog("debugDumpProxy: obj is null"); return; }
                if (obj is ScriptObject so)
                {
                    DebugLog($"debugDumpProxy: obj is ScriptObject, id={so.GetHashCode()}");

                    // Sample: V8ScriptObject の場合、特に中身を表示
                    if (so.GetType().FullName.Contains("V8ScriptObject"))
                    {
                        DebugLog("debugDumpProxy: obj is V8ScriptObject");
                        try
                        {
                            var keys = so.PropertyNames;
                            DebugLog($"debugDumpProxy: V8ScriptObject keys: {string.Join(", ", keys)}");
                        }
                        catch (Exception ex)
                        {
                            DebugLog($"debugDumpProxy: V8ScriptObject key enum failed: {ex.Message}");
                        }
                    }
                }
                else
                {
                    DebugLog($"debugDumpProxy: obj is {obj.GetType().FullName}, id={obj.GetHashCode()}");
                }
            }
            catch (Exception ex)
            {
                DebugLog($"debugDumpProxy failed: {ex.Message}");
            }
        }
    }
}