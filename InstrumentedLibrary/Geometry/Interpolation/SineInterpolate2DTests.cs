using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using static System.Math;
using System;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The sine interpolate2d tests class.
    /// </summary>
    [DisplayName("Cosine Interpolate Tests")]
    [Description("Find a point on a Cosine curve.")]
    [SourceCodeLocationProvider]
    public static class SineInterpolate2DTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(SineInterpolate2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 1d, 1d, 0.5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (0.49999999999999994d, 0.49999999999999994d), epsilon: double.Epsilon) },
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
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y) Sine(double x1, double y1, double x2, double y2, double t)
            => InterpolateSine(x1, y1, x2, y2, t);

        /// <summary>
        /// The sine.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="t">The t.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
        /// <acknowledgment>
        /// http://paulbourke.net/miscellaneous/interpolation/
        /// </acknowledgment>
        [DisplayName("Sine Interpolate 2D")]
        [Description("Sine Interpolation.")]
        [Acknowledgment("http://paulbourke.net/miscellaneous/interpolation/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) Sine_(
            double x1, double y1,
            double x2, double y2,
            double t)
        {
            var mu2 = (1d - Sin(t * PI)) / 2d;
            return (x1 * (1d - mu2) + x2 * mu2, y1 * (1d - mu2) + y2 * mu2);
        }

        /// <summary>
        /// Function For sine interpolated Line
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="index"></param>
        /// <returns>Returns the interpolated point of the index value.</returns>
        [DisplayName("Sine Interpolate 2D")]
        [Description("Sine Interpolation.")]
        [Acknowledgment("http://paulbourke.net/miscellaneous/interpolation/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) InterpolateSine(
            double x1, double y1,
            double x2, double y2,
            double index)
        {
            var a = new Point2D(x1, y1);
            var b = new Point2D(x2, y2);
            //Single MU2 = (double)((1.0 - Cos(index * 180)) * 0.5);
            //return Y1 * (1.0 - MU2) + Y2 * MU2;
            var MU2 = (1d - Sin(index * 180d)) * 0.5d;
            var ret = a * (1d - MU2) + (b * MU2);
            return (ret.I, ret.J);
        }
    }
}
