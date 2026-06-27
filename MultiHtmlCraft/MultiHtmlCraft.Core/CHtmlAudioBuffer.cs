using System;
using System.Collections.Generic;
using System.Text;
using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// The AudioParam interface represents an audio-related parameter, usually a parameter of an AudioNode (such as GainNode.gain). An AudioParam can be set to a specific value or a change in value, and can be scheduled to happen at a specific time and following a specific pattern.
    /// </summary>
    public sealed class CHtmlAudioBuffer : CHtmlNode, ICommonObjectInterface 
    {
      
        internal System.WeakReference ___ownerDocumentWeakReference = null;


        internal double ___length = 0;
        internal double ___sampleRate = 0;
        internal double ___duration = 0;
        internal double ___numberOfChannels = 0;
        /// <summary>
        /// AudioBuffer can have muliple channel data
        /// </summary>
        internal List<CHtmlNativeArray> ___channelData;

        public CHtmlAudioBuffer()
        {
           
        }
        public double length
        {
            get { return this.___length; }
        }
        public double sampleRate
        {
            get { return this.___sampleRate; }
        }
        public double duration
        {
            get { return this.___duration; }
        }
        public double numberOfChannels
        {
            get { return this.___numberOfChannels; }
        }
        /// <summary>
        /// The getChannelData() method of the AudioBuffer Interface returns a Float32Array containing the PCM data associated with the channel, defined by the channel parameter (with 0 representing the first channel).
        /// </summary>
        /// <param name="___channdelObject"></param>
        /// <returns>Float32Array</returns>
        public CHtmlNativeArray  getChannelData(object ___channdelObject)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry(" calling {0}.getChannelData({1})", this, ___channdelObject);
            }
            return this.___channelData[commonHTML.GetIntFromObject(___channdelObject,0)];
        }
        public void copyFromChannel(object ___obj_destination, object ___obj_channelNumber, object ___obj_startInChannel)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO: calling {0}.copyFromChanndel()", this);
            }
        }

        public void copyToChannel(object ___obj_source, object ___obj_channelNumber, object ___obj_startInChannel)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO: calling {0}.copyToChanndel()", this);
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

        public  bool hasOwnProperty(string ___name)
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
                case "numberOfChannels":
                    return this.numberOfChannels;
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

        public  bool ___hasPropertyByName(string ___name)
        {

            return false;
        }
        public   bool ___hasPropertyByIndex(int ___index)
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
        public  void ___deleteByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___deleteByName {0} {1} called : {2}", this.GetType(), this, ___name);
            }

        }
        public  object[] ___getByIds()
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
        public  void ___setParentScope(object ___object)
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
