using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The orientation struct.
    /// </summary>
    [DataContract, Serializable]
    [DebuggerDisplay("{ToString()}")]
    public struct Orientation3D
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Orientation3D"/> struct.
        /// </summary>
        /// <param name="orientation">The orientation.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Orientation3D(Orientation3D orientation)
            : this(orientation.Roll, orientation.Pitch, orientation.Yaw)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Orientation3D"/> struct from a tuple.
        /// </summary>
        /// <param name="tuple"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Orientation3D((double Roll, double Pitch, double Yaw) tuple)
            : this()
        {
            (Roll, Pitch, Yaw) = tuple;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Orientation3D"/> class.
        /// </summary>
        /// <param name="roll">The roll.</param>
        /// <param name="pitch">The pitch.</param>
        /// <param name="yaw">The yaw.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Orientation3D(double roll, double pitch, double yaw)
            : this()
        {
            Roll = roll;
            Pitch = pitch;
            Yaw = yaw;
        }
        #endregion Constructors

        #region Deconstructors
        /// <summary>
        /// Deconstruct this <see cref="Orientation3D"/> to a <see cref="ValueTuple{T1, T2, T3}"/>.
        /// </summary>
        /// <param name="roll">The roll.</param>
        /// <param name="pitch">The pitch.</param>
        /// <param name="yaw">The yaw.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Deconstructor(out double roll, out double pitch, out double yaw)
        {
            roll = Roll;
            pitch = Pitch;
            yaw = Yaw;
        }
        #endregion Deconstructors

        #region Properties
        /// <summary>
        /// Gets or sets the roll.
        /// </summary>
        [DataMember, XmlAttribute, SoapAttribute]
        public double Roll { get; set; }

        /// <summary>
        /// Gets or sets the pitch.
        /// </summary>
        [DataMember, XmlAttribute, SoapAttribute]
        public double Pitch { get; set; }

        /// <summary>
        /// Gets or sets the yaw.
        /// </summary>
        [DataMember, XmlAttribute, SoapAttribute]
        public double Yaw { get; set; }
        #endregion Properties

        #region Operators

        /// <summary>
        /// Compares two <see cref="Orientation3D"/> objects.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Orientation3D left, Orientation3D right) => Equals(left, right);

        /// <summary>
        /// Compares two <see cref="Orientation3D"/> objects.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Orientation3D left, Orientation3D right) => !Equals(left, right);

        /// <summary>
        /// Tuple to <see cref="Orientation3D"/> struct.
        /// </summary>
        /// <param name="tuple"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Orientation3D((double Roll, double Pitch, double Yaw) tuple) => new Orientation3D(tuple);
        #endregion Operators

        #region Public Methods
        /// <summary>
        /// Compares two <see cref="Orientation3D"/> objects.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Compare(Orientation3D a, Orientation3D b)
            => Equals(a, b);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(Orientation3D a, Orientation3D b) => (a.Roll == b.Roll) && (a.Pitch == b.Pitch) && (a.Yaw == b.Yaw);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is Orientation3D && Equals(this, (Orientation3D)obj);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Orientation3D value) => Equals(this, value);

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(Roll, Pitch, Yaw);

        /// <summary>
        /// Creates a string representation of this <see cref="Orientation3D"/> struct based on the current culture.
        /// </summary>
        /// <returns>A string representation of this object.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => ToString("R" /* format string */, CultureInfo.InvariantCulture /* format provider */);

        /// <summary>
        /// Creates a string representation of this <see cref="Orientation3D"/> struct based on the IFormatProvider
        /// passed in.  If the provider is null, the CurrentCulture is used.
        /// </summary>
        /// <param name="provider"></param>
        /// <returns>
        /// A string representation of this object.
        /// </returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(IFormatProvider provider) => ToString("R" /* format string */, provider);

        /// <summary>
        /// Creates a string representation of this <see cref="Orientation3D"/> struct based on the format string
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
            if (this == null) return nameof(Orientation3D);
            var s = ((provider as CultureInfo) ?? CultureInfo.InvariantCulture).GetNumericListSeparator();
            return $"{nameof(Orientation3D)}({nameof(Roll)}:{Roll.ToString(format, provider)}{s} {nameof(Pitch)}:{Pitch.ToString(format, provider)}{s} {nameof(Yaw)}:{Yaw.ToString(format, provider)})";
        }
        #endregion Public Methods
    }
}