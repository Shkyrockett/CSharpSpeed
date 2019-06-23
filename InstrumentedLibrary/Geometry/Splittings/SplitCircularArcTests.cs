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
    public static class SplitCircularArcTests
    {
        /// <summary>
        /// The split.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="radius"></param>
        /// <param name="startAngle"></param>
        /// <param name="sweepAngle"></param>
        /// <param name="ts">The ts.</param>
        /// <returns>The <see cref="T:CircularArc[]"/>.</returns>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CircularArc2D[] SplitCircularArc(double x, double y, double radius, double startAngle, double sweepAngle, params double[] ts)
        {
            if (ts is null)
            {
                return new[] { new CircularArc2D(x, y, radius, startAngle, sweepAngle) };
            }

            var filtered = ts.Where(t => t >= 0d && t <= 1d).Distinct().OrderBy(t => t).ToList();
            var start = new CircularArc2D(x, y, radius, startAngle, sweepAngle);
            if (filtered.Count == 0)
            {
                return new[] { start };
            }

            var tLast = 0d;
            var list = new List<CircularArc2D>(filtered.Count + 1);
            foreach (var t in filtered)
            {
                var relT = 1d - ((1d - t) / (1d - tLast));
                tLast = t;
                var (A, B) = BisectCircularArcTests.BisectCircularArc(x, y, radius, startAngle, sweepAngle, relT);
                list.Add(A);
                start = B;
            }

            list.Add(start);
            return list.ToArray();
        }
    }
}
