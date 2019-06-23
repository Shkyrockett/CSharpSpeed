using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The interpolate cubic bezier1d tests class.
    /// </summary>
    [DisplayName("Cubic Bezier Interpolate 1D Tests")]
    [Description("Find a point on a 1D Cubic Bezier curve.")]
    [SourceCodeLocationProvider]
    public static class InterpolateBezierCubic1DTests
    {
        /// <summary>
        /// The interpolate cubic bezier1d test.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(InterpolateBezierCubic1DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 1d, 2d, 3d, 0.5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:1.5d, epsilon: double.Epsilon) },
                { new object[] { 0d, 3d, 6d, 7d, 0.5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:4.25d, epsilon: double.Epsilon) },
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
        /// <param name="v3"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double CubicBezier(double v0, double v1, double v2, double v3, double t)
            => CubicBezier_(v0, v1, v2, v3, t);

        /// <summary>
        /// The cubic bezier.
        /// </summary>
        /// <param name="v0">The v0.</param>
        /// <param name="v1">The v1.</param>
        /// <param name="v2">The v2.</param>
        /// <param name="v3">The v3.</param>
        /// <param name="t">The t.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://paulbourke.net/geometry/bezier/index.html
        /// </acknowledgment>
        [DisplayName("Cubic Bezier Interpolate 1")]
        [Description("Simple Cubic Bezier Interpolation.")]
        [Acknowledgment("http://paulbourke.net/geometry/bezier/index.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CubicBezier_(double v0, double v1, double v2, double v3, double t)
        {
            // The inverse of t.
            var ti = 1d - t;

            // The inverse of t cubed.
            var ti3 = ti * ti * ti;

            // The t cubed.
            var t3 = t * t * t;

            return (ti3 * v0) + (3d * t * ti * ti * v1) + (3d * t * t * ti * v2) + (t3 * v3);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://blog.demofox.org/2015/07/05/the-de-casteljeau-algorithm-for-evaluating-bezier-curves/
        /// </acknowledgment>
        [DisplayName("Cubic Bezier Interpolate 1")]
        [Description("Simple Cubic Bezier Interpolation.")]
        [Acknowledgment("https://blog.demofox.org/2015/07/05/the-de-casteljeau-algorithm-for-evaluating-bezier-curves/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double BezierCubic(double A, double B, double C, double D, double t)
        {
            var ABC = InterpolateBezierQuadratic1DTests.BezierQuadratic(A, B, C, t);
            var BCD = InterpolateBezierQuadratic1DTests.BezierQuadratic(B, C, D, t);
            return InterpolateLinear1DTests.BezierLinear(ABC, BCD, t);
        }

        /// <summary>
        /// The EvalBez method.
        /// </summary>
        /// <param name="p0">The p0.</param>
        /// <param name="p1">The p1.</param>
        /// <param name="p2">The p2.</param>
        /// <param name="p3">The p3.</param>
        /// <param name="t">The t.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/24809978/calculating-the-bounding-box-of-cubic-bezier-curve
        /// http://floris.briolas.nl/floris/2009/10/bounding-box-of-cubic-bezier/
        /// http://jsfiddle.net/SalixAlba/QQnvm/4/
        /// </acknowledgment>
        [DisplayName("Cubic Interpolate EvalBez")]
        [Description("Simple Cubic Interpolation.")]
        [Acknowledgment("http://stackoverflow.com/questions/24809978/calculating-the-bounding-box-of-cubic-bezier-curve", "http://floris.briolas.nl/floris/2009/10/bounding-box-of-cubic-bezier/", "http://jsfiddle.net/SalixAlba/QQnvm/4/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EvalBez(double p0, double p1, double p2, double p3, double t)
        {
            return (p0 * (1 - t) * (1 - t) * (1 - t)) + (3 * p1 * t * (1 - t) * (1 - t)) + (3 * p2 * t * t * (1 - t)) + (p3 * t * t * t);
        }
    }
}
