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
    public static class RightBisectLineSegmentTests
    {
        /// <summary>
        /// The split.
        /// </summary>
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IShapeSegment RightBisectLineSegment(double aX, double aY, double bX, double bY, double t)
        {
            if (t <= 0d)
            {
                return new LineSegment2D(aX, aY, bX, bY);
            }

            if (t >= 1d)
            {
                return new Point2D(bX, bY);
            }

            var (cX, cY) = InterpolateLinear2DTests.LinearInterpolate2D(aX, aY, bX, bY, t);

            return new LineSegment2D(cX, cY, bX, bY);
        }
    }
}
