using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using MultiHtmlCraft.Interfaces;

namespace MultiHtmlCraft.Interfaces
{


    public interface IMultiversalWindow
    {
        /// <summary>
        /// Retuns Multiversal Window Level
        /// </summary>
        /// <returns></returns>
        int ___getMultiversalWindowLevel();
        bool has(string ___name);
        bool has(int ___index);
        object get(string ___name);
        object get(int ___index);
        void put(string ___name, Object ___val);
        void put(int ___index, Object ___val);
        object[] getIds();
        void delete(string ___name);
        void delete(int ___index);
        IMultiversalScriptScope getMultiversalScopeByName(string __name);
        IMultiversalScriptScope getMultiversalScopeByScriptType(string ___type);
        /// <summary>
        /// Returns Multiversal Window Level
        /// </summary>
        int MultiverseWindowLevel
        {
            get;
            set;
        }
        IMultiversalWindow MultiversalOwnerWindow
        { 
            get;
        }
        /// <summary>
        /// Some types are script engine specific type( such as org.mozilla.javascript.Constring).
        /// In order to allow multiversal window to handle conversion, pre-register the type using this method
        /// </summary>
        /// <param name="___convertingType">Script Engine Specific Type</param>
        /// <param name="___returnType">Return Type</param>
        /// <param name="___delegate">delegate for conversion function</param>
        void registerTypeConvertDelegate(Type ___convertingType, Type ___returnType, Delegate ___delegate);

        IMultiversalWindow ___getChildMultiversalWindow(int ___index);
        IMultiversalWindow ___getChildMultiversalWindow(string ___name);
        void ___setChildMultiversalWindow(IMultiversalWindow ___childWindow);
        void ___setParentMultiversalWindow(IMultiversalWindow ___childWindow);


        IMultiversalWindow ___getOwnerMultiversalWindow();
        IMultiversalWindow ___getParentMultiversalWindow();

        void initializeMultiversalScopes(bool createStandardObjects);
        void registerPrototypeObject(IPrototypeFunction protofunction);
        /// <summary>
        /// IE and Chrome does not have return value
        /// </summary>
        /// <param name="args"></param>
        void addEventListener(params Object[] args);

        /// <summary>
        /// IE and Chrome does not return value
        /// </summary>
        /// <param name="args"></param>
        void removeEventListener(params Object[] args);

        object setTimeout(params Object[] args);
        object setTimeout(object setTimeoutParam1, object setTimeOutParam2);
        object setTimeout(object setTimeoutParam1, object setTimeOutParam2, object setTimeoutParam3);
        object setInterval(params Object[] args);
        //object setInterval(object setIntervalParam1, object setIntervalParam2, object setIntervalParam3);
        //object setInterval(object setIntervalParam1, object setIntervalParam2);



  
        object clearTimeout(double timerID);
        object clearTimeout(object timerID);


        object clearInterval(double timerID);
        object clearInterval(object timerID);




        object postMessage(params Object[] args);
  

  
        object requestAnimationFrame(params Object[] arg);


        object cancelAnimationFrame(params Object[] args);
        object cancelAnimationFrame(object arg);

        object captureEvents(params Object[] args);

        object releaseEvents(params Object[] args);


        object dispatchEvent(params Object[] args);

        object alert(params Object[] args);
  

        object confirm(params Object[] args);


        object open(params Object[] args);

        object fetch(params Object[] args);


        object owns(string param);
        object owns(object param);

        object navigate(params Object[] args);


        object showModalDialog(params Object[] args);


        object moveBy(params Object[] args);

        object moveTo(params Object[] args);


        object resizeBy(params Object[] args);

        object resizeTo(params Object[] args);

        object scroll(params Object[] args);


        object scrollTo(params Object[] args);

        object scrollBy(params Object[] args);

        object find(params Object[] args);

        object focus(params Object[] args);


        object blur(params Object[] args);
        

        object close(params Object[] args);

        object print(params Object[] args);


        object prompt(params Object[] args);



        object stop(params Object[] args);


        // ------------------------------
        // String Encode / Decode
        // -----------------------------

        object escape(params Object[] args);

        object unescape(params Object[] args);


        object encodeURIComponent(params Object[] args);

        object decodeURIComponent(params Object[] args);

        object decodeURI(params Object[] args);

        object encodeURI(params Object[] args);

        object atob(params Object[] args);
     

        object btoa(params Object[] args);
 

        void ___set_onfunction_property(string ___name, object ___func);
        object ___get_onfunction_property(string ___name);
        object ___createObject(string ___instanceName, params object[] args);

     
        int ___getScriptProcessorCount();
        object getComputedStyle(params Object[] args);

        object matchMedia(params object[] args);


        object requestFileSystem(params object[] args);
        
        
        object getSelection(params object[] args);

   


        object ___convertScriptObjectToString(params object[] args);

        
        IMultiversalScriptScriptEngineType ___multiversalScriptScriptEngine
        {
            get;
            set;
        }
        object console
        {
            get;
        }
        object navigator
        {
            get;
        }
        object location
        {
            get;
        }
        object history
        {
            get;
        }
        object document
        {
            get;
        }



    }
}

