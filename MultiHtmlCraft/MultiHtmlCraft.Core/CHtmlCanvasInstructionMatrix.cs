using System;
using System.Collections.Generic;
using System.Text;

namespace MultiHtmlCraft.Core
{
    public class CHtmlCanvasInstructionMatrix
    {
        public double A { get; }
        public double B { get; }
        public double C { get; }
        public double D { get; }
        public double E { get; }
        public double F { get; }

        public CHtmlCanvasInstructionMatrix(double a, double b, double c, double d, double e, double f)
        {
            A = a; B = b; C = c; D = d; E = e; F = f;
        }
    }
}
