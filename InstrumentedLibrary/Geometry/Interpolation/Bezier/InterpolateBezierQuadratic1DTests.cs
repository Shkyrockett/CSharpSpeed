using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The interpolate quadratic bezier1d tests class.
    /// </summary>
    [DisplayName("Quadratic Bezier Interpolate 1D Tests")]
    [Description("Find a point on a 1D Quadratic Bezier curve.")]
    [SourceCodeLocationProvider]
    public static class InterpolateBezierQuadratic1DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 1D cubic interpolation of a point.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(InterpolateBezierQuadratic1DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0.5d, 0d, 1d, 2d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:1d, epsilon: double.Epsilon) },
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
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double QuadraticBezierInterpolate1D(double t, double v0, double v1, double v2)
            => QuadraticBezierInterpolate1D_0(t, v0, v1, v2);

        /// <summary>
        /// Three control point Bézier interpolation mu ranges from 0 to 1, start to end of the curve.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        [DisplayName("Quadratic Bezier Interpolate 1")]
        [Description("Simple Quadratic Bezier Interpolation.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double QuadraticBezierInterpolate1D_0(double t, double v0, double v1, double v2)
        {
            var mu1 = 1d - t;
            var mu12 = mu1 * mu1;
            var mu2 = t * t;

            return (v0 * mu12) + (2 * v1 * mu1 * t) + (v2 * mu2);
        }

        /// <summary>
        /// Evaluate a point on a Bézier-curve. t goes from 0 to 1.0
        /// </summary>
        /// <param name="t"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
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
        public static double QuadraticBezierInterpolate1D_1(double t, double v0, double v1, double v2)
        {
            // point between a and b
            var ab = InterpolateLinear1DTests.LinearInterpolate1D(t, v0, v1);

            // point between b and c
            var bc = InterpolateLinear1DTests.LinearInterpolate1D(t, v1, v2);

            // point on the bezier-curve
            return InterpolateLinear1DTests.LinearInterpolate1D(t, ab, bc);
        }

        /// <summary>
        /// Three control point Bézier interpolation mu ranges from 0 to 1, start to end of the curve.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        [DisplayName("Quadratic Bezier Interpolate 1")]
        [Description("Simple Quadratic Bezier Interpolation.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double QuadraticBezierInterpolate1D_2(double t, double v0, double v1, double v2)
        {
            return (v0 * ((1d - t) * (1d - t))) + (2 * v1 * (1d - t) * t) + (v2 * (t * t));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://blog.demofox.org/2015/07/05/the-de-casteljeau-algorithm-for-evaluating-bezier-curves/
        /// </acknowledgment>
        [DisplayName("Quadratic Bezier Interpolate 2")]
        [Description("Simple Quadratic Bezier Interpolation.")]
        [Acknowledgment("https://blog.demofox.org/2015/07/05/the-de-casteljeau-algorithm-for-evaluating-bezier-curves/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double BezierQuadratic(double t, double A, double B, double C)
        {
            var AB = InterpolateLinear1DTests.BezierLinear(t, A, B);
            var BC = InterpolateLinear1DTests.BezierLinear(t, B, C);
            return InterpolateLinear1DTests.BezierLinear(t, AB, BC);
        }
    }
}
