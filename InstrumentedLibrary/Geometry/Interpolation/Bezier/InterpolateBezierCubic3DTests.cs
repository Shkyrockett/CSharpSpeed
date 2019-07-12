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
    /// The interpolate cubic bezier3d tests class.
    /// </summary>
    [DisplayName("Cubic Bezier Interpolate 3D Tests")]
    [Description("Find a point on a 3D Cubic Bezier curve.")]
    [SourceCodeLocationProvider]
    public static class InterpolateBezierCubic3DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 2D cubic interpolation of a point.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(BezierInterpolateCubic2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0.5d, 0d, 0d, 0d, 1d, 1d, 1d, 2d, 1d, 1d, 3d, 0d, 0d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (1.5d, 0.75d, 0.75d), epsilon: double.Epsilon) },
                { new object[] { 0.5d, 0d, 1d, 2d, 2d, 3d, 4d, 4d, 5d, 5d, 6d, 7d, 7d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (3d, 4d, 4.5d), epsilon: double.Epsilon) },
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
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y, double Z) CubicBezierInterpolate2D(double t, double aX, double aY, double aZ, double bX, double bY, double bZ, double cX, double cY, double cZ, double dX, double dY, double dZ)
            => CubicBezierInterpolate3D1(t, aX, aY, aZ, bX, bY, bZ, cX, cY, cZ, dX, dY, dZ);

        /// <summary>
        /// Calculate parametric value of x or y given t and the four point
        /// coordinates of a cubic bezier curve. This is a separate function
        /// because we need it for both x and y values.
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
        /// <returns></returns>
        /// <acknowledgment>
        /// http://www.lemoda.net/maths/bezier-length/index.html
        /// </acknowledgment>
        [DisplayName("Cubic Bezier Interpolate 2")]
        [Description("Simple Cubic Bezier Interpolation.")]
        [Acknowledgment("http://www.lemoda.net/maths/bezier-length/index.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) CubicBezierInterpolate3D1(double t, double aX, double aY, double aZ, double bX, double bY, double bZ, double cX, double cY, double cZ, double dX, double dY, double dZ)
        {
            // Formula from Wikipedia article on Bézier curves.
            return (
                (aX * (1d - t) * (1d - t) * (1d - t)) + (3d * bX * (1d - t) * (1d - t) * t) + (3d * cX * (1d - t) * t * t) + (dX * t * t * t),
                (aY * (1d - t) * (1d - t) * (1d - t)) + (3d * bY * (1d - t) * (1d - t) * t) + (3d * cY * (1d - t) * t * t) + (dY * t * t * t),
                (aZ * (1d - t) * (1d - t) * (1d - t)) + (3d * bZ * (1d - t) * (1d - t) * t) + (3d * cZ * (1d - t) * t * t) + (dZ * t * t * t)
                );
        }
    }
}
