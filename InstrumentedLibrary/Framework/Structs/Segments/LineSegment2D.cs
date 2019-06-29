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
    public struct LineSegment2D
        : IShapeSegment, ICachableProperties
    {
        #region Implementations
        /// <summary>
        /// The empty.
        /// </summary>
        public static LineSegment2D Empty = new LineSegment2D(0d, 0d, 0d, 0d);
        #endregion

        #region Fields
        private double aX;
        private double aY;
        private double bX;
        private double bY;
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LineSegment2D(Point2D a, Point2D b)
            : this()
        {
            this.AX = a.X;
            this.AY = a.Y;
            this.BX = b.X;
            this.BY = b.Y;
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

        #region Deconstructors
        /// <summary>
        /// Deconstruct this <see cref="LineSegment2D"/> to a <see cref="ValueTuple{T1, T2, T3, T4}"/>.
        /// </summary>
        /// <param name="XA"></param>
        /// <param name="YA"></param>
        /// <param name="XB"></param>
        /// <param name="YB"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out double XA, out double YA, out double XB, out double YB)
        {
            XA = this.AX;
            YA = this.AY;
            XB = this.BX;
            YB = this.BY;
        }

        /// <summary>
        /// Deconstruct this <see cref="LineSegment2D"/> to a <see cref="ValueTuple{T1, T2, T3, T4}"/>.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out Point2D A, out Point2D B)
        {
            A = (this.AX, this.AY);
            B = (this.BX, this.BY);
        }
        #endregion Deconstructors

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = nameof(AX)), XmlAttribute(nameof(AX)), SoapAttribute(nameof(AX))]
        public double AX { get { return aX; } set { aX = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = nameof(AY)), XmlAttribute(nameof(AY)), SoapAttribute(nameof(AY))]
        public double AY { get { return aY; } set { aY = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = nameof(BX)), XmlAttribute(nameof(BX)), SoapAttribute(nameof(BX))]
        public double BX { get { return bX; } set { bX = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = nameof(BY)), XmlAttribute(nameof(BY)), SoapAttribute(nameof(BY))]
        public double BY { get { return bY; } set { bY = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// 
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        public Point2D A { get { return (AX, AY); } set { (AX, AY) = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// 
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        public Point2D B { get { return (BX, BY); } set { (BX, BY) = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// Gets the curve x Polynomial.
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        public Polynomial CurveX
        {
            get
            {
                var (x1, _, x2, _) = this;
                var curveX = (Polynomial)(this as ICachableProperties).CachingProperty(() => Polynomial.Bezier(x1, x2));
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
                var (_, y1, _, y2) = this;
                var curveX = (Polynomial)(this as ICachableProperties).CachingProperty(() => Polynomial.Bezier(y1, y2));
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
            //if (this is null)
            //{
            //    return $"{nameof(Ray2D)}";
            //}

            var sep = ((formatProvider as CultureInfo) ?? CultureInfo.InvariantCulture).GetNumericListSeparator();
            return $"{nameof(Ray2D)}({nameof(A)}: {A.ToString(format, formatProvider)}{sep} {nameof(B)}: {B.ToString(format, formatProvider)})";
        }
    }
}
