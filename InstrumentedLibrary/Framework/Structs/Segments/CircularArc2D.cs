using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [ComVisible(true)]
    [DataContract, Serializable]
    [DebuggerDisplay("{ToString()}")]
    public struct CircularArc2D
        : IShapeSegment, ICachableProperties
    {
        #region Implementations
        /// <summary>
        /// The empty.
        /// </summary>
        public static CircularArc2D Empty = new CircularArc2D(0d, 0d, 0d, 0d, Maths.Tau);
        private double x;
        private double y;
        private double radius;
        private double startAngle;
        private double sweepAngle;
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arc"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CircularArc2D(CircularArc2D arc)
            : this(arc.X, arc.Y, arc.Radius, arc.StartAngle, arc.SweepAngle)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="radius"></param>
        /// <param name="startAngle"></param>
        /// <param name="sweepAngle"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CircularArc2D(double x, double y, double radius, double startAngle, double sweepAngle)
            : this()
        {
            X = x;
            Y = y;
            Radius = radius;
            StartAngle = startAngle;
            SweepAngle = sweepAngle;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tuple"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CircularArc2D((double x, double y, double radius, double startAngle, double sweepAngle) tuple)
            : this(tuple.x, tuple.y, tuple.radius, tuple.startAngle, tuple.sweepAngle)
        { }
        #endregion

        #region Deconstructors
        /// <summary>
        /// Deconstruct this <see cref="CircularArc2D"/> to a <see cref="ValueTuple{T1, T2, T3, T4, T5}"/>.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Radius"></param>
        /// <param name="StartAngle"></param>
        /// <param name="SweepAngle"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out double X, out double Y, out double Radius, out double StartAngle, out double SweepAngle)
        {
            X = this.X;
            Y = this.Y;
            Radius = this.Radius;
            StartAngle = this.StartAngle;
            SweepAngle = this.StartAngle;
        }
        #endregion Deconstructors

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = nameof(X)), XmlAttribute(nameof(X)), SoapAttribute(nameof(X))]
        public double X { get { return x; } set { x = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = nameof(Y)), XmlAttribute(nameof(Y)), SoapAttribute(nameof(Y))]
        public double Y { get { return y; } set { y = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = nameof(Radius)), XmlAttribute(nameof(Radius)), SoapAttribute(nameof(Radius))]
        public double Radius { get { return radius; } set { radius = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = nameof(StartAngle)), XmlAttribute(nameof(StartAngle)), SoapAttribute(nameof(StartAngle))]
        public double StartAngle { get { return startAngle; } set { startAngle = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = nameof(SweepAngle)), XmlAttribute(nameof(SweepAngle)), SoapAttribute(nameof(SweepAngle))]
        public double SweepAngle { get { return sweepAngle; } set { sweepAngle = value; (this as ICachableProperties).ClearCache(); } }

        /// <summary>
        /// Property cache for commonly used properties that may take time to calculate.
        /// </summary>
        [Browsable(false)]
        [field: NonSerialized]
        [IgnoreDataMember, XmlIgnore, SoapIgnore]
        Dictionary<object, object> ICachableProperties.PropertyCache { get; set; }
        #endregion

        /// <summary>
        /// Creates a <see cref="string"/> representation of this <see cref="IShape"/> interface based on the current culture.
        /// </summary>
        /// <returns>A <see cref="string"/> representation of this instance of the <see cref="IShape"/> object.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => ToString("R" /* format string */, CultureInfo.InvariantCulture /* format provider */);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            //if (this is null)
            //{
            //    return nameof(CircularArc2D);
            //}

            var sep = ((formatProvider as CultureInfo) ?? CultureInfo.InvariantCulture).GetNumericListSeparator();
            return $"{nameof(CircularArc2D)}({nameof(X)}: {X.ToString(format, formatProvider)}{sep} {nameof(Y)}: {Y.ToString(format, formatProvider)}{sep} {nameof(Radius)}: {Radius.ToString(format, formatProvider)}{sep} {nameof(StartAngle)}: {StartAngle.ToString(format, formatProvider)}{sep} {nameof(SweepAngle)}: {SweepAngle.ToString(format, formatProvider)})";
        }
    }
}
