using System;
using System.Collections;


#if WINDOWS
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
#else
using System.Drawing; // assuming System.Drawing.Comon is aviable
#endif 


using System.Runtime.InteropServices;

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
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using SkiaSharp;
using Avalonia.Media.Imaging;




namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// Canvas Context
    /// </summary>

    public class CHtmlCanvasContext2D : CHtmlNode, IDynamicMetaObjectProvider, ICommonObjectInterface, System.IDisposable
    {
        #region ICommonObjectInterface Members
        public void ___setPropertyByName(string name, object val) => this.___properties[name] = val;
        public void ___setPropertyByIndex(int index, object val) => this.___properties[index.ToString()] = val;
        public object ___getPropertyByName(string name) => this.___properties.TryGetValue(name, out var val) ? val : null;
        public object ___getPropertyByIndex(int index) => this.___properties.TryGetValue(index.ToString(), out var val) ? val : null;
        public bool ___hasPropertyByName(string name) => this.___properties.ContainsKey(name);
        public bool ___hasPropertyByIndex(int index) => this.___properties.ContainsKey(index.ToString());
        public void ___deleteByIndex(int index) => this.___properties.Remove(index.ToString());
        public void ___deleteByName(string name) => this.___properties.Remove(name);
        public object[] ___getByIds() => this.___properties.Keys.Cast<object>().ToArray();
        public object ___getDefaultValue() => this.ToString();
        public object ___getProtoType() => ___CanvasPrototypeInstanceWeakReference?.Target;
        public void ___setProtoType(object __object) => ___CanvasPrototypeInstanceWeakReference = new WeakReference(__object);
        public void ___setParentScope(object __object) => ___MultiversalWindowWeakReference = new WeakReference(__object);
        public object ___getParentScope() => ___MultiversalWindowWeakReference?.Target;
        public string ___getClassName() => "CanvasRenderingContext2D";
        public bool ___hasInstance(object __object) => __object is CHtmlCanvasContext2D;
        public bool ___instanceEquals(object __object) => ReferenceEquals(this, __object);
        public object ___common_object_clone() => this.MemberwiseClone();
        #endregion

        private System.Collections.Generic.Stack<CHtmlCanvasState> ___CanvasStateStack = null;
        internal System.WeakReference ___CanvasPrototypeInstanceWeakReference = null;
        internal CHtmlCanvasContextAttributes ___contextAttributes = null;
        internal System.WeakReference ___MultiversalWindowWeakReference = null;
        internal static System.Collections.Generic.Dictionary<string, CHtmlFontInfo> ___canvasCHtmlFontInfoDictionary = new System.Collections.Generic.Dictionary<string, CHtmlFontInfo>();
        private static object ___canvasCHtmlFontInfoLockingObject = new object();
        private const int ___canvasCHtmlFontInfoMaximumEntries = 10000;
        private const double ___audioContextSampleRate = 48000;
        internal GraphicAPIType ___CanvasGraphicAPIType = GraphicAPIType.Unknown;
        internal bool ___needAvoidToCallCanvasActivityIntoDocument = false;
        /// <summary>
        /// Property names for Context Attributes
        /// </summary>
        internal static string[] ____Context_Attribute_Name_Array = new string[] { "alpha", "depth", "stencil", "antialias", "premultipliedAlpha", "preserveDrawingBuffer" };
        /// <summary>
        /// Graphics Object which is created with target Bitmap (which should be disposed just before drawing)
        /// </summary>

        private System.Drawing.Graphics ___CanvasImageObjectToGdiImage = null;
        private SKCanvas ___CanvasImageObjectToSkKBitmap = null;
        private float[] ___lineDashList;

        /// <summary>
        /// Canvas 2D Brush Object (This will be created or disposed when object is defiend)
        /// </summary>
        private System.Drawing.Brush ___canvas2DBrush = null;
        public static readonly Dictionary<string, int> CHtmlCanvasContext2Dproperties = createCHtmlCanvasContext2DProperties();

        private static Dictionary<string, int> createCHtmlCanvasContext2DProperties()
        {
            var dict = new Dictionary<string, int>();
            dict["fillStyle"] = 1;
            dict["strokeStyle"] = 2;
            dict["lineWidth"] = 3;
            dict["lineCap"] = 4;
            dict["lineJoin"] = 5;
            dict["miterLimit"] = 6;
            dict["font"] = 7;
            dict["textAlign"] = 8;
            dict["textBaseline"] = 9;
            dict["shadowColor"] = 10;
            dict["shadowBlur"] = 11;
            dict["shadowOffsetX"] = 12;
            dict["shadowOffsetY"] = 13;
            dict["globalAlpha"] = 14;
            dict["globalCompositeOperation"] = 15;




            return dict;
        }
        public static readonly Dictionary<string, int> CHtmlCanvasContext2Dmethods = createCHtmlCanvasContext2DMethods();

        private static Dictionary<string, int> createCHtmlCanvasContext2DMethods()
        {
            var dict = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
    {
        {"fillRect", 1},
        {"strokeRect", 2},
        {"beginPath", 3},
        {"moveTo", 4},
        {"lineTo", 5},
        {"arc", 6},
        {"arcTo", 7},
        {"bezierCurveTo", 8},
        {"quadraticCurveTo", 9},
        {"ellipse", 10},
        {"rect", 11},
        {"closePath", 12},
        {"fill", 13},
        {"stroke", 14},
        {"clearRect", 15},
        {"drawImage", 16},
        {"save", 17},
        {"restore", 18},
        {"setTransform", 19},
        {"resetTransform", 20},
        {"translate", 21},
        {"scale", 22},
        {"rotate", 23},
        {"getImageData", 24},
        {"putImageData", 25},
        {"createLinearGradient", 26},
        {"createRadialGradient", 27},
        {"createPattern", 28},
        {"measureText", 29},
        {"fillText", 30},
        {"strokeText", 31},
        {"getLineDash", 32},
        {"setLineDash", 33},
        {"clip", 34},
        {"isPointInPath", 35},
        {"flush", 36},
        {"drawElements", 37},

    };
            return dict;
        }
        public CHtmlCanvasContext2D()
        {

            //this.___PointFList = new System.Collections.Generic.List<System.Drawing.PointF>();
            this.___CanvasStateStack = new System.Collections.Generic.Stack<CHtmlCanvasState>();
#if WINDOWS
            this.___CanvasGdiGraphicPath = new GraphicsPath();
#endif

            this.___CanvasContextCreatedTime = DateTime.Now;



            this.___CanvasInstructionsList = new System.Collections.Generic.List<CHtmlCanvasContextInstruction>();

        }
        public CHtmlCanvasContext2D(bool isPrototype)
        {
            this.___properties = new System.Collections.Generic.Dictionary<string, object>(System.StringComparer.OrdinalIgnoreCase);

            this.___CanvasInstructionsList = new System.Collections.Generic.List<CHtmlCanvasContextInstruction>();

        }
        // Provide ClearScript with a stable host proxy to avoid dynamic binding paths
        public CHtmlClearScriptCanvasContextHostProxy GetClearScriptHostProxy()
        {
            return new CHtmlClearScriptCanvasContextHostProxy(this);
        }

        ~CHtmlCanvasContext2D()
        {

            this.___IsDisposing = true;
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
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

#if WINDOWS
        private System.Drawing.Image ___C2DSavedStateImage = null;
#endif
        /// <summary>
        /// If the background color ___hasInner been assigned or not.
        /// </summary>
        internal bool ___IsCanvasBackgroundSysColorSpecified = false;

        /// <summary>
        /// If backgroundColorSearch Tried once
        /// </summary>
        internal bool ___IsCanvasBackgroundSysColorSearchAttempted = false;
        internal ColorSpec ___CanvasBackgroundSysColor = new ColorSpec(0, 0, 0, 255);

        internal ColorSpec ___CanvasForegroundSysColor = new ColorSpec(0, 0, 0);

        internal PointFSpec ___CanvasTranslatePoint = new PointFSpec(0, 0);
        internal static PointF PointNaN = new PointF(float.NaN, float.NaN);
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
        internal System.WeakReference ___CanvasGdiImageWeakReference = null;
        internal System.WeakReference ___CanvasSkiaBitmapWeakReference = null;
        /// <summary>
        /// Brush for GDI+ 
        /// </summary>
        internal System.Drawing.Brush? ___CanvasGdiBrush = null;
        /// <summary>
        /// Brush for SkiaSharp
        /// </summary>
        internal SKPaint? ___CanvasSkiaFillPaint = null;
        internal SKPaint? ___CanvasSkiaStrokePaint = null;
        internal SKPaint? ___CanvasSkiaBrush = null;

        internal double ___CanvasWidth = 300;
        internal double ___CanvasHeight = 300;

        public double Width { get => ___CanvasWidth; set => ___CanvasWidth = value; }
        public double Height { get => ___CanvasHeight; set => ___CanvasHeight = value; }

        public static double ___getDegreeToRadian(double degree)
        {
            return degree * (Math.PI / 180.0);
        }

        public void beginPath()
        {
#if DEBUG
            try
            {
#endif
            if (this.___CanvasInstructionsList != null)
            {
                this.___CanvasInstructionsList.Clear(); // Clear previous instructions when beginning a new path 
                this.___CanvasInstructionsList.Add(new CHtmlCanvasContextInstruction { InstructionType = CanvasInstructionType.BeginPath });
            }
#if DEBUG
            }
            catch { }
#endif
#if WINDOWS
            if (this.___CanvasGdiGraphicPath != null) this.___CanvasGdiGraphicPath.Dispose();
            this.___CanvasGdiGraphicPath = new GraphicsPath();
#endif
#if !WINDOWS
            if (this.___CanvasSkiaGraphicPath != null) this.___CanvasSkiaGraphicPath.Dispose();
            this.___CanvasSkiaGraphicPath = new SKPath();
#endif
            this.___IsGraphicsPathOpen = true;
            this.___currentPointF = PointNaN; // Reset current point
        }

        public void closePath()
        {
            if (commonLog.LoggingEnabled)
            {
                System.Diagnostics.Debug.WriteLine("closePath() method called. Current instruction count: " + (this.___CanvasInstructionsList != null ? this.___CanvasInstructionsList.Count : 0));
            }
#if DEBUG
            try
            {
#endif
            if (this.___CanvasInstructionsList != null)
            {
                this.___CanvasInstructionsList.Add(new CHtmlCanvasContextInstruction { InstructionType = CanvasInstructionType.ClosePath });
            }
#if DEBUG
            }
            catch { }
#endif
#if WINDOWS
            if (this.___CanvasGdiGraphicPath != null) this.___CanvasGdiGraphicPath.CloseFigure();
#endif
#if !WINDOWS
            if (this.___CanvasSkiaGraphicPath != null) this.___CanvasSkiaGraphicPath.Close();
#endif
        }

        public void moveTo(double x, double y)
        {
            this.___currentPointF = new PointF((float)x, (float)y);
#if WINDOWS
            if (this.___CanvasGdiGraphicPath == null) this.___CanvasGdiGraphicPath = new GraphicsPath();
            this.___CanvasGdiGraphicPath.StartFigure();
#endif
#if !WINDOWS
            if (this.___CanvasSkiaGraphicPath == null) this.___CanvasSkiaGraphicPath = new SKPath();
            this.___CanvasSkiaGraphicPath.MoveTo((float)x, (float)y);
#endif
            if (this.___CanvasInstructionsList != null)
            {
                this.___CanvasInstructionsList.Add(new CHtmlCanvasContextInstruction { InstructionType = CanvasInstructionType.MoveTo, point = new PointFSpec((float)x, (float)y) });
            }
        }

        public void lineTo(double x, double y)
        {
            if (float.IsNaN(this.___currentPointF.X))
            {
                // If no current point exists, moveTo first then continue.
                // This keeps behavior consistent with other curve methods
                // (e.g. bezierCurveTo) which call moveTo when current point
                // is not set and then continue drawing.
                this.moveTo(x, y); // Act as moveTo if no current point exists
                // continue to add line (may become zero-length)
            }
#if WINDOWS
            if (this.___CanvasGdiGraphicPath == null) this.___CanvasGdiGraphicPath = new GraphicsPath();
            this.___CanvasGdiGraphicPath.AddLine(this.___currentPointF, new PointF((float)x, (float)y));
#endif
#if !WINDOWS
            if (this.___CanvasSkiaGraphicPath == null) this.___CanvasSkiaGraphicPath = new SKPath();
            this.___CanvasSkiaGraphicPath.LineTo((float)x, (float)y);
#endif
            this.___currentPointF = new PointF((float)x, (float)y);
            if (this.___CanvasInstructionsList != null)
            {
                this.___CanvasInstructionsList.Add(new CHtmlCanvasContextInstruction { InstructionType = CanvasInstructionType.LineTo, point = new PointFSpec((float)x, (float)y) });
            }
        }

        public void fillRect(double x, double y, double w, double h)
        {
            ___setCanvasActivityIntoDocument();
#if WINDOWS
            var gr = this.___getactiveC2DGraphicsFromBaseImage();
            if (gr != null)
            {
                if (this.___CanvasGdiBrush == null) ___createBrushFromFillStyleObject(Color.Black);
                gr.FillRectangle(this.___CanvasGdiBrush, (float)x, (float)y, (float)w, (float)h);
            }
#endif
#if !WINDOWS
            using (var skCanvas = this.___getActiveSkiaCanvasFromBaseImage())
            {
                if (skCanvas != null)
                {
                    if (this.___CanvasSkiaFillPaint == null || this.___contextFillStyleAsObject is CHtmlCanvasContextExtenstionObject) ___createBrushFromFillStyleObject(Color.Black);

                    var paint = this.___CanvasSkiaFillPaint;
                    byte originalAlpha = paint.Color.Alpha;
                    if (this.___contextGlobalAlpha < 1)
                    {
                        paint.Color = paint.Color.WithAlpha((byte)(this.___contextGlobalAlpha * originalAlpha));
                    }

                    paint.Style = SKPaintStyle.Fill;
                    skCanvas.DrawRect((float)x, (float)y, (float)w, (float)h, paint);

                    if (this.___contextGlobalAlpha < 1)
                    {
                        paint.Color = paint.Color.WithAlpha(originalAlpha);
                    }
                }
            }
#endif
            if (this.___CanvasInstructionsList != null)
            {
                this.___CanvasInstructionsList.Add(new CHtmlCanvasContextInstruction { InstructionType = CanvasInstructionType.FillRect, rectangle = new RectangleFSpec((float)x, (float)y, (float)w, (float)h) });
            }
        }

        public void strokeRect(double x, double y, double w, double h)
        {
            ___setCanvasActivityIntoDocument();
#if WINDOWS
            var gr = this.___getactiveC2DGraphicsFromBaseImage();
            if (gr != null)
            {
                if (this.___CanvasGdiBrush == null) ___createStrokeBrushInstance();
                using (var pen = new Pen(this.___CanvasGdiBrush, (float)this.___contextLineWidth))
                {
                    gr.DrawRectangle(pen, (float)x, (float)y, (float)w, (float)h);
                }
            }
#endif
#if !WINDOWS
             using (var skCanvas = this.___getActiveSkiaCanvasFromBaseImage())
             {
                 if (skCanvas != null)
                 {
                      if (this.___CanvasSkiaStrokePaint == null || this.___contextStrokeStyleAsObject is CHtmlCanvasContextExtenstionObject) ___createStrokeBrushInstance();
                      if (this.___CanvasSkiaStrokePaint == null) this.___CanvasSkiaStrokePaint = new SKPaint { Color = SKColors.Black, Style = SKPaintStyle.Stroke, IsAntialias = true };

                      var paint = this.___CanvasSkiaStrokePaint;
                      byte originalAlpha = paint.Color.Alpha;
                      if (this.___contextGlobalAlpha < 1)
                      {
                          paint.Color = paint.Color.WithAlpha((byte)(this.___contextGlobalAlpha * originalAlpha));
                      }

                      paint.Style = SKPaintStyle.Stroke;
                      paint.StrokeWidth = (float)this.___contextLineWidth;
                      skCanvas.DrawRect((float)x, (float)y, (float)w, (float)h, paint);

                      if (this.___contextGlobalAlpha < 1)
                      {
                          paint.Color = paint.Color.WithAlpha(originalAlpha);
                      }
                 }
             }
#endif
            if (this.___CanvasInstructionsList != null)
            {
                this.___CanvasInstructionsList.Add(new CHtmlCanvasContextInstruction { InstructionType = CanvasInstructionType.StrokeRect, rectangle = new RectangleFSpec((float)x, (float)y, (float)w, (float)h) });
            }
        }

        public void arc(double x, double y, double radius, double startAngle, double endAngle, bool anticlockwise)
        {
            if (double.IsNaN(x) || double.IsNaN(y) || double.IsNaN(radius) || double.IsNaN(startAngle) || double.IsNaN(endAngle))
                return;

            double startAngleDeg = startAngle * 180 / Math.PI;
            double endAngleDeg = endAngle * 180 / Math.PI;
            double sweepAngleDeg = endAngleDeg - startAngleDeg;

            if (anticlockwise)
            {
                if (sweepAngleDeg > 0) sweepAngleDeg -= 360;
                while (sweepAngleDeg < -360) sweepAngleDeg += 360;
            }
            else
            {
                if (sweepAngleDeg < 0) sweepAngleDeg += 360;
                while (sweepAngleDeg > 360) sweepAngleDeg -= 360;
            }

            if (Math.Abs(endAngle - startAngle) >= 2 * Math.PI)
            {
                sweepAngleDeg = anticlockwise ? -360 : 360;
            }

#if WINDOWS
            if (this.___CanvasGdiGraphicPath == null) this.___CanvasGdiGraphicPath = new GraphicsPath();
            float diameter = (float)radius * 2;
            this.___CanvasGdiGraphicPath.AddArc((float)(x - radius), (float)(y - radius), diameter, diameter, (float)startAngleDeg, (float)sweepAngleDeg);
#endif
#if !WINDOWS
            if (this.___CanvasSkiaGraphicPath == null) this.___CanvasSkiaGraphicPath = new SKPath();
            if (!float.IsNaN(this.___currentPointF.X))
            {
                this.___CanvasSkiaGraphicPath.ArcTo(new SKRect((float)(x - radius), (float)(y - radius), (float)(x + radius), (float)(y + radius)), (float)startAngleDeg, (float)sweepAngleDeg, false);
            }
            else
            {
                this.___CanvasSkiaGraphicPath.AddArc(new SKRect((float)(x - radius), (float)(y - radius), (float)(x + radius), (float)(y + radius)), (float)startAngleDeg, (float)sweepAngleDeg);
            }
#endif
            if (this.___CanvasInstructionsList != null)
            {
                this.___CanvasInstructionsList.Add(new CHtmlCanvasContextInstruction
                {
                    InstructionType = CanvasInstructionType.Arc,
                    point = new PointFSpec((float)x, (float)y),
                    radius = (float)radius,
                    startAngle = (float)startAngle,
                    endAngle = (float)endAngle,
                    anticlockwise = anticlockwise
                });
            }
            this.___currentPointF = new PointF((float)(x + radius * Math.Cos(endAngle)), (float)(y + radius * Math.Sin(endAngle)));
        }

        public void arcTo(double x1, double y1, double x2, double y2, double radius, bool v)
        {
            // Precise implementation of arcTo: create an arc tangent to the segments
            // from current point (p0) -> (x1,y1) and (x1,y1) -> (x2,y2) with given radius.
            if (double.IsNaN(x1) || double.IsNaN(y1) || double.IsNaN(x2) || double.IsNaN(y2) || double.IsNaN(radius))
                return;

            // If current point is not set, behave like moveTo(x1, y1)
            if (float.IsNaN(this.___currentPointF.X))
            {
                this.moveTo(x1, y1);
                return;
            }

            // Points
            var p0x = this.___currentPointF.X;
            var p0y = this.___currentPointF.Y;
            var p1x = (float)x1;
            var p1y = (float)y1;
            var p2x = (float)x2;
            var p2y = (float)y2;

            // Vectors from p1
            double ax = p0x - p1x;
            double ay = p0y - p1y;
            double bx = p2x - p1x;
            double by = p2y - p1y;

            double lenA = Math.Sqrt(ax * ax + ay * ay);
            double lenB = Math.Sqrt(bx * bx + by * by);

            // If either segment has zero length, just lineTo p1
            if (lenA < 1e-6 || lenB < 1e-6)
            {
                this.lineTo(x1, y1);
                return;
            }

            // Normalize
            double aux = ax / lenA;
            double auy = ay / lenA;
            double bux = bx / lenB;
            double buy = by / lenB;

            // Dot product and angle between vectors
            double dot = aux * bux + auy * buy;
            // If vectors are collinear or opposite, just lineTo p1
            if (dot > 0.999999 || dot < -0.999999)
            {
                this.lineTo(x1, y1);
                return;
            }

            double angle = Math.Acos(Math.Max(-1.0, Math.Min(1.0, dot)));
            double halfAngle = angle / 2.0;

            if (halfAngle <= 1e-9)
            {
                this.lineTo(x1, y1);
                return;
            }

            double r = Math.Abs(radius);

            // Distance from p1 to tangent points along the two segments
            double dist = r / Math.Tan(halfAngle);

            // Tangent points
            var t1x = p1x + (float)(aux * dist);
            var t1y = p1y + (float)(auy * dist);
            var t2x = p1x + (float)(bux * dist);
            var t2y = p1y + (float)(buy * dist);

            // Compute center along bisector direction
            double bisx = aux + bux;
            double bisy = auy + buy;
            double bisLen = Math.Sqrt(bisx * bisx + bisy * bisy);
            if (bisLen < 1e-9)
            {
                // Opposite directions, fallback
                this.lineTo(x1, y1);
                return;
            }

            double centerDist = r / Math.Sin(halfAngle);
            double cux = bisx / bisLen;
            double cuy = bisy / bisLen;

            var cx = p1x + (float)(cux * centerDist);
            var cy = p1y + (float)(cuy * centerDist);

            // Angles for arc
            double startAngle = Math.Atan2(t1y - cy, t1x - cx);
            double endAngle = Math.Atan2(t2y - cy, t2x - cx);

            // Determine sweep such that arc goes between tangent points inside the corner.
            double sweep = endAngle - startAngle;
            while (sweep <= -Math.PI) sweep += 2.0 * Math.PI;
            while (sweep > Math.PI) sweep -= 2.0 * Math.PI;

            // Determine rotation direction from cross product of (t1-center) x (t2-center)
            double cross = (t1x - cx) * (t2y - cy) - (t1y - cy) * (t2x - cx);
            bool anticlockwise = cross > 0.0;

            // Convert to degrees for GDI and Skia usage
            double startDeg = startAngle * 180.0 / Math.PI;
            double endDeg = endAngle * 180.0 / Math.PI;
            double sweepDeg = endDeg - startDeg;

            if (anticlockwise)
            {
                if (sweepDeg > 0) sweepDeg -= 360;
                while (sweepDeg < -360) sweepDeg += 360;
            }
            else
            {
                if (sweepDeg < 0) sweepDeg += 360;
                while (sweepDeg > 360) sweepDeg -= 360;
            }

#if WINDOWS
            if (this.___CanvasGdiGraphicPath == null) this.___CanvasGdiGraphicPath = new GraphicsPath();
            float diameter = (float)(r * 2.0);
            this.___CanvasGdiGraphicPath.AddLine(this.___currentPointF, new PointF((float)t1x, (float)t1y));
            this.___CanvasGdiGraphicPath.AddArc((float)(cx - r), (float)(cy - r), diameter, diameter, (float)startDeg, (float)sweepDeg);
            // move current point to arc end
            this.___CanvasGdiGraphicPath.AddLine(new PointF((float)t2x, (float)t2y), new PointF((float)t2x, (float)t2y));
#endif
#if !WINDOWS
            if (this.___CanvasSkiaGraphicPath == null) this.___CanvasSkiaGraphicPath = new SKPath();
            this.___CanvasSkiaGraphicPath.LineTo((float)t1x, (float)t1y);
            this.___CanvasSkiaGraphicPath.ArcTo(new SKRect((float)(cx - r), (float)(cy - r), (float)(cx + r), (float)(cy + r)), (float)startDeg, (float)sweepDeg, false);
#endif

            // Update current point to tangent end
            this.___currentPointF = new PointF((float)t2x, (float)t2y);

            if (this.___CanvasInstructionsList != null)
            {
                this.___CanvasInstructionsList.Add(new CHtmlCanvasContextInstruction
                {
                    InstructionType = CanvasInstructionType.ArcTo,
                    controlPoint1 = new PointFSpec((float)x1, (float)y1),
                    point = new PointFSpec((float)x2, (float)y2),
                    radius = (float)r,
                    startAngle = (float)startAngle,
                    endAngle = (float)endAngle
                });
            }
        }

        public void fill()
        {
            if(commonLog.LoggingEnabled && commonLog.LogLevel >=8)
            {
                commonLog.LogEntry($"{this}.fill() method called. Current instruction count: " + (this.___CanvasInstructionsList != null ? this.___CanvasInstructionsList.Count : 0));
            }
            ___setCanvasActivityIntoDocument();
#if DEBUG
            try
            {
#endif
            if (this.___CanvasInstructionsList != null)
            {
                this.___CanvasInstructionsList.Add(new CHtmlCanvasContextInstruction { InstructionType = CanvasInstructionType.Fill });
            }
#if DEBUG
            }
            catch { }
#endif
#if WINDOWS
            var gr = this.___getactiveC2DGraphicsFromBaseImage();
            if (gr != null)
            {
                if (this.___CanvasGdiBrush == null) ___createBrushFromFillStyleObject(Color.Black);
                gr.FillPath(this.___CanvasGdiBrush, this.___CanvasGdiGraphicPath);
            }
#endif
#if !WINDOWS
            using (var skCanvas = this.___getActiveSkiaCanvasFromBaseImage())
            {
                if (skCanvas != null && this.___CanvasSkiaGraphicPath != null)
                {
                    if (this.___CanvasSkiaFillPaint == null || this.___contextFillStyleAsObject is CHtmlCanvasContextExtenstionObject) ___createBrushFromFillStyleObject(Color.Black);

                    var paint = this.___CanvasSkiaFillPaint;
                    byte originalAlpha = paint.Color.Alpha;
                    if (this.___contextGlobalAlpha < 1)
                    {
                        paint.Color = paint.Color.WithAlpha((byte)(this.___contextGlobalAlpha * originalAlpha));
                    }

                    paint.Style = SKPaintStyle.Fill;
                    skCanvas.DrawPath(this.___CanvasSkiaGraphicPath, paint);

                    if (this.___contextGlobalAlpha < 1)
                    {
                        paint.Color = paint.Color.WithAlpha(originalAlpha);
                    }
                }
            }
#endif
        }

        public void ellipse(double x, double y, double rx, double ry, double rotation, double startAngle, double endAngle, bool anticlockwise)
        {
#if DEBUG
            try
            {
#endif
            if (this.___CanvasInstructionsList != null)
            {
                this.___CanvasInstructionsList.Add(new CHtmlCanvasContextInstruction
                {
                    InstructionType = CanvasInstructionType.Ellipse,
                    point = new PointFSpec((float)x, (float)y),
                    rx = (float)rx,
                    ry = (float)ry,
                    rotation = (float)rotation,
                    startAngle = (float)startAngle,
                    endAngle = (float)endAngle,
                    anticlockwise = anticlockwise
                });
            }
#if DEBUG
            }
            catch { }
#endif
#if WINDOWS
            if (this.___CanvasGdiGraphicPath == null) this.___CanvasGdiGraphicPath = new GraphicsPath();
            this.___CanvasGdiGraphicPath.AddEllipse((float)(x - rx), (float)(y - ry), (float)(rx * 2), (float)(ry * 2));
#endif
#if !WINDOWS
            if (this.___CanvasSkiaGraphicPath == null) {
                this.___CanvasSkiaGraphicPath = new SKPath();
            } else {
                this.___CanvasSkiaGraphicPath.Reset(); 
            }
            

            this.___CanvasSkiaGraphicPath.AddOval(new SKRect((float)(x - rx), (float)(y - ry), (float)(x + rx), (float)(y + ry)));


            var _matrix = SkiaSharp.SKMatrix.CreateRotation((float)rotation, (float)x, (float)y);
            this.___CanvasSkiaGraphicPath.Transform(_matrix);


#endif
        }

        public void ellipse(double x, double y, double rx, double ry, double rotation, double startAngle, double endAngle, int anticlockwise)
        {
            ellipse(x, y, rx, ry, rotation, startAngle, endAngle, anticlockwise != 0);
        }

        public void rect(double x, double y, double w, double h)
        {
            // Add rectangle to current path
            if (double.IsNaN(x) || double.IsNaN(y) || double.IsNaN(w) || double.IsNaN(h)) return;
#if WINDOWS
            if (this.___CanvasGdiGraphicPath == null) this.___CanvasGdiGraphicPath = new GraphicsPath();
            this.___CanvasGdiGraphicPath.AddRectangle(new RectangleF((float)x, (float)y, (float)w, (float)h));
#endif
#if !WINDOWS
            if (this.___CanvasSkiaGraphicPath == null) this.___CanvasSkiaGraphicPath = new SKPath();
            this.___CanvasSkiaGraphicPath.AddRect(new SKRect((float)x, (float)y, (float)(x + w), (float)(y + h)));
#endif
            if (this.___CanvasInstructionsList != null)
            {
                this.___CanvasInstructionsList.Add(new CHtmlCanvasContextInstruction { InstructionType = CanvasInstructionType.Rect, rectangle = new RectangleFSpec((float)x, (float)y, (float)w, (float)h) });
            }
        }

        public void bezierCurveTo(double cp1x, double cp1y, double cp2x, double cp2y, double x, double y)
        {
            if (float.IsNaN(this.___currentPointF.X))
            {
                this.moveTo(cp1x, cp1y);
            }
#if DEBUG
            try
            {
#endif
            if (this.___CanvasInstructionsList != null)
            {
                this.___CanvasInstructionsList.Add(new CHtmlCanvasContextInstruction
                {
                    InstructionType = CanvasInstructionType.BezierCurveTo,
                    controlPoint1 = new PointFSpec((float)cp1x, (float)cp1y),
                    controlPoint2 = new PointFSpec((float)cp2x, (float)cp2y),
                    point = new PointFSpec((float)x, (float)y)
                });
            }
#if DEBUG
            }
            catch { }
#endif
#if WINDOWS
            if (this.___CanvasGdiGraphicPath == null) this.___CanvasGdiGraphicPath = new GraphicsPath();
            this.___CanvasGdiGraphicPath.AddBezier(this.___currentPointF, new PointF((float)cp1x, (float)cp1y), new PointF((float)cp2x, (float)cp2y), new PointF((float)x, (float)y));
#endif
#if !WINDOWS
            if (this.___CanvasSkiaGraphicPath == null) this.___CanvasSkiaGraphicPath = new SKPath();
            this.___CanvasSkiaGraphicPath.CubicTo((float)cp1x, (float)cp1y, (float)cp2x, (float)cp2y, (float)x, (float)y);
#endif
            this.___currentPointF = new PointF((float)x, (float)y);
        }
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
        internal object ___contextFillStyleAsObject = null;
        /// <summary>
        /// Object is created last time
        /// </summary>
        private object ___contextFillStylePriorAsObject = null;

#if WINDOWS
        private System.Drawing.Brush ___contextBrushPriorClone = null;
        //private System.Collections.Generic.List<System.Drawing.PointF> ___PointFList = null;
        private System.Drawing.Drawing2D.GraphicsPath ___CanvasGdiGraphicPath = null;
#else
        // SkiaSharp Path
        private SKPath ___CanvasSkiaGraphicPath = null;

#endif
        private bool ___IsGraphicsPathOpen = false;
        /// <summary>
        /// ___currentPointF
        /// if not set it is (float.NaN, floatNaN)
        /// </summary>
        private System.Drawing.PointF ___currentPointF = PointNaN;
        private bool ___isMoveToPointNeedsToSetToPath = false;
        public bool ___IsDisposing = false;
#if WINDOWS
        // private bool ___IsPathClosed = false;
        /// <summary>
        /// TextureBrush Base Image (will be cloned).
        /// </summary>
        private Image ___BrushPatternImage = null;
#endif



        public object fillStyle
        {
            set
            {
                if (this.___canvas2DBrush != null)
                {
                    this.___canvas2DBrush.Dispose();
                    this.___canvas2DBrush = null;
                }
                this.___contextFillStyleAsObject = value;
                // Force recreation on next draw if it's an extension object (gradient/pattern)
                if (value is CHtmlCanvasContextExtenstionObject)
                {
                    this.___CanvasSkiaFillPaint = null;
                    this.___createBrushFromFillStyleObject(Color.Transparent);
                }
                else
                {
                    this.___createBrushFromFillStyleObject(Color.Transparent);
                }
            }
            get { return commonHTML.GetStringValue(this.___contextFillStyleAsObject); }
        }

        private object ___contextStrokeStyleAsObject = null;
        public object strokeStyle
        {
            set
            {
                this.___contextStrokeStyleAsObject = value;
                if (value is CHtmlCanvasContextExtenstionObject)
                {
                    this.___CanvasSkiaStrokePaint = null;
                }
                else
                {
                    this.___createStrokeBrushInstance();
                }
            }
            get { return this.___contextStrokeStyleAsObject; }
        }
        internal object ___contextDestination = null;


        private object ___contextShadowColorAsObject = null;

        public object shadowColor
        {
            set { this.___contextShadowColorAsObject = value; }
            get { return this.___contextShadowColorAsObject; }
        }

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
            set
            {
                this.___setContextFont(value);
            }
            get { return this.___contextFontAsObject; }

        }
        private void ___setContextFont(object value)
        {
            this.___contextFontAsObject = value;
            try
            {
                switch (___contextFontAsObject)
                {
                    case String str:
                        string ___strFont = str;
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



                                return;
                            }

                        }
                        break;
                    case NiL.JS.Core.JSValue nilvalue:
                        {
                            if (nilvalue.Value is string)
                            {
                                string ___strFontNilJs = nilvalue.Value as string;
                                if (string.IsNullOrEmpty(___strFontNilJs) == false && string.CompareOrdinal(___strFontNilJs, this.___contextFontAsString) == 0 && (this.___contextCHtmlFontInfo != null))
                                {
                                    // same font
                                    return;
                                }
                                if (string.IsNullOrEmpty(___strFontNilJs) == false)
                                {
                                    CHtmlFontInfo ___cachedFont = null;
                                    if (___canvasCHtmlFontInfoDictionary.TryGetValue(___strFontNilJs, out ___cachedFont))
                                    {
                                        this.___contextCHtmlFontInfo = ___cachedFont;
                                        this.___contextFontAsString = ___strFontNilJs;
                                        return;
                                    }
                                }
                            }
                            break;
                        }



                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                        {
                            commonLog.LogEntry("TODO: CHtmlCanvasContext.___setContextFont() for non string...");
                        }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
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
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 1000)
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
            this.___disposeC2DBitmapContext();

            if (this.___contextFillStylePriorAsObject != null)
            {
                this.___contextFillStylePriorAsObject = null;
            }
#if WINDOWS
            if (this.___contextBrushPriorClone != null)
            {
                this.___contextBrushPriorClone.Dispose();
                this.___contextBrushPriorClone = null;
            }
#endif

            if (this.___parentElementWeakReference != null)
            {
                this.___parentElementWeakReference = null;
            }
            if (this.___contextShadowColorAsObject != null)
            {
                this.___contextShadowColorAsObject = null;
            }
            if (this.___contextStrokeStyleAsObject != null)
            {
                this.___contextStrokeStyleAsObject = null;
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
#if WINDOWS
            if (this.___BrushPatternImage != null)
            {
                this.___BrushPatternImage.Dispose();
                this.___BrushPatternImage = null;
            }
#endif

            if (this.___contextCHtmlFontInfo != null)
            {
                this.___contextCHtmlFontInfo = null;
            }
#if WINDOWS
            if (this.___CanvasGdiGraphicPath != null)
            {
                this.___CanvasGdiGraphicPath.Dispose();
                this.___CanvasGdiGraphicPath = null;
            }
#endif
            this.___ContextTimerLockingObject = null;
            if (this.___CanvasStateStack != null)
            {

                this.___CanvasStateStack = null;
            }
            if (this.___CanvasInstructionsList != null)
            {

                this.___CanvasInstructionsList = null;
            }
#if WINDOWS
            if (this.___canvas2DBrush != null)
            {

                this.___canvas2DBrush.Dispose();
                this.___canvas2DBrush = null;
            }
#endif
#if WINDOwS
            if (this.___clearBackgroundSolidBrush != null)
            {
                this.___clearBackgroundSolidBrush.Dispose();
                this.___clearBackgroundSolidBrush = null;
            }
#endif
        }

        public string ContextMode
        {
            get { return this.___ContextMode; }
            set { this.___ContextMode = value; }
        }
        public CHtmlElement parentElement
        {
            get
            {
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
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("entering {0}.createLinearGradient({1},{2},{3},{4})", this, x0, y0, x1, y1);
            }
            CHtmlCanvasContextExtenstionObject __gradient = new CHtmlCanvasContextExtenstionObject(CanvasExtentionObjectType.LinerGradient);

            __gradient.___ownerCanvasContextWeakReference = new WeakReference(this, false);

            RectangleF gradientRect = new RectangleF((float)x0, (float)y0, (float)x1, (float)y1);
            __gradient.___baseRectangle1 = gradientRect;
            this.___contextFillStyleAsObject = __gradient;
            return __gradient;
        }
        public CHtmlCanvasContextExtenstionObject createLinearGradient(double x0, double y0, double x1, double y1, double p5)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
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
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
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
        /// createRadialGradient(startX,startY,startR,endX,endY,endR)
        /// 属性名／パラメーター	内　容
        /// ==============================
        /// startX	グラデーションの開始X座標を指定します。
        /// startY	グラデーションの開始Y座標を指定します。
        /// startR	最初の円の半径を指定します。
        /// endX	グラデーションの終了X座標を指定します。
        /// endY	グラデーションの終了Y座標を指定します。
        /// endR	終了の円の半径を指定します。
        /// </summary>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="r0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="r1"></param>
        /// <returns></returns>
        public CHtmlCanvasContextExtenstionObject createRadialGradient(double x0, double y0, double r0, double x1, double y1, double r1)
        {
            x0 = double.IsNaN(x0) ? 0 : x0;
            y0 = double.IsNaN(y0) ? 0 : y0;
            r0 = double.IsNaN(r0) ? 0 : r0;
            x1 = double.IsNaN(x1) ? 0 : x1;
            y1 = double.IsNaN(y1) ? 0 : y1;
            r1 = double.IsNaN(r1) ? 0 : r1;

            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("entering {0}.createRadialGradient({1},{2},{3},{4},{5},{6})", this, x0, y0, r0, x1, y1, r1);
            }
            CHtmlCanvasContextExtenstionObject __gradient = new CHtmlCanvasContextExtenstionObject(CanvasExtentionObjectType.RadialGradient);
            __gradient.___ownerCanvasContextWeakReference = new WeakReference(this, false);
            RectangleF paramFirst = new RectangleF((float)x0, (float)y0, (float)r0, (float)r0);
            RectangleF paramSecond = new RectangleF((float)x1, (float)y1, (float)r1, (float)r1);
            __gradient.___baseRectangle1 = paramFirst;
            __gradient.___baseRectangle2 = paramSecond;
#if WINDOWS
            __gradient.___grapicPathWeakRef = new WeakReference(this.___CanvasGdiGraphicPath, false);
#endif
            return __gradient;

        }
        public CHtmlCanvasContextExtenstionObject createRadialGradient(double x0, double y0, double r0, double x1, double y1, object obj_r1)
        {
            double r1 = commonData.GetDoubleFromObject(obj_r1, 0);
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("entering {0}.createRadialGradient({1},{2},{3},{4},{5},{6})", this, x0, y0, r0, x1, y1, obj_r1);
            }
            CHtmlCanvasContextExtenstionObject __gradient = new CHtmlCanvasContextExtenstionObject(CanvasExtentionObjectType.RadialGradient);
            __gradient.___ownerCanvasContextWeakReference = new WeakReference(this, false);

            RectangleF paramFirst = new RectangleF((float)x0, (float)y0, (float)r0, (float)r0);
            RectangleF paramSecond = new RectangleF((float)x1, (float)y1, (float)r1, (float)r1);
            __gradient.___baseRectangle1 = paramFirst;
            __gradient.___baseRectangle2 = paramSecond;
