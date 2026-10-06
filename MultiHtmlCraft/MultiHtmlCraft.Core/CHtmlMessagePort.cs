
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Text;
using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// FileList for HTML5. ex.  input type=files
    /// </summary>
    public class CHtmlMessagePort : CHtmlNode, ICommonObjectInterface
    {
        public static Dictionary<string, int> CHtmlMessagePortProperties = initCHtmlMessagePortPropertiesList();
        public static Dictionary<string, int> CHtmlMessagePortMethods = initCHtmlMessagePortMethodsList();

        private static Dictionary<string, int> initCHtmlMessagePortPropertiesList()
        {
            Dictionary<string, int> list = new Dictionary<string, int>();
            list["onmessage"] = 0;
            list["onmessageerror"] = 1;
            return list;
        }
        private static Dictionary<string, int> initCHtmlMessagePortMethodsList()
        {
            Dictionary<string, int> list = new Dictionary<string, int>();
            list["postMessage"] = 0;
            list["start"] = 1;
            list["close"] = 2;
            return list;
        }

        internal CHtmlMessagePort? ___partner = null;
        private object? _onmessage = null;

        internal void ___setPartner(CHtmlMessagePort partner)
        {
            this.___partner = partner;
        }

        // onmessage handler for script assignment (port.onmessage = fn)
        public object onmessage
        {
            get
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5) commonLog.LogEntry($"enter CHtmlMessagePort.onmessage");
                if (this.___properties.TryGetValue("onmessage", out var h)) return h!;
                return _onmessage!;
            }
            set
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5) commonLog.LogEntry($"enter CHtmlMessagePort.onmessage set with : " + value);
                _onmessage = value;
                // store in dynamic property bag so ClearScript BindGet/Set can find it
                this.___properties["onmessage"] = value;
            }
        }

        // postMessage to send data to the other port
        public void postMessage(object message)
        {
             if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5) commonLog.LogEntry($"TODO enter CHtmlMessagePort.postMessage {message } ");
            try
            {
                if (this.___partner != null)
                {
                    this.___partner.___receiveMessage(message);
                }
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("CHtmlMessagePort.postMessage error: {0}", ex.Message); } catch { }
            }
        }
        public void start()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5) commonLog.LogEntry($"TODO enter CHtmlMessagePort.start() ");
            try
            {

            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("CHtmlMessagePort.postMessage start() error : {0}", ex.Message); } catch { }
            }
        }
        public void close()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5) commonLog.LogEntry($"TODO enter CHtmlMessagePort.close() ");
            try
            {

            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("CHtmlMessagePort.postMessage close() error : {0}", ex.Message); } catch { }
            }
        }

        internal void ___receiveMessage(object message)
        {
            try
            {
                // Prefer stored dynamic handler in properties
                object? handler = null;
                if (!this.___properties.TryGetValue("onmessage", out handler)) handler = _onmessage;

                if (handler == null) return;

                var typeName = handler.GetType().Name ?? string.Empty;
                // If it's a ClearScript V8 function object, invoke dynamically
                if (typeName.Contains("V8ScriptObject") || typeName.Contains("ScriptObject") || typeName.Contains("ScriptItem"))
                {
                    try
                    {
                        dynamic v8 = handler;
                        // pass plain message; callers can wrap into event object if needed
                        v8(message);
                        return;
                    }
                    catch (Exception ex)
                    {
                        try { if (commonLog.LoggingEnabled) commonLog.LogEntry("V8 onmessage invoke error: {0}", ex.Message); } catch { }
                    }
                }
                // If it's a delegate, invoke
                if (handler is Delegate d)
                {
                    try { d.DynamicInvoke(new object[] { message }); return; } catch { }
                }
                // otherwise, ignore or attempt dynamic invocation
                try { dynamic dyn = handler; dyn(message); } catch { }
            }
            catch { }
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
