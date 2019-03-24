using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Center of Triangle Tests")]
    [Description("Find the center of a Triangle.")]
    [SourceCodeLocationProvider]
    public static class TriangleCenterTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(RectangleCenterTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 2d, 0d, 1d, 2d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (1d, 0.6180339887498948d), epsilon: double.Epsilon) },
            };

            var results = new List<SpeedTester>();
            foreach (var method in ReflectionHelper.ListStaticMethodsWithAttribute(MethodBase.GetCurrentMethod().DeclaringType, typeof(SourceCodeLocationProviderAttribute)))
            {
                var methodDescription = ((DescriptionAttribute)method.GetCustomAttribute(typeof(DescriptionAttribute)))?.Description;
                results.Add(new SpeedTester(method, methodDescription, tests));
            }
            return results;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ax"></param>
        /// <param name="ay"></param>
        /// <param name="bx"></param>
        /// <param name="by"></param>
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double x, double y) TriangleCenter(double ax, double ay, double bx, double by, double cx, double cy)
            => TriangleCenter1(ax, ay, bx, by, cx, cy);

        /// <summary>
        /// Compute the center of triangle a-b-c.
        /// </summary>
        /// <param name="ax">The ax.</param>
        /// <param name="ay">The ay.</param>
        /// <param name="bx">The bx.</param>
        /// <param name="by">The by.</param>
        /// <param name="cx">The cx.</param>
        /// <param name="cy">The cy.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
        /// <acknowledgment>
        /// https://www.khanacademy.org/computer-programming/c/5567955982876672
        /// </acknowledgment>
        [DisplayName("Center of Triangle")]
        [Description("Find the center of a Triangle.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double x, double y) TriangleCenter1(double ax, double ay, double bx, double by, double cx, double cy)
        {
            var a = Distance2DTests.Distance2D(bx, by, cx, cy);
            var b = Distance2DTests.Distance2D(ax, ay, cx, cy);
            var c = Distance2DTests.Distance2D(bx, by, ax, ay);
            var p = a + b + c;
            // This will throw if the center is the origin...
            return (
                x: ((a * ax) + (b * bx) + (c * cx)) / p,
                y: ((a * ay) + (b * by) + (c * cy)) / p
            );
        }
    }
}
