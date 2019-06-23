using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public struct QuadraticBezier2D
        : IShapeSegment
    {
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public QuadraticBezier2D(Point2D a, Point2D b, Point2D c)
        {
            A = a;
            B = b;
            C = c;
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
        public QuadraticBezier2D(double aX, double aY, double bX, double bY)
            : this(LineSegmentToQuadraticBezierSegmentTests.LineSegmentToQuadraticBezier(aX, aY, bX, bY))
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public QuadraticBezier2D(double aX, double aY, double bX, double bY, double cX, double cY)
            : this(new Point2D(aX, aY), new Point2D(bX, bY), new Point2D(cX, cY))
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tuple"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public QuadraticBezier2D((double aX, double aY, double bX, double bY, double cX, double cY) tuple)
            : this(new Point2D(tuple.aX, tuple.aY), new Point2D(tuple.bX, tuple.bY), new Point2D(tuple.cX, tuple.cY))
        { }
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public Point2D A { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public Point2D B { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public Point2D C { get; internal set; }
        #endregion

        #region Operators
        /// <summary>
        /// Implicit conversion from tuple.
        /// </summary>
        /// <param name="tuple"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator QuadraticBezier2D((double x1, double y1, double x2, double y2, double x3, double y3) tuple)
            => new QuadraticBezier2D(tuple.x1, tuple.y1, tuple.x2, tuple.y2, tuple.x3, tuple.y3);

        /// <summary>
        /// Implicit conversion from tuple.
        /// </summary>
        /// <param name="tuple"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator QuadraticBezier2D((Point2D p1, Point2D p2, Point2D p3, Point2D p4) tuple)
            => new QuadraticBezier2D(tuple.p1, tuple.p2, tuple.p3);

        /// <summary>
        /// Converts the specified <see cref="QuadraticBezier2D"/> structure to a <see cref="ValueTuple{T1, T2, T3, T4, T5, T6}"/> structure.
        /// </summary>
        /// <param name="bezier">The <see cref="ValueTuple{T1, T2, T3, T4, T5, T6}"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator (double x1, double y1, double x2, double y2, double x3, double y3)(QuadraticBezier2D bezier)
            => (bezier.A.X, bezier.A.Y, bezier.B.X, bezier.B.Y, bezier.C.X, bezier.C.Y);

        /// <summary>
        /// Converts the specified <see cref="QuadraticBezier2D"/> structure to a <see cref="ValueTuple{T1, T2, T3}"/> structure.
        /// </summary>
        /// <param name="bezier">The <see cref="ValueTuple{T1, T2, T3}"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator (Point2D p1, Point2D p2, Point2D p3)(QuadraticBezier2D bezier)
            => ((bezier.A.X, bezier.A.Y), (bezier.B.X, bezier.B.Y), (bezier.C.X, bezier.C.Y));
        #endregion Operators

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Point2D Interpolate(double v) => new Point2D(InterpolateBezierQuadratic2DTests.QuadraticBezierInterpolate2D(A.X, A.Y, B.X, B.Y, C.X, C.Y, v));

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CubicBezier2D ToCubicBezier2D() => new CubicBezier2D(A.X, A.Y, B.X, B.Y, C.X, C.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public string ToString(string format, IFormatProvider formatProvider) => throw new NotImplementedException();
    }
}