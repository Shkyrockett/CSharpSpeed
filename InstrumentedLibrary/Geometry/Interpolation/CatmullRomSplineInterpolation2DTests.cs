using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The catmull rom spline interpolation2d tests class.
    /// </summary>
    [DisplayName("Cubic Catmull-Rom Interpolate Tests")]
    [Description("Find a point on a Cubic CatmullRom curve.")]
    [SourceCodeLocationProvider]
    public static class CatmullRomSplineInterpolation2DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the angle between Two 3D points.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(CatmullRomSplineInterpolation2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 0d, 1d, 1d, 1d, 1d, 0d, 0.5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:(0.5d, 1.125d), epsilon: double.Epsilon) },
                { new object[] { 0d, 1d, 2d, 3d, 4d, 5d, 6d, 7d, 0.5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:(3d, 4d), epsilon: double.Epsilon) },
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
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <param name="x4"></param>
        /// <param name="y4"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y) CatmullRomInterpolate2D(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4, double t)
            => InterpolateCatmullRom(x1, y1, x2, y2, x3, y3, x4, y4, t);

        /// <summary>
        /// Calculates interpolated point between two points using Catmull-Rom Spline
        /// </summary>
        /// <param name="t0X">First Point</param>
        /// <param name="t0Y">First Point</param>
        /// <param name="p1X">Second Point</param>
        /// <param name="p1Y">Second Point</param>
        /// <param name="p2X">Third Point</param>
        /// <param name="p2Y">Third Point</param>
        /// <param name="t3X">Fourth Point</param>
        /// <param name="t3Y">Fourth Point</param>
        /// <param name="t">
        /// Normalized distance between second and third point
        /// where the spline point will be calculated
        /// </param>
        /// <returns>
        /// Calculated Spline Point
        /// </returns>
        /// <acknowledgment>
        /// Points calculated exist on the spline between points two and three.
        /// From: http://tehc0dez.blogspot.com/2010/04/nice-curves-catmullrom-spline-in-c.html
        /// </acknowledgment>
        [DisplayName("Catmull-Rom Interpolate 2D")]
        [Description("Catmull-Rom Interpolation.")]
        [Acknowledgment("http://tehc0dez.blogspot.com/2010/04/nice-curves-catmullrom-spline-in-c.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) InterpolateCatmullRom(
            double t0X, double t0Y,
            double p1X, double p1Y,
            double p2X, double p2Y,
            double t3X, double t3Y,
            double t)
        {
            var tSquared = t * t;
            var tCubed = tSquared * t;
            return (
                0.5d * (2d * p1X
                + (-t0X + p2X) * t
                + (2d * t0X - 5d * p1X + 4d * p2X - t3X) * tSquared
                + (-t0X + 3d * p1X - 3d * p2X + t3X) * tCubed),
                0.5d * (2d * p1Y
                + (-t0Y + p2Y) * t
                + (2d * t0Y - 5d * p1Y + 4d * p2Y - t3Y) * tSquared
                + (-t0Y + 3d * p1Y - 3d * p2Y + t3Y) * tCubed));
        }

        /// <summary>
        /// The catmull rom spline.
        /// </summary>
        /// <param name="x0">The x0.</param>
        /// <param name="y0">The y0.</param>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="x3">The x3.</param>
        /// <param name="y3">The y3.</param>
        /// <param name="t">The t.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
        /// <acknowledgment>
        /// http://paulbourke.net/miscellaneous/interpolation/
        /// </acknowledgment>
        [DisplayName("Catmull-Rom Interpolate 2D")]
        [Description("Catmull-Rom Interpolation.")]
        [Acknowledgment("http://paulbourke.net/miscellaneous/interpolation/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) CatmullRomSpline(
            double x0, double y0,
            double x1, double y1,
            double x2, double y2,
            double x3, double y3,
            double t)
        {
            var mu2 = t * t;

            var aX0 = -0.5d * x0 + 1.5d * x1 - 1.5d * x2 + 0.5d * x3;
            var aY0 = -0.5d * y0 + 1.5d * y1 - 1.5d * y2 + 0.5d * y3;
            var aX1 = x0 - 2.5d * x1 + 2d * x2 - 0.5d * x3;
            var aY1 = y0 - 2.5d * y1 + 2d * y2 - 0.5d * y3;
            var aX2 = -0.5d * x0 + 0.5d * x2;
            var aY2 = -0.5d * y0 + 0.5d * y2;

            return (
                aX0 * t * mu2 + aX1 * mu2 + aX2 * t + x1,
                aY0 * t * mu2 + aY1 * mu2 + aY2 * t + y1);
        }
    }
}
