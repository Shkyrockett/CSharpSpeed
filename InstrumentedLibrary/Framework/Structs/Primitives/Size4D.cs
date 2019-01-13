using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The size2d class.
    /// </summary>
    public struct Size4D
    {
        /// <summary>
        /// Represents a <see cref="Size4D"/> that has <see cref="Width"/>, <see cref="Height"/>, <see cref="Depth"/> and <see cref="Breadth"/> values set to zero.
        /// </summary>
        public static readonly Size4D Empty = new Size4D(0d, 0d, 0d, 0d);

        /// <summary>
        /// Initializes a new instance of the <see cref="Size4D"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="depth">The depth.</param>
        /// <param name="breadth">The breadth.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Size4D(double width, double height, double depth, double breadth)
        {
            Width = width;
            Height = height;
            Depth = depth;
            Breadth = breadth;
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
        /// Gets or sets the depth.
        /// </summary>
        public double Depth { get; internal set; }

        /// <summary>
        /// Gets or sets the depth.
        /// </summary>
        public double Breadth { get; internal set; }

        /// <summary>
        /// Deconstruct this <see cref="Size4D"/> to a <see cref="ValueTuple{T1, T2, T3, T4}"/>.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="depth">The depth.</param>
        /// <param name="breadth">The breadth.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out double width, out double height, out double depth, out double breadth)
        {
            width = Width;
            height = Height;
            depth = Depth;
            breadth = Breadth;
        }

        /// <summary>
        /// The operator +.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="Size4D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size4D operator +(Size4D value) => new Size4D(+value.Width, +value.Height, +value.Depth, +value.Breadth);

        /// <summary>
        /// Add an amount to both values in the <see cref="Point4D"/> classes.
        /// </summary>
        /// <param name="value">The original value</param>
        /// <param name="addend">The amount to add.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size4D operator +(Size4D value, double addend) => new Size4D(value.Width + addend, value.Height + addend, value.Depth + addend, value.Breadth + addend);

        /// <summary>
        /// Add two <see cref="Size4D"/> classes together.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size4D operator +(Size4D value, Point4D addend) => new Size4D(value.Width + addend.X, value.Height + addend.Y, value.Depth + addend.Z, value.Breadth + addend.W);

        /// <summary>
        /// Add two <see cref="Size4D"/> classes together.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size4D operator +(Size4D value, Size4D addend) => new Size4D(value.Width + addend.Width, value.Height + addend.Height, value.Depth + addend.Depth, value.Breadth + addend.Breadth);

        /// <summary>
        /// The operator -.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="Size4D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size4D operator -(Size4D value) => new Size4D(-value.Width, -value.Height, -value.Depth, -value.Breadth);

        /// <summary>
        /// Subtract a <see cref="Size4D"/> from a <see cref="double"/> value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size4D operator -(Size4D value, double subend) => new Size4D(value.Width - subend, value.Height - subend, value.Depth - subend, value.Breadth - subend);

        /// <summary>
        /// Subtract a <see cref="Size4D"/> from another <see cref="Size4D"/> class.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size4D operator -(Size4D value, Point4D subend) => new Size4D(value.Width - subend.X, value.Height - subend.Y, value.Depth - subend.Z, value.Breadth - subend.W);

        /// <summary>
        /// Subtract a <see cref="Size4D"/> from another <see cref="Size4D"/> class.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="subend"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size4D operator -(Size4D value, Size4D subend) => new Size4D(value.Width - subend.Width, value.Height - subend.Height, value.Depth - subend.Depth, value.Breadth - subend.Breadth);

        /// <summary>
        /// Scale a point
        /// </summary>
        /// <param name="factor"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size4D operator *(double value, Size4D factor) => new Size4D(value * factor.Width, value * factor.Height, value * factor.Depth, value * factor.Breadth);

        /// <summary>
        /// Scale a Size.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="factor"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size4D operator *(Size4D value, double factor) => new Size4D(value.Width * factor, value.Height * factor, value.Depth * factor, value.Breadth * factor);

        /// <summary>
        /// Divide a <see cref="Size4D"/> by a <see cref="double"/> value.
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Size4D operator /(Size4D dividend, double divisor) => new Size4D(dividend.Width / divisor, dividend.Height / divisor, dividend.Depth / divisor, dividend.Breadth / divisor);

        /// <summary>
        /// Compares two <see cref="Size4D"/> objects.
        /// The result specifies whether the values of the <see cref="Width"/>, <see cref="Height"/>, <see cref="Depth"/> and <see cref="Breadth"/>
        /// values of the two <see cref="Size4D"/> objects are equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Size4D left, Size4D right) => Equals(left, right);

        /// <summary>
        /// Compares two <see cref="Size4D"/> objects.
        /// The result specifies whether the values of the <see cref="Width"/>, <see cref="Height"/>, <see cref="Depth"/> or <see cref="Breadth"/>
        /// values of the two <see cref="Size4D"/> objects are unequal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Size4D left, Size4D right) => !Equals(left, right);

        /// <summary>
        /// Converts the specified <see cref="Point4D"/> structure to a <see cref="Size4D"/> structure.
        /// </summary>
        /// <param name="point">The <see cref="Point4D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Size4D(Point4D point) => new Size4D(point.X, point.Y, point.Z, point.W);

        /// <summary>
        /// Converts the specified <see cref="Vector4D"/> structure to a <see cref="Size4D"/> structure.
        /// </summary>
        /// <param name="vector">The <see cref="Vector4D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Size4D(Vector4D vector) => new Size4D(vector.I, vector.J, vector.K, vector.L);

        /// <summary>
        /// Converts the specified <see cref="Size4D"/> structure to a <see cref="ValueTuple{T1, T2, T3, T4}"/> structure.
        /// </summary>
        /// <param name="size">The <see cref="Size4D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator (double Width, double Height, double Depth, double Breadth) (Size4D size) => (size.Width, size.Height, size.Depth, size.Breadth);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is Size4D && Equals(this, (Size4D)obj);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(Size4D a, Size4D b) => (a.Width == b.Width) & (a.Height == b.Height) & (a.Depth == b.Depth) & (a.Breadth == b.Breadth);

        /// <summary>
        /// Get the hash code.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(Width, Height, Depth, Breadth);

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"{nameof(Size3D)}{{{nameof(Width)}:{Width:R}, {nameof(Height)}:{Height:R}, {nameof(Depth)}:{Depth:R}, {nameof(Breadth)}:{Breadth:R} }}";
    }
}