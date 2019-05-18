using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The interpolate quadratic bezier1d tests class.
    /// </summary>
    [DisplayName("Quadratic Bezier Interpolate 1D Tests")]
    [Description("Find a point on a 1D Quadratic Bezier curve.")]
    [SourceCodeLocationProvider]
    public static class InterpolateQuadraticBezier1DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 1D cubic interpolation of a point.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(InterpolateQuadraticBezier1DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 1d, 2d, 0.5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:1d, epsilon: double.Epsilon) },
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
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double QuadraticBezierInterpolate1D(double v0, double v1, double v2, double t)
            => QuadraticBezierInterpolate1D_0(v0, v1, v2, t);

        /// <summary>
        /// Three control point Bézier interpolation mu ranges from 0 to 1, start to end of the curve.
        /// </summary>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [DisplayName("Quadratic Bezier Interpolate 1")]
        [Description("Simple Quadratic Bezier Interpolation.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double QuadraticBezierInterpolate1D_0(
            double v0,
            double v1,
            double v2,
            double t)
        {
            var mu1 = 1 - t;
            var mu12 = mu1 * mu1;
            var mu2 = t * t;

            return (v0 * mu12) + (2 * v1 * mu1 * t) + (v2 * mu2);
        }

        /// <summary>
        /// Evaluate a point on a Bézier-curve. t goes from 0 to 1.0
        /// </summary>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://www.cubic.org/docs/bezier.htm
        /// </acknowledgment>
        [DisplayName("Quadratic Bezier Interpolate 2")]
        [Description("Simple Quadratic Bezier Interpolation.")]
        [Acknowledgment("http://www.cubic.org/docs/bezier.htm")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double QuadraticBezierInterpolate1D_1(
            double v0,
            double v1,
            double v2,
            double t)
        {
            // point between a and b
            var ab = InterpolateLinear1DTests.LinearInterpolate1D(v0, v1, t);

            // point between b and c
            var bc = InterpolateLinear1DTests.LinearInterpolate1D(v1, v2, t);

            // point on the bezier-curve
            return InterpolateLinear1DTests.LinearInterpolate1D(ab, bc, t);
        }
    }
}
