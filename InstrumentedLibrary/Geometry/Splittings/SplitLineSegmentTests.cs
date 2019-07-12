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
    [DisplayName("Split Line Segment")]
    [Description("Split Line Segment.")]
    [SourceCodeLocationProvider]
    public static class SplitLineSegmentTests
    {
        /// <summary>
        /// The polygon centroid test.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(SplitLineSegmentTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 1000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 5d, 5d, new double[] { 0.5d } }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static LineSegment2D[] Split(double aX, double aY, double bX, double bY, params double[] ts)
            => Split1(aX, aY, bX, bY, ts);

        /// <summary>
        /// The split.
        /// </summary>
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="ts">The ts.</param>
        /// <returns>The <see cref="Array"/>.</returns>
        [DisplayName("Split Line Segment")]
        [Description("Split Line Segment.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static LineSegment2D[] Split1(double aX, double aY, double bX, double bY, params double[] ts)
        {
            if (ts is null)
            {
                return new[] { new LineSegment2D(aX, aY, bX, bY) };
            }

            var filtered = ts.Where(t => t >= 0d && t <= 1d).Distinct().OrderBy(t => t).ToArray();
            var start = new LineSegment2D(aX, aY, bX, bY);
            if (filtered.Length == 0)
            {
                return new[] { start };
            }

            var list = new LineSegment2D[filtered.Length + 1];
            var previous = start.A;
            for (var i = 0; i < filtered.Length; i++)
            {
                var next = InterpolateLinear2DTests.LinearInterpolate2D(filtered[i], aX, aY, bX, bY);
                list[i] = new LineSegment2D(previous, next);
                previous = next;
            }

            list[^1] = new LineSegment2D(previous, (bX, bY));
            return list;
        }
    }
}
