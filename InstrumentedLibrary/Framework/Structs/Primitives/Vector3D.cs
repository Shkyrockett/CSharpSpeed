using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The vector3d struct. Represents a vector in 3D coordinate space (double precision floating-point coordinates).
    /// </summary>
    [DataContract, Serializable]
    [ComVisible(true)]
    [DebuggerDisplay("{nameof(I)}: {I ?? double.NaN}, {nameof(J)}: {J ?? double.NaN}, {nameof(K)}: {K ?? double.NaN}")]
    public struct Vector3D
        : IFormattable
    {
        /// <summary>
        /// Represents a <see cref="Vector3D"/> that has <see cref="I"/>, <see cref="J"/>, and <see cref="K"/> values set to zero.
        /// </summary>
        public static readonly Vector3D Empty = new Vector3D(0d, 0d, 0d);

        /// <summary>
        /// Represents a <see cref="Vector3D"/> that has <see cref="I"/>, <see cref="J"/>, and <see cref="K"/> values set to 1.
        /// </summary>
        public static readonly Vector3D Unit = new Vector3D(1d, 1d, 1d);

        /// <summary>
        /// Represents a <see cref="Vector3D"/> that has <see cref="I"/>, <see cref="J"/>, and <see cref="K"/> values set to NaN.
        /// </summary>
        public static readonly Vector3D NaN = new Vector3D(double.NaN, double.NaN, double.NaN);

        /// <summary>
        /// Represents a <see cref="Vector3D"/> that has <see cref="I"/> set to 1, <see cref="J"/> set to 0, and <see cref="K"/> set to 0.
        /// </summary>
        public static readonly Vector3D XAxis = new Vector3D(1d, 0d, 0d);

        /// <summary>
        /// Represents a <see cref="Vector3D"/> that has <see cref="I"/> set to 0, <see cref="J"/> set to 1, and <see cref="K"/> set to 0.
        /// </summary>
        public static readonly Vector3D YAxis = new Vector3D(0d, 1d, 0d);

        /// <summary>
        /// Represents a <see cref="Vector3D"/> that has <see cref="I"/> set to 0, <see cref="J"/> set to 0, and <see cref="K"/> set to 1.
        /// </summary>
        public static readonly Vector3D ZAxis = new Vector3D(0d, 0d, 1d);

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3D"/> class.
        /// </summary>
        /// <param name="vector3D">A <see cref="Vector3D"/> class to clone.</param>
        public Vector3D(Vector3D vector3D)
            : this(vector3D.I, vector3D.J, vector3D.K)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3D"/> class.
        /// </summary>
        /// <param name="i">The <see cref="I"/> component of the <see cref="Vector3D"/> class.</param>
        /// <param name="j">The <see cref="J"/> component of the <see cref="Vector3D"/> class.</param>
        /// <param name="k">The <see cref="K"/> component of the <see cref="Vector3D"/> class.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3D(double i, double j, double k)
            : this()
        {
            I = i;
            J = j;
            K = k;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3D"/> class.
        /// </summary>
        /// <param name="tuple"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3D((double X, double Y, double Z) tuple)
            : this()
        {
            (I, J, K) = tuple;
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
            : this()
        {
            (var i, var j, var k) = (bI - aI, bJ - aJ, bK - aK);
            var d = Sqrt((i * i) + (j * j) + (k * k));
            I = i * 1d / d;
            J = j * 1d / d;
            K = k * 1d / d;
        }

        /// <summary>
        /// Deconstruct this <see cref="Vector3D"/> to a <see cref="ValueTuple{T1, T2, T3}"/>.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <param name="k">The k.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out double i, out double j, out double k)
        {
            i = I;
            j = J;
            k = K;
        }

        /// <summary>
        /// Gets or sets the I or first Component of a 3D Vector
        /// </summary>
        [DataMember, XmlAttribute, SoapAttribute]
        public double I { get; set; }

        /// <summary>
        /// Gets or sets the j or second Component of a 3D Vector
        /// </summary>
        [DataMember, XmlAttribute, SoapAttribute]
        public double J { get; set; }

        /// <summary>
        /// Gets or sets the k or third Component of a 3D Vector
        /// </summary>
        [DataMember, XmlAttribute, SoapAttribute]
        public double K { get; set; }

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
        public static Point3D operator -(Vector3D value, Point3D subend) => new Point3D(value.I - subend.X, value.J - subend.Y, value.K - subend.Z);

        /// <summary>
        /// Subtract Points
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3D operator -(Vector3D value, Vector3D subend) => new Vector3D(value.I - subend.I, value.J - subend.J, value.K - subend.K);

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
        /// Point to Vector3D
        /// </summary>
        /// <param name="tuple"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Vector3D((double X, double Y, double Z) tuple) => new Vector3D(tuple);
        /// <summary>
        /// Compares two Vectors
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Compare(Vector3D a, Vector3D b) => Equals(a, b);

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
        /// The equals.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vector3D value) => Equals(this, value);

        /// <summary>
        /// Get the hash code.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(I, J, K);

        /// <summary>
        /// Creates a human-readable string that represents this <see cref="Vector3D"/> struct.
        /// </summary>
        /// <returns>A string representation of this <see cref="Vector3D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => ToString("R" /* format string */, CultureInfo.InvariantCulture /* format provider */);

        /// <summary>
        /// Creates a string representation of this <see cref="Vector3D"/> struct based on the IFormatProvider
        /// passed in.  If the provider is null, the CurrentCulture is used.
        /// </summary>
        /// <param name="provider">The <see cref="CultureInfo"/> provider.</param>
        /// <returns>A string representation of this <see cref="Vector3D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(IFormatProvider provider) => ToString("R" /* format string */, provider);

        /// <summary>
        /// Creates a string representation of this <see cref="Vector3D"/> struct based on the format string
        /// and IFormatProvider passed in.
        /// If the provider is null, the CurrentCulture is used.
        /// See the documentation for IFormattable for more information.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="provider">The <see cref="CultureInfo"/> provider.</param>
        /// <returns>A string representation of this <see cref="Vector3D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider provider)
        {
            if (this == null) return nameof(Vector3D);
            var s = ((provider as CultureInfo) ?? CultureInfo.InvariantCulture).GetNumericListSeparator();
            return $"{nameof(Vector3D)}=[{nameof(I)}:{I.ToString(format, provider)}{s} {nameof(J)}:{J.ToString(format, provider)}{s} {nameof(K)}:{K.ToString(format, provider)}]";
        }
    }
}