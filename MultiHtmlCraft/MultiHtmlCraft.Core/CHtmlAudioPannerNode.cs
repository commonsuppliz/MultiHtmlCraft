using System;
using System.Collections.Generic;
using System.Text;
using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// Panner Node
    /// </summary>
    public sealed class CHtmlAudioPannerNode : CHtmlAudioNode
    {



        internal CHtmlAudioParam ___gain = null;
        public CHtmlAudioPannerNode()
        {
            this.___gain = new CHtmlAudioParam();

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

        public override bool hasOwnProperty(string ___name)
        {
            return this.___hasPropertyByName(___name);
        }
        public CHtmlAudioParam gain
        {
            get { return this.___gain; }
        }
        #region properties
        internal double ___coneInnerAngle;
        public double coneInnerAngle
        {
            get { return this.___coneInnerAngle; }
            set { this.___coneInnerAngle = value; }
        }
        internal double ___coneOuterAngle;
        public double coneOuterAngle
        {
            get { return ___coneOuterAngle; }
            set { ___coneOuterAngle = value; }
        }
        internal double ___coneOuterGain;
        public double coneOuterGain
        {
            get { return ___coneOuterGain; }
            set { this.___coneOuterGain = value; }
        }
        /// <summary>
        /// distanaceModel default value is inverse
        /// possible value is linear, inverse, exponential
        /// </summary>
        internal string ___distanceModel = "inverse";
        public string distanceModel
        {
            get { return ___distanceModel; }
            set { ___distanceModel = value; }
        }
        internal double ___maxDistance;
        public double maxDistance
        {
            get { return ___maxDistance; }
            set { this.___maxDistance = value; }
        }
        /// <summary>
        /// panningModel default value is equalpower.
        /// or HRTF
        /// </summary>
        internal string ___panningModel = "equalpower";
        public string panningModel
        {
            get { return ___panningModel; }
            set { ___panningModel = value; }
        }
        internal double ___refDistance;
        public double refDistance
        {
            get { return ___refDistance; }
            set { ___refDistance = value; }
        }
        internal double ___rolloffFactor;
        public double rolloffFactor
        {
            get { return ___rolloffFactor; }
            set { ___rolloffFactor = value; }
        }
        internal double ___positionX;
        public double positionX
        {
            get { return ___positionX; }
            set { ___positionX = value; }
        }
        internal double ___positionY;
        public double positionY
        {
            get { return ___positionY; }
            set { ___positionY = value; }
        }
        internal double ___positionZ;
        public double positionZ
        {
            get { return ___positionZ; }
            set { ___positionZ = value; }
        }

        internal double ___orientationX;
        public double orientationX
        {
            get { return ___orientationX; }
            set { ___orientationX = value; }
        }
        internal double ___orientationY;
        public double orientationY
        {
            get { return ___orientationY; }
            set { ___orientationY = value; }
        }
        internal double ___orientationZ;
        public double orientationZ
        {
            get { return ___orientationZ; }
            set { ___orientationZ = value; }
        }

        #endregion
        #region methods
        /// <summary>
        /// The setPosition() method of the PannerNode Interface defines the position of the audio source relative to the listener (represented by an AudioListener object stored in the AudioContext.listener attribute.) The three parameters x, y and z are unitless and describe the source's position in 3D space using the right-hand Cartesian coordinate system.
        ///  The setPosition() method's default value of the position is (0, 0, 0).
        /// </summary>
        /// <param name="___p1"></param>
        /// <param name="___p2"></param>
        /// <param name="___p3"></param>
        public void setPosition(object ___p1, object ___p2, object ___p3)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: calling {0}.setPosition()", this);
            }
        }
        /// <summary>
        /// The setVelocity() method of the PannerNode Interface defines the velocity vector of the audio source — how fast it is moving and in what direction.
        /// The velocity relative to the listener is used to control the pitch change needed to conform with the Doppler effect due to the relative speed.
        /// As the vector controls both the direction of travel and its velocity, the three parameters x, y and z are expressed in meters per second. 
        /// The default value of the velocity vector is (0, 0, 0).
        /// </summary>
        /// <param name="___p1"></param>
        /// <param name="___p2"></param>
        /// <param name="___p3"></param>
        public void setVolocity(object ___p1, object ___p2, object ___p3)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: calling {0}.setVelocity()", this);
            }
        }
        /// <summary>
        /// The setOrientation() method of the PannerNode Interface defines the direction the audio source is playing in.
        /// This can have a big effect if the sound is very directional — controlled by the three cone-related attributes PannerNode.coneInnerAngle, PannerNode.coneOuterAngle, and PannerNode.coneOuterGain. In such a case, a sound pointing away from the listener can be very quiet or even silent.
        /// The three parameters x, y and z are unitless and describe a direction vector in 3D space using the right-hand Cartesian coordinate system.
        /// The default value of the direction vector is (1, 0, 0).
        /// </summary>
        /// <param name="___p1"></param>
        /// <param name="___p2"></param>
        /// <param name="___p3"></param>
        public void setOrientation(object ___p1, object ___p2, object ___p3)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: calling {0}.setOrientation()",  this);
            }
        }
