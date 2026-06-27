using System;
using System.Collections.Generic;
using System.Text;
using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// FileList for HTML5. ex.  input type=files
    /// </summary>
    public class CHtmlAudioNode : CHtmlNode, ICommonObjectInterface 
    {
        internal string ___type = null;
        internal System.WeakReference ___ownerDocumentWeakReference = null;
        internal System.WeakReference ___ownerContextWeakReference = null;


        internal double ___numberOfInputs = 0;
        internal double ___numberOfOutputs = 0;
        internal double ___channelCount = 0;
        internal string ___channelCountMode = null;
        internal string ___channelInterpretation = null;
        public double numberOfInputs
        {
            get { return this.___numberOfInputs; }
            set { this.___numberOfInputs = value; }
        }
        public double numberOfOutputs
        {
            get { return this.___numberOfOutputs; }
            set { this.___numberOfOutputs = value; }
        }
        public double channelCount
        {
            get { return this.___channelCount; }
            set { this.___channelCount = value; }
        }
        public string channelCountMode
        {
            get { return commonHTML.___convertNullToEmpty(this.___channelCountMode); }
            set { this.___channelCountMode = value; }
        }
        public string channelInterpretation
        {
            get {return commonHTML.___convertNullToEmpty(this.___channelInterpretation); }
            set { this.___channelInterpretation = value; }
        }

        public CHtmlCanvasContext2D context
        {
            get
            {
                if (this.___ownerContextWeakReference != null)
                {
                    return this.___ownerContextWeakReference.Target as CHtmlCanvasContext2D;
                }
                return null;
            }
        }
        #region AudioNode Methods
        public void connect()
        {
            this.___connect_Inner(null, null, null);
        }
        public void connect(object ___audioParamObject)
        {
            this.___connect_Inner(___audioParamObject, null, null);
        }
        public void connect(object ___audioParamObject, object _n1)
        {
            this.___connect_Inner(___audioParamObject, _n1, null);
        }
        public void connect(object ___audioParamObject, double  _n1, double  _n2)
        {
            this.___connect_Inner(___audioParamObject, _n1, _n2);
        }
        private void ___connect_Inner(object ___audioParamObject, object  _n1, object _n2)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
            {
               commonLog.LogEntry("calling {0}.connect({1})", this, ___audioParamObject);
            }
        }
        public CHtmlAudioGainNode createGain()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
            {
               commonLog.LogEntry("calling {0}.createGain()", this);
            }
            CHtmlAudioGainNode ___gainNode = new CHtmlAudioGainNode();
            ___gainNode.___ownerContextWeakReference = this.___ownerContextWeakReference;
            return ___gainNode;
        }
        public void disconnect()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
            {
               commonLog.LogEntry("calling {0}.disconnect()", this);
            }
        }
        #endregion

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
        public string type
        {
            get {return  commonHTML.___convertNullToEmpty(this.___type); }
            set { this.___type = value; }
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
                case "type":
                    return commonHTML.___convertNullToEmpty(this.___type);
                case "numberOfInputs":
                    return this.___numberOfInputs;
                case "numberOfOutputs":
                    return this.___numberOfOutputs;
                case "context":
                    return this.context;
                case "channelCount":
                    return this.___channelCount;
                case "channelCountMode":
                    return commonHTML.___convertNullToEmpty(this.___channelCountMode);
                case "channelInterpretation":
                    return commonHTML.___convertNullToEmpty(this.___channelInterpretation);
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
