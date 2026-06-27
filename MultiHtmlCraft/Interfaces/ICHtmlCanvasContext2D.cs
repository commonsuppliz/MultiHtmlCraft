using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal interface ICHtmlCanvasContext2D
    {
        public object fillStyle { get; set; }
        public object strokeStyle { get; set; }
        public double lineWidth { get; set; }
        public string lineCap { get; set; }
        public string lineJoin { get; set; }
        public double miterLimit { get; set; }
        public double gobalAlpha { get; set; }
        public string font { get; set; }
        public string textAlign { get; set; }
        public string textBaseline { get; set; }
        public string shadowColor { get; set; }
        public double shadowBlur { get; set; }
        public double shadowOffsetX { get; set; }
        public double shadowOffsetY { get; set; }
        public void clip();
    }

}
