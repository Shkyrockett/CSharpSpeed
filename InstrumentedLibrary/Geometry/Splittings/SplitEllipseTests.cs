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
    public static class SplitEllipseTests
    {
        /// <summary>
        /// The split.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="rX"></param>
        /// <param name="rY"></param>
        /// <param name="angle"></param>
        /// <param name="ts">The ts.</param>
        /// <returns>The <see cref="T:EllipticalArc[]"/>.</returns>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static EllipticalArc2D[] Split(double x, double y, double rX, double rY, double angle, params double[] ts)
        {
            if (ts is null || ts.Length == 0)
            {
                return new[] { OpenEllipseTests.OpenEllipse(x, y, rX, rY, angle, 0d) };
            }

            var filtered = ts.Where(t => t >= 0d && t <= 1d).Distinct().OrderBy(t => t).ToArray();
            var arc = OpenEllipseTests.OpenEllipse(x, y, rX, rY, angle, filtered[0]);
            if (filtered.Length == 0)
            {
                return new[] { arc };
            }

            var tLast = 0d;
            var start = arc;
            var list = new List<EllipticalArc2D>(filtered.Length + 1);
            foreach (var t in filtered)
            {
                var relT = 1d - ((1d - t) / (1d - tLast));
                tLast = t;
                var (A, B) = BisectEllipticalArcTests.SplitEllipticalArc(arc.X, arc.Y, arc.RX, arc.RY, arc.Angle, arc.StartAngle, arc.SweepAngle, relT);
                list.Add(A);
                start = B;
            }

            list.Add(start);
            return list.ToArray();
        }
    }
}
