using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Python.Runtime;
using MultiHtmlCraft.Interfaces;
namespace PythonProcessor
{

    internal class PythonProcessor : IAsyncDisposable, IMultiversalScriptProcessor
    {
        public PythonProcessor() { }
        private PythonProcessorScope _scope;

        public IMultiversalScriptScope multiversalscope
        {
            get { return _scope; }
            set { _scope = (PythonProcessorScope)value; }
        }

        public object callfunction(object functionobject)
        {
            throw new NotImplementedException();
        }

        public object callfunction(object functionobject, object scope, object thisObj, object[] args)
        {
            throw new NotImplementedException();
        }
        public object callfunction(object functionobject,  object[] args)
        {
            throw new NotImplementedException();
        }

        public object compile(string script)
        {
            throw new NotImplementedException();
        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }

        public object execute(string script)
        {
            throw new NotImplementedException();
        }

        public object get(string name)
        {
            throw new NotImplementedException();
        }

        public void put(string name, object val)
        {
            throw new NotImplementedException();
        }
    }
}
