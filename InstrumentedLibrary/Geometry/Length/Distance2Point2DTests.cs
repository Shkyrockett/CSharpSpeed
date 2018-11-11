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
    [DisplayName("2 Point 2D Distance Tests")]
    [Description("Find the distance between two points.")]
    [Signature("public static double Distance2D(double x1, double y1, double x2, double y2)")]
    [SourceCodeLocationProvider]
    public static class Distance2Point2DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the distance between two 2D points.
        /// </summary>
        /// <returns></returns>
        [DisplayName(nameof(Distance2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { (0d, 0d), (1d, 0d) }, new TestCaseResults("Horizontal Line.", trials, 1d, double.Epsilon) }
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
        /// Distance between two 2D points.
        /// </summary>
        /// <param name="a">First component.</param>
        /// <param name="b">Second component.</param>
        /// <returns>The distance between two points.</returns>
        [DisplayName("Distance Method 1")]
        [Description("Find the distance between two points.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Distance2D_1(
            (double X, double Y) a,
            (double X, double Y) b)
        {
            return Sqrt(((b.X - a.X) * (b.X - a.X)) + ((b.Y - a.Y) * (b.X - a.Y)));
        }

        /// <summary>
        /// The distance.
        /// </summary>
        /// <param name="a">The point1.</param>
        /// <param name="b">The point2.</param>
        /// <returns>The <see cref="double"/>.</returns>
        [DisplayName("Distance Method 1")]
        [Description("Find the distance between two points.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Distance(
            (double X, double Y) a,
            (double X, double Y) b)
        {
            var dx = a.X - b.X;
            var dy = a.Y - b.Y;
            return Sqrt((dx * dx) + (dy * dy));
        }
    }
}
