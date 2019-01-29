using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    public class QuadraticBezier2D
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public QuadraticBezier2D(Point2D a, Point2D b, Point2D c)
        {
            A = a;
            B = b;
            C = c;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public QuadraticBezier2D(double aX, double aY, double bX, double bY)
            : this(LineSegmentToQuadraticBezierSegmentTests.LineSegmentToQuadraticBezier(aX, aY, bX, bY))
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public QuadraticBezier2D(double aX, double aY, double bX, double bY, double cX, double cY)
            : this(new Point2D(aX, aY), new Point2D(bX, bY), new Point2D(cX, cY))
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public QuadraticBezier2D((double aX, double aY, double bX, double bY, double cX, double cY) tuple)
            : this(new Point2D(tuple.aX, tuple.aY), new Point2D(tuple.bX, tuple.bY), new Point2D(tuple.cX, tuple.cY))
        { }

        public Point2D A { get; internal set; }

        public Point2D B { get; internal set; }

        public Point2D C { get; internal set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Point2D Interpolate(double v) => new Point2D(InterpolateQuadraticBezier2DTests.QuadraticBezierInterpolate2D(A.X, A.Y, B.X, B.Y, C.X, C.Y, v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CubicBezier2D ToCubicBezier2D()
        {
            return new CubicBezier2D(A.X, A.Y, B.X, B.Y, C.X, C.Y);
        }
    }
}