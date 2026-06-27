using System;
using System.Collections.Generic;
using System.Text;
using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// FileList for HTML5. ex.  input type=files
    /// </summary>
    public sealed class CHtmlAudioBufferSourceNode : CHtmlAudioNode
    {


        internal System.WeakReference ___ownerCanvasContextWeakReference = null;
        internal CHtmlAudioBuffer ___buffer = null;
        internal CHtmlAudioParam  ___playbackRate = null;
        internal CHtmlAudioParam  ___detune = null;
        internal bool ___loop = false;
        internal double ___loopEnd;
        internal double ___loopStart;
        public CHtmlAudioBufferSourceNode()
        {
            
        }

        public CHtmlAudioBuffer buffer
        {
            get { return this.___buffer; }
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
        public CHtmlAudioParam detune
        {
            get { return this.___detune; }
        }
        public double loopEnd
        {
            get { return this.___loopEnd; }
        }
        public double loopStart
        {
            get { return this.___loopStart; }
        }

        public CHtmlAudioParam  playbackRate
        {
            get
            {
                if(this.___playbackRate == null)
                {
                    this.___playbackRate = new CHtmlAudioParam();
                   
                }
                return ___playbackRate;
            }
        }
       
        public override  bool hasOwnProperty(string ___name)
        {
            return this.___hasPropertyByName(___name);
        }
        public void start()
        {
            this.___start_inner(null, null, null);
        }
        public void start(object pwhen, object poffset, object pduaration)
        {
            this.___start_inner(pwhen, poffset, pduaration);

        }
        public void start(object pwhen)
        {
            this.___start_inner(pwhen, null,null);

        }
        public void start(object pwhen, object poffset)
        {
            this.___start_inner(pwhen, poffset, null);

        }
        internal void ___start_inner(object pwhen, object poffset, object pduaration)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling {0}.start()", this);
            }
            try
            { }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                {
                   commonLog.LogEntry("calling {0}.start() exception", ex);
                }
            }
        }
        public void stop(double ___time)
        {
            this.___stop_inner(___time);
        }
        public void stop()
        {
            this.___stop_inner(double.MinValue);
        }
        private void ___stop_inner(double ___num)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: calling {0}.stop()", this);
            }
            try
            { }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                {
                   commonLog.LogEntry("calling {0}.stop() exception", ex);
                }

            }
        }

        #region IPropertBox メンバ

        public override object ___getPropertyByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("getPropertyValue for {0} {1} ", this, ___name);
            }
            switch (___name)
            {
                case "buffer":
                    return this.___buffer;
                case "playbackRate":
                    return this.playbackRate;
                case "loop":
                    return this.___loop;
                case "detrune":
                    return this.___detune;
                case "loopEnd":
                    return this.___loopEnd;
                case "loopStart":
                    return this.___loopStart;

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
               commonLog.LogEntry("getPropertyValue for {0} {1} failed", this, ___name);
            }
            return null;
        }


        public override void ___setPropertyByName(string ___name, object val)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("setPropertyValue for {0} {1} ", this, ___name);
            }
            switch (___name)
            {
                case "buffer":

                    this.___buffer = null;
                    break;
                case "loop":
                    this.___loop = commonData.convertObjectToBoolean(val, false);
                    break;
                case "loopEnd":
                    this.___loopEnd = commonData.GetDoubleFromObject(val, 0);
                    break;
                case "loopStart":
                    this.___loopStart = commonData.GetDoubleFromObject(val, 0);
                    break;

                default:
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("setPropertyValue for {0} {1}  {2} = {3} failed", this.GetType(), this, ___name, val);
                    }
                    this.___properties[___name] = val;
                    break;
            }
        }


        public override  bool ___hasPropertyByName(string ___name)
        {

            return false;
        }



        #endregion
    }
}
