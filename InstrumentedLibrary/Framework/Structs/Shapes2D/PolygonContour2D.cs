using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The polygon contour class.
    /// </summary>
    public struct PolygonContour2D
        : IClosedShape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PolygonContour2D"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

        /// <summary>
        /// 
        /// </summary>
        public RotationDirections Orientation => PolygonIsOrientedClockwiseTests.PolygonIsOrientedClockwise(Points.Cast<(double X, double Y)>().ToArray()) ? RotationDirections.Clockwise : RotationDirections.CounterClockwise;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="polygon"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator List<Point2D>(PolygonContour2D polygon) => polygon.Points as List<Point2D>;

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider) => $"{nameof(PolygonContour2D)}({string.Join(",", Points)})";
    }
}