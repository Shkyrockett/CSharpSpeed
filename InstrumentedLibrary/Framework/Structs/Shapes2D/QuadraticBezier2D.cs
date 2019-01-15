using System;

namespace InstrumentedLibrary
{
    public class QuadraticBezier2D
    {
        public QuadraticBezier2D(Point2D a, Point2D b, Point2D c)
        {
            A = a;
            B = b;
            C = c;
        }

        public Point2D A { get; internal set; }
        public Point2D B { get; internal set; }
        public Point2D C { get; internal set; }

        public Point2D Interpolate(double v) => new Point2D(InterpolateQuadraticBezier2DTests.QuadraticBezierInterpolate2D(A.X, A.Y, B.X, B.Y, C.X, C.Y, v));
    }
}