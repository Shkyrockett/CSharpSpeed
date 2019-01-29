using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The interpolate cubic2d tests class.
    /// </summary>
    [DisplayName("Cubic Interpolate 2D Tests")]
    [Description("Find a point on a 2D Cubic curve.")]
    [SourceCodeLocationProvider]
    public static class InterpolateCubic2DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 2D cubic interpolation of a point.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(InterpolateCubic2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 1d, 2d, 3d, 4d, 5d, 6d, 7d, 0.5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:(3d, 4d), epsilon: double.Epsilon) },
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
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y) CubicInterpolate2D(double x0, double y0, double x1, double y1, double x2, double y2, double x3, double y3, double t)
            => CubicInterpolate2D_(x0, y0, x1, y1, x2, y2, x3, y3, t);

        /// <summary>
        /// The cubic interpolate2d.
        /// </summary>
        /// <param name="x0">The x0.</param>
        /// <param name="y0">The y0.</param>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="x3">The x3.</param>
        /// <param name="y3">The y3.</param>
        /// <param name="t">The t.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
        /// <acknowledgment>
        /// http://paulbourke.net/miscellaneous/interpolation/
        /// </acknowledgment>
        [DisplayName("Cubic Interpolate 1")]
        [Description("Simple Cubic Interpolation.")]
        [Acknowledgment("http://paulbourke.net/miscellaneous/interpolation/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) CubicInterpolate2D_(
            double x0, double y0,
            double x1, double y1,
            double x2, double y2,
            double x3, double y3,
            double t)
        {
            var mu2 = t * t;

            var aX0 = x3 - x2 - x0 + x1;
            var aY0 = y3 - y2 - y0 + y1;
            var aX1 = x0 - x1 - aX0;
            var aY1 = y0 - y1 - aY0;
            var aX2 = x2 - x0;
            var aY2 = y2 - y0;

            return (
                (aX0 * t * mu2) + (aX1 * mu2) + (aX2 * t) + x1,
                (aY0 * t * mu2) + (aY1 * mu2) + (aY2 * t) + y1);
        }
    }
}
