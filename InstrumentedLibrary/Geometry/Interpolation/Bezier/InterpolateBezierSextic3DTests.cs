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
    [DisplayName("Sextic Bezier Interpolate 3D Tests")]
    [Description("Find a point on a 3D Sextic Bezier curve.")]
    [SourceCodeLocationProvider]
    public static class InterpolateBezierSextic3DTests
    {
        /// <summary>
        /// The interpolate cubic bezier3d test.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(InterpolateBezierSextic2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0.5d, 0d, 1d, 2d, 3d, 4d, 5d, 6d, 7d, 8d, 9d, 10d, 11d, 12d, 13d, 14d, 15d, 16d, 17d, 18d, 19d, 20d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: 7.21875d, epsilon: double.Epsilon) },
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
        /// <param name="aZ"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="bZ"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <param name="cZ"></param>
        /// <param name="dX"></param>
        /// <param name="dY"></param>
        /// <param name="dZ"></param>
        /// <param name="eX"></param>
        /// <param name="eY"></param>
        /// <param name="eZ"></param>
        /// <param name="fX"></param>
        /// <param name="fY"></param>
        /// <param name="fZ"></param>
        /// <param name="gX"></param>
        /// <param name="gY"></param>
        /// <param name="gZ"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y, double Z) BezierInterpolateBezierSextic2DTestsSextic(double t, double aX, double aY, double aZ, double bX, double bY, double bZ, double cX, double cY, double cZ, double dX, double dY, double dZ, double eX, double eY, double eZ, double fX, double fY, double fZ, double gX, double gY, double gZ)
            => BezierSextic(t, aX, aY, aZ, bX, bY, bZ, cX, cY, cZ, dX, dY, dZ, eX, eY, eZ, fX, fY, fZ, gX, gY, gZ);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="aZ"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="bZ"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <param name="cZ"></param>
        /// <param name="dX"></param>
        /// <param name="dY"></param>
        /// <param name="dZ"></param>
        /// <param name="eX"></param>
        /// <param name="eY"></param>
        /// <param name="eZ"></param>
        /// <param name="fX"></param>
        /// <param name="fY"></param>
        /// <param name="fZ"></param>
        /// <param name="gX"></param>
        /// <param name="gY"></param>
        /// <param name="gZ"></param>
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
        public static (double X, double Y, double Z) BezierSextic(double t, double aX, double aY, double aZ, double bX, double bY, double bZ, double cX, double cY, double cZ, double dX, double dY, double dZ, double eX, double eY, double eZ, double fX, double fY, double fZ, double gX, double gY, double gZ)
        {
            var abcdef = InterpolateBezierQuintic3DTests.BezierQuintic(t, aX, aY, aZ, bX, bY, bZ, cX, cY, cZ, dX, dY, dZ, eX, eY, eZ, fX, fY, fZ);
            var bcdefg = InterpolateBezierQuintic3DTests.BezierQuintic(t, bX, bY, bZ, cX, cY, cZ, dX, dY, dZ, eX, eY, eZ, fX, fY, fZ, gX, gY, gZ);
            return InterpolateLinear3DTests.LinearInterpolate3D(t, abcdef.X, abcdef.Y, abcdef.Z, bcdefg.X, bcdefg.Y, bcdefg.Z);
        }
    }
}
