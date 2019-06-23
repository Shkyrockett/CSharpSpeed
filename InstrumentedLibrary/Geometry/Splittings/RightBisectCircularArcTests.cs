using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class RightBisectCircularArcTests
    {
        /// <summary>
        /// The split.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="radius"></param>
        /// <param name="startAngle"></param>
        /// <param name="sweepAngle"></param>
        /// <param name="t"></param>
        /// <returns>The <see cref="T:CircularArc[]"/>.</returns>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CircularArc2D RightBisectCircularArc(double x, double y, double radius, double startAngle, double sweepAngle, double t)
        {
            if (t < 0d || t > 1d)
            {
                throw new ArgumentOutOfRangeException();
            }

            return new CircularArc2D(x, y, radius, startAngle + (sweepAngle * t), sweepAngle - (sweepAngle * t));
        }
    }
}
