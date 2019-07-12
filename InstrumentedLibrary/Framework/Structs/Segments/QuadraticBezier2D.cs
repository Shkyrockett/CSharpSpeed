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
    public struct QuadraticBezier2D
        : IShapeSegment, ICachableProperties, IEquatable<QuadraticBezier2D>
    {
        #region Fields
        private Point2D a;
        private Point2D b;
        private Point2D c;
        #endregion

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
            : this()
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

        #region Deconstructors
        /// <summary>
        /// Deconstruct this <see cref="QuadraticBezier2D"/> to a <see cref="ValueTuple{T1, T2, T3}"/>.
        /// </summary>
        /// <param name="AX"></param>
        /// <param name="AY"></param>
        /// <param name="BX"></param>
        /// <param name="BY"></param>
        /// <param name="CX"></param>
        /// <param name="CY"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out double AX, out double AY, out double BX, out double BY, out double CX, out double CY)
        {
            AX = this.A.X;
            AY = this.A.Y;
            BX = this.B.X;
            BY = this.B.Y;
            CX = this.C.X;
            CY = this.C.Y;
        }

        /// <summary>
        /// Deconstruct this <see cref="QuadraticBezier2D"/> to a <see cref="ValueTuple{T1, T2, T3}"/>.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out Point2D A, out Point2D B, out Point2D C)
        {
            A = this.A;
            B = this.B;
            C = this.C;
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
        /// Gets the curve x Polynomial.
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        public Polynomial CurveX
        {
            get
            {
                var (a, b, c) = this;
                var curveX = (Polynomial)(this as ICachableProperties).CachingProperty(() => Polynomial.Bezier(a.X, b.X, c.X));
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
                var (a, b, c) = this;
                var curveX = (Polynomial)(this as ICachableProperties).CachingProperty(() => Polynomial.Bezier(a.Y, b.Y, c.Y));
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
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(QuadraticBezier2D left, QuadraticBezier2D right) => left.Equals(right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(QuadraticBezier2D left, QuadraticBezier2D right) => !(left == right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is QuadraticBezier2D && Equals((QuadraticBezier2D)obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(QuadraticBezier2D other) => other.a == a && other.b == b && other.c == c;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(QuadraticBezier2D left, QuadraticBezier2D right) => left.Equals(right);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(a, b, c);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Point2D Interpolate(double t) => new Point2D(InterpolateBezierQuadratic2DTests.QuadraticBezierInterpolate2D(t, A.X, A.Y, B.X, B.Y, C.X, C.Y));

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
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public (double x1, double y1, double x2, double y2, double x3, double y3) To() => (a.X, a.Y, b.X, b.Y, c.X, c.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public QuadraticBezier2D ToQuadraticBezier2D()
        {
            throw new NotImplementedException();
        }

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
            if (this == null) return nameof(QuadraticBezier2D);
            var sep = ((formatProvider as CultureInfo) ?? CultureInfo.InvariantCulture).GetNumericListSeparator();
            return $"{nameof(QuadraticBezier2D)}({nameof(A)}: {A.ToString(format, formatProvider)}{sep} {nameof(B)}: {B.ToString(format, formatProvider)}{sep} {nameof(C)}: {C.ToString(format, formatProvider)})";
        }
    }
}
