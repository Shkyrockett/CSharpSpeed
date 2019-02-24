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
    /// The <see cref="Matrix2x2D"/> struct.
    /// </summary>
    [DataContract, Serializable]
    [ComVisible(true)]
    public struct Matrix2x2D
    {
        /// <summary>
        /// An Empty <see cref="Matrix2x2D"/>.
        /// </summary>
        public static readonly Matrix2x2D Empty = new Matrix2x2D(
            0d, 0d,
            0d, 0d);

        /// <summary>
        /// An Identity <see cref="Matrix2x2D"/>.
        /// </summary>
        public static readonly Matrix2x2D Identity = new Matrix2x2D(
            1d, 0d,
            0d, 1d);

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix2x2D"/> class.
        /// </summary>
        /// <param name="m0x0"></param>
        /// <param name="m0x1"></param>
        /// <param name="m1x0"></param>
        /// <param name="m1x1"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Matrix2x2D(double m0x0, double m0x1, double m1x0, double m1x1)
            : this()
        {
            M0x0 = m0x0;
            M0x1 = m0x1;
            M1x0 = m1x0;
            M1x1 = m1x1;
        }

        /// <summary>
        /// Create a new Matrix from 2 Vertex2 objects.
        /// </summary>
        /// <param name="xAxis"></param>
        /// <param name="yAxis"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Matrix2x2D(Vector2D xAxis, Vector2D yAxis)
            : this(xAxis.I, xAxis.J, yAxis.I, yAxis.J)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix2x2D"/> class.
        /// </summary>
        /// <param name="tuple">The tuple.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Matrix2x2D((
            double M1x1, double M1x2,
            double M2x1, double M2x2) tuple)
            : this()
        {
            (M0x0, M0x1, M1x0, M1x1) = tuple;
        }

        /// <summary>
        /// Deconstruct this <see cref="Matrix2x2D"/> to a <see cref="ValueTuple{T1, T2, T3, T4}"/>.
        /// </summary>
        /// <param name="m0x0">The m0x0.</param>
        /// <param name="m0x1">The m0x1.</param>
        /// <param name="m1x0">The m1x0.</param>
        /// <param name="m1x1">The m1x1.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(
            out double m0x0, out double m0x1,
            out double m1x0, out double m1x1)
        {
            m0x0 = M0x0;
            m0x1 = M0x1;
            m1x0 = M1x0;
            m1x1 = M1x1;
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
        /// Gets or sets the m1x0.
        /// </summary>
        public double M1x0 { get; set; }

        /// <summary>
        /// Gets or sets the m1x1.
        /// </summary>
        public double M1x1 { get; set; }

        /// <summary>
        /// Gets or sets the cx.
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        [Description("The First column of the " + nameof(Matrix2x2D))]
        public Vector2D Cx { get { return new Vector2D(M0x0, M1x0); } set { (M0x0, M1x0) = value; } }

        /// <summary>
        /// Gets or sets the cy.
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        [Description("The Second column of the " + nameof(Matrix2x2D))]
        public Vector2D Cy { get { return new Vector2D(M0x1, M1x1); } set { (M0x1, M1x1) = value; } }

        /// <summary>
        /// Gets or sets the rx.
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        [Description("The First row of the " + nameof(Matrix2x2D))]
        public Vector2D Rx { get { return new Vector2D(M0x0, M0x1); } set { (M0x0, M0x1) = value; } }

        /// <summary>
        /// Gets or sets the ry.
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        [Description("The Second row of the " + nameof(Matrix2x2D))]
        public Vector2D Ry { get { return new Vector2D(M1x0, M1x1); } set { (M1x0, M1x1) = value; } }

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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Matrix2x2D matrix1, Matrix2x2D matrix2) => Equals(matrix1, matrix2);

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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Matrix2x2D matrix1, Matrix2x2D matrix2) => !Equals(matrix1, matrix2);

        /// <summary>
        /// Returns the HashCode for this <see cref="Matrix2x2D"/>
        /// </summary>
        /// <returns>
        /// The <see cref="int"/> HashCode for this <see cref="Matrix2x2D"/>.
        /// </returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(M0x0, M0x1, M1x0, M1x1);

        /// <summary>
        /// Compares two Matrix2x3D
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Compare(Matrix2x2D a, Matrix2x2D b) => Equals(a, b);

        /// <summary>
        /// Compares two Matrix instances for object equality.  In this equality
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
        public static bool Equals(Matrix2x2D matrix1, Matrix2x2D matrix2)
            => matrix1.M0x0.Equals(matrix2.M0x0)
                   && matrix1.M0x1.Equals(matrix2.M0x1)
                   && matrix1.M1x0.Equals(matrix2.M1x0)
                   && matrix1.M1x1.Equals(matrix2.M1x1);

        /// <summary>
        /// Equals - compares this Matrix with the passed in object.  In this equality
        /// Double.NaN is equal to itself, unlike in numeric equality.
        /// Note that double values can acquire error when operated upon, such that
        /// an exact comparison between two values which
        /// are logically equal may fail.
        /// </summary>
        /// <returns>
        /// bool - true if the object is an instance of Matrix and if it's equal to "this".
        /// </returns>
        /// <param name='obj'>The object to compare to "this"</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is Matrix2x2D && Equals(this, (Matrix2x2D)obj);

        /// <summary>
        /// Equals - compares this <see cref="Matrix2x2D"/> with the passed in object.  In this equality
        /// Double.NaN is equal to itself, unlike in numeric equality.
        /// Note that double values can acquire error when operated upon, such that
        /// an exact comparison between two values which
        /// are logically equal may fail.
        /// </summary>
        /// <returns>
        /// bool - true if "value" is equal to "this".
        /// </returns>
        /// <param name='value'>The Matrix to compare to "this"</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Matrix2x2D value) => Equals(this, value);

        /// <summary>
        /// Creates a string representation of this <see cref="Matrix2x2D"/> struct based on the current culture.
        /// </summary>
        /// <returns>
        /// A string representation of this object.
        /// </returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => ToString("R" /* format string */, CultureInfo.InvariantCulture /* format provider */);

        /// <summary>
        /// Creates a string representation of this <see cref="Matrix2x2D"/> struct based on the IFormatProvider
        /// passed in.  If the provider is null, the CurrentCulture is used.
        /// </summary>
        /// <returns>
        /// A string representation of this object.
        /// </returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(IFormatProvider provider) => ToString("R" /* format string */, provider);

        /// <summary>
        /// Creates a string representation of this <see cref="Matrix2x2D"/> struct based on the format string
        /// and IFormatProvider passed in.
        /// If the provider is null, the CurrentCulture is used.
        /// See the documentation for IFormattable for more information.
        /// </summary>
        /// <returns>
        /// A string representation of this object.
        /// </returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider provider)
        {
            if (this == null) return nameof(Matrix4x4D);
            var s = ((provider as CultureInfo) ?? CultureInfo.InvariantCulture).GetNumericListSeparator();
            return $"{nameof(Matrix2x2D)}=[{nameof(M0x0)}:{M0x0.ToString(format, provider)}{s} {nameof(M0x1)}:{M0x1.ToString(format, provider)}{s} {nameof(M1x0)}:{M1x0.ToString(format, provider)}{s} {nameof(M1x1)}:{M1x1.ToString(format, provider)}]";
        }
    }
}