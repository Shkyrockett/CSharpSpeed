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
    [DisplayName("Right Bisect Cubic Bezier")]
    [Description("Right Bisect Cubic Bezier.")]
    [SourceCodeLocationProvider]
    public static class RightBisectCubicBezierTests
    {
        /// <summary>
        /// The polygon centroid test.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(RightBisectCubicBezierTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 1000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 0d, 5d, 5d, 5d, 5d, 0d, 0.5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        /// <param name="dX"></param>
        /// <param name="dY"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static CubicBezier2D RightBisectCubicBezier(double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY, double t)
            => RightBisectCubicBezier_(aX, aY, bX, bY, cX, cY, dX, dY, t);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <param name="dX"></param>
        /// <param name="dY"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://jwezorek.com/2015/01/my-code-for-doing-two-things-that-sooner-or-later-you-will-want-to-do-with-bezier-curves/
        /// </acknowledgment>
        [DisplayName("Right Bisect Cubic Bezier")]
        [Description("Right Bisect Cubic Bezier.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CubicBezier2D RightBisectCubicBezier_(double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY, double t)
        {
            var (eX, eY) = InterpolateLinear2DTests.LinearInterpolate2D(aX, aY, bX, bY, t);
            var (fX, fY) = InterpolateLinear2DTests.LinearInterpolate2D(bX, bY, cX, cY, t);
            var (gX, gY) = InterpolateLinear2DTests.LinearInterpolate2D(cX, cY, dX, dY, t);
            var (hX, hY) = InterpolateLinear2DTests.LinearInterpolate2D(eX, eY, fX, fY, t);
            var (jX, jY) = InterpolateLinear2DTests.LinearInterpolate2D(fX, fY, gX, gY, t);
            var (kX, kY) = InterpolateLinear2DTests.LinearInterpolate2D(hX, hY, jX, jY, t);

            return (kX, kY, jX, jY, gX, gY, dX, dY);
        }
    }
}
