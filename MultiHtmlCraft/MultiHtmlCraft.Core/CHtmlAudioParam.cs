using System;
using System.Collections.Generic;
using System.Text;

using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// The AudioParam interface represents an audio-related parameter, usually a parameter of an AudioNode (such as GainNode.gain). An AudioParam can be set to a specific value or a change in value, and can be scheduled to happen at a specific time and following a specific pattern.
    /// </summary>
    public sealed class CHtmlAudioParam : CHtmlNode, ICommonObjectInterface 
    {
      
        internal System.WeakReference ___ownerDocumentWeakReference = null;


        internal double ___value = 0;

        internal double ___defaultValue = 0;
        public CHtmlAudioParam()
        {
            this.___multiversalClassType = IMutilversalObjectType.AudioParam;
        }
        public void setValueAtTime(double _value)
        {
            ___setValueCurveAtTime(_value,0);
        }
        public void setValueAtTime(object _value, object _startTime)
        {
            ___setValueCurveAtTime(commonData.GetDoubleFromObject(_value,0), commonData.GetDoubleFromObject(_startTime,0));
        }
        public void setValueAtTime(double _value, double _startTime)
        {
            ___setValueCurveAtTime(_value , _startTime);
        }
        public void setValueCurveAtTime(double _value)
        {
            ___setValueCurveAtTime(_value,0);
        }
        public void setValueCurveAtTime()
        {
            ___setValueCurveAtTime(0, 0);
        }
        internal void ___setValueCurveAtTime(double _value, double _startTime)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("callling {0}.setValueCurveAtTime() ", this);
            }
        }
        public void cancelScheduledValues(double _startTime)
        {
            ___cancelScheduledValues(_startTime);
        }
        public void cancelScheduledValues()
        {
            ___cancelScheduledValues(0);
        }
        internal void ___cancelScheduledValues(double _startTime)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("callling {0}.cancelScheduledValue() ", this);
            }
        }
        public void exponentialRampToValueAtTime(double _value, double _endTime)
        {
            ___exponentialRampToValueAtTime(_value, _endTime);
        }
        internal void ___exponentialRampToValueAtTime(double _value, double _endTime)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("callling {0}.exponentialRampToValueAtTime() ", this);
            }
        }
        public void linearRampToValueAtTime(double _value, double _endTime)
        {
            ___linearRampToValueAtTime(_value, _endTime);
        }
        internal void ___linearRampToValueAtTime(double _value, double _endTime)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("callling {0}.linearRampToValueAtTime() ", this);
            }
        }
        public void setTargetAtTime(double target, double startTime, double timeConstant)
        {
            ___setTargetAtTime(target, startTime, timeConstant);
        }
        public void setTargetAtTime(double target, double startTime)
        {
            ___setTargetAtTime(target, startTime,0);
        }
        public void setTargetAtTime(double target)
        {
            ___setTargetAtTime(target, 0, 0);
        }
        internal void ___setTargetAtTime(double target, double startTime, double timeConstant)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("callling {0}.setTargetTime() ", this);
            }
        }


        public double value
        {
            get { return this.___value; }
            set { this.___value = value; }
        }
        public double defaultValue
        {
            get { return this.___defaultValue; }
            set { this.___defaultValue = value; }
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

        public bool hasOwnProperty(string ___name)
        {
            return this.___hasPropertyByName(___name);
        }


        #region IPropertBox メンバ

        public object ___getPropertyByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValue for {0} {1} ", this, ___name);
            }
            switch (___name)
            {
                case "value":
                    return this.___value;
                case "defaultValue":
                    return this.___defaultValue;
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

        public void ___setPropertyByName(string ___name, object val)
        {
            switch (___name)
            {
                case "value":
                    this.___value = commonData.GetDoubleFromObject(val, 0);
                    return;
                case "defaultValue":
                    this.___value = commonData.GetDoubleFromObject(val, 0);
                    return;
                default:
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("SetPropertyValue for {0} {1}  {2} = {3} failed", this.GetType(), this, ___name, val);
                    }
                    this.___properties[___name] = val;
                    break;
            }
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

        public bool ___hasPropertyByName(string ___name)
        {

            return false;
        }
        public bool ___hasPropertyByIndex(int ___index)
        {
            return true;
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

        #endregion
    }
}
