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
    [DisplayName("Split Circle")]
    [Description("Split Circle.")]
    [SourceCodeLocationProvider]
    public static class SplitCircleTests
    {
        /// <summary>
        /// The polygon centroid test.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(SplitCircleTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 1000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 5d, 5d, 5d, new double[] { 0.5d } }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="radius"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static CircularArc2D[] SplitCircle(double x, double y, double radius, params double[] ts)
            => Split(x, y, radius, ts);

        /// <summary>
        /// The split.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="radius"></param>
        /// <param name="ts">The ts.</param>
        /// <returns>The <see cref="Array"/>.</returns>
        [DisplayName("Split Circle")]
        [Description("Split Circle.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
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
