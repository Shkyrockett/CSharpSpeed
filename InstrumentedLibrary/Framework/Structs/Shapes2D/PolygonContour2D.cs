using System.Collections.Generic;
using System.Linq;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The polygon contour class.
    /// </summary>
    public struct PolygonContour2D
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PolygonContour2D"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        public PolygonContour2D(IEnumerable<Point2D> points)
        {
            Points = points.ToList();
        }

        /// <summary>
        /// Gets or sets the points.
        /// </summary>
        public IList<Point2D> Points { get; set; }

        /// <summary>
        /// Gets the count.
        /// </summary>
        public int Count => Points?.Count() ?? 0;

        public RotationDirections Orientation => PolygonIsOrientedClockwiseTests.PolygonIsOrientedClockwise(Points as List<Point2D>) ? RotationDirections.Clockwise : RotationDirections.CounterClockwise;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="polygon"></param>
        public static implicit operator List<Point2D>(PolygonContour2D polygon) => polygon.Points as List<Point2D>;

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public override string ToString() => $"{nameof(PolygonContour2D)}{{{string.Join(",", Points)} }}";
    }
}