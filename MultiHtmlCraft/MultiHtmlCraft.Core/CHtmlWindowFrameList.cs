using System;
using System.Collections.Generic;
using System.Text;


namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// window.frames List
    /// </summary>
    public sealed class CHtmlWindowFrameList 
    {
        private System.Collections.Generic.SortedList<string, System.WeakReference> ____windowFrameInternalList = null;
        private int ___frameCount = 0;
        public CHtmlWindowFrameList()
        {
            this.____windowFrameInternalList = new SortedList<string, WeakReference>(StringComparer.OrdinalIgnoreCase);
        }
        internal void ___addCHtmlElement(CHtmlElement ___elem)
        {
            System.WeakReference ___elementReference = new WeakReference(___elem, false);
            bool ___IsBeenAddedToList = false;
            if (string.IsNullOrEmpty(___elem.___idLowSimple) == false)
            {
                this.____windowFrameInternalList[___elem.___idLowSimple] = ___elementReference;
                ___IsBeenAddedToList = true;
            }
            if (string.IsNullOrEmpty(___elem.___name) == false)
            {
                this.____windowFrameInternalList[___elem.___name] = ___elementReference;
                ___IsBeenAddedToList = true;
               
            }
            if (___IsBeenAddedToList == false)
            {
                this.____windowFrameInternalList["frame__dummy_" + ___elem.GetHashCode().ToString()] = ___elementReference;
                ___IsBeenAddedToList = true;
            }
            if (___IsBeenAddedToList == true)
            {
                ___frameCount++;
            }
        }
        public int length
        {
            get
            {
                return this.___frameCount;
            }
        }
        public int jsGet_length()
        {
            return this.___frameCount;
        }
        #region interfaces
        public void delete(int i)
        {
        }
        public void delete(string str)
        {
        }
        public object get(int i, object  s)
        {
            object ___returnObject = null;
            if (i >= 0 && i < this.___frameCount)
            {
                System.WeakReference ___elemRef = null;
                try
                {
                    ___elemRef = this.____windowFrameInternalList.Values[i];
                    if (___elemRef != null)
                    {
                         ___returnObject  =  this.___ConvertWeakReferenceToWindow(___elemRef);
                    }
                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled)
                    {
                       commonLog.LogEntry("WindowFrame Error", ex);
                    }

                }
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("window.frame(int {0}) will returns {1}", i, ___returnObject);
            }
            return ___returnObject;
        }
        public object get(string str, object  s)
        {
            object ___returnObject = null;
            System.WeakReference ___elemRef = null;
            this.____windowFrameInternalList.TryGetValue(str, out ___elemRef);
            if (___elemRef != null)
            {
                ___returnObject =  this.___ConvertWeakReferenceToWindow(___elemRef);
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("window.frame(string {0}) will returns {1}",str, ___returnObject);
            }
            return ___returnObject;
        }
        public string getClassName()
        {
            return "Frames";
        }
        internal void ___CleanUp()
        {
            if (this.____windowFrameInternalList != null)
            {
                this.____windowFrameInternalList.Clear();
                this.____windowFrameInternalList = null;
            }
            this.___frameCount = 0;
        }
        private object ___ConvertWeakReferenceToWindow(System.WeakReference ___elemRef)
        {
            CHtmlElement ___elem = null;
            ___elem = ___elemRef.Target as CHtmlElement;
            if (___elem != null)
            {

            }

            return null;
        }

   


        public object[] getIds()
        {
            return null;
        }

        public bool has(int i, object  s)
        {
            if (i >= 0 && i < this.___frameCount)
            {
                return true;
            }
            return false;
        }
        public bool has(string str, object s)
        {
            return this.____windowFrameInternalList.ContainsKey(str);
        }
        public bool hasInstance(object  s)
        {
            return false;
        }
        public void put(int i, object  s, object obj)
        {
        }
        public void put(string str, object  s, object obj)
        {
        }
        public void setParentScope(object s)
        {
        }
        public void setPrototype(object  s)
        { }

        #endregion


    }
}
