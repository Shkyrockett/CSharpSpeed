using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The functional interpolation tests class.
    /// </summary>
    [DisplayName("Functional Interpolation Tests")]
    [Description("Run interpolation of a function.")]
    [SourceCodeLocationProvider]
    public static class FunctionalInterpolationTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(FunctionalInterpolationTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { (Func<double, (double X, double Y)>)((i) => InterpolateCubic2DTests.CubicInterpolate2D(0d, 5d, 10d, 15d, 20d, 15d, 30d, 5d, i)), 100 }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:Tau, epsilon: double.Epsilon) },
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
        /// <param name="func"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static List<(double X, double Y)> Interpolate0to1(Func<double, (double X, double Y)> func, int count)
            => Interpolate0to1_(func, count);

        /// <summary>
        /// Retrieves a list of points interpolated from a function.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="count">The number of points desired.</param>
        /// <returns></returns>
        [DisplayName("The cubic bezier arc length")]
        [Description("The cubic bezier arc length.")]
        [Acknowledgment("http://steve.hollasch.net/cgindex/curves/cbezarclen.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<(double X, double Y)> Interpolate0to1_(Func<double, (double X, double Y)> func, int count)
        {
            return new List<(double X, double Y)>(from i in Enumerable.Range(0, count) select func(1d / count * i));
        }
    }
}
