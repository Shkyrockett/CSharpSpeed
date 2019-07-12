using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Split Circular Arc")]
    [Description("Split Circular Arc.")]
    [SourceCodeLocationProvider]
    public static class SplitCircularArcTests
    {
        /// <summary>
        /// The polygon centroid test.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(SplitCircularArcTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 1000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 5d, 5d, 5d, 0d, Math.PI, new double[] { 0.5d } }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        /// <param name="startAngle"></param>
        /// <param name="sweepAngle"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static CircularArc2D[] SplitCircularArc(double x, double y, double radius, double startAngle, double sweepAngle, params double[] ts)
            => SplitCircularArc1(x, y, radius, startAngle, sweepAngle, ts);

        /// <summary>
        /// The split.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="radius"></param>
        /// <param name="startAngle"></param>
        /// <param name="sweepAngle"></param>
        /// <param name="ts">The ts.</param>
        /// <returns>The <see cref="Array"/>.</returns>
        [DisplayName("Split Circular Arc")]
        [Description("Split Circular Arc.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CircularArc2D[] SplitCircularArc1(double x, double y, double radius, double startAngle, double sweepAngle, params double[] ts)
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
