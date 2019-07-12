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
    [DisplayName("Split Line")]
    [Description("Split Line.")]
    [SourceCodeLocationProvider]
    public static class SplitLineTests
    {
        /// <summary>
        /// The polygon centroid test.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(SplitLineTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 1000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 1d, 0d, new double[] { 0.5d } }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static IShapeSegment[] SplitLine(double x, double y, double i, double j, params double[] ts)
            => Split1(x, y, i, j, ts);

        /// <summary>
        /// The split.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="ts">The ts.</param>
        /// <returns>The <see cref="Array"/>.</returns>
        [DisplayName("Split Line")]
        [Description("Split Line.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IShapeSegment[] Split1(double x, double y, double i, double j, params double[] ts)
        {
            if (ts is null)
            {
                return new IShapeSegment[] { new Line2D(x, y, i, j) };
            }

            var filtered = ts.Distinct().OrderBy(t => t).ToArray();
            if (filtered.Length == 0)
            {
                return new IShapeSegment[] { new Line2D(x, y, i, j) };
            }

            var n = filtered.Length;
            var shapes = new IShapeSegment[n + 1];
            var prev = InterpolateLinear2DTests.LinearInterpolate2D(filtered[0], x, y, x + i, y + j);
            shapes[0] = new Ray2D(prev, (-i, -j));

            for (var index = 1; index < n; index++)
            {
                var next = InterpolateLinear2DTests.LinearInterpolate2D(filtered[index], x, y, x + i, y + j);
                shapes[index] = new LineSegment2D(prev, next);
                prev = next;
            }

            shapes[^1] = new Ray2D(prev, (i, j));
            return shapes;
        }
    }
}
