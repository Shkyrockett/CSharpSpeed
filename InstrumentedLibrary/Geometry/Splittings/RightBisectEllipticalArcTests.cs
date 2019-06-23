using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class RightBisectEllipticalArcTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="rX"></param>
        /// <param name="rY"></param>
        /// <param name="angle"></param>
        /// <param name="startAngle"></param>
        /// <param name="sweepAngle"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static EllipticalArc2D RightSplitEllipticalArc(double x, double y, double rX, double rY, double angle, double startAngle, double sweepAngle, double t)
        {
            if (t < 0d || t > 1d)
            {
                throw new ArgumentOutOfRangeException();
            }

            return new EllipticalArc2D(x, y, rX, rY, angle, startAngle, sweepAngle * t);
        }
    }
}
