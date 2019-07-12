using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [ComVisible(true)]
    [DataContract, Serializable]
    [DebuggerDisplay("{ToString()}")]
    public struct CubicBezier2D
        : IShapeSegment, ICachableProperties, IEquatable<CubicBezier2D>
    {
        #region Fields
        private Point2D a;
        private Point2D b;
        private Point2D c;
        private Point2D d;
        #endregion

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
            : this()
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

        #region Deconstructors
        /// <summary>
        /// Deconstruct this <see cref="CubicBezier2D"/> to a <see cref="ValueTuple{T1, T2, T3, T4}"/>.
        /// </summary>
        /// <param name="AY"></param>
        /// <param name="AX"></param>
        /// <param name="BX"></param>
        /// <param name="BY"></param>
        /// <param name="CX"></param>
        /// <param name="CY"></param>
        /// <param name="DX"></param>
        /// <param name="DY"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out double AY, out double AX, out double BX, out double BY, out double CX, out double CY, out double DX, out double DY)
        {
            AX = this.A.X;
            AY = this.A.Y;
            BX = this.B.X;
            BY = this.B.Y;
            CX = this.C.X;
            CY = this.C.Y;
            DX = this.D.X;
            DY = this.D.Y;
        }

        /// <summary>
        /// Deconstruct this <see cref="CubicBezier2D"/> to a <see cref="ValueTuple{T1, T2, T3, T4}"/>.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out Point2D A, out Point2D B, out Point2D C, out Point2D D)
        {
            A = this.A;
            B = this.B;
            C = this.C;
            D = this.D;
        }
        #endregion Deconstructors

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = nameof(A)), XmlElement(nameof(A)), SoapElement(nameof(A))]
        public Point2D A { get { return a; } set { a = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = nameof(B)), XmlElement(nameof(B)), SoapElement(nameof(B))]
        public Point2D B { get { return b; } set { b = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = nameof(C)), XmlElement(nameof(C)), SoapElement(nameof(C))]
        public Point2D C { get { return c; } set { c = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = nameof(D)), XmlElement(nameof(D)), SoapElement(nameof(D))]
        public Point2D D { get { return d; } set { d = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// Gets the curve x Polynomial.
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        public Polynomial CurveX
        {
            get
            {
                var (a, b, c, d) = this;
                var curveX = (Polynomial)(this as ICachableProperties).CachingProperty(() => Polynomial.Bezier(a.X, b.X, c.X, d.X));
                curveX.IsReadonly = true;
                return curveX;
            }
        }

        /// <summary>
        /// Gets the curve y Polynomial.
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        public Polynomial CurveY
        {
            get
            {
                var (a, b, c, d) = this;
                var curveX = (Polynomial)(this as ICachableProperties).CachingProperty(() => Polynomial.Bezier(a.Y, b.Y, c.Y, d.Y));
                curveX.IsReadonly = true;
                return curveX;
            }
        }

        /// <summary>
        /// Property cache for commonly used properties that may take time to calculate.
        /// </summary>
        [Browsable(false)]
        [field: NonSerialized]
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        Dictionary<object, object> ICachableProperties.PropertyCache { get; set; }
        #endregion Properties

        #region Operators
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(CubicBezier2D left, CubicBezier2D right) => left.Equals(right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(CubicBezier2D left, CubicBezier2D right) => !(left == right);

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
        public Point2D Interpolate(double v) => BezierInterpolateCubic2DTests.CubicBezierCurve(v, A.X, A.Y, B.X, B.Y, C.X, C.Y, D.X, D.Y);

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
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CubicBezier2D ToCubicBezier2D()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public (double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4) To() => (a.X, a.Y, b.X, b.Y, c.X, c.Y, d.X, d.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is CubicBezier2D && Equals((CubicBezier2D)obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(CubicBezier2D other) => other.a == a && other.b == b && other.c == c && other.d == d;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(CubicBezier2D left, CubicBezier2D right) => left.Equals(right);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(a, b, c, d);

        /// <summary>
        /// Creates a <see cref="string"/> representation of this <see cref="IShape"/> interface based on the current culture.
        /// </summary>
        /// <returns>A <see cref="string"/> representation of this instance of the <see cref="IShape"/> object.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => ToString("R" /* format string */, CultureInfo.InvariantCulture /* format provider */);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (this == null) return nameof(CubicBezier2D);
            var sep = ((formatProvider as CultureInfo) ?? CultureInfo.InvariantCulture).GetNumericListSeparator();
            return $"{nameof(CubicBezier2D)}({nameof(A)}: {A.ToString(format, formatProvider)}{sep} {nameof(B)}: {B.ToString(format, formatProvider)}{sep} {nameof(C)}: {C.ToString(format, formatProvider)}{sep} {nameof(D)}: {D.ToString(format, formatProvider)})";
        }
    }
}
