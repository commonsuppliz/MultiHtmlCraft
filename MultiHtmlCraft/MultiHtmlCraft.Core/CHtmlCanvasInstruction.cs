using System;
using System.Collections.Generic;
using System.Text;

namespace MultiHtmlCraft.Core
{
    
    public enum CanvasInstructionType : byte
    {
        None,
        Save,
        Restore,
        BeginPath,
        ClosePath,
        MoveTo,
        LineTo,
        FillRect,
        StrokeRect,
        Fill,
        Stroke,
        Arc,
        ArcTo,
        BezierCurveTo,
        Ellipse,
        Rect,
        Scale,
        Translate,
        Rotate,
        Transform,
        SetTransform,
        Clip,
        ResetTransform,
        QuadraticCurveTo
    }
    public sealed class CHtmlCanvasContextInstruction 
    {
        public CanvasInstructionType InstructionType;
        public float floatValue;
        public PointFSpec point;
        public PointFSpec controlPoint1;
        public PointFSpec controlPoint2;
        public float startAngle;
        public float endAngle;
        public float radius;
        public float rx;
        public float ry;
        public float rotation;
        public bool anticlockwise;
        public RectangleFSpec rectangle;
        public CHtmlCanvasInstructionMatrix matrix;
    }
}
