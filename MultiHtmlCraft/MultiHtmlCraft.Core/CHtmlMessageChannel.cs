using MultiHtmlCraft.Interfaces;
using NiL.JS.BaseLibrary;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Linq.Expressions;
namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// FileList for HTML5. ex.  input type=files
    /// </summary>
    public class CHtmlMessageChannel : CHtmlNode, ICommonObjectInterface
    {
        internal static Dictionary<string, int> CHtmlMessageChannelProperties = initCHtmlMessageChannelProperties();
        private static Dictionary<string, int> initCHtmlMessageChannelProperties()
        {
            var props = new Dictionary<string, int>();
            props["port1"] = 1;
            props["port2"] = 2;
            return props;
        }
        internal CHtmlMessagePort? ___port1 = null;
        internal CHtmlMessagePort? ___port2 = null;
        public CHtmlMessageChannel()
        {
            this.___multiversalClassType = IMutilversalObjectType.MessageChannel;
            // initialize linked ports
            try
            {
                var p1 = new CHtmlMessagePort();
                var p2 = new CHtmlMessagePort();
                p1.___setPartner(p2);
                p2.___setPartner(p1);
                this.___port1 = p1;
                this.___port2 = p2;
                this.___properties["port1"] = p1;
                this.___properties["port2"] = p2;
            }
            catch { }
        }

        public CHtmlMessageChannel(object[] ___args) 
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("{0}.constuctor called with args:... ", this, ___args);
            }
            this.___multiversalClassType = IMutilversalObjectType.MessageChannel;
            // initialize linked ports for ctor with args as well
            try
            {
                var p1 = new CHtmlMessagePort();
                var p2 = new CHtmlMessagePort();
                p1.___setPartner(p2);
                p2.___setPartner(p1);
                this.___port1 = p1;
                this.___port2 = p2;
                this.___properties["port1"] = p1;
                this.___properties["port2"] = p2;
            }
            catch { }
        }
        public CHtmlMessagePort port1
        {

            get
            {
                return (CHtmlMessagePort)this.___getPropertyByName("port1");
            }
        }
        public CHtmlMessagePort port2
        {

            get
            {
                return (CHtmlMessagePort)this.___getPropertyByName("port2");
            }
        }


        public string getClassName()
        {
            return this.GetType().Name;
        }
        public override string ToString()
        {
            if (this.___IsPrototype == false)
            {
                return this.GetType().Name;
            }
            else
            {
                return this.GetType().Name + "[prototype]";
            }
        }


        public virtual  bool hasOwnProperty(string ___name)
        {
            return this.___hasPropertyByName(___name);
        }


        #region IPropertBox メンバ

        public virtual object ___getPropertyByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValue for {0} {1} ", this, ___name);
            }
            switch (___name)
            {
                case "port1":
                    return this.___port1;
                case "port2":
                    return this.___port2;
                default:
                    break;
            }
            object propValue;
            if (___properties.TryGetValue(___name, out propValue))
            {
                return propValue;
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValue for {0} {1} failed", this, ___name);
            }
            return null;
        }

        public virtual void ___setPropertyByName(string ___name, object val)
        {
            switch (___name)
            {
                default:
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("SetPropertyValue for {0} {1}  {2} = {3} failed", this.GetType(), this, ___name, val);
                    }
                    this.___properties[___name] = val;
                    break;
            }
        }
        public virtual void ___setPropertyByIndex(int ___index, object val)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("SetPropertyValueIndex for {0} {1}  {2} = {3} failed", this.GetType(), this, ___index, val);
            }
        }
        public virtual object ___getPropertyByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValueInex for {0} {1} {2} failed", this.GetType(), this, ___index);
            }
            return null;
        }

        public virtual bool ___hasPropertyByName(string ___name)
        {

            return false;
        }
        public virtual  bool ___hasPropertyByIndex(int ___index)
        {
            return true;
        }
        public virtual  object ___common_object_clone()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("x__Clone {0} {1} called", this.GetType(), this);
            }
            return this;
        }
        public virtual void ___deleteByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___deleteByIndex {0} {1} called : {2}", this.GetType(), this, ___index);
            }
        }
        public virtual void ___deleteByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___deleteByName {0} {1} called : {2}", this.GetType(), this, ___name);
            }

        }
        public virtual  object[] ___getByIds()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getByIds() {0} {1} called", this.GetType(), this);
            }
            return null;

        }
        public virtual  string ___getClassName()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getClassName {0} {1} called", this.GetType(), this);
            }
            return this.GetType().Name;
        }
        public DynamicMetaObject GetMetaObject(Expression parameter)
        {
            return new CHtmlClearScriptDynamicMetaObject<CHtmlMessageChannel>(parameter, this);
        }
        public virtual object ___getDefaultValue()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getDefaultValue {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public virtual object ___getParentScope()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getParentScope {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public virtual void ___setParentScope(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___setParentScope {0} {1} called : {2}", this.GetType(), this, ___object);
            }
        }
        public virtual object ___getProtoType()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getProtoType {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public virtual bool ___hasInstance(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___hasInstance {0} {1} called : {2}", this.GetType(), this, ___object);
            }
            return false;
        }
        public virtual  bool ___instanceEquals(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___instanceEquals {0} {1} called : {2}", this.GetType(), this, ___object);
            }
            return object.ReferenceEquals(this, ___object);
        }
        public virtual  void ___setProtoType(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___setProtoType {0} {1} called : {2}", this.GetType(), this, ___object);
            }
        }

        #endregion
    }
}
