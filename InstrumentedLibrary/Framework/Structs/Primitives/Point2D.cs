using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The <see cref="Point2D"/> struct.
    /// </summary>
    public struct Point2D
    {
        /// <summary>
        /// Represents a <see cref="Point2D"/> that has <see cref="X"/> and <see cref="Y"/> values set to zero.
        /// </summary>
        public static readonly Point2D Empty = new Point2D(0d, 0d);

        /// <summary>
        /// Initializes a new instance of the <see cref="Point2D"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point2D"/> class.
        /// </summary>
        /// <param name="tuple"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Point2D((double X, double Y) tuple)
            : this(tuple.X, tuple.Y)
        { }

        /// <summary>
        /// Gets or sets the x.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the y.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Deconstruct this <see cref="Point4D"/> to a <see cref="ValueTuple{T1, T2}"/>.
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
        /// Unary addition operator.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D operator +(Point2D value) => new Point2D(+value.X, +value.Y);

        /// <summary>
        /// Add an amount to both values in the <see cref="Point2D"/> classes.
        /// </summary>
        /// <param name="value">The original value</param>
        /// <param name="addend">The amount to add.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D operator +(Point2D value, double addend) => new Point2D(value.X + addend, value.Y + addend);

        /// <summary>
        /// Add two <see cref="Point2D"/> classes together.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator +(Point2D value, Point2D addend) => new Vector2D(value.X + addend.X, value.Y + addend.Y);

        /// <summary>
        /// Add two <see cref="Point2D"/> classes together.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D operator +(Point2D value, Size2D addend) => new Point2D(value.X + addend.Width, value.Y + addend.Height);

        /// <summary>
        /// Operator Point + Vector
        /// </summary>
        /// <param name="point"> The Point to be added to the Vector </param>
        /// <param name="vector"> The Vector to be added to the Point </param>
        /// <returns>
        /// Point - The result of the addition
        /// </returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D operator +(Point2D point, Vector2D vector) => new Point2D(point.X + vector.I, point.Y + vector.J);

        /// <summary>
        /// Unary subtraction operator.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D operator -(Point2D value) => new Point2D(-value.X, -value.Y);

        /// <summary>
        /// Subtract a <see cref="Point2D"/> from a <see cref="double"/> value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D operator -(Point2D value, double subend) => new Point2D(value.X - subend, value.Y - subend);

        /// <summary>
        /// Subtract a <see cref="Point2D"/> from another <see cref="Point2D"/> class.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator -(Point2D value, Point2D subend) => new Vector2D(value.X + subend.X, value.Y + subend.Y);

        /// <summary>
        /// Subtract a <see cref="Point2D"/> from another <see cref="Point2D"/> class.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D operator -(Point2D value, Size2D subend) => new Point2D(value.X + subend.Width, value.Y + subend.Height);

        /// <summary>
        /// Subtract a <see cref="Point2D"/> from another <see cref="Point2D"/> class.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D operator -(Point2D value, Vector2D subend) => new Point2D(value.X + subend.I, value.Y + subend.J);

        /// <summary>
        /// Scale a point
        /// </summary>
        /// <param name="factor"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D operator *(double value, Point2D factor) => new Point2D(value * factor.X, value * factor.Y);

        /// <summary>
        /// Scale a point.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="factor"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D operator *(Point2D value, double factor) => new Point2D(value.X * factor, value.Y * factor);

        /// <summary>
        /// Inflate a point.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="factor"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D operator *(Point2D value, Size2D factor) => new Point2D(value.X * factor.Width, value.Y * factor.Height);

        /// <summary>
        /// Divide a <see cref="Point2D"/> by a value.
        /// </summary>
        /// <param name="divisor">The divisor value</param>
        /// <param name="dividend">The dividend to add.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D operator /(Point2D divisor, double dividend) => new Point2D(divisor.X / dividend, divisor.Y / dividend);

        /// <summary>
        /// Divide a Point2D
        /// </summary>
        /// <param name="divisor">The <see cref="Point2D"/></param>
        /// <param name="dividend">The divisor</param>
        /// <returns>A Point2D divided by the divisor</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D operator /(double divisor, Point2D dividend) => new Point2D(divisor / dividend.X, divisor / dividend.Y);

        /// <summary>
        /// Compares two <see cref="Point2D"/> objects.
        /// The result specifies whether the values of the <see cref="X"/> and <see cref="Y"/>
        /// values of the two <see cref="Point2D"/> objects are equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Point2D left, Point2D right) => Equals(left, right);

        /// <summary>
        /// Compares two <see cref="Point2D"/> objects.
        /// The result specifies whether the values of the <see cref="X"/> or <see cref="Y"/>
        /// values of the two <see cref="Point2D"/> objects are unequal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Point2D left, Point2D right) => !Equals(left, right);

        /// <summary>
        /// Converts the specified <see cref="Vector2D"/> structure to a <see cref="Point2D"/> structure.
        /// </summary>
        /// <param name="vector">The <see cref="Vector2D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Point2D(Vector2D vector) => new Point2D(vector.I, vector.J);

        /// <summary>
        /// Converts the specified <see cref="Size2D"/> structure to a <see cref="Point2D"/> structure.
        /// </summary>
        /// <param name="size">The <see cref="Size2D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Point2D(Size2D size) => new Point2D(size.Width, size.Height);

        /// <summary>
        /// Converts the specified <see cref="Point2D"/> structure to a <see cref="ValueTuple{T1, T2}"/> structure.
        /// </summary>
        /// <param name="point">The <see cref="Point2D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator (double X, double Y) (Point2D point) => (point.X, point.Y);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(Point2D a, Point2D b) => (a.X == b.X) & (a.Y == b.Y);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is Point2D && Equals(this, (Point2D)obj);

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
        public override string ToString() => $"{nameof(Point2D)}{{{nameof(X)}:{X:R}, {nameof(Y)}:{Y:R} }}";
    }
}