#if WINDOWS
            __gradient.___grapicPathWeakRef = new WeakReference(this.___CanvasGdiGraphicPath, false);
#endif
            return __gradient;

        }
        /// <summary>
        /// The WebGLRenderingContext.getError() method of the WebGL API returns error information.
        /// </summary>
        /// <returns>0: no error</returns>
        public object getError()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
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
            _byteArray.___BYTES_PER_ELEMENT = 1;
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
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
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
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("createImageData with 1 parameter: {0}", imageObject);
            }
            try
            {
                if (commonHTML.isClrNumeric(imageObject))
                {
                    double doubleValue = commonData.GetDoubleFromObject(imageObject, 0);
                    return this.___createImageDataInner(doubleValue, doubleValue);
                }
                else
                {
                    throw new NotSupportedException();

                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
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
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("entering {0}.getImageDataInner({1}, {2}, {3}, {4})...", this, p1, p2, p3, p4);
            }
#if WINDOWS
            System.Drawing.Graphics ___grAdhocContext = null;
#else
            switch (commonHTML.GraphicApiType)
            {
                case GraphicAPIType.Avalonia:
                case GraphicAPIType.SkiaSharp:
                    SkiaSharp.SKCanvas ___grSkiaGraphicsContext = null;
                    break;
            }
#endif
            CHtmlNativeArray _byteArrayList = new CHtmlNativeArray(CHtmlNumericArrayType.Uint8ClampedArray);
            double ___x1 = 0;
            double ___y1 = 0;
            double ___width1 = 0;
            double ___height1 = 0;
      
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
                    // PixelFormat.Format32bppPArgb shoud not be used for caluculations
                    // ===================================================
#if WINDOWS
                    System.Drawing.Bitmap targetBmp = null;
                    targetBmp = new System.Drawing.Bitmap((int)___width1, (int)___height1, PixelFormat.Format32bppArgb);



                    if (this.___CanvasGdiImageWeakReference != null)
                    {
                        srcImage = this.___CanvasGdiImageWeakReference.Target as Image;
                    }
                    if (srcImage != null)
                    {
                        this.___disposeC2DBitmapContext();
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


                    _byteArrayList.___byteArray = this.___ImageGDIBitmapToBytes(targetBmp);
                    _byteArrayList.___arrayLength = _byteArrayList.___byteArray.Length;
                    imageDateResult.width = ___width1;
                    imageDateResult.height = ___height1;
                    imageDateResult.data = _byteArrayList;
#else

                    switch (commonHTML.GraphicApiType)
                    {
                        case GraphicAPIType.Avalonia:
                        case GraphicAPIType.SkiaSharp:
                            {
                                SkiaSharp.SKBitmap srcSkiaSharpBitmap = null;
                                if (this.___CanvasSkiaBitmapWeakReference != null)
                                {
                                     srcSkiaSharpBitmap = this.___CanvasSkiaBitmapWeakReference.Target as SkiaSharp.SKBitmap;
                                    if (srcSkiaSharpBitmap != null)
                                    {
                                        int sx = (int)___x1;
    int sy = (int)___y1;
    int swidth = (int)___width1;
    int sheight = (int)___height1;
    
    // 全体のピクセルスパンを取得
    var fullPixelSpan = srcSkiaSharpBitmap.GetPixelSpan();
    int stride = srcSkiaSharpBitmap.RowBytes / 4; // 1ピクセル = 4バイト
    
    // 指定領域のピクセルデータを作成
    byte[] pixelBytes = new byte[swidth * sheight * 4];
    
    int destIndex = 0;
    for (int y = sy; y < sy + sheight; y++)
    {
        int srcStartIndex = (y * stride + sx) * 4;
        Array.Copy(srcSkiaSharpBitmap.Bytes, srcStartIndex, pixelBytes, destIndex, swidth * 4);
        destIndex += swidth * 4;
    }
    
    var skiaArrayListSkiaData = new CHtmlCanvas2DImageData();


    skiaArrayListSkiaData.data = new CHtmlNativeArray(CHtmlNumericArrayType.Uint8ClampedArray)
    {
        ___byteArray = pixelBytes,
        ___arrayLength = pixelBytes.Length,
        ___width = swidth,
        ___height = sheight,
        ___BYTES_PER_ELEMENT = 1
    };
    skiaArrayListSkiaData.width = swidth;
    skiaArrayListSkiaData.height = sheight;
     skiaArrayListSkiaData.___height = sheight;
    return skiaArrayListSkiaData;
                                    }
                                }
                                if (srcImage != null)
                                {
                                }
                                break;
                                }

                                }
#endif
                }
                else
                {
                    throw new NotSupportedException("getImageData is only supported in 2D or SVG context");
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("Canvas getImageDataInner Failed. ", ex);
                }
            }
