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
    public static class LeftBisectNBezierTests
    {
        /// <summary>
        /// Cut a <see cref="BezierSegment"/> into multiple fragments at the given t indices, using "De Casteljau" algorithm.
        /// The value at which to split the curve. Should be strictly inside ]0,1[ interval.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <param name="t">The t.</param>
        /// <returns>The <see cref="T:BezierSegment[]"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <acknowledgment>
        /// http://pomax.github.io/bezierinfo/#decasteljau
        /// https://github.com/superlloyd/Poly
        /// </acknowledgment>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D[] LeftBisectNBezier(Point2D[] points, double t)
        {
            if (t < 0d || t > 1d)
            {
                throw new ArgumentOutOfRangeException();
            }

            var bezier2 = new List<Point2D>();
            var bezier1 = new List<Point2D>();
            var lp = points.ToList();

            while (lp.Count > 0)
            {
                bezier2.Insert(0, lp.Last());
                bezier1.Add(lp.First());
                var next = new List<Point2D>(lp.Count - 1);
                for (var i = 0; i < lp.Count - 1; i++)
                {
                    var p0 = lp[i];
                    var p1 = lp[i + 1];
                    next.Add(new Point2D(((p0.X * (1d - t)) + (t * p1.X), (p0.Y * (1d - t)) + (t * p1.Y))));
                }

                lp = next;
            }

            return bezier1.ToArray();
        }
    }
}
