using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The cubic bezier derivative tests class.
    /// </summary>
    [DisplayName("Cubic Bezier Derivative Tests")]
    [Description("Cubic Bezier Derivative.")]
    [SourceCodeLocationProvider]
    public static class CubicBezierDerivativeTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(CubicBezierDerivativeTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0.5d, 0d, 0d, 1d, 1d, 2d, 1d, 3d, 0d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (3d, 0d), epsilon: double.Epsilon) },
                { new object[] { 0.5d, 0d, 1d, 2d, 3d, 4d, 5d, 6d, 7d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (6d, 6d), epsilon: double.Epsilon) },
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
        /// <param name="p0X"></param>
        /// <param name="p0Y"></param>
        /// <param name="p1X"></param>
        /// <param name="p1Y"></param>
        /// <param name="p2X"></param>
        /// <param name="p2Y"></param>
        /// <param name="p3X"></param>
        /// <param name="p3Y"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y) CubicBezierDerivative(double t, double p0X, double p0Y, double p1X, double p1Y, double p2X, double p2Y, double p3X, double p3Y)
            => CubicBezierDerivative1(t, p0X, p0Y, p1X, p1Y, p2X, p2Y, p3X, p3Y);

        /// <summary>
        /// The cubic bezier derivative0.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="p0X"></param>
        /// <param name="p0Y"></param>
        /// <param name="p1X"></param>
        /// <param name="p1Y"></param>
        /// <param name="p2X"></param>
        /// <param name="p2Y"></param>
        /// <param name="p3X"></param>
        /// <param name="p3Y"></param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        /// <acknowledgment>
        /// http://www.cs.mtu.edu/~shene/COURSES/cs3621/NOTES/spline/Bezier/bezier-der.html
        /// </acknowledgment>
        [DisplayName("Cubic Bezier Derivative Tests")]
        [Description("Cubic Bezier Derivative.")]
        [Acknowledgment("http://www.cs.mtu.edu/~shene/COURSES/cs3621/NOTES/spline/Bezier/bezier-der.html")]
        [SourceCodeLocationProvider]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [DebuggerStepThrough]
        public static (double X, double Y) CubicBezierDerivative0(double t, double p0X, double p0Y, double p1X, double p1Y, double p2X, double p2Y, double p3X, double p3Y)
        {
            return (
                (3d * Pow(1d - t, 2d) * (p1X - p0X)) + (6d * (1d - t) * t * (p2X - p1X)) + (3d * Pow(t, 2d) * (p3X - p2X)),
                (3d * Pow(1d - t, 2d) * (p1Y - p0Y)) + (6d * (1d - t) * t * (p2Y - p1Y)) + (3d * Pow(t, 2d) * (p3Y - p2Y))
                );
        }

        /// <summary>
        /// The cubic bezier derivative1.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="p0X"></param>
        /// <param name="p0Y"></param>
        /// <param name="p1X"></param>
        /// <param name="p1Y"></param>
        /// <param name="p2X"></param>
        /// <param name="p2Y"></param>
        /// <param name="p3X"></param>
        /// <param name="p3Y"></param>
        /// <returns>The (double X, double Y).</returns>
        /// <acknowledgment>
        /// http://www.cs.mtu.edu/~shene/COURSES/cs3621/NOTES/spline/Bezier/bezier-der.html
        /// </acknowledgment>
        [DisplayName("Cubic Bezier Derivative Tests")]
        [Description("Cubic Bezier Derivative.")]
        [Acknowledgment("http://www.cs.mtu.edu/~shene/COURSES/cs3621/NOTES/spline/Bezier/bezier-der.html")]
        [SourceCodeLocationProvider]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [DebuggerStepThrough]
        public static (double X, double Y) CubicBezierDerivative1(double t, double p0X, double p0Y, double p1X, double p1Y, double p2X, double p2Y, double p3X, double p3Y)
        {
            var mu1 = 1d - t;
            var mu12 = mu1 * mu1;
            var mu2 = t * t;

            return (
                (3d * mu12 * (p1X - p0X)) + (6d * mu1 * t * (p2X - p1X)) + (3d * mu2 * (p3X - p2X)),
                (3d * mu12 * (p1Y - p0Y)) + (6d * mu1 * t * (p2Y - p1Y)) + (3d * mu2 * (p3Y - p2Y))
                );
        }
    }
}
