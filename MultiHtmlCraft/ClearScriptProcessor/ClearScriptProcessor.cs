using Microsoft.ClearScript;
using Microsoft.ClearScript.V8;
using MultiHtmlCraft.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;



namespace ClearScriptProcessor
{
    public class ClearScriptProcessor : IMultiversalScriptProcessor, IDisposable
    {
        private IMultiversalScriptScope? _scope = null;
        private V8ScriptEngine? _v8ScriptEngine = null;
        private bool _isDisposed = false;




        public IMultiversalScriptScope multiversalscope
        {
            get
            {
                return _scope;
            }
            set
            {
                _scope = value;
            }
        }
        public V8ScriptEngine clearscriptengine
        {
            get
            {
                return _v8ScriptEngine;

            }
            set
            {
                _v8ScriptEngine = value;
            }
        }

        public IMultiversalWindow Window { get; }
        public ICHtmlDocumentInterface Document { get; set; } = null;



        public object callfunction(object functionobject, object scope, object thisObj, object[] args)
        {
            return CallFunctionInternal(functionobject, args);
        }

        public object callfunction(object functionobject, object[] args)
        {
            return CallFunctionInternal(functionobject, args);
        }

        public object callfunction(object functionobject)
        {
            return CallFunctionInternal(functionobject, null);
        }
        private static bool IsSafeCallableFV8unctionObject(object o)
        {
            if (o == null) return false;
            var t = o.GetType().FullName;

            if (t == null) return false;

            // ClearScript V8 内部実装クラスやプロキシを判定
            if (t.IndexOf("V8Function", StringComparison.OrdinalIgnoreCase) >= 0 ||
                t.IndexOf("V8ScriptFunction", StringComparison.OrdinalIgnoreCase) >= 0 ||
                t.IndexOf("V8ScriptObject", StringComparison.OrdinalIgnoreCase) >= 0 ||
                t.IndexOf("V8ObjectImpl", StringComparison.OrdinalIgnoreCase) >= 0 || // 追加: 内部実装クラス
                t.IndexOf("ScriptFunctionProxy", StringComparison.OrdinalIgnoreCase) >= 0 ||
                t.IndexOf("ClearScriptProcessorScope+HandlerWrapper", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return true;
            }

            // SplitProxy かつ V8ObjectImpl を含む場合は呼び出しを試みる
            if (t.IndexOf("SplitProxy", StringComparison.OrdinalIgnoreCase) >= 0 &&
                t.IndexOf("V8Object", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return true;
            }

            return false;
        }
        private bool IsHandleLike(object o)
        {
            if (o == null) return false;
            var t = o.GetType();
            if (t.FullName != null && (t.FullName.Contains("+Handle") || t.FullName.IndexOf("Handle", StringComparison.OrdinalIgnoreCase) >= 0))
                return true;
            // guts: IntPtr を持つ型もハンドルと見なす
            try
            {
                var f = t.GetField("guts", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                if (f != null && f.FieldType == typeof(IntPtr)) return true;
            }
            catch { }
            return false;
        }

        private void EnsureUniversalApplyFunction(V8ScriptEngine engine)
        {
            // グローバルに ___universalApply がなければ注入する
            try
            {
                bool exists = false;
                try
                {
                    // Evaluate を使って global の存在を確認し、dynamic バインディングを避ける
                    var eval = engine.Evaluate("(typeof ___universalApply !== 'undefined')");
                    if (eval is bool b && b) exists = true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"EnsureUniversalApplyFunction: presence check failed: {ex.GetType().Name} {ex.Message}");
                    exists = false;
                }

                if (!exists)
                {
                    // 修正: if 文の閉じ括弧を追加し、ホストプロキシ経由の呼び出しを強化
                    engine.Execute(@"
                        function ___universalApply(f, args) {
                            if (typeof f === 'function') {
                                return f.apply(null, args || []);
                            } else if (f && typeof f.Invoke === 'function') {
                                return f.Invoke(args);
                            } else if (f && typeof f === 'object') {
                                // ClearScript のプロキシは typeof 'object' になるが呼び出し可能な場合がある
                                try { return f.apply(null, args || []); } catch(e) {}
                            }
                            throw new Error('Target is not a function (type: ' + (typeof f) + ')');
                        }
                    ");
                }
                // 開発中は exists チェックを外すか、関数の型情報を詳細に出力するように上書きします
                engine.Execute(@"
                    (function(g) {
                        g.___universalApply = function(f, args) {
                            if (!f) throw new Error('Target is null or undefined');
                            if (typeof f === 'function') {
                                return f.apply(null, args || []);
                            }
                            // ホストオブジェクトの Invoke メソッド（デリゲート等）
                            if (typeof f.Invoke === 'function') {
                                return f.Invoke(args);
                            }
                            // プロキシオブジェクト等、apply を持っていれば試行
                            if (f.apply && (typeof f.apply === 'function')) {
                                try { return f.apply(null, args || []); } catch(e) {}
                            }
                            throw new Error('Target is not a function. type=' + (typeof f) + ' hasInvoke=' + (!!f.Invoke));
                        };
                    })(globalThis);
                ");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EnsureUniversalApplyFunction Error: {ex.Message}");
                // 失敗しても処理を続ける（フォールバック呼び出しで対応）
            }
        }

        private object CallFunctionInternal(object functionobject, object[] args)
        {
            if (functionobject == null) return null;

            // ClearScript の Undefined を早期に無視する
            if (functionobject is Microsoft.ClearScript.Undefined)
            {
                Debug.WriteLine("CallFunctionInternal: functionobject is ClearScript.Undefined - skipping invocation.");
                return null;
            }

            int ___callfunctionStage = -1;
            try
            {
                Debug.WriteLine($"CallFunctionInternal: functionobject type = {functionobject.GetType().FullName} Thread ID :{System.Threading.Thread.CurrentThread.ManagedThreadId}");

                if (functionobject is Microsoft.ClearScript.ScriptObject scriptObject)
                {
                    ___callfunctionStage = 1;
                    try
                    {
#if DEBUG

                        Debug.WriteLine("CallFunctionInternal: Detected ScriptObject, invoking directly.");
#endif
                        return scriptObject.InvokeAsFunction(args ?? Array.Empty<object>());

                    }
                    catch (Exception ex){
                        Debug.WriteLine(ex.Message);
                    }

                }


                ___callfunctionStage = 2;
                //DumpProxyInfo(functionobject);

                // 2. V8ObjectImpl などの内部オブジェクトの場合
                // Avoid dynamic binder: use reflection-based invocation for fallback
                // var dynFunc = functionobject; // removed dynamic usage

                var engine = this._v8ScriptEngine;

                // --- 追加: まずこのオブジェクトが JS の "function" か判定する ---
                bool isFunction = false;
                try
                {
                    var tcheck = functionobject.GetType();
                    var okProp = tcheck.GetProperty("ObjectKind", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    if (okProp != null)
                    {
                        var okVal = okProp.GetValue(functionobject);
                        if (okVal != null)
                        {
                            if (okVal.ToString().IndexOf("Function", StringComparison.OrdinalIgnoreCase) >= 0)
                                isFunction = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"CallFunctionInternal: ObjectKind check failed: {ex.Message}");
                }

                // --- 重要: 非公開の内部実装を直接リフレクションで呼ぶのは危険なので Public メソッドのみ選ぶ ---
                try
                {
                    var t = functionobject.GetType();
                    // 非公開メソッドも含めて探索していたが、内部ネイティブ呼び出しでアクセス違反が発生するケースがあるため
                    // ここでは明示的に公開メソッド（IsPublic）に限定する。
                    var methods = t.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                    var directInvoke = methods.FirstOrDefault(m =>
                    {
                        var ps = m.GetParameters();
                        // 変更点: m.IsPublic を追加して、ClearScript の内部ネイティブ呼び出しを誤って直接呼ばないようにする
                        return m.Name == "Invoke"
                            && m.IsPublic
                            && ps.Length == 2
                            && ps[0].ParameterType == typeof(bool)
                            && (ps[1].ParameterType == typeof(object[]) || ps[1].ParameterType == typeof(System.Array));
                    });

                    if (directInvoke != null)
                    {
                        try
                        {
                            var invokeArgs = args ?? Array.Empty<object>();
                            // 重要: ClearScript の内部 Invoke(bool asConstructor, object[] args) の第1引数は
                            // コンストラクターとして呼ぶかどうかのフラグです。通常の関数呼び出しなので false   を渡します。
                            var param0 = false;
                            var param1 = invokeArgs.Length == 0 ? null : (object)invokeArgs;
                            return directInvoke.Invoke(functionobject, new object[] { param0, param1 });
                        }
                        catch (TargetInvocationException tie)
                        {
                            Debug.WriteLine($"CallFunctionInternal directInvoke TargetInvocationException: {tie.InnerException?.Message ?? tie.Message}");
                            // fallthrough -> 次の手段へ
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"CallFunctionInternal directInvoke failed: {ex.Message}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"CallFunctionInternal: direct Invoke(bool,object[]) check failed: {ex.Message}");
                }

                // engine.Invoke を使うのは最終手段にする（ネイティブで例外を起こす危険があるため））
                if (engine != null)
                {
                    if (isFunction)
                    {
                        EnsureUniversalApplyFunction(engine);

                        try
                        {
                            // 第二引数に args 配列を渡す（JS 側で配列として受け取る）
                            return engine.Invoke("___universalApply", functionobject, args ?? Array.Empty<object>());
                        }
                        catch (Microsoft.ClearScript.ScriptEngineException sex)
                        {
                            Debug.WriteLine($"CallFunctionInternal ScriptEngineException: {sex.ErrorDetails ?? sex.Message}");
                            // fallthrough -> 下のフォールバックを試す
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"CallFunctionInternal Critical (engine.Invoke): {ex.Message}");
                            // fallthrough -> 下のフォールバックを試す
                        }
                    }
                    else
                    {
                        Debug.WriteLine("CallFunctionInternal: target is not a JS function according to ObjectKind - skip engine.Invoke to avoid ClearScript errors.");
                    }
                }

                // --- 追加の安全対策 ---
                // ClearScript の内部プロキシ型が渡っている可能性がある場合は、リフレクションで非公開メソッドを呼ばないよう
                // public メソッド限定のフォールバック、かつエンジン側の universalApply を先に試す。

                if (engine != null)
                {
                    try
                    {
                        var typeName = functionobject.GetType().FullName ?? string.Empty;
                        if ((typeName.IndexOf("V8", StringComparison.OrdinalIgnoreCase) >= 0 || typeName.IndexOf("SplitProxy", StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            EnsureUniversalApplyFunction(engine);
                            try
                            {
                                return engine.Invoke("___universalApply", functionobject, args ?? Array.Empty<object>());
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine($"CallFunctionInternal engine.Invoke fallback failed: {ex.Message}");
                                // fallthrough -> reflection fallback
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"CallFunctionInternal: engine proxy check failed: {ex.Message}");
                    }
                }

                // ここから従来の reflection / dynamic フォールバック処理
                try
                {
                    var invokeArgs = args ?? Array.Empty<object>();

                    var t = functionobject.GetType();
                    // 変更: public メソッドのみ対象にする（内部ネイティブの非公開 Invoke を呼ばないように）
                    var invokeMethods = t.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                                         .Where(m => string.Equals(m.Name, "Invoke", StringComparison.Ordinal))
                                         .ToArray();

                    foreach (var mi in invokeMethods)
                    {
                        var pars = mi.GetParameters();
                        try
                        {
                            if (pars.Length == 1
                                && (pars[0].ParameterType == typeof(object[]) || pars[0].ParameterType == typeof(System.Array)))
                            {
                                var param0 = invokeArgs.Length == 0 ? null : (object)invokeArgs;
                                return mi.Invoke(functionobject, new object[] { param0 });
                            }

                            if (pars.Length == 0)
                            {
                                return mi.Invoke(functionobject, null);
                            }
                        }
                        catch (TargetParameterCountException)
                        {
                            Debug.WriteLine($"CallFunctionInternal reflection overload parameter mismatch for {mi}.");
                        }
                        catch (TargetInvocationException tie)
                        {
                            Debug.WriteLine($"CallFunctionInternal reflection target invocation exception: {tie.InnerException?.Message ?? tie.Message}");
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"CallFunctionInternal reflection Invoke failed: {ex.Message}");
                        }
                    }

                    // シンプルに公開メソッドを探す
                    var miSimple = GetBestMethod(functionobject.GetType(), "Invoke", BindingFlags.Instance | BindingFlags.Public, -1, false);
                    if (miSimple != null)
                    {
                        try
                        {
                            return miSimple.Invoke(functionobject, invokeArgs.Length == 0 ? null : new object[] { invokeArgs });
                        }
                        catch (TargetParameterCountException)
                        {
                            try
                            {
                                return miSimple.Invoke(functionobject, invokeArgs);
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine($"CallFunctionInternal reflection Invoke failed: {ex.Message}");
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"CallFunctionInternal reflection Invoke failed: {ex.Message}");
                        }
                    }

                    // Reflection-based fallback: try 'apply' or 'call' methods if available
                    try
                    {
                        var tFallback = functionobject.GetType();
                        // try apply(thisArg, args)
                        var miApply = GetBestMethod(tFallback, "apply", BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase, -1, true);
                        if (miApply != null)
                        {
                            try
                            {
                                return miApply.Invoke(functionobject, new object[] { null, invokeArgs });
                            }
                            catch (TargetInvocationException tie)
                            {
                                Debug.WriteLine($"CallFunctionInternal apply TargetInvocationException: {tie.InnerException?.Message ?? tie.Message}");
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine($"CallFunctionInternal apply invoke failed: {ex.Message}");
                            }
                        }

                        // try call(thisArg, ...args) - need to expand args into parameter list
                        var miCall = GetBestMethod(tFallback, "call", BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase, -1, true);
                        if (miCall != null)
                        {
                            try
                            {
                                // build parameters: first is thisArg (null), then each arg
                                var callParams = new object[(invokeArgs?.Length ?? 0) + 1];
                                callParams[0] = null;
                                if (invokeArgs != null && invokeArgs.Length > 0) Array.Copy(invokeArgs, 0, callParams, 1, invokeArgs.Length);
                                return miCall.Invoke(functionobject, callParams);
                            }
                            catch (TargetInvocationException tie)
                            {
                                Debug.WriteLine($"CallFunctionInternal call TargetInvocationException: {tie.InnerException?.Message ?? tie.Message}");
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine($"CallFunctionInternal call invoke failed: {ex.Message}");
                            }
                        }

                        // As last resort, if no apply/call, and no args, try parameterless Invoke method already handled above; nothing more to try.
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"CallFunctionInternal reflection fallback failed: {ex.Message}");
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"CallFunctionInternal fallback failed: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"CallFunctionInternal Critical: {ex.Message}");
            }
            return null;
        }

        // プロキシを再帰的にアンラップして実体を返す。深さ制限あり。


        // デバッグ用：プロキシの型、メソッド、フィールド、プロパティを出力する
        private void DumpProxyInfo(object obj)
        {
            // Guard null
            if (obj is null) return;
            try
            {
                Type t = obj.GetType();
                Debug.WriteLine($"DumpProxyInfo: Type = {t.FullName}");

                var methods = t.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                Debug.WriteLine($"DumpProxyInfo: Methods ({methods.Length})");
                foreach (var m in methods)
                {
                    Debug.WriteLine($"  M: {m.Name} ({string.Join(", ", m.GetParameters().Select(p => p.ParameterType.Name))})");
                }

                var fields = t.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                Debug.WriteLine($"DumpProxyInfo: Fields ({fields.Length})");
                foreach (var f in fields)
                {
                    Debug.WriteLine($"  F: {f.Name} : {f.FieldType.FullName}");
                }

                var props = t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                Debug.WriteLine($"DumpProxyInfo: Properties ({props.Length})");
                foreach (var p in props)
                {
                    Debug.WriteLine($"  P: {p.Name} : {p.PropertyType.FullName}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DumpProxyInfo Error: {ex.Message}");
            }
        }

        public object compile(string script)
        {
            throw new NotImplementedException();
        }

        public object execute(string script)
        {
            if (_v8ScriptEngine == null)
            {
                throw new InvalidOperationException("Script engine is not initialized.");
            }

            var scriptToExecute = WrapIfCommonJs(script, "");
            if (_scope != null && _scope.EnableScriptLogging)
            {
                Debug.WriteLine("Executing Javascript script:");
                Debug.WriteLine("========================= Start Script ===================================");
                Debug.WriteLine(scriptToExecute);
                Debug.WriteLine("========================= End Script   ===================================");
            }

            // Detect if this is likely a jQuery/library script
            bool isCommonJsScript = script.Contains("module.exports") || script.Contains("exports.");
            bool isJQueryScript = script.Contains("jQuery") && (script.Contains("factory") || script.Contains("noConflict"));

            _v8ScriptEngine.Execute(scriptToExecute);

            // After executing potential library scripts, check and fix $ callable nature
            if (isCommonJsScript || isJQueryScript)
            {
                try
                {
                    // Use console.log for visible output since Debug.WriteLine may not show
                    _v8ScriptEngine.Execute("console.log('[ClearScript] Checking jQuery callable status...');");

                    // Check if $ exists but is not callable
                    var dollarType = _v8ScriptEngine.Evaluate("typeof $");
                    _v8ScriptEngine.Execute($"console.log('[ClearScript] typeof $ = ' + (typeof $));");

                    if (dollarType?.ToString() != "function")
                    {
                        _v8ScriptEngine.Execute("console.log('[ClearScript] $ is not a function, attempting wrapper creation...');");

                        // Get the $ object from global scope
                        var dollarObj = _v8ScriptEngine.Global["$"];

                        if (dollarObj == null)
                        {
                            _v8ScriptEngine.Execute("console.log('[ClearScript] $ is null in engine.Global');");
                        }
                        else
                        {
                            var dollarObjType = dollarObj.GetType().FullName;
                            _v8ScriptEngine.Execute($"console.log('[ClearScript] $ CLR type = {dollarObjType}');");

                            // Check if it's a ScriptObject (V8 function wrapper)
                            if (dollarObj is Microsoft.ClearScript.ScriptObject so)
                            {
                                _v8ScriptEngine.Execute("console.log('[ClearScript] $ is ScriptObject, creating host invoker...');");

                                // Create a host delegate that can invoke the ScriptObject
                                Func<object[], object> jqueryInvoker = (args) =>
                                {
                                    try
                                    {
                                        return so.InvokeAsFunction(args ?? Array.Empty<object>());
                                    }
                                    catch (Exception ex)
                                    {
                                        Debug.WriteLine($"jqueryInvoker error: {ex.Message}");
                                        return null;
                                    }
                                };

                                // Expose the invoker to JavaScript
                                _v8ScriptEngine.AddHostObject("___jqueryHostInvoker", jqueryInvoker);
                                _v8ScriptEngine.AddHostObject("___jqueryScriptObject", so);

                                // Create a JavaScript wrapper function
                                _v8ScriptEngine.Execute(@"
                                    (function() {
                                        console.log('[ClearScript] Creating jQuery wrapper function...');
                                        var origJQ = ___jqueryScriptObject;
                                        var invoker = ___jqueryHostInvoker;

                                        // Create the wrapper function
                                        var wrapper = function() {
                                            var args = Array.prototype.slice.call(arguments);
                                            return invoker(args);
                                        };

                                        // Copy all properties from original jQuery
                                        if (origJQ) {
                                            for (var key in origJQ) {
                                                try { wrapper[key] = origJQ[key]; } catch(e) {}
                                            }
                                            try { wrapper.prototype = origJQ.prototype; } catch(e) {}
                                            try { wrapper.fn = origJQ.fn; } catch(e) {}
                                        }

                                        // Assign to global scope using bare identifier
                                        $ = wrapper;
                                        jQuery = wrapper;

                                        // Also update window
                                        if (typeof window !== 'undefined') {
                                            window.$ = wrapper;
                                            window.jQuery = wrapper;
                                        }

                                        console.log('[ClearScript] jQuery wrapper created, typeof $ = ' + typeof $);
                                    })();
                                ");
                            }
                            else
                            {
                                // Not a ScriptObject - try to create wrapper using engine.Invoke
                                _v8ScriptEngine.Execute("console.log('[ClearScript] $ is not ScriptObject, trying alternative approach...');");

                                // Store the object and create an invoker that uses engine.Script
                                _v8ScriptEngine.AddHostObject("___jqueryRawObject", dollarObj);

                                _v8ScriptEngine.Execute(@"
                                    (function() {
                                        console.log('[ClearScript] Creating alternative wrapper...');
                                        var origJQ = ___jqueryRawObject;

                                        // Try to invoke via .apply if available
                                        var wrapper = function() {
                                            var args = Array.prototype.slice.call(arguments);
                                            if (origJQ && typeof origJQ.apply === 'function') {
                                                return origJQ.apply(this, args);
                                            }
                                            if (origJQ && typeof origJQ.Invoke === 'function') {
                                                return origJQ.Invoke(args);
                                            }
                                            throw new Error('Cannot invoke jQuery: no callable method found');
                                        };

                                        // Copy properties
                                        if (origJQ) {
                                            for (var key in origJQ) {
                                                try { wrapper[key] = origJQ[key]; } catch(e) {}
                                            }
                                        }

                                        $ = wrapper;
                                        jQuery = wrapper;
                                        if (typeof window !== 'undefined') {
                                            window.$ = wrapper;
                                            window.jQuery = wrapper;
                                        }

                                        console.log('[ClearScript] Alternative wrapper created, typeof $ = ' + typeof $);
                                    })();
                                ");
                            }
                        }
                    }
                    else
                    {
                        _v8ScriptEngine.Execute("console.log('[ClearScript] $ is already a function, no wrapper needed');");
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"execute: jQuery wrapper creation failed: {ex.Message}");
                    try { _v8ScriptEngine.Execute($"console.log('[ClearScript] Wrapper creation error: {ex.Message.Replace("'", "\\'")}');"); } catch { }
                }
            }

            return null;
        }

        public object get(string name)
        {
            if (_v8ScriptEngine == null)
                throw new InvalidOperationException("Script engine is not initialized.");
            return _v8ScriptEngine.Global[name];
        }

        public void put(string name, object val)
        {
            if (_v8ScriptEngine == null)
                throw new InvalidOperationException("Script engine is not initialized.");

            try
            {
                if (val == null)
                {
                    _v8ScriptEngine.Global[name] = null;
                    return;
                }

                // If the value is a host DOM object (from MultiHtmlCraft.Core), expose it as a host object
                // so ClearScript presents it as a CLR-backed host object rather than a V8 proxy.
                var t = val.GetType();
                var assemblyName = t.Assembly?.GetName()?.Name ?? string.Empty;

                if (assemblyName.IndexOf("MultiHtmlCraft", StringComparison.OrdinalIgnoreCase) >= 0 ||
                    assemblyName.IndexOf("MultiHtmlCraft.Core", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    // Use AddHostObject to ensure the CLR members (and our DynamicMetaObject) are visible to scripts
                    try
                    {
                        _v8ScriptEngine.AddHostObject(name, val);
                        return;
                    }
                    catch
                    {
                        // fall back to global assignment if AddHostObject fails for some reason
                    }
                }

                // Default: plain assignment
                _v8ScriptEngine.Global[name] = val;
            }
            catch
            {
                // swallow to avoid throwing into host; attempt simple assignment
                try { _v8ScriptEngine.Global[name] = val; } catch { }
            }
        }

        void IDisposable.Dispose()
        {
            if (_isDisposed)
                return;
            _isDisposed = true;
            try
            {
                _v8ScriptEngine?.Dispose();
            }
            catch { }
            _v8ScriptEngine = null;
            _scope = null;
        }
        private string WrapIfCommonJs(string script, string scriptUrl)
        {
            // We should only wrap if this is a jQuery script.
            // Wrapping other UMD scripts creates isolated scopes, breaking their global variable declarations.
            bool isJQueryScript = script.Contains("jQuery") && (script.Contains("factory") || script.Contains("noConflict"));

            if (isJQueryScript && (script.Contains("module.exports") || script.Contains("exports.")))
            {
                // Strategy: The issue is that globalThis in ClearScript is a CLR-backed object.
                // Any assignment to globalThis.$ goes through CLR interop which can corrupt V8 functions.
                //
                // Solution: First, declare top-level var $ and jQuery (outside IIFE) so they exist
                // in V8's true global scope. Then, inside the IIFE finally block, assign module.exports
                // to these pre-declared variables using bare identifier assignment.
                //
                // The key insight: `var $;` at top level creates a V8 global variable.
                // Then `$ = someFunction;` (bare identifier) assigns to this V8 variable,
                // NOT to globalThis.$ which would go through CLR.

                // Pre-declare $ and jQuery at top level (outside IIFE)
                var preDeclaration = "var $, jQuery; ";

                var wrapperStart = "(function(){var module = { exports: {} }; var exports = module.exports; try {";

                // In finally block, assign module.exports to the pre-declared $ and jQuery
                // Using bare identifier assignment, NOT globalThis.$ which corrupts V8 functions
                var wrapperEnd = @"} finally { 
try { 
    var ___me = module.exports;
    if (___me && typeof ___me === 'function') {
        // Assign to the pre-declared $ and jQuery variables
        // These are V8 global scope variables, not CLR proxy properties
        $ = ___me;
        jQuery = ___me;
    } else if (___me && typeof ___me === 'object' && ___me !== null) {
        $ = ___me;
        jQuery = ___me;
    }
} catch(e) { /* swallow */ } 
}})();";
                return preDeclaration + wrapperStart + script + wrapperEnd;
            }
            return script;
        }

        // Safe method resolver to avoid AmbiguousMatchException from Type.GetMethod when multiple overloads exist
        private System.Reflection.MethodInfo GetBestMethod(Type t, string name, System.Reflection.BindingFlags flags, int preferParamCount = -1, bool ignoreCase = false)
        {
            try
            {
                var comparison = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
                var candidates = t.GetMethods(flags)
                                  .Where(m => string.Equals(m.Name, name, comparison))
                                  .ToArray();
                if (candidates.Length == 0) return null;
                if (candidates.Length == 1) return candidates[0];

                if (preferParamCount >= 0)
                {
                    var exact = candidates.FirstOrDefault(m => m.GetParameters().Length == preferParamCount);
                    if (exact != null) return exact;
                }

                // prefer methods that take (object[]) or array-like single parameter
                var arrParam = candidates.FirstOrDefault(m =>
                {
                    var ps = m.GetParameters();
                    return ps.Length == 1 && (ps[0].ParameterType == typeof(object[]) || ps[0].ParameterType.IsArray);
                });
                if (arrParam != null) return arrParam;

                // prefer exact parameter count 0
                var zeroParam = candidates.FirstOrDefault(m => m.GetParameters().Length == 0);
                if (zeroParam != null) return zeroParam;

                // fallback: pick first candidate
                return candidates[0];
            }
            catch
            {
                return null;
            }
        }

        public object __host_window_invoke(object prop, object[] args)
        {
            try
            {
                if (prop == null) return null;
                string name = prop as string ?? prop.ToString();
                var member = this.get(name);
                if (member is Microsoft.ClearScript.ScriptObject so)
                {
                    try { return so.InvokeAsFunction(args ?? Array.Empty<object>()); } catch { }
                }
                // CLR delegate / wrapper - try reflection Invoke
                try
                {
                    var mi = member?.GetType().GetMethod("Invoke", BindingFlags.Instance | BindingFlags.Public);
                    if (mi != null)
                    {
                        // prefer array arg
                        return mi.Invoke(member, new object[] { args ?? Array.Empty<object>() });
                    }
                }
                catch { }
            }
            catch { }
            return null;
        }
    }
}