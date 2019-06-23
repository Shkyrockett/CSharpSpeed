using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public struct CircularArc2D
        : IShapeSegment
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tuple"></param>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CircularArc2D(CircularArc2D tuple)
            : this(tuple.X, tuple.Y, tuple.Radius, tuple.StartAngle, tuple.SweepAngle)
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

        /// <summary>
        /// 
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double StartAngle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double SweepAngle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider) => throw new NotImplementedException();
    }
}
