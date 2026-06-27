using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using MultiHtmlCraft.Interfaces;
using System.Runtime.CompilerServices;
using MultiHtmlCraft.Interfaces;
using System.Collections.Generic;

namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// AudioContext
    /// </summary>
    
    public class CHtmlAudioContext : CHtmlNode, ICommonObjectInterface, System.IDisposable
    {


        internal CHtmlCanvasContextAttributes ___contextAttributes = null;
        internal System.WeakReference ___MultiversalWindowWeakReference = null;


        private const int ___canvasCHtmlFontInfoMaximumEntries = 10000; private const double ___audioContextSampleRate = 48000;
        internal System.WeakReference ___audioContextPrototypeInstanceWeakReference = null;

        internal string ___state = "suspended";
        internal double ___currentTime = 0;
        public CHtmlAudioContext()
        { }
        public CHtmlAudioContext(bool isPrototype)
        {
            this.___IsPrototype = isPrototype;
        }



        ~CHtmlAudioContext()
        {

            this.___IsDisposing = true;
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
                if (this.___IsPrototype == false)
                {
                   commonLog.LogEntry("AudioContext Fializing ...");
                }
            }


            this.___cleanUp();
        }
        private object ___ContextTimerLockingObject = new object();
        private int ___ContextTimerDelay = 50;
        private const int MAX_CONTEXT_TIMER_DELAY = 15000; // 15 seconds
        private int CONTEXT_TIMER_WATCH_INTERVAL = 50;





        internal static PointF PointNaN = new PointF(float.NaN, float.NaN);





        private System.IntPtr ___ParentWindowControlHandle = IntPtr.Zero;

        // private DateTime ___CanvasContextLatestDrawTime = DateTime.Now;
        private string ___ContextMode = null;
        internal CanvasContextModeType ___CanvasContextModeType = CanvasContextModeType.None;
        internal System.WeakReference ___parentElementWeakReference = null;
        internal int ___parentElementOID = -1;
        internal System.WeakReference ___ownerDocumentWeakReference = null;
        internal System.WeakReference ___C2DImageWeakReference = null;



        #region AudioContextAttributes





        #endregion
        /// <summary>
        /// Number of Context Object Finalized Count
        /// 
        /// </summary>






        private bool ___IsGraphicsPathOpen = false;
        /// <summary>
        /// ___currentPointF
        /// if not set it is (float.NaN, floatNaN)
        /// </summary>
        private System.Drawing.PointF ___currentPointF = PointNaN;
        public bool ___IsDisposing = false;





     
        internal CHtmlAudioDestinationNode ___audioDestinationNode = null;









        private void ____doNothing()
        {
            if (this.___IsGraphicsPathOpen)
            {
            }
        }





        #region IDisposable メンバ

        public void Dispose()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 1000)
            {
                if (this.___IsPrototype == false)
                {
                   commonLog.LogEntry("AudioContext Disposing ...");
                }
            }
            this.___IsDisposing = true;
            this.___cleanUp();
            GC.SuppressFinalize(this);
        }



        #endregion

        private void ___cleanUp()
        {


            if (this.___parentElementWeakReference != null)
            {
                this.___parentElementWeakReference = null;
            }




            this.___ContextTimerLockingObject = null;


        }

        public string ContextMode
        {
            get { return this.___ContextMode; }
            set { this.___ContextMode = value; }
        }
        public CHtmlElement parentElement
        {
            get {
                if (this.___parentElementWeakReference != null)
                {
                    return this.___parentElementWeakReference.Target as CHtmlElement;
                }
                return null;
            }
            set { this.___parentElementWeakReference = new WeakReference(value, false); }
        }
        public CHtmlElement canvas
        {
            get { return this.parentElement; }

        }
        public override string ToString()
        {
            return string.Format("Context : " + this.___CanvasContextModeType.ToString());
        }



        public string state
        {
            get { return ___state; }
            set
            {
                this.___state = commonHTML.GetStringValue(value);
            }
        }






        public CHtmlAudioBiquadFilterNode createBiquadFilter()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("calling {0}.createBiqualFilter()", this);
            }
            CHtmlAudioBiquadFilterNode ___biquadFilter = new CHtmlAudioBiquadFilterNode();
            ___biquadFilter.___ownerContextWeakReference = new WeakReference(this, false);
            return ___biquadFilter;
        }


        public CHtmlAudioDynamicsCompressorNode createDynamicsCompressor()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("calling {0}.createDynamicsCompressor()", this);
            }
            return new CHtmlAudioDynamicsCompressorNode();
        }


        public void bindBuffer(object ___objectTarget, object ___objectBuffer)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("calliing {0}.bindBuffer({1}, {2})", this, ___objectTarget, ___objectBuffer);
            }
        }
        public void bufferData(object obj_target, object obj_size_data, object obj_usage)
        {

        }
        /// <summary>
        /// Sets the weighting factors that are used by blendEquationSeparate.
        /// </summary>
        /// <param name="___srcRGB"></param>
        /// <param name="___dstRGB"></param>
        /// <param name="___srcAlpha"></param>
        /// <param name="___dstAlpha"></param>
        public void blendFuncSeparate(object ___srcRGB, object ___dstRGB, object ___srcAlpha, object ___dstAlpha)
        {

        }
        public void blendEquation(object ___mode)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO: calling {0}.blendEquation({1})", this, ___mode);
            }
        }
        public void cullFace(object ___mode)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO: calling {0}.cullFace({1})", this, ___mode);
            }
        }
        public void viewport(object object_x, object object_y, object p1, object p2)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("setting {0}.viewport({1}, {2}, {3} , {4})", this, object_x, object_y, p1, p2);
            }
        }
        public void shaderSource(object ___shader, object ___shaderType)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO: calling {0}.sourceShader({1}, {2}", this, ___shader, ___shaderType);
            }
        }
        public void compileShader(object ___shaderSource)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO: calling {0}.compileShader({1})", this, ___shaderSource);
            }
        }
        /// <summary>
        /// Attaches a WebGLShader object to a WebGLProgram object.
        /// </summary>
        /// <param name="___objectProgram"></param>
        /// <param name="___shader"></param>
        public void attachShader(object ___objectProgram, object ___shader)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO: calling {0}.attachShader({1}, {2})", this, ___objectProgram, ___shader);
            }
        }
        /// <summary>
        /// Links an attached vertex shader and an attached fragment shader to a program so it can be used by the graphics processing unit (GPU).
        /// </summary>
        /// <param name="___objectProgram"></param>
        public void linkProgram(object ___objectProgram)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO: calling {0}.linkProgram({1})", this, ___objectProgram);
            }
        }
        /// <summary>
        /// Returns the value of the program parameter that corresponds to a supplied pname for a given program, or null if an error occurs.
        /// </summary>
        /// <param name="___objectProgram">A WebGLProgram to ___getInner parameter information from.</param>
        /// <param name="___pname">A Glenum specifying the information to query. Possible values:
        /// gl.DELETE_STATUS: Returns a GLboolean indicating whether or not the program is flagged for deletion.
        /// gl.LINK_STATUS: Returns a GLboolean indicating whether or not the last link operation was successful.
        /// gl.VALIDATE_STATUS: Returns a GLboolean indicating whether or not the last validation operation was successful.
        /// gl.ATTACHED_SHADERS: Returns a GLint indicating the number of attached shaders to a program.
        /// gl.ACTIVE_ATTRIBUTES: Returns a GLint indicating the number of active attribute variables to a program.
        /// gl.ACTIVE_UNIFORMS: Returns a GLint indicating the number of active uniform variables to a program.
        /// When using a WebGL 2 context, the following values are available additionally:
        /// gl.TRANSFORM_FEEDBACK_BUFFER_MODE: Returns a GLenum indicating the buffer mode when transform feedback is active.May be gl.SEPARATE_ATTRIBS or gl.INTERLEAVED_ATTRIBS.
        /// gl.TRANSFORM_FEEDBACK_VARYINGS: Returns a GLint indicating the number of varying variables to capture in transform feedback mode.
        /// gl.ACTIVE_UNIFORM_BLOCKS: Returns a GLint indicating the number of uniform blocks containing active uni

        /// <returns>Returns the requested program information (as specified with pname).</returns>
        public object getProgramParameter(object ___objectProgram, object ___param)
        {

            /*
             pname	returned type
            gl.DELETE_STATUS	Boolean
            gl.LINK_STATUS	Boolean
            gl.VALIDATE_STATUS	Boolean
            gl.ATTACHED_SHADERS	Number
            gl.ACTIVE_ATTRIBUTES	Number
            gl.ACTIVE_UNIFORMS	Number
           */
            int ___paramValue = (int)commonData.GetDoubleFromObject(___param, 0);
            bool ___objResult = false;
            switch (___paramValue)
            {
                case (int)0x8B80:
                    ___objResult = false;
                    break;
                case (int)0x8B82:
                    ___objResult = false;
                    break;
                case (int)0x8B83:
                    ___objResult = false;
                    break;
                case (int)0x8B85:
                    ___objResult = false;
                    break;
                case (int)0x8B89:
                    ___objResult = false;
                    break;
                case (int)0x8B86:
                    ___objResult = false;
                    break;
                default:
                    ___objResult = false;
                    break;

            }

            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("calling {0}.getProgramparameter({1}, {2}) returns : {3}", this, ___objectProgram, ___paramValue, ___objResult);
            }

            return ___objResult;
        }
        /// <summary>
        /// Set the program object to use for rendering.
        /// </summary>
        /// <param name="___objectProgram"></param>
        public void useProgram(object ___objectProgram)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO: calling {0}.useProgram({1})", this, ___objectProgram);
            }
        }
        public double getAttribLocation(object ___objectProgram, object ___pname)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO: calling {0}.getAttribLocation({1}, {2})", this, ___objectProgram, ___pname);
            }
            return 0;
        }
        public void vertexAttribPointer(object ___object_index, object ___object_size, object ___object_type, object ___object_normalized, object ___object_stride, object ___object_offset)
        {
        }
        /// <summary>
        /// Returns the value of the parameter associated with pname for a shader object.
        /// </summary>
        /// <param name="___shader"></param>
        /// <param name="___pcname"></param>
        /// <returns></returns>
        public object getShaderParameter(object ___shader, object ___pcname)
        {

            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("calling {0}.getShaderParameter({1}, {2})", this, ___shader, ___pcname);
            }
            int ___pcvalue = (int)commonData.GetDoubleFromObject(___pcname, 0);
            switch (___pcvalue)
            {
                case (int)0x8B4F:
                    return 0;
                case (int)0x8B80:
                    return true;
                case (int)0x8B81:
                    return true;
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("{0}.getShaderParameter({1}, {2}) failed", this, ___shader, ___pcname);
            }
            return null;
        }
        public void depthFunc(object ___param)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO: calling {0}.depthFunc({1})", this, ___param);
            }
        }
        public void activeTexture(object ___texture)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO: calling {0}.activeTexture({1})", this, ___texture);
            }
        }
        public string getProgramInfoLog(object ___program)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO: calling {0}.getProgramInfoLog({1})", this, ___program);
            }
            return "";
        }
        public string getShaderInfoLog(object ___shader)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO: calling {0}.getShaderInfoLog({1})", this, ___shader);
            }
            return "";
        }
        /// <summary>
        /// Turns on a vertex attribute at a specific index position in a vertex attribute array.
        /// </summary>
        /// <param name="___vertexIndex"></param>
        public void enableVertexAttribArray(object ___vertexIndex)
        {

        }
        /// <summary>
        /// Turns off a vertex attribute at a specific index position in a vertex attribute array.
        /// </summary>
        /// <param name="___vertexIndex"></param>
        public void disableVertexAttribArray(object ___vertexIndex)
        {

        }
        public void enable(object ___objectCap)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO: calling {0}.enable({1})", this, ___objectCap);
            }
        }
        public void disable(object ___objectCap)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO: calling {0}.disable({1})", this, ___objectCap);
            }
        }














        internal static double ___ConvertNaNInfiniteToZero(double ___double)
        {
            if (double.IsNaN(___double) || double.IsNegativeInfinity(___double) || double.IsPositiveInfinity(___double))
            {
                return 0;
            }
            return ___double;
        }


        public double sampleRate
        {
            get
            {
                return ___audioContextSampleRate;
            }
        }

        public double currentTime
        {
            get { return ___currentTime; }
        }







        #region IPropertBox メンバ


   
        public object ___getPropertyByName(string ___name)
        {
            switch (___name)
            {
                case "destination":
                    return this.destination;
                case "sampleRate":
                      return ___audioContextSampleRate;
                case "onstatechange":
                    return this.___onstatechange;
                case "currentTime":
                    return ___currentTime;

                case "state":
                    return this.state;


                case "canvas":
                case "Canvas":
                    if (this.___parentElementWeakReference != null)
                    {
                        return this.___parentElementWeakReference.Target as CHtmlElement;
                    }
                    else
                    {
                        return null;
                    }

                default:
                    object propValue = null;
                    if (this.___properties.TryGetValue(___name, out propValue) == true)
                    {

                        return propValue;

                    }
                    if (this.___audioContextPrototypeInstanceWeakReference != null)
                    {
                        CHtmlAudioContext  __prototypeAudioContext = this.___audioContextPrototypeInstanceWeakReference.Target as CHtmlAudioContext;
                        if (__prototypeAudioContext != null)
                        {
                            if (__prototypeAudioContext.___properties.TryGetValue(___name, out propValue) == true)
                            {
                                return propValue;
                            }
                        }

                    }
                    break;
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("getPropertyValue for {0} {1} '{2}' failed", this.GetType(), this, ___name);
            }
            return null;
        }
        #region  constants
        

        #endregion
   
        public void ___setPropertyByName(string ___name, object val)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling setPropertyValue for {0} \'{1}\' {2} = {3}", this.GetType(), this, ___name, val);
            }
            switch (___name)
            {
                case "onstatechange":
                    this.___set_onstatechange(val);
                    break;
                case "state":
                    this.state = commonHTML.GetStringValue(val) ;
                    break;
                default:
                    bool ___ValueStored = false;
                    this.___properties[___name] = val;
                    ___ValueStored = true;

                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("setPropertyValue for {0} {1}  '{2}' = {3} Success : {4}", this.GetType(), this, ___name, val, ___ValueStored);
                    }
                    break;
            }
        }
   
        public void ___setPropertyByIndex(int ___index, object val)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("SetPropertyValueIndex for {0} \'{1}\' {2} = {3} failed", this.GetType(), this, ___index, val);
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
        public bool hasOwnProperty(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("entering {0}.hasOwnProperty({1})....", this, ___name);
            }
            return this.___hasPropertyByName(___name);
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

        public static CanvasContextModeType ___GetCanvasTypeFromName(string ___name)
        {
            switch (___name)
            {
                case "2D":
                case "2d":
                    return CanvasContextModeType.Canvas2D;
                case "3D":
                case "3d":
                    return CanvasContextModeType.WebGL;
                case "___SVG":
                case "___svg":
                    return CanvasContextModeType.SVG;
                case "webgl":
                case "WebGL":
                case "WebGl":
                case "WEBGL":
                case "experimental-webgl":
                case "webkit-webgl":
                case "moz-webgl":
                case "ms-webgl":
                case "khtml-webgl":
                case "o-webgl":
                    return CanvasContextModeType.WebGL;

            }
            return CanvasContextModeType.OtherType;
        }
        #endregion
        private object ___CanvasWindowLockingObject = new object();


        private void ___CanvasContextTimerDoNothing(object ___state)
        {
            if (___ContextTimerDelay == 0) {; }
            if (CONTEXT_TIMER_WATCH_INTERVAL == 50) {; }


        }

 
        /// <summary>
        /// Associates a WebGLFramebuffer object with the gl.FRAMEBUFFER bind target. 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="framebuffer"></param>
        public void bindFramebuffer(object ____target, object ____framebuffer)
        {

        }

        public void bindRenderbuffer(object ____target, object ____renderbuffer)
        {
        }
        public void blendEquationSeparate(object ____modeRGB, object ____modeAlpha)
        {

        }
        public void bufferSubData(object ____target, object ____offset, object ____data)
        {
        }

        public void blendFunc(object ___sfactor, object ___dfactor)
        {

        }

        public int checkFramebufferStatus(object ____target)
        {
            return 0;
        }
        public void copyTexImage2D(object ____target, object ____level, object ____format, object ____x, object ____y, object ____width, object ____height, object ____border)
        {

        }
        public void copyTexSubImage2D(object ____target, object ____level, object ____xoffset, object ____yoffset, object ____x, object ____y, object ____width, object ____height)
        {
        }

        /// <summary>
        /// Deletes a specific WebGLFramebuffer object. If you delete the currently bound framebuffer, object ____the default framebuffer will be bound. Deleting a framebuffer detaches all of its attachments.
        /// </summary>
        /// <param name="framebuffer"></param>
        public void deleteFramebuffer(object ____objectframebuffer)
        {
        }
        public void deleteProgram(object ___program)
        {

        }
        public void deleteShader(object ___shader)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: {0}.deleteShader({1})", this, ___shader);
            }
        }
        public bool depthMask(object ____flag)
        {
            return true;
        }
        public void depthRange(object ____zNear, object ____zFar)
        {

        }
        public void drawArrays(object ___mode, object ___first, object ___count)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("{0}.drawArrays({1}, {2}, {3})", this, ___mode, ___first, ___count);
            }
        }
        public void framebufferRenderbuffer(object ____target, object ____attachment, object ____renderbuffertarget, object ____renderbuffer)
        {

        }
        public void framebufferTexture2D(object ____target, object ____attachment, object ____textarget, object ____texture, object ____level)
        {

        }
        public void frontFace(object ____mode)
        {

        }
        public void generateMipmap(object ____target)
        {

        }
        public void getActiveAttrib(object ____program, object ____index)
        {

        }
        public CHtmlCanvasContextAttributes getContextAttributes()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling {0}.getContextAttributes()", this);
            }
            if (this.___contextAttributes == null)
            {
                this.___contextAttributes = new CHtmlCanvasContextAttributes();
                this.___contextAttributes.___canvasContextWeakReference = new WeakReference(this, false);
            }
            return this.___contextAttributes;
        }
        public int getError(object ____)
        {
            return 0;
        }

        public object getFramebufferAttachmentParameter(object ____target, object ____attachment, object ____pname)
        {
            return null;
        }
        public object getParameter(object ____pname)
        {
            return null;
        }


        #region AudioContext Related APIs
        /// <summary>
        /// The onstatechange property of the AudioContext interface defines an event handler function to be called when the statechange event fires: this occurs when the audio context's state changes. 
        /// </summary>
        internal object ___onstatechange = null;
        public object onstatechange
        {
            get { return this.___onstatechange; }
            set { this.___set_onstatechange(value); }
        }
        internal void ___set_onstatechange(object val)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("setting {0}.onstatechange({1})", this, val);
            }
            this.___onstatechange = val;
        }
        public CHtmlAudioPannerNode createPanner()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling {0}.createPanner()", this);
            }
            CHtmlAudioPannerNode __audioPanner = new CHtmlAudioPannerNode();
            __audioPanner.___ownerContextWeakReference = new WeakReference(this, false);
            return __audioPanner;
        }

        public CHtmlAudioOscillatorNode createOscillator()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling {0}.createOscillator()", this);
            }
            CHtmlAudioOscillatorNode __osililator = new CHtmlAudioOscillatorNode();
            __osililator.___ownerContextWeakReference = new WeakReference(this, false);
            return __osililator;
        }
        public CHtmlAudioAnalyserNode createAnalyser()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling {0}.createAnalyser()", this);
            }
            CHtmlAudioAnalyserNode ___audioAnalyser = new CHtmlAudioAnalyserNode();
            ___audioAnalyser.___ownerContextWeakReference = new WeakReference(this, false);
            return ___audioAnalyser;
        }


        public object createBuffer()
        {
            return this.___createBuffer_Inner(null);
        }

        public object createBuffer(object ___p1)
        {
            return this.___createBuffer_Inner(new object[] { ___p1 });
        }
        public object createBuffer(object ___p1, object ___p2)
        {
            return this.___createBuffer_Inner(new object[] { ___p1, ___p2 });
        }
        public object createBuffer(object ___p1, object ___p2, object ___p3)
        {
            return this.___createBuffer_Inner(new object[] { ___p1, ___p2, ___p3 });
        }
        public object createBuffer(object ___p1, object ___p2, object ___p3, object ___p4)
        {
            return this.___createBuffer_Inner(new object[] { ___p1, ___p2, ___p3, ___p4 });
        }
        public object createBuffer(object ___p1, object ___p2, object ___p3, object ___p4, object ___p5)
        {
            return this.___createBuffer_Inner(new object[] { ___p1, ___p2, ___p3, ___p4, ___p5 });
        }
        public object createBuffer(object ___p1, object ___p2, object ___p3, object ___p4, object ___p5, object ___p6)
        {
            return this.___createBuffer_Inner(new object[] { ___p1, ___p2, ___p3, ___p4, ___p5, ___p6 });
        }
        public object createBuffer(object ___p1, object ___p2, object ___p3, object ___p4, object ___p5, object ___p6, object ___p7)
        {
            return this.___createBuffer_Inner(new object[] { ___p1, ___p2, ___p3, ___p4, ___p5, ___p6, ___p7 });
        }
        private object ___createBuffer_Inner(object[] ___args)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("calling {0}.createBuffer()", this);
            }
            object ____returnBuffer = null;
            if (this.___CanvasContextModeType == CanvasContextModeType.AudioContext)
            {

                CHtmlAudioBuffer ___audioBuffer = new CHtmlAudioBuffer();
                // audioCtx.createBuffer(1, 22050, 22050);
                //                                  (numberOfChannels, Length, sampleRate)
                if (___args != null && ___args.Length == 3)
                {
                    ___audioBuffer.___numberOfChannels = commonData.GetDoubleFromObject(___args[0], 0);
                    int numChan = (int)___audioBuffer.___numberOfChannels;
                    ___audioBuffer.___channelData = new List<CHtmlNativeArray>();
                    for(int i = 0; i < numChan; i ++)
                    {
                        ___audioBuffer.___channelData[i].___arrayType = CHtmlNumericArrayType.Float32Array;
                    }
                    ___audioBuffer.___length = commonData.GetDoubleFromObject(___args[1], 0);
                    ___audioBuffer.___sampleRate = commonData.GetDoubleFromObject(___args[2], 0);
                }
                ____returnBuffer = ___audioBuffer;
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("{0}.createBuffer() returns {1}", this, ____returnBuffer);
            }
            return ____returnBuffer;
        }
        public void resume()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("calling {0}.resume()", this);
            }
            this.___state = "running";
        }
        public void suspend()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("calling {0}.suspend()", this);
            }
            this.___state = "suspended";
        }

        public void close()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("calling {0}.close()", this);
            }
            this.___state = "suspended";
        }

        /// <summary>
        /// destination is normally used for AudioContext Destination Device Node
        /// </summary>
        public CHtmlAudioDestinationNode destination
        {
            get
            {
                if (this.___CanvasContextModeType == CanvasContextModeType.AudioContext)
                {

                        if (this.___audioDestinationNode == null)
                        {
                            this.___audioDestinationNode = new CHtmlAudioDestinationNode();
                            this.___audioDestinationNode.___ownerContextWeakReference = new WeakReference(this, false);
                        }
                        return this.___audioDestinationNode;
                }
                return this.___audioDestinationNode; 
            }
            set
            {
                this.___audioDestinationNode = value as CHtmlAudioDestinationNode;
            }
        }

        public CHtmlAudioScriptProcessorNode createScriptProcessor(double pbufferSize, double pnumberOfInputChannels, double pnumberOfOutputChannels)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling {0}.createScriptProcessor()", this);
            }
            CHtmlAudioScriptProcessorNode ___audioScriptProcessor = new CHtmlAudioScriptProcessorNode();
            ___audioScriptProcessor.___bufferSize = pbufferSize;
            ___audioScriptProcessor.___numberOfInputChannels = pnumberOfInputChannels;
            ___audioScriptProcessor.___numberOfOutputChannels = pnumberOfOutputChannels;
            ___audioScriptProcessor.___ownerContextWeakReference = new WeakReference(this, false);
            return ___audioScriptProcessor;
        }

        public CHtmlAudioGainNode createGain()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling {0}.createGain()", this);
            }
            CHtmlAudioGainNode ___gainNode = new CHtmlAudioGainNode();
            ___gainNode.___ownerContextWeakReference = new WeakReference(this, false);
            return ___gainNode;
        }
        public CHtmlAudioBufferSourceNode createBufferSource()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling {0}.createBufferSource()", this);
            }
            CHtmlAudioBufferSourceNode ___audioBufferSource = new CHtmlAudioBufferSourceNode();
            ___audioBufferSource.___ownerCanvasContextWeakReference = new WeakReference(this, false);
            return ___audioBufferSource;
        }
        public CHtmlAudioChannelMergerNode createChannelMerger(double ___numOfInputs)
        {
            return this.___createChannenelMerger(___numOfInputs);
        }
        public CHtmlAudioChannelMergerNode createChannelMergerNode()
        {
            return this.___createChannenelMerger(0);
        }
        private CHtmlAudioChannelMergerNode ___createChannenelMerger(double ___numOfInputs)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling {0}.createChannelMerger()", this);
            }
            CHtmlAudioChannelMergerNode  ___audioChannelMerger = new CHtmlAudioChannelMergerNode();
            ___audioChannelMerger.___numberofinputs = ___numOfInputs;
            ___audioChannelMerger.___ownerContextWeakReference = new WeakReference(this, false);
            return ___audioChannelMerger;
        }
        private object ___decodeAudioDataCurrerntData =null;
        /// <summary>
        /// Result of decodeAudioData
        /// </summary>
        private object ___decodeAudioDataDecodedData = null;
        private object ___decodedAudioDataFunctionObject = null;
        private object ___decodedAudioDataFunctionErrObject = null;
        /// <summary>
        /// Classic way
        /// </summary>
        /// <param name="___objAudioData"></param>
        /// <param name="___objFunction"></param>
        public object  decodeAudioData(object ___objAudioData, object ___objFunction)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling {0}.decodeAudioData({1}, {2}) [Classic Way]", this, ___objAudioData, ___objFunction );
            }

            ___decodeAudioDataCurrerntData = ___objAudioData;
            ___decodedAudioDataFunctionObject = ___objFunction;
            ___decodeAudoDataInner();
            return null;
        }



        /// <summary>
        /// Classic way
        /// </summary>
        /// <param name="___objAudioData"></param>
        /// <param name="___objFunction"></param>
        public object decodeAudioData(object ___objAudioData, object ___objFunction, object ___objErrorCallBack)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling {0}.decodeAudioData({1}, {2}, {3}) [Classic Way]", this, ___objAudioData, ___objFunction, ___objErrorCallBack);
            }
            if (___decodeAudioDataCurrerntData != null)
            {
                ___decodeAudioDataCurrerntData = null;
            }
            ___decodeAudioDataCurrerntData = ___objAudioData;
            ___decodedAudioDataFunctionObject = ___objFunction;
            ___decodedAudioDataFunctionErrObject = ___objErrorCallBack;
            ___decodeAudoDataInner();
            return null;
        }
        internal void ___decodeAudoDataInner()
        {
            if(this.___MultiversalWindowWeakReference != null)
            {
                // Thread Versioin
                System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(___decodeAudioDataInnerAsync));
                thread.Start();
            } else
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                {
                   commonLog.LogEntry("strange AudioContext owner window reference is not assigned. Skipping...");
                }
            }
        }
        /// <summary>
        /// Process decodeAudio Asynchonously
        /// </summary>
        internal void ___decodeAudioDataInnerAsync()
        {
            // ================================================================================================
            // decodeAudioData Actual Data Processing Step here. Skip it for now
            // ================================================================================================
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: decodeAudioData Data Processing Part. Skipping...");
            }

            this.___decodeAudioDataDecodedData = this.___decodeAudioDataCurrerntData;
            // ================================================================================================
            // decodeAudioData Function Execute Section
            // ================================================================================================
            if (this.___decodedAudioDataFunctionObject !=null)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                {
                   commonLog.LogEntry("decodeAudioData Function Process Begin...");
                }
                CHtmlMultiversalWindow  multiversal = this.___MultiversalWindowWeakReference.Target as CHtmlMultiversalWindow;
                if (multiversal != null)
                {
                    multiversal.___execute___functionObject("AudioContext.decodeAudioData()", this.___decodedAudioDataFunctionObject, new object[] { this.___decodeAudioDataDecodedData });
                       
                }
            }
        }
        /// <summary>
        /// ES6 Way
        /// </summary>
        /// <param name="___objAudioData"></param>
        /// <returns>PromiseObject</returns>
        public CHtmlPromisingFunctionObject decodeAudioData(object ___objAudioData)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling {0}.decodeAudioData({1}, {2}) [ES6 Way]", this, ___objAudioData);
            }
            if (___decodeAudioDataCurrerntData != null)
            {
                ___decodeAudioDataCurrerntData = null;
            }
            ___decodeAudioDataCurrerntData = ___objAudioData;
            CHtmlPromisingFunctionObject ___promise = new CHtmlPromisingFunctionObject();
            ___promise.____functionOrigin = "decodeAudioData";
            ___promise.___originalObjectWeakReference = new WeakReference(this, false);
            ___promise.___param1WeakReference = new WeakReference(this.___decodeAudioDataCurrerntData, false);
            return ___promise;
        }
        #endregion

        public bool isPrototypeOf(object ___protoObject)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling {0}.isPrototpyeOf('{1}') ", this, ___protoObject);
            }
            switch (commonHTML.isPrototypeOf_precheck(this, ___protoObject))
            {
                case 0:
                default:
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("TODO:  {0}.isPrototpyeOf('{1}') test needs more test. returns true for now... ", this, ___protoObject);
                    }
                    break;
                case 1:
                    return true;
                case 2:
                    return false;
            }
            return true;
        }
        public new  IMutilversalObjectType multiversalClassType
        {
            get
            {
                switch (this.___CanvasContextModeType)
                {
                    case CanvasContextModeType.Canvas2D:
                    case CanvasContextModeType.Canvas2DPrototype:
                        return IMutilversalObjectType.CanvasRenderingContext2D;
                    case  CanvasContextModeType.WebGL:
                    case CanvasContextModeType.WebGLPrototype:
                        return IMutilversalObjectType.WebGLRenderingContext;
                    case CanvasContextModeType.AudioContext:
                        return IMutilversalObjectType.AudioContext;
                    case CanvasContextModeType.CanvasAudioContextPrototype:
                        return IMutilversalObjectType.AudioContext;
                }
                return IMutilversalObjectType.CanvasRenderingContext2D;
            }
        }
    }
}
