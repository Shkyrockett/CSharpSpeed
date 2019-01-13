using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using static InstrumentedLibrary.Maths;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The quadratic Bézier to cubic Bézier tests class.
    /// </summary>
    [DisplayName("Quadratic Bézier to Cubic Bézier Tests")]
    [Description("Convert a Quadratic Bézier to a Cubic Bézier.")]
    [Signature("public static double QuadraticBezierToCubicBezier(double v0, double v1, double v2, double v3, double t)")]
    [SourceCodeLocationProvider]
    public static class QuadraticBezierToCubicBezierTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(QuadraticBezierToCubicBezierTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 1d, 2d, 3d, 4d, 5d }, new TestCaseResults(description:"", trials:trials, expectedReturnValue: (0d, 1d, 1.33333333333333d, 2.33333333333333d, 4.66666666666667d, 5.66666666666667d, 6d, 7d), epsilon:DoubleEpsilon) },
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
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY) QuadraticBezierToCubicBezier(double aX, double aY, double bX, double bY, double cX, double cY)
            => QuadraticBezierToCubicBezierTuple(aX, aY, bX, bY, cX, cY);

        /// <summary>
        /// Raise a Quadratic Bézier to a Cubic Bézier.
        /// </summary>
        /// <param name="aX">The x-component of the starting point.</param>
        /// <param name="aY">The y-component of the starting point.</param>
        /// <param name="bX">The x-component of the handle.</param>
        /// <param name="bY">The y-component of the handle.</param>
        /// <param name="cX">The x-component of the end point.</param>
        /// <param name="cY">The y-component of the end point.</param>
        /// <returns>Returns Quadratic Bézier curve from a cubic curve.</returns>
        [DisplayName("Quadratic Bézier to Cubic Bézier Tests")]
        [Description("Raise a Quadratic Bézier to a Cubic Bézier.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY) QuadraticBezierToCubicBezierTuple(
            double aX, double aY,
            double bX, double bY,
            double cX, double cY)
        {
            return (aX, aY,
                    aX + TwoThirds * (bX - aX), aY + TwoThirds * (bY - aY),
                    cX + TwoThirds * (bX - cX), cY + TwoThirds * (bY - cY),
                    cX, cY);
        }
    }
}
