using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The cosine interpolate2d tests class.
    /// </summary>
    [DisplayName("Cosine Interpolate Tests")]
    [Description("Find a point on a Cosine curve.")]
    [SourceCodeLocationProvider]
    public static class CosineInterpolate2DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 2D Cosine interpolation point.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(CosineInterpolate2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0.5d, 0d, 0d, 1d, 1d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (0.49999999999999994d, 0.49999999999999994d), epsilon: double.Epsilon) },
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
        /// <param name="t"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y) CosineInterpolate2D(double t, double x1, double y1, double x2, double y2)
            => CosineInterpolate2D1(t, x1, y1, x2, y2);

        /// <summary>
        /// The cosine interpolate2d.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
        /// <acknowledgment>
        /// http://paulbourke.net/miscellaneous/interpolation/
        /// </acknowledgment>
        [DisplayName("Cosine Interpolate 2D")]
        [Description("Cosine Interpolation.")]
        [Acknowledgment("http://paulbourke.net/miscellaneous/interpolation/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) CosineInterpolate2D1(double t, double x1, double y1, double x2, double y2)
        {
            var mu2 = (1d - Cos(t * PI)) * 0.5d;
            return (
                (x1 * (1d - mu2)) + (x2 * mu2),
                (y1 * (1d - mu2)) + (y2 * mu2));
        }

        /// <summary>
        /// Function For cosine interpolated Line
        /// </summary>
        /// <param name="index"></param>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <returns>Returns the interpolated point of the index value.</returns>
        [DisplayName("Cosine Interpolate 2D")]
        [Description("Cosine Interpolation.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) Interpolate(double index, double x1, double y1, double x2, double y2)
        {
            var a = new Point2D(x1, y1);
            var b = new Point2D(x2, y2);
            //var mu = (1d - Cos(index * 180d)) * 0.5d;
            //return Y1 * (1d - mu) + Y2 * mu;
            var mu = (1d - Cos(index * PI)) * 0.5d;
            var ret = (a * (1d - mu)) + (b * mu);
            return (ret.I, ret.J);
        }

        /// <summary>
        /// Function For cosine interpolated Line
        /// </summary>
        /// <param name="index"></param>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <returns></returns>
        [DisplayName("Cosine Interpolate 2D")]
        [Description("Cosine Interpolation.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) CosineInterpolate(double index, double x1, double y1, double x2, double y2)
        {
            //var mu = (1d - Cos(index * 180d)) * 0.5d;
            var mu = (1d - Cos(index * PI)) * 0.5d;
            return new Point2D(
                (x1 * (1d - mu)) + (x2 * mu),
                (y1 * (1d - mu)) + (y2 * mu)
                );
        }
    }
}
