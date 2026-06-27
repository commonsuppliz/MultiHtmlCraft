using System;
using System.Collections.Generic;
using Python.Runtime;
using MultiHtmlCraft.Interfaces;
using System.Threading.Tasks;
using System.Security.AccessControl;
public class PythonProcessorScope : IAsyncDisposable, IMultiversalScriptScope, IDisposable
{
    private bool _disposed = false;
    private bool _initCompleted = false;
    private Py.GILState? _scope = null;
    private bool _isDefaultProcessor = false;
    private bool _EnableDebug = false;
    private bool _EnableScriptLogging = false;

    public bool IsDisposed
    {
        get
        {
            return _disposed;
        }
    }
    public bool IsInitCompleted
    {
        get
        {
            return _initCompleted;
        }
    }
    public bool IsDefaultProcessor
    {
        get
        {
            return _isDefaultProcessor;
        }
        set
        {
            _isDefaultProcessor = value;
        }
    }
    public bool EnableDebug
        {
        get
        {
            return _EnableDebug;
        }
        set
        {
            _EnableDebug = value;
        }
    }

    public PythonProcessorScope() { }

    public ValueTask DisposeAsync()
    {
        PythonEngine.Shutdown();
        _scope?.Dispose();
        _disposed = true;
        return new ValueTask(Task.CompletedTask);
    }

    public void disposeScriptEngine()
    {
        PythonEngine.Shutdown();
        _scope.Dispose();
        _disposed = true;
        
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
    public bool EnableDebugLog
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

    public string getMultivasalScopeName()
    {
        throw new NotImplementedException();
    }
    private static List<string> _invokeScriptNames = new List<string>{ "text/python", "text/py" };
    public string[] getMultiversalInvokeScriptNames()
    {
        return _invokeScriptNames.ToArray();
    }

    public IMultiversalScriptProcessor getMultiversalScriptProcessor()
    {
        PythonProcessor.PythonProcessor _new = new PythonProcessor.PythonProcessor();
        _new.multiversalscope = this;
        return _new;

    }

    public IMultiversalWindow getMultiversalWindow()
    {
        throw new NotImplementedException();
    }

    public IMultiversalWindowType getMutilversalWindowType()
    {
        throw new NotImplementedException();
    }

    public void initScriptEngine()
    {
        PythonEngine.Initialize();
        _initCompleted = true;
         _scope = Py.GIL();
 
    }

    public bool isDefaultMultiversalProcessor()
    {
        throw new NotImplementedException();
    }

    public bool isInitCompleted()
    {
        throw new NotImplementedException();
    }

    public void relaseMultiversal()
    {
        throw new NotImplementedException();
    }

    public void setMultiversalWindow(IMultiversalWindow window)
    {
        throw new NotImplementedException();
    }

    public void setMutilversalWindowType(IMultiversalWindowType windowType)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        PythonEngine.Shutdown();
        _scope.Dispose();
        _disposed = true;
        
    }
    private int _timeout = 0;

    public void setTimeout(int timeout)
    {
       _timeout = timeout;
    }
}
