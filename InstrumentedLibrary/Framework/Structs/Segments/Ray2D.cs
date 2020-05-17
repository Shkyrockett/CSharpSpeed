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
    public struct Ray2D
        : IShapeSegment, ICachableProperties, IEquatable<Ray2D>
    {
        #region Fields
        private double x;
        private double y;
        private double i;
        private double j;
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Ray2D(double x, double y, double i, double j)
            : this()
        {
            X = x;
            Y = y;
            I = i;
            J = j;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="direction"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Ray2D(Point2D location, Vector2D direction)
            : this(location.X, location.Y, direction.I, direction.J)
        { }
        #endregion

        #region Deconstructors
        /// <summary>
        /// Deconstruct this <see cref="Ray2D"/> to a <see cref="ValueTuple{T1, T2, T3, T4}"/>.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="I"></param>
        /// <param name="J"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out double X, out double Y, out double I, out double J)
        {
            X = this.X;
            Y = this.Y;
            I = this.I;
            J = this.J;
        }
        #endregion Deconstructors

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = nameof(X)), XmlAttribute(nameof(X)), SoapAttribute(nameof(X))]
        public double X { get { return x; } set { x = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = nameof(Y)), XmlAttribute(nameof(Y)), SoapAttribute(nameof(Y))]
        public double Y { get { return y; } set { y = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = nameof(I)), XmlAttribute(nameof(I)), SoapAttribute(nameof(I))]
        public double I { get { return i; } set { i = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = nameof(J)), XmlAttribute(nameof(J)), SoapAttribute(nameof(J))]
        public double J { get { return j; } set { j = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// Property cache for commonly used properties that may take time to calculate.
        /// </summary>
        [Browsable(false)]
        [field: NonSerialized]
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        Dictionary<object, object> ICachableProperties.PropertyCache { get; set; }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Ray2D left, Ray2D right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Ray2D left, Ray2D right)
        {
            return !(left == right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is Ray2D && Equals((Ray2D)obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Ray2D other) => other.x == x && other.y == y && other.i == i && other.j == j;

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(Ray2D left, Ray2D right) => left.Equals(right);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(x, y, i, j);

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
            if (this == null) return $"{nameof(Ray2D)}";
            var sep = ((formatProvider as CultureInfo) ?? CultureInfo.InvariantCulture).GetNumericListSeparator();
            return $"{nameof(Ray2D)}({nameof(X)}: {X.ToString(format, formatProvider)}{sep} {nameof(Y)}: {Y.ToString(format, formatProvider)}{sep} {nameof(I)}: {I.ToString(format, formatProvider)}{sep} {nameof(J)}: {J.ToString(format, formatProvider)})";
        }
    }
}
