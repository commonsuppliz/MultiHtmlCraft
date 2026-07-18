using MultiHtmlCraft.Interfaces;
using MultiHtmlCraft.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Dynamic;
using System.Text;
using System.Linq.Expressions;
namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// CHtmlSVGElement 
	/// </summary>
	public class CHtmlSVGElement : CHtmlElement, System.IDisposable
	{
        /// <summary>
        /// Weak Reference for root svg tag element
        /// svg - non
        ///    ret - ___hasInner
        ///    circle - ___hasInner
        /// </summary>
        internal System.WeakReference ___parentSVGElementWeakReference = null;

        internal System.DateTime ___svgImageCreationTime;

        internal bool ___isSVGImageNeedsToCreate = true;

        internal CHtmlCanvasContextExtenstionObject ___brushExtentionObject = null;
        internal List<CHtmlCanvasPathElementInstruction> ___canvasPathList = null;
        private bool ___isSvgElement = false;
        public CHtmlSVGElement() : base()
        {
            this.___elementTagType = CHtmlElementType.SVG;
            this.___multiversalClassType = IMutilversalObjectType.SVGElement;
            this.___isSvgElement = true;
            this.___IsElementBlock = true;
            this.___svgImageCreationTime = System.DateTime.Now;
            //this.___svgImageNeedsToCreate = true;
            this.___brushExtentionObject = null;
            this.___canvasPathList = new List<CHtmlCanvasPathElementInstruction>();
        
            this.___isSvgElement = true;
            this.___IsElementBlock = true;
		}
        ~CHtmlSVGElement()
        {
            this.___cleanUp();
        }
        protected new void Dispose()
        {
            this.___cleanUp();
            base.Dispose();
            GC.SuppressFinalize(this);
        }
        private void ___cleanUp()
        {
            if (___brushExtentionObject != null)
            {
                ___brushExtentionObject = null;
            }

        }
		public new void translate(double __x, double __y)
		{

		}
        public CHtmlSVGRect createSVGRect()
        {
            CHtmlSVGRect rect = new CHtmlSVGRect();
            return rect;
        }
		#region IPropertBox メンバ

		public override  void ___setPropertyByIndex(int ___index, object val)
		{
			base.___setPropertyByIndex(___index, val);
		}

		public override void ___setPropertyByName(string ___name, object val)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("set : {0} = {1} for {2}", ___name, val , this);
            }
			base.___setPropertyByName(name, val);
		}

		public override  bool ___hasPropertyByIndex(int ___index)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("set : {0}  for {1}", ___index,  this);
            }
			// TODO:  CHtmlSVGElement._x__HasProperty 実装を追加します。
            return base.___hasPropertyByIndex(___index);
		}

		public override bool ___hasPropertyByName(string __name)
		{
			// TODO:  CHtmlSVGElement.Prototype.IPropertBox._x__HasProperty 実装を追加します。
			return base.___hasPropertyByName(__name);
		}

        public override object ___getPropertyByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("___getInner : {0} for {1}", ___index, this);
            }

            return base.___getPropertyByIndex(___index);
        }

        public override object ___getPropertyByName(string ___name)
		{
			// TODO:  CHtmlSVGElement.Prototype.IPropertBox.___getPropertyByName 実装を追加します。
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("___getInner : {0} for {1}", ___name,   this);
            }
			return base.___getPropertyByName(___name);
		}
        public IMutilversalObjectType multiversalObjectType
        {
            get { return base.___multiversalClassType; }
        }
        public override string ToString()
        {
            return "[object " + base.___multiversalClassType.ToString() + "]";
        }


        #endregion

        #region SVG Drawings
        internal static bool ___isFillSVGElement(CHtmlSVGElement ___svgElement)
        {
            CHtmlAttribute fillAttr = null;
            if(___svgElement.___attributes.TryGetValue("fill", out fillAttr) == true)
            {
                if(fillAttr != null && fillAttr.___value != null)
                {
                    if(string.CompareOrdinal(fillAttr.___value.ToString(), "none") == 0 ||string.CompareOrdinal(fillAttr.___value.ToString(), "transparent") == 0)
                    {
                        return false;
                    }
                }
            }
            return ___svgElement.___style.___IsBackgroundColorSpecified;
        }
        internal static bool ___isStokeSVGElement(CHtmlSVGElement ___svgElement)
        {
            if (___svgElement.___style.___Stroke == null)
                return false;
            if (string.CompareOrdinal(___svgElement.___style.___Stroke, "none") == 0 || string.CompareOrdinal(___svgElement.___style.___Stroke, "transparent") == 0)
            {
                return false;
            }

            return true;
        }
        internal static bool ___isGroupingToDrawElement(CHtmlSVGElement ___svgElement)
        {
            if (___svgElement.___groupingElementType == CHtmlElementType.DEFS || ___svgElement.___groupingElementType == CHtmlElementType.SYMBOL)
            {
                return false;
            }
            return true;
        }
        internal static void ___drawSVGElementWithContext(CHtmlSVGElement ___svgElement, CHtmlCanvasContext2D ___svgContext, System.DateTime ___drawingTime)
        {
            if (___svgElement == null)
                return;
            try
            {

                switch (___svgElement.___elementTagType)
                {
                    case CHtmlElementType.LINE:

                        float ___lineX1 = (float)___svgElement.___attributes.___getAttributeByNameInDouble("x1", (int)___svgContext.Width);
                        float ___lineY1 = (float)___svgElement.___attributes.___getAttributeByNameInDouble("y1", (int)___svgContext.Height);

                        float ___lineX2 = (float)___svgElement.___attributes.___getAttributeByNameInDouble("x2", (int)___svgContext.Width);
                        float ___lineY2 = (float)___svgElement.___attributes.___getAttributeByNameInDouble("y2", (int)___svgContext.Height);
                        ___svgContext.beginPath();
                        ___svgContext.moveTo(___lineX1, ___lineY1);
                        ___svgContext.lineTo(___lineX2, ___lineY2);
                        ___svgContext.closePath();
                        ___setSVGElementStrokeStyleWithCSSStyle(___svgElement, ___svgContext);
                        ___svgContext.stroke();
                        break;
                    case CHtmlElementType.RECT:
                        RectangleF ___svgRectF = RectangleF.Empty;

                        ___svgRectF.X = (float)___svgElement.___attributes.___getAttributeByNameInDouble("x", (int)___svgContext.Width);
                        ___svgRectF.Y = (float)___svgElement.___attributes.___getAttributeByNameInDouble("y", (int)___svgContext.Height);
                        ___svgRectF.Width = (float)___svgElement.___style.___WidthComputedValue;
                        ___svgRectF.Height = (float)___svgElement.___style.___HeightComputedValue;

                        if (___isFillSVGElement(___svgElement))
                        {
                            ___setSVGElementFillStyleWithCSSStyle(___svgElement, ___svgContext);
                            ___svgContext.fillRect(___svgRectF.X, ___svgRectF.Y, ___svgRectF.Width, ___svgRectF.Height);
                        }
                        if (___isStokeSVGElement(___svgElement))
                        {
                            ___setSVGElementStrokeStyleWithCSSStyle(___svgElement, ___svgContext);
                            ___svgContext.strokeRect(___svgRectF.X, ___svgRectF.Y, ___svgRectF.Width, ___svgRectF.Height);
                        }
                        break;
                    case CHtmlElementType.CIRCLE:
                        RectangleF ___svgCircleF = RectangleF.Empty;

                        ___svgCircleF.X = (float)___svgElement.___attributes.___getAttributeByNameInDouble("cx", (int)___svgContext.Width);
                        ___svgCircleF.Y = (float)___svgElement.___attributes.___getAttributeByNameInDouble("cy", (int)___svgContext.Height);
                        ___svgCircleF.Width = (float)___svgElement.___attributes.___getAttributeByNameInDouble("r", (int)___svgContext.Height);
                        ___svgContext.beginPath();
                        ___svgContext.arc(___svgCircleF.X, ___svgCircleF.Y, ___svgCircleF.Width, 0, CHtmlCanvasContext2D.___getDegreeToRadian(360), false);
                        ___svgContext.closePath();
                        if (___isFillSVGElement(___svgElement))
                        {
                            ___setSVGElementFillStyleWithCSSStyle(___svgElement, ___svgContext);
                            ___svgContext.fill();
                        }
                        if (___isStokeSVGElement(___svgElement))
                        {
                            ___setSVGElementStrokeStyleWithCSSStyle(___svgElement, ___svgContext);
                            ___svgContext.stroke();
                        }

                        break;
                    case CHtmlElementType.ELLIPSE:
                        PointF ___svgEllipseF = PointF.Empty;

                        double ___svgEllipse_rx = 0;
                        double ___svgEllipse_ry = 0;
                        ___svgEllipseF.X = (float)___svgElement.___attributes.___getAttributeByNameInDouble("cx", (int)___svgContext.Width);
                        ___svgEllipseF.Y = (float)___svgElement.___attributes.___getAttributeByNameInDouble("cy", (int)___svgContext.Height);
                        ___svgEllipse_rx = ___svgElement.___attributes.___getAttributeByNameInDouble("rx", (int)___svgContext.___CanvasWidth);
                        ___svgEllipse_ry = ___svgElement.___attributes.___getAttributeByNameInDouble("ry", (int)___svgContext.___CanvasHeight);
                        double ___svgEllipseRotation = 0; // always 0
                        double ___svgEllipseStartAngle = 0; // should be zero
                        double ___svgEllipseEndAngle = 2 * Math.PI; // 2 * Math.PI;


                        ___svgContext.beginPath();
                        ___svgContext.ellipse(___svgEllipseF.X, ___svgEllipseF.Y, ___svgEllipse_rx, ___svgEllipse_ry, ___svgEllipseRotation, ___svgEllipseStartAngle, ___svgEllipseEndAngle, false);
                        ___svgContext.closePath();
                        if (___isFillSVGElement(___svgElement))
                        {
                            ___setSVGElementFillStyleWithCSSStyle(___svgElement, ___svgContext);
                            ___svgContext.fill();
                        }
                        if (___isStokeSVGElement(___svgElement))
                        {
                            ___setSVGElementStrokeStyleWithCSSStyle(___svgElement, ___svgContext);
                            ___svgContext.stroke();
                        }


                        break;
                    case CHtmlElementType.POLYGON:
                    case CHtmlElementType.POLYLINE:
                        CHtmlAttribute attrPolyPoints = null;
                        if (___svgElement.___attributes.TryGetValue("points", out attrPolyPoints) == true)
                        {
                            string strAttrPoints = commonHTML.GetStringValue(attrPolyPoints.___value);

                            PointF[] ptfPoints;
                            if (string.IsNullOrEmpty(strAttrPoints) == false)
                            {

                                ptfPoints = ___getPointFArrayFromString(strAttrPoints);
                                if (ptfPoints != null && ptfPoints.Length > 0)
                                {
                                    int ptfPointsLen = ptfPoints.Length;
                                    if (___svgElement.___elementTagType == CHtmlElementType.POLYGON)
                                    {
                                        ___svgContext.beginPath();
                                    }
                                    ___svgContext.moveTo(ptfPoints[0].X, ptfPoints[0].Y);
                                    for (int points1 = 1; points1 < ptfPointsLen; points1++)
                                    {
                                        ___svgContext.lineTo(ptfPoints[points1].X, ptfPoints[points1].Y);
                                    }
                                    if (___svgElement.___elementTagType == CHtmlElementType.POLYGON)
                                    {
                                        ___svgContext.closePath();
                                    }
                                    if (___isFillSVGElement(___svgElement))
                                    {
                                        ___setSVGElementFillStyleWithCSSStyle(___svgElement, ___svgContext);
                                        ___svgContext.fill();
                                    }
                                    if (___isStokeSVGElement(___svgElement))
                                    {
                                        ___setSVGElementStrokeStyleWithCSSStyle(___svgElement, ___svgContext);
                                        ___svgContext.stroke();
                                    }
                                }
                            }
                        }
                        break;
                    case CHtmlElementType.IMAGE:
                        break;
                    case CHtmlElementType.PATH:
                        bool ___willDrawByGrouping = ___isGroupingToDrawElement(___svgElement);
                        if (___svgElement.___canvasPathList == null)
                        {
                         

                            string strPath_D = commonHTML.GetElementAttributeInString(___svgElement, "d");

                            ___svgElement.___canvasPathList = ___getSVGPathIntructionsFromString(strPath_D);
                            commonLog.LogEntry((strPath_D + " : Path Count : " + ___svgElement.___canvasPathList.Count.ToString()) + " num : ");
                        }
                        if(___willDrawByGrouping && ___svgElement.___canvasPathList != null)
                        {
                            ___drawSVGPathElementWithIntructions(___svgElement, ___svgContext, ___drawingTime);
                        }
                        break;
                    case CHtmlElementType.RADIALGRADIENT:
                    case CHtmlElementType.LINEARGRADIENT:

                        string strGradientElementID = null;

                        if (string.IsNullOrEmpty(___svgElement.___id) == false)
                        {
                            strGradientElementID = ___svgElement.___id;
                        }
                        double gra_x0 = 0;
                        double gra_y0 = 0;
                        double gra_x1 = ___svgContext.___CanvasWidth;
                        double gra_y1 = ___svgContext.___CanvasHeight;

                        if (___svgElement.___elementTagType == CHtmlElementType.RADIALGRADIENT)
                        {
                            double gra_r0 = 0;
                            double gra_r1 = 0;
                            // radialGradient
                            ___svgElement.___brushExtentionObject = ___svgContext.createRadialGradient(gra_x0, gra_y0, gra_r0, gra_x1, gra_y1, gra_r1);
                        }
                        else
                        {
                            // linerGradient
                            ___svgElement.___brushExtentionObject = ___svgContext.createLinearGradient(gra_x0, gra_y0, gra_x1, gra_y1);
                        }

                        int gradientChildStopLen = ___svgElement.___childNodes.length;
                        if (gradientChildStopLen >= 1)
                        {
                            /// [Normal Canvas LinearGradientStyle]
                            /// 
                            /// var grd=ctx.createLinearGradient(0,0,170,0);
                            /// grd.addColorStop(0, "black");
                            /// grd.addColorStop(1, "white");
                            /// ctx.fillStyle = grd;
                            ///

                            for (int i = 0; i < gradientChildStopLen; i++)
                            {
                                CHtmlSVGElement ___svgStopElement = ___svgElement.___childNodes[i] as CHtmlSVGElement;
                                if (___svgStopElement != null && ___svgStopElement.___elementTagType == CHtmlElementType.STOP)
                                {

                                    float svgStopOffset = (float)___svgStopElement.___attributes.___getAttributeByNameInDouble("offset", (int)1);
                                    Color svgStopColor = Color.Transparent;
                                    string ___strStopColor = null;
                                    if (string.IsNullOrEmpty(___svgStopElement.___style.___StopColor) == false)
                                    {
                                        ___strStopColor = ___svgStopElement.___style.___StopColor;
                                    }
                                    else
                                    {
                                        ___strStopColor = "";
                                    }
                                    float svgStopOpacity = 0;
                                    if (string.IsNullOrEmpty(___svgStopElement.___style.___StopOpacity) == false)
                                    {
                                        svgStopOpacity = (float)commonHTML.GetDoubleValueFromString(___svgStopElement.___style.___StopOpacity, 1, 1);
                                        // Since addStopColor does not allow opacity, create new string
                                        if (svgStopOpacity > 0 && svgStopOpacity <= 1)
                                        {
                                            ___svgElement.___brushExtentionObject.addColorStop(svgStopOffset, ___strStopColor);
                                        }
                                        else
                                        {
                                            ___svgElement.___brushExtentionObject.addColorStop(svgStopOffset, ___strStopColor);
                                        }
                                    }
                                    else
                                    {
                                        ___svgElement.___brushExtentionObject.addColorStop(svgStopOffset, ___strStopColor);
                                    }

                                }

                            }
                        }
                        break;
                    case CHtmlElementType.TEXT:
                        break;
                    case CHtmlElementType.G:
                        break;
                    case CHtmlElementType.A:
                        break;
                    case CHtmlElementType.USE:
                        break;
                    case CHtmlElementType.SVG:
                        break;

                    default:
                        break;
                }
            }
            catch (Exception exSVGElementDraw)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                {
                    commonLog.LogEntry("___drawSVGElementWithContext exception : " + ___svgElement.toLogString(), exSVGElementDraw);
                }
            }
        }

        internal static PointF[] ___getPointFArrayFromString(string strAttrPoints)
        {
            string[] spPoints = strAttrPoints.Split(commonHTML.SVG_POINTS_SEPARATOR_CHARS);
            int len = spPoints.Length;
            System.Collections.Generic.List<PointF> listPoints = new System.Collections.Generic.List<PointF>();
            bool isX = true;
            float fx = 0; float fy = 0;
            if (len > 1)
            {
                for (int i = 0; i < len; i++)
                {
                    if (string.IsNullOrEmpty(spPoints[i]) == false)
                    {
                        if (isX)
                        {
                            float.TryParse(spPoints[i], out fx);
                            fy = 0;
                            isX = false;
                        }
                        else
                        {
                            float.TryParse(spPoints[i], out fy);
                            listPoints.Add(new PointF(fx, fy));
                            fx = 0;
                            isX = true;
                        }
                    }
                }
            }
            return listPoints.ToArray();
        }



        /// <summary>
        /// Draw SVGPath Element
        /// </summary>
        /// <param name="___svgElement"></param>
        /// <param name="___svgContext"></param>
        /// <param name="___drawingTime"></param>
        public static void
        ___drawSVGPathElementWithIntructions(CHtmlSVGElement ___svgElement, CHtmlCanvasContext2D ___svgContext, System.DateTime ___drawingTime)
        {
            try
            {
                int len = ___svgElement.___canvasPathList.Count;
                int dpos = 0;
                ___svgContext.beginPath();
                PointF firstPointF = new PointF(0, 0);
                PointF lastMovedPoint = new PointF(0, 0);
                for (int i = 0; i < len; i++)
                {
                  
                    CHtmlCanvasPathElementInstruction pathinfo = ___svgElement.___canvasPathList[i];
                    int datalistLen = pathinfo.datalist.Count;
                    switch(pathinfo.commandType)
                    {
                        case CanvasPathInstructionType.M:
                            if(commonLog.LoggingEnabled && ___isOdd(datalistLen) == true)
                            {
                                commonLog.LogEntry("strange... {0} datalist is not odd pos :{1} values:{2}", ___svgElement.toLogString(), i, datalistLen);
                            }
                            for(dpos = 0; dpos  < datalistLen -1; dpos  = dpos + 2)
                            {
                                double xM = pathinfo.datalist[dpos];
                                double yM = pathinfo.datalist[dpos+1];
                                ___svgContext.moveTo(xM, yM);
                                lastMovedPoint.X = (float)xM;
                                lastMovedPoint.Y = (float)yM;
                            }
                            break;
                        case CanvasPathInstructionType.m:
                            if (commonLog.LoggingEnabled && ___isOdd(datalistLen) == true)
                            {
                                commonLog.LogEntry("strange... {0} datalist is not odd pos :{1} values:{2}", ___svgElement.toLogString(), i, datalistLen);
                            }

                            for (dpos = 0; dpos < datalistLen - 1; dpos = dpos + 2)
                            {

                                double x_low = pathinfo.datalist[dpos];
                                double y_low = pathinfo.datalist[dpos + 1];
                                lastMovedPoint.X = (float)x_low + lastMovedPoint.X;
                                lastMovedPoint.Y = (float)y_low + lastMovedPoint.Y;
                                ___svgContext.moveTo(lastMovedPoint.X, lastMovedPoint.Y);

                            }
                            break;
                        case CanvasPathInstructionType.L:
                            if (commonLog.LoggingEnabled && ___isOdd(datalistLen) == true)
                            {
                                commonLog.LogEntry("strange... {0} datalist is not odd pos :{1} values:{2}", ___svgElement.toLogString(), i, datalistLen);
                            }
                            for (dpos = 0; dpos < datalistLen - 1; dpos = dpos + 2)
                            {
                                ___svgContext.lineTo(pathinfo.datalist[dpos], pathinfo.datalist[dpos + 1]);
                            }
                            break;
                        case CanvasPathInstructionType.l:
                            if (commonLog.LoggingEnabled && ___isOdd(datalistLen) == true)
                            {
                                commonLog.LogEntry("strange... {0} datalist is not odd pos :{1} values:{2}", ___svgElement.toLogString(), i, datalistLen);
                            }
                            for (dpos = 0; dpos < datalistLen - 1; dpos = dpos + 2)
                            {
                                double x_low = pathinfo.datalist[dpos];
                                double y_low = pathinfo.datalist[dpos + 1];
                                double x_low2  = (float)x_low + lastMovedPoint.X;
                                double y_low2 = (float)y_low + lastMovedPoint.Y;
                                ___svgContext.lineTo(x_low2  , y_low2);
                            }
                            break;
                        case CanvasPathInstructionType.C:
                        case CanvasPathInstructionType.c:
                        case CanvasPathInstructionType.S:
                        case CanvasPathInstructionType.s:
                        case CanvasPathInstructionType.Q:
                        case CanvasPathInstructionType.q:
                        case CanvasPathInstructionType.T:
                        case CanvasPathInstructionType.t:
                            if (commonLog.LoggingEnabled )
                            {
                                if(___isOdd(datalistLen) == true || datalistLen == 0)
                                commonLog.LogEntry("strange... {0} datalist is not odd pos :{1} values:{2} type:{3}", ___svgElement.toLogString(), i, datalistLen, pathinfo.commandType);
                            }
                            double curveX0 = 0;
                            double curveY0 = 0;
                            double curveX1 = 0;
                            double curveY1 = 0;
                            double curveX2 = 0;
                            double curveY2 = 0;
                            bool needToAbsolute = false;
                            if(pathinfo.commandType == CanvasPathInstructionType.c || pathinfo.commandType == CanvasPathInstructionType.s || pathinfo.commandType == CanvasPathInstructionType.q || pathinfo.commandType == CanvasPathInstructionType.t)
                            {
                                needToAbsolute = true;
                            }
                                if (datalistLen >= 2)
                            {
                                curveX0 = pathinfo.datalist[0];
                                curveY0 = pathinfo.datalist[1];
                                if(needToAbsolute)
                                {
                                    curveX0 = lastMovedPoint.X + curveX0;
                                    curveY0 = lastMovedPoint.Y + curveY0;
                                }
                                if (datalistLen >= 4)
                                {
                                    curveX1 = pathinfo.datalist[2];
                                    curveY1 = pathinfo.datalist[3];
                                    if (needToAbsolute)
                                    {
                                        curveX1 = lastMovedPoint.X + curveX1;
                                        curveY1 = lastMovedPoint.Y + curveY1;
                                    }
                                    if (datalistLen >= 6)
                                    {
                                        curveX2 = pathinfo.datalist[4];
                                        curveY2 = pathinfo.datalist[5];
                                        if (needToAbsolute)
                                        {
                                            curveX2 = lastMovedPoint.X + curveX2;
                                            curveY2 = lastMovedPoint.Y + curveY2;
                                        }
                                    }

                                }
                            }
                            // [C,c[6],S,s[4]] cubric Bezier : canvas.bezierCurveTo(20,100,200,100,200,20);
                            // [Q,q[4] ,T,t[2]] quadratic Beizer : quadraticCurveTo()
                            if(pathinfo.commandType == CanvasPathInstructionType.Q || pathinfo.commandType == CanvasPathInstructionType.q || pathinfo.commandType == CanvasPathInstructionType.T || pathinfo.commandType == CanvasPathInstructionType.t)
                            {
                                ___svgContext.quadraticCurveTo(curveX0, curveY0, curveX1, curveY1);
                            }
                            else
                            {
                                ___svgContext.bezierCurveTo(curveX0, curveY0, curveX1, curveY1, curveX2, curveY2);
                            }
                            break;
                        case CanvasPathInstructionType.A:
                        case CanvasPathInstructionType.a:
                            if (commonLog.LoggingEnabled)
                            {
                                if (datalistLen != 7)
                                    commonLog.LogEntry("strange... {0} datalist is not odd pos :{1} values:{2} type:{3}", ___svgElement.toLogString(), i, datalistLen, pathinfo.commandType);
                            }
                            if(datalistLen >= 7)
                            {
                                /*
                                    A rx ry 1? 2? 3? x y

                                        where
                                            rx,ry is the centerpoint of the arc
                                            1? is the x-axis-rotation
                                            2? is the large-arc-flag
                                            3? is the sweep flag
                                            x,y is the point the arc is drawn to
                                */
                                double arc_rx = pathinfo.datalist[0];
                                double arc_ry = pathinfo.datalist[1];
                                double arc_ro = pathinfo.datalist[2];
                                double arc_large = pathinfo.datalist[3];
                                double arc_sweep = pathinfo.datalist[4];
                                double arc_x1 = pathinfo.datalist[5];
                                double arc_y1 = pathinfo.datalist[6];
                                double ___svgEllipseStartAngle = 0; // should be zero
                                double ___svgEllipseEndAngle = 2 * Math.PI; // 2 * Math.PI;
                                if (pathinfo.commandType ==  CanvasPathInstructionType.A)
                                {
                                    ___svgContext.ellipse(arc_x1, arc_y1, arc_rx, arc_ry, arc_ro,___svgEllipseStartAngle , ___svgEllipseEndAngle, 0);
                                }
                                else
                                {
                                    ___svgContext.ellipse(arc_x1, arc_y1, arc_rx, arc_ry, arc_ro, ___svgEllipseStartAngle, ___svgEllipseEndAngle, 0);
                                }

                            }
                            break;

                        case CanvasPathInstructionType.H:
                        case CanvasPathInstructionType.V:
                            if (datalistLen >= 1)
                            {
                                double abs_movePos1 = pathinfo.datalist[0];
                                if (pathinfo.commandType == CanvasPathInstructionType.H)
                                {
                                    // H
                                    ___svgContext.lineTo(abs_movePos1, lastMovedPoint.Y);

                                }
                                else
                                {
                                    // V
                                    ___svgContext.lineTo(lastMovedPoint.X, abs_movePos1);

                                }
                            }
                            break;
                        case CanvasPathInstructionType.h:
                        case CanvasPathInstructionType.v:
                            if (datalistLen >= 1)
                            {
                                double relative_movePos1 = pathinfo.datalist[0];
                                if(pathinfo.commandType == CanvasPathInstructionType.h)
                                {
                                    // h
                                    double relative_movePos2 = lastMovedPoint.X + relative_movePos1;
                                    ___svgContext.lineTo(relative_movePos2, lastMovedPoint.Y);
                                }
                                else
                                {
                                    // v
                                    double relative_movePos2 = lastMovedPoint.Y + relative_movePos1;
                                    ___svgContext.lineTo(lastMovedPoint.X, relative_movePos2);
                                }

                            }
                            break;
                        case CanvasPathInstructionType.Z:
                            ___svgContext.closePath();
                            break;
                        default:
                            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                            {
                                commonLog.LogEntry("TODO: ___drawSVGPathElement needs to draw : {0}  ", pathinfo.commandType);
                            }
                            break;
                    }
                }
                if (len > 0)
                {
                    if (___isFillSVGElement(___svgElement) == true)
                    {
                        ___setSVGElementFillStyleWithCSSStyle(___svgElement, ___svgContext);
                        ___svgContext.fill();
                    }
                    if (___isStokeSVGElement(___svgElement) == true)
                    {
                        ___setSVGElementStrokeStyleWithCSSStyle(___svgElement, ___svgContext);
                        ___svgContext.stroke();
                    }
                }
            }
            catch (Exception expath)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                {
                    commonLog.LogEntry("___drawSVGPathElement exception.. ", expath);
                }
            }
        }
        public static List<CHtmlCanvasPathElementInstruction>
            ___getSVGPathIntructionsFromString(string str)
        {
            List<CHtmlCanvasPathElementInstruction> result = new List<CHtmlCanvasPathElementInstruction> ();
            char[] cs = str.ToCharArray();
            int cslen = cs.Length;
            char c = ' ';
            CHtmlCanvasPathElementInstruction  ___curPath = null;
            for(int i = 0;i < cslen; i ++)
            {
                c = cs[i];
                switch(c)
                {
                    case 'M':
                        if(___curPath != null)
                        {
                            result.Add(___curPath);
                        }
                        ___curPath = null;
                        ___curPath = new CHtmlCanvasPathElementInstruction();
                        ___curPath.commandType  = CanvasPathInstructionType.M;
                        break;
                    case 'm':
                        if (___curPath != null)
                        {
                            result.Add(___curPath);
                        }
                        ___curPath = null;
                        ___curPath = new CHtmlCanvasPathElementInstruction();
                        ___curPath.commandType = CanvasPathInstructionType.m;
                        break;
                    case 'l':
                        if (___curPath != null)
                        {
                            result.Add(___curPath);
                        }
                        ___curPath = null;
                        ___curPath = new CHtmlCanvasPathElementInstruction();
                        ___curPath.commandType = CanvasPathInstructionType.l;
                        break;
                    case 'C':
                        if (___curPath != null)
                        {
                            result.Add(___curPath);
                        }
                        ___curPath = null;
                        ___curPath = new CHtmlCanvasPathElementInstruction();
                        ___curPath.commandType = CanvasPathInstructionType.C;
                        break;
                    case 'V':
                        if (___curPath != null)
                        {
                            result.Add(___curPath);
                        }
                        ___curPath = null;
                        ___curPath = new CHtmlCanvasPathElementInstruction();
                        ___curPath.commandType = CanvasPathInstructionType.V;
                        break;
                    case 'c':
                        if (___curPath != null)
                        {
                            result.Add(___curPath);
                        }
                        ___curPath = null;
                        ___curPath = new CHtmlCanvasPathElementInstruction();
                        ___curPath.commandType = CanvasPathInstructionType.c;
                        break;
                    case 'v':
                        if (___curPath != null)
                        {
                            result.Add(___curPath);
                        }
                        ___curPath = null;
                        ___curPath = new CHtmlCanvasPathElementInstruction();
                        ___curPath.commandType = CanvasPathInstructionType.v;
                        break;
                    case 'H':
                        if (___curPath != null)
                        {
                            result.Add(___curPath);
                        }
                        ___curPath = null;
                        ___curPath = new CHtmlCanvasPathElementInstruction();
                        ___curPath.commandType = CanvasPathInstructionType.H;
                        break;
                    case 'h':
                        if (___curPath != null)
                        {
                            result.Add(___curPath);
                        }
                        ___curPath = null;
                        ___curPath = new CHtmlCanvasPathElementInstruction();
                        ___curPath.commandType = CanvasPathInstructionType.h;
                        break;
                    case 'L':
                        if (___curPath != null)
                        {
                            result.Add(___curPath);
                        }
                        ___curPath = null;
                        ___curPath = new CHtmlCanvasPathElementInstruction();
                        ___curPath.commandType = CanvasPathInstructionType.L;
                        break;
                    case 'S':
                        if (___curPath != null)
                        {
                            result.Add(___curPath);
                        }
                        ___curPath = null;
                        ___curPath = new CHtmlCanvasPathElementInstruction();
                        ___curPath.commandType = CanvasPathInstructionType.S;
                        break;
                    case 's':
                        if (___curPath != null)
                        {
                            result.Add(___curPath);
                        }
                        ___curPath = null;
                        ___curPath = new CHtmlCanvasPathElementInstruction();
                        ___curPath.commandType = CanvasPathInstructionType.s;
                        break;
                    case 'z':
                        if (___curPath != null)
                        {
                            result.Add(___curPath);
                        }
                        ___curPath = null;
                        ___curPath = new CHtmlCanvasPathElementInstruction();
                        ___curPath.commandType = CanvasPathInstructionType.Z;
                        break;
                    case 'A':
                        if (___curPath != null)
                        {
                            result.Add(___curPath);
                        }
                        ___curPath = null;
                        ___curPath = new CHtmlCanvasPathElementInstruction();
                        ___curPath.commandType = CanvasPathInstructionType.A;
                        break;
                    case 'a':
                        if (___curPath != null)
                        {
                            result.Add(___curPath);
                        }
                        ___curPath = null;
                        ___curPath = new CHtmlCanvasPathElementInstruction();
                        ___curPath.commandType = CanvasPathInstructionType.a;
                        break;
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                    case '.':
                    case '-':
                        int num_start = i;
                        System.Text.StringBuilder sbNum = new System.Text.StringBuilder(10);
                        for (int n = num_start; n < cslen; n++)
                        {
                            char num_c = cs[n];
                            if (!___isNumberEndChar(num_c))
                            {
                                sbNum.Append(num_c);
                                if(n == cslen -1 )
                                {
                                    if (sbNum != null && sbNum.Length > 0)
                                    {
                                        string strNum = sbNum.ToString();
                                        sbNum = null;

                                        double drNum;
                                        if (double.TryParse(strNum, out drNum))
                                        {
                                            if (___curPath != null)
                                            {
                                                ___curPath.datalist.Add(drNum);
                                                //___curPath.numEntryCount++;

                                            }
                                            else
                                            {
                                                if (char.IsLetter(c))
                                                {
                                                    commonLog.LogEntry("Path Value found, but list not found : {0} ", drNum);
                                                }
                                            }
                                        }
                                    }
                                    i = n;
                                }
                                continue;

                            }
                            else
                            {
                                if (sbNum.Length > 0)
                                {
                                    string strNum = sbNum.ToString();
                                    sbNum = null;
                                    
                                    double drNum;
                                    if (double.TryParse(strNum, out drNum))
                                    {
                                        if (___curPath != null)
                                        {
                                            ___curPath.datalist.Add(drNum);
                                            //___curPath.numEntryCount++;

                                        }
                                        else
                                        {
                                            if (char.IsLetter(c))
                                            {
                                                commonLog.LogEntry("Path Value found, but list not found : {0} ", drNum);
                                            }
                                        }
                                    }
                                }
                                if (char.IsLetter(num_c))
                                {
                                    i = n - 1;
                                }
                                else
                                {
                                    i = n - 1;
                                }
                                goto NextChar;
                            }
                        }
     

                        break;
                    case ' ':
                    case '\t':
                    case '\r':
                    case '\n':
                        break;
                    case ',':
                        break;
                    default:
                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                        {
                            if (char.IsLetter(c))
                            {
                                commonLog.LogEntry("Unknow Path command: " + c.ToString());
                            }
                        }
                        break;

                }
                NextChar:
                if (false) { }
            }
            if(___curPath != null)
            {
                result.Add(___curPath);
            }
            return result;
        }
        public static bool ___isNumberEndChar(char c)
        {
            if (char.IsLetter(c))
                return true;
            if (c == ' ' || c == '\t' || c == '\t' || c == '\r' || c == '\n' || c == ',')
                return true;
            return false;
        }
        public static bool ___isOdd(int value)
        {
            return value % 2 != 0;
        }
        private static void ___setSVGElementStrokeStyleWithCSSStyle(CHtmlSVGElement ___svgElement, CHtmlCanvasContext2D ___svgContext)
        {
            try
            {

                if (string.IsNullOrEmpty(___svgElement.___style.___Stroke) == false)
                {
                    ___svgContext.strokeStyle = ___svgElement.___style.___Stroke;
                }
                if (string.IsNullOrEmpty(___svgElement.___style.___StrokeWidth) == false)
                {
                    ___svgContext.lineWidth = (int)commonHTML.GetDoubleValueFromString(___svgElement.___style.___StrokeWidth, 1, 1);
                }

            }
            catch (Exception exSVGElementDraw)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                {
                    commonLog.LogEntry("___setSVGElementFillStrokeWithCSSTyle :exception : " + ___svgElement.toLogString(), exSVGElementDraw);
                }
            }

        }
        private static void ___setSVGElementFillStyleWithCSSStyle(CHtmlSVGElement ___svgElement, CHtmlCanvasContext2D ___svgContext)
        {
            bool ___targetObjectFound = false;
            try
            {
                if (___svgElement.___style.___IsBackgroundColorSpecified == true)
                {
                    string strFillColorString = ___svgElement.___style.___BackgroundColor;
                    if (strFillColorString.StartsWith("url(", StringComparison.Ordinal) == true)
                    {
                        int quoteEnd = strFillColorString.LastIndexOf(')');
                        string strInnerUrl = null;
                        if (quoteEnd == -1)
                        {
                            strInnerUrl = strFillColorString.Substring(4);
                            if (commonHTML.FasterIsWhiteSpaceLimited(strInnerUrl[0]) || commonHTML.FasterIsWhiteSpaceLimited(strInnerUrl[strInnerUrl.Length - 1]))
                            {
                                strInnerUrl = strInnerUrl.Trim();
                            }
                        }
                        else
                        {
                            strInnerUrl = strFillColorString.Substring(4, quoteEnd - 4);
                            if (commonHTML.FasterIsWhiteSpaceLimited(strInnerUrl[0]) || commonHTML.FasterIsWhiteSpaceLimited(strInnerUrl[strInnerUrl.Length - 1]))
                            {
                                strInnerUrl = strInnerUrl.Trim();
                            }
                        }
                        if (string.IsNullOrEmpty(strInnerUrl) == false)
                        {
                            char c0 = strInnerUrl[0];
                            switch (c0)
                            {
                                case '#':

                                    // element id is obtained, now looks for target fill element
                                    if (___svgContext.___parentElementWeakReference != null)
                                    {
                                        CHtmlElement ___canvasSVGElement = ___svgContext.___parentElementWeakReference.Target as CHtmlElement;
                                        if (___canvasSVGElement != null)
                                        {
                                            CHtmlCollection list = commonHTML.___getQuerySelectorListProcessorInner(___canvasSVGElement, strInnerUrl, CHtmlQuerySelectorType.element_querySelector);
                                            if (list.Count > 0)
                                            {
                                                CHtmlSVGElement ___targetSVGFillElement = list.__GetByIndex(0) as CHtmlSVGElement;
                                                if (___targetSVGFillElement != null && ___targetSVGFillElement.___brushExtentionObject != null)
                                                {
                                                    ___svgContext.___contextFillStyleAsObject = null;
                                                    ___svgContext.___contextFillStyleAsObject = ___targetSVGFillElement.___brushExtentionObject;
                                                    ___targetObjectFound = true;
                                                    return;
                                                }
                                            }
                                        }

                                    }
                                    if (!___targetObjectFound)
                                    {
                                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                                        {
                                            commonLog.LogEntry(" ___setSVGElementFillStyleWithCSSStyle() object search not found. but ok... " + strInnerUrl);
                                        }
                                    }

                                    return;
                                default:
                                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                                    {
                                        commonLog.LogEntry("TODO: ___setSVGElementFillStyleWithCSSStyle(): " + strInnerUrl);
                                    }
                                    break;
                            }
                        }
                    }
                    else
                    {
                        ___svgContext.___contextFillStyleAsObject = strFillColorString;
                    }

                }
            }
            catch (Exception exSVGElementDraw)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                {
                    commonLog.LogEntry("___setSVGElementFillStrokeWithCSSTyle :exception : " + ___svgElement.toLogString(), exSVGElementDraw);
                }
            }

        }

        #endregion

        /// <summary>
        /// Draws SVG Element
        /// (This is only called for root HTMLSvgElement.
        /// </summary>
        /// <param name="___element">Root SVG Element</param>
        /// <param name="__targetStyle"></param>
        /// <param name="elementBounds"></param>
        /// <param name="_grCon"></param>
        /// <param name="SkipText"></param>
        /// <param name="IsCursorWithinBounds"></param>
        /// 
        public static void ___drawSVGElement(CHtmlElement ___element, CHtmlCSSStyleSheet __targetStyle, RectangleF elementBounds,CHtmlGraphicContainer _grCon, bool SkipText, bool IsCursorWithinBounds)
        {

            CHtmlSVGElement ___svgRoot = ___element as CHtmlSVGElement;
            if (___svgRoot == null)
            {
                return;

            }

            System.Diagnostics.Stopwatch ___svgStopWatch = new System.Diagnostics.Stopwatch();
            CHtmlCanvasContext2D ___svgContext = null;
            try
            {
                if (___svgRoot.___isSVGImageNeedsToCreate == false)
                {
                    if (___svgRoot.___CanvasGdiImage != null)
                    {
                        _grCon.Graphic.DrawImageUnscaledAndClipped(___svgRoot.___CanvasGdiImage, Rectangle.Round(elementBounds));
                        return;
                    }
                    else
                    {
                        ___svgRoot.___isSVGImageNeedsToCreate = true;
                    }

                }
                ___svgStopWatch = new System.Diagnostics.Stopwatch();
                //
                // Last time this SVG Image is created
                // 
                DateTime ___svgImageCreationTime = DateTime.Now;

                ___svgStopWatch.Start();
                ___svgContext = ___svgRoot.___getCanvasContext_inner(commonHTML.SVG_Canvas_String, null) as CHtmlCanvasContext2D;
                int ___childLength_i1 = ___svgRoot.___childNodes.length;
                for (int i1 = 0; i1 < ___childLength_i1; i1++)
                {
                    CHtmlSVGElement ___childSVGElem_i1 = ___svgRoot.___childNodes.__GetByIndex(i1) as CHtmlSVGElement;
                    if (___childSVGElem_i1 == null)
                        continue;
                    CHtmlSVGElement.___drawSVGElementWithContext(___childSVGElem_i1, ___svgContext, ___svgImageCreationTime);

                    int ___childLength_i2 = ___childSVGElem_i1.___childNodes.length;
                    for (int i2 = 0; i2 < ___childLength_i2; i2++)
                    {
                        CHtmlSVGElement ___childSVGElem_i2 = ___childSVGElem_i1.___childNodes.__GetByIndex(i2) as CHtmlSVGElement;
                        if (___childSVGElem_i2 == null)
                            continue;
                        CHtmlSVGElement.___drawSVGElementWithContext(___childSVGElem_i2, ___svgContext, ___svgImageCreationTime);
                        int ___childLength_i3 = ___childSVGElem_i2.___childNodes.length;
                        for (int i3 = 0; i3 < ___childLength_i3; i3++)
                        {
                            CHtmlSVGElement ___childSVGElem_i3 = ___childSVGElem_i2.___childNodes.__GetByIndex(i3) as CHtmlSVGElement;
                            if (___childSVGElem_i3 == null)
                                continue;
                            CHtmlSVGElement.___drawSVGElementWithContext(___childSVGElem_i3, ___svgContext, ___svgImageCreationTime);
                            int ___childLength_i4 = ___childSVGElem_i3.___childNodes.length;
                            for (int i4 = 0; i4 < ___childLength_i4; i4++)
                            {
                                CHtmlSVGElement ___childSVGElem_i4 = ___childSVGElem_i3.___childNodes.__GetByIndex(i4) as CHtmlSVGElement;
                                if (___childSVGElem_i4 == null)
                                    continue;
                                CHtmlSVGElement.___drawSVGElementWithContext(___childSVGElem_i4, ___svgContext, ___svgImageCreationTime);
                                int ___childLength_i5 = ___childSVGElem_i4.___childNodes.length;
                                for (int i5 = 0; i5 < ___childLength_i5; i5++)
                                {
                                    CHtmlSVGElement ___childSVGElem_i5 = ___childSVGElem_i4.___childNodes.__GetByIndex(i5) as CHtmlSVGElement;
                                    if (___childSVGElem_i5 == null)
                                        continue;
                                    CHtmlSVGElement.___drawSVGElementWithContext(___childSVGElem_i5, ___svgContext, ___svgImageCreationTime);
                                    int ___childLength_i6 = ___childSVGElem_i5.___childNodes.length;
                                    for (int i6 = 0; i6 < ___childLength_i6; i6++)
                                    {
                                        CHtmlSVGElement ___childSVGElem_i6 = ___childSVGElem_i5.___childNodes.__GetByIndex(i6) as CHtmlSVGElement;
                                        if (___childSVGElem_i6 == null)
                                            continue;
                                        CHtmlSVGElement.___drawSVGElementWithContext(___childSVGElem_i6, ___svgContext, ___svgImageCreationTime);
                                        int ___childLength_i7 = ___childSVGElem_i5.___childNodes.length;
                                        for (int i7 = 0; i7 < ___childLength_i7; i7++)
                                        {
                                            CHtmlSVGElement ___childSVGElem_i7 = ___childSVGElem_i6.___childNodes.__GetByIndex(i7) as CHtmlSVGElement;
                                            if (___childSVGElem_i7 == null)
                                                continue;
                                            CHtmlSVGElement.___drawSVGElementWithContext(___childSVGElem_i7, ___svgContext, ___svgImageCreationTime);
                                            int ___childLength_i8 = ___childSVGElem_i6.___childNodes.length;
                                            for (int i8 = 0; i8 < ___childLength_i8; i8++)
                                            {
                                                CHtmlSVGElement ___childSVGElem_i8 = ___childSVGElem_i7.___childNodes.__GetByIndex(i8) as CHtmlSVGElement;
                                                if (___childSVGElem_i8 == null)
                                                    continue;
                                                CHtmlSVGElement.___drawSVGElementWithContext(___childSVGElem_i8, ___svgContext, ___svgImageCreationTime);
                                                int ___childLength_i9 = ___childSVGElem_i8.___childNodes.length;
                                                for (int i9 = 0; i9 < ___childLength_i9; i9++)
                                                {
                                                    CHtmlSVGElement ___childSVGElem_i9 = ___childSVGElem_i8.___childNodes.__GetByIndex(i9) as CHtmlSVGElement;
                                                    if (___childSVGElem_i9 == null)
                                                        continue;
                                                    CHtmlSVGElement.___drawSVGElementWithContext(___childSVGElem_i9, ___svgContext, ___svgImageCreationTime);
                                                    int ___childLength_i10 = ___childSVGElem_i9.___childNodes.length;
                                                    for (int i10 = 0; i10 < ___childLength_i10; i10++)
                                                    {
                                                        CHtmlSVGElement ___childSVGElem_i10 = ___childSVGElem_i9.___childNodes.__GetByIndex(i10) as CHtmlSVGElement;
                                                        if (___childSVGElem_i10 == null)
                                                            continue;
                                                        CHtmlSVGElement.___drawSVGElementWithContext(___childSVGElem_i10, ___svgContext, ___svgImageCreationTime);
                                                        int ___childLength_i11 = ___childSVGElem_i10.___childNodes.length;
                                                        for (int i11 = 0; i11 < ___childLength_i11; i11++)
                                                        {
                                                            CHtmlSVGElement ___childSVGElem_i11 = ___childSVGElem_i10.___childNodes.__GetByIndex(i11) as CHtmlSVGElement;
                                                            if (___childSVGElem_i11 == null)
                                                                continue;
                                                            CHtmlSVGElement.___drawSVGElementWithContext(___childSVGElem_i11, ___svgContext, ___svgImageCreationTime);

                                                            int ___childLength_i12 = ___childSVGElem_i11.___childNodes.length;
                                                            for (int i12 = 0; i12 < ___childLength_i12; i12++)
                                                            {
                                                                CHtmlSVGElement ___childSVGElem_i12 = ___childSVGElem_i11.___childNodes.__GetByIndex(i12) as CHtmlSVGElement;
                                                                if (___childSVGElem_i12 == null)
                                                                    continue;
                                                                CHtmlSVGElement.___drawSVGElementWithContext(___childSVGElem_i2, ___svgContext, ___svgImageCreationTime);
                                                                int ___childLength_i13 = ___childSVGElem_i12.___childNodes.length;
                                                                for (int i13 = 0; i13 < ___childLength_i13; i13++)
                                                                {
                                                                    CHtmlSVGElement ___childSVGElem_i13 = ___childSVGElem_i12.___childNodes.__GetByIndex(i13) as CHtmlSVGElement;
                                                                    if (___childSVGElem_i13 == null)
                                                                        continue;
                                                                    CHtmlSVGElement.___drawSVGElementWithContext(___childSVGElem_i3, ___svgContext, ___svgImageCreationTime);
                                                                    int ___childLength_i14 = ___childSVGElem_i12.___childNodes.length;
                                                                    for (int i14 = 0; i14 < ___childLength_i14; i14++)
                                                                    {
                                                                        CHtmlSVGElement ___childSVGElem_i14 = ___childSVGElem_i13.___childNodes.__GetByIndex(i14) as CHtmlSVGElement;
                                                                        if (___childSVGElem_i14 == null)
                                                                            continue;
                                                                        CHtmlSVGElement.___drawSVGElementWithContext(___childSVGElem_i4, ___svgContext, ___svgImageCreationTime);
                                                                        int ___childLength_i15 = ___childSVGElem_i14.___childNodes.length;
                                                                        for (int i15 = 0; i15 < ___childLength_i15; i15++)
                                                                        {
                                                                            CHtmlSVGElement ___childSVGElem_i15 = ___childSVGElem_i14.___childNodes.__GetByIndex(i15) as CHtmlSVGElement;
                                                                            if (___childSVGElem_i15 == null)
                                                                                continue;
                                                                            CHtmlSVGElement.___drawSVGElementWithContext(___childSVGElem_i5, ___svgContext, ___svgImageCreationTime);

                                                                            int ___childLength_i16 = ___childSVGElem_i15.___childNodes.length;
                                                                            for (int i16 = 0; i16 < ___childLength_i16; i16++)
                                                                            {
                                                                                CHtmlSVGElement ___childSVGElem_i16 = ___childSVGElem_i15.___childNodes.__GetByIndex(i16) as CHtmlSVGElement;
                                                                                if (___childSVGElem_i16 == null)
                                                                                    continue;
                                                                                CHtmlSVGElement.___drawSVGElementWithContext(___childSVGElem_i16, ___svgContext, ___svgImageCreationTime);
                                                                                int ___childLength_i17 = ___childSVGElem_i16.___childNodes.length;

                                                                                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                                                                                {
                                                                                    commonLog.LogEntry("TODO : ___drawSVGElement : {0} ___hasInner more child nodes", ___childSVGElem_i16.toLogString());
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                ___svgRoot.___svgImageCreationTime = ___svgImageCreationTime;
                ___svgRoot.___isSVGImageNeedsToCreate = false;

                ___svgContext.___disposeC2DBitmapContext();
                ___svgContext.Dispose();
                ___svgContext = null;
                ___svgStopWatch.Stop();
                if (_grCon != null && ___svgRoot.___CanvasGdiImage != null)
                {
                    _grCon.Graphic.DrawImageUnscaledAndClipped(___svgRoot.___CanvasGdiImage, Rectangle.Round(elementBounds));
                }
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 7)
                {

                    commonLog.LogEntry("___drawSVGElement({0}) ___hasInner been completed in {1} ms...", ___svgRoot.toLogString(), ___svgStopWatch.ElapsedMilliseconds);
                }

            }
            catch (Exception exSVGDrawException)
            {
                ___svgRoot.___isSVGImageNeedsToCreate = false;
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                {
                    commonLog.LogEntry("___drawSVGElement exception. ", exSVGDrawException);
                }
                if (___svgContext != null)
                {
                    ___svgContext.___disposeC2DBitmapContext();
                    ___svgContext.Dispose();
                    ___svgContext = null;
                }

            }
        }
        #region MetaObject
        public DynamicMetaObject GetMetaObject(Expression parameter)
        {
            return new CHtmlClearScriptDynamicMetaObject<CHtmlSVGElement>(parameter, this);
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
            switch (name)
            {
                case "innerHTML":
                case "checked":
                case "disabled":
                case "value":
                case "id":
                case "tagName":
                case "class":
                case "classname":
                case "className":
                case "autoPlay":
                case "classId":
                case "classid":
                case "name":
                case "nodeValue":
                case "src":
                case "auto":
                case "style":
                case "styleSheet":
                case "href":
                case "charset":
                case "characterSet":
                case "dir":
                case "type":
                case "location":
                case "async":
                case "defer":
                case "contentEditable":
                case "contenteditable":
                case "alt":
                case "lang":
                case "language":
                case "title":
                case "innerText":
                case "selected":
                case "htmlFor":
                case "htmlfor":
                case "mimetype":
                case "mimeType":
                case "width":
                case "height":
                case "crossOrigin":
                case "crossorigin":
                case "textContent":
                    this.___setPropertyByName(name, value);
                    return;

            }

            this.___properties[name] = value;
        }
        public IEnumerable<string> GetDynamicMemberNames()
        {
            List<string> members = new List<string>();
            members.AddRange(CHtmlElementProperties.Keys);
            members.AddRange(CHtmlElementMethods.Keys);
            if (this.___properties.Count > 0)
            {
                members.AddRange(this.___properties.Keys);
            }
            return members;
        }
        public DynamicMetaObject BindInvokeMember(
 InvokeMemberBinder binder, DynamicMetaObject[] args)
        {
            StringBuilder paramInfo = new StringBuilder();
            paramInfo.AppendFormat("Calling {0}(", binder.Name);
            foreach (var item in args)
                paramInfo.AppendFormat("{0}, ", item.Value);
            paramInfo.Append(")");
            Expression[] parameters = new Expression[]
            {
 Expression.Constant(paramInfo.ToString())
            };
            DynamicMetaObject methodInfo = null;
            /*
            DynamicMetaObject methodInfo = new DynamicMetaObject(
            Expression.Call(
            Expression.Convert(Expression, LimitType),
            typeof(DynamicDictionary).GetMethod("WriteMethodInfo"),
            parameters),
            BindingRestrictions.GetTypeRestriction(Expression, LimitType));
            */
            return methodInfo;
        }
        #endregion
    }
}
