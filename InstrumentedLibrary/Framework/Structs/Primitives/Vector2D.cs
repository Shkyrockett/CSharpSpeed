using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The vector2d struct.
    /// </summary>
    public struct Vector2D
    {
        /// <summary>
        /// Represents a <see cref="Vector2D"/> that has <see cref="I"/> and <see cref="J"/> values set to zero.
        /// </summary>
        public static readonly Vector2D Empty = new Vector2D(0d, 0d);

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2D"/> class.
        /// </summary>
        /// <param name="tuple"></param>
        public Vector2D((double I, double J) tuple)
            : this(tuple.I, tuple.J)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2D"/> class.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2D(double i, double j)
        {
            I = i;
            J = j;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2D"/> class.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2D(Point2D a, Point2D b)
            : this(a.X, a.Y, b.X, b.Y)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2D"/> class.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2D(Vector2D a, Vector2D b) :
            this(a.I, a.J, b.I, b.J)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2D"/> class.
        /// </summary>
        /// <param name="aI">The aI.</param>
        /// <param name="aJ">The aJ.</param>
        /// <param name="bI">The bI.</param>
        /// <param name="bJ">The bJ.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2D(double aI, double aJ, double bI, double bJ)
        {
            (var i, var j) = (bI - aI, bJ - aJ);
            var d = Sqrt((i * i) + (j * j));
            I = i * 1d / d;
            J = j * 1d / d;
        }

        /// <summary>
        /// Gets or sets the I.
        /// </summary>
        public double I { get; set; }

        /// <summary>
        /// Gets or sets the j.
        /// </summary>
        public double J { get; set; }

        /// <summary>
        /// Deconstruct this <see cref="Vector2D"/> to a <see cref="ValueTuple{T1, T2}"/>.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Deconstruct(out double i, out double j)
        {
            i = I;
            j = J;
        }

        /// <summary>
        /// The operator +.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="Vector2D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator +(Vector2D value) => new Vector2D(+value.I, +value.J);

        /// <summary>
        /// Add Points
        /// </summary>
        /// <param name="value"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator +(Vector2D value, double addend) => new Vector2D(value.I + addend, value.J + addend);

        /// <summary>
        /// Add Points
        /// </summary>
        /// <param name="value"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D operator +(Vector2D value, Point2D addend) => new Point2D(value.I + addend.X, value.J + addend.Y);

        /// <summary>
        /// Add Points
        /// </summary>
        /// <param name="value"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator +(Vector2D value, Vector2D addend) => new Vector2D(value.I + addend.I, value.J + addend.J);

        /// <summary>
        /// The operator -.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="Vector2D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator -(Vector2D value) => new Vector2D(-value.I, -value.J);

        /// <summary>
        /// Subtract Points
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator -(Vector2D value, double subend) => new Vector2D(value.I - subend, value.J - subend);

        /// <summary>
        /// Subtract Points
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D operator -(Vector2D value, Point2D subend) => new Point2D(value.I + subend.X, value.J + subend.Y);

        /// <summary>
        /// Subtract Points
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator -(Vector2D value, Vector2D subend) => new Vector2D(value.I + subend.I, value.J + subend.J);

        /// <summary>
        /// Scale a Vector
        /// </summary>
        /// <param name="value">The Point</param>
        /// <param name="factor">The Multiplier</param>
        /// <returns>A Point Multiplied by the Multiplier</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator *(Vector2D value, double factor) => new Vector2D(value.I * factor, value.J * factor);

        /// <summary>
        /// Scale a Vector
        /// </summary>
        /// <param name="factor">The Multiplier</param>
        /// <param name="value">The Point</param>
        /// <returns>A Point Multiplied by the Multiplier</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator *(double factor, Vector2D value) => new Vector2D(value.I * factor, value.J * factor);

        /// <summary>
        /// Scale a Vector
        /// </summary>
        /// <param name="value">The Point</param>
        /// <param name="factor">The Multiplier</param>
        /// <returns>A Point Multiplied by the Multiplier</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator *(Vector2D value, Size2D factor) => new Vector2D(value.I * factor.Width, value.J * factor.Height);

        /// <summary>
        /// Divide a Vector2D
        /// </summary>
        /// <param name="divisor">The Vector2D</param>
        /// <param name="divedend">The divisor</param>
        /// <returns>A Vector2D divided by the divisor</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator /(Vector2D divisor, double divedend) => new Vector2D(divisor.I / divedend, divisor.J / divedend);

        /// <summary>
        /// Divide a Vector2D
        /// </summary>
        /// <param name="divisor">The Vector2D</param>
        /// <param name="dividend">The divisor</param>
        /// <returns>A Vector2D divided by the divisor</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator /(double divisor, Vector2D dividend) => new Vector2D(divisor / dividend.I, divisor / dividend.I);

        /// <summary>
        /// The operator ==.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2D a, Vector2D b) => Equals(a, b);

        /// <summary>
        /// The operator !=.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2D a, Vector2D b) => !Equals(a, b);

        /// <summary>
        /// Converts the specified <see cref="Point2D"/> structure to a <see cref="Size2D"/> structure.
        /// </summary>
        /// <param name="point">The <see cref="Point2D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector2D(Point2D point) => new Vector2D(point.X, point.Y);

        /// <summary>
        /// Converts the specified <see cref="Size2D"/> structure to a <see cref="Size2D"/> structure.
        /// </summary>
        /// <param name="size">The <see cref="Size2D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector2D(Size2D size) => new Vector2D(size.Width, size.Height);

        /// <summary>
        /// Converts the specified <see cref="Vector2D"/> structure to a <see cref="ValueTuple{T1, T2}"/> structure.
        /// </summary>
        /// <param name="vector">The <see cref="Vector2D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator (double I, double J) (Vector2D vector) => (vector.I, vector.J);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is Vector2D && Equals(this, (Vector2D)obj);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(Vector2D a, Vector2D b) => (a.I == b.I) & (a.J == b.J);

        /// <summary>
        /// Get the hash code.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(I, J);

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"{nameof(Vector2D)}{{{nameof(I)}:{I:R}, {nameof(J)}:{J:R} }}";
    }
}