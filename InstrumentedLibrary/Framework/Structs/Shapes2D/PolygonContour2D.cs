using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The polygon contour class.
    /// </summary>
    [ComVisible(true)]
    [DataContract, Serializable]
    [DebuggerDisplay("{ToString()}")]
    public struct PolygonContour2D
        : IClosedShape, ICachableProperties, IEquatable<PolygonContour2D>
    {
        #region Implementations
        /// <summary>
        /// The empty.
        /// </summary>
        public static readonly PolygonContour2D Empty = new PolygonContour2D(new[] { Point2D.Empty });
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="PolygonContour2D"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PolygonContour2D(IEnumerable<Point2D> points)
            : this()
        {
            Points = points.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PolygonContour2D(params Point2D[] array)
            : this(array.ToList())
        { }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the points.
        /// </summary>
        [DataMember(Name = nameof(Points)), XmlArray(nameof(Points)), SoapElement(nameof(Points))]
        public IList<Point2D> Points { get; set; }

        /// <summary>
        /// Gets the count.
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        public int Count => Points?.Count() ?? 0;

        /// <summary>
        /// 
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        public RotationDirection Orientation => PolygonIsOrientedClockwiseTests.PolygonIsOrientedClockwise(Points.Cast<(double X, double Y)>().ToArray()) ? RotationDirection.Clockwise : RotationDirection.CounterClockwise;

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
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(PolygonContour2D left, PolygonContour2D right) => left.Equals(right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(PolygonContour2D left, PolygonContour2D right) => !(left == right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="polygon"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator List<Point2D>(PolygonContour2D polygon) => polygon.Points as List<Point2D>;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public List<Point2D> ToList()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(Points);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is PolygonContour2D && Equals((PolygonContour2D)obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PolygonContour2D other) => other.Points == Points;

        /// <summary>
        /// Tests whether <paramref name="left"/> is a <see cref="PolygonContour2D"/> with the same as <paramref name="right"/>.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(PolygonContour2D left, PolygonContour2D right) => left.Equals(right);

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
            if (this == null) return nameof(PolygonContour2D);
            var sep = $"{((formatProvider as CultureInfo) ?? CultureInfo.InvariantCulture).GetNumericListSeparator()} ";
            return $"{nameof(PolygonContour2D)}({string.Join(sep, Points)})";
        }
    }
}