#if WINDOWS
            if (___grAdhocContext != null)
            {
                ___grAdhocContext.Dispose();
                ___grAdhocContext = null;

            }
#else
#endif


            return imageDateResult;
        }
        private byte[] ___ImageGDIBitmapToBytes(System.Drawing.Bitmap bmp)
        {
#if WINDOWS
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
#else
            return new byte[] { };
#endif




        }
        private void ___swapBitmapByteOrder(ref byte[] bts)
        {
            int len = bts.Length;
            for (int pos = 0; pos < len - 4; pos = pos + 4)
            {
                byte b1 = bts[pos];
                byte b3 = bts[pos + 2];
                bts[pos] = b3;
                bts[pos + 2] = b1;
            }
        }


        public void putImageData(object _imageData, object p1, object p2)
        {
            this.___putImageData_inner(_imageData, p1, p2, null, null, null, null);
        }
        public void putImageData(object _imageData, object p1, object p2, object dirtyX, object dirtyY, object dirtyWidth, object dirtyHeight)
        {
            this.___putImageData_inner(_imageData, p1, p2, dirtyX, dirtyY, dirtyWidth, dirtyHeight);
        }
        private void ___putImageData_inner(object _imageData, object p1, object p2, object dirtyX, object dirtyY, object dirtyWidth, object dirtyHeight)
        {
            double? p1Value = null;
            double? p2Value = null;
            double? dirtyXValue = null;
            double? dirtyYValue = null;
            double? dirtyWidthValue = null;
            double? dirtyHeightValue = null;
            if(p1 != null)
            {
                p1Value = commonData.GetDoubleFromObject(p1, 0);
            }
            if(p2 != null)
            {
                p2Value = commonData.GetDoubleFromObject(p2, 0);
            }
            if(dirtyX != null)
            {
                dirtyXValue = commonData.GetDoubleFromObject(dirtyX, 0);
            }
            if(dirtyY != null)
            {
                dirtyYValue = commonData.GetDoubleFromObject(dirtyY, 0);
            }
            if(dirtyWidth != null)
            {
                dirtyWidthValue = commonData.GetDoubleFromObject(dirtyWidth, 0);
            }
            if(dirtyHeight != null)
            {
                dirtyHeightValue = commonData.GetDoubleFromObject(dirtyHeight, 0);
            }

            CHtmlCanvas2DImageData imageDateResult = _imageData as CHtmlCanvas2DImageData;
            if (imageDateResult == null) return;

            // データがnullまたは空の場合は処理しない
            if (imageDateResult.data == null || imageDateResult.data.___byteArray == null || imageDateResult.data.___byteArray.Length == 0)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("putImageData: ImageData or byte array is null/empty");
                }
                return;
            }

        

