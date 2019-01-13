using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The size2d class.
    /// </summary>
    public struct Size2D
    {
        /// <summary>
        /// Represents a <see cref="Size2D"/> that has <see cref="Width"/> and <see cref="Height"/> values set to zero.
        /// </summary>
        public static readonly Size2D Empty = new Size2D(0d, 0d);

        /// <summary>
        /// Initializes a new instance of the <see cref="Size2D"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Size2D(double width, double height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        public double Width { get; internal set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        public double Height { get; internal set; }

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
        public static implicit operator (double Width, double Height) (Size2D size) => (size.Width, size.Height);

        /// <summary>
        /// The equals.
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
        /// Get the hash code.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(Width, Height);

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"{nameof(Size2D)}{{{nameof(Width)}:{Width:R}, {nameof(Height)}:{Height:R} }}";
    }
}