using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The accumulator point2d struct.
    /// </summary>
    public struct AccumulatorPoint2D
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccumulatorPoint2D"/> class.
        /// </summary>
        /// <param name="point">The point.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AccumulatorPoint2D(Point2D point)
            : this(point.X, point.Y)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccumulatorPoint2D"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AccumulatorPoint2D(double x, double y)
            : this(x, y, 0, 0)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccumulatorPoint2D"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="totalDistance">The totalDistance.</param>
        /// <param name="previousIndex"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AccumulatorPoint2D(double x, double y, double totalDistance, int previousIndex)
        {
            this.X = x;
            this.Y = y;
            TotalDistance = totalDistance;
            PreviousIndex = previousIndex;
        }

        /// <summary>
        /// Gets or sets the x.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the y.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Gets or sets the total distance.
        /// </summary>
        public double TotalDistance { get; set; }

        /// <summary>
        /// Gets or sets the previous.
        /// </summary>
        public int PreviousIndex { get; set; }

        /// <summary>
        /// Implicit conversion to ItPoint2D.
        /// </summary>
        /// <returns>
        /// </returns>
        /// <param name="point"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AccumulatorPoint2D(Point2D point)
            => new AccumulatorPoint2D(point.X, point.Y);

        /// <summary>
        /// Implicit conversion to ItPoint2D.
        /// </summary>
        /// <returns>
        /// </returns>
        /// <param name="point"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Point2D(AccumulatorPoint2D point)
            => new Point2D(point.X, point.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator (double X, double Y) (AccumulatorPoint2D point)
            => (point.X, point.Y);

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"{nameof(AccumulatorPoint2D)}{{{nameof(X)}:{X:R}, {nameof(Y)}:{Y:R}, {nameof(TotalDistance)}:{TotalDistance:R}, {nameof(PreviousIndex)}:{PreviousIndex:R} }}";
    }
}