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
    /// The size2d struct.
    /// </summary>
    [ComVisible(true)]
    [DataContract, Serializable]
    [DebuggerDisplay("{ToString()}")]
    public struct Size2D
        : IFormattable,
        IEquatable<Size2D>,
        IPrintable
    {
        #region Implementations
        /// <summary>
        /// Represents a <see cref="Size2D"/> that has <see cref="Width"/>, and <see cref="Height"/> values set to zero.
        /// </summary>
        public static readonly Size2D Empty = new Size2D(0d, 0d);

        /// <summary>
        /// Represents a <see cref="Size2D"/> that has <see cref="Width"/>, and <see cref="Height"/> values set to 1.
        /// </summary>
        public static readonly Size2D Unit = new Size2D(1d, 1d);

        /// <summary>
        /// Represents a <see cref="Size2D"/> that has <see cref="Width"/>, and <see cref="Height"/> values set to NaN.
        /// </summary>
        public static readonly Size2D NaN = new Size2D(double.NaN, double.NaN);
        #endregion Implementations

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Size2D"/> class.
        /// </summary>
        /// <param name="size"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Size2D(Size2D size)
            : this(size.Width, size.Height)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Size2D"/> class.
        /// </summary>
        /// <param name="point"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Size2D(Point2D point)
            : this(point.X, point.Y)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Size2D"/> class.
        /// </summary>
        /// <param name="width">The Width component of the Size.</param>
        /// <param name="height">The Height component of the Size.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Size2D(double width, double height)
            : this()
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Size2D"/> class.
        /// </summary>
        /// <param name="tuple"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Size2D((double Width, double Height) tuple)
            : this()
        {
            (Width, Height) = tuple;
        }
        #endregion Constructors

        #region Deconstructors
        /// <summary>
        /// Deconstruct this <see cref="Size2D"/> to a <see cref="ValueTuple{T1, T2}"/>.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out double width, out double height)
        {
            width = Width;
            height = Height;
        }
        #endregion Deconstructors

        #region Properties
        /// <summary>
        /// Gets or sets the Width component of a <see cref="Size2D"/> coordinate.
        /// </summary>
        [DataMember(Name = nameof(Width)), XmlAttribute(nameof(Width)), SoapAttribute(nameof(Width))]
        public double Width { get; set; }

        /// <summary>
        /// Gets or sets the Height component of a <see cref="Size2D"/> coordinate.
        /// </summary>
        [DataMember(Name = nameof(Height)), XmlAttribute(nameof(Height)), SoapAttribute(nameof(Height))]
        public double Height { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Point2D"/> is empty.
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        [Browsable(false)]
        public bool IsEmpty
            => Abs(Width) < double.Epsilon
            && Abs(Height) < double.Epsilon;
        #endregion Properties

        #region Operators
        /// <summary>
        /// The operator +.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="Size2D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size2D operator +(Size2D value) => new Size2D(+value.Width, +value.Height);

        /// <summary>
        /// Add an amount to both values in the <see cref="Point2D"/> classes.
        /// </summary>
        /// <param name="value">The original value</param>
        /// <param name="addend">The amount to add.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size2D operator +(Size2D value, double addend) => new Size2D(value.Width + addend, value.Height + addend);

        /// <summary>
        /// Add two <see cref="Size2D"/> classes together.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size2D operator +(Size2D value, Point2D addend) => new Size2D(value.Width + addend.X, value.Height + addend.Y);

        /// <summary>
        /// Add two <see cref="Size2D"/> classes together.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size2D operator +(Size2D value, Size2D addend) => new Size2D(value.Width + addend.Width, value.Height + addend.Height);

        /// <summary>
        /// The operator -.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="Size2D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size2D operator -(Size2D value) => new Size2D(-value.Width, -value.Height);

        /// <summary>
        /// Subtract a <see cref="Size2D"/> from a <see cref="double"/> value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size2D operator -(Size2D value, double subend) => new Size2D(value.Width - subend, value.Height - subend);

        /// <summary>
        /// Subtract a <see cref="Size2D"/> from another <see cref="Size2D"/> class.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size2D operator -(Size2D value, Point2D subend) => new Size2D(value.Width - subend.X, value.Height - subend.Y);

        /// <summary>
        /// Subtract a <see cref="Size2D"/> from another <see cref="Size2D"/> class.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size2D operator -(Size2D value, Size2D subend) => new Size2D(value.Width - subend.Width, value.Height - subend.Height);

        /// <summary>
        /// Scale a point
        /// </summary>
        /// <param name="factor"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size2D operator *(double value, Size2D factor) => new Size2D(value * factor.Width, value * factor.Height);

        /// <summary>
        /// Scale a point.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="factor"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size2D operator *(Size2D value, double factor) => new Size2D(value.Width * factor, value.Height * factor);

        /// <summary>
        /// Divide a <see cref="Size2D"/> by a <see cref="double"/> value.
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size2D operator /(Size2D dividend, double divisor) => new Size2D(dividend.Width / divisor, dividend.Height / divisor);

        /// <summary>
        /// Compares two <see cref="Size2D"/> objects.
        /// The result specifies whether the values of the <see cref="Width"/> and <see cref="Height"/>
        /// values of the two <see cref="Size2D"/> objects are equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Size2D left, Size2D right) => Equals(left, right);

        /// <summary>
        /// Compares two <see cref="Size2D"/> objects.
        /// The result specifies whether the values of the <see cref="Width"/> or <see cref="Height"/>
        /// values of the two <see cref="Size2D"/> objects are unequal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Size2D left, Size2D right) => !Equals(left, right);

        /// <summary>
        /// Converts the specified <see cref="Point2D"/> structure to a <see cref="Size2D"/> structure.
        /// </summary>
        /// <param name="point">The <see cref="Point2D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Size2D(Point2D point) => new Size2D(point.X, point.Y);

        /// <summary>
        /// Converts the specified <see cref="Vector2D"/> structure to a <see cref="Size2D"/> structure.
        /// </summary>
        /// <param name="vector">The <see cref="Vector2D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Size2D(Vector2D vector) => new Size2D(vector.I, vector.J);

        /// <summary>
        /// Converts the specified <see cref="Size2D"/> structure to a <see cref="ValueTuple{T1, T2}"/> structure.
        /// </summary>
        /// <param name="size">The <see cref="Size2D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator (double Width, double Height)(Size2D size) => (size.Width, size.Height);

        /// <summary>
        /// Implicit conversion from tuple.
        /// </summary>
        /// <returns></returns>
        /// <param name="tuple"> Size - the Size to convert to a Vector </param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Size2D((double Width, double Height) tuple) => new Size2D(tuple);
        #endregion Operators

        #region Factories
        ///// <summary>
        ///// Parse a string for a <see cref="Size2D"/> value.
        ///// </summary>
        ///// <param name="source"><see cref="string"/> with <see cref="Size2D"/> data </param>
        ///// <returns>
        ///// Returns an instance of the <see cref="Size2D"/> struct converted
        ///// from the provided string using the <see cref="CultureInfo.InvariantCulture"/>.
        ///// </returns>
        //[ParseMethod]
        //public static Size2D Parse(string source)
        //    => Parse(source, CultureInfo.InvariantCulture);

        ///// <summary>
        ///// Parse a string for a <see cref="Size2D"/> value.
        ///// </summary>
        ///// <param name="source"><see cref="string"/> with <see cref="Size2D"/> data </param>
        ///// <param name="provider"></param>
        ///// <returns>
        ///// Returns an instance of the <see cref="Size2D"/> struct converted
        ///// from the provided string using the <see cref="CultureInfo.InvariantCulture"/>.
        ///// </returns>
        //public static Size2D Parse(string source, IFormatProvider provider)
        //{
        //    var tokenizer = new Tokenizer(source, provider);
        //    var firstToken = tokenizer.NextTokenRequired();

        //    // The token will already have had whitespace trimmed so we can do a simple string compare.
        //    var value = firstToken == nameof(Empty) ? Empty : new Size2D(
        //        Convert.ToDouble(firstToken, provider),
        //        Convert.ToDouble(tokenizer.NextTokenRequired(), provider)
        //        );

        //    // There should be no more tokens in this string.
        //    tokenizer.LastTokenRequired();
        //    return value;
        //}
        #endregion Factories

        #region Methods
        /// <summary>
        /// Get the hash code.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(Width, Height);

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
        /// Tests to see whether the specified object is a <see cref="Size2D"/>
        /// with the same dimensions as this <see cref="Size2D"/>.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is Size2D && Equals(this, (Size2D)obj);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(Size2D a, Size2D b) => (a.Width == b.Width) & (a.Height == b.Height);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Size2D value) => Equals(this, value);

        /// <summary>
        /// The to point2d.
        /// </summary>
        /// <returns>The <see cref="Point2D"/>.</returns>
        public Point2D ToPoint2D() => (Point2D)this;

        /// <summary>
        /// The truncate.
        /// </summary>
        /// <returns>The <see cref="Size2D"/>.</returns>
        public Size2D Truncate() => new Size2D((int)Width, (int)Height);

        /// <summary>
        /// Creates a human-readable string that represents this <see cref="Size2D"/> struct.
        /// </summary>
        /// <returns>A string representation of this <see cref="Size2D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => ToString("R" /* format string */, CultureInfo.InvariantCulture /* format provider */);

        /// <summary>
        /// Creates a string representation of this <see cref="Size2D"/> struct based on the IFormatProvider
        /// passed in.  If the provider is null, the CurrentCulture is used.
        /// </summary>
        /// <param name="provider">The <see cref="CultureInfo"/> provider.</param>
        /// <returns>A string representation of this <see cref="Size2D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(IFormatProvider provider) => ToString("R" /* format string */, provider);

        /// <summary>
        /// Creates a string representation of this <see cref="Size2D"/> struct based on the format string
        /// and IFormatProvider passed in.
        /// If the provider is null, the CurrentCulture is used.
        /// See the documentation for IFormattable for more information.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="provider">The <see cref="CultureInfo"/> provider.</param>
        /// <returns>A string representation of this <see cref="Size2D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider provider)
        {
            if (this == null) return nameof(Size2D);
            var sep = ((provider as CultureInfo) ?? CultureInfo.InvariantCulture).GetNumericListSeparator();
            return $"{nameof(Size2D)}({nameof(Width)}: {Width.ToString(format, provider)}{sep} {nameof(Height)}: {Height.ToString(format, provider)})";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static Size2D Plus(Size2D item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Size2D Add(Size2D left, Size2D right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static Size2D Negate(Size2D item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Size2D Subtract(Size2D left, Size2D right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Size2D Multiply(Size2D left, Size2D right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Size2D Divide(Size2D left, Size2D right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Size2D ToSize2D(Size2D left, Size2D right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public (double Width, double Height) To()
        {
            throw new NotImplementedException();
        }
        #endregion Methods
    }
}