using System.Collections.Generic;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The polyline struct.
    /// </summary>
    public struct Polyline
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Polyline"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        public Polyline(List<Point2D> points)
        {
            this.Points = points;
        }

        /// <summary>
        /// Gets or sets the points.
        /// </summary>
        public List<Point2D> Points { get; set; }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public override string ToString() => $"{nameof(Polyline)}{{{string.Join(",", Points)} }}";
    }
}