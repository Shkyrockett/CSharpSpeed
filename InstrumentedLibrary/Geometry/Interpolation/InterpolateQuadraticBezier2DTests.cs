using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The interpolate quadratic bezier2d tests class.
    /// </summary>
    [DisplayName("Quadratic Bezier Interpolate 2D Tests")]
    [Description("Find a point on a 2D Quadratic Bezier curve.")]
    [SourceCodeLocationProvider]
    public static class InterpolateQuadraticBezier2DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 2D cubic interpolation of a point.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(InterpolateQuadraticBezier2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 1d, 2d, 3d, 4d, 5d, 0.5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:(2d, 3d), epsilon: double.Epsilon) },
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
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y) QuadraticBezierInterpolate2D(double x0, double y0, double x1, double y1, double x2, double y2, double t)
            => QuadraticBezierInterpolate2D_0(x0, y0, x1, y1, x2, y2, t);

        /// <summary>
        /// Three control point Bézier interpolation mu ranges from 0 to 1, start to end of the curve.
        /// </summary>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [DisplayName("Quadratic Bezier Interpolate 1")]
        [Description("Simple Quadratic Bezier Interpolation.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) QuadraticBezierInterpolate2D_0(
            double x0, double y0,
            double x1, double y1,
            double x2, double y2,
            double t)
        {
            var mu1 = 1 - t;
            var mu12 = mu1 * mu1;
            var mu2 = t * t;

            return (
                (x0 * mu12) + (2 * x1 * mu1 * t) + (x2 * mu2),
                (y0 * mu12) + (2 * y1 * mu1 * t) + (y2 * mu2)
                );
        }

        /// <summary>
        /// Evaluate a point on a Bézier-curve. t goes from 0 to 1.0
        /// </summary>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
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
        public static (double X, double Y) QuadraticBezierInterpolate2D_1(
            double x0, double y0,
            double x1, double y1,
            double x2, double y2,
            double t)
        {
            // point between a and b
            var ab = InterpolateLinear2DTests.LinearInterpolate2D(x0, y0, x1, y1, t);

            // point between b and c
            var bc = InterpolateLinear2DTests.LinearInterpolate2D(x1, y1, x2, y2, t);

            // point on the bezier-curve
            return InterpolateLinear2DTests.LinearInterpolate2D(ab.X, ab.Y, bc.X, bc.Y, t);
        }
    }
}
