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
    /// The cosine interpolate3d tests class.
    /// </summary>
    [DisplayName("Cosine Interpolate Tests")]
    [Description("Find a point on a Cosine curve.")]
    [SourceCodeLocationProvider]
    public static class CosineInterpolate3DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 3D Cosine interpolation point.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(CosineInterpolate3DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 0d, 1d, 1d, 1d, 0.5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:(0.49999999999999994d, 0.49999999999999994d, 0.49999999999999994d), epsilon: double.Epsilon) },
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
        /// <param name="z1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="z2"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y, double Z) CosineInterpolate3D(double x1, double y1, double z1, double x2, double y2, double z2, double t)
            => CosineInterpolate3D_(x1, y1, z1, x2, y2, z2, t);

        /// <summary>
        /// The cosine interpolate3d.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="z1">The z1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="z2">The z2.</param>
        /// <param name="t">The t.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <acknowledgment>
        /// http://paulbourke.net/miscellaneous/interpolation/
        /// </acknowledgment>
        [DisplayName("Cosine Interpolate 3D")]
        [Description("Cosine Interpolation.")]
        [Acknowledgment("http://paulbourke.net/miscellaneous/interpolation/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) CosineInterpolate3D_(
            double x1, double y1, double z1,
            double x2, double y2, double z2,
            double t)
        {
            var mu2 = (1d - Cos(t * PI)) / 2d;
            return (
                x1 * (1d - mu2) + x2 * mu2,
                y1 * (1d - mu2) + y2 * mu2,
                z1 * (1d - mu2) + z2 * mu2);
        }
    }
}
