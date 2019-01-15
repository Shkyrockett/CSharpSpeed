using System;

namespace InstrumentedLibrary
{
    public class CubicBezier2D
    {
        public CubicBezier2D(Point2D a, Point2D b, Point2D c, Point2D d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        public Point2D A { get; internal set; }
        public Point2D B { get; internal set; }
        public Point2D C { get; internal set; }
        public Point2D D { get; internal set; }

        public Point2D Interpolate(double v) => new Point2D(InterpolateCubicBezier2DTests.CubicBezierCurve(A.X, A.Y, B.X, B.Y, C.X, C.Y, D.X, D.Y, v));
    }
}