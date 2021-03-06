﻿using System;
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
    /// The <see cref="Vector4D"/> struct. Represents a vector in 4D coordinate space (double precision floating-point coordinates).
    /// </summary>
    [ComVisible(true)]
    [DataContract, Serializable]
    [DebuggerDisplay("{ToString()}")]
    public struct Vector4D
        : IFormattable,
        IEquatable<Vector4D>,
        IPrintable
    {
        #region Static Fields
        /// <summary>
        /// Represents a <see cref="Vector4D"/> that has <see cref="I"/>, <see cref="J"/>, <see cref="K"/>, and <see cref="L"/> values set to zero.
        /// </summary>
        public static readonly Vector4D Empty = new Vector4D(0d, 0d, 0d, 0d);

        /// <summary>
        /// Represents a <see cref="Vector4D"/> that has <see cref="I"/>, <see cref="J"/>, <see cref="K"/>, and <see cref="L"/> values set to 1.
        /// </summary>
        public static readonly Vector4D Unit = new Vector4D(1d, 1d, 1d, 1d);

        /// <summary>
        /// Represents a <see cref="Vector4D"/> that has <see cref="I"/>, <see cref="J"/>, <see cref="K"/>, and <see cref="L"/> values set to NaN.
        /// </summary>
        public static readonly Vector4D NaN = new Vector4D(double.NaN, double.NaN, double.NaN, double.NaN);

        /// <summary>
        /// Represents a <see cref="Vector4D"/> that has <see cref="I"/> set to 1, <see cref="J"/> set to 0, <see cref="K"/> set to 0, and <see cref="L"/> set to 0.
        /// </summary>
        public static readonly Vector4D XAxis = new Vector4D(1d, 0d, 0d, 0d);

        /// <summary>
        /// Represents a <see cref="Vector4D"/> that has <see cref="I"/> set to 0, <see cref="J"/> set to 1, <see cref="K"/> set to 0, and <see cref="L"/> set to 0.
        /// </summary>
        public static readonly Vector4D YAxis = new Vector4D(0d, 1d, 0d, 0d);

        /// <summary>
        /// Represents a <see cref="Vector4D"/> that has <see cref="I"/> set to 0, <see cref="J"/> set to 0, <see cref="K"/> set to 1, and <see cref="L"/> set to 0.
        /// </summary>
        public static readonly Vector4D ZAxis = new Vector4D(0d, 0d, 1d, 0d);

        /// <summary>
        /// Represents a <see cref="Vector4D"/> that has <see cref="I"/> set to 0, <see cref="J"/> set to 0, <see cref="K"/> set to 0, and <see cref="L"/> set to 1.
        /// </summary>
        public static readonly Vector4D WAxis = new Vector4D(0d, 0d, 0d, 1d);
        #endregion Static Fields

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4D"/> class as a copy of the one provided.
        /// </summary>
        /// <param name="vector4D">A <see cref="Vector4D"/> class to clone.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4D(Vector4D vector4D)
            : this(vector4D.I, vector4D.J, vector4D.K, vector4D.L)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4D"/> class.
        /// </summary>
        /// <param name="i">The <see cref="I"/> component of the <see cref="Vector4D"/> class.</param>
        /// <param name="j">The <see cref="J"/> component of the <see cref="Vector4D"/> class.</param>
        /// <param name="k">The <see cref="K"/> component of the <see cref="Vector4D"/> class.</param>
        /// <param name="l">The <see cref="L"/> component of the <see cref="Vector4D"/> class.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4D(double i, double j, double k, double l)
            : this()
        {
            I = i;
            J = j;
            K = k;
            L = l;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4D"/> class.
        /// </summary>
        /// <param name="tuple">The X, Y, Z and W values in tuple form.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4D((double X, double Y, double Z, double W) tuple)
            : this()
        {
            (I, J, K, L) = tuple;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4D"/> struct.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4D((double X, double Y, double Z, double W) a, (double X, double Y, double Z, double W) b)
            : this(a.X, a.Y, a.Z, a.W, b.X, b.Y, b.Z, b.W)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4D"/> class.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4D(Vector4D a, Vector4D b)
            : this(a.I, a.J, a.K, a.L, b.I, b.J, b.K, b.L)
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
            : this()
        {
            (var i, var j, var k, var l) = (bI - aI, bJ - aJ, bK - aK, bL - aL);
            var d = Sqrt((i * i) + (j * j) + (k * k) + (l * l));
            I = i * 1d / d;
            J = j * 1d / d;
            K = k * 1d / d;
            L = l * 1d / d;
        }
        #endregion Constructors

        #region Deconstructors
        /// <summary>
        /// Deconstruct this <see cref="Vector4D"/> to a <see cref="ValueTuple{T1, T2, T3, T4}"/>.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <param name="k">The k.</param>
        /// <param name="l">The l.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out double i, out double j, out double k, out double l)
        {
            i = I;
            j = J;
            k = K;
            l = L;
        }
        #endregion Deconstructors

        #region Properties
        /// <summary>
        /// Gets or sets the I or first Component of a 4D Vector
        /// </summary>
        [DataMember(Name = nameof(I)), XmlAttribute(nameof(I)), SoapAttribute(nameof(I))]
        public double I { get; set; }

        /// <summary>
        /// Gets or sets the j or second Component of a 4D Vector
        /// </summary>
        [DataMember(Name = nameof(J)), XmlAttribute(nameof(J)), SoapAttribute(nameof(J))]
        public double J { get; set; }

        /// <summary>
        /// Gets or sets the k or third Component of a 4D Vector
        /// </summary>
        [DataMember(Name = nameof(K)), XmlAttribute(nameof(K)), SoapAttribute(nameof(K))]
        public double K { get; set; }

        /// <summary>
        /// Gets or sets the l or fourth Component of a 4D Vector
        /// </summary>
        [DataMember(Name = nameof(L)), XmlAttribute(nameof(L)), SoapAttribute(nameof(L))]
        public double L { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Vector4D"/> is empty.
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        [Browsable(false)]
        public bool IsEmpty
            => Abs(I) < double.Epsilon
            && Abs(J) < double.Epsilon
            && Abs(K) < double.Epsilon
            && Abs(L) < double.Epsilon;
        #endregion Properties

        #region Operators
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
        public static Point4D operator -(Vector4D value, Point4D subend) => new Point4D(value.I - subend.X, value.J - subend.Y, value.K - subend.Z, value.L - subend.W);

        /// <summary>
        /// Subtract Vectors
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4D operator -(Vector4D value, Vector4D subend) => new Vector4D(value.I - subend.I, value.J - subend.J, value.K - subend.K, value.L - subend.L);

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
        public static implicit operator (double I, double J, double K, double L)(Vector4D vector) => (vector.I, vector.J, vector.K, vector.L);

        /// <summary>
        /// Tuple to Vector4D
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Vector4D((double X, double Y, double Z, double W) value) => new Vector4D(value);
        #endregion Operators

        #region Factories
        ///// <summary>
        ///// Parse a string for a <see cref="Vector4D"/> value.
        ///// </summary>
        ///// <param name="source"><see cref="string"/> with <see cref="Vector4D"/> data </param>
        ///// <returns>
        ///// Returns an instance of the <see cref="Vector4D"/> struct converted
        ///// from the provided string using the <see cref="CultureInfo.InvariantCulture"/>.
        ///// </returns>
        //[ParseMethod]
        //public static Vector4D Parse(string source)
        //    => Parse(source, CultureInfo.InvariantCulture);

        ///// <summary>
        ///// Parse a string for a <see cref="Vector4D"/> value.
        ///// </summary>
        ///// <param name="source"><see cref="string"/> with <see cref="Vector4D"/> data </param>
        ///// <param name="provider"></param>
        ///// <returns>
        ///// Returns an instance of the <see cref="Vector4D"/> struct converted
        ///// from the provided string using the <see cref="CultureInfo.InvariantCulture"/>.
        ///// </returns>
        //public static Vector4D Parse(string source, IFormatProvider provider)
        //{
        //    var tokenizer = new Tokenizer(source, provider);
        //    var firstToken = tokenizer.NextTokenRequired();

        //    var value = new Vector4D(
        //        Convert.ToDouble(firstToken, provider),
        //        Convert.ToDouble(tokenizer.NextTokenRequired(), provider),
        //        Convert.ToDouble(tokenizer.NextTokenRequired(), provider),
        //        Convert.ToDouble(tokenizer.NextTokenRequired(), provider)
        //        );

        //    // There should be no more tokens in this string.
        //    tokenizer.LastTokenRequired();
        //    return value;
        //}
        #endregion Factories

        #region Public Methods
        /// <summary>
        /// Get the hash code.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(I, J, K, L);

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
        /// The equals.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vector4D other) => Equals(this, other);

        /// <summary>
        /// Creates a human-readable string that represents this <see cref="Vector4D"/> struct.
        /// </summary>
        /// <returns>A string representation of this <see cref="Vector4D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => ToString("R" /* format string */, CultureInfo.InvariantCulture /* format provider */);

        /// <summary>
        /// Creates a string representation of this <see cref="Vector4D"/> struct based on the IFormatProvider
        /// passed in.  If the provider is null, the CurrentCulture is used.
        /// </summary>
        /// <param name="provider">The <see cref="CultureInfo"/> provider.</param>
        /// <returns>A string representation of this <see cref="Vector4D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(IFormatProvider provider) => ToString("R" /* format string */, provider);

        /// <summary>
        /// Creates a string representation of this <see cref="Vector4D"/> struct based on the format string
        /// and IFormatProvider passed in.
        /// If the provider is null, the CurrentCulture is used.
        /// See the documentation for IFormattable for more information.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="provider">The <see cref="CultureInfo"/> provider.</param>
        /// <returns>A string representation of this <see cref="Vector4D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider provider)
        {
            if (this == null) return nameof(Vector4D);
            var sep = ((provider as CultureInfo) ?? CultureInfo.InvariantCulture).GetNumericListSeparator();
            return $"{nameof(Vector4D)}({nameof(I)}: {I.ToString(format, provider)}{sep} {nameof(J)}: {J.ToString(format, provider)}{sep} {nameof(K)}: {K.ToString(format, provider)}{sep} {nameof(L)}: {L.ToString(format, provider)})";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static Vector4D Plus(Vector4D item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector4D Add(Vector4D left, Vector4D right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static Vector4D Negate(Vector4D item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector4D Subtract(Vector4D left, Vector4D right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector4D Multiply(Vector4D left, Vector4D right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector4D Divide(Vector4D left, Vector4D right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector4D ToVector4D(Vector4D left, Vector4D right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public (double I, double J, double K, double L) To()
        {
            throw new NotImplementedException();
        }
        #endregion Public Methods
    }
}