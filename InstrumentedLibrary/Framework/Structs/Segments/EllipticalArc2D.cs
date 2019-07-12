using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [ComVisible(true)]
    [DataContract, Serializable]
    [DebuggerDisplay("{ToString()}")]
    public struct EllipticalArc2D
        : IShapeSegment, ICachableProperties, IEquatable<EllipticalArc2D>
    {
        #region Implementations
        /// <summary>
        /// The empty.
        /// </summary>
        public static readonly EllipticalArc2D Empty = new EllipticalArc2D(0d, 0d, 0d, 0d, 0d, 0d, Maths.Tau);
        #endregion

        #region Fields
        private double x;
        private double y;
        private double radiusA;
        private double radiusB;
        private double angle;
        private double startAngle;
        private double sweepAngle;
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="radiusA"></param>
        /// <param name="radiusB"></param>
        /// <param name="angle"></param>
        /// <param name="startAngle"></param>
        /// <param name="sweepAngle"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EllipticalArc2D(double x, double y, double radiusA, double radiusB, double angle, double startAngle, double sweepAngle)
            : this()
        {
            X = x;
            Y = y;
            RadiusA = radiusA;
            RadiusB = radiusB;
            Angle = angle;
            StartAngle = startAngle;
            SweepAngle = sweepAngle;
        }
        #endregion

        #region Deconstructors
        /// <summary>
        /// Deconstruct this <see cref="EllipticalArc2D"/> to a <see cref="ValueTuple{T1, T2, T3, T4, T5, T6, T7}"/>.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="RadiusA"></param>
        /// <param name="RadiusB"></param>
        /// <param name="Angle"></param>
        /// <param name="StartAngle"></param>
        /// <param name="SweepAngle"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out double X, out double Y, out double RadiusA, out double RadiusB, out double Angle, out double StartAngle, out double SweepAngle)
        {
            X = this.X;
            Y = this.Y;
            RadiusA = this.RadiusA;
            RadiusB = this.RadiusB;
            Angle = this.Angle;
            StartAngle = this.StartAngle;
            SweepAngle = this.StartAngle;
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
        [DataMember(Name = nameof(RadiusA)), XmlAttribute(nameof(RadiusA)), SoapAttribute(nameof(RadiusA))]
        public double RadiusA { get { return radiusA; } set { radiusA = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = nameof(RadiusB)), XmlAttribute(nameof(RadiusB)), SoapAttribute(nameof(RadiusB))]
        public double RadiusB { get { return radiusB; } set { radiusB = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = nameof(Angle)), XmlAttribute(nameof(Angle)), SoapAttribute(nameof(Angle))]
        public double Angle { get { return angle; } set { angle = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = nameof(StartAngle)), XmlAttribute(nameof(StartAngle)), SoapAttribute(nameof(StartAngle))]
        public double StartAngle { get { return startAngle; } set { startAngle = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = nameof(SweepAngle)), XmlAttribute(nameof(SweepAngle)), SoapAttribute(nameof(SweepAngle))]
        public double SweepAngle { get { return sweepAngle; } set { sweepAngle = value; (this as ICachableProperties).ClearCache(); } }

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
        public static bool operator ==(EllipticalArc2D left, EllipticalArc2D right) => left.Equals(right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(EllipticalArc2D left, EllipticalArc2D right) => !(left == right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is EllipticalArc2D && Equals((EllipticalArc2D)obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(EllipticalArc2D other) => other.x == x && other.y == y && other.angle == angle && other.startAngle == startAngle && other.sweepAngle == sweepAngle;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(EllipticalArc2D left, EllipticalArc2D right) => left.Equals(right);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(x, y, radiusA, radiusB, angle, startAngle, sweepAngle);

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
            if (this == null) return nameof(Ellipse2D);
            var sep = ((formatProvider as CultureInfo) ?? CultureInfo.InvariantCulture).GetNumericListSeparator();
            return $"{nameof(EllipticalArc2D)}({nameof(X)}: {X.ToString(format, formatProvider)}{sep} {nameof(Y)}: {Y.ToString(format, formatProvider)}{sep} {nameof(RadiusA)}: {RadiusA.ToString(format, formatProvider)}{sep} {nameof(RadiusB)}: {RadiusB.ToString(format, formatProvider)}{sep} {nameof(Angle)}: {Angle.ToString(format, formatProvider)}{sep} {nameof(StartAngle)}: {StartAngle.ToString(format, formatProvider)}{sep} {nameof(SweepAngle)}: {SweepAngle.ToString(format, formatProvider)})";
        }
    }
}
