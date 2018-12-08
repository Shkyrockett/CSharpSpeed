using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using static InstrumentedLibrary.Maths;
using static System.Math;
using System;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The cosine interpolate2d tests class.
    /// </summary>
    [DisplayName("Cosine Interpolate Tests")]
    [Description("Find a point on a Cosine curve.")]
    [Signature("public static double CosineInterpolate2D(double v0, double v1, double v2, double v3, double t)")]
    [SourceCodeLocationProvider]
    public static class CosineInterpolate2DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 2D Cosine interpolation point.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(CosineInterpolate2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 1d, 1d, 0.5d }, new TestCaseResults(description:"", trials:trials, expectedReturnValue: (0.49999999999999994d, 0.49999999999999994d), epsilon:DoubleEpsilon) },
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
        /// The cosine interpolate2d.
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
        [DisplayName("Cosine Interpolate 2D")]
        [Description("Cosine Interpolation.")]
        [Acknowledgment("http://paulbourke.net/miscellaneous/interpolation/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) CosineInterpolate2D(
            double x1, double y1,
            double x2, double y2,
            double t)
        {
            var mu2 = (1d - Cos(t * PI)) * 0.5d;
            return (
                (x1 * (1d - mu2)) + x2 * mu2,
                (y1 * (1d - mu2)) + y2 * mu2);
        }

        /// <summary>
        /// Function For cosine interpolated Line
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="index"></param>
        /// <returns>Returns the interpolated point of the index value.</returns>
        [DisplayName("Cosine Interpolate 2D")]
        [Description("Cosine Interpolation.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) Interpolate(
            double x1, double y1,
            double x2, double y2,
            double index)
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
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="index"></param>
        /// <returns></returns>
        [DisplayName("Cosine Interpolate 2D")]
        [Description("Cosine Interpolation.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) CosineInterpolate(
            double x1, double y1,
            double x2, double y2,
            double index)
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