#if WINDOWS
            try
            {



                if (this.___CanvasContextModeType == CanvasContextModeType.Canvas2D || this.___CanvasContextModeType == CanvasContextModeType.SVG)
                {
                    if (this.___CanvasGdiImageWeakReference != null)
                    {
                        Image targetImage = this.___CanvasGdiImageWeakReference.Target as Image;
                        if (targetImage is System.Drawing.Bitmap targetBmp)
                        {
                            this.___disposeC2DBitmapContext();

                            byte[] rgbValues = imageDateResult.data.___byteArray;
                            if (rgbValues != null)
                            {
                                int width = (int)imageDateResult.width;
                                int height = (int)imageDateResult.height;

                                Rectangle rect = new Rectangle((int)dirtyXValue, (int)dirtyYValue, (int)dirtyWidthValue, (int)dirtyHeightValue);

                                System.Drawing.Imaging.BitmapData bmpData =
                                 targetBmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

                                IntPtr ptr = bmpData.Scan0;
                                int bytes = bmpData.Stride * height;
                                byte[] targetRgbValues = new byte[bytes];
                                Array.Copy(rgbValues, targetRgbValues, Math.Min(rgbValues.Length, targetRgbValues.Length));

                                ___swapBitmapByteOrder(ref targetRgbValues);
                                System.Runtime.InteropServices.Marshal.Copy(targetRgbValues, 0, ptr, bytes);
                                targetBmp.UnlockBits(bmpData);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("Canvas putImageDataInner Failed. ", ex);
                }
            }
#else
            switch(commonHTML.GraphicApiType)
            {
                case GraphicAPIType.Avalonia:
                case GraphicAPIType.SkiaSharp:


                    if (this.___CanvasContextModeType == CanvasContextModeType.Canvas2D || this.___CanvasContextModeType == CanvasContextModeType.SVG)
                    {
                        var skiaBitmap = this.___CanvasSkiaBitmapWeakReference?.Target as SkiaSharp.SKBitmap;
                        if (skiaBitmap != null && imageDateResult.data != null )
                        {
                            byte[] rgbValues = imageDateResult.data.___byteArray;
                            int imageDataWidth = (int)imageDateResult.width;
                            int imageDataHeight = (int)imageDateResult.height;
                            if (imageDataWidth == skiaBitmap.Width && imageDataHeight == skiaBitmap.Height)
                            {
                                IntPtr dstPixels = skiaBitmap.GetPixels();


                                System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, dstPixels, rgbValues.Length);
                            }
                            else
                            {
                                              if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                {
                    commonLog.LogEntry($"putImageData with size diff {rgbValues.Length} vs {imageDateResult.width * imageDateResult.height * 4}: {imageDateResult.width}, height: {imageDateResult.height}");
                }
                                var skiaImageDataImage = getRgbaBytesToSkiaBitmap(rgbValues, (int)imageDateResult.width, (int)imageDateResult.height);
                                using (var canvas = new SkiaSharp.SKCanvas(skiaBitmap))
                                {
                                    
                                    canvas.DrawBitmap(skiaImageDataImage,(int) p1Value.Value, (int)p2Value.Value);

                                    // 確実に描画を確定させる
                                    canvas.Flush();
                                }

                            }
                        }
                    }
                        break;
                    
            }

#endif

            this.___ContextTimerDelay = 0;
            this.___setCanvasActivityIntoDocument();
        }
        private void ___drawImage_inner(object _image, double sx, double sy, double sw, double sh, double dx, double dy, double dw, double dh, int ____methodType)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("entering {0}.drawImage_inner({1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10})...", this, _image.GetType().FullName, sx, sy, sw, sh, dx, dy, dw, dh, ____methodType);
            }
#if WINDOWS
            System.Drawing.Image ___imageObject = null;
            bool IsIMGElementImageWeakReferenceNeedsToSetIfImageFound = false;
            string targetFullUrl = null;

            System.Drawing.Graphics ___gractiveContext = null;
            Type ___imgType = null;

            sx = double.IsNaN(sx) ? 0 : sx;
            sy = double.IsNaN(sy) ? 0 : sy;
            sw = double.IsNaN(sw) ? 0 : sw;
            sh = double.IsNaN(sh) ? 0 : sh;
            dx = double.IsNaN(dx) ? 0 : dx;
            dy = double.IsNaN(dy) ? 0 : dy;
            dw = double.IsNaN(dw) ? 0 : dw;
            dh = double.IsNaN(dh) ? 0 : dh;

            if (_image == null)
            {
                return;
            }
            if (this.___IsDisposing == true)
            {
                return;
            }


            CHtmlElement ___imgElement = null;
            try
            {
                // 1. Obtain image url section.
                string ___srcUrl = null;
                switch (_image)
                {
                    case CHtmlElement _imgElement:
                        ___imgElement = _imgElement;
#if DEBUG
                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                        {
                            commonLog.LogEntry("drawImage() called with CHtmlImageElement {0} src='{1}'", _imgElement.toLogString(), _imgElement.src);
                        }
#endif
                        break;
                    case NiL.JS.Core.JSValue nilImageValue:
                        if (nilImageValue.Value is CHtmlElement)
                        {
                            ___imgElement = nilImageValue.Value as CHtmlElement;
                        }
                        break;
                }


                if (___imgElement != null)
                {
                    switch (___imgElement.___elementTagType)
                    {
                        case CHtmlElementType.IMG:
                            {
                                if (___imgElement.___style != null)
                                {
                                    if (___imgElement.___style.___IMG_ImageWeakReference != null)
                                    {
                                        ___imageObject = ___imgElement.___style.___IMG_ImageWeakReference.Target as Image;
                                        if (___imageObject != null)
                                        {
                                            goto ImageMayBeObtained;
                                        }
                                    }
                                    else
                                    {
                                        IsIMGElementImageWeakReferenceNeedsToSetIfImageFound = true;
                                    }
                                }
                                ___srcUrl = ___imgElement.src;
                                goto ImageSrcObtained;

                            }
                        case CHtmlElementType.CANVAS:
                            {
                                if (___imgElement.___CanvasGdiImage != null)
                                {
                                    if (___imgElement.___canvasContextCurrent2D != null)
                                    {
                                        ___imgElement.___canvasContextCurrent2D.___disposeC2DBitmapContext();
                                    }
                                    ___imageObject = ___imgElement.___CanvasGdiImage;
                                    goto ImageMayBeObtained;
                                }
                            }
                            break;

                    }
                }
            ImageSrcObtained:
                if (string.IsNullOrEmpty(___srcUrl) == true)
                {
                    return;
                }
                string orignalSrc = ___srcUrl;

                ___imageObject = this.___GetImageFromDocumentWithUrl(___srcUrl, ref targetFullUrl);
                if (IsIMGElementImageWeakReferenceNeedsToSetIfImageFound == true && ___imageObject != null)
                {
                    if (___imgElement != null)
                    {
                        if (___imgElement.___style != null)
                        {
                            if (___imgElement.___style.___IMG_ImageWeakReference == null)
                            {
                                ___imgElement.___style.___IMG_ImageWeakReference = new WeakReference(___imageObject, false);
                            }
                            else
                            {
                                ___imgElement.___style.___IMG_ImageWeakReference.Target = ___imageObject;
                            }
                        }
                    }
                }
            ImageMayBeObtained:

                if (___imageObject == null)
                {
                    // ==============================================================================================
                    // Image Src Not Found Stage (Assuming srcUrl is complete)
                    // ==============================================================================================
                    if (string.IsNullOrEmpty(targetFullUrl) == false && targetFullUrl.StartsWith("http", StringComparison.Ordinal) == true)
                    {
                        CHtmlDocument ___ownerDocument = null;

                        if (this.___ownerDocumentWeakReference != null)
                        {
                            ___ownerDocument = this.___ownerDocumentWeakReference.Target as CHtmlDocument;
                        }
                        if (___ownerDocument == null)
                        {
                            return;
                        }
                        if (___ownerDocument.___PageRequestedUrlList.ContainsKey(targetFullUrl) == false)
                        {
                            /*
                            ___ownerDocument.___downloadviaQueue(targetFullUrl, "image", "", "", ___ownerDocument.___URL, "",Threading.IDrawingType.UrlImage, "", null, 0, UrlSourceType.Src, false);

                            */
                            return;
                        }
                        else
                        {
                            // may be download image failed... or pending
                            return;
                        }

                    }

                    return;
                    // ==============================================================================================
                }
                else
                {
                    ___imgType = ___imageObject.GetType();
                    if (this.___CanvasContextModeType == CanvasContextModeType.Canvas2D || this.___CanvasContextModeType == CanvasContextModeType.SVG)
                    {
                        if (this.___contextGlobalAlpha < 1)
                        {
                            try
                            {
                                Image opacityImage = ___changeOpacityImage(___imageObject, (float)this.___contextGlobalAlpha);
                                ___imageObject = null;
                                ___imageObject = opacityImage;
                            }
                            catch (Exception exOpacity)
                            {
                                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                                {
                                    commonLog.LogEntry("CHtmlCanvasContext image opacity operation failed. ", exOpacity);
                                }
                            }
                        }
                        var commonconvertBitmapOnCanvas = false;
                        if (commonconvertBitmapOnCanvas == true && ___imageObject != null && ___imageObject.PixelFormat != PixelFormat.Format32bppPArgb && ___imgElement != null)
                        {
                            System.Drawing.Bitmap ___bmpOriginal = null;
                            System.Drawing.Bitmap ___bmpNew = null;
                            System.Drawing.Graphics grNewBmp = null;

                            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                            {
                                commonLog.LogEntry("drawImage is not PAargbImage. converting...");
                            }
                            ___bmpOriginal = ___imageObject as System.Drawing.Bitmap;



                            ___bmpNew = new System.Drawing.Bitmap(___bmpOriginal.Width, ___bmpOriginal.Height, PixelFormat.Format32bppPArgb);
                            grNewBmp = System.Drawing.Graphics.FromImage(___bmpNew);

                            grNewBmp.DrawImageUnscaled(___bmpOriginal, 0, 0);



                            grNewBmp.Dispose();
                            grNewBmp = null;
                            if (this.___ownerDocumentWeakReference != null)
                            {
                                CHtmlDocument ___ownerDocument = this.___ownerDocumentWeakReference.Target as CHtmlDocument;
                                if (___ownerDocument != null && ___ownerDocument.___pargbConvertedBitmapList != null)
                                {
                                    if (System.Threading.Monitor.TryEnter(___ownerDocument.___pargbConvertedBitmapListLokingObject, 1000))
                                    {
                                        if (___imgElement.___srcBase != null && string.IsNullOrEmpty(___imgElement.___srcBase.___Href) == false)
                                        {
                                            ___ownerDocument.___pargbConvertedBitmapList[___imgElement.___srcBase.___Href] = ___bmpNew;
                                        }
                                        else
                                        {
                                            ___ownerDocument.___pargbConvertedBitmapList[___imgElement.___elementOID.ToString()] = ___bmpNew;
                                        }
                                        System.Threading.Monitor.Exit(___ownerDocument.___pargbConvertedBitmapListLokingObject);
                                    }
                                    ___imgElement.___style.___IMG_ImageWeakReference = null;
                                    ___imgElement.___style.___IMG_ImageWeakReference = new WeakReference(___bmpNew, false);
                                }
                            }
                            else
                            {
                                ___bmpNew.Dispose();
                                ___bmpNew = null;
                            }
                        }


                        ___gractiveContext = this.___getactiveC2DGraphicsFromBaseImage();

                        if (___gractiveContext != null)
                        {
                            /*
                            System.Drawing.Drawing2D.Matrix __matrix = ___activeGraphics.Transform;
                            float[] ___matrixElements = __matrix.Elements;
                            bool ___isTransformApplied = false;
                            if (___matrixElements[1] == 0 && ___matrixElements[0] == 1 && ___matrixElements[2] == 0 && ___matrixElements[3] == 1 && ___matrixElements[4] == 0 && ___matrixElements[5] == 0)
                            {
                                 // may be no transform on current Graphics 
                            }
                            else
                            {
                                // transforms have been applied. must use normal drawImage.
                                ___isTransformApplied = true;
                            }
                             */
                            switch (____methodType)
                            {
                                case 1:

                                    ___gractiveContext.DrawImageUnscaled(___imageObject, (int)dx, (int)dy);


                                    break;
                                case 2:

                                    ___gractiveContext.DrawImage(___imageObject, (int)dx, (int)dy, (int)dw, (int)dh);

                                    break;
                                case 3:
                                    /// ====================================================================
                                    //  C# Reference
                                    // public void DrawImage(
                                    // Image image,
                                    // Rectangle destRect,
                                    // Rectangle srcRect,
                                    // GraphicsUnit srcUnit
                                    //  )
                                    //
                                    //
                                    // =====================================================================
                                    if ((sw < ___imageObject.Width) && (sh < ___imageObject.Height))
                                    {

                                        ___gractiveContext.DrawImage(___imageObject, new RectangleF((float)dx, (float)dy, (float)dw, (float)dh), new RectangleF((float)sx, (float)sy, (float)sw, (float)sh), GraphicsUnit.Pixel);



                                    }
                                    else
                                    {
                                        // in WinformsGDI.Net, You can not draw same size image to drawimage. At least 1 pixel smaller than target image context
                                        // +-------------------------------------+
                                        // |+-------------------------------------+                                                    
                                        // ||                                     |
                                        // ||                                     |
                                        // ||                                     |
                                        // ||                                     |
                                        // +\-------------------------------------|
                                        //  +-------------------------------------+
                                        if ((sw >= ___imageObject.Width) && (sh >= ___imageObject.Height))
                                        {

                                            ___gractiveContext.DrawImage(___imageObject, new RectangleF((float)dx, (float)dy, (float)dw, (float)dh), new RectangleF((float)sx, (float)sy, (float)(___imageObject.Width - 1), (float)(___imageObject.Height - 1)), GraphicsUnit.Pixel);

                                        }
                                        else if ((dw >= ___imageObject.Width) && (dh < ___imageObject.Height))

                                        {

                                            ___gractiveContext.DrawImage(___imageObject, new RectangleF((float)dx, (float)dy, (float)dw, (float)dh), new RectangleF((float)sx, (float)sy, (float)(___imageObject.Width - 1), (float)sh), GraphicsUnit.Pixel);


                                        }
                                        else
                                        {
                                            ___gractiveContext.DrawImage(___imageObject, new RectangleF((float)dx, (float)dy, (float)dw, (float)dh), new RectangleF((float)sx, (float)sy, (float)sw, (float)(___imageObject.Height - 1)), GraphicsUnit.Pixel);

                                        }
                                    }
                                    // ___activeGraphics.DrawImageUnscaled(___imageObject, (int)dx, (int)dy, (int)dw, (int)dh);
                                    break;
                                default:


                                    ___gractiveContext.DrawImageUnscaled(___imageObject, (int)dx, (int)dy);

                                    break;
                            }
                        }


                        if (___imageObject != null)
                        {
                            // this is just reference DO NOT DISPOSE HERE.
                            ___imageObject = null;
                        }


                    }
                    else
                    {

                    }

                    this.___ContextTimerDelay = 0;
                }

            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry("CHtmlCanvasContext drawImage inner processing Errror]\t : ", ex);
                    commonLog.LogEntry("[CanvasImageInfo]\t : \r\n{0} Width: {1} Height: {2} ", ___imgType, this.___CanvasWidth, this.___CanvasHeight);
                    if (___imageObject == null)
                    {
                        commonLog.LogEntry("Strange... drawImage trying image which seems null...");
                    }
                    else
                    {

                        commonLog.LogEntry("[Target ImageInfo]\t :\rn Image Type : {0} Canvas Width : {1} Canvas Heigtht : {2}", ___imgType, this.___CanvasWidth, this.___CanvasHeight);

                        try
                        {
                            commonLog.LogEntry("[Target Imge Info]\t: {0}", ___imageObject);
                        }
                        catch { }
                        try
                        {
                            commonLog.LogEntry("[Target Imge DimimetionList]\t: {0}", ___imageObject.FrameDimensionsList);
                        }
                        catch { }
                        try
                        {
                            commonLog.LogEntry("[Target Pixel Format]\t: {0}", ___imageObject.PixelFormat);
                        }
                        catch
                        {
                            commonLog.LogEntry("\t\t\t\tPixelFormat  Error!!!");
                        }
                        try
                        {
                            commonLog.LogEntry("\t\t\t\tWidth\t: {0}", ___imageObject.Width);
                        }
                        catch
                        { }
                        try
                        {
                            commonLog.LogEntry("\t\t\t\tHeight\t: {0}", ___imageObject.Height);
                        }
                        catch { }


                        try
                        {
                            commonLog.LogEntry("\t\t\t\tFrameDimenstionList\t: {0}", ___imageObject.FrameDimensionsList);
                        }
                        catch { }
                        try

                        {
                            commonLog.LogEntry(string.Concat("[Target Params]:\t", " sx=", sx, " sy=", sy, " sw=", sw, " sh=", sh, " dx=", dx, " dy=", dy, " dw=", dw, ", dh=", dh, ", methodType=", ____methodType));
                        }
                        catch { }
                    }
                }
            }



