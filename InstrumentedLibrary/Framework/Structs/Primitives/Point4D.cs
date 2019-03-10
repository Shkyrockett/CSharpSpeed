﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The <see cref="Point4D"/> struct.
    /// </summary>
    [DataContract, Serializable]
    [ComVisible(true)]
    [DebuggerDisplay("{nameof(X)}: {X ?? double.NaN}, {nameof(Y)}: {Y ?? double.NaN}, {nameof(Z)}: {Z ?? double.NaN}, {nameof(W)}: {W ?? double.NaN}")]
    public struct Point4D
        : IFormattable
    {
        /// <summary>
        /// Represents a <see cref="Point4D"/> that has <see cref="X"/>, <see cref="Y"/>, <see cref="Z"/>, and <see cref="W"/> values set to zero.
        /// </summary>
        public static readonly Point4D Empty = new Point4D(0d, 0d, 0d, 0d);

        /// <summary>
        /// Represents a <see cref="Point4D"/> that has <see cref="X"/>, <see cref="Y"/>, <see cref="Z"/>, and <see cref="W"/> values set to 1.
        /// </summary>
        public static readonly Point4D Unit = new Point4D(1d, 1d, 1d, 1d);

        /// <summary>
        /// Represents a <see cref="Point4D"/> that has <see cref="X"/>, <see cref="Y"/>, <see cref="Z"/>, and <see cref="W"/> values set to NaN.
        /// </summary>
        public static readonly Point4D NaN = new Point4D(double.NaN, double.NaN, double.NaN, double.NaN);

        /// <summary>
        /// Initializes a new instance of the <see cref="Point4D"/> class.
        /// </summary>
        /// <param name="point"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Point4D(Point4D point)
            : this(point.X, point.Y, point.Z, point.W)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point4D"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        /// <param name="w">The w.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Point4D(double x, double y, double z, double w)
            : this()
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// Initializes a new  instance of the <see cref="Point3D"/> class.
        /// </summary>
        /// <param name="tuple"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Point4D((double X, double Y, double Z, double W) tuple)
            : this()
        {
            (X, Y, Z, W) = tuple;
        }

        /// <summary>
        /// Deconstruct this <see cref="Point4D"/> to a <see cref="ValueTuple{T1, T2, T3, T4}"/>.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        /// <param name="w">The w.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out double x, out double y, out double z, out double w)
        {
            x = X;
            y = Y;
            z = Z;
            w = W;
        }

        /// <summary>
        /// Gets or sets the X component of a <see cref="Point4D"/> coordinate.
        /// </summary>
        [DataMember, XmlAttribute, SoapAttribute]
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the Y component of a <see cref="Point4D"/> coordinate.
        /// </summary>
        [DataMember, XmlAttribute, SoapAttribute]
        public double Y { get; set; }

        /// <summary>
        /// Gets or sets the Z component of a <see cref="Point4D"/> coordinate.
        /// </summary>
        [DataMember, XmlAttribute, SoapAttribute]
        public double Z { get; set; }

        /// <summary>
        /// Gets or sets the W component of a <see cref="Point4D"/> coordinate.
        /// </summary>
        [DataMember, XmlAttribute, SoapAttribute]
        public double W { get; set; }

        /// <summary>
        /// Unary addition operator.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point4D operator +(Point4D value) => new Point4D(+value.X, +value.Y, +value.Z, +value.W);

        /// <summary>
        /// Add an amount to both values in the <see cref="Point4D"/> classes.
        /// </summary>
        /// <param name="value">The original value</param>
        /// <param name="addend">The amount to add.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point4D operator +(Point4D value, double addend) => new Point4D(value.X + addend, value.Y + addend, value.Z + addend, value.W + addend);

        /// <summary>
        /// Add two <see cref="Point4D"/> classes together.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4D operator +(Point4D value, Point4D addend) => new Vector4D(value.X + addend.X, value.Y + addend.Y, value.Z + addend.Z, value.W + addend.W);

        /// <summary>
        /// Add two <see cref="Point4D"/> classes together.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point4D operator +(Point4D value, Size4D addend) => new Point4D(value.X + addend.Width, value.Y + addend.Height, value.Z + addend.Depth, value.W + addend.Breadth);

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
        public static Point4D operator +(Point4D point, Vector4D vector) => new Point4D(point.X + vector.I, point.Y + vector.J, point.Z + vector.K, point.W + vector.L);

        /// <summary>
        /// Unary subtraction operator.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point4D operator -(Point4D value) => new Point4D(-value.X, -value.Y, -value.Z, -value.W);

        /// <summary>
        /// Subtract a <see cref="Point4D"/> from a <see cref="double"/> value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point4D operator -(Point4D value, double subend) => new Point4D(value.X - subend, value.Y - subend, value.Z - subend, value.W - subend);

        /// <summary>
        /// Subtract a <see cref="Point4D"/> from another <see cref="Point4D"/> class.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4D operator -(Point4D value, Point4D subend) => new Vector4D(value.X + subend.X, value.Y + subend.Y, value.Z + subend.Z, value.W + subend.W);

        /// <summary>
        /// Subtract a <see cref="Point4D"/> from another <see cref="Point4D"/> class.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point4D operator -(Point4D value, Size4D subend) => new Point4D(value.X + subend.Width, value.Y + subend.Height, value.Z + subend.Depth, value.W + subend.Breadth);

        /// <summary>
        /// Subtract a <see cref="Point4D"/> from another <see cref="Point4D"/> class.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point4D operator -(Point4D value, Vector4D subend) => new Point4D(value.X + subend.I, value.Y + subend.J, value.Z + subend.K, value.W + subend.L);

        /// <summary>
        /// Scale a point
        /// </summary>
        /// <param name="factor"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point4D operator *(double value, Point4D factor) => new Point4D(value * factor.X, value * factor.Y, value * factor.Z, value * factor.W);

        /// <summary>
        /// Scale a point.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="factor"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point4D operator *(Point4D value, double factor) => new Point4D(value.X * factor, value.Y * factor, value.Z * factor, value.W * factor);

        /// <summary>
        /// Divide a <see cref="Point4D"/> by a value.
        /// </summary>
        /// <param name="divisor">The divisor value</param>
        /// <param name="dividend">The dividend to add.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point4D operator /(Point4D divisor, double dividend) => new Point4D(divisor.X / dividend, divisor.Y / dividend, divisor.Z / dividend, divisor.W / dividend);

        /// <summary>
        /// Divide a <see cref="Point4D"/>
        /// </summary>
        /// <param name="divisor">The <see cref="Point4D"/></param>
        /// <param name="dividend">The divisor</param>
        /// <returns>A <see cref="Point4D"/> divided by the divisor</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point4D operator /(double divisor, Point4D dividend) => new Point4D(divisor / dividend.X, divisor / dividend.Y, divisor / dividend.Z, divisor / dividend.W);

        /// <summary>
        /// Compares two <see cref="Point4D"/> objects.
        /// The result specifies whether the values of the <see cref="X"/>, <see cref="Y"/>, <see cref="Z"/> and <see cref="W"/>
        /// values of the two <see cref="Point4D"/> objects are equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Point4D left, Point4D right) => Equals(left, right);

        /// <summary>
        /// Compares two <see cref="Point4D"/> objects.
        /// The result specifies whether the values of the <see cref="X"/>, <see cref="Y"/>, <see cref="Z"/> or <see cref="W"/>
        /// values of the two <see cref="Point4D"/> objects are unequal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Point4D left, Point4D right) => !Equals(left, right);

        /// <summary>
        /// Converts the specified <see cref="Vector4D"/> structure to a <see cref="Point4D"/> structure.
        /// </summary>
        /// <param name="vector">The <see cref="Vector4D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Point4D(Vector4D vector) => new Point4D(vector.I, vector.J, vector.K, vector.L);

        /// <summary>
        /// Converts the specified <see cref="Size4D"/> structure to a <see cref="Point4D"/> structure.
        /// </summary>
        /// <param name="size">The <see cref="Size4D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Point4D(Size4D size) => new Point4D(size.Width, size.Height, size.Depth, size.Breadth);

        /// <summary>
        /// Implicit conversion from tuple.
        /// </summary>
        /// <param name="tuple"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Point4D((double X, double Y, double Z, double W) tuple) => new Point4D(tuple);

        /// <summary>
        /// Converts the specified <see cref="Point4D"/> structure to a <see cref="ValueTuple{T1, T2, T3, T4}"/> structure.
        /// </summary>
        /// <param name="point">The <see cref="Point4D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator (double X, double Y, double Z, double W) (Point4D point) => (point.X, point.Y, point.Z, point.W);

        /// <summary>
        /// Compares two Vectors
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Compare(Point4D a, Point4D b)
            => Equals(a, b);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(Point4D a, Point4D b) => (a.X == b.X) && (a.Y == b.Y) && (a.Z == b.Z) && (a.W == b.W);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is Point4D && Equals(this, (Point4D)obj);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Point4D value) => Equals(this, value);

        /// <summary>
        /// Get the hash code.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(X, Y, Z, W);

        /// <summary>
        /// Creates a human-readable string that represents this <see cref="Point4D"/> struct.
        /// </summary>
        /// <returns>A string representation of this <see cref="Point4D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => ToString("R" /* format string */, CultureInfo.InvariantCulture /* format provider */);

        /// <summary>
        /// Creates a string representation of this <see cref="Point4D"/> struct based on the IFormatProvider
        /// passed in.  If the provider is null, the CurrentCulture is used.
        /// </summary>
        /// <param name="provider">The <see cref="CultureInfo"/> provider.</param>
        /// <returns>A string representation of this <see cref="Point4D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(IFormatProvider provider) => ToString("R" /* format string */, provider);

        /// <summary>
        /// Creates a string representation of this <see cref="Point4D"/> struct based on the format string
        /// and IFormatProvider passed in.
        /// If the provider is null, the CurrentCulture is used.
        /// See the documentation for IFormattable for more information.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="provider">The <see cref="CultureInfo"/> provider.</param>
        /// <returns>A string representation of this <see cref="Point4D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider provider)
        {
            if (this == null) return nameof(Point4D);
            var s = ((provider as CultureInfo) ?? CultureInfo.InvariantCulture).GetNumericListSeparator();
            return $"{nameof(Point4D)}=[{nameof(X)}:{X.ToString(format, provider)}{s} {nameof(Y)}:{Y.ToString(format, provider)}{s} {nameof(Z)}:{Z.ToString(format, provider)}{s} {nameof(W)}:{W.ToString(format, provider)}]";
        }
    }
}