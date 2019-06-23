using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The polyline struct.
    /// </summary>
    public struct Polyline2D
        : IShapeSegment
    {
        #region Constructors
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
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the points.
        /// </summary>
        public List<Point2D> Points { get; set; }

        /// <summary>
        /// Gets the count.
        /// </summary>
        public int Count => Points?.Count ?? 0;
        #endregion

        /// <summary>
        /// The to string.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider) => $"{nameof(Polyline2D)}({string.Join(",", Points)})";
    }
}