#else
            try
            {
                switch (commonHTML.GraphicApiType)
                {
                    case GraphicAPIType.Avalonia:
                    case GraphicAPIType.SkiaSharp:
                        {
                            if (_image == null || this.___IsDisposing) return;

                            sx = double.IsNaN(sx) ? 0 : sx;
                            sy = double.IsNaN(sy) ? 0 : sy;
                            sw = double.IsNaN(sw) ? 0 : sw;
                            sh = double.IsNaN(sh) ? 0 : sh;
                            dx = double.IsNaN(dx) ? 0 : dx;
                            dy = double.IsNaN(dy) ? 0 : dy;
                            dw = double.IsNaN(dw) ? 0 : dw;
                            dh = double.IsNaN(dh) ? 0 : dh;

                            SKBitmap skBitmapToDraw = null;
                            CHtmlElement imgElement = null;

                            if (_image is CHtmlElement elem)
                            {
                                if (elem.___elementTagType == CHtmlElementType.IMG )
                                {
                                    imgElement = elem;
                                }
                                else
                                {
                                   if(commonLog.LoggingEnabled && commonLog .LogLevel >= 5)
                                    {
                                        commonLog.LogEntry("CHtmlCanvasContext drawImage:. Image is not ImageEElement: {0} (elementTagType={1})", elem.toLogString(), elem.___elementTagType);
                                    }
                                    imgElement = elem;
                                }
                            }
                            else if (_image is NiL.JS.Core.JSValue nilValue && nilValue.Value is CHtmlElement elemNil)
                            {
                                imgElement = elemNil;
                            }

                            if (imgElement != null)
                            {
                                // Handle Canvas element - get SKBitmap directly from canvas
                                if (imgElement.___elementTagType == CHtmlElementType.CANVAS)
                                {
                                    if (imgElement.___CanvasSkiaBitmap != null)
                                    {
#if DEBUG
                                        SkiaSharp.SKBitmap ___canvasBitmap = imgElement.___CanvasSkiaBitmap;
                                        if(___canvasBitmap != null)
                                        {
                                            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                                            {
                                                commonLog.LogEntry("CHtmlCanvasContext drawImage: Saving canvas bitmap to 'canvas_image.png' for debugging. Canvas size: {0}x{1}", ___canvasBitmap.Width, ___canvasBitmap.Height);
                                            }
                                        }
                                        using (SKData data = ___canvasBitmap.Encode(SKEncodedImageFormat.Png,100))
                                        {
                                            if (data == null)
                                            {
                                                throw new InvalidOperationException("Fail to decode image data");
                                            }


                                            using (var stream = File.OpenWrite("canvas_image.png"))
                                            {
                                                data.SaveTo(stream);
                                            }
                                        }
#endif
                                        // Flush the canvas context if it exists
                                        if (imgElement.___canvasContextCurrent2D != null)
                                        {
                                            imgElement.___canvasContextCurrent2D.___disposeC2DBitmapContext();
                                        }
                                        skBitmapToDraw = imgElement.___CanvasSkiaBitmap;
                                        goto ImageObjectFound;
                                    }
                                }
                                // Handle IMG element
                                if (imgElement.___style.___IMG_SkiaBitmapWeakReference != null)
                                {

                                    if (imgElement.___style.___IMG_SkiaBitmapWeakReference is WeakReference<SKBitmap> weakRef)
                                    {
                                        if (weakRef.TryGetTarget(out skBitmapToDraw))
                                        {
                                            goto ImageObjectFound;
                                        }
                                    }
                                }
                                if (this.___ownerDocumentWeakReference != null && imgElement.___src != null)
                                {
                                    CHtmlDocument ___ownerDocument = this.___ownerDocumentWeakReference.Target as CHtmlDocument;
                                    if (___ownerDocument != null && ___ownerDocument.___imageRawConcurrentDictionaryForSKBitmap.TryGetValue(imgElement.___src, out skBitmapToDraw))
                                    {
                                        imgElement.___style.___IMG_SkiaBitmapWeakReference = new WeakReference<SKBitmap>(skBitmapToDraw, false);
                                        goto ImageObjectFound;
                                    }
                                }
                                else if (imgElement.___src == null && imgElement.___elementTagType != CHtmlElementType.CANVAS)
                                {
                                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                                    {
                                        commonLog.LogEntry("CHtmlCanvasContext drawImage: imgElement.___src is null for element {0} (elementTagType={1}). This may occur when: 1) IMG element's src is not set yet, 2) Dynamically created image without src.", imgElement.toLogString(), imgElement.___elementTagType);
                                    }
                                    goto ImageObjectFound;
                                }
                            }
                        ImageObjectFound:
                            if (skBitmapToDraw == null)
                            {
                                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                                {
                                    commonLog.LogEntry("CHtmlCanvasContext drawImage: Unable to obtain SKBitmap for the provided image object. This may occur when: 1) The image is still loading, 2) The image source is invalid, or 3) There is an issue with caching. Provided image object: {0}", _image);
                                }
                                return; // Only return when bitmap is null
                            }

                            // Draw the bitmap
                            if (skBitmapToDraw != null)
                            {
                                using (var skCanvas = this.___getActiveSkiaCanvasFromBaseImage())
                                {
                                    if (skCanvas != null)
                                    {
                                        using (var paint = new SKPaint())
                                        {
                                            paint.IsAntialias = true;
                                            paint.FilterQuality = SKFilterQuality.High;
                                            if (this.___contextGlobalAlpha < 1)
                                            {
                                                paint.Color = paint.Color.WithAlpha((byte)(this.___contextGlobalAlpha * 255));
                                            }

                                            switch (____methodType)
                                            {
                                                case 1:
                                                    skCanvas.DrawBitmap(skBitmapToDraw, (float)dx, (float)dy, paint);
                                                    break;
                                                case 2:
                                                    skCanvas.DrawBitmap(skBitmapToDraw, new SKRect((float)dx, (float)dy, (float)(dx + dw), (float)(dy + dh)), paint);
                                                    break;
                                                case 3:
                                                    skCanvas.DrawBitmap(skBitmapToDraw,
                                                        new SKRect((float)sx, (float)sy, (float)(sx + sw), (float)(sy + sh)),
                                                        new SKRect((float)dx, (float)dy, (float)(dx + dw), (float)(dy + dh)),
                                                        paint);
                                                    break;
                                                default:
                                                    skCanvas.DrawBitmap(skBitmapToDraw, (float)dx, (float)dy, paint);
                                                    break;
                                            }
                                        }
                                    }
                                }
                            }
                            this.___ContextTimerDelay = 0;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry("CHtmlCanvasContext drawImage SkiaSharp processing Error: ", ex);
                }
            }
#endif

            ___setCanvasActivityIntoDocument();

        }
        internal static System.Drawing.Bitmap ___changeOpacityImage(System.Drawing.Image img, float opacityvalue)
        {
#if WINDOWS

            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img.Width, img.Height); // Determining Width and Height of Source Image
            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bmp);
            ColorMatrix colormatrix = new ColorMatrix();
            colormatrix.Matrix33 = opacityvalue;
            ImageAttributes imgAttribute = new ImageAttributes();
            imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            graphics.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttribute);
            graphics.Dispose();   // Releasing all resource used by graphics 
            return bmp;
#else
             return null;
#endif

        }
        /// <summary>
        /// dispose canvas context 2D bitmap if exists.
        /// Note: this method should be called just before drawing.
        /// </summary>
        public void ___disposeC2DBitmapContext()
        {
#if WINDOWS
            if (this.___CanvasImageObjectToGdiImage != null)
            {
                this.___CanvasImageObjectToGdiImage.Dispose();
                this.___CanvasImageObjectToGdiImage = null;
            }
#endif
        }
