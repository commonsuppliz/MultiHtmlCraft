using System;
using System.Collections.Generic;
using System.Text;

namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// stores canvas information 
    /// see: http://honttoni.blog74.fc2.com/blog-entry-198.html
    /// </summary>
    internal sealed class CHtmlCanvasState
    {
        internal object ___contextStrokeStyleAsObject;
        internal object ___contextShadowColorAsObject;
        internal double ___contextShadowBlur = 0;
        internal double ___contextShadowOffsetX = 0;
        internal double ___contextShadowOffsetY = 0;
        internal object ___contextLineCap = null;
        internal object ___contextLineJoin = null;
        internal double ___contextLineWidth = 1;
        internal double ___contextMiterLimit = 0;
        internal object ___contextFontAsObject = null;
        internal string ___contextFontAsString = null;
        internal object ___contextFillStyleAsObject = null;
        internal object ___contextTextAlignAsObject = null;
        internal object ___contextTextBaseline = null;
        internal object ___contextglobalCompositeOperationAsObject = null;
        internal double ___contextGlobalAlpha = 1;
        internal int ___contextGlobalAlpha255 = 255;
        internal PointFSpec ___contextTranslatePoint = PointFSpec.Empty;
        internal float ___contextRotateAngle = 0;
        internal CHtmlCanvasState()
        {

        }

    }
}
