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
    /// The circle struct.
    /// </summary>
    [ComVisible(true)]
    [DataContract, Serializable]
    [DebuggerDisplay("{ToString()}")]
    public struct Ellipse2D
        : IClosedShape, ICachableProperties, IEquatable<Ellipse2D>
    {
        #region Implementations
        /// <summary>
        /// The empty.
        /// </summary>
        public static readonly Ellipse2D Empty = new Ellipse2D(0d, 0d, 0d, 0d);
        #endregion

        #region Fields
        private double x;
        private double y;
        private double radiusA;
        private double radiusB;
        private double angle;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Ellipse2D"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="radiusA">The radius a.</param>
        /// <param name="radiusB">The radius b.</param>
        /// <param name="angle">The angle the <see cref="Ellipse2D"/> is rotated about the center.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Ellipse2D(double x, double y, double radiusA, double radiusB, double angle = 0)
            : this()
        {
            X = x;
            Y = y;
            RadiusA = radiusA;
            RadiusB = radiusB;
            Angle = angle;
        }
        #endregion

        #region Deconstructors
        /// <summary>
        /// Deconstruct this <see cref="Ellipse2D"/> to a <see cref="ValueTuple{T1, T2, T3, T4, T5}"/>.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="RadiusA"></param>
        /// <param name="RadiusB"></param>
        /// <param name="Angle"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out double X, out double Y, out double RadiusA, out double RadiusB, out double Angle)
        {
            X = this.X;
            Y = this.Y;
            RadiusA = this.RadiusA;
            RadiusB = this.RadiusB;
            Angle = this.Angle;
        }

        /// <summary>
        /// Deconstruct this <see cref="Ellipse2D"/> to a <see cref="ValueTuple{T1, T2, T3, T4}"/>.
        /// </summary>
        /// <param name="X">The left.</param>
        /// <param name="Y">The top.</param>
        /// <param name="RadiusA">The radius a.</param>
        /// <param name="RadiusB">The radius b.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out double X, out double Y, out double RadiusA, out double RadiusB)
        {
            X = this.X;
            Y = this.Y;
            RadiusA = this.RadiusA;
            RadiusB = this.RadiusB;
        }
        #endregion Deconstructors

        #region Properties
        /// <summary>
        /// Gets or sets the center <see cref="X"/> coordinate.
        /// </summary>
        [DataMember(Name = nameof(X)), XmlAttribute(nameof(X)), SoapAttribute(nameof(X))]
        public double X { get { return x; } set { x = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// Gets or sets the center <see cref="Y"/> coordinate.
        /// </summary>
        [DataMember(Name = nameof(Y)), XmlAttribute(nameof(Y)), SoapAttribute(nameof(Y))]
        public double Y { get { return y; } set { y = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// Gets or sets the a radius.
        /// </summary>
        [DataMember(Name = nameof(RadiusA)), XmlAttribute(nameof(RadiusA)), SoapAttribute(nameof(RadiusA))]
        public double RadiusA { get { return radiusA; } set { radiusA = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// Gets or sets the b radius.
        /// </summary>
        [DataMember(Name = nameof(RadiusB)), XmlAttribute(nameof(RadiusB)), SoapAttribute(nameof(RadiusB))]
        public double RadiusB { get { return radiusB; } set { radiusB = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// Gets or sets the angle the <see cref="Ellipse2D"/> is rotated about the center.
        /// </summary>
        [DataMember(Name = nameof(Angle)), XmlAttribute(nameof(Angle)), SoapAttribute(nameof(Angle))]
        public double Angle { get { return angle; } set { angle = value; (this as ICachableProperties).ClearCache(); } }

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
        public static bool operator ==(Ellipse2D left, Ellipse2D right)
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
        public static bool operator !=(Ellipse2D left, Ellipse2D right)
        {
            return !(left == right);
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is Ellipse2D && Equals((Ellipse2D)obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Ellipse2D other) => other.X == X && other.Y == Y && other.RadiusA == RadiusA && other.RadiusB == RadiusB && other.Angle == Angle;

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(Ellipse2D left, Ellipse2D right) => left.Equals(right);

        /// <summary>
        /// Get the hash code.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(X, Y, RadiusA, RadiusB, Angle);

        /// <summary>
        /// Creates a <see cref="string"/> representation of this <see cref="IShape"/> interface based on the current culture.
        /// </summary>
        /// <returns>A <see cref="string"/> representation of this instance of the <see cref="IShape"/> object.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => ToString("R" /* format string */, CultureInfo.InvariantCulture /* format provider */);

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (this == null) return nameof(Ellipse2D);
            var sep = ((formatProvider as CultureInfo) ?? CultureInfo.InvariantCulture).GetNumericListSeparator();
            return $"{nameof(Ellipse2D)}({nameof(X)}: {X.ToString(format, formatProvider)}{sep} {nameof(Y)}: {Y.ToString(format, formatProvider)}{sep} {nameof(RadiusA)}: {RadiusA.ToString(format, formatProvider)}{sep} {nameof(RadiusB)}: {RadiusB.ToString(format, formatProvider)}{sep} {nameof(Angle)}: {Angle.ToString(format, formatProvider)})";
        }
    }
}
