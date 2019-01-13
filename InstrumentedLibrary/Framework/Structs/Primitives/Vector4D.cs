using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The <see cref="Vector4D"/> struct.
    /// </summary>
    public struct Vector4D
    {
        /// <summary>
        /// Represents a <see cref="Vector3D"/> that has <see cref="I"/>, <see cref="J"/>, <see cref="K"/> and <see cref="L"/> values set to zero.
        /// </summary>
        public static readonly Vector4D Empty = new Vector4D(0d, 0d, 0d, 0d);

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4D"/> class.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <param name="k">The k.</param>
        /// <param name="l">The l.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4D(double i, double j, double k, double l)
        {
            I = i;
            J = j;
            K = k;
            L = l;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4D"/> class.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4D(Vector4D a, Vector4D b) :
            this(a.I, a.J, a.K, a.L, b.I, b.J, b.K, b.L)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4D"/> class.
        /// </summary>
        /// <param name="aI">The aI.</param>
        /// <param name="aJ">The aJ.</param>
        /// <param name="aK">The aK.</param>
        /// <param name="aL">The aL.</param>
        /// <param name="bI">The bI.</param>
        /// <param name="bJ">The bJ.</param>
        /// <param name="bK">The bK.</param>
        /// <param name="bL">The bL.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4D(double aI, double aJ, double aK, double aL, double bI, double bJ, double bK, double bL)
        {
            (var i, var j, var k, var l) = (bI - aI, bJ - aJ, bK - aK, bL - aL);
            var d = Sqrt((i * i) + (j * j) + (k * k) + (l * l));
            I = i * 1d / d;
            J = j * 1d / d;
            K = k * 1d / d;
            L = l * 1d / d;
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
        /// Gets or sets the k.
        /// </summary>
        public double L { get; set; }

        /// <summary>
        /// Deconstruct this <see cref="Vector4D"/> to a <see cref="ValueTuple{T1, T2, T3, T4}"/>.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <param name="k">The k.</param>
        /// <param name="l">The l.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Deconstruct(out double i, out double j, out double k, out double l)
        {
            i = I;
            j = J;
            k = K;
            l = L;
        }

        /// <summary>
        /// The operator +.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="Vector4D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4D operator +(Vector4D value) => new Vector4D(+value.I, +value.J, +value.K, +value.L);

        /// <summary>
        /// Add Points
        /// </summary>
        /// <param name="value"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4D operator +(Vector4D value, double addend) => new Vector4D(value.I + addend, value.J + addend, value.K + addend, value.L + addend);

        /// <summary>
        /// Add Points
        /// </summary>
        /// <param name="value"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point4D operator +(Vector4D value, Point4D addend) => new Point4D(value.I + addend.X, value.J + addend.Y, value.K + addend.Z, value.L + addend.W);

        /// <summary>
        /// Add Points
        /// </summary>
        /// <param name="value"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4D operator +(Vector4D value, Vector4D addend) => new Vector4D(value.I + addend.I, value.J + addend.J, value.K + addend.K, value.L + addend.L);

        /// <summary>
        /// The operator -.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="Vector4D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4D operator -(Vector4D value) => new Vector4D(-value.I, -value.J, -value.K, -value.L);

        /// <summary>
        /// Subtract Points
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4D operator -(Vector4D value, double subend) => new Vector4D(value.I - subend, value.J - subend, value.K - subend, value.L - subend);

        /// <summary>
        /// Subtract Points
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point4D operator -(Vector4D value, Point4D subend) => new Point4D(value.I + subend.X, value.J + subend.Y, value.K + subend.Z, value.L + subend.W);

        /// <summary>
        /// Subtract Vectors
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4D operator -(Vector4D value, Vector4D subend) => new Vector4D(value.I + subend.I, value.J + subend.J, value.K + subend.K, value.L + subend.L);

        /// <summary>
        /// Scale a Vector
        /// </summary>
        /// <param name="value">The Point</param>
        /// <param name="factor">The Multiplier</param>
        /// <returns>A Vector Multiplied by the Multiplier</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4D operator *(Vector4D value, double factor) => new Vector4D(value.I * factor, value.J * factor, value.K * factor, value.L * factor);

        /// <summary>
        /// Scale a Vector
        /// </summary>
        /// <param name="factor">The Multiplier</param>
        /// <param name="value">The Point</param>
        /// <returns>A Vector Multiplied by the Multiplier</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4D operator *(double factor, Vector4D value) => new Vector4D(value.I * factor, value.J * factor, value.K * factor, value.L * factor);

        /// <summary>
        /// Scale a Vector
        /// </summary>
        /// <param name="value">The Point</param>
        /// <param name="factor">The Multiplier</param>
        /// <returns>A Vector Multiplied by the Multiplier</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4D operator *(Vector4D value, Size4D factor) => new Vector4D(value.I * factor.Width, value.J * factor.Height, value.K * factor.Depth, value.L * factor.Breadth);

        /// <summary>
        /// Divide a <see cref="Vector4D"/>
        /// </summary>
        /// <param name="divisor">The <see cref="Vector4D"/></param>
        /// <param name="divedend">The divisor</param>
        /// <returns>A <see cref="Vector4D"/> divided by the divisor</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4D operator /(Vector4D divisor, double divedend) => new Vector4D(divisor.I / divedend, divisor.J / divedend, divisor.K / divedend, divisor.L / divedend);

        /// <summary>
        /// Divide a <see cref="Vector4D"/>
        /// </summary>
        /// <param name="divisor">The <see cref="Vector4D"/></param>
        /// <param name="dividend">The divisor</param>
        /// <returns>A <see cref="Vector4D"/> divided by the divisor</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4D operator /(double divisor, Vector4D dividend) => new Vector4D(divisor / dividend.I, divisor / dividend.I, divisor / dividend.K, divisor / dividend.L);

        /// <summary>
        /// The operator ==.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector4D a, Vector4D b) => Equals(a, b);

        /// <summary>
        /// The operator !=.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector4D a, Vector4D b) => !Equals(a, b);

        /// <summary>
        /// Converts the specified <see cref="Point4D"/> structure to a <see cref="Vector4D"/> structure.
        /// </summary>
        /// <param name="point">The <see cref="Point4D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector4D(Point4D point) => new Vector4D(point.X, point.Y, point.Z, point.W);

        /// <summary>
        /// Converts the specified <see cref="Size4D"/> structure to a <see cref="Vector4D"/> structure.
        /// </summary>
        /// <param name="size">The <see cref="Size4D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector4D(Size4D size) => new Vector4D(size.Width, size.Height, size.Depth, size.Breadth);

        /// <summary>
        /// Converts the specified <see cref="Vector4D"/> structure to a <see cref="ValueTuple{T1, T2, T3, T4}"/> structure.
        /// </summary>
        /// <param name="vector">The <see cref="Vector4D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator (double I, double J, double K, double L) (Vector4D vector) => (vector.I, vector.J, vector.K, vector.L);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is Vector4D && Equals(this, (Vector4D)obj);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(Vector4D a, Vector4D b) => (a.I == b.I) & (a.J == b.J) & (a.K == b.K) & (a.L == b.L);

        /// <summary>
        /// Get the hash code.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(I, J, K, L);

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"{nameof(Vector3D)}{{{nameof(I)}:{I:R}, {nameof(J)}:{J:R}, {nameof(K)}:{K:R}, {nameof(L)}:{L:R} }}";
    }
}