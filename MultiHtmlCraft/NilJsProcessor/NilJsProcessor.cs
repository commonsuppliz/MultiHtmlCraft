using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using MultiHtmlCraft.Interfaces;
using NiL.JS.Core;
using NiL.JS.BaseLibrary;
using NiL.JS.Core.Interop;
using NiL.JS.Expressions;
using System.Linq;

namespace NilJsProcessor
{
    public class NilJsProcessor : IMultiversalScriptProcessor
    {
        public NilJsScope scope = null;
        public IMultiversalScriptScope multiversalscope
        {
            get { return scope; }
            set { scope = (NilJsScope)value; }
        }

        public int Timeout { get; set; } = 5000; // Default timeout in milliseconds

        public object callfunction(object functionobject)
        {
            try { 


            if (functionobject is Function)
            {
                return ((Function)functionobject).Call(new Arguments());
            }else if (functionobject is JSValue jsValue && jsValue.Value is Function jsFunc)
            {

                return jsFunc.Call(new Arguments());
            }
            else
            {
                throw new ArgumentException("functionobject is not a NilJs Function");
            }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
#if XXX
        public object callfunction(object functionobject, object scope, object thisObj, object[] args)
        {
                // null または undefined の場合は呼び出し不可能なので、何もしない
            if (functionobject == null || (functionobject is JSValue jsValueCheck && (jsValueCheck.ValueType == JSValueType.Undefined || jsValueCheck.ValueType == JSValueType.Undefined)))
            {
                return null; // または JSValue.undefined を返す
            }

            Function funcToCall = null;

            if (functionobject is Function directFunc)
            {
                funcToCall = directFunc;
            }
            else if (functionobject is JSValue jsValue && jsValue.ValueType == JSValueType.Function)
            {
                funcToCall = jsValue.Value as Function;
            }

            if (funcToCall != null)
            {
                Arguments nlArgs = new Arguments();
                if (args != null)
                {
                    for (int i = 0; i < args.Length; i++)
                    {
                        nlArgs.Add(JSValue.Marshal(args[i]));
                    }
                }
                
                var thisJsValue = thisObj != null ? JSValue.Marshal(thisObj) : JSValue.Undefined;

                return funcToCall.Call(thisJsValue, nlArgs);
            }
            else
            {
                throw new ArgumentException("functionobject is not a NilJs Function. Actual type: " + functionobject?.GetType().FullName);
            }
        }
#endif
        public object callfunction(object functionobject, object scope, object thisObj, object[] args)
        {

            if (functionobject == null) return null;

            // 型チェックの最適化（パターンマッチング使用）
            Function funcToCall = functionobject switch
            {
                Function directFunc => directFunc,
                JSValue { ValueType: JSValueType.Function, Value: Function jsFunc } => jsFunc,
                _ => null
            };

            if (funcToCall == null) return null;

            // 引数が空の場合の最適化
            if (args == null || args.Length == 0)
            {
                var thisJsValue = thisObj != null ? JSValue.Marshal(thisObj) : JSValue.Undefined;
                return funcToCall.Call(thisJsValue, new Arguments());
            }

            // 引数マーシャリングの最適化 - 修正版
            var nlArgs = new Arguments(); // デフォルトコンストラクタを使用
            for (int i = 0; i < args.Length; i++)
            {
                nlArgs.Add(JSValue.Marshal(args[i]));
            }

            var thisValue = thisObj != null ? JSValue.Marshal(thisObj) : JSValue.Undefined;
            try
            {
                if (thisObj != null)
                {
                    return funcToCall.Call(thisValue, nlArgs);
                }
                else
                {
                    return funcToCall.Call(nlArgs);
                }
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        public object callfunction(object functionobject, object[] args)
        {
            // 他のオーバーロードに処理を委譲
            return callfunction(functionobject, null, null, args);
        }

        public object compile(string script)
        {
            int pos = script.IndexOf("function");
            if (pos == -1)
            {
                throw new ArgumentException("script is not a function");
            }
            else
            {
                string funcName = script.Substring(pos + 8, script.IndexOf("(", pos) - pos - 8).Trim();
                scope.context.Eval(script);
                return  scope.context.GetVariable(funcName);

            }
      
        }

        [Hidden]
        public object execute(string script)
        {
            try {
                var win = scope.context.GetVariable("window");
                if(win == null || win.ValueType == JSValueType.Undefined)
                {
                    win = scope.context.GlobalContext.GetVariable("window") ?? scope.context.GlobalContext.GetVariable("globalThis");
                }
                var jsvalue = scope.context.Eval(script, win, false);
                //var jsvalue = scope.context.Eval(script,  false);
                return jsvalue;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException ?? ae;
            }
        }

        private async Task<object> ExecuteWithTimeout(string script, TimeSpan timeout)
        {
            using (var cts = new CancellationTokenSource())
            {
                var task = Task.Run(() => scope.context.Eval(script), cts.Token);

                if (await Task.WhenAny(task, Task.Delay(timeout, cts.Token)) == task)
                {
                    // スクリプトの評価が完了した場合
                    return task.Result;
                }
                else
                {
                    // タイムアウトが発生した場合
                    cts.Cancel();
                    throw new TimeoutException("スクリプトの評価がタイムアウトしました。");
                }
            }
        }

        public object get(string name)
        {
            return scope.context.GetVariable(name);
        }

        public void put(string name, object val)
        {
            scope.context.DefineVariable(name).Assign(JSValue.Marshal(val));
        }

    }
}
