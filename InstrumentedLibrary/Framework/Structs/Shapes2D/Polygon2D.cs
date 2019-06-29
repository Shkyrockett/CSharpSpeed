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
    /// The polygon class.
    /// </summary>
    [ComVisible(true)]
    [DataContract, Serializable]
    [DebuggerDisplay("{ToString()}")]
    public struct Polygon2D
        : IClosedShape, ICachableProperties
    {
        #region Implementations
        /// <summary>
        /// The empty.
        /// </summary>
        public static Polygon2D Empty = new Polygon2D(new[] { Point2D.Empty });
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Polygon2D"/> class.
        /// </summary>
        /// <param name="contours">The contours.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Polygon2D(IEnumerable<PolygonContour2D> contours)
            : this()
        {
            Contours = contours;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Polygon2D(params Point2D[] array)
            : this(new[] { new PolygonContour2D(array) })
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Polygon2D(params PolygonContour2D[] array)
            : this(array.ToList())
        { }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the contours.
        /// </summary>
        [DataMember(Name = nameof(Contours)), XmlArray(nameof(Contours)), SoapElement(nameof(Contours))]
        public IEnumerable<PolygonContour2D> Contours { get; set; }

        /// <summary>
        /// Gets the count.
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        public int Count => Contours?.Count() ?? 0;

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
        /// <param name="polygon"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator List<List<Point2D>>(Polygon2D polygon)
        {
            var list = new List<List<Point2D>>();

            foreach (var contour in polygon.Contours)
            {
                list.Add(contour);
            }

            return list;
        }

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
            //if (this is null)
            //{
            //    return nameof(Polygon2D);
            //}

            var sep = $"{((formatProvider as CultureInfo) ?? CultureInfo.InvariantCulture).GetNumericListSeparator()} ";
            return $"{nameof(Polygon2D)}({string.Join(sep, Contours)})";
        }
    }
}
