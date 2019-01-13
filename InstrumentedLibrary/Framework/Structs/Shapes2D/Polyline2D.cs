using System.Collections.Generic;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The polyline struct.
    /// </summary>
    public struct Polyline2D
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Polyline2D"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        public Polyline2D(List<Point2D> points)
        {
            Points = points;
        }

        /// <summary>
        /// Gets or sets the points.
        /// </summary>
        public List<Point2D> Points { get; set; }

        /// <summary>
        /// Gets the count.
        /// </summary>
        public int Count => Points?.Count ?? 0;

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public override string ToString() => $"{nameof(Polyline2D)}{{{string.Join(",", Points)} }}";
    }
}