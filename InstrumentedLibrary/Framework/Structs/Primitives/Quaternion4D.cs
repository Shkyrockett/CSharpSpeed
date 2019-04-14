using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using static System.Math;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The <see cref="Quaternion4D"/> struct.
    /// </summary>
    [DataContract, Serializable]
    [ComVisible(true)]
    public struct Quaternion4D
        : IFormattable
    {
        /// <summary>
        /// Represents a <see cref="Quaternion4D"/> that has <see cref="X"/>, <see cref="Y"/>, <see cref="Z"/>, and <see cref="W"/> values set to zero.
        /// </summary>
        public static readonly Quaternion4D Empty = new Quaternion4D(0d, 0d, 0d, 0d);

        /// <summary>
        /// Represents a <see cref="Quaternion4D"/> that has <see cref="X"/>, <see cref="Y"/>, <see cref="Z"/>, and <see cref="W"/> values set to zero.
        /// </summary>
        public static readonly Quaternion4D Zero = new Quaternion4D(0d, 0d, 0d, 0d);

        /// <summary>
        /// Represents a <see cref="Quaternion4D"/> that has <see cref="X"/>, <see cref="Y"/>, <see cref="Z"/>, and <see cref="W"/> values set to NaN.
        /// </summary>
        public static readonly Quaternion4D NaN = new Quaternion4D(double.NaN, double.NaN, double.NaN, double.NaN);

        /// <summary>
        /// Represents a <see cref="Quaternion4D"/> that has <see cref="X"/> set to 0, <see cref="Y"/> set to 0, <see cref="Z"/> set to 0, and <see cref="W"/> set to 1.
        /// </summary>
        public static readonly Quaternion4D Identity = new Quaternion4D(0d, 0d, 0d, 1d);

        /// <summary>
        /// Initializes a new instance of the <see cref="Quaternion4D"/> class.
        /// </summary>
        /// <param name="tuple">The tuple.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Quaternion4D((double X, double Y, double Z, double W) tuple)
            : this()
        {
            (X, Y, Z, W) = tuple;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Quaternion4D"/> class.
        /// </summary>
        /// <param name="x">The <paramref name="x"/>.</param>
        /// <param name="y">The <paramref name="y"/>.</param>
        /// <param name="z">The <paramref name="z"/>.</param>
        /// <param name="w">The <paramref name="w"/>.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Quaternion4D(double x, double y, double z, double w)
            : this()
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Quaternion4D"/> class.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <param name="scalar">The scalar.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Quaternion4D(Vector3D vector, double scalar)
            : this(vector.I, vector.J, vector.K, scalar)
        { }

        /// <summary>
        /// Deconstruct this <see cref="Quaternion4D"/> to a <see cref="ValueTuple{T1, T2, T3, T4}"/>.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        /// <param name="w">The w.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out double x, out double y, out double z, out double w)
        {
            x = X;
            y = Y;
            z = Z;
            w = W;
        }

        /// <summary>
        /// Gets or sets the <see cref="X"/> value of this Quaternion. 
        /// </summary>
        [DataMember, XmlAttribute, SoapAttribute]
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Y"/> value of this Quaternion. 
        /// </summary>
        [DataMember, XmlAttribute, SoapAttribute]
        public double Y { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Z"/> value of this Quaternion. 
        /// </summary>
        [DataMember, XmlAttribute, SoapAttribute]
        public double Z { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="W"/> value of this Quaternion. 
        /// </summary>
        [DataMember, XmlAttribute, SoapAttribute]
        public double W { get; set; }

        /// <summary>
        /// Gets or sets the pitch.
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        public double Pitch
        {
            set
            {
                var euler = ToEulerAngles();
                FromEulerAngles(euler.Roll, value, euler.Yaw);
            }
            get
            {
                var test = (X * Y) + (Z * W);
                if (Abs(test) > 0.499d) // singularitY at north and south pole
                {
                    return 0d;
                }

                return Atan2((2d * X * W) - (2d * Y * Z), 1d - (2d * X * X) - (2d * Z * Z));
            }
        }

        /// <summary>
        /// Gets or sets the yaw.
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        public double Yaw
        {
            set
            {
                var euler = ToEulerAngles();
                FromEulerAngles(euler.Roll, euler.Pitch, value);
            }
            get
            {
                var test = (X * Y) + (Z * W);
                if (Abs(test) > 0.499d) // singularitY at north and south pole
                {
                    return Sign(test) * 2d * Atan2(X, W);
                }

                return Atan2((2d * Y * W) - (2d * X * Z), 1d - (2d * Y * Y) - (2d * Z * Z));
            }
        }

        /// <summary>
        /// Gets or sets the roll.
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        public double Roll
        {
            set
            {
                var euler = ToEulerAngles();
                FromEulerAngles(value, euler.Pitch, euler.Yaw);
            }
            get
            {
                var test = (X * Y) + (Z * W);
                if (Abs(test) > 0.499d) // singularitY at north and south pole
                {
                    return Sign(test) * HalfPi;
                }

                return Asin(2d * test);
            }
        }

        /// <summary>
        /// Local X-aXis portion of this rotation.
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        public Vector3D XAxis
        {
            get
            {
                //var fTX = 2.0f * X;
                var fTY = 2.0f * Y;
                var fTZ = 2.0f * Z;
                var fTWY = fTY * W;
                var fTWZ = fTZ * W;
                var fTXY = fTY * X;
                var fTXZ = fTZ * X;
                var fTYY = fTY * Y;
                var fTZZ = fTZ * Z;
                return new Vector3D(1.0d - (fTYY + fTZZ), fTXY + fTWZ, fTXZ - fTWY);
            }
        }

        /// <summary>
        /// Local Y-aXis portion of this rotation.
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        public Vector3D YAxis
        {
            get
            {
                var fTX = 2.0f * X;
                var fTY = 2.0f * Y;
                var fTZ = 2.0f * Z;
                var fTWX = fTX * W;
                var fTWZ = fTZ * W;
                var fTXX = fTX * X;
                var fTXY = fTY * X;
                var fTYZ = fTZ * Y;
                var fTZZ = fTZ * Z;
                return new Vector3D(fTXY - fTWZ, 1d - (fTXX + fTZZ), fTYZ + fTWX);
            }
        }

        /// <summary>
        /// Local Z-aXis portion of this rotation.
        /// </summary>
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        public Vector3D ZAxis
        {
            get
            {
                var fTX = 2.0f * X;
                var fTY = 2.0f * Y;
                var fTZ = 2.0f * Z;
                var fTWX = fTX * W;
                var fTWY = fTY * W;
                var fTXX = fTX * X;
                var fTXZ = fTZ * X;
                var fTYY = fTY * Y;
                var fTYZ = fTZ * Y;
                return new Vector3D(fTXZ + fTWY, fTYZ - fTWX, 1d - (fTXX + fTYY));
            }
        }

        /// <summary>
        /// Compares two <see cref="Quaternion4D"/> instances for exact equality.
        /// The result specifies whether the values of the <see cref="X"/>, <see cref="Y"/>, <see cref="Z"/>, and <see cref="W"/>
        /// values of the two <see cref="Quaternion4D"/> objects are equal.
        /// </summary>
        /// <param name="left">The first <see cref="Quaternion4D"/> to compare</param>
        /// <param name="right">The second <see cref="Quaternion4D"/> to compare</param>
        /// <returns>
        /// A boolean value indicating whether the two <see cref="Quaternion4D"/> instances are exactly equal.
        /// The return value is true if they are equal, false otherwise.
        /// </returns>
        /// <remarks>
        /// Note that double values can acquire error when operated upon, such that
        /// an exact comparison between two values which are logically equal may fail.
        /// Furthermore, using this equality operator, Double.NaN is not equal to itself.
        /// </remarks>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Quaternion4D left, Quaternion4D right) => Equals(left, right);

        /// <summary>
        /// Compares two <see cref="Quaternion4D"/> instances for exact inequality.
        /// The result specifies whether the values of the <see cref="X"/>, <see cref="Y"/>, <see cref="Z"/>, or <see cref="W"/>
        /// values of the two <see cref="Quaternion4D"/> objects are unequal.
        /// </summary>
        /// <param name="left">The first <see cref="Quaternion4D"/> to compare.</param>
        /// <param name="right">The second <see cref="Quaternion4D"/> to compare.</param>
        /// <returns>
        /// A boolean value indicating whether the two <see cref="Quaternion4D"/> instances are exactly unequal.
        /// The return value is true if they are unequal, false otherwise.
        /// </returns>
        /// <remarks>
        /// Note that double values can acquire error when operated upon, such that
        /// an exact comparison between two values which are logically equal may fail.
        /// Furthermore, using this equality operator, Double.NaN is not equal to itself.
        /// </remarks>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Quaternion4D left, Quaternion4D right) => !Equals(left, right);

        /// <summary>
        /// Converts the specified <see cref="Quaternion4D"/> structure to a <see cref="ValueTuple{T1, T2, T3, T4}"/> structure.
        /// </summary>
        /// <param name="quaternion">The <see cref="Quaternion4D"/> to be converted.</param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator (double X, double Y, double Z, double W) (Quaternion4D quaternion) => (quaternion.X, quaternion.Y, quaternion.Z, quaternion.W);

        /// <summary>
        /// Tuple to <see cref="Quaternion4D"/>.
        /// </summary>
        /// <param name="tuple"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Quaternion4D((double X, double Y, double Z, double W) tuple) => new Quaternion4D(tuple);

        /// <summary>
        /// set this quaternion's values from the rotation matrix built from the Axi.
        /// </summary>
        /// <param name="XAxis"></param>
        /// <param name="YAxis"></param>
        /// <param name="ZAxis"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion4D FromAxis(Vector3D XAxis, Vector3D YAxis, Vector3D ZAxis)
            => FromRotationMatrix(new Matrix3x3D(
                XAxis.I, YAxis.I, ZAxis.I,
                XAxis.J, YAxis.J, ZAxis.J,
                XAxis.K, YAxis.K, ZAxis.K));

        /// <summary>
        /// The from axis angle.
        /// </summary>
        /// <param name="axis">The axis.</param>
        /// <param name="angle">The angle.</param>
        /// <returns>The <see cref="Quaternion4D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion4D FromAxisAngle(Vector3D axis, double angle)
        {
            var halfAngle = angle * 0.5d;
            var sin = Sin(halfAngle);
            var cos = Cos(halfAngle);
            return new Quaternion4D(axis.I * sin, axis.J * sin, axis.K * sin, cos);

        }

        /// <summary>
        /// The from rotation matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>The <see cref="Quaternion4D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion4D FromRotationMatrix(Matrix3x3D matrix)
        {
            var trace = matrix.M0x0 + matrix.M1x1 + matrix.M2x2;
            var quaternion = new Quaternion4D();
            if (trace > 0d)
            {
                var root = Sqrt(trace + 1d);
                quaternion.W = root * 0.5d;
                root = 0.5d / root;
                quaternion.X = (matrix.M1x2 - matrix.M2x1) * root;
                quaternion.Y = (matrix.M2x0 - matrix.M0x2) * root;
                quaternion.Z = (matrix.M0x1 - matrix.M1x0) * root;
                return quaternion;
            }
            if ((matrix.M0x0 >= matrix.M1x1) && (matrix.M0x0 >= matrix.M2x2))
            {
                var root = Sqrt(1f + matrix.M0x0 - matrix.M1x1 - matrix.M2x2);
                var w = 0.5d / root;
                quaternion.X = 0.5d * root;
                quaternion.Y = (matrix.M0x1 + matrix.M1x0) * w;
                quaternion.Z = (matrix.M0x2 + matrix.M2x0) * w;
                quaternion.W = (matrix.M1x2 - matrix.M2x1) * w;
                return quaternion;
            }
            if (matrix.M1x1 > matrix.M2x2)
            {
                var root = Sqrt(1f + matrix.M1x1 - matrix.M0x0 - matrix.M2x2);
                var w = 0.5d / root;
                quaternion.X = (matrix.M1x0 + matrix.M0x1) * w;
                quaternion.Y = 0.5d * root;
                quaternion.Z = (matrix.M2x1 + matrix.M1x2) * w;
                quaternion.W = (matrix.M2x0 - matrix.M0x2) * w;
                return quaternion;
            }
            var sqrt = Sqrt(1f + matrix.M2x2 - matrix.M0x0 - matrix.M1x1);
            var ww = 0.5d / sqrt;
            quaternion.X = (matrix.M2x0 + matrix.M0x2) * ww;
            quaternion.Y = (matrix.M2x1 + matrix.M1x2) * ww;
            quaternion.Z = 0.5d * sqrt;
            quaternion.W = (matrix.M0x1 - matrix.M1x0) * ww;
            return quaternion;
        }

        /// <summary>
        /// The from Euler angles.
        /// </summary>
        /// <param name="roll">The roll.</param>
        /// <param name="pitch">The pitch.</param>
        /// <param name="yaw">The yaw.</param>
        /// <returns>The <see cref="Quaternion4D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion4D FromEulerAngles(double roll, double pitch, double yaw)
        {
            var halfRoll = roll * 0.5d;
            var rollSin = Sin(halfRoll);
            var rollCos = Cos(halfRoll);
            var halfPitch = pitch * 0.5d;
            var pitchSin = Sin(halfPitch);
            var pitchCos = Cos(halfPitch);
            var halfYaw = yaw * 0.5d;
            var yawSin = Sin(halfYaw);
            var yawCos = Cos(halfYaw);
            return new Quaternion4D(
                (yawCos * pitchSin * rollCos) + (yawSin * pitchCos * rollSin),
                (yawSin * pitchCos * rollCos) - (yawCos * pitchSin * rollSin),
                (yawCos * pitchCos * rollSin) - (yawSin * pitchSin * rollCos),
                (yawCos * pitchCos * rollCos) + (yawSin * pitchSin * rollSin));
        }

        /// <summary>
        /// The quaternion to Euler angles.
        /// </summary>
        /// <returns>The <see cref="Orientation3D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Orientation3D ToEulerAngles()
        {
            var test = (X * Y) + (Z * W);
            var quat = (Yaw: 0d, Roll: 0d, Pitch: 0d);
            if (test > 0.499d)
            {
                // singularitY at north pole
                quat.Yaw = 2d * Atan2(X, W);
                quat.Roll = HalfPi;
                quat.Pitch = 0d;
            }
            else if (test < -0.499d)
            {
                // singularitY at south pole
                quat.Yaw = -2d * Atan2(X, W);
                quat.Roll = -HalfPi;
                quat.Pitch = 0d;
            }
            else
            {
                var sqX = X * X;
                var sqY = Y * Y;
                var sqZ = Z * Z;
                quat.Yaw = Atan2((2d * Y * W) - (2d * X * Z), 1d - (2d * sqY) - (2d * sqZ));
                quat.Roll = Asin(2d * test);
                quat.Pitch = Atan2((2d * X * W) - (2d * Y * Z), 1d - (2d * sqX) - (2d * sqZ));
            }

            if (quat.Pitch <= Epsilon)
            {
                quat.Pitch = 0d;
            }

            if (quat.Yaw <= Epsilon)
            {
                quat.Yaw = 0d;
            }

            if (quat.Roll <= Epsilon)
            {
                quat.Roll = 0d;
            }

            return quat;
        }

        /// <summary>
        /// Compares two <see cref="Quaternion4D"/> structs.
        /// </summary>
        /// <param name="a">The object to compare.</param>
        /// <param name="b">The object to compare against.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Compare(Quaternion4D a, Quaternion4D b) => Equals(a, b);

        /// <summary>
        /// Compares two <see cref="Quaternion4D"/> instances for exact equality.
        /// </summary>
        /// <param name="a">The first <see cref="Quaternion4D"/> to compare.</param>
        /// <param name="b">The second <see cref="Quaternion4D"/> to compare.</param>
        /// <returns>
        /// A boolean value indicating whether the two <see cref="Quaternion4D"/> instances are exactly unequal.
        /// The return value is true if they are unequal, false otherwise.
        /// </returns>
        /// <remarks>
        /// Note that double values can acquire error when operated upon, such that
        /// an exact comparison between two values which are logically equal may fail.
        /// Furthermore, using this equality operator, Double.NaN is not equal to itself.
        /// </remarks>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(Quaternion4D a, Quaternion4D b) => (a.X == b.X) && (a.Y == b.Y) && (a.Z == b.Z) && (a.W == b.W);

        /// <summary>
        /// Compares this <see cref="Quaternion4D"/> with the passed in object.
        /// </summary>
        /// <param name="obj">The object to compare to this <see cref="Quaternion4D"/> to.</param>
        /// <returns>
        /// A boolean value indicating whether the two <see cref="Quaternion4D"/> instances are exactly unequal.
        /// The return value is true if they are unequal, false otherwise.
        /// </returns>
        /// <remarks>
        /// Note that double values can acquire error when operated upon, such that
        /// an exact comparison between two values which are logically equal may fail.
        /// In this equality Double.NaN is equal to itself, unlike in numeric equality.
        /// </remarks>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is Quaternion4D && Equals(this, (Quaternion4D)obj);

        /// <summary>
        /// Compares this <see cref="Quaternion4D"/> with the passed in <see cref="Quaternion4D"/>.
        /// </summary>
        /// <param name="value">The <see cref="Quaternion4D"/> to compare to this <see cref="Quaternion4D"/> to.</param>
        /// <returns>
        /// A boolean value indicating whether the two <see cref="Quaternion4D"/> instances are exactly unequal.
        /// The return value is true if they are unequal, false otherwise.
        /// </returns>
        /// <remarks>
        /// Note that double values can acquire error when operated upon, such that
        /// an exact comparison between two values which are logically equal may fail.
        /// In this equality Double.NaN is equal to itself, unlike in numeric equality.
        /// </remarks>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Quaternion4D value) => Equals(this, value);

        /// <summary>
        /// Get the hash code.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(X, Y, Z, W);

        /// <summary>
        /// Creates a human-readable string that represents this <see cref="Quaternion4D"/> struct.
        /// </summary>
        /// <returns>A string representation of this <see cref="Quaternion4D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => ToString("R" /* format string */, CultureInfo.InvariantCulture /* format provider */);

        /// <summary>
        /// Creates a string representation of this <see cref="Quaternion4D"/> struct based on the IFormatProvider
        /// passed in.  If the provider is null, the CurrentCulture is used.
        /// </summary>
        /// <param name="provider">The <see cref="CultureInfo"/> provider.</param>
        /// <returns>A string representation of this <see cref="Quaternion4D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(IFormatProvider provider) => ToString("R" /* format string */, provider);

        /// <summary>
        /// Creates a string representation of this <see cref="Quaternion4D"/> class based on the format string
        /// and IFormatProvider passed in.
        /// If the provider is null, the CurrentCulture is used.
        /// See the documentation for IFormattable for more information.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="provider">The <see cref="CultureInfo"/> provider.</param>
        /// <returns>A string representation of this <see cref="Quaternion4D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider provider)
        {
            if (this == null) return nameof(Quaternion4D);
            var s = ((provider as CultureInfo) ?? CultureInfo.InvariantCulture).GetNumericListSeparator();
            return $"{nameof(Quaternion4D)}=[{nameof(X)}:{X.ToString(format, provider)}{s} {nameof(Y)}:{Y.ToString(format, provider)}{s} {nameof(Z)}:{Z.ToString(format, provider)}{s} {nameof(W)}:{W.ToString(format, provider)}]";
        }
    }
}
