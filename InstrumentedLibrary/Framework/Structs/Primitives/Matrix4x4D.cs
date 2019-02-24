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
    /// The matrix4x4d struct.
    /// </summary>
    [DataContract, Serializable]
    [ComVisible(true)]
    public struct Matrix4x4D
    {
        /// <summary>
        /// An Empty <see cref="Matrix4x4D"/>.
        /// </summary>
        public static readonly Matrix4x4D Empty = new Matrix4x4D(
            0d, 0d, 0d, 0d,
            0d, 0d, 0d, 0d,
            0d, 0d, 0d, 0d,
            0d, 0d, 0d, 0d);

        /// <summary>
        /// An Identity <see cref="Matrix4x4D"/>.
        /// </summary>
        public static readonly Matrix4x4D Identity = new Matrix4x4D(
            1d, 0d, 0d, 0d,
            0d, 1d, 0d, 0d,
            0d, 0d, 1d, 0d,
            0d, 0d, 0d, 1d);

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix4x4D"/> class.
        /// </summary>
        /// <param name="m0x0"></param>
        /// <param name="m0x1"></param>
        /// <param name="m0x2"></param>
        /// <param name="m0x3"></param>
        /// <param name="m1x0"></param>
        /// <param name="m1x1"></param>
        /// <param name="m1x2"></param>
        /// <param name="m1x3"></param>
        /// <param name="m2x0"></param>
        /// <param name="m2x1"></param>
        /// <param name="m2x2"></param>
        /// <param name="m2x3"></param>
        /// <param name="m3x0"></param>
        /// <param name="m3x1"></param>
        /// <param name="m3x2"></param>
        /// <param name="m3x3"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Matrix4x4D(
            double m0x0, double m0x1, double m0x2, double m0x3,
            double m1x0, double m1x1, double m1x2, double m1x3,
            double m2x0, double m2x1, double m2x2, double m2x3,
            double m3x0, double m3x1, double m3x2, double m3x3)
            : this()
        {
            M0x0 = m0x0;
            M0x1 = m0x1;
            M0x2 = m0x2;
            M0x3 = m0x3;
            M1x0 = m1x0;
            M1x1 = m1x1;
            M1x2 = m1x2;
            M1x3 = m1x3;
            M2x0 = m2x0;
            M2x1 = m2x1;
            M2x2 = m2x2;
            M2x3 = m2x3;
            M3x0 = m3x0;
            M3x1 = m3x1;
            M3x2 = m3x2;
            M3x3 = m3x3;
        }

        /// <summary>
        /// Create a new Matrix from 2 Vector4D objects.
        /// </summary>
        /// <param name="xAxis"></param>
        /// <param name="yAxis"></param>
        /// <param name="zAxis"></param>
        /// <param name="wAxis"></param>
        public Matrix4x4D(Vector4D xAxis, Vector4D yAxis, Vector4D zAxis, Vector4D wAxis)
            : this(xAxis.I, xAxis.J, xAxis.K, xAxis.L,
                  yAxis.I, yAxis.J, yAxis.K, yAxis.L,
                  zAxis.I, zAxis.J, zAxis.K, zAxis.L,
                  wAxis.I, wAxis.J, wAxis.K, wAxis.L)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix4x4D"/> class.
        /// </summary>
        /// <param name="tuple">The tuple.</param>
        public Matrix4x4D((
            double m0x0, double m0x1, double m0x2, double m0x3,
            double m1x0, double m1x1, double m1x2, double m1x3,
            double m2x0, double m2x1, double m2x2, double m2x3,
            double m3x0, double m3x1, double m3x2, double m3x3) tuple)
            : this()
        {
            (M0x0, M0x1, M0x2, M0x3,
            M1x0, M1x1, M1x2, M1x3,
            M2x0, M2x1, M2x2, M2x3,
            M3x0, M3x1, M3x2, M3x3) = tuple;
        }

        /// <summary>
        /// Deconstruct this <see cref="Matrix2x2D"/> to a <see cref="ValueTuple{T1, T2, T3, T4, T5, T6, T7, T8}"/>.
        /// </summary>
        /// <param name="m0x0">The m0x0.</param>
        /// <param name="m0x1">The m0x1.</param>
        /// <param name="m0x2"></param>
        /// <param name="m0x3"></param>
        /// <param name="m1x0">The m1x0.</param>
        /// <param name="m1x1">The m1x1.</param>
        /// <param name="m1x2"></param>
        /// <param name="m1x3"></param>
        /// <param name="m2x0"></param>
        /// <param name="m2x1"></param>
        /// <param name="m2x2"></param>
        /// <param name="m2x3"></param>
        /// <param name="m3x0"></param>
        /// <param name="m3x1"></param>
        /// <param name="m3x2"></param>
        /// <param name="m3x3"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(
            out double m0x0, out double m0x1, out double m0x2, out double m0x3,
            out double m1x0, out double m1x1, out double m1x2, out double m1x3,
            out double m2x0, out double m2x1, out double m2x2, out double m2x3,
            out double m3x0, out double m3x1, out double m3x2, out double m3x3)
        {
            m0x0 = M0x0;
            m0x1 = M0x1;
            m0x2 = M0x2;
            m0x3 = M0x3;
            m1x0 = M1x0;
            m1x1 = M1x1;
            m1x2 = M1x2;
            m1x3 = M1x3;
            m2x0 = M2x0;
            m2x1 = M2x1;
            m2x2 = M2x2;
            m2x3 = M2x3;
            m3x0 = M2x0;
            m3x1 = M2x1;
            m3x2 = M2x2;
            m3x3 = M2x3;
        }

        /// <summary>
        /// Gets or sets the m0x0.
        /// </summary>
        public double M0x0 { get; set; }

        /// <summary>
        /// Gets or sets the m0x1.
        /// </summary>
        public double M0x1 { get; set; }

        /// <summary>
        /// Gets or sets the m0x2.
        /// </summary>
        public double M0x2 { get; set; }

        /// <summary>
        /// Gets or sets the m0x3.
        /// </summary>
        public double M0x3 { get; set; }

        /// <summary>
        /// Gets or sets the m1x0.
        /// </summary>
        public double M1x0 { get; set; }

        /// <summary>
        /// Gets or sets the m1x1.
        /// </summary>
        public double M1x1 { get; set; }

        /// <summary>
        /// Gets or sets the m1x2.
        /// </summary>
        public double M1x2 { get; set; }

        /// <summary>
        /// Gets or sets the m1x3.
        /// </summary>
        public double M1x3 { get; set; }

        /// <summary>
        /// Gets or sets the m2x0.
        /// </summary>
        public double M2x0 { get; set; }

        /// <summary>
        /// Gets or sets the m2x1.
        /// </summary>
        public double M2x1 { get; set; }

        /// <summary>
        /// Gets or sets the m2x2.
        /// </summary>
        public double M2x2 { get; set; }

        /// <summary>
        /// Gets or sets the m2x3.
        /// </summary>
        public double M2x3 { get; set; }

        /// <summary>
        /// Gets or sets the m3x0.
        /// </summary>
        public double M3x0 { get; set; }

        /// <summary>
        /// Gets or sets the m3x1.
        /// </summary>
        public double M3x1 { get; set; }

        /// <summary>
        /// Gets or sets the m3x2.
        /// </summary>
        public double M3x2 { get; set; }

        /// <summary>
        /// Gets or sets the m3x3.
        /// </summary>
        public double M3x3 { get; set; }

        /// <summary>
        /// Gets or sets the cx.
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        [Description("The First column of the " + nameof(Matrix4x4D))]
        public Vector4D Cx { get { return new Vector4D(M0x0, M1x0, M2x0, M3x0); } set { (M0x0, M1x0, M2x0, M3x0) = value; } }

        /// <summary>
        /// Gets or sets the cy.
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        [Description("The Second column of the " + nameof(Matrix4x4D))]
        public Vector4D Cy { get { return new Vector4D(M0x1, M1x1, M2x1, M3x1); } set { (M0x1, M1x1, M2x1, M3x1) = value; } }

        /// <summary>
        /// Gets or sets the cz.
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        [Description("The Third column of the " + nameof(Matrix4x4D))]
        public Vector4D Cz { get { return new Vector4D(M0x2, M1x2, M2x2, M3x2); } set { (M0x2, M1x2, M2x2, M3x2) = value; } }

        /// <summary>
        /// Gets or sets the cw.
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        [Description("The Fourth column of the " + nameof(Matrix4x4D))]
        public Vector4D Cw { get { return new Vector4D(M0x3, M1x3, M2x3, M3x3); } set { (M0x3, M1x3, M2x3, M3x3) = value; } }

        ///// <summary>
        ///// The X Row or row zero.
        ///// </summary>
        /// <summary>
        /// Gets or sets the rx.
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        [Description("The First row of the " + nameof(Matrix4x4D))]
        public Vector4D Rx { get { return new Vector4D(M0x0, M0x1, M0x2, M0x3); } set { (M0x0, M0x1, M0x2, M0x3) = value; } }

        ///// <summary>
        ///// The Y Row or row one.
        ///// </summary>
        /// <summary>
        /// Gets or sets the ry.
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        [Description("The Second row of the " + nameof(Matrix4x4D))]
        public Vector4D Ry { get { return new Vector4D(M1x0, M1x1, M1x2, M1x3); } set { (M1x0, M1x1, M1x2, M1x3) = value; } }

        ///// <summary>
        ///// The Z Row or row one.
        ///// </summary>
        /// <summary>
        /// Gets or sets the rz.
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        [Description("The Third row of the " + nameof(Matrix4x4D))]
        public Vector4D Rz { get { return new Vector4D(M2x0, M2x1, M2x2, M2x3); } set { (M2x0, M2x1, M2x2, M2x3) = value; } }

        ///// <summary>
        ///// The W Row or row one.
        ///// </summary>
        /// <summary>
        /// Gets or sets the rw.
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        [Description("The Fourth row of the " + nameof(Matrix4x4D))]
        public Vector4D Rw { get { return new Vector4D(M3x0, M3x1, M3x2, M3x3); } set { (M3x0, M3x1, M3x2, M3x3) = value; } }

        /// <summary>
        /// Compares two Matrix instances for exact equality.
        /// Note that double values can acquire error when operated upon, such that
        /// an exact comparison between two values which are logically equal may fail.
        /// Furthermore, using this equality operator, Double.NaN is not equal to itself.
        /// </summary>
        /// <returns>
        /// bool - true if the two Matrix instances are exactly equal, false otherwise
        /// </returns>
        /// <param name='matrix1'>The first Matrix to compare</param>
        /// <param name='matrix2'>The second Matrix to compare</param>
        [DebuggerStepThrough]
        public static bool operator ==(Matrix4x4D matrix1, Matrix4x4D matrix2)
            => Equals(matrix1, matrix2);

        /// <summary>
        /// Compares two Matrix instances for exact inequality.
        /// Note that double values can acquire error when operated upon, such that
        /// an exact comparison between two values which are logically equal may fail.
        /// Furthermore, using this equality operator, Double.NaN is not equal to itself.
        /// </summary>
        /// <returns>
        /// bool - true if the two Matrix instances are exactly unequal, false otherwise
        /// </returns>
        /// <param name='matrix1'>The first Matrix to compare</param>
        /// <param name='matrix2'>The second Matrix to compare</param>
        [DebuggerStepThrough]
        public static bool operator !=(Matrix4x4D matrix1, Matrix4x4D matrix2)
            => !Equals(matrix1, matrix2);

        /// <summary>
        /// Returns the HashCode for this Matrix
        /// </summary>
        /// <returns>
        /// int - the HashCode for this Matrix
        /// </returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => new {
            M0x0, M0x1, M0x2, M0x3,
            M1x0, M1x1, M1x2, M1x3,
            M2x0, M2x1, M2x2, M2x3,
            M3x0, M3x1, M3x2, M3x3 }.GetHashCode();

        /// <summary>
        /// Compares two <see cref="Matrix4x4D"/>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Compare(Matrix4x4D a, Matrix4x4D b) => Equals(a, b);

        /// <summary>
        /// Compares two <see cref="Matrix4x4D"/> instances for object equality.  In this equality
        /// Double.NaN is equal to itself, unlike in numeric equality.
        /// Note that double values can acquire error when operated upon, such that
        /// an exact comparison between two values which
        /// are logically equal may fail.
        /// </summary>
        /// <returns>
        /// bool - true if the two Matrix instances are exactly equal, false otherwise
        /// </returns>
        /// <param name='matrix1'>The first Matrix to compare</param>
        /// <param name='matrix2'>The second Matrix to compare</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(Matrix4x4D matrix1, Matrix4x4D matrix2)
            => matrix1.M0x0.Equals(matrix2.M0x0)
                && matrix1.M0x1.Equals(matrix2.M0x1)
                && matrix1.M0x2.Equals(matrix2.M0x2)
                && matrix1.M0x3.Equals(matrix2.M0x3)
                && matrix1.M1x0.Equals(matrix2.M1x0)
                && matrix1.M1x1.Equals(matrix2.M1x1)
                && matrix1.M1x2.Equals(matrix2.M1x2)
                && matrix1.M1x3.Equals(matrix2.M1x3)
                && matrix1.M2x0.Equals(matrix2.M2x0)
                && matrix1.M2x1.Equals(matrix2.M2x1)
                && matrix1.M2x2.Equals(matrix2.M2x2)
                && matrix1.M2x3.Equals(matrix2.M2x3)
                && matrix1.M3x0.Equals(matrix2.M3x0)
                && matrix1.M3x1.Equals(matrix2.M3x1)
                && matrix1.M3x2.Equals(matrix2.M3x2)
                && matrix1.M3x3.Equals(matrix2.M3x3);

        /// <summary>
        /// Equals - compares this <see cref="Matrix4x4D"/> with the passed in object.  In this equality
        /// Double.NaN is equal to itself, unlike in numeric equality.
        /// Note that double values can acquire error when operated upon, such that
        /// an exact comparison between two values which
        /// are logically equal may fail.
        /// </summary>
        /// <returns>
        /// bool - true if the object is an instance of <see cref="Matrix4x4D"/> and if it's equal to "this".
        /// </returns>
        /// <param name='obj'>The object to compare to "this"</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is Matrix4x4D && Equals(this, (Matrix4x4D)obj);

        /// <summary>
        /// Equals - compares this <see cref="Matrix4x4D"/> with the passed in object.  In this equality
        /// Double.NaN is equal to itself, unlike in numeric equality.
        /// Note that double values can acquire error when operated upon, such that
        /// an exact comparison between two values which
        /// are logically equal may fail.
        /// </summary>
        /// <returns>
        /// bool - true if "value" is equal to "this".
        /// </returns>
        /// <param name='value'>The <see cref="Matrix4x4D"/> to compare to "this"</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Matrix4x4D value) => Equals(this, value);

        /// <summary>
        /// Creates a string representation of this <see cref="Matrix3x2D"/> struct based on the current culture.
        /// </summary>
        /// <returns>
        /// A string representation of this <see cref="Matrix3x2D"/>.
        /// </returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => ToString("R" /* format string */, CultureInfo.InvariantCulture /* format provider */);

        /// <summary>
        /// Creates a string representation of this <see cref="Matrix3x2D"/> struct based on the IFormatProvider
        /// passed in.  If the provider is null, the CurrentCulture is used.
        /// </summary>
        /// <returns>
        /// A string representation of this <see cref="Matrix3x2D"/>.
        /// </returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(IFormatProvider provider) => ToString("R" /* format string */, provider);

        /// <summary>
        /// Creates a string representation of this <see cref="Matrix3x2D"/> struct based on the format string
        /// and IFormatProvider passed in.
        /// If the provider is null, the CurrentCulture is used.
        /// See the documentation for IFormattable for more information.
        /// </summary>
        /// <returns>
        /// A string representation of this <see cref="Matrix3x2D"/>.
        /// </returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider provider)
        {
            if (this == null) return nameof(Matrix4x4D);
            var s = ((provider as CultureInfo) ?? CultureInfo.InvariantCulture).GetNumericListSeparator();
            return $"{nameof(Matrix4x4D)}=[{nameof(M0x0)}:{M0x0.ToString(format, provider)}{s} {nameof(M0x1)}:{M0x1.ToString(format, provider)}{s} {nameof(M0x2)}:{M0x2.ToString(format, provider)}{s} {nameof(M0x3)}:{M0x3.ToString(format, provider)}{s} {nameof(M1x0)}:{M1x0.ToString(format, provider)}{s} {nameof(M1x1)}:{M1x1.ToString(format, provider)}{s} {nameof(M1x2)}:{M1x2.ToString(format, provider)}{s} {nameof(M1x3)}:{M1x3.ToString(format, provider)}{s} {nameof(M2x0)}:{M2x0.ToString(format, provider)}{s} {nameof(M2x1)}:{M2x1.ToString(format, provider)}{s} {nameof(M2x2)}:{M2x2.ToString(format, provider)}{s} {nameof(M2x3)}:{M2x3.ToString(format, provider)}{s} {nameof(M3x0)}:{M3x0.ToString(format, provider)}{s} {nameof(M3x1)}:{M3x1.ToString(format, provider)}{s} {nameof(M3x2)}:{M3x2.ToString(format, provider)}{s} {nameof(M3x3)}:{M3x3.ToString(format, provider)}]";
        }
    }
}