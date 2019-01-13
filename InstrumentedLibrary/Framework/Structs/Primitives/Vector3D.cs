using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The vector3d struct.
    /// </summary>
    public struct Vector3D
    {
        /// <summary>
        /// Represents a <see cref="Vector3D"/> that has <see cref="I"/>, <see cref="J"/> and <see cref="K"/> values set to zero.
        /// </summary>
        public static readonly Vector3D Empty = new Vector3D(0d, 0d, 0d);

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3D"/> class.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <param name="k">The k.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3D(double i, double j, double k)
        {
            I = i;
            J = j;
            K = k;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3D"/> class.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3D(Vector3D a, Vector3D b) :
            this(a.I, a.J, a.K, b.I, b.J, b.K)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3D"/> class.
        /// </summary>
        /// <param name="aI">The aI.</param>
        /// <param name="aJ">The aJ.</param>
        /// <param name="aK">The aK.</param>
        /// <param name="bI">The bI.</param>
        /// <param name="bJ">The bJ.</param>
        /// <param name="bK">The bK.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3D(double aI, double aJ, double aK, double bI, double bJ, double bK)
        {
            (var i, var j, var k) = (bI - aI, bJ - aJ, bK - aK);
            var d = Sqrt((i * i) + (j * j) + (k * k));
            I = i * 1d / d;
            J = j * 1d / d;
            K = k * 1d / d;
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
        /// Gets or sets the k.
        /// </summary>
        public double K { get; set; }

        /// <summary>
        /// Deconstruct this <see cref="Vector3D"/> to a <see cref="ValueTuple{T1, T2, T3}"/>.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <param name="k">The k.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Deconstruct(out double i, out double j, out double k)
        {
            i = I;
            j = J;
            k = K;
        }

        /// <summary>
        /// The operator +.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="Vector3D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3D operator +(Vector3D value) => new Vector3D(+value.I, +value.J, +value.K);

        /// <summary>
        /// Add Points
        /// </summary>
        /// <param name="value"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3D operator +(Vector3D value, double addend) => new Vector3D(value.I + addend, value.J + addend, value.K + addend);

        /// <summary>
        /// Add Points
        /// </summary>
        /// <param name="value"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3D operator +(Vector3D value, Point3D addend) => new Point3D(value.I + addend.X, value.J + addend.Y, value.K + addend.Z);

        /// <summary>
        /// Add Points
        /// </summary>
        /// <param name="value"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3D operator +(Vector3D value, Vector3D addend) => new Vector3D(value.I + addend.I, value.J + addend.J, value.K + addend.K);

        /// <summary>
        /// The operator -.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="Vector3D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3D operator -(Vector3D value) => new Vector3D(-value.I, -value.J, -value.K);

        /// <summary>
        /// Subtract Points
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3D operator -(Vector3D value, double subend) => new Vector3D(value.I - subend, value.J - subend, value.K - subend);

        /// <summary>
        /// Subtract Points
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point3D operator -(Vector3D value, Point3D subend) => new Point3D(value.I + subend.X, value.J + subend.Y, value.K + subend.Z);

        /// <summary>
        /// Subtract Points
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3D operator -(Vector3D value, Vector3D subend) => new Vector3D(value.I + subend.I, value.J + subend.J, value.K + subend.K);

        /// <summary>
        /// Scale a Vector
        /// </summary>
        /// <param name="value">The Point</param>
        /// <param name="factor">The Multiplier</param>
        /// <returns>A Point Multiplied by the Multiplier</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3D operator *(Vector3D value, double factor) => new Vector3D(value.I * factor, value.J * factor, value.K * factor);

        /// <summary>
        /// Scale a Vector
        /// </summary>
        /// <param name="factor">The Multiplier</param>
        /// <param name="value">The Point</param>
        /// <returns>A Point Multiplied by the Multiplier</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3D operator *(double factor, Vector3D value) => new Vector3D(value.I * factor, value.J * factor, value.K * factor);

        /// <summary>
        /// Scale a Vector
        /// </summary>
        /// <param name="value">The Point</param>
        /// <param name="factor">The Multiplier</param>
        /// <returns>A Point Multiplied by the Multiplier</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3D operator *(Vector3D value, Size3D factor) => new Vector3D(value.I * factor.Width, value.J * factor.Height, value.K * factor.Depth);

        /// <summary>
        /// Divide a <see cref="Vector3D"/>
        /// </summary>
        /// <param name="divisor">The <see cref="Vector3D"/></param>
        /// <param name="divedend">The divisor</param>
        /// <returns>A <see cref="Vector3D"/> divided by the divisor</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3D operator /(Vector3D divisor, double divedend) => new Vector3D(divisor.I / divedend, divisor.J / divedend, divisor.K / divedend);

        /// <summary>
        /// Divide a <see cref="Vector3D"/>
        /// </summary>
        /// <param name="divisor">The <see cref="Vector3D"/></param>
        /// <param name="dividend">The divisor</param>
        /// <returns>A <see cref="Vector3D"/> divided by the divisor</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3D operator /(double divisor, Vector3D dividend) => new Vector3D(divisor / dividend.I, divisor / dividend.I, divisor / dividend.K);

        /// <summary>
        /// The operator ==.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector3D a, Vector3D b) => Equals(a, b);

        /// <summary>
        /// The operator !=.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector3D a, Vector3D b) => !Equals(a, b);

        /// <summary>
        /// Converts the specified <see cref="Point3D"/> structure to a <see cref="Vector3D"/> structure.
        /// </summary>
        /// <param name="point">The <see cref="Point3D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector3D(Point3D point) => new Vector3D(point.X, point.Y, point.Z);

        /// <summary>
        /// Converts the specified <see cref="Size3D"/> structure to a <see cref="Vector3D"/> structure.
        /// </summary>
        /// <param name="size">The <see cref="Size3D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector3D(Size3D size) => new Vector3D(size.Width, size.Height, size.Depth);

        /// <summary>
        /// Converts the specified <see cref="Vector3D"/> structure to a <see cref="ValueTuple{T1, T2, T3}"/> structure.
        /// </summary>
        /// <param name="vector">The <see cref="Vector3D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator (double I, double J, double K) (Vector3D vector) => (vector.I, vector.J, vector.K);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is Vector3D && Equals(this, (Vector3D)obj);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(Vector3D a, Vector3D b) => (a.I == b.I) & (a.J == b.J) & (a.K == b.K);

        /// <summary>
        /// Get the hash code.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(I, J, K);

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"{nameof(Vector3D)}{{{nameof(I)}:{I:R}, {nameof(J)}:{J:R}, {nameof(K)}:{K:R} }}";
    }
}