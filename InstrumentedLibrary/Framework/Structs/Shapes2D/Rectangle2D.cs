using System;
using System.Collections.Generic;
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
    /// The rectangle2d struct.
    /// </summary>
    [ComVisible(true)]
    [DataContract, Serializable]
    [DebuggerDisplay("{ToString()}")]
    public struct Rectangle2D
        : IClosedShape, ICachableProperties, IEquatable<Rectangle2D>
    {
        #region Implementations
        /// <summary>
        /// The empty (readonly). Value: new Rectangle2D().
        /// </summary>
        public static readonly Rectangle2D Empty = new Rectangle2D(0, 0, 0, 0);

        /// <summary>
        /// The unit (readonly). Value: new Rectangle2D(0, 0, 1, 1).
        /// </summary>
        public static readonly Rectangle2D Unit = new Rectangle2D(0, 0, 1, 1);
        #endregion Implementations

        #region Fields
        /// <summary>
        /// The X coordinate location of the rectangle.
        /// </summary>
        private double x;

        /// <summary>
        /// The Y coordinate location of the rectangle.
        /// </summary>
        private double y;

        /// <summary>
        /// The width of the rectangle.
        /// </summary>
        private double width;

        /// <summary>
        /// The height of the rectangle.
        /// </summary>
        private double height;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle2D"/> class with an initial location and size.
        /// </summary>
        /// <param name="rectangle">The rectangle to clone.</param>
        public Rectangle2D(Rectangle2D rectangle)
            : this(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle2D"/> class with an empty location, with the provided size.
        /// </summary>
        /// <param name="size">The height and width of the <see cref="Rectangle2D"/>.</param>
        public Rectangle2D(Size2D size)
            : this(0, 0, size.Width, size.Height)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle2D"/> class with an initial location and size.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="size"></param>
        public Rectangle2D(Point2D location, Size2D size)
            : this(location.X, location.Y, size.Width, size.Height)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle2D"/> class  with a location and a vector size.
        /// </summary>
        public Rectangle2D(Point2D point, Vector2D vector)
            : this(point, point + vector)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle2D"/> class with the location and size from a tuple.
        /// </summary>
        /// <param name="tuple"></param>
        public Rectangle2D((double, double, double, double) tuple)
            : this()
        {
            (X, Y, Width, Height) = tuple;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle2D"/> class with a location and size.
        /// </summary>
        /// <param name="x">The x coordinate of the upper left corner of the rectangle.</param>
        /// <param name="y">The y coordinate of the upper left corner of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The Height of the rectangle.</param>
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
        /// Initializes a new instance of the <see cref="Rectangle2D"/> class with the upper left and lower right corners.
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
        /// Initializes a new instance of the <see cref="Rectangle2D"/> class with the location and size from a tuple.
        /// </summary>
        /// <param name="tuple1"></param>
        /// <param name="tuple2"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Rectangle2D((double, double) tuple1, (double, double) tuple2)
            : this()
        {
            (X, Y) = tuple1;
            (Width, Height) = tuple2;
        }
        #endregion Constructors

        #region Deconstructors
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
        #endregion Deconstructors

        #region Properties
        /// <summary>
        /// Gets or sets the X coordinate location of the rectangle.
        /// </summary>
        [Browsable(true)]
        [DisplayName(nameof(X))]
        [Category("Elements")]
        [Description("The " + nameof(X) + " coordinate location of the " + nameof(Rectangle2D) + ".")]
        [RefreshProperties(RefreshProperties.All)]
        [DataMember(Name = nameof(X)), XmlAttribute(nameof(X)), SoapAttribute(nameof(X))]
        public double X { get { return x; } set { x = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// Gets or sets the Y coordinate location of the rectangle.
        /// </summary>
        [Browsable(true)]
        [DisplayName(nameof(Y))]
        [Category("Elements")]
        [Description("The " + nameof(Y) + " coordinate location of the " + nameof(Rectangle2D) + ".")]
        [RefreshProperties(RefreshProperties.All)]
        [DataMember(Name = nameof(Y)), XmlAttribute(nameof(Y)), SoapAttribute(nameof(Y))]
        public double Y { get { return y; } set { y = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// Gets or sets the width of the rectangle.
        /// </summary>
        [Browsable(true)]
        [DisplayName(nameof(Width))]
        [Category("Elements")]
        [Description("The " + nameof(Width) + " of the " + nameof(Rectangle2D) + ".")]
        [RefreshProperties(RefreshProperties.All)]
        [DataMember(Name = nameof(Width)), XmlAttribute(nameof(Width)), SoapAttribute(nameof(Width))]
        public double Width { get { return width; } set { width = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// Gets or sets the height of the rectangle.
        /// </summary>
        [Browsable(true)]
        [DisplayName(nameof(Height))]
        [Category("Elements")]
        [Description("The " + nameof(Height) + " of the " + nameof(Rectangle2D) + ".")]
        [RefreshProperties(RefreshProperties.All)]
        [DataMember(Name = nameof(Height)), XmlAttribute(nameof(Height)), SoapAttribute(nameof(Height))]
        public double Height { get { return height; } set { height = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// Gets or sets the location of the rectangle.
        /// </summary>
        [Browsable(false)]
        [DisplayName(nameof(Location))]
        [Category("Elements")]
        [Description("The top left " + nameof(Location) + " of the " + nameof(Rectangle2D) + ".")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        //[TypeConverter(typeof(Point2DConverter))]
        [RefreshProperties(RefreshProperties.All)]
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Point2D Location { get { return new Point2D(x, y); } set { (x, y) = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// Gets or sets the height and width of the rectangle.
        /// </summary>
        [Browsable(false)]
        [DisplayName(nameof(Size))]
        [Category("Elements")]
        [Description("The " + nameof(Size) + " in " + nameof(Height) + " and " + nameof(Width) + " of the " + nameof(Rectangle2D) + ".")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [RefreshProperties(RefreshProperties.All)]
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Size2D Size { get { return new Size2D(width, height); } set { (width, height) = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// Gets or sets the center point X and Y coordinates of the rectangle.
        /// </summary>
        [Browsable(false)]
        [DisplayName(nameof(Center))]
        [Category("Elements")]
        [Description("The " + nameof(Center) + " location of the " + nameof(Rectangle2D) + ".")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        //[TypeConverter(typeof(Point2DConverter))]
        [RefreshProperties(RefreshProperties.All)]
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Point2D Center { get { return new Point2D(x + (width * 0.5d), Y + (height * 0.5d)); } set { (x, y) = (value.X - (width * 0.5d), value.Y - (height * 0.5d)); (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// Gets or sets the Aspect ratio of the rectangle.
        /// </summary>
        [Browsable(true)]
        [DisplayName(nameof(Aspect))]
        [Category("Properties")]
        [Description("The " + nameof(Aspect) + " ratio of the height and width of the " + nameof(Rectangle2D) + ".")]
        [RefreshProperties(RefreshProperties.All)]
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        public double Aspect { get { return height / width; } set { (height, width) = (width * value, height / value); (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// Gets or sets the left.
        /// </summary>
        [Browsable(false)]
        [DisplayName(nameof(Left))]
        [Category("Elements")]
        [Description("The left location of the " + nameof(Rectangle2D) + ".")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [RefreshProperties(RefreshProperties.All)]
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        public double Left { get { return X; } set { width += x - value; x = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// Gets or sets the top.
        /// </summary>
        [Browsable(false)]
        [DisplayName(nameof(Top))]
        [Category("Elements")]
        [Description("The top location of the " + nameof(Rectangle2D) + ".")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [RefreshProperties(RefreshProperties.All)]
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        public double Top { get { return Y; } set { height += y - value; y = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// Gets or sets the right.
        /// </summary>
        [Browsable(false)]
        [DisplayName(nameof(Right))]
        [Category("Elements")]
        [Description("The right location of the " + nameof(Rectangle2D) + ".")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [RefreshProperties(RefreshProperties.All)]
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        public double Right { get { return x + width; } set { width = value - x; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// Gets or sets the bottom.
        /// </summary>
        [Browsable(false)]
        [Category("Elements")]
        [Description("The bottom location of the " + nameof(Rectangle2D) + ".")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [RefreshProperties(RefreshProperties.All)]
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        public double Bottom { get { return y + height; } set { height = value - y; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// Gets or sets the top left point.
        /// </summary>
        [Browsable(false)]
        [DisplayName(nameof(TopLeft))]
        [Category("Elements")]
        [Description("The top left location of the " + nameof(Rectangle2D) + ".")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [RefreshProperties(RefreshProperties.All)]
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        public Point2D TopLeft { get { return new Point2D(x, y); } set { (x, y) = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// Gets or sets the top right point.
        /// </summary>
        [Browsable(false)]
        [DisplayName(nameof(TopRight))]
        [Category("Elements")]
        [Description("The top right location of the " + nameof(Rectangle2D) + ".")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [RefreshProperties(RefreshProperties.All)]
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        public Point2D TopRight { get { return new Point2D(Right, y); } set { (Right, y) = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// Gets or sets the bottom left point.
        /// </summary>
        [Browsable(false)]
        [DisplayName(nameof(BottomLeft))]
        [Category("Elements")]
        [Description("The bottom left location of the " + nameof(Rectangle2D) + ".")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [RefreshProperties(RefreshProperties.All)]
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        public Point2D BottomLeft { get { return new Point2D(x, Bottom); } set { (x, Bottom) = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// Gets or sets the bottom right point.
        /// </summary>
        [Browsable(false)]
        [DisplayName(nameof(BottomRight))]
        [Category("Elements")]
        [Description("The bottom right location of the " + nameof(Rectangle2D) + ".")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [RefreshProperties(RefreshProperties.All)]
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        public Point2D BottomRight { get { return new Point2D(Right, Bottom); } set { (Right, Bottom) = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// Gets the bounding box of the rectangle.
        /// </summary>
        [Browsable(false)]
        [DisplayName(nameof(Bounds))]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [RefreshProperties(RefreshProperties.All)]
        [Category("Elements")]
        [Description("bounding box of the " + nameof(Rectangle2D) + ".")]
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        public Rectangle2D Bounds => this;

        /// <summary>
        /// Gets the length of the perimeter of the rectangle.
        /// </summary>
        [Browsable(true)]
        [DisplayName(nameof(Perimeter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [Category("Elements")]
        [Description("The distance around the " + nameof(Rectangle2D) + ".")]
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        public double Perimeter
        {
            get
            {
                var (left, top, width, height) = this;
                return (double)(this as ICachableProperties).CachingProperty(() => RectanglePerimeterTests.RectanglePerimeter(left, top, width, height));
            }
        }

        /// <summary>
        /// Gets the area.
        /// </summary>
        [Browsable(true)]
        [DisplayName(nameof(Area))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [Category("Elements")]
        [Description("The " + nameof(Area) + " of the " + nameof(Rectangle2D) + ".")]
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        public double Area
        {
            get
            {
                var (_, _, width, height) = this;
                return (double)(this as ICachableProperties).CachingProperty(() => RectangleAreaTests.RectangleArea(width, height));
            }
        }

        /// <summary>
        /// Gets a value indicating whether the Rectangle2D has area.
        /// </summary>
        [Browsable(false)]
        [DisplayName(nameof(HasArea))]
        [Category("Elements")]
        [Description("A value indicating whether or not the " + nameof(Rectangle2D) + " has " + nameof(Height) + " or " + nameof(Width) + ".")]
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        public bool HasArea => width > 0 && height > 0;

        /// <summary>
        /// Gets a value indicating whether the Rectangle2D is empty.
        /// </summary>
        [Browsable(false)]
        [DisplayName(nameof(IsEmpty))]
        [Category("Elements")]
        [Description("A value indicating whether or not the " + nameof(Rectangle2D) + " has height or width.")]
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        public bool IsEmpty => (width <= 0) || (height <= 0);

        /// <summary>
        /// Property cache for commonly used properties that may take time to calculate.
        /// </summary>
        [Browsable(false)]
        [field: NonSerialized]
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        Dictionary<object, object> ICachableProperties.PropertyCache { get; set; }
        #endregion Properties

        #region Operators
        /// <summary>
        /// Tests whether two <see cref="Rectangle2D"/> objects have equal location and size.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Rectangle2D left, Rectangle2D right) => Equals(left, right);

        /// <summary>
        /// Tests whether two <see cref="Rectangle2D"/> objects differ in location or size.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Rectangle2D left, Rectangle2D right) => !Equals(left, right);

        /// <summary>
        /// Implicit conversion from <see cref="ValueTuple{T1, T2, T3, T4}"/> to <see cref="Rectangle2D"/>.
        /// </summary>
        /// <returns></returns>
        /// <param name="tuple"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Rectangle2D((double Left, double Top, double Width, double Height) tuple) => new Rectangle2D(tuple);

        /// <summary>
        /// Implicit conversion from <see cref="Rectangle2D"/> to <see cref="ValueTuple{T1, T2, T3, T4}"/>.
        /// </summary>
        /// <returns></returns>
        /// <param name="rectangle"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator (double Left, double Top, double Width, double Height)(Rectangle2D rectangle) => (rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        #endregion Operators

        /// <summary>
        /// Creates a new <see cref="Rectangle2D"/> with the specified location and size.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="right">The right.</param>
        /// <param name="bottom">The bottom.</param>
        /// <returns>The <see cref="Rectangle2D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rectangle2D FromLTRB(double left, double top, double right, double bottom) => new Rectangle2D(left, top, right - left, bottom - top);

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public (double Left, double Top, double Width, double Height) To() => (x, y, width, height);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Rectangle2D ToRectangle2D()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Tests whether <paramref name="obj"/> is a <see cref="Rectangle2D"/> with the same location and size of this <see cref="Rectangle2D"/>.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is Rectangle2D && Equals(this, (Rectangle2D)obj);

        /// <summary>
        /// Tests whether <paramref name="left"/> is a <see cref="Rectangle2D"/> with the same location and size of <paramref name="right"/>.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(Rectangle2D left, Rectangle2D right) => left.Equals(right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Rectangle2D other) => other.X == X && other.Y == Y && other.Width == Width && other.Height == Height;

        /// <summary>
        /// Gets the hash code for this <see cref="Rectangle2D"/>.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(x, y, width, height);

        /// <summary>
        /// Creates a <see cref="string"/> representation of this <see cref="IShape"/> interface based on the current culture.
        /// </summary>
        /// <returns>A <see cref="string"/> representation of this instance of the <see cref="IShape"/> object.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => ToString("R" /* format string */, CultureInfo.InvariantCulture /* format provider */);

        /// <summary>
        /// Creates a string representation of this <see cref="Rectangle2D"/> struct based on the format string
        /// and IFormatProvider passed in.
        /// If the provider is null, the CurrentCulture is used.
        /// See the documentation for IFormattable for more information.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <returns>
        /// A string representation of this object.
        /// </returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (this == null) return nameof(Rectangle2D);
            var sep = ((formatProvider as CultureInfo) ?? CultureInfo.InvariantCulture).GetNumericListSeparator();
            return $"{nameof(Rectangle2D)}({nameof(X)}: {x.ToString(format, formatProvider)}{sep} {nameof(Y)}: {y.ToString(format, formatProvider)}{sep} {nameof(Width)}: {width.ToString(format, formatProvider)}{sep} {nameof(Height)}: {height.ToString(format, formatProvider)})";
        }
        #endregion Methods
    }
}
