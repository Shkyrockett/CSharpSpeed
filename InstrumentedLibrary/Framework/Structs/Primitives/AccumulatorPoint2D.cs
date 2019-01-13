using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The <see cref="AccumulatorPoint2D"/> struct.
    /// </summary>
    public struct AccumulatorPoint2D
    {
        /// <summary>
        /// Represents a <see cref="AccumulatorPoint2D"/> that has <see cref="X"/> and <see cref="Y"/> values set to zero.
        /// </summary>
        public static readonly AccumulatorPoint2D Empty = new AccumulatorPoint2D(0d, 0d);

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
            X = x;
            Y = y;
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
        /// Deconstruct this <see cref="AccumulatorPoint2D"/> to a <see cref="ValueTuple{T1, T2}"/>.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out double x, out double y)
        {
            x = X;
            y = Y;
        }

        /// <summary>
        /// Deconstruct this <see cref="AccumulatorPoint2D"/> to a <see cref="ValueTuple{T1, T2, T3, T4}"/>.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="totalDistance">The totalDistance.</param>
        /// <param name="previousIndex">The previousIndex.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out double x, out double y, out double totalDistance, out int previousIndex)
        {
            x = X;
            y = Y;
            totalDistance = TotalDistance;
            previousIndex = PreviousIndex;
        }

        /// <summary>
        /// Implicit conversion to ItPoint2D.
        /// </summary>
        /// <returns>
        /// </returns>
        /// <param name="point"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AccumulatorPoint2D(Point2D point) => new AccumulatorPoint2D(point.X, point.Y);

        /// <summary>
        /// Converts the specified <see cref="AccumulatorPoint2D"/> structure to a <see cref="Point2D"/> structure.
        /// </summary>
        /// <param name="point">The <see cref="AccumulatorPoint2D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Point2D(AccumulatorPoint2D point) => new Point2D(point.X, point.Y);

        /// <summary>
        /// Converts the specified <see cref="AccumulatorPoint2D"/> structure to a <see cref="ValueTuple{T1, T2}"/> structure.
        /// </summary>
        /// <param name="point">The <see cref="AccumulatorPoint2D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator (double X, double Y) (AccumulatorPoint2D point) => (point.X, point.Y);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(AccumulatorPoint2D a, AccumulatorPoint2D b) => (a.X == b.X) & (a.Y == b.Y);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is AccumulatorPoint2D && Equals(this, (AccumulatorPoint2D)obj);

        /// <summary>
        /// Get the hash code.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(X, Y);

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"{nameof(AccumulatorPoint2D)}{{{nameof(X)}:{X:R}, {nameof(Y)}:{Y:R}, {nameof(TotalDistance)}:{TotalDistance:R}, {nameof(PreviousIndex)}:{PreviousIndex:R} }}";
    }
}