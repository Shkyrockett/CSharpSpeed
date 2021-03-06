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
    /// The transform2d struct.
    /// </summary>
    [ComVisible(true)]
    [DataContract, Serializable]
    [DebuggerDisplay("{ToString()}")]
    public struct Transform2D
        : IEquatable<Transform2D>,
        IPrintable
    {
        #region Implementations
        /// <summary>
        /// The identity.
        /// </summary>
        public static readonly Transform2D Identity = new Transform2D(0d, 0d, 0d, 0d, 1d, 1d);
        #endregion Implementations

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Transform2D"/> class.
        /// </summary>
        /// <param name="tuple">The tuple.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Transform2D((double x, double y, double skewX, double skewY, double scaleX, double scaleY) tuple)
            : this()
        {
            (X, Y, SkewX, SkewY, ScaleX, ScaleY) = tuple;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Transform2D"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="skewX">The skewX.</param>
        /// <param name="skewY">The skewY.</param>
        /// <param name="scaleX">The scaleX.</param>
        /// <param name="scaleY">The scaleY.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Transform2D(double x, double y, double skewX, double skewY, double scaleX, double scaleY)
            : this()
        {
            X = x;
            Y = y;
            SkewX = skewX;
            SkewY = skewY;
            ScaleX = scaleX;
            ScaleY = scaleY;
        }
        #endregion Constructors

        #region Deconstructors
        /// <summary>
        /// The deconstruct.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="skewX">The skewX.</param>
        /// <param name="skewY">The skewY.</param>
        /// <param name="scaleX">The scaleX.</param>
        /// <param name="scaleY">The scaleY.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Deconstruct(out double x, out double y, out double skewX, out double skewY, out double scaleX, out double scaleY)
        {
            x = X;
            y = Y;
            skewX = SkewX;
            skewY = SkewY;
            scaleX = ScaleX;
            scaleY = ScaleY;
        }
        #endregion Deconstructors

        #region Properties
        /// <summary>
        /// Gets or sets the <see cref="X"/> coordinate of the location of the <see cref="Transform2D"/>.
        /// </summary>
        [DataMember(Name = nameof(X)), XmlAttribute(nameof(X)), SoapAttribute(nameof(X))]
        [Browsable(true)]
        [Category("Elements")]
        [Description("The center x coordinate location of the " + nameof(Transform2D) + ".")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [RefreshProperties(RefreshProperties.All)]
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Y"/> coordinate of the location of the <see cref="Transform2D"/>.
        /// </summary>
        [DataMember(Name = nameof(Y)), XmlAttribute(nameof(Y)), SoapAttribute(nameof(Y))]
        [Browsable(true)]
        [Category("Elements")]
        [Description("The center y coordinate location of the " + nameof(Transform2D) + ".")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [RefreshProperties(RefreshProperties.All)]
        public double Y { get; set; }

        /// <summary>
        /// Gets or sets the horizontal skew value of the <see cref="Transform2D"/>.
        /// </summary>
        [DataMember(Name = nameof(SkewX)), XmlAttribute(nameof(SkewX)), SoapAttribute(nameof(SkewX))]
        [Browsable(true)]
        [Category("Elements")]
        [Description("The x skew of the " + nameof(Transform2D) + ".")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [RefreshProperties(RefreshProperties.All)]
        public double SkewX { get; set; }

        /// <summary>
        /// Gets or sets the vertical skew value of the <see cref="Transform2D"/>.
        /// </summary>
        [DataMember(Name = nameof(SkewY)), XmlAttribute(nameof(SkewY)), SoapAttribute(nameof(SkewY))]
        [Browsable(true)]
        [Category("Elements")]
        [Description("The y skew of the " + nameof(Transform2D) + ".")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [RefreshProperties(RefreshProperties.All)]
        public double SkewY { get; set; }

        /// <summary>
        /// Gets or sets the horizontal scale of the <see cref="Transform2D"/>.
        /// </summary>
        [DataMember(Name = nameof(ScaleX)), XmlAttribute(nameof(ScaleX)), SoapAttribute(nameof(ScaleX))]
        [Browsable(true)]
        [Category("Elements")]
        [Description("The x scale of the " + nameof(Transform2D) + ".")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [RefreshProperties(RefreshProperties.All)]
        public double ScaleX { get; set; }

        /// <summary>
        /// Gets or sets the vertical scale of the <see cref="Transform2D"/>.
        /// </summary>
        [DataMember(Name = nameof(ScaleY)), XmlAttribute(nameof(ScaleY)), SoapAttribute(nameof(ScaleY))]
        [Browsable(true)]
        [Category("Elements")]
        [Description("The y scale of the " + nameof(Transform2D) + ".")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [RefreshProperties(RefreshProperties.All)]
        public double ScaleY { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Rotation"/> angle of the <see cref="Transform2D"/> in Radians.
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        [Browsable(true)]
        //[GeometryAngleRadians]
        [Category("Elements")]
        [Description("The angle of " + nameof(Rotation) + " to rotate the " + nameof(Transform2D) + " in Radians.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        //[TypeConverter(typeof(AngleConverter))]
        [RefreshProperties(RefreshProperties.All)]
        public double Rotation
        {
            get { return SkewY; }
            set
            {
                var delta = value - SkewY;
                SkewX += delta;
                SkewY += delta;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Rotation"/> angle of the <see cref="Transform2D"/> in Degrees.
        /// </summary>
        [DataMember(Name = "Angle"), XmlAttribute("Angle"), SoapAttribute("Angle")]
        [Browsable(false)]
        //[GeometryAngleDegrees]
        [Category("Elements")]
        [Description("The angle of " + nameof(Rotation) + " to rotate the " + nameof(Transform2D) + " in Degrees.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [RefreshProperties(RefreshProperties.All)]
        public double RotationDegrees { get { return Rotation.ToDegrees(); } set { Rotation = value.ToRadians(); } }

        /// <summary>
        /// Gets or sets the <see cref="Location"/> of the <see cref="Transform2D"/>
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        [Browsable(true)]
        [Category("Elements")]
        [Description("The " + nameof(Location) + " of the " + nameof(Transform2D) + ".")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        //[TypeConverter(typeof(Point2DConverter))]
        [RefreshProperties(RefreshProperties.All)]
        public Point2D Location { get { return new Point2D(X, Y); } set { (X, Y) = value; } }

        /// <summary>
        /// Gets or sets the <see cref="SkewY"/> vector of the <see cref="Transform2D"/>
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        [Browsable(true)]
        [Category("Elements")]
        [Description("The " + nameof(Skew) + " vector of the " + nameof(Transform2D) + ".")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        //[TypeConverter(typeof(Point2DConverter))]
        [RefreshProperties(RefreshProperties.All)]
        public Vector2D Skew { get { return new Vector2D(X, Y); } set { (SkewX, SkewY) = value; } }

        /// <summary>
        /// Gets or sets the <see cref="Scale"/> of the <see cref="Transform2D"/>
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        [Browsable(true)]
        [Category("Elements")]
        [Description("The " + nameof(Location) + " location of the " + nameof(Transform2D) + ".")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        //[TypeConverter(typeof(Point2DConverter))]
        [RefreshProperties(RefreshProperties.All)]
        public Size2D Scale { get { return new Size2D(X, Y); } set { (ScaleX, ScaleY) = value; } }
        #endregion Properties

        #region Operators

        /// <summary>
        /// Compares two <see cref="Transform2D"/> instances for exact equality.
        /// Note that double values can acquire error when operated upon, such that
        /// an exact comparison between two values which are logically equal may fail.
        /// Furthermore, using this equality operator, Double.NaN is not equal to itself.
        /// </summary>
        /// <returns>
        /// bool - true if the two <see cref="Transform2D"/> instances are exactly equal, false otherwise
        /// </returns>
        /// <param name='transform1'>The first <see cref="Transform2D"/> to compare</param>
        /// <param name='transform2'>The second <see cref="Transform2D"/> to compare</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Transform2D transform1, Transform2D transform2) => Equals(transform1, transform2);

        /// <summary>
        /// Compares two <see cref="Transform2D"/> instances for exact inequality.
        /// Note that double values can acquire error when operated upon, such that
        /// an exact comparison between two values which are logically equal may fail.
        /// Furthermore, using this equality operator, Double.NaN is not equal to itself.
        /// </summary>
        /// <returns>
        /// bool - true if the two <see cref="Transform2D"/> instances are exactly unequal, false otherwise
        /// </returns>
        /// <param name='transform1'>The first <see cref="Transform2D"/> to compare</param>
        /// <param name='transform2'>The second <see cref="Transform2D"/> to compare</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Transform2D transform1, Transform2D transform2) => !Equals(transform1, transform2);
        #endregion Operators

        #region Factories
        #endregion Factories

        #region Methods
        /// <summary>
        /// Compares two Vectors
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Compare(Transform2D a, Transform2D b) => Equals(a, b);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(Transform2D a, Transform2D b) => a.X == b.X & a.Y == b.Y & a.SkewX == b.SkewX & a.SkewY == b.SkewY & a.ScaleX == b.ScaleX & a.ScaleY == b.ScaleY;

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is Transform2D && Equals(this, (Transform2D)obj);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Transform2D value) => Equals(this, value);

        /// <summary>
        /// Get the hash code.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(X, Y, SkewX, SkewY, ScaleX, ScaleY);

        /// <summary>
        /// Creates a human-readable string that represents this <see cref="Transform2D"/>.
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => ToString("R" /* format string */, CultureInfo.InvariantCulture /* format provider */);

        /// <summary>
        /// Creates a string representation of this <see cref="Transform2D"/> struct based on the IFormatProvider
        /// passed in.  If the provider is null, the CurrentCulture is used.
        /// </summary>
        /// <param name="provider">The <see cref="CultureInfo"/> provider.</param>
        /// <returns>A string representation of this <see cref="Transform2D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(IFormatProvider provider) => ToString("R" /* format string */, provider);

        /// <summary>
        /// Creates a string representation of this <see cref="Transform2D"/> struct based on the format string
        /// and IFormatProvider passed in.
        /// If the provider is null, the CurrentCulture is used.
        /// See the documentation for IFormattable for more information.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="provider"></param>
        /// <returns>
        /// A string representation of this object.
        /// </returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider provider)
        {
            if (this == null) return nameof(Point2D);
            var sep = ((provider as CultureInfo) ?? CultureInfo.InvariantCulture).GetNumericListSeparator();
            return $"{nameof(Transform2D)}({nameof(X)}: {X.ToString(format, provider)}{sep} {nameof(Y)}: {Y.ToString(format, provider)}{sep} {nameof(SkewX)}: {SkewX.ToString(format, provider)}{sep} {nameof(SkewY)}: {SkewY.ToString(format, provider)}{sep} {nameof(ScaleX)}: {ScaleX.ToString(format, provider)}{sep} {nameof(ScaleY)}: {ScaleY.ToString(format, provider)})";
        }
        #endregion Methods
    }
}