#endregion

        #region IPropertBox メンバ

        public override object ___getPropertyByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("entering GetPropertyValue for {0} {1} ", this, ___name);
            }
            switch (___name)
            {
                case "gain":
                    return this.___gain;
                case  "coneInnerAngle":
                    return this.___coneInnerAngle;
                case "coneOuterAngle":
                    return this.___coneOuterAngle;
                case "coneOuterGain":
                    return this.___coneOuterGain;
                case "distanceModel":
                    return this.___distanceModel;
                case "maxDistance":
                    return this.___maxDistance;
                case "panningModel":
                    return this.___panningModel;
                case "refDistance":
                    return this.___refDistance;
                case "rolloffFactor":
                    return this.___rolloffFactor;
                case "positionX":
                    return this.___positionX;
                case "positionY":
                    return this.___positionY;
                case "positionZ":
                    return this.___positionZ;
                case "orientationX":
                    return this.___orientationX;
                case "orientationY":
                    return this.___orientationY;
                case "orientationZ":
                    return this.___orientationZ;
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
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("entering SetPropertyValue for {0} {1}  {2} = {3} ", this.GetType(), this, ___name, val);
            }
            switch (___name)
            {
                case "coneInnerAngle":
                    this.___coneInnerAngle = commonData.GetDoubleFromObject(val, 0);
                    return;
                case "coneOuterAngle":
                    this.___coneOuterAngle = commonData.GetDoubleFromObject(val, 0);
                    return;
                case "coneOuterGain":
                    this.___coneOuterGain = commonData.GetDoubleFromObject(val, 0);
                    return;
                case "distanceModel":
                    this.___distanceModel = commonHTML.GetStringValue(val);
                    return;
                case "maxDistance":
                     this.___maxDistance  = commonData.GetDoubleFromObject(val, 0);
                     return;
                case "panningModel":
                    this.___panningModel = commonHTML.GetStringValue(val);
                    return;
                case "refDistance":
                    this.___refDistance  = commonData.GetDoubleFromObject(val, 0);
                    return;
                case "rolloffFactor":
                    this.___rolloffFactor  = commonData.GetDoubleFromObject(val, 0);
                    return;
                case "positionX":
                    this.___positionX = commonData.GetDoubleFromObject(val, 0);
                    return;
                case "positionY":
                    this.___positionY = commonData.GetDoubleFromObject(val, 0);
                    return;
                case "positionZ":
                    this.___positionZ = commonData.GetDoubleFromObject(val, 0);
                    return;
                case "orientationX":
                    this.___orientationX = commonData.GetDoubleFromObject(val, 0);
                    break;
                case "orientationY":
                    this.___orientationY = commonData.GetDoubleFromObject(val, 0);
                    break;
                case "orientationZ":
                    this.___orientationZ = commonData.GetDoubleFromObject(val, 0);
                    break;
                default:
                    this.___properties[___name] = val;
                    break;
            }
        }
        public override  void ___setPropertyByIndex(int ___index, object val)
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
        public override  bool ___hasPropertyByIndex(int ___index)
        {
            return true;
        }




        #endregion
    }
}
