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
    [DisplayName("Quintic Bezier Interpolate 3D Tests")]
    [Description("Find a point on a 3D Quintic Bezier curve.")]
    [SourceCodeLocationProvider]
    public static class InterpolateBezierQuintic3DTests
    {
        /// <summary>
        /// The interpolate cubic bezier3d test.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(InterpolateBezierQuintic1DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0.5d, 0d, 1d, 2d, 3d, 4d, 5d, 6d, 7d, 8d, 9d, 10d, 11d, 12d, 13d, 14d, 15d, 16d, 17d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (0d, 0d, 0d), epsilon: double.Epsilon) },
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
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y, double Z) InterpolateBezierQuintic1D(double t, double aX, double aY, double aZ, double bX, double bY, double bZ, double cX, double cY, double cZ, double dX, double dY, double dZ, double eX, double eY, double eZ, double fX, double fY, double fZ)
            => BezierQuintic(t, aX, aY, aZ, bX, bY, bZ, cX, cY, cZ, dX, dY, dZ, eX, eY, eZ, fX, fY, fZ);

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
        /// <returns></returns>
        /// <acknowledgment>
        /// https://blog.demofox.org/2015/07/05/the-de-casteljeau-algorithm-for-evaluating-bezier-curves/
        /// </acknowledgment>
        [DisplayName("Quintic Bezier Interpolate 1")]
        [Description("Simple Quintic Bezier Interpolation.")]
        [Acknowledgment("https://blog.demofox.org/2015/07/05/the-de-casteljeau-algorithm-for-evaluating-bezier-curves/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) BezierQuintic(double t, double aX, double aY, double aZ, double bX, double bY, double bZ, double cX, double cY, double cZ, double dX, double dY, double dZ, double eX, double eY, double eZ, double fX, double fY, double fZ)
        {
            var abcde = InterpolateBezierQuartic3DTests.QuarticBezierInterpolateGetPoint(t, aX, aY, aZ, bX, bY, bZ, cX, cY, cZ, dX, dY, dZ, eX, eY, eZ);
            var bcdef = InterpolateBezierQuartic3DTests.QuarticBezierInterpolateGetPoint(t, bX, bY, bZ, cX, cY, cZ, dX, dY, dZ, eX, eY, eZ, fX, fY, fZ);
            return InterpolateLinear3DTests.LinearInterpolate3D(t, abcde.X, abcde.Y, abcde.Z, bcdef.X, bcdef.Y, bcdef.Z);
        }
    }
}
