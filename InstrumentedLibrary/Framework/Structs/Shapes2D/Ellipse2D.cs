using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The circle struct.
    /// </summary>
    public struct Ellipse2D
    {
        /// <summary>
        /// The empty.
        /// </summary>
        public static Ellipse2D Empty = new Ellipse2D(0, 0, 0, 0);

        /// <summary>
        /// Initializes a new instance of the <see cref="Ellipse2D"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="radiusA">The radius a.</param>
        /// <param name="radiusB">The radius b.</param>
        /// <param name="angle">The angle the <see cref="Ellipse2D"/> is rotated about the center.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Ellipse2D(double x, double y, double radiusA, double radiusB, double angle = 0)
            : this()
        {
            X = x;
            Y = y;
            RadiusA = radiusA;
            RadiusB = radiusB;
            Angle = angle;
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
        /// Gets or sets the a radius.
        /// </summary>
        public double RadiusA { get; set; }

        /// <summary>
        /// Gets or sets the b radius.
        /// </summary>
        public double RadiusB { get; set; }

        /// <summary>
        /// Gets or sets the angle the <see cref="Ellipse2D"/> is rotated about the center.
        /// </summary>
        public double Angle { get; set; }

        /// <summary>
        /// Deconstruct this <see cref="Ellipse2D"/> to a <see cref="ValueTuple{T1, T2, T3, T4, T5}"/>.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="radiusA">The radius a.</param>
        /// <param name="radiusB">The radius b.</param>
        /// <param name="angle">The angle the <see cref="Ellipse2D"/> is rotated about the center.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out double left, out double top, double radiusA, double radiusB, double angle)
        {
            left = X;
            top = Y;
            radiusA = RadiusA;
            radiusB = RadiusB;
            angle = Angle;
        }

        /// <summary>
        /// Deconstruct this <see cref="Ellipse2D"/> to a <see cref="ValueTuple{T1, T2, T3, T4}"/>.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="radiusA">The radius a.</param>
        /// <param name="radiusB">The radius b.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out double left, out double top, double radiusA, double radiusB)
        {
            left = X;
            top = Y;
            radiusA = RadiusA;
            radiusB = RadiusB;
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is Ellipse2D && Equals(this, (Ellipse2D)obj);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(Ellipse2D left, Ellipse2D right) => left.X == right.X && left.Y == right.Y && left.RadiusA == right.RadiusA && left.RadiusB == right.RadiusB && left.Angle == right.Angle;

        /// <summary>
        /// Get the hash code.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(X, Y, RadiusA, RadiusB, Angle);

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"{nameof(Rectangle2D)}=[{nameof(X)}:{X:R}, {nameof(Y)}:{Y:R}, {nameof(RadiusA)}:{RadiusA:R}, {nameof(RadiusB)}:{RadiusB:R}, {nameof(Angle)}:{Angle:R}]";
    }
}