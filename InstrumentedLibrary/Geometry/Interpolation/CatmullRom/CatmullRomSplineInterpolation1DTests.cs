using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The catmull rom spline interpolation1d tests class.
    /// </summary>
    [DisplayName("Cubic Catmull-Rom Interpolate Tests")]
    [Description("Find a point on a Cubic CatmullRom curve.")]
    [SourceCodeLocationProvider]
    public static class CatmullRomSplineInterpolation1DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the angle between Two 3D points.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(CatmullRomSplineInterpolation1DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0.5d, 0d, 0d, 1d, 1d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:0.5d, epsilon: double.Epsilon) },
                { new object[] { 0.5d, 0d, 1d, 2d, 3d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:1.5d, epsilon: double.Epsilon) },
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
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        /// <param name="v4"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double CatmullRomInterpolate1D(double t, double v1, double v2, double v3, double v4)
            => CatmullRomSpline(t, v1, v2, v3, v4);

        /// <summary>
        /// Performs a Catmull-Rom interpolation using the specified positions.
        /// </summary>
        /// <param name="t">Weighting factor.</param>
        /// <param name="v1">The first position in the interpolation.</param>
        /// <param name="v2">The second position in the interpolation.</param>
        /// <param name="v3">The third position in the interpolation.</param>
        /// <param name="v4">The fourth position in the interpolation.</param>
        /// <returns>A position that is the result of the Catmull-Rom interpolation.</returns>
        /// <acknowledgment>
        /// http://www.mvps.org/directx/articles/catmull/
        /// </acknowledgment>
        [DisplayName("Catmull-Rom Interpolate 1D")]
        [Description("Catmull-Rom Interpolation.")]
        [Acknowledgment("http://www.mvps.org/directx/articles/catmull/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CatmullRom(double t, double v1, double v2, double v3, double v4)
        {
            var tSquared = t * t;
            var tCubed = tSquared * t;
            return
                0.5d * ((2d * v2)
                + ((v3 - v1) * t)
                + (((2d * v1) - (5d * v2) + (4d * v3) - v4) * tSquared)
                + (((3d * v2) - v1 - (3.0d * v3) + v4) * tCubed));
        }

        /// <summary>
        /// The catmull rom spline.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="v0">The v0.</param>
        /// <param name="v1">The v1.</param>
        /// <param name="v2">The v2.</param>
        /// <param name="v3">The v3.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://paulbourke.net/miscellaneous/interpolation/
        /// </acknowledgment>
        [DisplayName("Catmull-Rom Interpolate 1D")]
        [Description("Catmull-Rom Interpolation.")]
        [Acknowledgment("http://paulbourke.net/miscellaneous/interpolation/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CatmullRomSpline(double t, double v0, double v1, double v2, double v3)
        {
            var mu2 = t * t;
            var a0 = (-0.5d * v0) + (1.5d * v1) - (1.5d * v2) + (0.5d * v3);
            var a1 = v0 - (2.5d * v1) + (2d * v2) - (0.5d * v3);
            var a2 = (-0.5d * v0) + (0.5d * v2);
            var a3 = v1;
            return (a0 * t * mu2) + (a1 * mu2) + (a2 * t) + a3;
        }
    }
}
