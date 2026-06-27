using System;
using System.Collections.Generic;
using System.Text;
using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// window.matchMedia() resultset
    /// </summary>
    public class CHtmlMatchMedia : ICommonObjectInterface 
    {
        public CHtmlMatchMedia(string _media)
        {
            this.___media = string.Copy(_media);
            if (___media.Length != 0)
            {
                CHtmlMediaQueryNode mediaNode = null;
                mediaNode = new CHtmlMediaQueryNode(CHtmlMediaQueryNodeType.RootNode);
                mediaNode.OwnerElementType = MediaQueryOwnerElementType.CSSInlineMedia;
                mediaNode.Text = this.___media;
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                   commonLog.LogEntry("window.matchMedia({0})  result : {1}", this.___media, mediaNode.Result);
                }
                if (mediaNode.Result == CHtmlMediaQueryResult.OK)
                {
                    this.___matches = true;
                }
                else
                {
                    this.___matches = false;
                }
            }
            else
            {
                this.___matches = false;
            }
        }
        private bool ___matches = false;
        public bool matches
        {
            get
            {
                return this.___matches;
            }
        }
        private string ___media = "";
        public void addListener(object ___listener)
        {

        }
        public void removeListener(object ___listener)
        {

        }

        #region Object Interfaces

        public void ___setPropertyByName(string ___name, object ___val)
        {
           // this.___properties[___name] = ___val;
        }
        public void ___setPropertyByIndex(int ___index, object val)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("SetPropertyValueIndex for {0} {1}  {2} = {3} failed", this.GetType(), this, ___index, val);
            }
        }
        public object ___getPropertyByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValueInex for {0} {1} {2} failed", this.GetType(), this, ___index);
            }
            return null;
        }
        public object ___getPropertyByName(string ___name)
        {
            switch (___name)
            {
                case "matches":
                    return this.matches;
                case "media":
                    return this.___media;

            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValue for {0} {1} {2} failed", this.GetType(), this, ___name);
            }
            return null;

        }
        public bool isMatching(object ___object)
        {
            return this.___isMatching_Inner(___object);
        }
        public bool isMatching()
        {
            return this.___isMatching_Inner(null);
        }
        private bool ___isMatching_Inner(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("{0}.isMatches({1}) returns true", this, ___object, ___matches);
            }
            return this.___matches;
        }

        public bool ___hasPropertyByName(string ___name)
        {
            switch (___name)
            {
                case "matches":
                    return true;
                case "media":
                    return true;
                case "addListenter":
                    return true;
                case "removeListener":
                    return true;
            }
            return false;
        }
        public bool ___hasPropertyByIndex(int ___index)
        {
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
                return IMutilversalObjectType.Unkown;
            }
        }
        #endregion


    }
}
