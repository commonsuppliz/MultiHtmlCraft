using System;
using System.Collections;
#if WINDOWS
using System.Drawing;
using System.Drawing.Drawing2D;
#else
using System.Drawing;
#endif

using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.IO;
using MultiHtmlCraft.Interfaces;
using System.Runtime.CompilerServices;
using MultiHtmlCraft.Interfaces;
using System.Dynamic;
using System.Linq.Expressions;
using System.Collections.Generic;
using Interfaces;
using System.Xml.Linq;

using MultiHtmlCraft.Core;
using System.Reflection;

namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// Canvas Context
    /// </summary>
    
    public class CHtmlWebGLRenderingContext: CHtmlNode, IDynamicMetaObjectProvider, ICommonObjectInterface, System.IDisposable
    {
        private System.Collections.Generic.Stack<CHtmlCanvasState> ___CanvasStateStack = null;
        internal System.WeakReference ___CanvasPrototypeInstanceWeakReference = null;
        internal CHtmlCanvasContextAttributes ___contextAttributes = null;
        internal System.WeakReference ___MultiversalWindowWeakReference = null;
        internal static System.Collections.Generic.Dictionary<string,CHtmlFontInfo> ___canvasCHtmlFontInfoDictionary = new System.Collections.Generic.Dictionary<string,CHtmlFontInfo>();
        private static object ___canvasCHtmlFontInfoLockingObject = new object();
        private const int ___canvasCHtmlFontInfoMaximumEntries = 10000;
        private const double ___audioContextSampleRate = 48000;

        internal bool ___needAvoidToCallCanvasActivityIntoDocument = false;
        /// <summary>
        /// Property names for Context Attirbutes
        /// </summary>
        internal static string[] ____Context_Attribute_Name_Array = new string[] { "alpha", "depth", "stencil", "antialias", "premultipliedAlpha", "preserveDrawingBuffer" };



        public CHtmlWebGLRenderingContext()
        {

            //this.___PointFList = new System.Collections.Generic.List<System.Drawing.PointF>();
            this.___CanvasStateStack = new System.Collections.Generic.Stack<CHtmlCanvasState>();


            this.___CanvasContextCreatedTime = DateTime.Now;



            this.___CanvasInstructionsList = new System.Collections.Generic.List<CHtmlCanvasContextInstruction>();


        }
        public CHtmlWebGLRenderingContext(bool isPrototype)
        {
            this.___properties = new System.Collections.Generic.Dictionary<string, object>(System.StringComparer.OrdinalIgnoreCase);

            this.___CanvasInstructionsList = new System.Collections.Generic.List<CHtmlCanvasContextInstruction>();

        }

        ~CHtmlWebGLRenderingContext()
        {

            this.___IsDisposing = true;
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
                if (this.___IsPrototype == false)
                {
                   commonLog.LogEntry("Canvas Context Fializing ...");
                }
            }


            this.___cleanUp();
        }
        private object ___ContextTimerLockingObject = new object();
        private int ___ContextTimerDelay = 50;
        private const int MAX_CONTEXT_TIMER_DELAY = 15000; // 15 seconds
        private int CONTEXT_TIMER_WATCH_INTERVAL = 50;


 
        /// <summary>
        /// If the background color ___hasInner been assigned or not.
        /// </summary>
        internal bool ___IsCanvasBackgroundSysColorSpecified = false;

        /// <summary>
        /// If backgroundColorSearch Tried once
        /// </summary>
        internal bool ___IsCanvasBackgroundSysColorSearchAttempted = false;
        internal ColorSpec ___CanvasBackgroundSysColor = ColorSpec.Transparent;

        internal ColorSpec ___CanvasForegroundSysColor = ColorSpec.Black;

        internal PointFSpec ___CanvasTranslatePoint = new PointFSpec(0, 0);
        internal static PointFSpec PointNaN = new PointFSpec(0, 0);
        internal float ___CanvasRotateAngle = 0;

        internal System.Collections.Generic.List<CHtmlCanvasContextInstruction> ___CanvasInstructionsList;

        internal int ___CanvasInstructionSavedPoint = 0;




        private System.IntPtr ___ParentWindowControlHandle = IntPtr.Zero;
        private DateTime ___CanvasContextCreatedTime = DateTime.Now;
        // private DateTime ___CanvasContextLatestDrawTime = DateTime.Now;
        private string ___ContextMode = null;
        internal CanvasContextModeType ___CanvasContextModeType = CanvasContextModeType.None;
        internal System.WeakReference ___parentElementWeakReference = null;
        internal int ___parentElementOID = -1;
        internal System.WeakReference ___ownerDocumentWeakReference = null;


        internal double ___CanvasWidth = 300;
        internal double ___CanvasHeight = 3000;
        #region ContextAttributes

        internal bool ___Context_Attributes_alpha = true;
        internal bool ___Context_Attributes_depth = true;
        internal bool ___Context_Attributes_stencil = false;
        internal bool ___Context_Attributes_antialias = true;
        internal bool ___Context_Attributes_premultipliedAlpha = true;
        internal bool ___Context_Attributes_preserveDrawingBuffer = true;
        internal bool ___CanvasImageSmoothingEnabled = true;
        internal double ___CanvasBackingStorePixelRatio = 1;



        #endregion
        /// <summary>
        /// Number of Context Object Finalized Count
        /// 
        /// </summary>




        private double ___BackingStorePixelRatio = 1.0;
        internal object ___contextFillStyleAsObject = "black";
        /// <summary>
        /// Object is created last time
        /// </summary>
        private object ___contextFillStylePriorAsObject = null;

        private bool ___IsGraphicsPathOpen = false;
        /// <summary>
        /// ___currentPointF
        /// if not set it is (float.NaN, floatNaN)
        /// </summary>
        private PointFSpec ___currentPointF = new PointFSpec(0, 0);
        private bool ___isMoveToPointNeedsToSetToPath = false;
        public bool ___IsDisposing = false;
        // private bool ___IsPathClosed = false;
        /// <summary>
        /// TextureBrush Base Image (will be cloned).
        /// </summary>



        public string fillStyle
        {
            set { this.___contextFillStyleAsObject = value;
         
 
            }
            get { return commonHTML.GetStringValue(this.___contextFillStyleAsObject); }
        }

   

        internal object ___contextDestination = null;


        private object ___contextShadowColorAsObject = null;



        private double ___contextShadowBlur = 0;
        public double shadowBlur
        {
            get { return this.___contextShadowBlur; }
            set { this.___contextShadowBlur = value; }
        }
        public bool msImageSmoothingEnabled
        {
            get
            {
                return this.___CanvasImageSmoothingEnabled;
            }
        }
        public bool webkitImageSmoothingEnabled
        {
            get
            {
                return this.___CanvasImageSmoothingEnabled;
            }
        }
        public bool mozImageSmoothingEnabled
        {
            get
            {
                return this.___CanvasImageSmoothingEnabled;
            }
        }
        public bool imageSmoothingEnabled
        {
            get
            {
                return this.___CanvasImageSmoothingEnabled;
            }
        }
        public double webkitBackingStorePixelRatio
        {
            get { return this.___CanvasBackingStorePixelRatio; }
        }
        public double backingStorePixelRatio
        {
            get { return this.___CanvasBackingStorePixelRatio; }
        }
        public double msBackingStorePixelRatio
        {
            get { return this.___CanvasBackingStorePixelRatio; }
        }
        public double mosBackingStorePixelRatio
        {
            get { return this.___CanvasBackingStorePixelRatio; }
        }
        public double oBackingStorePixelRatio
        {
            get { return this.___CanvasBackingStorePixelRatio; }
        }
        private double ___contextShadowOffsetX = 0;
        public double shadowOffsetX
        {
            get { return this.___contextShadowOffsetX; }
            set { this.___contextShadowOffsetX = value; }
        }

        private double ___contextShadowOffsetY = 0;
        public double shadowOffsetY
        {
            get { return this.___contextShadowOffsetY; }
            set { this.___contextShadowOffsetY = value; }
        }

        private object ___contextLineCap = null;
        public object LineCap
        {
            set { this.___contextLineCap = value; }
            get { return this.___contextLineCap; }
        }
        public object lineCap
        {
            set { this.___contextLineCap = value; }
            get { return this.___contextLineCap; }
        }

        private object ___contextLineJoin = null;
        public object lineJoin
        {
            set { this.___contextLineJoin = value; }
            get { return this.___contextLineJoin; }
        }
        public object LineJoin
        {
            set { this.___contextLineJoin = value; }
            get { return this.___contextLineJoin; }
        }


        private double ___contextLineWidth = 1;

        public double LineWidth
        {
            get { return this.___contextLineWidth; }
            set { this.___contextLineWidth = value; }
        }

        public double lineWidth
        {
            get { return this.___contextLineWidth; }
            set { this.___contextLineWidth = value; }
        }


        private double ___contextMiterLimit = 0;

        public double miterLimit
        {
            get { return this.___contextMiterLimit; }
            set { this.___contextMiterLimit = value; }
        }
        public double MiterLimit
        {
            get { return this.___contextMiterLimit; }
            set { this.___contextMiterLimit = value; }
        }
        /// <summary>
        /// Context Attribtes value
        /// </summary>
        public bool alpha
        {
            get { return this.___Context_Attributes_alpha; }
            set { this.___Context_Attributes_alpha = value; }
        }
        /// <summary>
        /// Context Attribtes value
        /// </summary>
        public bool depth
        {
            get { return this.___Context_Attributes_depth; }
            set { this.___Context_Attributes_depth = value; }
        }
        /// <summary>
        /// Context Attribtes value
        /// </summary>
        public bool stencil
        {
            get { return this.___Context_Attributes_stencil; }
            set { this.___Context_Attributes_stencil = value; }
        }
        /// <summary>
        /// Context Attribtes value
        /// </summary>
        public bool antialias
        {
            get { return this.___Context_Attributes_antialias; }
            set { this.___Context_Attributes_antialias = value; }
        }
        /// <summary>
        /// Context Attribtes value
        /// </summary>
        public bool premultipliedAlpha
        {
            get { return this.___Context_Attributes_premultipliedAlpha; }
            set { this.___Context_Attributes_premultipliedAlpha = value; }
        }
        /// <summary>
        /// Context Attribtes value
        /// </summary>
        public bool preserveDrawingBuffer
        {
            get { return this.___Context_Attributes_preserveDrawingBuffer; }
            set { this.___Context_Attributes_preserveDrawingBuffer = value; }
        }



        private object ___contextFontAsObject = (object)"";
        private string ___contextFontAsString = null;
        private CHtmlFontInfo ___contextCHtmlFontInfo = null;
        /// <summary>
        /// Canvas font. Valid Valies should be the same as Css FontSpec Value.
        /// ex.  'italic 400 12px/2 Unknown FontSpec, sans-serif';
        /// </summary>
		public object font
        {
            set {
                this.___setContextFont(value);
            }
            get { return this.___contextFontAsObject; }

        }
        private void ___setContextFont(object value)
        {
            this.___contextFontAsObject = value;
            try
            {
                if (value is string)
                {
                    string ___strFont = commonHTML.GetStringValue(value);
                    if (string.IsNullOrEmpty(___strFont) == false && string.CompareOrdinal(___strFont, this.___contextFontAsString) == 0 && (this.___contextCHtmlFontInfo != null))
                    {
                        // same font
                        return;
                    }

                    if (string.IsNullOrEmpty(___strFont) == false)
                    {

                       CHtmlFontInfo ___cachedFont = null;
                        if (___canvasCHtmlFontInfoDictionary.TryGetValue(___strFont, out ___cachedFont))
                        {
                            this.___contextCHtmlFontInfo = ___cachedFont;
                            this.___contextFontAsString = ___strFont;
                            return;
                        }
                        else
                        {

                           CHtmlFontInfo __CHtmlFontInfo = new CHtmlFontInfo();
                            commonHTML.setCSSFontStyleIntoStyleSheetOrCHtmlFontInfo(null, __CHtmlFontInfo, ___strFont);
                            System.Drawing.Color ___tmpColor = System.Drawing.Color.Black;
                            this.___contextCHtmlFontInfo = __CHtmlFontInfo;
                            this.___contextFontAsString = ___strFont;
                            bool ___CHtmlFontInfoLocked = false;
                            try
                            {
      
                                        CHtmlWebGLRenderingContext.___canvasCHtmlFontInfoDictionary.Clear();
                                    
                                
                            }
                            finally
                            {
                                if (___CHtmlFontInfoLocked)
                                {
                                    System.Threading.Monitor.Exit(CHtmlWebGLRenderingContext.___canvasCHtmlFontInfoLockingObject);
                                }
                            }

                            return;
                        }
                    }
                    else

                    {

                        this.___contextCHtmlFontInfo = new CHtmlFontInfo("Monospace", 10);
                        this.___contextFontAsString = null;
                    }
                } else

                {

                    this.___contextCHtmlFontInfo = new CHtmlFontInfo("Monospace", 10);
                    this.___contextFontAsString = null;
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("TODO: CHtmlCanvasContext.___setContextFont() for non string...");
                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                {
                   commonLog.LogEntry("CHtmlCanvasContext.___setContextFont() errror : ", ex);
                }


            }
        }

        private object ___contextTextAlignAsObject = null;

        public object textAlign
        {
            get { return this.___contextTextAlignAsObject; }
            set { this.___contextTextAlignAsObject = value; }
        }

        private object ___contextTextBaseline = null;

        public object textBaseLine
        {
            get { return this.___contextTextBaseline; }
            set { this.___contextTextBaseline = value; }
        }
        internal object ___contextglobalCompositeOperationAsObject = null;
        internal CHtmlCanvasContextGlobalCompositionType ___contextGlobalCompositionMode = CHtmlCanvasContextGlobalCompositionType.source_over;
        public object globalCompositeOperation
        {
            get { return this.___contextglobalCompositeOperationAsObject; }
            set { this.___setGlobalCompositeOperationValue(value); }
        }
        /// <summary>
        /// assuming paramater is string now...
        /// </summary>
        /// <param name="val"></param>
        public void ___setGlobalCompositeOperationValue(object val)
        {
            this.___contextglobalCompositeOperationAsObject = val;
            string strGlobalCompositeOperation = commonHTML.GetStringValue(this.___contextglobalCompositeOperationAsObject);
            if (string.IsNullOrEmpty(strGlobalCompositeOperation) == false)
            {
                switch (strGlobalCompositeOperation)
                {
                    case "source-over"://   Default.Displays the source image over the destination image  
                        ___contextGlobalCompositionMode = CHtmlCanvasContextGlobalCompositionType.source_over;
                        break;
                    case "source-atop":// Displays the source image on top of the destination image. The part of the source image that is outside the destination image is not shown 
                        ___contextGlobalCompositionMode = CHtmlCanvasContextGlobalCompositionType.source_atop;
                        break;
                    case "source-in":	//Displays the source image in to the destination image. Only the part of the source image that is INSIDE the destination image is shown, and the destination image is transparent
                        ___contextGlobalCompositionMode = CHtmlCanvasContextGlobalCompositionType.source_in;
                        break;
                    case "source-out": //	Displays the source image out of the destination image. Only the part of the source image that is OUTSIDE the destination image is shown, and the destination image is transparent  
                        ___contextGlobalCompositionMode = CHtmlCanvasContextGlobalCompositionType.source_out;
                        break;
                    case "destination-over":  //  Displays the destination image over the source image
                        ___contextGlobalCompositionMode = CHtmlCanvasContextGlobalCompositionType.destination_over;
                        break;
                    case "destination-atop": //    Displays the destination image on top of the source image. The part of the destination image that is outside the source image is not shown 
                        ___contextGlobalCompositionMode = CHtmlCanvasContextGlobalCompositionType.destination_atop;
                        break;
                    case "destination-in"://	Displays the destination image in to the source image. Only the part of the destination image that is INSIDE the source image is shown, and the source image is transparent Play it »
                    case "destination-out"://	Displays the destination image out of the source image. Only the part of the destination image that is OUTSIDE the source image is shown, and the source image is transparent   Play it »
                        ___contextGlobalCompositionMode = CHtmlCanvasContextGlobalCompositionType.destination_out;
                        break;
                    case "lighter": //Displays the source image + the destination image   Play it »
                        ___contextGlobalCompositionMode = CHtmlCanvasContextGlobalCompositionType.lighter;
                        break;
                    case "copy":// Displays the source image.The destination image is ignored Play it »
                        ___contextGlobalCompositionMode = CHtmlCanvasContextGlobalCompositionType.copy;
                        break;
                    case "xor":
                        ___contextGlobalCompositionMode = CHtmlCanvasContextGlobalCompositionType.xor;
                        break;
                }
            }
        }


        /// <summary>
        /// Global Alpha is default 1
        /// </summary>
		private double ___contextGlobalAlpha = 1;
        private int ___contextGlobalAlphaAsInt255 = -1;
        public double globalAlpha
        {
            get { return this.___contextGlobalAlpha; }
            set { this.___contextGlobalAlpha = value; }
        }


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
                   commonLog.LogEntry("Canvas Context Disposing ...");
                }
            }
            this.___IsDisposing = true;
            this.___cleanUp();
            GC.SuppressFinalize(this);
        }



        #endregion

        private void ___cleanUp()
        {
            

            if (this.___contextFillStylePriorAsObject != null)
            {
                this.___contextFillStylePriorAsObject = null;
            }
            
  

            if (this.___parentElementWeakReference != null)
            {
                this.___parentElementWeakReference = null;
            }
            if (this.___contextShadowColorAsObject != null)
            {
                this.___contextShadowColorAsObject = null;
            }

            if (this.___contextTextAlignAsObject != null)
            {
                this.___contextTextAlignAsObject = null;
            }
            if (this.___contextTextBaseline != null)
            {
                this.___contextTextBaseline = null;
            }
            if (this.___contextFillStyleAsObject != null)
            {
                this.___contextFillStyleAsObject = null;
            }
            if (this.___contextFontAsObject != null)
            {
                this.___contextFontAsObject = null;
            }
            if (this.___contextLineCap != null)
            {
                ___contextLineCap = null;
            }
            if (this.___contextLineJoin != null)
            {
                this.___contextLineJoin = null;
            }
 

            if (this.___contextCHtmlFontInfo != null)
            {
                this.___contextCHtmlFontInfo = null;
            }


            this.___ContextTimerLockingObject = null;
            if (this.___CanvasStateStack != null)
            {

                this.___CanvasStateStack = null;
            }
            if (this.___CanvasInstructionsList != null)
            {

                this.___CanvasInstructionsList = null;
            }
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
        private const double MIN_GRADIENT_WIDTH = 300;
        public CHtmlCanvasContextExtenstionObject createLinearGradient(double x0, double y0, double x1, double y1)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("entering {0}.createLinearGradient({1},{2},{3},{4})", this, x0, y0, x1, y1);
            }
            CHtmlCanvasContextExtenstionObject __gradient = new CHtmlCanvasContextExtenstionObject(CanvasExtentionObjectType.LinerGradient);

            __gradient.___ownerCanvasContextWeakReference = new WeakReference(this, false);

            RectangleF gradientRect = new RectangleF((float)x0, (float)y0, (float)x1, (float)y1);
            __gradient.___baseRectangle1 = gradientRect;
            return __gradient;
        }
        public CHtmlCanvasContextExtenstionObject createLinearGradient(double x0, double y0, double x1, double y1, double p5)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("entering {0}.createLinearGradient({1},{2},{3},{4},{5})", this, x0, y0, x1, y1, p5);
            }
            CHtmlCanvasContextExtenstionObject __gradient = new CHtmlCanvasContextExtenstionObject(CanvasExtentionObjectType.LinerGradient);

            __gradient.___ownerCanvasContextWeakReference = new WeakReference(this, false);

            RectangleF gradientRect = new RectangleF((float)x0, (float)y0, (float)x1, (float)y1);
            __gradient.___baseRectangle1 = gradientRect;
            return __gradient;
        }
        public CHtmlCanvasContextExtenstionObject createLinearGradient(double x0, double y0, double x1, double y1, double p5, double p6)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("entering {0}.createLinearGradient({1},{2},{3},{4},{5},{6})", this, x0, y0, x1, y1, p5, p6);
            }
            CHtmlCanvasContextExtenstionObject __gradient = new CHtmlCanvasContextExtenstionObject(CanvasExtentionObjectType.LinerGradient);

            __gradient.___ownerCanvasContextWeakReference = new WeakReference(this, false);

            RectangleF gradientRect = new RectangleF((float)x0, (float)y0, (float)x1, (float)y1);
            __gradient.___baseRectangle1 = gradientRect;
            return __gradient;
        }
        /// <summary>
        /// Just Buggy browser support
        /// </summary>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="p5"></param>
        /// <param name="obj_p6"></param>
        /// <returns></returns>
        public CHtmlCanvasContextExtenstionObject createLinearGradient(double x0, double y0, double x1, double y1, double p5, object obj_p6)
        {
            return this.createLinearGradient(x0, y0, x1, y1, p5, commonData.GetDoubleFromObject(obj_p6, 0));
        }
     


        /// <summary>
        /// The WebGLRenderingContext.getError() method of the WebGL API returns error information.
        /// </summary>
        /// <returns>0: no error</returns>
        public object getError()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("entering {0}.getError()", this);
            }
            return 0;
        }
        private CHtmlCanvas2DImageData ___createImageDataInner(double w, double h)
        {
            CHtmlCanvas2DImageData ___imageDataNew = new CHtmlCanvas2DImageData();
            CHtmlNativeArray _byteArray = new CHtmlNativeArray(CHtmlNumericArrayType.Uint8ClampedArray);

            _byteArray.___width = w;
            _byteArray.___height = h;
            int byteLength = (int)(w * h) * 4;
            _byteArray.___byteArray = new byte[byteLength];
            _byteArray.___arrayLength = byteLength;
            ___imageDataNew.___width = w;
            ___imageDataNew.___height = h;
            ___imageDataNew.___data = _byteArray;
            return ___imageDataNew;
        }
        /// <summary>
        /// Creates blank image data of specified width, and height
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
		public ICHtmlCanvas2DImageData createImageData(object p1Object, object p2Object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("entering {0}.getImageDataInner({1}, {2})", this, p1Object, p2Object);
            }
            double p1 = 0;
            if (p1Object != null)
            {
                p1 = (float)___ConvertNaNInfiniteToZero(commonData.GetDoubleFromObject(p1Object, 0));
            }
            double p2 = 0;
            if (p2Object != null)
            {
                p2 = (float)___ConvertNaNInfiniteToZero(commonData.GetDoubleFromObject(p2Object, 0));
            }
            if (p1 <= 0)
            {
                p1 = 1;
            }
            if (p2 <= 0)
            {
                p2 = p1;
            }
            return this.___createImageDataInner(p1, p2);
   
        }
        /// <summary>
        /// createImageData() with one parameter is image element or etc.
        /// </summary>
        /// <param name="imageObject"></param>
        /// <returns></returns>
        public CHtmlCanvas2DImageData createImageData(object imageObject)
        {
            CHtmlCanvas2DImageData _ImageData = new CHtmlCanvas2DImageData();
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("createImageData with 1 parameter: {0}", imageObject);
            }
            try
            {
                if (commonHTML.isClrNumeric(imageObject) )
                {
                    double doubleValue = commonData.GetDoubleFromObject(imageObject, 0);
                    return this.___createImageDataInner(doubleValue, doubleValue);
                }
                else
                {
                    throw new NotSupportedException();

                }
            } catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                {
                   commonLog.LogEntry("Error  createImageData unkonwn data type ", ex);
                }

            }
            return this.___createImageDataInner(100, 100);
        }

        public ICHtmlCanvas2DImageData getImageDataHD(object p1, object p2, object p3, object p4)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("calling getImageDataHD()...", this);
            }
            return this.getImageDataInner(p1, p2, p3, p4);
        }
        public ICHtmlCanvas2DImageData getImageData(object p1, object p2, object p3, object p4)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("calling getImageData()...", this);
            }
            return this.getImageDataInner(p1, p2, p3, p4);
        }
        private ICHtmlCanvas2DImageData getImageDataInner(object p1, object p2, object p3, object p4)
        {
            CHtmlCanvas2DImageData imageDateResult = new CHtmlCanvas2DImageData();
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("entering {0}.getImageDataH({1}, {2}, {3}, {4})...", this, p1, p2, p3, p4);
            }
            System.Drawing.Graphics ___grAdhocContext = null;
            CHtmlNativeArray _byteArrayList = new CHtmlNativeArray(CHtmlNumericArrayType.Uint8ClampedArray);
            double ___x1 = 0;
            double ___y1 = 0;
            double ___width1 = 0;
            double ___height1 = 0;
            Bitmap targetBmp = null;
            Image srcImage = null;
            try
            {
                if (p1 != null)
                {
                    ___x1 = ___ConvertNaNInfiniteToZero(commonData.GetDoubleFromObject(p1, 0));
                }
                if (p2 != null)
                {
                    ___y1 = ___ConvertNaNInfiniteToZero(commonData.GetDoubleFromObject(p2, 0));
                }
                if (p3 != null)
                {
                    ___width1 = ___ConvertNaNInfiniteToZero(commonData.GetDoubleFromObject(p3, 0));
                }
                if (p4 != null)
                {
                    ___height1 = ___ConvertNaNInfiniteToZero(commonData.GetDoubleFromObject(p4, 0));
                }


                _byteArrayList.___width = ___width1;
                _byteArrayList.___height = ___height1;

                if (this.___CanvasContextModeType == CanvasContextModeType.Canvas2D || this.___CanvasContextModeType == CanvasContextModeType.SVG)
                {
                    Rectangle section = new Rectangle((int)___x1, (int)___y1, (int)___width1, (int)___height1);

                    if (___width1 < 1)
                    {
                        ___width1 = 1;
                    }
                    if (___height1 < 1)
                    {
                        ___height1 = 1;
                    }
                    // ===================================================
                    // PixelFormat.Format32bppArgb is better for this situation.
                    // PixelFormat.Format32bppPArgb shoud not be used for calucurations
                    // ===================================================
                    targetBmp = new Bitmap((int)___width1, (int)___height1, PixelFormat.Format32bppArgb);


                    if (srcImage != null)
                    {
                  
                        // Grahics Context is from bitmap
                        ___grAdhocContext = Graphics.FromImage(targetBmp);

                        ___grAdhocContext.DrawImageUnscaled(srcImage, (int)section.X, (int)section.Y, (int)section.Width, (int)section.Height);

                    }
                    else
                    {

                    }

                    // Clean u
                    if (___grAdhocContext != null)
                    {
                        ___grAdhocContext.Dispose();
                        ___grAdhocContext = null;


                    }

                    // [Array Format]
                    // 32x32 size image should become 32 * 32 * 4 =  4094 length byte length


                    _byteArrayList.___byteArray = this.___ImageToBytes(targetBmp);
                    _byteArrayList.___arrayLength = _byteArrayList.___byteArray.Length;
                    imageDateResult.width = ___width1;
                    imageDateResult.height = ___height1;
                    imageDateResult.data = _byteArrayList;
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                   commonLog.LogEntry("Canvas getImageDataInner Failed. ", ex);
                }
            }
            // Clean up
            if (___grAdhocContext != null)
            {
                ___grAdhocContext.Dispose();
                ___grAdhocContext = null;

            }


            return imageDateResult;
        }
        private byte[] ___ImageToBytes(Bitmap bmp)
        {

            // Lock the bitmap's bits. 
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData =
             bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array  to hold the bytes  of the bitmap.
            int bytes = bmpData.Stride * bmp.Height;
            byte[] rgbValues = new byte[bytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes); bmp.UnlockBits(bmpData);
            ___swapBitmapByteOrder(ref rgbValues);
            return rgbValues;



            /*
            
            byte[] bmp32Data = null;
            using (Bitmap bmp32 = new Bitmap(bmp.Width, bmp.Height))
            {
                // bmp が 32bitARGB 形式ではない場合でも 32bitARGBに変換
                using (Graphics g = Graphics.FromImage(bmp32))
                {
                    g.DrawImage(bmp,
                        new Rectangle(0, 0, bmp32.Width, bmp32.Height),
                        new Rectangle(0, 0, bmp.Width, bmp.Height),
                        GraphicsUnit.Pixel);
                }
                bmp32Data = BitmapToByteArray(bmp32);
            }
            return bmp32Data;
            */
            /*
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData =
                bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                PixelFormat.Format32bppArgb);


            IntPtr ptr = bmpData.Scan0;


            int bytes = bmp.Width * bmp.Height * 4;
            byte[] rgbValues = new byte[bytes];


            Marshal.Copy(ptr, rgbValues, 0, bytes);

            bmp.UnlockBits(bmpData);
            return rgbValues;
            */

        }
        private void ___swapBitmapByteOrder(ref byte[] bts)
        {
            int len = bts.Length;
            for(int pos = 0; pos < len -4; pos = pos +4)
            {
                byte b1 = bts[pos];
                byte b3 = bts[pos + 2];
                bts[pos] = b3;
                bts[pos + 2] = b1;
            }
        }




        private Bitmap ___BytesToBmp(byte[] bmpBytes, Size imageSize)
        {
            if (imageSize.Width >= 1 && imageSize.Height >= 1)
            {
                try
                {
                    Bitmap bmp = new Bitmap(imageSize.Width, imageSize.Height, PixelFormat.Format32bppPArgb);

                    BitmapData bData = bmp.LockBits(new Rectangle(new Point(), bmp.Size), ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);

                    // Copy the bytes to the bitmap object
                    Marshal.Copy(bmpBytes, 0, bData.Scan0, bmpBytes.Length);
                    bmp.UnlockBits(bData);
                    return bmp;
                }
                catch (Exception exBmp)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("__BytesToBmp() errror : ", exBmp);
                    }
                    return new Bitmap(1, 1, PixelFormat.Format32bppPArgb);
                }
            }
            else
            {
                try
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("__BytesToBmp() ___hasInner been zero sise. Attempting bytes to ___getInner image....");
                    }
                    System.IO.MemoryStream memStream = new System.IO.MemoryStream(bmpBytes, true);
                    Bitmap bmpNew = new Bitmap(memStream);
                    return bmpNew;
                }
                catch (Exception ex2)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("__BytesToBmp() errror : ", ex2);
                    }
                }
                return new Bitmap(1, 1, PixelFormat.Format32bppPArgb);
            }
        }
        /// <summary>
        /// Convert Current Canvas image into "data:" string
        /// </summary>
        /// <param name="imageType">Type of array</param>
        /// <returns>image string</returns>
        internal static string ___performToDataURLOperationWebGL(string ___imageType, int ___imageQuality, int ___ImageWidth, int ___imageHeight, CHtmlWebGLRenderingContext __contextObject, CHtmlElement __canvasElement)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("entering PerformToDataURLOperation  : {0}, {1} , {2}, {3} , {4} , {5}", ___imageType, ___imageQuality, ___ImageWidth, ___imageHeight, __contextObject, __canvasElement);
            }
            string type1 = commonHTML.FasterTrimAndToLower(___imageType);
            System.IO.MemoryStream imageStream = new System.IO.MemoryStream();
            System.Text.StringBuilder ___sbDataBuilder = new System.Text.StringBuilder();
            ___sbDataBuilder.Append("data:");
            try
            {
                if (___imageType.Length == 0)
                {
                    type1 = "image/png";
                }
                ___sbDataBuilder.Append(type1);
                ___sbDataBuilder.Append(';');
                byte[] bytesImage = null;
                Image ___bitmapForCanvas = null;
                if (__canvasElement != null)
                {
                    if (__canvasElement.___CanvasGdiImage != null)
                    {
                        ___bitmapForCanvas = __canvasElement.___CanvasGdiImage;
                    }
                }
 
                if (___bitmapForCanvas != null)
                {
                    Bitmap bmpConversion = new Bitmap(___bitmapForCanvas.Width, ___bitmapForCanvas.Height, PixelFormat.Format32bppPArgb);

                    Image ___ImageConverted = bmpConversion as Image;
                    Graphics gr = Graphics.FromImage(___ImageConverted);
                    gr.DrawImageUnscaled(___bitmapForCanvas, 0, 0);
                    gr.Dispose();
                    gr = null;
                    switch (type1)
                    {
                        case "imge/bmp":
                            ___ImageConverted.Save(imageStream, ImageFormat.Bmp);
                            break;
                        case "imge/gif":
                            ___ImageConverted.Save(imageStream, ImageFormat.Gif);
                            break;
                        case "imge/jpeg":
                        case "imge/jpg":
                            ___ImageConverted.Save(imageStream, ImageFormat.Jpeg);
                            break;
                        case "imge/png":
                            ___ImageConverted.Save(imageStream, ImageFormat.Png);
                            break;
                        default:
                            ___ImageConverted.Save(imageStream, ImageFormat.Png);
                            break;
                    }
                }
                if (imageStream != null)
                {
                    bytesImage = imageStream.ToArray();
                    imageStream.Dispose();
                    imageStream = null;
                    ___sbDataBuilder.Append("base64, ");
                    //___sbDataBuilder.Append(commonGraphics.ConvertBinaryToBase64(bytesImage));
                }







            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                {
                    commonLog.LogEntry("toDataURL Operation Error : ", ex);
                }
            }
            if (imageStream != null)
            {
                imageStream.Dispose();
                imageStream = null;
            }
            return ___sbDataBuilder.ToString();
        }

        /// <summary>
        /// Convert Current Canvas image into "data:" string
        /// </summary>
        /// <param name="imageType">Type of array</param>
        /// <returns>image string</returns>
        internal static string ___performToDataURLOperation(string ___imageType, int ___imageQuality, int ___ImageWidth, int ___imageHeight, CHtmlCanvasContext2D __contextObject, CHtmlElement __canvasElement)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("entering PerformToDataURLOperation  : {0}, {1} , {2}, {3} , {4} , {5}", ___imageType, ___imageQuality, ___ImageWidth, ___imageHeight, __contextObject, __canvasElement);
            }
            string type1 = commonHTML.FasterTrimAndToLower(___imageType);
            System.IO.MemoryStream imageStream = new System.IO.MemoryStream();
            System.Text.StringBuilder ___sbDataBuilder = new System.Text.StringBuilder();
            ___sbDataBuilder.Append("data:");
            try
            {
                if (___imageType.Length == 0)
                {
                    type1 = "image/png";
                }
                ___sbDataBuilder.Append(type1);
                ___sbDataBuilder.Append(';');
                byte[] bytesImage = null;
                Image ___bitmapForCanvas = null;
                if (__canvasElement != null)
                {
                    if (__canvasElement.___CanvasGdiImage != null)
                    {
                        ___bitmapForCanvas = __canvasElement.___CanvasGdiImage;
                    }
                }
                if (__contextObject != null)
                {
                    if (__contextObject.___CanvasGdiImageWeakReference != null)
                    {
                        ___bitmapForCanvas = __contextObject.___CanvasGdiImageWeakReference.Target as Image;
                    }
                }
                if (___bitmapForCanvas != null)
                {
                    Bitmap bmpConversion = new Bitmap(___bitmapForCanvas.Width, ___bitmapForCanvas.Height, PixelFormat.Format32bppPArgb);

                    Image ___ImageConverted = bmpConversion as Image;
                    Graphics gr = Graphics.FromImage(___ImageConverted);
                    gr.DrawImageUnscaled(___bitmapForCanvas, 0, 0);
                    gr.Dispose();
                    gr = null;
                    switch (type1)
                    {
                        case "imge/bmp":
                            ___ImageConverted.Save(imageStream, ImageFormat.Bmp);
                            break;
                        case "imge/gif":
                            ___ImageConverted.Save(imageStream, ImageFormat.Gif);
                            break;
                        case "imge/jpeg":
                        case "imge/jpg":
                            ___ImageConverted.Save(imageStream, ImageFormat.Jpeg);
                            break;
                        case "imge/png":
                            ___ImageConverted.Save(imageStream, ImageFormat.Png);
                            break;
                        default:
                            ___ImageConverted.Save(imageStream, ImageFormat.Png);
                            break;
                    }
                }
                if (imageStream != null)
                {
                    bytesImage = imageStream.ToArray();
                    imageStream.Dispose();
                    imageStream = null;
                    ___sbDataBuilder.Append("base64, ");
                    //___sbDataBuilder.Append(commonGraphics.ConvertBinaryToBase64(bytesImage));
                }







            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                {
                   commonLog.LogEntry("toDataURL Operation Error : ", ex);
                }
            }
            if (imageStream != null)
            {
                imageStream.Dispose();
                imageStream = null;
            }
            return ___sbDataBuilder.ToString();
        }
        /// <summary>
        /// Canvas toDataURL
        /// </summary>
        /// <param name="__imageTypes">ImageType</param>
        /// <param name="___imageQuality">Numeric</param>
        /// <returns></returns>
        public string toDataURL(object __imageTypes, object ___imageQuality)
        {
            return CHtmlWebGLRenderingContext.___performToDataURLOperationWebGL(commonHTML.GetStringValue(__imageTypes), -1, -1, -1, this, null);
        }
        public string toDataURL(object __imageTypes)
        {
            return CHtmlWebGLRenderingContext.___performToDataURLOperationWebGL(commonHTML.GetStringValue(__imageTypes), -1, -1, -1, this, null);
        }
        public string toDataURL()
        {
            return CHtmlWebGLRenderingContext.___performToDataURLOperationWebGL("", -1, -1, -1, this, null);
        }
        /// <summary>
        /// Convert Radian to Degree
        /// </summary>
        /// <param name="paramangle">Radian</param>
        /// <returns>degree</returns>
        internal static double ___getRadianToDegree(double paramRadian)
        {
            return paramRadian * (180.0 / Math.PI);
        }
        /// <summary>
        /// Conert Degree to Radian
        /// </summary>
        /// <param name="paramangle"></param>
        /// <returns></returns>
        internal static double ___getDegreeToRadian(double paramDegree)
        {
            return Math.PI * paramDegree / 180.0;
        }
        #region DrawingMethods
        


        const double ___pieDouble = 2 * Math.PI;



        public static System.Drawing.PointF ___getClosestPointFWithRadius(PointF ___startPoint, System.Drawing.PointF ___centerPoint, float ___radius)
        {
            double ___angle = Math.Atan2(___centerPoint.Y - ___startPoint.Y, ___startPoint.X - ___centerPoint.X);

            double x = ___radius * System.Math.Cos(___angle) + ___centerPoint.X;
            double y = ___radius * System.Math.Sin(___angle) + ___centerPoint.Y;

            return new PointF((float)x, (float)y);
        }





        public void clearDepth(object ___depth)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling {0}.clearDepth()", this);
            }
        }
        public void clear(object ___objMask)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling {0}.clear({0}) ", this, ___objMask);
            }
        }
        
  
        public void clearStencil(object ___index)
        {

        }
        public void colorMask(object ___objRed, object ___objGreen, object ___objBlue, object ___objAlpha)
        {

        }
        public CHtmlCanvasWebGLShader createShader()
        {
            return this.createShader(null);
        }
        public CHtmlAudioPannerNode createPanner()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("calling {0}.createPanner()", this);
            }
            CHtmlAudioPannerNode panner = new CHtmlAudioPannerNode();
            return panner;
        }
        public CHtmlCanvasWebGLShader createShader(object __type)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("setting {0}.createShader()", this);
            }
            CHtmlCanvasWebGLShader shader = new CHtmlCanvasWebGLShader();
            return shader;
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
            if (this.___CanvasContextModeType == CanvasContextModeType.WebGL || this.___CanvasContextModeType == CanvasContextModeType.WebGLPrototype)
            {


                ____returnBuffer = new CHtmlCanvasWebGLBuffer();
            }

            
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("{0}.createBuffer() returns {1}", this, ____returnBuffer);
            }
            return ____returnBuffer;
        }
        public CHtmlAudioDynamicsCompressorNode createDynamicsCompressor()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("calling {0}.createDynamicsCompressor()", this);
            }
            return new CHtmlAudioDynamicsCompressorNode();
        }
        public CHtmlCanvasWebGLFramebuffer createFramebuffer()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("calling {0}.createFramebuffer()", this);
            }
            return new CHtmlCanvasWebGLFramebuffer();
        }
        public CHtmlCanvasWebGLRenderbuffer createRenderbuffer()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("calling {0}.createRenderbuffer()", this);
            }
            return new CHtmlCanvasWebGLRenderbuffer();
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
        public CHtmlCanvasWebGLProgram createProgram()
        {
            return new CHtmlCanvasWebGLProgram();
        }
        public object getUniformLocation(object ___objectProgram, object ___pname)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO: calling {0}.getUniformLocation({1}, {2})", this, ___objectProgram, ___pname);
            }
            return null;
        }
        public CHtmlCanvasWebGLTexture createTexture()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("calling {0}.createTexture()", this);
            }
            return new CHtmlCanvasWebGLTexture();
        }
        public void bindTexture(object ___target, CHtmlCanvasWebGLTexture ___texture)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO: calling {0}.bindTexture({1}, {2})", this, ___target, ___texture);
            }
        }
        public void bindAttribLocation(object ___objProgram, object ___objIndex, object ___objName)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO: calling {0}.bindAttribLocation({1}, {2}, {3})", this, ___objProgram, ___objIndex, ___objName);
            }
        }






        

        public void fillText(object __text, double __x, double __y, double __maxWidth)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling {0}.fillText('{1}', {2}, {3}, {4})... ", this, __text,  __x, __y, __maxWidth);
            }
            try
            {

            }

            
            catch (Exception exBase)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                {
                   commonLog.LogEntry("fillText error : ", exBase);
                }
            }
            //___setCanvasActivityIntoDocument();

        }
        public void strokeText(object _text, double x, double y, double maxWidth)
        {
            this.fillText(_text, x, y, maxWidth);
        }
        public void strokeText(object _text, double x, double y)
        {
            this.fillText(_text, x, y, this.___CanvasWidth);
        }
        public void fillText(object __text, double __x, double __y)
        {
            this.fillText(__text, __x, __y, this.___CanvasWidth);
        }
        /// <summary>
        /// The rect() method creates a rectangle.
        /// Tip: Use the stroke() or the fill() method to actually draw the rectangle on the canvas.
        /// </summary>
        /// <param name="ox">x</param>
        /// <param name="oy">y</param>
        /// <param name="ow">The width of the rectangle, in pixels</param>
        /// <param name="oh">The height of the rectangle, in pixels</param>
        public void rect(object ox, object  oy, object  ow, object oh)
        {
            double x = ___ConvertNaNInfiniteToZero(commonData.GetDoubleFromObject(ox, 0));
            double y = ___ConvertNaNInfiniteToZero(commonData.GetDoubleFromObject(oy, 0));
            double w = ___ConvertNaNInfiniteToZero(commonData.GetDoubleFromObject(ow, 0));
            double h = ___ConvertNaNInfiniteToZero(commonData.GetDoubleFromObject(oh, 0));
            //this.___graphic2DPath.AddRectangle(new RectangleF((float)x,(float) y,(float) w,(float) h));
            //this.___graphic2DPath.CloseFigure();
        }


        internal static double ___ConvertNaNInfiniteToZero(double ___double)
        {
            if (double.IsNaN(___double) || double.IsNegativeInfinity(___double) || double.IsPositiveInfinity(___double))
            {
                return 0;
            }
            return ___double;
        }
       





        private Image ___GetImageFromDocumentWithUrl(string ___srcUrl, ref string ___targetFullUrl)
        {
            CHtmlDocument ___ownerDocument = null;
            Image ___imageObject = null;
            if (this.___ownerDocumentWeakReference != null)
            {
                ___ownerDocument = this.___ownerDocumentWeakReference.Target as CHtmlDocument;
            }
            if (___ownerDocument == null)
            {
                return null;
            }
            else
            {
                if (___srcUrl.StartsWith("http", StringComparison.OrdinalIgnoreCase) == true || ___srcUrl.StartsWith("data:", StringComparison.OrdinalIgnoreCase) == true)
                {
                    goto GetImageSection;
                }
                if (___srcUrl.StartsWith("url(", StringComparison.OrdinalIgnoreCase))
                {
                    ___srcUrl = commonHTML.GetUrlQuotedUrlToNormalUrl(___srcUrl, ___ownerDocument.___URL);
                    goto GetImageSection;
                }
                else
                {
                    ___srcUrl = commonHTML.GetAbsoluteUri(___ownerDocument.___URL, ___ownerDocument.___baseUrl, ___srcUrl);
                    goto GetImageSection;
                }
            GetImageSection:
                ___ownerDocument.___imageRawConcurrentDictionaryForGdi.TryGetValue(___srcUrl, out ___imageObject);
                ___targetFullUrl = string.Copy(___srcUrl);
            }
            return ___imageObject;
        }

        public void flush()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("{0}.flush()", this);
            }
        }
        public void drawElements(object ____mode,object ____objcount, object ___objtype,object ___objoffset)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: {0}.drawElements({1}, {2}, {3}, {4})", this, ____mode, ____objcount, ___objtype, ___objoffset);
            }
        }








      
      
  





        public CHtmlCanvasContextExtenstionObject createPattern(object imageObject, object patternType)
        {
            try
            {
                string ___src = "";
                if (imageObject is CHtmlElement)
                {
                    CHtmlElement elem = imageObject as CHtmlElement;
                    if (elem.___srcBase != null && string.IsNullOrEmpty(elem.___srcBase.___Href) == false)
                    {
                        ___src = string.Copy(elem.___srcBase.___Href);
                    }
                    else
                    {
                        ___src = string.Copy(elem.src);
                    }
                }
             
                CHtmlCanvasContextExtenstionObject pattern = new CHtmlCanvasContextExtenstionObject(CanvasExtentionObjectType.ImagePattern);

                pattern.___baseSrc = ___src;
                pattern.___basePattern = commonHTML.GetStringValue(patternType);
                return pattern;
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                {
                   commonLog.LogEntry("createPattern Error : ", ex);
                }

            }
            return null;
        }
        /// <summary>
        /// Get Size of Sting Size
        /// </summary>
        /// <param name="_text"></param>
        /// <returns>Returns object which ___hasInner width and height property.</returns>
		public CHtmlCanvasContextExtenstionObject measureText(string _text)
		{
            System.Drawing.Graphics ___gractiveContext = null;
            CHtmlCanvasContextExtenstionObject measureResult = new CHtmlCanvasContextExtenstionObject(CanvasExtentionObjectType.MeasureTextResult);
            measureResult.___baseWidth  = 100;
            measureResult.___baseHeight = 25;
            Font fnt = null;
            try
            {
                
                if (this.___contextCHtmlFontInfo != null)
                {
                    #if WINDOWS
                    fnt = this.___contextCHtmlFontInfo.ToFont();
                    #endif
                }
                else
                {
                    fnt = new Font(FontFamily.GenericSerif, 13f);
                }
                double measuredWidth = 0;
                double measuredHeight = 0;

                
                if (this.___CanvasContextModeType == CanvasContextModeType.Canvas2D || this.___CanvasContextModeType == CanvasContextModeType.SVG)
                {

                    ___gractiveContext = null;
                    SizeF textSizeF = ___gractiveContext.MeasureString(_text, fnt);
                    measuredWidth = textSizeF.Width;
                    measuredHeight = textSizeF.Height;
                    fnt.Dispose();
                    fnt = null;

                }
                else
                {
                    // 3d canvas is ad hoc
                    measuredWidth = fnt.Size * _text.Length;
                    measuredHeight = fnt.GetHeight();

                }
                measureResult.___baseWidth = measuredWidth;
                measureResult.___baseHeight = measuredHeight;
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                {
                   commonLog.LogEntry("CHtmlCanvasContext measureText('{0}')  : Result: {1}, {2}", _text, measuredWidth, measuredHeight);
                }

                return measureResult;
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                {
                   commonLog.LogEntry("measureText Error : ", ex);
                }
            }
            if (fnt != null)
            {
                fnt.Dispose();
            }

            
            return measureResult;
		}




		public void scale(object ox, object oy)
		{
            double x = ___ConvertNaNInfiniteToZero(commonData.GetDoubleFromObject(ox, 0));
            double y = ___ConvertNaNInfiniteToZero(commonData.GetDoubleFromObject(oy, 0));

            CHtmlCanvasContextInstruction ___instruction = new CHtmlCanvasContextInstruction();
            ___instruction.InstructionType = CanvasInstructionType.Scale;
            ___instruction.point = new PointFSpec((float)x, (float)y);


            // Add instruction into queue

            this.___CanvasInstructionsList.Add(___instruction);

		}
        public double sampleRate
        {
            get
            {
                return ___audioContextSampleRate;
            }
        }
        /// <summary>
        /// Save Current State and Pushes the current state onto the stack.
        /// </summary>
        public void save()
        {
            /*
  Each context maintains a stack of drawing states. Drawing states consist of:

 - The current transformation matrix.

 - The current clipping region.

 - The current values of the following attributes: strokeStyle, fillStyle, globalAlpha, lineWidth, lineCap,
   lineJoin, miterLimit, shadowOffsetX, shadowOffsetY, shadowBlur, shadowColor, globalCompositeOperation,
    font, textAlign, textBaseline.

 - The current path and the current bitmap are not part of the drawing state. The current path is persistent, 
   and can only be reset using the beginPath() method. The current bitmap is a property of the canvas,
   not the context.
          
 */
            switch(___CanvasContextModeType)
            {
                case CanvasContextModeType.Canvas2D:
                case CanvasContextModeType.SVG:
                
                    break;
            }


            CHtmlCanvasContextInstruction ___instruction = new CHtmlCanvasContextInstruction();
            ___instruction.InstructionType = CanvasInstructionType.Save;
            
            // Add instruction into queue

            this.___CanvasInstructionsList.Add(___instruction);
            this.___CanvasInstructionSavedPoint = this.___CanvasInstructionsList.Count;

            CHtmlCanvasState ___currentState = new CHtmlCanvasState();
            ___currentState.___contextFillStyleAsObject = this.___contextFillStyleAsObject;
            ___currentState.___contextFontAsObject = this.___contextFontAsObject;
            ___currentState.___contextFontAsString = this.___contextFontAsString;
            ___currentState.___contextLineCap = this.___contextLineCap;
            ___currentState.___contextLineJoin = this.___contextLineJoin;
            ___currentState.___contextLineWidth = this.___contextLineWidth;
            ___currentState.___contextShadowBlur = this.___contextShadowBlur;
            ___currentState.___contextShadowColorAsObject = this.___contextShadowColorAsObject;
            ___currentState.___contextShadowOffsetX = this.___contextShadowOffsetX;
            ___currentState.___contextShadowOffsetY = this.___contextShadowOffsetY;
       
            ___currentState.___contextTextAlignAsObject = this.___contextTextAlignAsObject;
            ___currentState.___contextTextBaseline = this.___contextTextBaseline;
            ___currentState.___contextglobalCompositeOperationAsObject = this.___contextglobalCompositeOperationAsObject;
            ___currentState.___contextGlobalAlpha = this.___contextGlobalAlpha;
            ___currentState.___contextGlobalAlpha255 = this.___contextGlobalAlphaAsInt255;
            ___currentState.___contextTranslatePoint = this.___CanvasTranslatePoint;
            ___currentState.___contextRotateAngle = this.___CanvasRotateAngle;

            this.___CanvasStateStack.Push(___currentState);
        }
        /// <summary>
        /// Restore Current State and Pops the top state on the stack, restoring the context to that state.
        /// </summary>
        public void restore()
        {
            
        }
        private static string[] ___webGLSuppportedExtenstionsArray = null;
        /// <summary>
        /// Returns an array of supported extension strings.
        /// </summary>
        /// <returns>String Array</returns>
        public string[] getSupportedExtensions()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling canvas getSupportedExtensions()...");
            }
            if (___webGLSuppportedExtenstionsArray == null)
            {
                System.Collections.Generic.List<string> arWebGLExtensionsList = new System.Collections.Generic.List<string>();
                arWebGLExtensionsList.Add("ANGLE_instanced_arrays");
                arWebGLExtensionsList.Add("EXT_blend_minmax");
                arWebGLExtensionsList.Add("EXT_color_buffer_float");
                arWebGLExtensionsList.Add("EXT_color_buffer_half_float");
                arWebGLExtensionsList.Add("EXT_disjoint_timer_query");
                arWebGLExtensionsList.Add("EXT_frag_depth");
                arWebGLExtensionsList.Add("EXT_sRGB");
                arWebGLExtensionsList.Add("EXT_shader_texture_lod");
                arWebGLExtensionsList.Add("EXT_texture_filter_anisotropic");
                arWebGLExtensionsList.Add("OES_element_index_uint");
                arWebGLExtensionsList.Add("OES_standard_derivatives");
                arWebGLExtensionsList.Add("OES_texture_float");
                arWebGLExtensionsList.Add("OES_texture_float_linear");
                arWebGLExtensionsList.Add("OES_texture_half_float");
                arWebGLExtensionsList.Add("OES_texture_half_float_linear");
                arWebGLExtensionsList.Add("OES_vertex_array_object");
                arWebGLExtensionsList.Add("WEBGL_color_buffer_float");
                arWebGLExtensionsList.Add("WEBGL_compressed_texture_atc");
                arWebGLExtensionsList.Add("WEBGL_compressed_texture_es3");
                arWebGLExtensionsList.Add("WEBGL_compressed_texture_etc1");
                arWebGLExtensionsList.Add("WEBGL_compressed_texture_pvrtc");
                arWebGLExtensionsList.Add("WEBGL_compressed_texture_s3tc");
                arWebGLExtensionsList.Add("WEBGL_debug_renderer_info");
                arWebGLExtensionsList.Add("WEBGL_debug_shaders");
                arWebGLExtensionsList.Add("WEBGL_depth_texture");
                arWebGLExtensionsList.Add("WEBGL_draw_buffers");
                arWebGLExtensionsList.Add("WEBGL_lose_context");
                ___webGLSuppportedExtenstionsArray = arWebGLExtensionsList.ToArray();
            }
            return ___webGLSuppportedExtenstionsArray;
        }
		
		
        public bool drawFocusRing(object obj_element, double ___x,double ___y)
        {
            return this.___drawFocusRing(obj_element, ___x, ___y, false);
        }
        public bool drawFocusRing(object obj_element, double ___x, double ___y, double doubleCustom)
        {
            if (doubleCustom == 1)
            {
                return this.___drawFocusRing(obj_element, ___x, ___y, true);
            }
            else
            {
                return this.___drawFocusRing(obj_element, ___x, ___y, false);
            }
        }
        public bool drawFocusRing(object obj_element, double ___x, double ___y, bool boolCustom)
        {
            return this.___drawFocusRing(obj_element, ___x, ___y, boolCustom);
        }
        private bool ___drawFocusRing(object obj_element, double ___x, double ___y, bool boolCustom)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO {0}.drawFocusRing({1}, {2}, {3}, {4})", this, obj_element, ___x,  ___y,  boolCustom);
            }
            return false;
        }
        public void rotate(double doubleRadian)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("{0}.rotate({1})", this, doubleRadian);
            }
            // in value is radian convert to radian
            double doubleAngle = ___getRadianToDegree(doubleRadian);

            CHtmlCanvasContextInstruction ___instruction = new CHtmlCanvasContextInstruction();
            ___instruction.InstructionType = CanvasInstructionType.Rotate;
            ___instruction.floatValue  = (float)doubleAngle;
           

            // Add instruction into queue

            this.___CanvasInstructionsList.Add(___instruction);


            this.___CanvasRotateAngle = (float)doubleAngle;
        }
        public double Width
        {
            get { return this.___CanvasWidth; }
            set { this.___CanvasWidth = value; }
        }
        public double width
        {
            get { return this.___CanvasWidth; }
            set { this.___CanvasWidth = value; }
        }
        public double Height
        {
            get { return this.___CanvasHeight; }
            set { this.___CanvasHeight = value; }
        }
        public double height
        {
            get { return this.___CanvasHeight; }
            set { this.___CanvasHeight = value; }
        }

		#endregion


		#region IPropertBox メンバ


   
        public object ___getPropertyByName(string ___name)
        {
            switch (___name)
            {

      
                case "font":
                case "FontSpec":
                    return this.___contextFontAsObject;
                case "strokestyle":
                case "strokeStyle":
                case "StrokeStyle":
                    return null;
                case "fillstyle":
                case "fillStyle":
                case "FillStyle":
                    return this.___contextFillStyleAsObject;
                case "linecap":
                case "lineCap":
                case "LineCap":
                    return this.___contextLineCap;
                case "linewidth":
                case "lineWidth":
                case "LineWidth":
                    return this.___contextLineWidth;
                case "textalign":
                case "textAlign":
                case "TextAlign":
                    return this.___contextTextAlignAsObject;
                case "textbaseline":
                case "textBaseLine":
                case "TextBaseLine":
                    return this.___contextTextBaseline;
                case "shadowblur":
                case "shadowBlur":
                    return this.___contextShadowBlur;
                case "shadowcolor":
                case "shadowColor":
                case "ShadowColor":
                    return this.___contextShadowColorAsObject;
                case "shadowoffsetX":
                case "shadowOffsetX":
                    return this.___contextShadowOffsetX;
                case "shadowoffsety":
                case "shadowOffsetY":
                    return this.___contextShadowOffsetY;
                case "linejoin":
                case "lineJoin":
                case "LineJoin":
                    return this.___contextLineJoin;
                case "miterlimit":
                    return this.___contextMiterLimit;
                case "globalalpha":
                case "globalAlpha":
                case "GlobalAlpha":
                    return this.___contextGlobalAlpha;
                case "globalcompositeoperation":
                case "globalCompositeOperation":
                case "GlobalCompositeOperation":
                    return this.___contextglobalCompositeOperationAsObject;
                case "backingstorepixelratio":
                case "backingstorepixelRatio":
                case "backingStorePixelRatio":
                    return this.___BackingStorePixelRatio;
                case "msImageSmoothingEnabled":
                case "mozImageSmoothingEnabled":
                case "webkitImageSmoothingEnabled":
                case "oImageSmoothingEnabled":
                case "imageSmoothingEnabled":
                    return this.___CanvasImageSmoothingEnabled;
                case "mosBackingStorePixelRatio":
                case "BackingStorePixelRatio":
                case "oBackingStorePixelRatio":
                case "webkitBackingStorePixelRatio":
                    return this.___CanvasBackingStorePixelRatio;
                case "width":
                case "Width":
                    return this.___CanvasWidth;
                case "height":
                case "Height":
                    return this.___CanvasHeight;
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
                case "VENDOR":
                    return this.VENDOR;
                case "RENDERER":
                    return this.RENDERER;
                case "VERSION":
                    return this.VERSION;
                case "SHADING_LANGUAGE_VERSION":
                    return this.SHADING_LANGUAGE_VERSION;
                case "CURRENT_PROGRAM":
                    return this.CURRENT_PROGRAM;
                case "NONE":
                case "ZERO":
                    return 0;
                case "ONE":
                    return 1;
                case "SRC_COLOR":
                    return this.SRC_COLOR;
                case "ONE_MINUS_SRC_COLOR":
                    return this.ONE_MINUS_SRC_COLOR;
                case "SRC_ALPHA":
                    return this.SRC_ALPHA;
                case "ONE_MINUS_SRC_ALPHA":
                    return this.ONE_MINUS_DST_ALPHA;
                case "DST_ALPHA":
                    return this.DST_ALPHA;
                case "ONE_MINUS_DST_ALPHA":
                    return this.ONE_MINUS_DST_ALPHA;
                case "DST_COLOR":
                    return this.DST_COLOR;
                case "ONE_MINUS_DST_COLOR":
                    return this.ONE_MINUS_DST_COLOR;
                case "SRC_ALPHA_SATURATE":
                    return this.SRC_ALPHA_SATURATE;
                case "NEVER":
                    return this.NEVER;
                case "LESS":
                    return this.LESS;
                case "EQUAL":
                    return this.EQUAL;
                case "LEQUAL":
                    return this.LEQUAL;
                case "GREATER":
                    return this.GREATER;
                case "NOTEQUAL":
                    return this.NOTEQUAL;
                case "GEQUAL":
                    return this.GEQUAL;
                case "ALWAYS":
                    return this.ALWAYS;
                case "FUNC_ADD":
                    return this.FUNC_ADD;
                case "BLEND_EQUATION":
                    return this.BLEND_EQUATION;
                case "BLEND_EQUATION_RGB":
                    return this.BLEND_EQUATION_RGB;
                case "BLEND_EQUATION_ALPHA":
                    return this.BLEND_EQUATION_ALPHA;
                case "FUNC_SUBTRACT":
                    return this.FUNC_SUBTRACT;
                case "FUNC_REVERSE_SUBTRACT":
                    return this.FUNC_REVERSE_SUBTRACT;
                case "BLEND_DST_RGB":
                    return this.BLEND_DST_RGB;
                case "BLEND_SRC_RGB":
                    return this.BLEND_SRC_RGB;
                case "BLEND_DST_ALPHA":
                    return this.BLEND_DST_ALPHA;
                case "BLEND_SRC_ALPHA":
                    return this.BLEND_SRC_ALPHA;
                case "CONSTANT_COLOR":
                    return this.CONSTANT_ALPHA;
                case "ONE_MINUS_CONSTANT_COLOR":
                    return this.ONE_MINUS_CONSTANT_COLOR;
                case "CONSTANT_ALPHA":
                    return this.CONSTANT_ALPHA;
                case "ONE_MINUS_CONSTANT_ALPHA":
                    return this.ONE_MINUS_CONSTANT_ALPHA;
                case "BLEND_COLOR":
                    return this.BLEND_COLOR;

                case "COMPILE_STATUS":
                    return this.COMPILE_STATUS;
                case "DELETE_STATUS":
                    return this.DELETE_STATUS;
                case "SHADER_TYPE":
                    return this.SHADER_TYPE;
                case "FRAGMENT_SHADER":
                    return this.FRAGMENT_SHADER;
                case "VERTEX_SHADER":
                    return this.VERTEX_SHADER;
                case "MAX_VERTEX_ATTRIBS":
                    return this.MAX_VERTEX_ATTRIBS;
                case "MAX_VERTEX_UNIFORM_VECTORS":
                    return this.MAX_VERTEX_UNIFORM_VECTORS;
                case "MAX_VARYING_VECTORS":
                    return this.MAX_VARYING_VECTORS;
                case "MAX_COMBINED_TEXTURE_IMAGE_UNITS":
                    return this.MAX_COMBINED_TEXTURE_IMAGE_UNITS;
                case "MAX_VERTEX_TEXTURE_IMAGE_UNITS":
                    return this.MAX_VERTEX_TEXTURE_IMAGE_UNITS;
                case "MAX_FRAGMENT_UNIFORM_VECTORS":
                    return this.MAX_FRAGMENT_UNIFORM_VECTORS;
                case "MAX_TEXTURE_IMAGE_UNITS":
                    return this.MAX_TEXTURE_IMAGE_UNITS;
                case "ARRAY_BUFFER":
                    return this.ARRAY_BUFFER;
                case "ELEMENT_ARRAY_BUFFER":
                    return this.ELEMENT_ARRAY_BUFFER;
                case "STATIC_DRAW":
                    return this.STATIC_DRAW;
                case "DYNAMIC_DRAW":
                    return this.DYNAMIC_DRAW;
                case "STREAM_DRAW":
                    return this.STREAM_DRAW;
                case "LINK_STATUS":
                    return this.LINK_STATUS;
                case "CULL_FACE":
                    return this.CULL_FACE;
                case "BLEND":
                    return this.BLEND;
                case "DITHER":
                    return this.DITHER;
                case "STENCIL_TEST":
                    return this.STENCIL_TEST;
                case "DEPTH_TEST":
                    return this.DEPTH_TEST;
                case "SCISSOR_TEST":
                    return this.SCISSOR_TEST;
                case "POLYGON_OFFSET_FILL":
                    return this.POLYGON_OFFSET_FILL;
                case "SAMPLE_ALPHA_TO_COVERAGE":
                    return this.SAMPLE_ALPHA_TO_COVERAGE;
                case "SAMPLE_COVERAGE":
                    return this.SAMPLE_COVERAGE;
                case "POINTS":
                    return 0;
                case "LINES":
                    return this.LINES;
                case "LINE_LOOP":
                    return this.LINE_LOOP;
                case "LINE_STRIP":
                    return this.LINE_STRIP;
                case "TRIANGLES":
                    return this.TRIANGLES;
                case "TRIANGLE_STRIP":
                    return this.TRIANGLE_STRIP;
                case "TRIANGLE_FAN":
                    return this.TRIANGLE_FAN;
                case "TEXTURE_CUBE_MAP":
                    return this.TEXTURE_CUBE_MAP;
                case "TEXTURE_2D":
                    return this.TEXTURE_2D;
                case "FRONT":
                    return this.FRONT;
                case "BACK":
                    return this.BACK;
                case "FRONT_AND_BACK":
                    return this.FRONT_AND_BACK;
                case "BYTE":
                    return this.BYTE;
                case "UNSIGNED_BYTE":
                    return this.UNSIGNED_BYTE;
                case "SHORT":
                    return this.SHORT;
                case "UNSIGNED_SHORT":
                    return this.UNSIGNED_SHORT;
                case "INT":
                    return this.INT;
                case "UNSIGNED_INT":
                    return this.UNSIGNED_INT;
                case "FLOAT":
                    return this.FLOAT;
                case "DEPTH_COMPONENT":
                    return this.DEPTH_COMPONENT;
                case "ALPHA":
                    return this.ALPHA;
                case "RGB":
                    return this.RGB;
                case "RGBA":
                    return this.RGBA;
                case "LUMINANCE":
                    return this.LUMINANCE;
                case "LUMINANCE_ALPHA":
                    return this.LUMINANCE_ALPHA;
                case "DEPTH_BUFFER_BIT":
                    return this.DEPTH_BUFFER_BIT;
                case "STENCIL_BUFFER_BIT":
                    return this.STENCIL_BUFFER_BIT;
                case "COLOR_BUFFER_BIT":
                    return this.COLOR_BUFFER_BIT;
                case "TEXTURE0": return (int)0x84C0;
                case "TEXTURE1": return (int)0x84C1;
                case "TEXTURE2": return (int)0x84C2;
                case "TEXTURE3": return (int)0x84C3;
                case "TEXTURE4": return (int)0x84C4;
                case "TEXTURE5": return (int)0x84C5;
                case "TEXTURE6": return (int)0x84C6;
                case "TEXTURE7": return (int)0x84C7;
                case "TEXTURE8": return (int)0x84C8;
                case "TEXTURE9": return (int)0x84C9;
                case "TEXTURE10": return (int)0x84CA;
                case "TEXTURE11": return (int)0x84CB;
                case "TEXTURE12": return (int)0x84CC;
                case "TEXTURE13": return (int)0x84CD;
                case "TEXTURE14": return (int)0x84CE;
                case "TEXTURE15": return (int)0x84CF;
                case "TEXTURE16": return (int)0x84D0;
                case "TEXTURE17": return (int)0x84D1;
                case "TEXTURE18": return (int)0x84D2;
                case "TEXTURE19": return (int)0x84D3;
                case "TEXTURE20": return (int)0x84D4;
                case "TEXTURE21": return (int)0x84D5;
                case "TEXTURE22": return (int)0x84D6;
                case "TEXTURE23": return (int)0x84D7;
                case "TEXTURE24": return (int)0x84D8;
                case "TEXTURE25": return (int)0x84D9;
                case "TEXTURE26": return (int)0x84DA;
                case "TEXTURE27": return (int)0x84DB;
                case "TEXTURE28": return (int)0x84DC;
                case "TEXTURE29": return (int)0x84DD;
                case "TEXTURE30": return (int)0x84DE;
                case "TEXTURE31": return (int)0x84DF;
                case "ACTIVE_TEXTURE": return (int)0x84E0;
                case "LOW_FLOAT":
                    return this.LOW_FLOAT;
                case "MEDIUM_FLOAT":
                    return this.MEDIUM_FLOAT;
                case "HIGH_FLOAT":
                    return this.HIGH_FLOAT;
                case "LOW_INT":
                    return this.LOW_INT;
                case "MEDIUM_INT":
                    return this.MEDIUM_INT;
                case "HIGH_INT":
                    return this.HIGH_INT;
                case "FRAMEBUFFER":
                case "FRAME_BUFFER":
                    return this.FRAMEBUFFER;
                case "RENDERBUFFER":
                case "RENDER_BUFFER":
                    return this.RENDERBUFFER;
                case "RGBA4":
                    return this.RGBA4;
                case "RGB5_A1":
                    return this.RGB5_A1;
                case "RGB565":
                    return this.RGB565;
                case "DEPTH_COMPONENT16":
                    return this.DEPTH_COMPONENT16;
                case "STENCIL_INDEX":
                    return this.STENCIL_INDEX;
                case "STENCIL_INDEX8":
                    return this.STENCIL_INDEX8;
                case "DEPTH_STENCIL":
                    return this.DEPTH_STENCIL;
                case "COLOR_ATTACHMENT0":
                    return this.COLOR_ATTACHMENT0;
                case "DEPTH_ATTACHMENT":
                    return this.DEPTH_ATTACHMENT;
                case "STENCIL_ATTACHMENT":
                    return this.STENCIL_ATTACHMENT;
                case "DEPTH_STENCIL_ATTACHMENT":
                    return this.DEPTH_STENCIL_ATTACHMENT;
                case "TEXTURE_MAG_FILTER":
                    return this.TEXTURE_MAG_FILTER;
                case "TEXTURE_MIN_FILTER":
                    return this.TEXTURE_MIN_FILTER;
                case "TEXTURE_WRAP_S":
                    return this.TEXTURE_WRAP_S;
                case "TEXTURE_WRAP_T":
                    return this.TEXTURE_WRAP_T;
                case "NEAREST":
                    return this.NEAREST;
                case "LINEAR":
                    return this.LINEAR;
                case "NEAREST_MIPMAP_NEAREST":
                    return (int)0x2800;
                case "LINEAR_MIPMAP_NEAREST":
                return (int)0x2701;
                case "NEAREST_MIPMAP_LINEAR":
                return (int)0x2702;
                case "LINEAR_MIPMAP_LINEAR":
                return (int)0x2703;
                case "REPEAT":
                return this.REPEAT;
                case "CLAMP_TO_EDGE":
                return this.CLAMP_TO_EDGE;
                case "MIRRORED_REPEAT":
                return this.MIRRORED_REPEAT;
                    //<!--- Context Attributes boolean values ----
                case "alpha":
                return this.___Context_Attributes_alpha;
                case "depth":
                return this.___Context_Attributes_depth;
                case "stencil":
                return this.___Context_Attributes_stencil;
                case "antialias":
                return this.___Context_Attributes_antialias;
                case "premultipliedAlpha":
                    return this.___Context_Attributes_premultipliedAlpha;
                case "preserveDrawingBuffer":
                    return this.___Context_Attributes_preserveDrawingBuffer;
                    //                 --!>
                case "CW":
                    return this.CW;
                case "CCW":
                    return this.CCW;
                case "INVALID_FRAMEBUFFER_OPERATION":
                    return this.INVALID_FRAMEBUFFER_OPERATION;
                case "UNPACK_FLIP_Y_WEBGL":
                    return this.UNPACK_FLIP_Y_WEBGL;
                case "UNPACK_PREMULTIPLY_ALPHA_WEBGL":
                    return this.UNPACK_PREMULTIPLY_ALPHA_WEBGL;
                case "CONTEXT_LOST_WEBGL":
                    return this.CONTEXT_LOST_WEBGL;
                case "UNPACK_COLORSPACE_CONVERSION_WEBGL":
                    return this.UNPACK_COLORSPACE_CONVERSION_WEBGL;
                case "BROWSER_DEFAULT_WEBGL":
                    return this.BROWSER_DEFAULT_WEBGL;
                case "COLOR_CLEAR_VALUE":
                    return this.COLOR_CLEAR_VALUE;
                case "COLOR_WRITEMASK":
                    return this.COLOR_WRITEMASK;
                case "UNPACK_ALIGNMENT":
                    return this.UNPACK_ALIGNMENT;
                case "PACK_ALIGNMENT":
                    return this.PACK_ALIGNMENT;
                case "MAX_TEXTURE_SIZE":
                    return this.MAX_TEXTURE_SIZE;
                case "MAX_VEIWPORT_DIMS":
                    return this.MAX_VEIWPORT_DIMS;
                case "SUBPIXEL_BITS":
                    return this.SUBPIXEL_BITS;
                case "RED_BITS":
                    return this.RED_BITS;
                case "GREEN_BITS":
                    return this.GREEN_BITS;
                case "BLUE_BITS":
                    return this.BLUE_BITS;
                case "ALPHA_BITS":
                    return this.ALPHA_BITS;
                case "DEPTH_BITS":
                    return this.DEPTH_BITS;
                case "STENCIL_BITS":
                    return this.STENCIL_BITS;
                case "POLYGON_OFFSET_UNITS":
                    return this.POLYGON_OFFSET_UNITS;
                case "POLYGON_OFFSET_FACTOR":
                    return this.POLYGON_OFFSET_FACTOR;
                case "TEXTURE_BINDING_2D":
                    return this.TEXTURE_BINDING_2D;
                case "SAMPLE_BUFFERS":
                    return this.SAMPLE_BUFFERS;
                case "SAMPLES":
                    return this.SAMPLES;
                case "SAMPLE_COVERAGE_VALUE":
                    return this.SAMPLE_COVERAGE_VALUE;
                case "SAMPLE_COVERAGE_INVERT":
                    return this.SAMPLE_COVERAGE_INVERT;
                case "TEXTURE_BINDING_CUBE_MAP":
                    return this.TEXTURE_BINDING_CUBE_MAP;
                case "TEXTURE_CUBE_MAP_POSITIVE_X":
                    return this.TEXTURE_CUBE_MAP_POSITIVE_X;
                case "TEXTURE_CUBE_MAP_NEGATIVE_X":
                    return this.TEXTURE_CUBE_MAP_NEGATIVE_X;
                case "TEXTURE_CUBE_MAP_POSITIVE_Y":
                    return this.TEXTURE_CUBE_MAP_POSITIVE_Y;
                case "TEXTURE_CUBE_MAP_NEGATIVE_Y":
                    return this.TEXTURE_CUBE_MAP_NEGATIVE_Y;
                case "TEXTURE_CUBE_MAP_POSITIVE_Z":
                    return this.TEXTURE_CUBE_MAP_POSITIVE_Z;
                case "TEXTURE_CUBE_MAP_NEGATIVE_Z":
                    return this.TEXTURE_CUBE_MAP_NEGATIVE_Z;
                case "MAX_CUBE_MAP_TEXTURE_SIZE":
                    return this.MAX_CUBE_MAP_TEXTURE_SIZE;
                case "COMPRESSED_TEXTURE_FORMATS":
                    return this.COMPRESSED_TEXTURE_FORMATS;
                default:
                    object propValue = null;
                    if (this.___properties.TryGetValue(___name, out propValue) == true)
                    {

                        return propValue;

                    }
                    if (this.___CanvasPrototypeInstanceWeakReference != null)
                    {
                        CHtmlCanvasContext2D __prototypeCanvas = this.___CanvasPrototypeInstanceWeakReference.Target as CHtmlCanvasContext2D;
                        if (__prototypeCanvas != null)
                        {
                            if (__prototypeCanvas.___properties.TryGetValue(___name, out propValue) == true)
                            {
                                return propValue;
                            }
                        }

                    }
                    break;
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValue for {0} {1} '{2}' failed", this.GetType(), this, ___name);
            }
            return null;
        }
        #region  constants
        public int VENDOR
        {
            get
            {
                return (int)0x1F00;
            }
        }
        public int RENDERER
        {
            get
            {
                return (int)0x1F01;
            }
        }
        public int VERSION
        {
            get
            {
                return (int)0x1F02;
            }
        }
        public int SHADING_LANGUAGE_VERSION
        {
            get
            {
                return (int)0x8B8C;
            }
        }
        public int CURRENT_PROGRAM
        {
            get
            {
                return (int)0x8B8D;
            }
        }
        public int ZERO
        {
            get
            {
                return 0;
            }
        }
        public int ONE
        {
            get
            {
                return 1;
            }
        }
        public int SRC_COLOR
        {
            get
            {
                return (int)0x0300;
            }
        }
        public int ONE_MINUS_SRC_COLOR
        {
            get
            {
                return (int)0x0301;
            }
        }
        public int SRC_ALPHA
        {
            get
            {
                return (int)0x0302;
            }
        }
        public int ONE_MINUS_SRC_ALPHA
        {
            get
            {
                return (int)0x0303;
            }
        }
        public int DST_ALPHA
        {
            get
            {
                return (int)0x0304;
            }
        }
        public int ONE_MINUS_DST_ALPHA
        {
            get
            {
                return (int)0x0305;
            }
        }
        public int DST_COLOR
        {
            get
            {
                return (int)0x0306;
            }
        }
        public int ONE_MINUS_DST_COLOR
        {
            get
            {
                return (int)0x0307;
            }
        }
        public int SRC_ALPHA_SATURATE
        {
            get
            {
                return (int)0x0308;
            }
        }
        public int NEVER
        {
            get
            {
                return (int)0x0200;
            }
        }
        public int LESS
        {
            get
            {
                return (int)0x0201;
            }
        }
        public int EQUAL
        {
            get
            {
                return (int)0x0202;
            }
        }
        public int LEQUAL
        {
            get
            {
                return (int)0x0203;
            }
        }
        public int GREATER
        {
            get
            {
                return (int)0x0204;
            }
        }
        public int NOTEQUAL
        {
            get
            {
                return (int)0x0205;
            }
        }
        public int GEQUAL
        {
            get
            {
                return (int)0x0206;
            }
        }
        public int ALWAYS
        {
            get
            {
                return (int)0x0207;
            }
        }
        public int FUNC_ADD
        {
            get
            {
                return (int)0x8006;
            }
        }
        public int BLEND_EQUATION
        {
            get
            {
                return (int)0x8009;
            }
        }
        public int BLEND_EQUATION_RGB
        {
            get
            {
                return (int)0x8009;
            }
        }
        public int BLEND_EQUATION_ALPHA
        {
            get
            {
                return (int)0x803D;
            }
        }
        public int FUNC_SUBTRACT
        {
            get
            {
                return (int)0x800A;
            }
        }
        public int FUNC_REVERSE_SUBTRACT
        {
            get
            {
                return (int)0x800B;
            }
        }
        public int BLEND_DST_RGB 
        {
            get
            {
                return (int)0x80C8;
            }
        }
        public int BLEND_SRC_RGB
        {
            get
            {
                return (int)0x80C9;
            }
        }
        public int BLEND_DST_ALPHA
        {
            get
            {
                return (int)0x80CA;
            }
        }
        public int BLEND_SRC_ALPHA
        {
            get
            {
                return (int)0x80CB;
            }
        }
        public int CONSTANT_COLOR
        {
            get
            {
                return (int)0x8001;
            }
        }
        public int ONE_MINUS_CONSTANT_COLOR
        {
            get
            {
                return (int)0x8002;
            }
        }
        public int CONSTANT_ALPHA
        {
            get
            {
                return (int)0x8003;
            }
        }
        public int ONE_MINUS_CONSTANT_ALPHA
        {
            get
            {
                return (int)0x8004;
            }
        }
        public int BLEND_COLOR
        {
            get
            {
                return (int)0x8005;
            }
        }
        public int FRAGMENT_SHADER
        {
            get
            {
                return 35632;
            }
        }
        public int MAX_VERTEX_ATTRIBS
        {
            get { return (int)0x8869; }
        }
        public int MAX_VERTEX_UNIFORM_VECTORS
        {
            get { return (int)0x8DFB; }
        }
        public int MAX_VARYING_VECTORS 
        {
            get { return (int)0x8DFC; }
        }
        public int MAX_COMBINED_TEXTURE_IMAGE_UNITS
        {
            get { return (int)0x8B4D; }
        }
        public int MAX_VERTEX_TEXTURE_IMAGE_UNITS
        {
            get { return (int)0x8B4C; }
        }
        public int MAX_TEXTURE_IMAGE_UNITS
        {
            get { return (int)0x8872; }
        }
        public int MAX_FRAGMENT_UNIFORM_VECTORS
        {
            get { return (int)0x8DFD; }
        }
        public int SHADER_TYPE
        {
            get
            {
                return (int)0x8B4F;
            }
        }
        public int DELETE_STATUS
        {
            get
            {
                return (int)0x8B80;
            }
        }
        public int COMPILE_STATUS
        {
            get
            {
                return (int)0x8B81;
            }
        }
        public int VERTEX_SHADER
        {
            get
            {
                return 35633;
            }
        }
        public int ELEMENT_ARRAY_BUFFER
        {
            get
            {
                return (int)0x8893;
            }
        }
        public int ARRAY_BUFFER
        {
            get
            {
                return (int)0x8892;
            }
        }
        public int STATIC_DRAW
        {
            get
            {
                return (int)0x88E4;
            }
        }
        public int DYNAMIC_DRAW
        {
            get
            {
                return (int)0x88E8;
            }
        }
        public int STREAM_DRAW
        {
            get
            {
                return (int)0x88E0;
            }
        }
        public int VALIDATE_STATUS
        {
            get
            {
                return (int)0x8B83;
            }
        }
        public int ATTACHED_SHADERS
        {
            get
            {
                return (int)0x8B85;
            }
        }
        public int ACTIVE_ATTRIBUTES
        {
            get
            {
                return (int)0x8B89;
            }
        }
        public int ACTIVE_UNIFORMS
        {
            get
            {
                return (int)0x8B86;
            }
        }
        public int LINK_STATUS
        {
            get
            {
                return (int)0x8B82;
            }
        }
        public int CULL_FACE
        {
            get
            {
                return (int)0x0B44;
            }
        }
        public int BLEND
        {
            get
            {
                return (int)0x0BE2;
            }
        }
        public int DITHER
        {
            get
            {
                return (int)0x0BD0;
            }
        }
        public int STENCIL_TEST
        {
            get
            {
                return (int)0x0B90;
            }
        }
        public int DEPTH_TEST
        {
            get
            {
                return (int)0x0B71;
            }
        }
        public int SCISSOR_TEST
        {
            get
            {
                return (int)0x0C11;
            }
        }
        public int POLYGON_OFFSET_FILL
        {
            get
            {
                return (int)0x8037;
            }
        }
        public int SAMPLE_ALPHA_TO_COVERAGE
        {
            get
            {
                return (int)0x809E;
            }
        }
        public int SAMPLE_COVERAGE
        {
            get
            {
                return (int)0x80A0;
            }
        }
        public int POINTS
        {
            get { return 0; }
        }
        public int LINES
        {
            get
            {
                return 1;
            }
        }
        public int LINE_LOOP
        {
            get
            {
                return 2;
            }
        }
        public int LINE_STRIP
        {
            get
            {
                return 3;
            }
        }
        public int TRIANGLES
        {
            get
            {
                return 4;
            }
        }
        public int TRIANGLE_STRIP
        {
            get
            {
                return 5;
            }
        }
        public int TRIANGLE_FAN
        {
            get
            {
                return 6;
            }
        }
        public int TEXTURE_2D
        {
            get
            {
                return (int)0x0DE1;
            }
        }
        public int TEXTURE_CUBE_MAP
        {
            get
            {
                return (int)0x8513;
            }
        }
        public int FRONT
        {
            get
            {
                return (int)0x0404;
            }
        }
        public int BACK
        {
            get
            {
                return (int)0x0405;
            }
        }
        public int FRONT_AND_BACK
        {
            get
            {
                return (int)0x0408;
            }
        }

        public int BYTE
        {
            get
            {
                return (int)0x1400;
            }
        }
        public int UNSIGNED_BYTE
        {
            get
            {
                return (int)0x1401;
            }
        }
        public int SHORT
        {
            get
            {
                return (int)0x1402;
            }
        }
        public int UNSIGNED_SHORT
        {
            get
            {
                return (int)0x1403;
            }
        }
        public int INT
        {
            get
            {
                return (int)0x1404;
            }
        }
        public int UNSIGNED_INT
        {
            get
            {
                return (int)0x1405;
            }
        }
        public int FLOAT
        {
            get
            {
                return (int)0x1406;
            }
        }



        public int DEPTH_COMPONENT
        {
            get
            {
                return (int)0x1902;
            }
        }
        public int ALPHA
        {
            get
            {
                return (int)0x1906;
            }
        }
        public int RGB
        {
            get
            {
                return (int)0x1907;
            }
        }
        public int RGBA
        {
            get
            {
                return (int)0x1908;
            }
        }
        public int LUMINANCE
        {
            get
            {
                return (int)0x1909;
            }
        }
        public int LUMINANCE_ALPHA
        {
            get
            {
                return (int)0x190A;
            }
        }

        public int COLOR_BUFFER_BIT
        {
            get
            {
                return (int)0x00004000;
            }
        }
        public int DEPTH_BUFFER_BIT
        {
            get
            {
                return (int)0x00000100;
            }
        }
        public int STENCIL_BUFFER_BIT
        {
            get
            {
                return (int)0x00000400;
            }
        }
        public int TEXTURE0
        {
            get
            {
                return (int)0x84C0;
            }
        }
        public int TEXTURE1
        {
            get
            {
                return (int)0x84C1;
            }
        }
        public int TEXTURE2
        {
            get
            {
                return (int)0x84C2;
            }
        }
        public int TEXTURE3
        {
            get
            {
                return (int)0x84C3;
            }
        }
        public int TEXTURE4
        {
            get
            {
                return (int)0x84C4;
            }
        }
        public int TEXTURE5
        {
            get
            {
                return (int)0x84C5;
            }
        }
        public int TEXTURE6
        {
            get
            {
                return (int)0x84C6;
            }
        }
        public int TEXTURE7
        {
            get
            {
                return (int)0x84C7;
            }
        }
        public int TEXTURE8
        {
            get
            {
                return (int)0x84C8;
            }
        }
        public int TEXTURE9
        {
            get
            {
                return (int)0x84C9;
            }
        }
        public int TEXTURE10
        {
            get
            {
                return (int)0x84CA;
            }
        }
        public int TEXTURE11
        {
            get
            {
                return (int)0x84CB;
            }
        }
        public int TEXTURE12
        {
            get
            {
                return (int)0x84CC;
            }
        }
        public int TEXTURE13
        {
            get
            {
                return (int)0x84CC;
            }
        }
        public int TEXTURE14
        {
            get
            {
                return (int)0x84CE;
            }
        }
        public int TEXTURE15
        {
            get
            {
                return (int)0x84CF;
            }
        }
        public int TEXTURE16
        {
            get
            {
                return (int)0x84D0;
            }
        }
        public int TEXTURE17
        {
            get
            {
                return (int)0x84D1;
            }
        }
        public int TEXTURE18
        {
            get
            {
                return (int)0x84D1;
            }
        }
        public int TEXTURE19
        {
            get
            {
                return (int)0x84D3;
            }
        }
        public int TEXTURE20
        {
            get
            {
                return (int)0x84D3;
            }
        }
        public int TEXTURE21
        {
            get
            {
                return (int)0x84D5;
            }
        }
        public int TEXTURE22
        {
            get
            {
                return (int)0x84D6;
            }
        }
        public int TEXTURE23
        {
            get
            {
                return (int)0x84D7;
            }
        }
        public int TEXTURE24
        {
            get
            {
                return (int)0x84D8;
            }
        }
        public int TEXTURE25
        {
            get
            {
                return (int)0x84D9;
            }
        }
        public int TEXTURE26
        {
            get
            {
                return (int)0x84DA;
            }
        }
        public int TEXTURE27
        {
            get
            {
                return (int)0x84DB;
            }
        }
        public int TEXTURE28
        {
            get
            {
                return (int)0x84DC;
            }
        }
        public int TEXTURE29
        {
            get
            {
                return (int)0x84DD;
            }
        }
        public int TEXTURE30
        {
            get
            {
                return (int)0x84DE;
            }
        }
        public int TEXTURE31
        {
            get
            {
                return (int)0x84DF;
            }
        }
        public int ACTIVE_TEXTURE
        {
            get
            {
                return (int)0x84E0;
            }
        }
        public int COLOR_CLEAR_VALUE
        {
            get { return (int)0x0C22; }
        }
        public int COLOR_WRITEMASK
        {
            get { return (int)0x0C23; }
        }
        public int UNPACK_ALIGNMENT
        {
            get { return (int)0x0CF5; }
        }
        public int PACK_ALIGNMENT
        {
            get { return (int)0x0D05; }
        }
        public int MAX_TEXTURE_SIZE
        {
            get { return (int)0x0D33; }
        }
        public int MAX_VEIWPORT_DIMS
        {
            get { return (int)0x0D3A; }
        }
        public int SUBPIXEL_BITS
        {
            get { return (int)0x0050; }
        }
        public int RED_BITS
        {
            get { return (int)0x0052; }
        }
        public int GREEN_BITS
        {
            get { return (int)0x0053; }
        }
        public int BLUE_BITS
        {
            get { return (int)0x0054; }
        }
        public int ALPHA_BITS
        {
            get { return (int)0x0055; }
        }
        public int DEPTH_BITS
        {
            get { return (int)0x0056; }
        }
        public int STENCIL_BITS
        {
            get { return (int)0x0057; }
        }
        public int POLYGON_OFFSET_UNITS
        {
            get { return (int)0x2A00; }
        }
        public int POLYGON_OFFSET_FACTOR
        {
            get { return (int)0x8038; }
        }
        public int TEXTURE_BINDING_2D
        {
            get { return (int)0x8069; }
        }
        public int SAMPLE_BUFFERS
        {
            get { return (int)0x80A8; }
        }
        public int SAMPLES
        {
            get { return (int)0x80A9; }
        }
        public int SAMPLE_COVERAGE_VALUE
        {
            get { return (int)0x80AA; }
        }
        public int SAMPLE_COVERAGE_INVERT
        {
            get { return (int)0x80AB; }
        }

        public int TEXTURE_BINDING_CUBE_MAP
        {
            get { return (int)0x8514; }
        }
        public int TEXTURE_CUBE_MAP_POSITIVE_X
        {
            get { return (int)0x8515; }
        }
        public int TEXTURE_CUBE_MAP_NEGATIVE_X
        {
            get { return (int)0x8516; }
        }
        public int TEXTURE_CUBE_MAP_POSITIVE_Y
        {
            get { return (int)0x8517; }
        }
        public int TEXTURE_CUBE_MAP_NEGATIVE_Y
        {
            get { return (int)0x8518; }
        }
        public int TEXTURE_CUBE_MAP_POSITIVE_Z
        {
            get { return (int)0x8519; }
        }
        public int TEXTURE_CUBE_MAP_NEGATIVE_Z
        {
            get { return (int)0x851A; }
        }
        public int MAX_CUBE_MAP_TEXTURE_SIZE 
        {
            get { return (int)0x851C; }
        }
        public int COMPRESSED_TEXTURE_FORMATS
        {
            get { return (int)0x86A3; }
        }
        public int LOW_FLOAT
        {
            get { return (int)0x8DF0; }
        }
        public int MEDIUM_FLOAT
        {
            get { return (int)0x8DF1; }
        }
        public int HIGH_FLOAT
        {
            get { return (int)0x8DF2; }
        }
        public int LOW_INT
        {
            get { return (int)0x8DF3; }
        }
        public int MEDIUM_INT
        {
            get { return (int)0x8DF4; }
        }
        public int HIGH_INT
        {
            get { return (int)0x8DF5; }
        }
        public int FRAMEBUFFER
        {
            get
            {
                return (int)0x8D40;
            }
        }
        public int RENDERBUFFER
        {
            get
            {
                return (int)0x8D41;
            }
        }
        public int RGBA4
        {
            get
            {
                return (int)0x8056;
            }
        }
        public int RGB5_A1
        {
            get
            {
                return (int)0x8057;
            }
        }
        public int RGB565
        {
            get
            {
                return (int)0x8062;
            }
        }
        public int DEPTH_COMPONENT16
        {
            get
            {
                return (int)0x81A5;
            }
        }
        public int STENCIL_INDEX
        {
            get
            {
                return (int)0x1901;
            }
        }
        public int STENCIL_INDEX8
        {
            get
            {
                return (int)0x8D48;
            }
        }
        public int DEPTH_STENCIL
        {
            get
            {
                return (int)0x84F9;
            }
        }
        public int COLOR_ATTACHMENT0
        {
            get
            {
                return (int)0x8CE0;
            }
        }
        public int DEPTH_ATTACHMENT
        {
            get
            {
                return (int)0x8D000;
            }
        }
        public int STENCIL_ATTACHMENT
        {
            get
            {
                return (int)0x8D20;
            }
        }
        public int DEPTH_STENCIL_ATTACHMENT
        {
            get
            {
                return (int)0x821A;
            }
        }
        public int TEXTURE_MAG_FILTER
        {
            get
            {
                return (int)0x2800;
            }
        }
        public int TEXTURE_MIN_FILTER
        {
            get
            {
                return (int)0x2801;
            }
        }
        public int TEXTURE_WRAP_S
        {
            get
            {
                return (int)0x2802;
            }
        }
        public int TEXTURE_WRAP_T
        {
            get
            {
                return (int)0x2803;
            }
        }
        public int NEAREST
        {
            get
            {
                return (int)0x2600;
            }
        }
        public int LINEAR
        {
            get
            {
                return (int)0x2601;
            }
        }
        public int REPEAT
        {
            get
            {
                return (int)0x2901;
            }
        }
        public int CLAMP_TO_EDGE
        {
            get
            {
                return (int)0x812F;
            }
        }
        public int MIRRORED_REPEAT
        {
            get
            {
                return (int)0x8370;
            }
        }
        public int UNPACK_FLIP_Y_WEBGL
        {
            get
            {
                return (int)0x9240;
            }
        }
        public int UNPACK_PREMULTIPLY_ALPHA_WEBGL
        {
            get
            {
                return (int)0x9241;
            }
        }
        public int CONTEXT_LOST_WEBGL
        {
            get
            {
                return (int)0x9242;
            }
        }
        public int UNPACK_COLORSPACE_CONVERSION_WEBGL
        {
            get
            {
                return (int)0x9243;
            }
        }
        public int BROWSER_DEFAULT_WEBGL  
        {
            get
            {
                return (int)0x9244;
            }
        }
        public int INVALID_FRAMEBUFFER_OPERATION
        {
            get
            {
                return (int)0x0506;
            }
        }
        public int CW
        {
            get
            {
                return (int)0x0900;
            }
        }
        public int CCW
        {
            get
            {
                return (int)0x0901;
            }
        }


        #endregion
   
		public void ___setPropertyByName(string ___name, object val)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling SetPropertyValue for {0} \'{1}\' {2} = {3}", this.GetType(), this, ___name, val);
            }
            switch (___name)
			{

                case "alpha":
                    this.___Context_Attributes_alpha = commonData.convertObjectToBoolean(val);
                    break;
                case "depth":
                    this.___Context_Attributes_depth = commonData.convertObjectToBoolean(val);
                    break;
                case "stencil":
                    this.___Context_Attributes_stencil = commonData.convertObjectToBoolean(val);
                    break;
                case "antialias":
                    this.___Context_Attributes_antialias = commonData.convertObjectToBoolean(val);
                    break;
                case "premultipliedAlpha":
                    this.___Context_Attributes_premultipliedAlpha = commonData.convertObjectToBoolean(val);
                    break;
                case "preserveDrawingBuffer":
                    this.___Context_Attributes_preserveDrawingBuffer = commonData.convertObjectToBoolean(val);
                    break;
				case "font":
                case "FontSpec":
                    // We need to create font from value so set it in property
                    this.___setContextFont(val);
					break;
				case "textalign":
                case "textAlign":
                case "TextAlign":
					this.___contextTextAlignAsObject = val;
					break;
				case "textbaseline":
                case "textBaseline":
                case "textBaseLine":
					this.___contextTextBaseline = val;
					break;

                case "strokeStyle":

					break;
				case "fillstyle":
                case "fillStyle":
                case "FillStyle":


                    break;
				case "shadowcolor":
                case "shadowColor":
					this.___contextShadowColorAsObject = val;
					break;
				
                case "lineCap":
                case "LineCap":
					this.___contextLineCap = val;
					break;
                case "msImageSmoothingEnabled":
                case "mozImageSmoothingEnabled":
                case "webkitImageSmoothingEnabled":
                case "oImageSmoothingEnabled":
                case "imageSmoothingEnabled":
                    this.___CanvasImageSmoothingEnabled = commonData.convertObjectToBoolean(val);
                    break;
				
                case "lineWidth":
                case "LineWidth":
                    this.___contextLineWidth = ___ConvertNaNInfiniteToZero(commonData.GetDoubleFromObject(val, 0));
                    if (this.___contextLineWidth <= 0)
                    {
                        this.___contextLineWidth = 1;
                    }
                    if (this.___contextLineWidth == double.NegativeInfinity ||this.___contextLineWidth == double.PositiveInfinity)
                    {
                        this.___contextLineWidth = 1;
                    }
                    else if (this.___contextLineWidth == double.NaN)
                    {
                        this.___contextLineWidth = 1;
                    }

					break;
				case "shadowblur":
                case "shadowBlur":
                    this.___contextShadowBlur = ___ConvertNaNInfiniteToZero(commonData.GetDoubleFromObject(val, 0));
					break;
				case "shadowoffsetx":
                case "shadowoffsetX":
                case "shadowOffsetX":
                    this.___contextShadowOffsetX = ___ConvertNaNInfiniteToZero(commonData.GetDoubleFromObject(val, 0));
					break;
				case "shadowoffsetY":
                case "shadowOffsetY":
                    this.___contextShadowOffsetY = ___ConvertNaNInfiniteToZero(commonData.GetDoubleFromObject(val, 0));
					break;
				case "linejoin":
                case "lineJoin":
					this.___contextLineJoin = val;
					break;
				case "miterlimit":
                case "miterLimit":
                case "MiterLimit":
                    this.___contextMiterLimit = ___ConvertNaNInfiniteToZero(commonData.GetDoubleFromObject(val, 0));
					break;
				case "globalalpha":
                case "globalAlpha":
                case "GlobalAlpha":
                    this.___contextGlobalAlpha = ___ConvertNaNInfiniteToZero(commonData.GetDoubleFromObject(val, 1));
                    if (this.___contextGlobalAlpha >= 0  && this.___contextGlobalAlpha <= 1)
                    {
                        this.___contextGlobalAlphaAsInt255 = (int)(255F * this.___contextGlobalAlpha);
                    }else
                    {
                        this.___contextGlobalAlphaAsInt255 = -1;
                    }
					break;
                case "backingStorePixelRatio":
                    this.___BackingStorePixelRatio = ___ConvertNaNInfiniteToZero(commonData.GetDoubleFromObject(val, 0));
                    break;
				case "globalcompositeoperation":
                case "globalCompositeOperation":
                case "GlobalCompositeOperation":
                    this.___setGlobalCompositeOperationValue(val);
					break;
                case "width":
                case "Width":
                    double doubleWidth = ___ConvertNaNInfiniteToZero(commonData.GetDoubleFromObject(val, 0));
                    if (Math.Abs(doubleWidth - this.___CanvasWidth) > 1)
                    {
                        if (this.___parentElementWeakReference != null)
                        {
                            CHtmlElement ___owerElement = this.___parentElementWeakReference.Target as CHtmlElement;
                            if (___owerElement != null)
                            {
                                if (___owerElement.offsetWidth != doubleWidth)
                                {
                                    ___owerElement.___offsetWidth = doubleWidth;
       
                                    ___owerElement.___resetC2DBitmapImageBaseduponOffsetSize();
                                    this.___CanvasWidth = doubleWidth;
                                }

                            }
                        }
                    }

                    break;
                case "height":
                case "Height":
                    double doubleHeight = ___ConvertNaNInfiniteToZero(commonData.GetDoubleFromObject(val, 0));
                    if (Math.Abs(doubleHeight - this.___CanvasHeight) > 1)
                    {
                        if (this.___parentElementWeakReference != null)
                        {
                            CHtmlElement ___owerElement = this.___parentElementWeakReference.Target as CHtmlElement;
                            if (___owerElement != null)
                            {
                                if (___owerElement.___offsetHeight != doubleHeight)
                                {
                                    ___owerElement.___offsetHeight = doubleHeight;

                                    ___owerElement.___resetC2DBitmapImageBaseduponOffsetSize();
                                    this.___CanvasHeight = doubleHeight;
                                }
                            }
                        }
                    }
                    this.___CanvasHeight = doubleHeight;


                    break;

				default:
					bool ___ValueStored = false;
                    this.___properties[___name] = val;
                    ___ValueStored = true;

					if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
					{
						commonLog.LogEntry("SetPropertyValue for {0} {1}  '{2}' = {3} Success : {4}",this.GetType(), this, ___name, val, ___ValueStored );
					}
					break;
			}
		}
		
		public void ___setPropertyByIndex(int ___index, object val)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("SetPropertyValueIndex for {0} \'{1}\' {2} = {3} failed",this.GetType(), this, ___index, val);
			}
			
		}
		
		public object ___getPropertyByIndex(int ___index)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("___getPropertyByName by index {0} {1} {2} failed",this.GetType(), this, ___index);
			}
			return null;
		}
        public bool hasOwnProperty(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("entering {0}.hasOwnProperty({1})....",  this, ___name);
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
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("x__Clone {0} {1} called",this.GetType(), this);
			}
			return this;
		}
		public void ___deleteByIndex(int ___index)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___deleteByIndex {0} {1} called : {2}",this.GetType(), this, ___index);
			}
		}
		public void ___deleteByName(string ___name)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___deleteByName {0} {1} called : {2}",this.GetType(), this, ___name);
			}

		}
		public object[] ___getByIds()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___getByIds() {0} {1} called",this.GetType(), this);
			}
			return null;

		}
		public string ___getClassName()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___getClassName {0} {1} called",this.GetType(), this);
			}
			return this.GetType().Name;
		}
		public object ___getDefaultValue()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___getDefaultValue {0} {1} called",this.GetType(), this);
			}
			return null;
		}
		public object ___getParentScope()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___getParentScope {0} {1} called",this.GetType(), this);
			}
			return null;
		}
		public void ___setParentScope(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___setParentScope {0} {1} called : {2}",this.GetType(), this, ___object);
			}
		}
		public object ___getProtoType()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___getProtoType {0} {1} called",this.GetType(), this);
			}
			return null;
		}
		public bool ___hasInstance(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___hasInstance {0} {1} called : {2}",this.GetType(), this, ___object);
			}
			return false;
		}
		public bool ___instanceEquals(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___instanceEquals {0} {1} called : {2}",this.GetType(), this, ___object);
			}
			return object.ReferenceEquals(this, ___object);
		}
		public void ___setProtoType(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___setProtoType {0} {1} called : {2}",this.GetType(), this, ___object);
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
                case "AudioContext":
                    return CanvasContextModeType.AudioContext;

            }
            return CanvasContextModeType.OtherType;
        }
		#endregion
        private object ___CanvasWindowLockingObject = new object();

        private void ___CanvasContextTimerDoNothing(object ___state)
        {
            if (___ContextTimerDelay == 0) { ;}
            if (CONTEXT_TIMER_WATCH_INTERVAL == 50) { ;}


        }
        public void uniform1i(object ___location,object ___value)
        {

        }
        public void uniform3f(object ___location, object ___object_x, object ___object_y, object ___object_z)
        {

        }
        public void uniform4f(object ___objLocation, object ___object_x, object ___object_y, object ___object_z, object ___object_w)
        {

        }
        public void uniform4i(object ___objLocation, object ___object_x, object ___object_y, object ___object_z, object ___object_w)
        {

        }
        public void uniform1f(object ___location, object ___obj_x)
        {

        }
        public void uniform4fv(object ___objLocation, object ___value)
        {
        }
        public void uniformMatrix4fv(object ___object_location, object ___object_transpose, object ___object_value)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO: {0}.uniformMatrix4fv()", this, ___object_location, ___object_transpose, ___object_value);
            }
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

        public void blendFunc(object ___sfactor,object ___dfactor)
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
               commonLog.LogEntry("{0}.drawArrays({1}, {2}, {3})", this, ___mode,  ___first, ___count);
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
        public CHtmlCanvasWebGLExtention getExtension(object ____name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling {0}.getExtenstion({1})", this, ____name );
            }
            CHtmlCanvasWebGLExtention ___extenstionInfo = new  CHtmlCanvasWebGLExtention();
            return ___extenstionInfo;
        }
        public object getFramebufferAttachmentParameter(object ____target, object ____attachment, object ____pname)
        {
            return null;
        }
        public object getParameter(object ____pname)
        {
            return null;
        }
        public CHtmlCanvasWebGLShaderPrecisionFormat getShaderPrecisionFormat(object ____shaderType, object ____precisionType)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling {0}.getShaderPrecisionFormat()", this);
            }
            CHtmlCanvasWebGLShaderPrecisionFormat ___shaderFormat = new CHtmlCanvasWebGLShaderPrecisionFormat();

            return ___shaderFormat;
        }
        public object getShaderSource(object ____shader)
        {
            return null;
        }

        public object getTexParameter(object ____target, object ____pname)
        {
            return null;
        }
        public object getVertexAttrib(object ____index, object ____pname)
        {
            return null;
        }
        public object getVertexAttribOffset(object ____index, object ____pname)
        {
            return null;
        }
        public bool isEnabled(object ____capability)
        {
            return true;
        }
        public object pixelStorei(object ____pname, object ____param)
        {
            return null;
        }
        public void polygonOffset(object ____factor, object ____units)
        {

        }
        public void readPixels(object ____x, object ____y, object ____width, object ____height, object ____format, object ____type, object ____pixels)
        {

        }
        public void renderbufferStorage(object ____target, object ____internalformat, object ____width, object ____height)
        {

        }
        public void scissor(object ____x, object ____y, object ____width, object ____height)
        {
        }
        public void texImage2D(object ____target, object ____level, object ____internalformat, object ____width, object ____height, object ____border, object ____format, object ____type, object ____pixels)
        {
        }
        public void texImage2D(object ____p1, object ___p2, object ___p3, object ___p4, object ___p5, object ___p6)
        {
        }
        public int texParameterf(object ____target, object ____pname, object ____param)
        {
            return 0;
        }
        public void texParameteri(object ____target, object ____pname, object ____param)
        {

        }
        public void texSubImage2D(object ____target, object ____level, object ____xoffset, object ____yoffset, object ____width, object ____height, object ____format, object ____type, object ____pixels)
        {

        }
        public void uniform1fv(object ____location, object ____value)
        {
        }

        public void uniform1iv(object ____location, object ____value)
        {
        }
        public void uniform2f(object ____location, object ____x, object ____y)
        {

        }
        public void uniform2fv(object ____location, object ____value)
        {

        }
        public void uniform2i(object ____location, object ____x, object ____y)
        {

        }
        public void uniform2iv(object ____location, object ____value)
        {

        }

        public void uniform3fv(object ____location, object ____value)
        {

        }
        public void uniform3i(object ____location, object ____x, object ____y, object ____z)
        {

        }
        public void uniform3iv(object ____location, object ____v)
        {

        }
        public void uniformMatrix2fv(object ____location, object ____transpose, object ____value)
        {

        }
        public void uniformMatrix3fv(object ____location, object ____transpose, object ____value)
        {

        }
        #region AudioContext Related APIs
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
        private object ___decodeAudioDataCurrerntData =null;
        private object ___decodeAudioDataFunctionOject = null;
        /// <summary>
        ///The decodeAudioData() method of the BaseAudioContext Interface is used to asynchronously decode audio file data contained in an ArrayBuffer.In this case the ArrayBuffer is loaded from XMLHttpRequest and FileReader.The decoded AudioBuffer is resampled to the AudioContext's sampling rate, then passed to a callback or promise.
        /// This is the preferred method of creating an audio source for Web Audio API from an audio track.This method only works on complete file data, not fragments of audio file data.
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
            ___decodeAudioDataFunctionOject = ___objFunction;
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramfunc"></param>
        /// <param name="paramref"></param>
        /// <param name="parammask"></param>
        public void stencilFunc(object paramfunc, object paramref, object parammask)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling {0}.stencilFunc({1}, {2}, {3})", this, paramfunc , paramref, parammask);
            }
            return;
        }
        /// <summary>
        /// The WebGLRenderingContext.stencilOp() method of the WebGL API sets both the front and back-facing stencil test actions
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <param name=""></param>
        public void stencilOp(object paramfail, object paramzfail,object paramzpass)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling {0}.stencilOp({1}, {2}, {3})", this, paramfail, paramzfail, paramzpass);
            }
            return;
        }
        /// <summary>
        /// The WebGLRenderingContext.lineWidth() method of the WebGL API sets the line width of rasterized lines.
        /// Note) WebGL.lineWidth(float) may be used as canvas.context.lineWidth property
        /// we need to separate this someday...
        /// </summary>
        /// <param name="pwidth"></param>
        public void webglLineWidth(object pwidth)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling {0}.lineWidth({1})", this, pwidth);
            }
            return;
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
        #region IDyamicMetaObjectProvider support to get and set properties
        public DynamicMetaObject GetMetaObject(Expression parameter)
        {
            return new CHtmlClearScriptDynamicMetaObject<CHtmlCanvasContext2D>(parameter, this);
        }
        public object GetDynamicMember(string name)
        {
            object objValue = null;
            this.___properties.TryGetValue(name, out objValue);
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry("{0}.GetDynamicMember({1} returns : {2}", this, name, objValue);
            }

            return objValue;
        }
        public void SetDynamicMember(string name, object value)
        {
            
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry("{0}.SettDynamicMember({1} is called value: {2}", this, name, value);
            }
            this.___properties[name] = value;
        }
        public IEnumerable<string> GetDynamicMemberNames()
        {
            //var methodNames = this.GetType().GetMembers();
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry("{0}.GetDynamicMemberNames()( is called", this);
            }
            
            /*
            foreach(var nameOfMethod in  methodNames)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                {
                    commonLog.LogEntry("{0}.GetDynamicMember({1} is set for Method: {2}", this, nameOfMethod.Name, nameOfMethod);
                }
                this.___properties[nameOfMethod.Name] = nameOfMethod;
            }
            */

                ;
            return this.___properties.Keys;
        }
        #endregion
    }
}
