using System;
using System.Collections.Generic;
using System.Text;
using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// The AudioParam interface represents an audio-related parameter, usually a parameter of an AudioNode (such as GainNode.gain). An AudioParam can be set to a specific value or a change in value, and can be scheduled to happen at a specific time and following a specific pattern.
    /// </summary>
    public sealed class CHtmlAudioAnalyserNode : CHtmlNode, ICommonObjectInterface 
    {
      
        internal System.WeakReference ___ownerDocumentWeakReference = null;
        internal System.WeakReference ___ownerContextWeakReference = null;




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
        internal double ___frequencyBinCount = 1;
        /// <summary>
        /// The frequencyBinCount property of the AnalyserNode interface is an unsigned long value half that of the FFT size. This generally equates to the number of data values you will have to play with for the visualization.
        /// </summary>
        public double frequencyBinCount
        {
            get { return ___frequencyBinCount; }
        }
        internal double ___fftSize = 2028;
        /// <summary>
        /// The fftSize property of the AnalyserNode interface is an unsigned long value representing the size of the FFT (Fast Fourier Transform) to be used to determine the frequency domain.
        /// The fftSize property's value must be a non-zero power of 2 in a range from 32 to 32768; its default value is 2048.
        /// </summary>
        public double fftSize
        {
            get { return ___fftSize; }
        }
        internal double ___maxDecibels = -30;
        internal double ___minDecibels = -100;
        /// <summary>
        /// The maxDecibels property of the AnalyserNode interface Is a double value representing the maximum power value in the scaling range for the FFT analysis data, for conversion to unsigned byte/float values — basically, this specifies the maximum value for the range of results when using getFloatFrequencyData() or getByteFrequencyData().
        //  The maxDecibels property's default value is -30.
        /// </summary>
        public double maxDecibels
        {
            get { return this.___maxDecibels; }
        }
        /// <summary>
        /// The minDecibels property of the AnalyserNode interface Is a double value representing the minimum power value in the scaling range for the FFT analysis data, for conversion to unsigned byte/float values — basically, this specifies the minimum value for the range of results when using getFloatFrequencyData() or getByteFrequencyData().
        /// The minDecibels property's default value is -100.
        /// </summary>
        public double minDecibels
        {
            get { return this.___minDecibels; }
        }

        public void connect(CHtmlAudioGainNode ___destNode )
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling {0}.connect()", this);
            }

        }
        internal double ___smoothingTimeConstant = 0.8;
        /// <summary>
        /// The smoothingTimeConstant property of the AnalyserNode interface is a double value representing the averaging constant with the last analysis frame. It's basically an average
        /// between the current buffer and the last buffer the AnalyserNode processed, and results in a much smoother set of value changes over time.
        /// The smoothingTimeConstant property's value defaults to 0.8; it must be in the range 0 to 1 (0 meaning no time averaging). If 0 is set, there is no averaging done, whereas a value of 1 means "overlap the previous and current buffer quite a lot while computing the value", which essentially smoothes the changes across AnalyserNode.getFloatFrequencyData/AnalyserNode.getByteFrequencyData calls.
        /// In technical terms, we apply a Blackman window and smooth the values over time.The default value is good enough for most cases.
        /// </summary>
        public double smoothingTimeConstant
        {
            get { return ___smoothingTimeConstant; }
        }

        public void disconnect()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling {0}.disconnect()", this);
            }

        }
        /// <summary>
        /// The getByteFrequencyData() method of the AnalyserNode interface copies the current frequency data into a Uint8Array (unsigned byte array) passed into it.
        /// If the array ___hasInner fewer elements than the AnalyserNode.frequencyBinCount, excess elements are dropped.If it ___hasInner more elements than needed, excess elements are ignored.
        /// </summary>
        /// <param name="objArray"></param>
        /// <returns></returns>
        public object getByteFrequencyData(object objArray)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: calling {0}.getByteFrequencyData()", this);
            }
            return objArray;
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
                case "fftSize":
                    return this.___fftSize;
                case "frequencyBinCount":
                    return this.___frequencyBinCount;
                case "maxDecibels":
                    return this.___maxDecibels;
                case "minDecibels":
                    return this.___minDecibels;
                case "smoothingTimeConstant":
                    return this.___smoothingTimeConstant;
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
