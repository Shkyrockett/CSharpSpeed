using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The distance2d tests class.
    /// </summary>
    [DisplayName("2D Distance Tests")]
    [Description("Find the distance between two points.")]
    [SourceCodeLocationProvider]
    public static class Distance2DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the distance between two 2D points.
        /// </summary>
        /// <returns></returns>
        [DisplayName(nameof(Distance2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 15000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 1d, 0d }, new TestCaseResults(description: "Horizontal Line.", trials: trials, expectedReturnValue:1d, epsilon: double.Epsilon) },
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
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double Distance2D(double ax, double ay, double bx, double by)
            => Distance2Dv1(ax, ay, bx, by);

        /// <summary>
        /// Distance between two 2D points.
        /// </summary>
        /// <param name="x1">First X component.</param>
        /// <param name="y1">First Y component.</param>
        /// <param name="x2">Second X component.</param>
        /// <param name="y2">Second Y component.</param>
        /// <returns>The distance between two points.</returns>
        [DisplayName("Distance Method 1")]
        [Description("This is the simple, most obvious implementation of the distance method.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Distance2Dv1(
            double x1, double y1,
            double x2, double y2)
        {
            return Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
        }

        /// <summary>
        /// The distance2d 1.
        /// </summary>
        /// <param name="ax">The ax.</param>
        /// <param name="ay">The ay.</param>
        /// <param name="bx">The ab.</param>
        /// <param name="by">The by.</param>
        /// <returns>The <see cref="double"/>.</returns>
        [DisplayName("Distance Method 2")]
        [Description("This method calls another distance method using Tuples. The allocation of the Tuples, and calling the other method seems to add a little more time.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Distance2Dv2(
            double ax, double ay,
            double bx, double by)
        {
            return Distance2Point2DTests.Distance2D((ax, ay), (bx, by));
        }

        /// <summary>
        /// Distance between two 2D points.
        /// </summary>
        /// <param name="x1">First X component.</param>
        /// <param name="y1">First Y component.</param>
        /// <param name="x2">Second X component.</param>
        /// <param name="y2">Second Y component.</param>
        /// <returns>The distance between two points.</returns>
        [DisplayName("Distance Method 3")]
        [Description("This method uses two delta local variables. The allocation of the variables seems to make the method slightly slower.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Distance2Dv3(
            double x1, double y1,
            double x2, double y2)
        {
            var x = x2 - x1;
            var y = y2 - y1;
            return Sqrt((x * x) + (y * y));
        }
    }
}
