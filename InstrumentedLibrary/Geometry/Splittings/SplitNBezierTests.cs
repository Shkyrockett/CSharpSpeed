using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Linq;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class SplitNBezierTests
    {
        /// <summary>
        /// The split.
        /// </summary>
        /// <param name="points">The Bézier.</param>
        /// <param name="ts">The ts.</param>
        /// <returns>The <see cref="T:BezierSegment[]"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D[][] SplitBezier(Point2D[] points, params double[] ts)
        {
            if (ts is null)
            {
                return new[] { points };
            }

            var filtered = ts.Where(t => t >= 0d && t <= 1d).Distinct().OrderBy(t => t).ToList();

            if (filtered.Count == 0)
            {
                return new[] { points };
            }

            var tLast = 0d;
            var prev = points;
            var list = new List<Point2D[]>(filtered.Count + 1);
            foreach (var t in filtered)
            {
                var relT = (1d - t) / (1d - tLast);
                tLast = t;
                var (A, B) = BisectNBezierTests.BisectNBezier(prev, relT);
                list.Add(A);
                prev = B;
            }

            list.Add(prev);
            return list.ToArray();
        }
    }
}
