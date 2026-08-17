using System;
using System.Collections.Generic;

using System.Text;

namespace MultiHtmlCraft.Interfaces
{

    public interface IMultiversalScriptScope
    {
        enum IMultiversalScriptScopeState
        {
            Uninitialized = 0,
            Initializing = 1,
            Initialized = 2,
            Disposing = 3,
            Disposed = 4,
        }
        enum IMultiversalScriptScopeInitResult
        {
            Success = 0,
            Timeout = 1,
            Failed = 2,
        }
        enum IMultiversalScriptScopeDisposeResult
        {
            Success = 0,
            Timeout = 1,
            Failed = 2,
        }
         
        enum IMultiversalScriptScopeCallFunctionResult
        {
            Success = 0,
            Timeout = 1,
            Failed = 2,
        }
        [Flags]
        enum IMultiversalScriptEngineType
        {
            Undefined = 0,
            NilJs = 1,
            ClearScriptV8 = 2,
            Jint = 4,
            RhinoNet = 8, 
            Python = 16,
        }
        bool EnableDebug { get; set; }
        bool EnableScriptLogging { get; set; }
        //IMultiversalScriptScope constructorMultiversalScope(IMultiversalWindow multi);
        void relaseMultiversal();
        string getMultivasalScopeName();
        void initScriptEngine();
        bool isInitCompleted();
        void disposeScriptEngine();
        string[] getMultiversalInvokeScriptNames();
        bool isDefaultMultiversalProcessor();
        IMultiversalScriptProcessor getMultiversalScriptProcessor();
        IMultiversalWindow getMultiversalWindow();
        void setMutilversalWindowType(IMultiversalWindowType windowType);
        IMultiversalWindowType getMutilversalWindowType();
        void setMultiversalWindow(IMultiversalWindow window);

        void setTimeout(int timeout);

        bool ScopeHas(string name);
        object ScopeGet(string name);
    }
}
