using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The <see cref="Point3D"/> struct.
    /// </summary>
    public struct Point3D
    {
        /// <summary>
        /// Represents a <see cref="Point3D"/> that has <see cref="X"/>, <see cref="Y"/> and <see cref="Z"/> values set to zero.
        /// </summary>
        public static readonly Point3D Empty = new Point3D(0d, 0d, 0d);

        /// <summary>
        /// Initializes a new instance of the <see cref="Point3D"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
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
        /// Gets or sets the z.
        /// </summary>
        public double Z { get; set; }

        /// <summary>
        /// Deconstruct this <see cref="Point4D"/> to a <see cref="ValueTuple{T1, T2, T3}"/>.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out double x, out double y, out double z)
        {
            x = X;
            y = Y;
            z = Z;
        }

        /// <summary>
        /// Unary addition operator.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3D operator +(Point3D value) => new Point3D(+value.X, +value.Y, +value.Z);

        /// <summary>
        /// Add an amount to both values in the <see cref="Point3D"/> classes.
        /// </summary>
        /// <param name="value">The original value</param>
        /// <param name="addend">The amount to add.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3D operator +(Point3D value, double addend) => new Point3D(value.X + addend, value.Y + addend, value.Z + addend);

        /// <summary>
        /// Add two <see cref="Point3D"/> classes together.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3D operator +(Point3D value, Point3D addend) => new Vector3D(value.X + addend.X, value.Y + addend.Y, value.Z + addend.Z);

        /// <summary>
        /// Add two <see cref="Point3D"/> classes together.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3D operator +(Point3D value, Size3D addend) => new Point3D(value.X + addend.Width, value.Y + addend.Height, value.Z + addend.Depth);

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
        public static Point3D operator +(Point3D point, Vector3D vector) => new Point3D(point.X + vector.I, point.Y + vector.J, point.Z + vector.K);

        /// <summary>
        /// Unary subtraction operator.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3D operator -(Point3D value) => new Point3D(-value.X, -value.Y, -value.Z);

        /// <summary>
        /// Subtract a <see cref="Point3D"/> from a <see cref="double"/> value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3D operator -(Point3D value, double subend) => new Point3D(value.X - subend, value.Y - subend, value.Z - subend);

        /// <summary>
        /// Subtract a <see cref="Point3D"/> from another <see cref="Point3D"/> class.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3D operator -(Point3D value, Point3D subend) => new Vector3D(value.X + subend.X, value.Y + subend.Y, value.Z + subend.Z);

        /// <summary>
        /// Subtract a <see cref="Point3D"/> from another <see cref="Point3D"/> class.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3D operator -(Point3D value, Size3D subend) => new Point3D(value.X + subend.Width, value.Y + subend.Height, value.Z + subend.Depth);

        /// <summary>
        /// Subtract a <see cref="Point3D"/> from another <see cref="Point3D"/> class.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3D operator -(Point3D value, Vector3D subend) => new Point3D(value.X + subend.I, value.Y + subend.J, value.Z + subend.K);

        /// <summary>
        /// Scale a point
        /// </summary>
        /// <param name="factor"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3D operator *(double value, Point3D factor) => new Point3D(value * factor.X, value * factor.Y, value * factor.Z);

        /// <summary>
        /// Scale a point.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="factor"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3D operator *(Point3D value, double factor) => new Point3D(value.X * factor, value.Y * factor, value.Z * factor);

        /// <summary>
        /// Divide a <see cref="Point3D"/> by a value.
        /// </summary>
        /// <param name="divisor">The divisor value</param>
        /// <param name="dividend">The dividend to add.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3D operator /(Point3D divisor, double dividend) => new Point3D(divisor.X / dividend, divisor.Y / dividend, divisor.Z / dividend);

        /// <summary>
        /// Divide a <see cref="Point3D"/>
        /// </summary>
        /// <param name="divisor">The <see cref="Point3D"/></param>
        /// <param name="dividend">The divisor</param>
        /// <returns>A <see cref="Point3D"/> divided by the divisor</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3D operator /(double divisor, Point3D dividend) => new Point3D(divisor / dividend.X, divisor / dividend.Y, divisor / dividend.Z);

        /// <summary>
        /// Compares two <see cref="Point3D"/> objects.
        /// The result specifies whether the values of the <see cref="X"/> and <see cref="Y"/>
        /// values of the two <see cref="Point3D"/> objects are equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Point3D left, Point3D right) => Equals(left, right);

        /// <summary>
        /// Compares two <see cref="Point3D"/> objects.
        /// The result specifies whether the values of the <see cref="X"/> or <see cref="Y"/>
        /// values of the two <see cref="Point3D"/> objects are unequal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Point3D left, Point3D right) => !Equals(left, right);

        /// <summary>
        /// Converts the specified <see cref="Vector3D"/> structure to a <see cref="Point3D"/> structure.
        /// </summary>
        /// <param name="vector">The <see cref="Vector3D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Point3D(Vector3D vector) => new Point3D(vector.I, vector.J, vector.K);

        /// <summary>
        /// Converts the specified <see cref="Size3D"/> structure to a <see cref="Point3D"/> structure.
        /// </summary>
        /// <param name="size">The <see cref="Size3D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Point3D(Size3D size) => new Point3D(size.Width, size.Height, size.Depth);

        /// <summary>
        /// Converts the specified <see cref="Point3D"/> structure to a <see cref="ValueTuple{T1, T2, T3}"/> structure.
        /// </summary>
        /// <param name="point">The <see cref="Point3D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator (double X, double Y, double Z) (Point3D point) => (point.X, point.Y, point.Z);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(Point3D a, Point3D b) => (a.X == b.X) && (a.Y == b.Y) && (a.Z == b.Z);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is Point3D && Equals(this, (Point3D)obj);

        /// <summary>
        /// Get the hash code.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(X, Y, Z);

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"{nameof(Point3D)}{{{nameof(X)}:{X:R}, {nameof(Y)}:{Y:R}, {nameof(Z)}:{Z:R} }}";
    }
}