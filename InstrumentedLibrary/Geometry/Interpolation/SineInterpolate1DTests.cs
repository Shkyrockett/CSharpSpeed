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
    /// The sine interpolate1d tests class.
    /// </summary>
    [DisplayName("Sine Interpolate Tests")]
    [Description("Find a point on a Sine curve.")]
    [SourceCodeLocationProvider]
    public static class SineInterpolate1DTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(SineInterpolate1DTests))]
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
        public static double Sine(double v1, double v2, double t)
            => Sine_(v1, v2, t);

        /// <summary>
        /// The sine.
        /// </summary>
        /// <param name="v1">The v1.</param>
        /// <param name="v2">The v2.</param>
        /// <param name="t">The t.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://paulbourke.net/miscellaneous/interpolation/
        /// </acknowledgment>
        [DisplayName("Sine Interpolate 1D")]
        [Description("Sine Interpolation.")]
        [Acknowledgment("http://paulbourke.net/miscellaneous/interpolation/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sine_(
            double v1,
            double v2,
            double t)
        {
            var mu2 = (1d - Sin(t * PI)) / 2d;
            return v1 * (1d - mu2) + v2 * mu2;
        }
    }
}
