using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

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
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"{nameof(Polyline2D)}=[{string.Join(",", Points)}]";
    }
}