#if WINDOWS

        private System.Drawing.Graphics ___getactiveC2DGraphicsFromBaseImage()
        {

            System.Drawing.Graphics grTarget = null;
            System.Drawing.Image img = null;
            bool ___has2DGraphicsObtained = false;
            bool ___isCanvasInstructionListEmptry = false;
            if (this.___CanvasInstructionsList == null || this.___CanvasInstructionsList.Count == 0)
            {
                ___isCanvasInstructionListEmptry = true;
            }
            if (this.___CanvasImageObjectToGdiImage != null)
            {
                if (___isCanvasInstructionListEmptry == true)
                {
                    return this.___CanvasImageObjectToGdiImage;
                }
                else
                {

                    ___has2DGraphicsObtained = true;
                }
            }


            try
            {


                if (___has2DGraphicsObtained == false && this.___CanvasGdiImageWeakReference != null)
                {
                    img = this.___CanvasGdiImageWeakReference.Target as System.Drawing.Image;
                    if (img != null)
                    {

                        if (___has2DGraphicsObtained == false)
                        {
                            try
                            {

                                grTarget = System.Drawing.Graphics.FromImage(img);

                                // default 
                                // [Faster Mode]

                                if (commonHTML.runtimeCLRType == CLRType.MicrosoftCLR)
                                {
                                    // default 
                                    // [Faster Mode]

                                    grTarget.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor; // or NearestNeighbour
                                                                                                                             // Note) SmoothingMode.AntiAlias will make asteroid benchmark 18 % worse. Default is better.
                                    grTarget.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                                    grTarget.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Default;
                                    grTarget.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.Default;
                                    grTarget.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                                    if (this.___contextGlobalCompositionMode == CHtmlCanvasContextGlobalCompositionType.copy)
                                    {
                                        grTarget.CompositingMode = CompositingMode.SourceCopy;
                                    }
                                    else
                                    {
                                        grTarget.CompositingMode = CompositingMode.SourceOver;
                                    }


                                }
                                else

                                {
                                    grTarget.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default; // or NearestNeighbour
                                                                                                                     // Note) SmoothingMode.AntiAlias will make asteroid benchmark 18 % worse. Default is better.
                                    grTarget.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                                    grTarget.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Default;
                                    grTarget.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.Default;
                                    grTarget.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                                    if (this.___contextGlobalCompositionMode == CHtmlCanvasContextGlobalCompositionType.copy)
                                    {
                                        grTarget.CompositingMode = CompositingMode.SourceCopy;
                                    }
                                    else
                                    {
                                        grTarget.CompositingMode = CompositingMode.SourceOver;
                                    }

                                }











                                //grTarget.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                            }
                            catch
                            {
                                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 30)
                                {
                                    commonLog.LogEntry("CanvasContext Graphics retry....");
                                }
                            }
                        }

                    }
                }
                else if (___has2DGraphicsObtained == true)
                {
                    if (this.___CanvasImageObjectToGdiImage != null)
                    {
                        grTarget = this.___CanvasImageObjectToGdiImage;
                    }

                }
                else
                {

                    img = this.___CanvasGdiImageWeakReference.Target as System.Drawing.Image;
                    if (img != null)
                    {
                        grTarget = System.Drawing.Graphics.FromImage(img);

                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry("CanvasContext Graphics Failed....", ex);
                }
            }
            if (grTarget != null)
            {
                if (___isCanvasInstructionListEmptry == false)
                {

                    return this.___setC2DGraphicsInstructionProperties(grTarget);
                }
                else
                {
                    return grTarget;
                }

            }
            if (grTarget == null)
            {
                grTarget = System.Drawing.Graphics.FromImage(img);
            }
            if (grTarget == null)
            {
                throw new Exception("CanvasContext Graphics Failed to obtain Graphics from Canvas Image");
            }
            return grTarget;

        }



#endif

#if !WINDOWS
        /// <summary>
        /// Get active SkiaSharp canvas from base image for SkiaSharp/Avalonia platforms
        /// </summary>
        /// <returns></returns>
        private SKCanvas ___getActiveSkiaCanvasFromBaseImage()
        {
            SKCanvas skCanvas = null;
            SKBitmap skBitmap = null;
            bool ___hasSkiaCanvasObtained = false;
            bool ___isCanvasInstructionListEmpty = false;
            
            if (this.___CanvasInstructionsList == null || this.___CanvasInstructionsList.Count == 0)
            {
                ___isCanvasInstructionListEmpty = true;
            }
            
            try
            {
                if (this.___CanvasSkiaBitmapWeakReference != null)
                {
                    skBitmap = this.___CanvasSkiaBitmapWeakReference.Target as SKBitmap;
                    if (skBitmap != null)
                    {
                        skCanvas = new SKCanvas(skBitmap);
                        ___hasSkiaCanvasObtained = true;
                        
                        // Set default properties
                        // skCanvas.Clear(SKColors.Transparent); // Removed: clearing on every get wipes intermediate drawings
                    }
                }
                
                if (skCanvas != null)
                {
                    if (___isCanvasInstructionListEmpty == false)
                    {
                        return this.___setSkiaCanvasInstructionProperties(skCanvas);
                    }
                    else
                    {
                        return skCanvas;
                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry("SkiaSharp Canvas Failed....", ex);
                }
            }
            
            if (skCanvas == null)
            {
                throw new Exception("SkiaSharp Canvas Failed to obtain Canvas from Canvas Image");
            }
            return skCanvas;
        }

        /// <summary>
        /// Set SkiaSharp canvas instruction properties (transforms, clips, etc.)
        /// </summary>
        /// <param name="skCanvas"></param>
        /// <returns></returns>
        private SKCanvas ___setSkiaCanvasInstructionProperties(SKCanvas skCanvas)
        {
            int currentInstructCount = this.___CanvasInstructionsList.Count;
            try
            {
                for (int ic = 0; ic < currentInstructCount; ic++)
                {
                    CHtmlCanvasContextInstruction ___instruct = this.___CanvasInstructionsList[ic];
                    if (___instruct.InstructionType == CanvasInstructionType.Save)
                    {
                        skCanvas.Save();
                        continue;
                    }
                    else
                    {
                        switch (___instruct.InstructionType)
                        {
                            case CanvasInstructionType.ResetTransform:
                                skCanvas.ResetMatrix();
                                continue;
                            case CanvasInstructionType.Save:
                                skCanvas.Save();
                                continue;
                            case CanvasInstructionType.Restore:
                                skCanvas.Restore();
                                continue;
                            case CanvasInstructionType.Translate:
                                skCanvas.Translate(___instruct.point.X, ___instruct.point.Y);
                                continue;
                            case CanvasInstructionType.Rotate:
                                skCanvas.RotateDegrees(___instruct.floatValue);
                                continue;
                            case CanvasInstructionType.Scale:
                                skCanvas.Scale(___instruct.point.X, ___instruct.point.Y);
                                continue;
                            case CanvasInstructionType.Transform:
                            case CanvasInstructionType.SetTransform:
                                if (___instruct.matrix != null)
                                {
                                    try
                                    {
                                        // Convert CHtmlCanvasInstructionMatrix to SKMatrix
                                        // A: ScaleX, B: SkewY, C: SkewX, D: ScaleY, E: TransX, F: TransY
                                        SKMatrix skMatrix = new SKMatrix(
                                            (float)___instruct.matrix.A, (float)___instruct.matrix.C, (float)___instruct.matrix.E,
                                            (float)___instruct.matrix.B, (float)___instruct.matrix.D, (float)___instruct.matrix.F,
                                            0, 0, 1);

                                        if (___instruct.InstructionType == CanvasInstructionType.SetTransform)
                                        {
                                            skCanvas.SetMatrix(skMatrix);
                                        }
                                        else
                                        {
                                            skCanvas.Concat(skMatrix);
                                        }
                                    }
                                    catch (Exception transException)
                                    {
                                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                                        {
                                            commonLog.LogEntry("SkiaSharp Canvas Transform Operation Error", transException);
                                        }
                                        goto ReturnCanvasPhase;
                                    }
                                }
                                continue;
                            case CanvasInstructionType.Clip:
                                if (this.___CanvasSkiaGraphicPath != null)
                                {
                                    try
                                    {
                                        skCanvas.ClipPath(this.___CanvasSkiaGraphicPath);
                                    }
                                    catch (Exception clipex)
                                    {
                                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 30)
                                        {
                                            commonLog.LogEntry("SkiaSharp Canvas Clip Operation Error", clipex);
                                        }
                                    }
                                }
                                continue;
                        }
                    }
                }
            }
            catch (Exception exTransForm)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 30)
                {
                    commonLog.LogEntry("SkiaSharp Canvas TransForm Error", exTransForm);
                }
            }

        ReturnCanvasPhase:
            return skCanvas;
        }
