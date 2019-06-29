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
    /// The polyline struct.
    /// </summary>
    [ComVisible(true)]
    [DataContract, Serializable]
    [DebuggerDisplay("{ToString()}")]
    public struct Polyline2D
        : IShapeSegment, ICachableProperties
    {
        #region Implementations
        /// <summary>
        /// The empty.
        /// </summary>
        public static Polyline2D Empty = new Polyline2D(new[] { Point2D.Empty });
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Polyline2D"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Polyline2D(List<Point2D> points)
            : this()
        {
            Points = points;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Polyline2D(params Point2D[] array)
            : this(array.ToList())
        { }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the points.
        /// </summary>
        [DataMember(Name = nameof(Points)), XmlArray(nameof(Points)), SoapElement(nameof(Points))]
        public List<Point2D> Points { get; set; }

        /// <summary>
        /// Gets the count.
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        public int Count => Points?.Count ?? 0;

        /// <summary>
        /// Property cache for commonly used properties that may take time to calculate.
        /// </summary>
        [Browsable(false)]
        [field: NonSerialized]
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        Dictionary<object, object> ICachableProperties.PropertyCache { get; set; }
        #endregion

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
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            //if (this is null)
            //{
            //    return nameof(Polyline2D);
            //}

            var sep = $"{((formatProvider as CultureInfo) ?? CultureInfo.InvariantCulture).GetNumericListSeparator()} ";
            return $"{nameof(Polyline2D)}({string.Join(sep, Points)})";
        }
    }
}
