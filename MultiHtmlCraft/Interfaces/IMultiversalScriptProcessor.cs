using System;
using System.Collections.Generic;
using System.Text;

namespace MultiHtmlCraft.Interfaces
{
    public interface IMultiversalScriptProcessor
    {
        object execute(string script);
        object compile(string script);
        object callfunction(Object functionobject);
        object callfunction(Object functionobject, Object scope, Object thisObj, Object[] args);
        object callfunction(Object functionobject,  Object[] args);
        object get(string name);
        void put(string name, Object val);

        
        IMultiversalScriptScope multiversalscope { get; set; }
    }

    /// <summary>
    /// Some Types are script-engine specifc types. To convert to .net types use these delegates and pre-register delegates on script processor.
    /// </summary>
    public static class IMultiversalScriptProcessorDelegates
    {
        public delegate double doubleConverter(object ___val);
        public delegate string stringConverter(object ___val);
        public delegate DateTime datetimeConverter(object ___val);
        public delegate bool  booleanConverter(object ___val);
        public delegate object undefinedTypeConverter(object ___val);
        public delegate object nullTypeConverter(object ___val);
        public delegate object[] arrayConverter(object ___val);
  
    }
}