#endif

        private System.Drawing.Graphics ___setC2DGraphicsInstructionProperties(System.Drawing.Graphics grTarget)
        {

            int currentInstructCount = this.___CanvasInstructionsList.Count;
            try
            {
                for (int ic = 0; ic < currentInstructCount; ic++)
                {
                    CHtmlCanvasContextInstruction ___instruct = this.___CanvasInstructionsList[ic];
                    if (___instruct.InstructionType == CanvasInstructionType.Save)
                    {
                        continue;
                    }
                    else
                    {
                        switch (___instruct.InstructionType)
                        {
                            case CanvasInstructionType.ResetTransform:
                                grTarget.ResetTransform();
                                continue;
                            case CanvasInstructionType.Translate:
                                grTarget.TranslateTransform(___instruct.point.X, ___instruct.point.Y);
                                continue;
                            case CanvasInstructionType.Rotate:
                                grTarget.RotateTransform(___instruct.floatValue);
                                continue;
                            case CanvasInstructionType.Scale:
                                grTarget.ScaleTransform(___instruct.point.X, ___instruct.point.Y);
                                continue;
                            case CanvasInstructionType.Transform:

                                if (___instruct.matrix != null)
                                {
                                    try
                                    {
                                        grTarget.Transform = commonData.convertCHtmlCanvasInstructionMatrixToSystemDrawing2DMatrix(___instruct.matrix) as System.Drawing.Drawing2D.Matrix;
                                    }
                                    catch (Exception transException)
                                    {
                                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                                        {
                                            commonLog.LogEntry("CanvasContext Graphics Transform Operation Error", transException);
                                        }
                                        goto ReturnGraphicsPhase;
                                    }
                                }
                                continue;
                            case CanvasInstructionType.SetTransform:
                                grTarget.ResetTransform();
                                if (___instruct.matrix != null)
                                {
                                    try
                                    {
                                        grTarget.Transform = commonData.convertCHtmlCanvasInstructionMatrixToSystemDrawing2DMatrix(___instruct.matrix) as System.Drawing.Drawing2D.Matrix; ;
                                    }
                                    catch (Exception transException)
                                    {
                                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                                        {
                                            commonLog.LogEntry("CanvasContext Graphics Transform Operation Error", transException);
                                        }
                                        goto ReturnGraphicsPhase;
                                    }
                                }
                                continue;
                            case CanvasInstructionType.Clip:
#if WINDOWS
                                if (this.___CanvasGdiGraphicPath != null)
                                {
                                    try
                                    {
                                        Region rgn = new Region(this.___CanvasGdiGraphicPath);
                                        grTarget.Clip = rgn;
                                    }
                                    catch (Exception clipex)
                                    {
                                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 30)
                                        {
                                            commonLog.LogEntry("CanvasContext Graphics Clip Operation Error", clipex);
                                        }
                                    }
                                }
#endif
                                continue;
                        }

                    }
                }
            }
            catch (Exception exTransFrom)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 30)
                {
                    commonLog.LogEntry("CanvasContext Graphics TransFrom Error", exTransFrom);
                }
            }

        ReturnGraphicsPhase:





            //grTarget.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            return grTarget;
        }
        public void clip()
        {
            if (commonLog.LoggingEnabled)
            {
                commonLog.LogEntry($"{this}.clip() method called. Current instruction count: {this.___CanvasInstructionsList.Count}");
            }
            if (___IsDisposing) return;

            try
            {
#if WINDOWS
                if (this.___CanvasContextModeType == CanvasContextModeType.Canvas2D || this.___CanvasContextModeType == CanvasContextModeType.SVG)
                {
                    this.___CanvasInstructionsList.Add(new CHtmlCanvasContextInstruction { InstructionType = CanvasInstructionType.Clip });
                    {
                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                        {
                            commonLog.LogEntry("CanvasContext clip() called CHtmlCanvasContextInstruction { InstructionType = CanvasInstructionType.Clip} is added to the instruction list.");
                        }
                    }
                }

#else




                this.___CanvasInstructionsList.Add(new CHtmlCanvasContextInstruction { InstructionType = CanvasInstructionType.Clip });
                    {
                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                        {
                            commonLog.LogEntry("CanvasContext clip() called CHtmlCanvasContextInstruction { InstructionType = CanvasInstructionType.Clip} is added to the instruction list.");
                        }
                    }
                
                
#endif
            }
            catch (ObjectDisposedException)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry("CanvasContext clip() called but object is already disposed.");
                }
            }
        }

        /// <summary>
        /// Draw Line Method
        /// </summary>
		public void stroke()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("entering CanvasContext stroke()");
            }

            if (this.___IsDisposing == true)
            {
                return;
            }
            try
            {
#if WINDOWS
                if (this.___CanvasContextModeType == CanvasContextModeType.Canvas2D || this.___CanvasContextModeType == CanvasContextModeType.SVG)
                {
                    System.Drawing.Graphics ___gractiveContext = null;


                    ___gractiveContext = this.___getactiveC2DGraphicsFromBaseImage();

                    if (___gractiveContext == null)
                    {

                        return;
                    }
                    System.Drawing.Pen pen = null;
                    try
                    {
                        if (this.___CanvasGdiBrush == null)
                        {
                            ___createStrokeBrushInstance();
                        }

                        pen = new System.Drawing.Pen(this.___CanvasGdiBrush, (int)this.___contextLineWidth);

                        // pen = new System.Drawing.Pen(Color.Green, (int)this.___contextLineWidth);
                        if (this.___lineDashList != null)
                        {
                            pen.DashStyle = DashStyle.Custom;
                            pen.DashPattern = this.___lineDashList;

                        }
                        ___gractiveContext.DrawPath(pen, this.___CanvasGdiGraphicPath);

                        /*
                        this.___CanvasGdiGraphicPath.Dispose();
                        this.___CanvasGdiGraphicPath = null;
                        this.___CanvasGdiGraphicPath = new GraphicsPath();
                         */




                    }
                    catch (Exception ex)
                    {
                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                        {
                            commonLog.LogEntry("CHtmlCanvasContext stroke errror : ", ex);
                        }
                    }
                    if (pen != null)
                    {
                        pen.Dispose();
                        pen = null;
                    }


                    this.___ContextTimerDelay = 0;

                    ___setCanvasActivityIntoDocument();
                    return;

                }
                else
                {

                    this.___ContextTimerDelay = 0;

                    return;

                }
#else
                switch(___CanvasGraphicAPIType)
                {
                    case GraphicAPIType.SkiaSharp:
                    case GraphicAPIType.Avalonia:
                        if (this.___CanvasContextModeType == CanvasContextModeType.Canvas2D || this.___CanvasContextModeType == CanvasContextModeType.SVG)
                        {
                            try
                            {
                                // Get active SKCanvas context
                                using (SKCanvas ___skiaCanvas = this.___getActiveSkiaCanvasFromBaseImage())
                                {
                                    if (___skiaCanvas == null)
                                    {
                                        return;
                                    }
                                    
                                    SKPaint strokePaint = null;
                                    try
                                    {
                                        // Create or get stroke brush instance
                                        if (this.___CanvasSkiaStrokePaint == null || this.___contextStrokeStyleAsObject is CHtmlCanvasContextExtenstionObject)
                                        {
                                            ___createStrokeBrushInstance();
                                        }
                                        
                                        // Create stroke paint
                                        strokePaint = new SKPaint();
                                        strokePaint.Style = SKPaintStyle.Stroke;
                                        strokePaint.StrokeWidth = (float)this.___contextLineWidth;
                                        strokePaint.IsAntialias = true;
                                        
                                        // Set color from stroke style
                                        if (this.___CanvasSkiaStrokePaint != null)
                                        {
                                            strokePaint.Color = this.___CanvasSkiaStrokePaint.Color;
                                            strokePaint.Shader = this.___CanvasSkiaStrokePaint.Shader;
                                        }
                                        else
                                        {
                                            // Default stroke color
                                            strokePaint.Color = SKColors.Black;
                                        }
                                        
                                        // Set line dash pattern if specified
                                        if (this.___lineDashList != null && this.___lineDashList.Length > 0)
                                        {
                                            strokePaint.PathEffect = SKPathEffect.CreateDash(this.___lineDashList, 0);
                                        }
                                        
                                        // Set line cap style
                                        if (this.___contextLineCap != null)
                                        {
                                            string lineCap = commonHTML.GetStringValue(this.___contextLineCap);
                                            switch (lineCap.ToLower())
                                            {
                                                case "round":
                                                    strokePaint.StrokeCap = SKStrokeCap.Round;
                                                    break;
                                                case "square":
                                                    strokePaint.StrokeCap = SKStrokeCap.Square;
                                                    break;
                                                case "butt":
                                                default:
                                                    strokePaint.StrokeCap = SKStrokeCap.Butt;
                                                    break;
                                            }
                                        }
                                        
                                        // Set line join style
                                        if (this.___contextLineJoin != null)
                                        {
                                            string lineJoin = commonHTML.GetStringValue(this.___contextLineJoin);
                                            switch (lineJoin.ToLower())
                                            {
                                                case "round":
                                                    strokePaint.StrokeJoin = SKStrokeJoin.Round;
                                                    break;
                                                case "bevel":
                                                    strokePaint.StrokeJoin = SKStrokeJoin.Bevel;
                                                    break;
                                                case "miter":
                                                default:
                                                    strokePaint.StrokeJoin = SKStrokeJoin.Miter;
                                                    break;
                                            }
                                        }
                                        
                                        // Set miter limit
                                        if (this.___contextMiterLimit > 0)
                                        {
                                            strokePaint.StrokeMiter = (float)this.___contextMiterLimit;
                                        }
                                        
                                        // Draw the path
                                        if (this.___CanvasSkiaGraphicPath != null)
                                        {
                                            if (this.___contextGlobalAlpha < 1)
                                            {
                                                byte originalAlpha = strokePaint.Color.Alpha;
                                                strokePaint.Color = strokePaint.Color.WithAlpha((byte)(this.___contextGlobalAlpha * originalAlpha));
                                                ___skiaCanvas.DrawPath(this.___CanvasSkiaGraphicPath, strokePaint);
                                                strokePaint.Color = strokePaint.Color.WithAlpha(originalAlpha);
                                            }
                                            else
                                            {
                                                ___skiaCanvas.DrawPath(this.___CanvasSkiaGraphicPath, strokePaint);
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                                        {
                                            commonLog.LogEntry("CHtmlCanvasContext stroke SkiaSharp error : ", ex);
                                        }
                                    }
                                    finally
                                    {
                                        if (strokePaint != null)
                                        {
                                            strokePaint.Dispose();
                                            strokePaint = null;
                                        }
                                    }
                                }
                                
                                this.___ContextTimerDelay = 0;
                                ___setCanvasActivityIntoDocument();
                                return;
                            }
                            catch (Exception ex)
                            {
                                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                                {
                                    commonLog.LogEntry("CHtmlCanvasContext stroke SkiaSharp outer error : ", ex);
                                }
                            }
                        }
                        break;
                }
                this.___ContextTimerDelay = 0;
                return;
#endif
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry("CHtmlCanvasContext stroke errror : ", ex);
                }
            }

            ___setCanvasActivityIntoDocument();
        }
        public void quadraticCurveTo(double cpx, double cpy, double x, double y)
        {
            this.___setCanvasActivityIntoDocument();
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry($"entering {this}.quadraticCurveTo({cpx}, {cpy}, {x}, {y}) ");
            }
            try
            {
                // Add to Instruction List
                CHtmlCanvasContextInstruction ___instruction = new CHtmlCanvasContextInstruction();
                ___instruction.InstructionType = CanvasInstructionType.QuadraticCurveTo;
                ___instruction.point = new PointFSpec((float)x, (float)y);
                ___instruction.controlPoint1 = new PointFSpec((float)cpx, (float)cpy);
                this.___CanvasInstructionsList.Add(___instruction);

#if WINDOWS
                if (this.___CanvasGdiGraphicPath != null)
                {
                    PointF p0 = this.___currentPointF;
                    if (float.IsNaN(p0.X))
                    {
                        p0 = new PointF((float)cpx, (float)cpy);
                        this.___CanvasGdiGraphicPath.StartFigure();
                    }

                    PointF p1 = new PointF((float)cpx, (float)cpy);
                    PointF p2 = new PointF((float)x, (float)y);

                    // Convert Quadratic Bezier to Cubic Bezier for GDI+
                    PointF cp1 = new PointF(p0.X + 2.0f / 3.0f * (p1.X - p0.X), p0.Y + 2.0f / 3.0f * (p1.Y - p0.Y));
                    PointF cp2 = new PointF(p2.X + 2.0f / 3.0f * (p1.X - p2.X), p2.Y + 2.0f / 3.0f * (p1.Y - p2.Y));

                    this.___CanvasGdiGraphicPath.AddBezier(p0, cp1, cp2, p2);
                }
#else
                if (___CanvasSkiaGraphicPath == null)
                    ___CanvasSkiaGraphicPath = new SKPath();

                if (float.IsNaN(___currentPointF.X) || float.IsNaN(___currentPointF.Y))
                {
                    ___CanvasSkiaGraphicPath.MoveTo((float)cpx, (float)cpy);
                }

                ___CanvasSkiaGraphicPath.QuadTo((float)cpx, (float)cpy, (float)x, (float)y);
#endif
                // Update current point
                this.___currentPointF = new PointF((float)x, (float)y);
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry("quadraticCurveTo error : ", ex);
                }
            }
        }

        public void clearRect(double x, double y, double w, double h)
        {
            ___setCanvasActivityIntoDocument();
#if WINDOWS
            var gr = this.___getactiveC2DGraphicsFromBaseImage();
            if (gr != null)
            {
                gr.FillRectangle(Brushes.Transparent, (float)x, (float)y, (float)w, (float)h);
            }
#endif
#if !WINDOWS
            using (var skCanvas = this.___getActiveSkiaCanvasFromBaseImage())
            {
                if (skCanvas != null)
                {
                    skCanvas.Save();
                    skCanvas.ClipRect(new SKRect((float)x, (float)y, (float)(x + w), (float)(y + h)));
                    skCanvas.Clear(SKColors.Transparent);
                    skCanvas.Restore();
                }
            }
#endif
        }

        public void translate(double x, double y)
        {
            this.___CanvasTranslatePoint = new PointFSpec((float)x, (float)y);
            this.___CanvasInstructionsList.Add(new CHtmlCanvasContextInstruction { InstructionType = CanvasInstructionType.Translate, point = this.___CanvasTranslatePoint });
        }

        public void rotate(double angle)
        {
            this.___CanvasRotateAngle = (float)angle;
            this.___CanvasInstructionsList.Add(new CHtmlCanvasContextInstruction { InstructionType = CanvasInstructionType.Rotate, floatValue = (float)(angle * 180 / Math.PI) });
        }

        public void scale(double x, double y)
        {
            this.___CanvasInstructionsList.Add(new CHtmlCanvasContextInstruction { InstructionType = CanvasInstructionType.Scale, point = new PointFSpec((float)x, (float)y) });
        }

        public void save()
        {
            if (commonLog.LoggingEnabled)
            {
                System.Diagnostics.Debug.WriteLine("save() method called. Current instruction count: " + (this.___CanvasInstructionsList != null ? this.___CanvasInstructionsList.Count : 0));
            }
            if (this.___CanvasStateStack == null) this.___CanvasStateStack = new Stack<CHtmlCanvasState>();

            CHtmlCanvasState state = new CHtmlCanvasState();
            state.___contextFillStyleAsObject = this.___contextFillStyleAsObject;
            state.___contextStrokeStyleAsObject = this.___contextStrokeStyleAsObject;
            state.___contextShadowColorAsObject = this.___contextShadowColorAsObject;
            state.___contextShadowBlur = this.___contextShadowBlur;
            state.___contextShadowOffsetX = this.___contextShadowOffsetX;
            state.___contextShadowOffsetY = this.___contextShadowOffsetY;
            state.___contextLineCap = this.___contextLineCap;
            state.___contextLineJoin = this.___contextLineJoin;
            state.___contextLineWidth = this.___contextLineWidth;
            state.___contextMiterLimit = this.___contextMiterLimit;
            state.___contextFontAsObject = this.___contextFontAsObject;
            state.___contextFontAsString = this.___contextFontAsString;
            state.___contextTextAlignAsObject = this.___contextTextAlignAsObject;
            state.___contextTextBaseline = this.___contextTextBaseline;
            state.___contextglobalCompositeOperationAsObject = this.___contextglobalCompositeOperationAsObject;
            state.___contextGlobalAlpha = this.___contextGlobalAlpha;
            state.___contextTranslatePoint = this.___CanvasTranslatePoint;
            state.___contextRotateAngle = this.___CanvasRotateAngle;

            this.___CanvasStateStack.Push(state);
            this.___CanvasInstructionsList.Add(new CHtmlCanvasContextInstruction { InstructionType = CanvasInstructionType.Save });
        }

        public void restore()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("restore() method called. Current instruction count: " + (this.___CanvasStateStack != null ? this.___CanvasStateStack.Count : 0));
            }
            if (___CanvasStateStack == null || ___CanvasStateStack.Count == 0)
                return;

            this.___CanvasInstructionsList.Add(new CHtmlCanvasContextInstruction { InstructionType = CanvasInstructionType.Restore });

            var state = ___CanvasStateStack.Pop();

            this.___contextStrokeStyleAsObject = state.___contextStrokeStyleAsObject;
            this.___contextShadowColorAsObject = state.___contextShadowColorAsObject;
            this.___contextShadowBlur = state.___contextShadowBlur;
            this.___contextShadowOffsetX = state.___contextShadowOffsetX;
            this.___contextShadowOffsetY = state.___contextShadowOffsetY;
            this.___contextLineCap = state.___contextLineCap;
            this.___contextLineJoin = state.___contextLineJoin;
            this.___contextLineWidth = state.___contextLineWidth;
            this.___contextMiterLimit = state.___contextMiterLimit;
            this.___contextFontAsObject = state.___contextFontAsObject;
            this.___contextFontAsString = state.___contextFontAsString;
            this.___contextFillStyleAsObject = state.___contextFillStyleAsObject;
            this.___contextTextAlignAsObject = state.___contextTextAlignAsObject;
            this.___contextTextBaseline = state.___contextTextBaseline;
            this.___contextglobalCompositeOperationAsObject = state.___contextglobalCompositeOperationAsObject;
            this.___contextGlobalAlpha = state.___contextGlobalAlpha;
            this.___CanvasTranslatePoint = state.___contextTranslatePoint;
            this.___CanvasRotateAngle = state.___contextRotateAngle;
        }

        public void drawImage(object image, double dx, double dy) => ___drawImage_inner(image, 0, 0, 0, 0, dx, dy, 0, 0, 1);
        public void drawImage(object image, double dx, double dy, double dw, double dh) => ___drawImage_inner(image, 0, 0, 0, 0, dx, dy, dw, dh, 2);
        public void drawImage(object image, double sx, double sy, double sw, double sh, double dx, double dy, double dw, double dh) => ___drawImage_inner(image, sx, sy, sw, sh, dx, dy, dw, dh, 3);
        public void drawImage(object image, object dx, object dy, object dw, object dh)
        {
            ___drawImage_inner(image, 0, 0, 0, 0, commonData.GetDoubleFromObject(dx), commonData.GetDoubleFromObject(dy), commonData.GetDoubleFromObject(dw), commonData.GetDoubleFromObject(dh), 2);
        }

        public CHtmlTextMetrics measureText(string text)
        {
            CHtmlTextMetrics metrics = new CHtmlTextMetrics();
            if (string.IsNullOrEmpty(text)) return metrics;

#if WINDOWS
            System.Drawing.Font font = null;
            if (this.___contextCHtmlFontInfo != null)
            {
                font = this.___contextCHtmlFontInfo.ToFont();
            }
            else
            {
                font = new System.Drawing.Font("Arial", 10);
            }

            using (font)
            {
                System.Drawing.Graphics g = null;
                bool disposeGraphics = false;
                try
                {
                    g = this.___getactiveC2DGraphicsFromBaseImage();
                }
                catch { }

                if (g == null)
                {
                    g = System.Drawing.Graphics.FromImage(new System.Drawing.Bitmap(1, 1));
                    disposeGraphics = true;
                }

                try
                {
                    var size = g.MeasureString(text, font, new System.Drawing.PointF(0, 0), System.Drawing.StringFormat.GenericTypographic);
                    metrics.___width = size.Width;
                }
                finally
                {
                    if (disposeGraphics && g != null) g.Dispose();
                }
            }
#else
            using (var paint = new SKPaint())
            {
                if (this.___contextCHtmlFontInfo != null)
                {
                    SKFontStyleWeight weight = this.___contextCHtmlFontInfo.Bold ? SKFontStyleWeight.Bold : SKFontStyleWeight.Normal;
                    SKFontStyleSlant slant = this.___contextCHtmlFontInfo.Italic ? SKFontStyleSlant.Italic : SKFontStyleSlant.Upright;

                    paint.Typeface = SKTypeface.FromFamilyName(this.___contextCHtmlFontInfo.FontName, weight, SKFontStyleWidth.Normal, slant);
                    paint.TextSize = this.___contextCHtmlFontInfo.FontSize;
                }
                else
                {
                    paint.Typeface = SKTypeface.FromFamilyName("Arial");
                    paint.TextSize = 10;
                }
                metrics.___width = paint.MeasureText(text);
            }
#endif
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry($"CHtmlCanvasContext2D measureText() returns {metrics.ToLogString()}");
            }
            return metrics;
        }

        public void fillText(string text, double x, double y)
        {
            ___fillText_Inner(text, x, y, -1);
        }
        public void fillText(string text, double x, double y, double maxWidth)
        {
            ___fillText_Inner(text, x, y, maxWidth);
        }
        internal void ___fillText_Inner(string text, double x, double y, double maxWidth)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("entering {0}.fillText_Inner('{1}', {2}, {3}, {4})", this, text, x, y, maxWidth);
            }
#if WINDOWS
            var gr = this.___getactiveC2DGraphicsFromBaseImage();
            if (gr != null)
            {
                using (var font = (this.___contextCHtmlFontInfo != null) ? this.___contextCHtmlFontInfo.ToFont() : new System.Drawing.Font("Arial", 10))
                {
                    if (this.___CanvasGdiBrush == null) ___createBrushFromFillStyleObject(Color.Black);
                    gr.DrawString(text, font, this.___CanvasGdiBrush, (float)x, (float)y);
                }
            }
#endif
#if !WINDOWS
            using (var skCanvas = this.___getActiveSkiaCanvasFromBaseImage())
            {
                if (skCanvas != null)
                {
                    if (this.___CanvasSkiaFillPaint == null || this.___contextFillStyleAsObject is CHtmlCanvasContextExtenstionObject) ___createBrushFromFillStyleObject(Color.Black);

                    using (var paint = this.___CanvasSkiaFillPaint.Clone())
                    {
                        paint.Style = SKPaintStyle.Fill;
                        if (this.___contextGlobalAlpha < 1)
                        {
                            paint.Color = paint.Color.WithAlpha((byte)(this.___contextGlobalAlpha * paint.Color.Alpha));
                        }
                        if (this.___contextCHtmlFontInfo != null)
                        {
                            SKFontStyleWeight weight = this.___contextCHtmlFontInfo.Bold ? SKFontStyleWeight.Bold : SKFontStyleWeight.Normal;
                            SKFontStyleSlant slant = this.___contextCHtmlFontInfo.Italic ? SKFontStyleSlant.Italic : SKFontStyleSlant.Upright;
                            paint.Typeface = SKTypeface.FromFamilyName(this.___contextCHtmlFontInfo.FontName, weight, SKFontStyleWidth.Normal, slant);
                            paint.TextSize = this.___contextCHtmlFontInfo.FontSize;
                        }
                        else
                        {
                            paint.Typeface = SKTypeface.FromFamilyName("Arial");
                            paint.TextSize = 10;
                        }
                        skCanvas.DrawText(text, (float)x, (float)y, paint);

                        // デバッグ用に現在のキャンバスの状態をPNGとして保存
                        if (this.___CanvasSkiaBitmapWeakReference?.Target is SKBitmap debugSnapshot)
                        {
                           /*
                            try
                            {
                                string debugFileName = Path.Combine(AppContext.BaseDirectory, $"canvas_fillText_{DateTime.Now:yyyyMMdd_HHmmss_fff}.png");
                                using (var image = SKImage.FromBitmap(debugSnapshot))
                                using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                                using (var stream = File.OpenWrite(debugFileName))
                                {
                                    data.SaveTo(stream);
                                }
                            }
                            catch { }
                            */
                        }
                    }
                }
            }
#endif
            ___setCanvasActivityIntoDocument();
        }

        public void strokeText(string text, double x, double y)
        {
            ___strokeText_Inner(text, x, y, -1);
        }
        public void strokeText(string text, double x, double y, double maxWidth)
        {
            ___strokeText_Inner(text, x, y, maxWidth);
        }
        internal void ___strokeText_Inner(string text, double x, double y, double maxWidth)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("entering {0}.strokeText_Inner('{1}', {2}, {3}, {4})", this, text, x, y, maxWidth);
            }
