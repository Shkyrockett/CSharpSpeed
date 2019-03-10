using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The circle struct.
    /// </summary>
    public struct Circle2D
    {
        /// <summary>
        /// The empty.
        /// </summary>
        public static Circle2D Empty = new Circle2D(0, 0, 0);

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle2D"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="radius">The radius.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Circle2D(double x, double y, double radius)
            : this()
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        /// <summary>
        /// Gets or sets the center <see cref="X"/> coordinate.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the center <see cref="Y"/> coordinate.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Gets or sets the radius.
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Deconstruct this <see cref="Circle2D"/> to a <see cref="ValueTuple{T1, T2, T3}"/>.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="radius">The radius.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out double left, out double top, out double radius)
        {
            left = X;
            top = Y;
            radius = Radius;
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is Circle2D && Equals(this, (Circle2D)obj);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(Circle2D left, Circle2D right) => left.X == right.X && left.Y == right.Y && left.Radius == right.Radius;

        /// <summary>
        /// Get the hash code.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(X, Y, Radius);

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"{nameof(Circle2D)}=[{nameof(X)}:{X:R}, {nameof(Y)}:{Y:R}, {nameof(Radius)}:{Radius:R}]";
    }
}