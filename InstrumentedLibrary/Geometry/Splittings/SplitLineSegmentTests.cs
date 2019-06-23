using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class SplitLineSegmentTests
    {
        /// <summary>
        /// The split.
        /// </summary>
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="ts">The ts.</param>
        /// <returns>The <see cref="T:LineSegment[]"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static LineSegment2D[] Split(double aX, double aY, double bX, double bY, params double[] ts)
        {
            if (ts is null)
            {
                return new[] { new LineSegment2D(aX, aY, bX, bY) };
            }

            var filtered = ts.Where(t => t >= 0d && t <= 1d).Distinct().OrderBy(t => t).ToArray();
            var start = new LineSegment2D(aX, aY, bX, bY);
            if (filtered.Length == 0)
            {
                return new[] { start };
            }

            var list = new LineSegment2D[filtered.Length + 1];
            var previous = start.A;
            for (var i = 0; i < filtered.Length; i++)
            {
                var next = InterpolateLinear2DTests.LinearInterpolate2D(aX, aY, bX, bY, filtered[i]);
                list[i] = new LineSegment2D(previous, next);
                previous = next;
            }

            list[^1] = new LineSegment2D(previous, (bX, bY));
            return list;
        }
    }
}
