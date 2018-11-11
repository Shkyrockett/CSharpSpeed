using System.Collections.Generic;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The polygon contour class.
    /// </summary>
    public struct PolygonContour
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PolygonContour"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        public PolygonContour(IEnumerable<Point2D> points)
        {
            this.Points = points;
        }

        /// <summary>
        /// Gets or sets the points.
        /// </summary>
        public IEnumerable<Point2D> Points { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="polygon"></param>
        public static implicit operator List<Point2D>(PolygonContour polygon)
        {
            return polygon.Points as List<Point2D>;
        }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public override string ToString() => $"{nameof(PolygonContour)}{{{string.Join(",", Points)} }}";
    }
}