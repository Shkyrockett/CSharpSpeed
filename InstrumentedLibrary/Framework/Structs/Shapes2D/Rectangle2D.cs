using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The rectangle2d struct.
    /// </summary>
    public struct Rectangle2D
        : IClosedShape
    {
        /// <summary>
        /// The empty.
        /// </summary>
        public static Rectangle2D Empty = new Rectangle2D(0, 0, 0, 0);

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle2D"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Rectangle2D(double x, double y, double width, double height)
            : this()
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle2D"/> class.
        /// </summary>
        /// <param name="point1">The point1.</param>
        /// <param name="point2">The point2.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Rectangle2D(Point2D point1, Point2D point2)
            : this()
        {
            X = Min(point1.X, point2.X);
            Y = Min(point1.Y, point2.Y);

            //  Max with 0 to prevent double weirdness from causing us to be (-epsilon..0)
            Width = Max(Max(point1.X, point2.X) - X, 0);
            Height = Max(Max(point1.Y, point2.Y) - Y, 0);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle2D"/> class.
        /// </summary>
        /// <param name="point1">The point1.</param>
        /// <param name="point2">The point2.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Rectangle2D((double X, double Y) point1, (double X, double Y) point2)
            : this()
        {
            X = Min(point1.X, point2.X);
            Y = Min(point1.Y, point2.Y);

            //  Max with 0 to prevent double weirdness from causing us to be (-epsilon..0)
            Width = Max(Max(point1.X, point2.X) - X, 0);
            Height = Max(Max(point1.Y, point2.Y) - Y, 0);
        }

        /// <summary>
        /// Deconstruct this <see cref="Rectangle2D"/> to a <see cref="ValueTuple{T1, T2, T3, T4}"/>.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out double left, out double top, out double width, out double height)
        {
            left = X;
            top = Y;
            width = Width;
            height = Height;
        }

        /// <summary>
        /// Gets or sets the x.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the left.
        /// </summary>
        public double Left { get { return X; } set { Width += X - value; X = value; } }

        /// <summary>
        /// Gets or sets the y.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Gets or sets the top.
        /// </summary>
        public double Top { get { return Y; } set { Height += Y - value; Y = value; } }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Gets or sets the right.
        /// </summary>
        public double Right { get { return X + Width; } set { Width = value - X; } }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Gets or sets the bottom.
        /// </summary>
        public double Bottom { get { return Y + Height; } set { Height = value - Y; } }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        public Point2D Location { get { return new Point2D(X, Y); } set { (X, Y) = value; } }

        /// <summary>
        /// 
        /// </summary>
        public Point2D TopLeft { get { return new Point2D(Left, Top); } set { (Left, Top) = value; } }

        /// <summary>
        /// 
        /// </summary>
        public Point2D TopRight { get { return new Point2D(Right, Top); } set { (Right, Top) = value; } }

        /// <summary>
        /// 
        /// </summary>
        public Point2D BottomRight { get { return new Point2D(Right, Bottom); } set { (Right, Bottom) = value; } }

        /// <summary>
        /// 
        /// </summary>
        public Point2D BottomLeft { get { return new Point2D(Left, Bottom); } set { (Left, Bottom) = value; } }

        /// <summary>
        /// Gets or sets the center.
        /// </summary>
        public Point2D Center { get { return new Point2D(X + (Width * 0.5d), Y + (Height * 0.5d)); } set { (X, Y) = (value.X - (Width * 0.5d), value.Y - (Height * 0.5d)); } }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        public Size2D Size { get { return new Size2D(Width, Height); } set { (Width, Height) = value; } }

        /// <summary>
        /// 
        /// </summary>
        public bool IsEmpty => (Width <= 0) || (Height <= 0);

        /// <summary>
        /// The from LTRB.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="right">The right.</param>
        /// <param name="bottom">The bottom.</param>
        /// <returns>The <see cref="Rectangle2D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rectangle2D FromLTRB(double left, double top, double right, double bottom) => new Rectangle2D(left, top, right - left, bottom - top);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is Rectangle2D && Equals(this, (Rectangle2D)obj);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(Rectangle2D left, Rectangle2D right) => left.X == right.X && left.Y == right.Y && left.Width == right.Width && left.Height == right.Height;

        /// <summary>
        /// Get the hash code.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(X, Y, Width, Height);

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider) => $"{nameof(Rectangle2D)}({nameof(X)}:{X:R}, {nameof(Y)}:{Y:R}, {nameof(Width)}:{Width:R}, {nameof(Height)}:{Height:R})";
    }
}