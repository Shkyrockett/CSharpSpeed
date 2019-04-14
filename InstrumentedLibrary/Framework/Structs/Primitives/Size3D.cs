using System;
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
    /// The size2d class.
    /// </summary>
    [DataContract, Serializable]
    [ComVisible(true)]
    [DebuggerDisplay("{nameof(Width)}: {Width ?? double.NaN}, {nameof(Height)}: {Height ?? double.NaN}, {nameof(Depth)}: {Depth ?? double.NaN}")]
    public struct Size3D
        : IFormattable
    {
        /// <summary>
        /// Represents a <see cref="Size3D"/> that has <see cref="Width"/>, <see cref="Height"/>, and <see cref="Depth"/> values set to zero.
        /// </summary>
        public static readonly Size3D Empty = new Size3D(0d, 0d, 0d);

        /// <summary>
        /// Represents a <see cref="Size3D"/> that has <see cref="Width"/>, <see cref="Height"/>, and <see cref="Depth"/> values set to 1.
        /// </summary>
        public static readonly Size3D Unit = new Size3D(1d, 1d, 1d);

        /// <summary>
        /// Represents a <see cref="Size3D"/> that has <see cref="Width"/>, <see cref="Height"/>, and <see cref="Depth"/> values set to NaN.
        /// </summary>
        public static readonly Size3D NaN = new Size3D(double.NaN, double.NaN, double.NaN);

        /// <summary>
        /// Initializes a new instance of the <see cref="Size3D"/> class.
        /// </summary>
        /// <param name="size"></param>
        public Size3D(Size3D size)
            : this(size.Width, size.Height, size.Depth)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Size3D"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="depth">The depth.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Size3D(double width, double height, double depth)
            : this()
        {
            Width = width;
            Height = height;
            Depth = depth;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Size3D"/> class.
        /// </summary>
        /// <param name="tuple"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Size3D((double Width, double Height, double Depth) tuple)
            : this()
        {
            (Width, Height, Depth) = tuple;
        }

        /// <summary>
        /// Deconstruct this <see cref="Size3D"/> to a <see cref="ValueTuple{T1, T2, T3}"/>.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="depth">The depth.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out double width, out double height, out double depth)
        {
            width = Width;
            height = Height;
            depth = Depth;
        }

        /// <summary>
        /// Gets or sets the Width component of a <see cref="Size3D"/> coordinate.
        /// </summary>
        [DataMember, XmlAttribute, SoapAttribute]
        public double Width { get; internal set; }

        /// <summary>
        /// Gets or sets the Height component of a <see cref="Size3D"/> coordinate.
        /// </summary>
        [DataMember, XmlAttribute, SoapAttribute]
        public double Height { get; internal set; }

        /// <summary>
        /// Gets or sets the Depth component of a <see cref="Size3D"/> coordinate.
        /// </summary>
        [DataMember, XmlAttribute, SoapAttribute]
        public double Depth { get; internal set; }

        /// <summary>
        /// The operator +.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="Size3D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size3D operator +(Size3D value) => new Size3D(+value.Width, +value.Height, +value.Depth);

        /// <summary>
        /// Add an amount to both values in the <see cref="Point3D"/> classes.
        /// </summary>
        /// <param name="value">The original value</param>
        /// <param name="addend">The amount to add.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size3D operator +(Size3D value, double addend) => new Size3D(value.Width + addend, value.Height + addend, value.Depth + addend);

        /// <summary>
        /// Add two <see cref="Size3D"/> classes together.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size3D operator +(Size3D value, Point3D addend) => new Size3D(value.Width + addend.X, value.Height + addend.Y, value.Depth + addend.Z);

        /// <summary>
        /// Add two <see cref="Size3D"/> classes together.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size3D operator +(Size3D value, Size3D addend) => new Size3D(value.Width + addend.Width, value.Height + addend.Height, value.Depth + addend.Depth);

        /// <summary>
        /// The operator -.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="Size3D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size3D operator -(Size3D value) => new Size3D(-value.Width, -value.Height, -value.Depth);

        /// <summary>
        /// Subtract a <see cref="Size3D"/> from a <see cref="double"/> value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size3D operator -(Size3D value, double subend) => new Size3D(value.Width - subend, value.Height - subend, value.Depth - subend);

        /// <summary>
        /// Subtract a <see cref="Size3D"/> from another <see cref="Size3D"/> class.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size3D operator -(Size3D value, Point3D subend) => new Size3D(value.Width - subend.X, value.Height - subend.Y, value.Depth - subend.Z);

        /// <summary>
        /// Subtract a <see cref="Size3D"/> from another <see cref="Size3D"/> class.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size3D operator -(Size3D value, Size3D subend) => new Size3D(value.Width - subend.Width, value.Height - subend.Height, value.Depth - subend.Depth);

        /// <summary>
        /// Scale a point
        /// </summary>
        /// <param name="factor"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size3D operator *(double value, Size3D factor) => new Size3D(value * factor.Width, value * factor.Height, value * factor.Depth);

        /// <summary>
        /// Scale a point.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="factor"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size3D operator *(Size3D value, double factor) => new Size3D(value.Width * factor, value.Height * factor, value.Depth * factor);

        /// <summary>
        /// Divide a <see cref="Size3D"/> by a <see cref="double"/> value.
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size3D operator /(Size3D dividend, double divisor) => new Size3D(dividend.Width / divisor, dividend.Height / divisor, dividend.Depth / divisor);

        /// <summary>
        /// Compares two <see cref="Size3D"/> objects.
        /// The result specifies whether the values of the <see cref="Width"/>, <see cref="Height"/> and <see cref="Depth"/>
        /// values of the two <see cref="Size3D"/> objects are equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Size3D left, Size3D right) => Equals(left, right);

        /// <summary>
        /// Compares two <see cref="Size3D"/> objects.
        /// The result specifies whether the values of the <see cref="Width"/>, <see cref="Height"/> or <see cref="Depth"/>
        /// values of the two <see cref="Size3D"/> objects are unequal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Size3D left, Size3D right) => !Equals(left, right);

        /// <summary>
        /// Converts the specified <see cref="Point3D"/> structure to a <see cref="Size3D"/> structure.
        /// </summary>
        /// <param name="point">The <see cref="Point3D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Size3D(Point3D point) => new Size3D(point.X, point.Y, point.Z);

        /// <summary>
        /// Converts the specified <see cref="Vector3D"/> structure to a <see cref="Size3D"/> structure.
        /// </summary>
        /// <param name="vector">The <see cref="Vector3D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Size3D(Vector3D vector) => new Size3D(vector.I, vector.J, vector.K);

        /// <summary>
        /// Converts the specified <see cref="Size3D"/> structure to a <see cref="ValueTuple{T1, T2, T3}"/> structure.
        /// </summary>
        /// <param name="size">The <see cref="Size3D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator (double Width, double Height, double Depth) (Size3D size) => (size.Width, size.Height, size.Depth);

        /// <summary>
        /// Implicit conversion from tuple.
        /// </summary>
        /// <returns></returns>
        /// <param name="tuple"> Size - the Size to convert to a Vector </param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Size3D((double Width, double Height, double Depth) tuple)
            => new Size3D(tuple);

        /// <summary>
        /// Compares two Vectors
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Compare(Size2D a, Size2D b) => Equals(a, b);

        /// <summary>
        /// Tests to see whether the specified object is a <see cref="Size3D"/>
        /// with the same dimensions as this <see cref="Size3D"/>.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is Size3D && Equals(this, (Size3D)obj);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(Size3D a, Size3D b) => (a.Width == b.Width) & (a.Height == b.Height) & (a.Depth == b.Depth);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Size3D value) => Equals(this, value);

        /// <summary>
        /// Get the hash code.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(Width, Height, Depth);

        /// <summary>
        /// Creates a human-readable string that represents this <see cref="Size3D"/> struct.
        /// </summary>
        /// <returns>A string representation of this <see cref="Size3D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => ToString("R" /* format string */, CultureInfo.InvariantCulture /* format provider */);

        /// <summary>
        /// Creates a string representation of this <see cref="Size3D"/> struct based on the IFormatProvider
        /// passed in.  If the provider is null, the CurrentCulture is used.
        /// </summary>
        /// <param name="provider">The <see cref="CultureInfo"/> provider.</param>
        /// <returns>A string representation of this <see cref="Size3D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(IFormatProvider provider) => ToString("R" /* format string */, provider);

        /// <summary>
        /// Creates a string representation of this <see cref="Size3D"/> struct based on the format string
        /// and IFormatProvider passed in.
        /// If the provider is null, the CurrentCulture is used.
        /// See the documentation for IFormattable for more information.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="provider">The <see cref="CultureInfo"/> provider.</param>
        /// <returns>A string representation of this <see cref="Size3D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider provider)
        {
            if (this == null) return nameof(Size3D);
            var s = ((provider as CultureInfo) ?? CultureInfo.InvariantCulture).GetNumericListSeparator();
            return $"{nameof(Size3D)}=[{nameof(Width)}:{Width.ToString(format, provider)}{s} {nameof(Height)}:{Height.ToString(format, provider)}{s} {nameof(Depth)}:{Depth.ToString(format, provider)}]";
        }
    }
}