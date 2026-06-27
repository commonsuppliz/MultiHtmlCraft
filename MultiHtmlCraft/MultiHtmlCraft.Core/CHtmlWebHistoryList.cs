using System;
using System.Collections.Generic;
using System.Text;
using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// Note: This class was used to be IProperyBox.However,
    /// We found some script(ex. history.js) use this class using defineSetter intensively.
    /// In order to work around this class is ScriptableObjet.
    /// 
    /// </summary>
    public class CHtmlHistoryList 
    {
        internal bool ___IsPrototype = false;
        internal bool ___DisableMCSInfoAdd = false;
        internal int  ___OwnerWindowLevel = -1;
        internal static string[] ___HistoryObjectFunctionPropertiesNames = new string[] { "replaceState", "pushState", "go", "back", "forward"};
        public delegate void WebHistoryHandler(object sender, CHtmlWebHistory _hist);
        internal event WebHistoryHandler ___WebHistoryBackward;
        internal event WebHistoryHandler ___WebHistoryForeward;
        internal event WebHistoryHandler ___WebHistoryGo;
        private System.Collections.ArrayList ___arHistoryList = new System.Collections.ArrayList();
        internal System.WeakReference ___ownerRendererWeakReference = null;
        public int CurrentHistoryIndex = -1;
        internal int  ___addWebHistory(CHtmlWebHistory ___hist)
        {
            return 0;
        }

        public object jsGet_state()
        {
            return null; 
        }
        public void jsSet_state(object ___value)
        {
            return;
        }

        public void replaceState(object __State, object ___TitleObject, object ___UrlObject)
        {
            string ___Title = commonHTML.GetStringValue(___TitleObject);
            string ___Url = commonHTML.GetStringValue(___UrlObject);
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO: replaceState({0}, {1} , {2})", __State, ___Title, ___Url);
            }
            CHtmlWebHistory foundHistory = null;// TODO;
            if (foundHistory != null)
            {
                foundHistory.Title = ___Title;
                foundHistory.State = __State;
            }
        }

        public void pushState(object __State, object ___TitleObject, object ___UrlObject)
        {
            string ___Title = commonHTML.GetStringValue(___TitleObject);
            string ___Url = commonHTML.GetStringValue(___UrlObject);
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("pushState({0}, {1} , {2})", __State, ___Title, ___Url);
            }
            CHtmlWebHistory newHistory = new CHtmlWebHistory();
            if (string.IsNullOrEmpty(___Url) == false)
            {
                newHistory.Url = string.Copy(___Url);
            }
            if (string.IsNullOrEmpty(___Title) == false)
            {
                newHistory.Title = string.Copy(___Title);
            }
            newHistory.State = __State;
            this.___addWebHistory(newHistory);
        }

        internal object ___GetByIndex(int i)
        {
            return null;
        }

        public void back()
        {
            if (this.___WebHistoryBackward != null)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                   commonLog.LogEntry("TODO : {0}.backward() called", this);
                }
            }
        }

         public void forward()
         {
             if (this.___WebHistoryForeward != null)
             {
                 if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                 {
                    commonLog.LogEntry("TODO : {0}.foward() called", this);
                 }
             }
         }

         public void go(object ___goParam)
         {
             if (this.___WebHistoryGo != null)
             {
                 if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                 {
                    commonLog.LogEntry("TODO : {0}.go() called", this);
                 }
             }
        }

        internal void ___clear()
        {
            this.___arHistoryList.Clear();
        }
        public int length
        {
            get
            {
                return this.___arHistoryList.Count;
            }
        }
        public int jsGet_length()
        {
         
                return this.___arHistoryList.Count;
            
        }
       
    }
}