#if WINDOWS
            var gr = this.___getactiveC2DGraphicsFromBaseImage();
            if (gr != null)
            {
                using (var font = (this.___contextCHtmlFontInfo != null) ? this.___contextCHtmlFontInfo.ToFont() : new System.Drawing.Font("Arial", 10))
                {
                    if (this.___CanvasGdiBrush == null) ___createStrokeBrushInstance();
                    using (var pen = new Pen(this.___CanvasGdiBrush, (float)this.___contextLineWidth))
                    {
                        using (var path = new GraphicsPath())
                        {
                            path.AddString(text, font.FontFamily, (int)font.Style, gr.DpiY * font.Size / 72, new PointF((float)x, (float)y), StringFormat.GenericTypographic);
                            gr.DrawPath(pen, path);
                        }
                    }
                }
            }
#endif
#if !WINDOWS
            using (var skCanvas = this.___getActiveSkiaCanvasFromBaseImage())
            {
                if (skCanvas != null)
                {
                    if (this.___CanvasSkiaStrokePaint == null || this.___contextStrokeStyleAsObject is CHtmlCanvasContextExtenstionObject) ___createStrokeBrushInstance();
                    if (this.___CanvasSkiaStrokePaint == null) this.___CanvasSkiaStrokePaint = new SKPaint { Color = SKColors.Black, Style = SKPaintStyle.Stroke, IsAntialias = true };

                    using (var paint = this.___CanvasSkiaStrokePaint.Clone())
                    {
                        paint.Style = SKPaintStyle.Stroke;
                        paint.StrokeWidth = (float)this.___contextLineWidth;
                        if (this.___contextGlobalAlpha < 1)
                        {
                            paint.Color = paint.Color.WithAlpha((byte)(this.___contextGlobalAlpha * paint.Color.Alpha));
                        }
                        if (this.___contextCHtmlFontInfo != null)
                        {
                            SKFontStyleWeight weight = this.___contextCHtmlFontInfo.Bold ? SKFontStyleWeight.Bold : SKFontStyleWeight.Normal;
                            SKFontStyleSlant slant = this.___contextCHtmlFontInfo.Italic ? SKFontStyleSlant.Italic : SKFontStyleSlant.Upright;
                            paint.Typeface = SKTypeface.FromFamilyName(this.___contextCHtmlFontInfo.FontName, weight, SKFontStyleWidth.Normal, slant);
                            paint.TextSize = this.___contextCHtmlFontInfo.FontSize;
                        }
                        else
                        {
                            paint.Typeface = SKTypeface.FromFamilyName("Arial");
                            paint.TextSize = 10;
                        }
                        skCanvas.DrawText(text, (float)x, (float)y, paint);
                    }
                }
            }
#endif
            ___setCanvasActivityIntoDocument();
        }

        public static string ___performToDataURLOperation(string type, double p1, double p2, double p3, object p4, CHtmlElement element)
        {
            return "";
        }

        public static CanvasContextModeType ___GetCanvasTypeFromName(string name)
        {
            if (string.Compare(name, "2d", StringComparison.OrdinalIgnoreCase) == 0) return CanvasContextModeType.Canvas2D;
            return CanvasContextModeType.None;
        }

        private double ___ConvertNaNInfiniteToZero(double value)
        {
            if (double.IsNaN(value) || double.IsInfinity(value)) return 0;
            return value;
        }

        private void ___setCanvasActivityIntoDocument()
        {
            /*if (this.___needAvoidToCallCanvasActivityIntoDocument)
                return;
            */
            if (this.___CanvasContextModeType == CanvasContextModeType.Canvas2D)
            {
                if (this.___ownerDocumentWeakReference != null)
                {
                    CHtmlDocument ___doc = this.___ownerDocumentWeakReference.Target as CHtmlDocument;
                    if (___doc != null)
                    {
                        if (___doc.___CanvasContextElement2DDrawingPendingList != null && ___doc.___CanvasContextElement2DDrawingPendingList.ContainsKey(this) == false)
                        {
                            ___doc.___CanvasContextElement2DDrawingPendingList[this] = null;
                        }

                    }
                }
            }
        }

        private Image ___GetImageFromDocumentWithUrl(string url, ref string fullUrl)
        {
            return null;
        }

        private void ___createBrushFromFillStyleObject(Color colorFallback)
        {
#if WINDOWS
            if (this.___contextFillStyleAsObject is string colorStr)
            {
                try { this.___CanvasGdiBrush = new SolidBrush(ColorTranslator.FromHtml(colorStr)); } catch { }
            }
            if (this.___CanvasGdiBrush == null)
            {
                this.___CanvasGdiBrush = new SolidBrush(colorFallback);
            }
#endif
#if !WINDOWS
            if (this.___contextFillStyleAsObject is CHtmlCanvasContextExtenstionObject grad)
            {
                if (grad.___ContextGraphicsObjectType == CanvasExtentionObjectType.LinerGradient || grad.___ContextGraphicsObjectType == CanvasExtentionObjectType.RadialGradient)
                {

    
                
                    
                   

                
                if (grad.___ColorStopList != null && grad.___ColorStopList.Count > 0)
                {
                    var colors = new List<SKColor>();
                    var positions = new List<float>();
                    foreach (var kv in grad.___ColorStopList)
                    {
                        colors.Add(new SKColor(kv.Value.R, kv.Value.G, kv.Value.B, kv.Value.A));
                        positions.Add((float)kv.Key);
                    }

                    SKShader shader = null;
                    if (grad.___ContextGraphicsObjectType == CanvasExtentionObjectType.LinerGradient)
                    {
                        var start = new SKPoint(grad.___baseRectangle1.X, grad.___baseRectangle1.Y);
                        var end = new SKPoint(grad.___baseRectangle1.Width, grad.___baseRectangle1.Height);
                        shader = SKShader.CreateLinearGradient(start, end, colors.ToArray(), positions.ToArray(), SKShaderTileMode.Clamp);
                    }
                    else if (grad.___ContextGraphicsObjectType == CanvasExtentionObjectType.RadialGradient)
                    {
                        var startCenter = new SKPoint(grad.___baseRectangle1.X, grad.___baseRectangle1.Y);
                        var startRadius = grad.___baseRectangle1.Width;
                        var endCenter = new SKPoint(grad.___baseRectangle2.X, grad.___baseRectangle2.Y);
                        var endRadius = grad.___baseRectangle2.Width;
                        shader = SKShader.CreateTwoPointConicalGradient(startCenter, startRadius, endCenter, endRadius, colors.ToArray(), positions.ToArray(), SKShaderTileMode.Clamp);
                    }

                    if (shader != null)
                    {
                        this.___CanvasSkiaFillPaint = new SKPaint { Shader = shader, Style = SKPaintStyle.Fill, IsAntialias = true };
                        return;
                    }
                    }
                }
                else if(grad.___ContextGraphicsObjectType == CanvasExtentionObjectType.CanvasPattern)
                    {
                        
                        CHtmlElement patternElement = grad.canvasPatternCanvas;
                        if (patternElement != null)
                        {
                        
                                 if (patternElement.___canvasContextCurrent2D != null && patternElement.___canvasContextCurrent2D.___CanvasSkiaBitmapWeakReference?.Target is SKBitmap patternBitmap)
                                {
                                    SKShader shader = SKShader.CreateBitmap(patternBitmap, SKShaderTileMode.Repeat, SKShaderTileMode.Repeat);
                                    this.___CanvasSkiaFillPaint = new SKPaint { Shader = shader, Style = SKPaintStyle.Fill, IsAntialias = true };
                                    return;
                                }
                                
                        }
                        else
                        {
                                  this.___CanvasSkiaFillPaint = new SKPaint { Color = new SKColor(colorFallback.R, colorFallback.G, colorFallback.B, colorFallback.A), Style = SKPaintStyle.Fill, IsAntialias = true };
                        return;
                        }

            

              
                        }
                   }

            string colorStr = commonHTML.GetStringValue(this.___contextFillStyleAsObject);
            if (string.IsNullOrEmpty(colorStr)) 
            {
                this.___CanvasSkiaFillPaint = new SKPaint { Color = new SKColor(colorFallback.R, colorFallback.G, colorFallback.B, colorFallback.A), Style = SKPaintStyle.Fill, IsAntialias = true };
                return;
            }

            try 
            { 
                ColorSpec spec = commonHTML.GetColorSpecFromString(colorStr);
                // If it returned black but the string isn't black, try alternative parsing
                if (spec.R == 0 && spec.G == 0 && spec.B == 0 && spec.A == 255 && colorStr.ToLower() != "black" && !colorStr.StartsWith("#000"))
                {
                    if (SKColor.TryParse(colorStr, out SKColor skColor))
                    {
                        this.___CanvasSkiaFillPaint = new SKPaint { Color = skColor, Style = SKPaintStyle.Fill, IsAntialias = true };
                        return;
                    }
                }
                this.___CanvasSkiaFillPaint = new SKPaint { Color = new SKColor(spec.R, spec.G, spec.B, spec.A), Style = SKPaintStyle.Fill, IsAntialias = true }; 
            } 
            catch 
            {
                this.___CanvasSkiaFillPaint = new SKPaint { Color = new SKColor(colorFallback.R, colorFallback.G, colorFallback.B, colorFallback.A), Style = SKPaintStyle.Fill, IsAntialias = true };
            }
            
            
              
            

#endif
        }

        private void ___createStrokeBrushInstance()
        {
#if WINDOWS
            if (this.___contextStrokeStyleAsObject is string colorStr)
            {
                try { this.___CanvasGdiBrush = new SolidBrush(ColorTranslator.FromHtml(colorStr)); } catch { }
            }
#endif
#if !WINDOWS
            if (this.___contextStrokeStyleAsObject is CHtmlCanvasContextExtenstionObject grad)
            {
                if (grad.___ColorStopList != null && grad.___ColorStopList.Count > 0)
                {
                    var colors = new List<SKColor>();
                    var positions = new List<float>();
                    foreach (var kv in grad.___ColorStopList)
                    {
                        colors.Add(new SKColor(kv.Value.R, kv.Value.G, kv.Value.B, kv.Value.A));
                        positions.Add((float)kv.Key);
                    }

                    SKShader shader = null;
                    if (grad.___ContextGraphicsObjectType == CanvasExtentionObjectType.LinerGradient)
                    {
                        var start = new SKPoint(grad.___baseRectangle1.X, grad.___baseRectangle1.Y);
                        var end = new SKPoint(grad.___baseRectangle1.Width, grad.___baseRectangle1.Height);
                        shader = SKShader.CreateLinearGradient(start, end, colors.ToArray(), positions.ToArray(), SKShaderTileMode.Clamp);
                    }
                    else if (grad.___ContextGraphicsObjectType == CanvasExtentionObjectType.RadialGradient)
                    {
                        var startCenter = new SKPoint(grad.___baseRectangle1.X, grad.___baseRectangle1.Y);
                        var startRadius = grad.___baseRectangle1.Width;
                        var endCenter = new SKPoint(grad.___baseRectangle2.X, grad.___baseRectangle2.Y);
                        var endRadius = grad.___baseRectangle2.Width;
                        shader = SKShader.CreateTwoPointConicalGradient(startCenter, startRadius, endCenter, endRadius, colors.ToArray(), positions.ToArray(), SKShaderTileMode.Clamp);
                    }

                    if (shader != null)
                    {
                        this.___CanvasSkiaStrokePaint = new SKPaint { Shader = shader, Style = SKPaintStyle.Stroke, IsAntialias = true };
                        return;
                    }
                }
            }

            string colorStr = commonHTML.GetStringValue(this.___contextStrokeStyleAsObject);
            if (string.IsNullOrEmpty(colorStr)) return;

            try 
            { 
                ColorSpec spec = commonHTML.GetColorSpecFromString(colorStr);
                // If it returned black but the string isn't black, try alternative parsing
                if (spec.R == 0 && spec.G == 0 && spec.B == 0 && spec.A == 255 && colorStr.ToLower() != "black" && !colorStr.StartsWith("#000"))
                {
                    if (SKColor.TryParse(colorStr, out SKColor skColor))
                    {
                        this.___CanvasSkiaStrokePaint = new SKPaint { Color = skColor, Style = SKPaintStyle.Stroke, IsAntialias = true };
                        return;
                    }
                }
                this.___CanvasSkiaStrokePaint = new SKPaint { Color = new SKColor(spec.R, spec.G, spec.B, spec.A), Style = SKPaintStyle.Stroke, IsAntialias = true }; 
            } 
            catch { }
#endif
        }

        public void transform(double a, double b, double c, double d, double e, double f)
        {

            var matrix = new CHtmlCanvasInstructionMatrix(a, b, c, d, e, f);
            this.___CanvasInstructionsList.Add(new CHtmlCanvasContextInstruction
            {
                InstructionType = CanvasInstructionType.Transform,
                matrix = matrix
            });
        }
        public void setTransform(double a, double b, double c, double d, double e, double f)
        {
            var matrix = new CHtmlCanvasInstructionMatrix(a, b, c, d, e, f);
            this.___CanvasInstructionsList.Add(new CHtmlCanvasContextInstruction
            {
                InstructionType = CanvasInstructionType.SetTransform,
                matrix = matrix
            });
        }
        private SKBitmap getRgbaBytesToSkiaBitmap(byte[] rgbaBytes, int width, int height)
        {
            // 1. 画像情報の定義 (RGBA 8888)
            //var info = new SKImageInfo(width, height, SKColorType.Rgba8888, SKAlphaType.Premul);
            //var info = new SKImageInfo(width, height, SKColorType.Bgra8888, SKAlphaType.Premul);
            // システムの標準（Bgra8888など）に自動で合わせる
            var info = new SKImageInfo(width, height, SKImageInfo.PlatformColorType, SKAlphaType.Premul);
            // 2. SKBitmap の作成
            var bitmap = new SKBitmap();

            // 3. バイト配列をピン留め（GCによってメモリ位置が変わらないようにする）
            var gcHandle = GCHandle.Alloc(rgbaBytes, GCHandleType.Pinned);

            try
            {
                // 4. ピクセルデータをセット
                // 第2引数にはピン留めした配列の先頭アドレスを渡す
                bitmap.InstallPixels(info, gcHandle.AddrOfPinnedObject(), info.RowBytes, (address, context) =>
                {
                    // 5. Bitmapが破棄されるときにピン留めを解除するコールバック
                    var handle = (GCHandle)context;
                    handle.Free();
                }, gcHandle);

                return bitmap;
            }
            catch
            {
                if (gcHandle.IsAllocated) gcHandle.Free();
                bitmap.Dispose();
                throw;
            }
        }

        public  object createPattern(object _canvasElementPattern, object repeatArg)
        {
            CHtmlCanvasContextExtenstionObject pattern = new CHtmlCanvasContextExtenstionObject(CanvasExtentionObjectType.CanvasPattern);
            pattern.canvasPatternCanvas = _canvasElementPattern as CHtmlElement;
            pattern.repeatPatternArg = commonHTML.GetStringValue(repeatArg);


            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry($"{this}: createPattern() called with {_canvasElementPattern} , {repeatArg} ");
            }
            return pattern;
        }
    }


}
