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
    /// The Catmull-Rom spline interpolation3d tests class.
    /// </summary>
    [DisplayName("Catmull-Rom Interpolate Tests")]
    [Description("Find a point on a CatmullRom curve.")]
    [SourceCodeLocationProvider]
    public static class CatmullRomSplineInterpolation3DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the angle between Two 3D points.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(CatmullRomSplineInterpolation3DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 0d, 0d, 0d, 1d, 1d, 1d, 1d, 1d, 0d, 0d, 0.5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:(0.5d, 0.5625d, 1.125d), epsilon: double.Epsilon) },
                { new object[] { 0d, 1d, 2d, 3d, 4d, 5d, 6d, 7d, 8d, 9d, 10d, 11d, 0.5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:(4.5d, 4.5d, 6.5d), epsilon: double.Epsilon) },
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
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="z1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="z2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <param name="z3"></param>
        /// <param name="x4"></param>
        /// <param name="y4"></param>
        /// <param name="z4"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y, double Z) CatmullRomInterpolate3D(double x1, double y1, double z1, double x2, double y2, double z2, double x3, double y3, double z3, double x4, double y4, double z4, double t)
            => CatmullRomSpline(x1, y1, z1, x2, y2, z2, x3, y3, z3, x4, y4, z4, t);

        /// <summary>
        /// Performs a Catmull-Rom interpolation using the specified positions.
        /// </summary>
        /// <param name="x1">The first position in the interpolation.</param>
        /// <param name="y1"></param>
        /// <param name="z1"></param>
        /// <param name="x2">The second position in the interpolation.</param>
        /// <param name="y2"></param>
        /// <param name="z2"></param>
        /// <param name="x3">The third position in the interpolation.</param>
        /// <param name="y3"></param>
        /// <param name="z3"></param>
        /// <param name="x4">The fourth position in the interpolation.</param>
        /// <param name="y4"></param>
        /// <param name="z4"></param>
        /// <param name="t">Weighting factor.</param>
        /// <returns>A position that is the result of the Catmull-Rom interpolation.</returns>
        /// <acknowledgment>
        /// http://www.mvps.org/directx/articles/catmull/
        /// </acknowledgment>
        [DisplayName("Catmull-Rom Interpolate 2D")]
        [Description("Catmull-Rom Interpolation.")]
        [Acknowledgment("http://www.mvps.org/directx/articles/catmull/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) CatmullRom(
            double x1, double y1, double z1,
            double x2, double y2, double z2,
            double x3, double y3, double z3,
            double x4, double y4, double z4,
            double t)
        {
            var tSquared = t * t;
            var tCubed = tSquared * t;
            return (
                0.5d * (2d * x2
                + (x3 - x1) * t
                + (2d * x1 - 5d * x2 + 4d * x3 - x4) * tSquared
                + (3d * x2 - x1 - 3d * x3 + x4) * tCubed),
                0.5d * (2d * x2
                + (y3 - y1) * t
                + (2d * y1 - 5d * y2 + 4d * y3 - y4) * tSquared
                + (3d * y2 - y1 - 3d * y3 + y4) * tCubed),
                0.5d * (2d * z2
                + (z3 - z1) * t
                + (2d * z1 - 5d * z2 + 4d * z3 - z4) * tSquared
                + (3d * z2 - z1 - 3d * z3 + z4) * tCubed));
        }

        /// <summary>
        /// The catmull rom spline.
        /// </summary>
        /// <param name="x0">The x0.</param>
        /// <param name="y0">The y0.</param>
        /// <param name="z0">The z0.</param>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="z1">The z1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="z2">The z2.</param>
        /// <param name="x3">The x3.</param>
        /// <param name="y3">The y3.</param>
        /// <param name="z3">The z3.</param>
        /// <param name="t">The t.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <acknowledgment>
        /// http://paulbourke.net/miscellaneous/interpolation/
        /// </acknowledgment>
        [DisplayName("Catmull-Rom Interpolate 3D")]
        [Description("Catmull-Rom Interpolation.")]
        [Acknowledgment("http://paulbourke.net/miscellaneous/interpolation/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) CatmullRomSpline(
            double x0, double y0, double z0,
            double x1, double y1, double z1,
            double x2, double y2, double z2,
            double x3, double y3, double z3,
            double t)
        {
            var mu2 = t * t;

            var aX0 = -0.5d * x0 + 1.5d * x1 - 1.5d * x2 + 0.5d * x3;
            var aY0 = -0.5d * y0 + 1.5d * y1 - 1.5d * y2 + 0.5d * y3;
            var aZ0 = -0.5d * z0 + 1.5d * z1 - 1.5d * z2 + 0.5d * z3;
            var aX1 = x0 - 2.5d * x1 + 2d * x2 - 0.5d * x3;
            var aY1 = y0 - 2.5d * y1 + 2d * y2 - 0.5d * y3;
            var aZ1 = z0 - 2.5d * z1 + 2d * z2 - 0.5d * z3;
            var aX2 = -0.5d * x0 + 0.5d * x2;
            var aY2 = -0.5d * y0 + 0.5d * y2;
            var aZ2 = -0.5d * z0 + 0.5d * z2;

            return (
                aX0 * t * mu2 + aX1 * mu2 + aX2 * t + x1,
                aY0 * t * mu2 + aY1 * mu2 + aY2 * t + y1,
                aZ0 * t * mu2 + aZ1 * mu2 + aZ2 * t + z1);
        }
    }
}
