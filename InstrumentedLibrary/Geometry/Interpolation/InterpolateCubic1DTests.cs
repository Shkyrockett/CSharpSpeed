using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The interpolate cubic1d tests class.
    /// </summary>
    [DisplayName("Cubic Interpolate Tests")]
    [Description("Find a point on a Cubic curve.")]
    [Signature("public static double CubicInterpolate1D(double v0, double v1, double v2, double v3, double t)")]
    [SourceCodeLocationProvider]
    public static class InterpolateCubic1DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 1D cubic interpolation of a point.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(InterpolateLinear3DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 1d, 2d, 3d, 0.5d }, new TestCaseResults(description:"", trials:trials, expectedReturnValue:1.5d, epsilon:DoubleEpsilon) }
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
        /// The cubic interpolate1d.
        /// </summary>
        /// <param name="v0">The v0.</param>
        /// <param name="v1">The v1.</param>
        /// <param name="v2">The v2.</param>
        /// <param name="v3">The v3.</param>
        /// <param name="t">The t.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://paulbourke.net/miscellaneous/interpolation/
        /// </acknowledgment>
        [DisplayName("Cubic Interpolate 1")]
        [Description("Simple Cubic Interpolation.")]
        [Acknowledgment("http://paulbourke.net/miscellaneous/interpolation/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CubicInterpolate1D(double v0, double v1, double v2, double v3, double t)
        {
            var mu2 = t * t;
            var a0 = v3 - v2 - v0 + v1;
            var a1 = v0 - v1 - a0;
            var a2 = v2 - v0;
            var a3 = v1;

            return (a0 * t * mu2) + (a1 * mu2) + (a2 * t) + a3;
        }
    }
}
