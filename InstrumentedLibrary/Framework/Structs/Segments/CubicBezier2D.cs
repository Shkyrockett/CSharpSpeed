using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public struct CubicBezier2D
        : IShapeSegment
    {
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CubicBezier2D(Point2D a, Point2D b, Point2D c, Point2D d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
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
        public CubicBezier2D(double aX, double aY, double bX, double bY)
            : this(LineSegmentToCubicBezierTests.LineSegmentToCubicBezier(aX, aY, bX, bY))
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
        public CubicBezier2D(double aX, double aY, double bX, double bY, double cX, double cY)
            : this(QuadraticBezierToCubicBezierTests.QuadraticBezierToCubicBezier(aX, aY, bX, bY, cX, cY))
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
        /// <param name="dX"></param>
        /// <param name="dY"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CubicBezier2D(double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY)
            : this(new Point2D(aX, aY), new Point2D(bX, bY), new Point2D(cX, cY), new Point2D(dX, dY))
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tuple"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CubicBezier2D((double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY) tuple)
            : this(new Point2D(tuple.aX, tuple.aY), new Point2D(tuple.bX, tuple.bY), new Point2D(tuple.cX, tuple.cY), new Point2D(tuple.dX, tuple.dY))
        { }
        #endregion Constructors

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        [DataMember, XmlAttribute, SoapAttribute]
        public Point2D A { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember, XmlAttribute, SoapAttribute]
        public Point2D B { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember, XmlAttribute, SoapAttribute]
        public Point2D C { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember, XmlAttribute, SoapAttribute]
        public Point2D D { get; internal set; }
        #endregion Properties

        #region Operators
        /// <summary>
        /// Implicit conversion from tuple.
        /// </summary>
        /// <param name="tuple"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator CubicBezier2D((double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4) tuple)
            => new CubicBezier2D(tuple.x1, tuple.y1, tuple.x2, tuple.y2, tuple.x3, tuple.y3, tuple.x4, tuple.y4);

        /// <summary>
        /// Implicit conversion from tuple.
        /// </summary>
        /// <param name="tuple"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator CubicBezier2D((Point2D p1, Point2D p2, Point2D p3, Point2D p4) tuple)
            => new CubicBezier2D(tuple.p1, tuple.p2, tuple.p3, tuple.p4);

        /// <summary>
        /// Converts the specified <see cref="Point2D"/> structure to a <see cref="ValueTuple{T1, T2, T3, T4, T5, T6, T7, T8}"/> structure.
        /// </summary>
        /// <param name="bezier">The <see cref="Point2D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator (double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)(CubicBezier2D bezier)
            => (bezier.A.X, bezier.A.Y, bezier.B.X, bezier.B.Y, bezier.C.X, bezier.C.Y, bezier.D.X, bezier.D.Y);

        /// <summary>
        /// Converts the specified <see cref="Point2D"/> structure to a <see cref="ValueTuple{T1, T2, T3, T4}"/> structure.
        /// </summary>
        /// <param name="bezier">The <see cref="Point2D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator (Point2D p1, Point2D p2, Point2D p3, Point2D p4)(CubicBezier2D bezier)
            => ((bezier.A.X, bezier.A.Y), (bezier.B.X, bezier.B.Y), (bezier.C.X, bezier.C.Y), (bezier.D.X, bezier.D.Y));
        #endregion Operators

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Point2D Interpolate(double v) => BezierInterpolateCubic2DTests.CubicBezierCurve(A.X, A.Y, B.X, B.Y, C.X, C.Y, D.X, D.Y, v);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public (CubicBezier2D, CubicBezier2D) Split(double t) => BisectCubicBezierTests.BisectCubicBezier(A.X, A.Y, B.X, B.Y, C.X, C.Y, D.X, D.Y, t);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public (Point2D, double) FindNearestPoint(Point2D pt) => NearestPointOnCubicBezierTests.FindNearestPoint(A.X, A.Y, B.X, B.Y, C.X, C.Y, D.X, D.Y, pt.X, pt.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider) => throw new NotImplementedException();
    }
}