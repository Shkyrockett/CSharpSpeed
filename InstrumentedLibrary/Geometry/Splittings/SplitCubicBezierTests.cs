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
    public static class SplitCubicBezierTests
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
        /// <param name="dX"></param>
        /// <param name="dY"></param>
        /// <param name="ts">The ts.</param>
        /// <returns>The <see cref="T:BezierSegment[]"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CubicBezier2D[] Split(double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY, params double[] ts)
        {
            if (ts is null)
            {
                return new[] { new CubicBezier2D(aX, aY, bX, bY, cX, cY, dX, dY) };
            }

            var filtered = ts.Where(t => t >= 0d && t <= 1d).Distinct().OrderBy(t => t).ToList();
            var prev = new CubicBezier2D(aX, aY, bX, bY, cX, cY, dX, dY);
            if (filtered.Count == 0)
            {
                return new[] { prev };
            }

            var tLast = 0d;
            var list = new List<CubicBezier2D>(filtered.Count + 1);
            foreach (var t in filtered)
            {
                var relT = (1d - t) / (1d - tLast);
                tLast = t;
                var (A, B) = BisectCubicBezierTests.BisectCubicBezier(prev.A.X, prev.A.Y, prev.B.X, prev.B.Y, prev.C.X, prev.C.Y, prev.D.X, prev.D.Y, relT);
                list.Add(A);
                prev = B;
            }

            list.Add(prev);
            return list.ToArray();
        }
    }
}
