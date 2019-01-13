using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using static System.Math;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The interpolate linear1d tests class.
    /// </summary>
    [DisplayName("Linear Interpolate Tests")]
    [Description("Find a point on a line.")]
    [Signature("public static double LinearInterpolate1D(double v1, double v2, double t)")]
    [SourceCodeLocationProvider]
    public static class InterpolateLinear1DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the linear interpolation point for a value between two 2D points.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(InterpolateLinear1DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 1d, 0.5d }, new TestCaseResults(description:"", trials:trials, expectedReturnValue:0.5d, epsilon:DoubleEpsilon) },
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
        public static double LinearInterpolate1D(double v1, double v2, double t)
            => LinearInterpolate1D_0(v1, v2, t);

        /// <summary>
        /// Precise method which guarantees v = v1 when t = 1.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://en.wikipedia.org/wiki/Linear_interpolation
        /// </acknowledgment>
        [DisplayName("Linear Interpolate 1")]
        [Description("Simple Linear Interpolation.")]
        [SourceCodeLocationProvider]
        [Acknowledgment("https://en.wikipedia.org/wiki/Linear_interpolation")]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double LinearInterpolate1D_0(
            double v1, double v2, double t)
            => ((1 - t) * v1) + (t * v2);

        /// <summary>
        /// Imprecise method which does not guarantee v = v1 when t = 1, due to floating-point arithmetic error.
        /// This form may be used when the hardware has a native Fused Multiply-Add instruction.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://en.wikipedia.org/wiki/Linear_interpolation
        /// </acknowledgment>
        [DisplayName("Linear Interpolate 2")]
        [Description("Simple Linear Interpolation.")]
        [Acknowledgment("https://en.wikipedia.org/wiki/Linear_interpolation")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double LinearInterpolate1D_1(
            double v1, double v2, double t)
            => v1 + (t * (v2 - v1));

        /// <summary>
        /// The linear interpolate1d 3.
        /// </summary>
        /// <param name="v1">The v1.</param>
        /// <param name="v2">The v2.</param>
        /// <param name="t">The t.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// https://en.wikipedia.org/wiki/Linear_interpolation
        /// </acknowledgment>
        [DisplayName("Linear Interpolate 3")]
        [Description("Simple Linear Interpolation.")]
        [Acknowledgment("https://en.wikipedia.org/wiki/Linear_interpolation")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double LinearInterpolate1D_2(
            double v1, double v2, double t)
            => (Abs(v1 - v2) < DoubleEpsilon) ? 0 : v1 - (1 / (v1 - v2) * t);
    }
}
