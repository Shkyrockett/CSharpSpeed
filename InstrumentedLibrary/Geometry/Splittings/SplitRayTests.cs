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
    public static class SplitRayTests
    {
        /// <summary>
        /// The split.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="ts">The ts.</param>
        /// <returns>The <see cref="T:Shape[]"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IShapeSegment[] SplitRay(double x, double y, double i, double j, params double[] ts)
        {
            if (ts is null)
            {
                return new IShapeSegment[] { new Ray2D(x, y, i, j) };
            }

            var filtered = ts.Where(t => t >= 0).Distinct().OrderBy(t => t).ToArray();
            if (filtered.Length == 0)
            {
                return new IShapeSegment[] { new Ray2D(x, y, i, j) };
            }

            var n = filtered.Length;
            var shapes = new IShapeSegment[n + 1];
            var prev = (x, y);
            for (var index = 0; i < n; i++)
            {
                var next = InterpolateLinear2DTests.LinearInterpolate2D(x, y, x + i, y + j, filtered[index]);
                shapes[index] = new LineSegment2D(prev, next);
                prev = next;
            }

            shapes[^1] = new Ray2D(prev, (i, j));
            return shapes;
        }
    }
}
