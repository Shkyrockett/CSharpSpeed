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
    public static class SplitQuadraticBezierTests
    {
        /// <summary>
        /// The split.
        /// </summary>
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <param name="ts">The ts.</param>
        /// <returns>The <see cref="T:BezierSegment[]"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static QuadraticBezier2D[] Split(double aX, double aY, double bX, double bY, double cX, double cY, params double[] ts)
        {
            if (ts is null)
            {
                return new[] { new QuadraticBezier2D(aX, aY, bX, bY, cX, cY) };
            }

            var filtered = ts.Where(t => t >= 0d && t <= 1d).Distinct().OrderBy(t => t).ToList();
            var start = new QuadraticBezier2D(aX, aY, bX, bY, cX, cY);
            if (filtered.Count == 0)
            {
                return new[] { start };
            }

            var tLast = 0d;
            var list = new List<QuadraticBezier2D>(filtered.Count + 1);
            foreach (var t in filtered)
            {
                var relT = (1d - t) / (1d - tLast);
                tLast = t;
                var (A, B) = BisectQuadraticBezierTests.BisectQuadraticBezier(start.A.X, start.A.Y, start.B.X, start.B.Y, start.C.X, start.C.Y, relT);
                list.Add(A);
                start = B;
            }

            list.Add(start);
            return list.ToArray();
        }
    }
}
