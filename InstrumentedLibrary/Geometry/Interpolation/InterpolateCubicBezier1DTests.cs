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
    public static class InterpolateCubicBezier1DTests
    {
        /// <summary>
        /// The interpolate cubic bezier1d test.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(InterpolateCubicBezier1DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
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
        public static double CubicBezier_(
            double v0,
            double v1,
            double v2,
            double v3,
            double t)
        {
            // The inverse of t.
            var ti = 1d - t;

            // The inverse of t cubed.
            var ti3 = ti * ti * ti;

            // The t cubed.
            var t3 = t * t * t;

            return (ti3 * v0) + (3d * t * ti * ti * v1) + (3d * t * t * ti * v2) + (t3 * v3);
        }
    }
}
