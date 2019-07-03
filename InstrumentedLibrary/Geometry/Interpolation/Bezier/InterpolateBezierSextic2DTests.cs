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
    [DisplayName("Sextic Bezier Interpolate 2D Tests")]
    [Description("Find a point on a 2D Sextic Bezier curve.")]
    [SourceCodeLocationProvider]
    public static class InterpolateBezierSextic2DTests
    {
        /// <summary>
        /// The interpolate cubic bezier1d test.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(InterpolateBezierSextic2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0.5d, 0d, 1d, 2d, 3d, 4d, 5d, 6d, 7d, 8d, 9d, 10d, 11d, 12d, 13d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: 7.21875d, epsilon: double.Epsilon) },
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
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <param name="dX"></param>
        /// <param name="dY"></param>
        /// <param name="eX"></param>
        /// <param name="eY"></param>
        /// <param name="fX"></param>
        /// <param name="fY"></param>
        /// <param name="gX"></param>
        /// <param name="gY"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y) BezierInterpolateBezierSextic2DTestsSextic(double t, double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY, double eX, double eY, double fX, double fY, double gX, double gY)
            => BezierSextic(t, aX, aY, bX, bY, cX, cY, dX, dY, eX, eY, fX, fY, gX, gY);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <param name="dX"></param>
        /// <param name="dY"></param>
        /// <param name="eX"></param>
        /// <param name="eY"></param>
        /// <param name="fX"></param>
        /// <param name="fY"></param>
        /// <param name="gX"></param>
        /// <param name="gY"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://blog.demofox.org/2015/07/05/the-de-casteljeau-algorithm-for-evaluating-bezier-curves/
        /// </acknowledgment>
        [DisplayName("Sextic Bezier Interpolate 1")]
        [Description("Simple Sextic Bezier Interpolation.")]
        [Acknowledgment("https://blog.demofox.org/2015/07/05/the-de-casteljeau-algorithm-for-evaluating-bezier-curves/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) BezierSextic(double t, double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY, double eX, double eY, double fX, double fY, double gX, double gY)
        {
            var abcdef = InterpolateBezierQuintic2DTests.BezierQuintic(t, aX, aY, bX, bY, cX, cY, dX, dY, eX, eY, fX, fY);
            var bcdefg = InterpolateBezierQuintic2DTests.BezierQuintic(t, bX, bY, cX, cY, dX, dY, eX, eY, fX, fY, gX, gY);
            return InterpolateLinear2DTests.LinearInterpolate2D(t, abcdef.X, abcdef.Y, bcdefg.X, bcdefg.Y);
        }
    }
}
