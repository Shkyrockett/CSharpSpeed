using System;
using System.Collections.Generic;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public struct EllipticalArc2D
        : IShapeSegment
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="rX"></param>
        /// <param name="rY"></param>
        /// <param name="angle"></param>
        /// <param name="v"></param>
        /// <param name="startAngle"></param>
        /// <param name="sweepAngle"></param>
        public EllipticalArc2D(double x, double y, double rX, double rY, double angle, double startAngle, double sweepAngle)
        {
            X = x;
            this.Y = y;
            this.RX = rX;
            this.RY = rY;
            this.Angle = angle;
            this.StartAngle = startAngle;
            this.SweepAngle = sweepAngle;
        }

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
        public double RX { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double RY { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Angle { get; set; }

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
        public string ToString(string format, IFormatProvider formatProvider) => throw new NotImplementedException();
    }
}
