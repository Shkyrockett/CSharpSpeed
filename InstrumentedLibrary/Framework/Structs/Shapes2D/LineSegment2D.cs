using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    public class LineSegment2D
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LineSegment2D(Point2D a, Point2D b)
        {
            A = a;
            B = b;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LineSegment2D(double aX, double aY, double bX, double bY)
            : this(new Point2D(aX, aY), new Point2D(bX, bY))
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LineSegment2D((double aX, double aY, double bX, double bY) tuple)
            : this(new Point2D(tuple.aX, tuple.aY), new Point2D(tuple.bX, tuple.bY))
        { }

        public Point2D A { get; internal set; }

        public Point2D B { get; internal set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Point2D Interpolate(double v) => new Point2D(InterpolateLinear2DTests.LinearInterpolate2D(A.X, A.Y, B.X, B.Y, v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public QuadraticBezier2D ToQuadraticBezier2D()
        {
            return new QuadraticBezier2D(A.X, A.Y, B.X, B.Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CubicBezier2D ToCubicBezier2D()
        {
            return new CubicBezier2D(A.X, A.Y, B.X, B.Y);
        }
    }
}