using System;
using System.Collections.Generic;
using System.Text;
using MultiHtmlCraft.Interfaces;
using MultiHtmlCraft.Interfaces;

namespace MultiHtmlCraft.Core
{
    public class CHtmlWindowScreenOrientation : CHtmlNode , ICommonObjectInterface 
    {

        
        internal string ___type = "";
        internal double ___angle = 0;
        internal object ___onchange = null;
        public string type
        {
            get { return ___type; }
        }
        public double angle
        {
            get { return ___angle; }
        }
        public object onchange
        {
            get { return this.___onchange;}
            set { this.___onchange = value; }
        }
        #region IPropertBox メンバ

        public void ___setPropertyByName(string ___name, object ___val)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("SetPropertyValueName for {0} {1}  {2} = {3} ", this.GetType(), this, ___name, ___val);
            }
            switch(___name)
            {
                case "type":
                    this.___type = commonHTML.GetStringValue(___val);
                    return;
                case "angle":
                    this.___angle = commonData.GetDoubleFromObject(___val, 0);
                    return;
                case "onchange":
                    this.___onchange = ___val;
                    return;


            }
            this.___properties[___name] = ___val;
        }

        public bool ___hasPropertyByName(string ___name)
        {
            return false;

        }
        public bool ___hasPropertyByIndex(int ___index)
        {
            return true;
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
               commonLog.LogEntry("___getPropertyByName by index {0} {1} {2} failed", this.GetType(), this, ___index);
            }
            return null;
        }
        public object prototype
        {
            get
            {
                if (this.___IsPrototype == false)
                {
                    if (this.___prototypeWeakReference != null)
                    {
                        return this.___prototypeWeakReference.Target;
                    }
                    return this;
                }
                else
                {
                    return this;
                }
            }
        }

        public object ___getPropertyByName(string ___name)
        {
            switch (___name)
            {
                case "type":
                  return ___type;
                case "angle":
                    return this.___angle;
                case "onchange":
                    return this.___onchange;
     

                default:
                    break;
            }
            object objProp = null;
            if (this.___properties.TryGetValue(___name, out objProp) == true)
            {
                return objProp;
            }

            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValue for {0} {1} {2} failed", this.GetType(), this, ___name);
            }

            return null;
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
            return "Screen";
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
            return this.prototype;
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

        #endregion
    }
}
