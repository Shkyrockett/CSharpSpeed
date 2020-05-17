using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Split Any Number Bezier")]
    [Description("Split Any Number Bezier.")]
    [SourceCodeLocationProvider]
    public static class SplitNBezierTests
    {
        /// <summary>
        /// The polygon centroid test.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(SplitNBezierTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 1000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { new Point2D[] { (0d, 0d), (0d, 5d), (5d, 5d), (5d, 0d) }, new double[] { 0.5d } }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
            };

            var results = new List<SpeedTester>();
            foreach (var method in HelperExtensions.ListStaticMethodsWithAttribute(MethodBase.GetCurrentMethod().DeclaringType, typeof(SourceCodeLocationProviderAttribute)))
            {
                var methodDescription = ((DescriptionAttribute)method.GetCustomAttribute(typeof(DescriptionAttribute)))?.Description;
                results.Add(new SpeedTester(method, methodDescription, tests));
            }
            return results;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Point2D[][] SplitBezier(Point2D[] points, params double[] ts)
            => SplitBezier1(points, ts);

        /// <summary>
        /// The split.
        /// </summary>
        /// <param name="points">The Bézier.</param>
        /// <param name="ts">The ts.</param>
        /// <returns>The <see cref="Array"/>.</returns>
        [DisplayName("Split Any Number Bezier")]
        [Description("Split Any Number Bezier.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D[][] SplitBezier1(Point2D[] points, params double[] ts)
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
