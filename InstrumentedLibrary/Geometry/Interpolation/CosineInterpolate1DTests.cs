using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The cosine interpolate1d tests class.
    /// </summary>
    [DisplayName("Cosine Interpolate Tests")]
    [Description("Find a point on a Cosine curve.")]
    [SourceCodeLocationProvider]
    public static class CosineInterpolate1DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 1D Cosine interpolation point.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(CosineInterpolate1DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 1d, 0.5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: 0.49999999999999994d, epsilon: double.Epsilon) },
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
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double CosineInterpolate1D(double v1, double v2, double t)
            => CosineInterpolate1D_(v1, v2, t);

        /// <summary>
        /// The cosine interpolate1d.
        /// </summary>
        /// <param name="v1">The v1.</param>
        /// <param name="v2">The v2.</param>
        /// <param name="t">The t.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://paulbourke.net/miscellaneous/interpolation/
        /// </acknowledgment>
        [DisplayName("Cosine Interpolate 1D")]
        [Description("Cosine Interpolation.")]
        [Acknowledgment("http://paulbourke.net/miscellaneous/interpolation/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CosineInterpolate1D_(double v1, double v2, double t)
        {
            var mu2 = (1d - Cos(t * PI)) / 2d;
            return v1 * (1d - mu2) + v2 * mu2;
        }
    }
}
