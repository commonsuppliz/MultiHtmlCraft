using System;
using System.Collections.Generic;
using System.Text;
using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// FileList for HTML5. ex.  input type=files
    /// </summary>
    public sealed class CHtmlAudioOscillatorNode : CHtmlAudioNode
    {
      


        public CHtmlAudioOscillatorNode()
        {
            ___frequency = new CHtmlAudioParam();
            ___detune = new CHtmlAudioParam();
            this.___oscillatorNodetype = "";
        }

        internal CHtmlAudioParam ___frequency = null;
        public CHtmlAudioParam frequency
        {
            get { return ___frequency; }
        }
        internal CHtmlAudioParam ___detune = null;
        public CHtmlAudioParam detune
        {
            get { return ___detune; }
        }
        internal string ___oscillatorNodetype = null;
        public new string type
        {
            get { return this.___oscillatorNodetype; }
        }
        internal object ___onended = null;
        public object onended
        {
            get { return this.___onended; }
            set { ___set_onended(value); }
        }
        public void ___set_onended(object __val)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("setting {0}.onended() ", this);
            }
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

        public override  bool hasOwnProperty(string ___name)
        {
            return this.___hasPropertyByName(___name);
        }
        public void start()
        {
            ___start(0);
        }
        public void start(object __pwhen)
        {
            start(commonData.GetDoubleFromObject(__pwhen, 0));
        }
        public void start(double _pwhen)
        {
            ___start(_pwhen);
        }

        internal void ___start(double _pwhen)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("callling {0}.start() ", this);
            }
        }
        public void stop()
        {
            ___stop(0);
        }
        public void stop(double ___val)
        {
            ___stop(___val);
        }
        public void stop(object ___val)
        {
            ___stop(commonData.GetDoubleFromObject(___val, 0));
        }
        public void ___stop(double ___val)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("callling {0}.stop() ", this);
            }

        }
        public void setPeriodicWave()
        {
            this.___setPeriodicWave(null); 
        }
        public void setPeriodicWave(object _pwave)
        {
            this.___setPeriodicWave(_pwave);
        }
        public void setWaveTable(object _pwave)
        {
            this.___setPeriodicWave(_pwave);
        }
        public void setWaveTable()
        {
            this.___setPeriodicWave(null);
        }
        public void ___setPeriodicWave(object _pwave)
        {

            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("callling {0}.setPeriodicWave() ", this);
            }
        }


        #region IPropertBox メンバ

        public override object ___getPropertyByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValue for {0} {1} ", this, ___name);
            }
            switch (___name)
            {
                case "frequency":
                    return this.___frequency;
                case "detune":
                    return this.___detune;
                case "onended":
                    return this.___onended;
                case "type":
                    return this.___oscillatorNodetype;
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

        public override  void ___setPropertyByName(string ___name, object val)
        {
            switch (___name)
            {
                case "type":
                    this.___oscillatorNodetype = commonHTML.GetStringValue(val);
                    break;
                case "onended":
                    ___set_onended(val);
                    break;
            
                default:
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("SetPropertyValue for {0} {1}  {2} = {3} failed", this.GetType(), this, ___name, val);
                    }
                    this.___properties[___name] = val;
                    break;
            }
        }
        public override void ___setPropertyByIndex(int ___index, object val)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("SetPropertyValueIndex for {0} {1}  {2} = {3} failed", this.GetType(), this, ___index, val);
            }
        }
        public override object ___getPropertyByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValueInex for {0} {1} {2} failed", this.GetType(), this, ___index);
            }
            return null;
        }

        public override  bool ___hasPropertyByName(string ___name)
        {

            return false;
        }





        #endregion
    }
}
