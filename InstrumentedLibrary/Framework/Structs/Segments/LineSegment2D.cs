using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public struct LineSegment2D
        : IShapeSegment
    {
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LineSegment2D(Point2D a, Point2D b)
        {
            A = a;
            B = b;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LineSegment2D(double aX, double aY, double bX, double bY)
            : this(new Point2D(aX, aY), new Point2D(bX, bY))
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tuple"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LineSegment2D((double aX, double aY, double bX, double bY) tuple)
            : this(new Point2D(tuple.aX, tuple.aY), new Point2D(tuple.bX, tuple.bY))
        { }
        #endregion

        #region Properties
        public Point2D A { get; internal set; }

        public Point2D B { get; internal set; }
        #endregion

        #region Operators
        /// <summary>
        /// Implicit conversion from tuple.
        /// </summary>
        /// <param name="tuple"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator LineSegment2D((double x1, double y1, double x2, double y2) tuple)
            => new LineSegment2D(tuple.x1, tuple.y1, tuple.x2, tuple.y2);

        /// <summary>
        /// Implicit conversion from tuple.
        /// </summary>
        /// <param name="tuple"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator LineSegment2D((Point2D p1, Point2D p2, Point2D p3, Point2D p4) tuple)
            => new LineSegment2D(tuple.p1, tuple.p2);

        /// <summary>
        /// Converts the specified <see cref="LineSegment2D"/> structure to a <see cref="ValueTuple{T1, T2, T3, T4}"/> structure.
        /// </summary>
        /// <param name="bezier">The <see cref="ValueTuple{T1, T2, T3, T4}"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator (double x1, double y1, double x2, double y2)(LineSegment2D bezier)
            => (bezier.A.X, bezier.A.Y, bezier.B.X, bezier.B.Y);

        /// <summary>
        /// Converts the specified <see cref="LineSegment2D"/> structure to a <see cref="ValueTuple{T1, T2}"/> structure.
        /// </summary>
        /// <param name="bezier">The <see cref="ValueTuple{T1, T2, T3}"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator (Point2D p1, Point2D p2)(LineSegment2D bezier)
            => ((bezier.A.X, bezier.A.Y), (bezier.B.X, bezier.B.Y));
        #endregion Operators

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Point2D Interpolate(double v) => new Point2D(InterpolateLinear2DTests.LinearInterpolate2D(A.X, A.Y, B.X, B.Y, v));

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public QuadraticBezier2D ToQuadraticBezier2D() => new QuadraticBezier2D(A.X, A.Y, B.X, B.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CubicBezier2D ToCubicBezier2D() => new CubicBezier2D(A.X, A.Y, B.X, B.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider) => throw new NotImplementedException();
    }
}