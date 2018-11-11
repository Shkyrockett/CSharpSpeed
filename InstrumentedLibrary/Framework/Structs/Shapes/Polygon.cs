using System.Collections.Generic;
using System.Linq;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The polygon class.
    /// </summary>
    public struct Polygon
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Polygon"/> class.
        /// </summary>
        /// <param name="contours">The contours.</param>
        public Polygon(IEnumerable<PolygonContour> contours)
        {
            this.Contours = contours;
        }

        /// <summary>
        /// Gets or sets the contours.
        /// </summary>
        public IEnumerable<PolygonContour> Contours { get; set; }

        /// <summary>
        /// Gets the count.
        /// </summary>
        public int Count => Contours.Count();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="polygon"></param>
        public static implicit operator List<List<Point2D>>(Polygon polygon)
        {
            var list = new List<List<Point2D>>();

            foreach (var contour in polygon.Contours)
            {
                list.Add(contour);
            }

            return list;
        }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public override string ToString() => $"{nameof(Polygon)}{{{string.Join(",", Contours)} }}";
    }
}