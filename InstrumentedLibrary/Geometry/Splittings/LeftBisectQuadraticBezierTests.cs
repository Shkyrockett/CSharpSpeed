using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Left Bisect Quadratic Bezier")]
    [Description("Left Bisect Quadratic Bezier.")]
    [SourceCodeLocationProvider]
    public static class LeftBisectQuadraticBezierTests
    {
        /// <summary>
        /// The polygon centroid test.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(LeftBisectQuadraticBezierTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 1000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 5d, 5d, 5d, 0d, 0.5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static QuadraticBezier2D LeftBisectQuadraticBezier(double aX, double aY, double bX, double bY, double cX, double cY, double t)
            => LeftBisectQuadraticBezier1(aX, aY, bX, bY, cX, cY, t);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://jwezorek.com/2015/01/my-code-for-doing-two-things-that-sooner-or-later-you-will-want-to-do-with-bezier-curves/
        /// https://developer.roblox.com/articles/Bezier-curves
        /// </acknowledgment>
        [DisplayName("Left Bisect Quadratic Bezier")]
        [Description("Left Bisect Quadratic Bezier.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static QuadraticBezier2D LeftBisectQuadraticBezier1(double aX, double aY, double bX, double bY, double cX, double cY, double t)
        {
            var (dX, dY) = InterpolateLinear2DTests.LinearInterpolate2D(t, aX, aY, bX, bY);
            var (eX, eY) = InterpolateLinear2DTests.LinearInterpolate2D(t, bX, bY, cX, cY);
            var (fX, fY) = InterpolateLinear2DTests.LinearInterpolate2D(t, dX, dY, eX, eY);

            return new QuadraticBezier2D(aX, aY, dX, dY, fX, fY);
        }
    }
}
