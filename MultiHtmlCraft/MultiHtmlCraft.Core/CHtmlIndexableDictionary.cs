using System;
using System.Collections.Generic;
using System.Text;
using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// This class is designed for Add Only, indexer access allowd list
    /// 61% faster than "SortedList(StringComparer.OrdinalIgnoreCase)"
    /// SortedList 8917.9479 ms...
    /// IndexableDictionary 3701.4697 ms...
    /// </summary>
    public class CHtmlDictionaryWithIndexEasyAssigned : ICommonObjectInterface 
    {
        internal IMutilversalObjectType ___multiversalType = IMutilversalObjectType.Unkown;
        private System.Collections.Generic.Dictionary<int, string> ___posList = new System.Collections.Generic.Dictionary<int, string>();
        private System.Collections.Generic.Dictionary<string, object> ___list = new Dictionary<string, object>();
   
       
        internal CHtmlHTMLCollectionType ___CollectionType = CHtmlHTMLCollectionType.Unknown;
        public void Add(string s, object o)
        {
            char[] cs = s.ToCharArray();
            foreach (char c in cs)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    s = commonHTML.FasterToLower(s);
                    break;
                }
            }
            int oldCount = this.___list.Count;
            ___list[s] = o;
            ___posList[oldCount] = s;
        }
        public object GetValueByKey(string s)
        {
            object ___object = null;
            string strLow = commonHTML.FasterToLower(s);
            if (this.___list.TryGetValue(strLow, out ___object))
            {
                return ___object;
            }
            return null;
        }
        public int Count
        {
            get
            {
                return this.___list.Count;
            }
        }
        public bool ContainsKey(string s)
        {
            string strLow = commonHTML.FasterToLower(s);
            return ___list.ContainsKey(strLow);
        }
        #region IPropertBox メンバ

        public object ___getPropertyByName(string ___name)
        {

            switch (___name)
            {
                case "length":
                    return this.___list.Count;
                case "__iterator__":
                    return commonHTML.rhinoForLoopEnumratorFunction;
                default:
                    object ___object = null;
                    string strLow = commonHTML.FasterToLower(___name);
                    if (this.___list.TryGetValue(strLow, out ___object))
                    {
                        return ___object;
                    }

                    break;
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValue for {0} {1} \"{2}\" failed", this.GetType(), this, ___name);
            }
            return null;
        }

        public void ___setPropertyByName(string ___name, object val)
        {
           
            this.Add(___name, val);

            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("SetPropertyValue by name {0} {1}  \"{2}\" = {3} success", this.GetType(), this, ___name, val);
            }
        }
        public object GetByIndex(int ___index)
        {
            string strKey = null;
            object ___objectTarget = null;
            if (this.___posList.TryGetValue(___index, out strKey))
            {
                if (___list.TryGetValue(strKey, out ___objectTarget))
                {
                    return ___objectTarget;
                }
            }
            return null;
        }

        /// <summary>
        /// when CHtmlElement is accessed by like document.body[1], it should return the input selement. not child nodes
        /// </summary>
        /// <param name="___index"></param>
        /// <returns></returns>
        public object ___getPropertyByIndex(int ___index)
        {
            if (___index > -1 && ___index < this.___list.Count)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                {
                   commonLog.LogEntry("GetPropertyValueByIndex for {0} {1} {2} success", this.GetType(), this, ___index);
                }
                return this.GetByIndex(___index);
            }
            else
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                {
                   commonLog.LogEntry("GetPropertyValueByIndex for {0} {1} {2} failed", this.GetType(), this, ___index);
                }
                return null;
            }
        }
        public void ___setPropertyByIndex(int ___index, object val)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: SetPropertyValueByIndex for {0} {1} {2} failed", this.GetType(), this, ___index, val);
            }
        }

        public bool ___hasPropertyByName(string ___name)
        {

            return false;
        }
        public bool ___hasPropertyByIndex(int ___index)
        {
            if (___index >= 0 && ___index < this.___list.Count)
            {
                return true;
            }
            return false;
        }
        public object ___common_object_clone()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("x__Clone {0} {1} called", this.GetType(), this);
            }
            return this;
        }
        public void ___deleteByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___deleteByIndex {0} {1} called : {2}", this.GetType(), this, ___index);
            }
        }
        public void ___deleteByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___deleteByName {0} {1} called : {2}", this.GetType(), this, ___name);
            }

        }
        public object[] ___getByIds()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getByIds() {0} {1} called", this.GetType(), this);
            }
            return null;

        }
        public string ___getClassName()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getClassName {0} {1} called", this.GetType(), this);
            }
            return this.GetType().Name;
        }
        public object ___getDefaultValue()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getDefaultValue {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public object ___getParentScope()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getParentScope {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public void ___setParentScope(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___setParentScope {0} {1} called : {2}", this.GetType(), this, ___object);
            }
        }
        public object ___getProtoType()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getProtoType {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public bool ___hasInstance(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___hasInstance {0} {1} called : {2}", this.GetType(), this, ___object);
            }
            return false;
        }
        public bool ___instanceEquals(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___instanceEquals {0} {1} called : {2}", this.GetType(), this, ___object);
            }
            return object.ReferenceEquals(this, ___object);
        }
        public void ___setProtoType(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___setProtoType {0} {1} called : {2}", this.GetType(), this, ___object);
            }
        }
        public IMutilversalObjectType multiversalClassType
        {
            get
            {
                return this.___multiversalType;
            }
        }

        #endregion

    }
}
