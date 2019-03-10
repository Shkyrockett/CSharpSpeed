using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    public class CubicBezier2D
    {
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CubicBezier2D(Point2D a, Point2D b, Point2D c, Point2D d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CubicBezier2D(double aX, double aY, double bX, double bY)
            : this(LineSegmentToCubicBezierTests.LineSegmentToCubicBezier(aX, aY, bX, bY))
        { }

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CubicBezier2D(double aX, double aY, double bX, double bY, double cX, double cY)
            : this(QuadraticBezierToCubicBezierTests.QuadraticBezierToCubicBezier(aX, aY, bX, bY, cX, cY))
        { }

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CubicBezier2D(double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY)
            : this(new Point2D(aX, aY), new Point2D(bX, bY), new Point2D(cX, cY), new Point2D(dX, dY))
        { }

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CubicBezier2D((double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY) tuple)
            : this(new Point2D(tuple.aX, tuple.aY), new Point2D(tuple.bX, tuple.bY), new Point2D(tuple.cX, tuple.cY), new Point2D(tuple.dX, tuple.dY))
        { }

        public Point2D A { get; internal set; }

        public Point2D B { get; internal set; }

        public Point2D C { get; internal set; }

        public Point2D D { get; internal set; }

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Point2D Interpolate(double v) => new Point2D(InterpolateCubicBezier2DTests.CubicBezierCurve(A.X, A.Y, B.X, B.Y, C.X, C.Y, D.X, D.Y, v));
    }
}