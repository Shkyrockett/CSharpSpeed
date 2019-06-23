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
    public static class SplitCircleTests
    {
        /// <summary>
        /// The split.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="radius"></param>
        /// <param name="ts">The ts.</param>
        /// <returns>The <see cref="T:CircularArc[]"/>.</returns>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CircularArc2D[] Split(double x, double y, double radius, params double[] ts)
        {
            if (ts is null)
            {
                return new[] { OpenCircleTests.OpenCircle(x, y, radius, 0d) };
            }

            var filtered = ts.Where(t => t >= 0d && t <= 1d).Distinct().OrderBy(t => t).ToList();
            var arc = OpenCircleTests.OpenCircle(x, y, radius, filtered[0]);
            if (filtered.Count == 0)
            {
                return new[] { arc };
            }

            var tLast = 0d;
            var start = arc;
            var list = new List<CircularArc2D>(filtered.Count + 1);
            foreach (var t in filtered)
            {
                var relT = 1d - ((1d - t) / (1d - tLast));
                tLast = t;
                var (A, B) = BisectCircularArcTests.BisectCircularArc(arc.X, arc.Y, arc.Radius, arc.StartAngle, arc.SweepAngle, relT);
                list.Add(A);
                start = B;
            }

            list.Add(start);
            return list.ToArray();
        }
    }
}
