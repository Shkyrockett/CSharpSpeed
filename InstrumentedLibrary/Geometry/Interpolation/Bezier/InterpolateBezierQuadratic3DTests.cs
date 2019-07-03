using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The interpolate quadratic bezier3d tests class.
    /// </summary>
    [DisplayName("Quadratic Bezier Interpolate 3D Tests")]
    [Description("Find a point on a 3D Quadratic Bezier curve.")]
    [SourceCodeLocationProvider]
    public static class InterpolateBezierQuadratic3DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 3D cubic interpolation of a point.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(InterpolateBezierQuadratic3DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0.5d, 0d, 1d, 2d, 3d, 4d, 5d, 6d, 7d, 8d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:(3d, 4d, 5d), epsilon: double.Epsilon) },
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
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="z0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="z1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="z2"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y, double Z) QuadraticBezierInterpolate3D(double t, double x0, double y0, double z0, double x1, double y1, double z1, double x2, double y2, double z2)
            => QuadraticBezierInterpolate3D_0(t, x0, y0, z0, x1, y1, z1, x2, y2, z2);

        /// <summary>
        /// Three control point Bezier interpolation mu ranges from 0 to 1, start to end of the curve.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="z0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="z1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="z2"></param>
        /// <returns></returns>
        [DisplayName("Quadratic Bezier Interpolate 1")]
        [Description("Simple Quadratic Bezier Interpolation.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) QuadraticBezierInterpolate3D_0(double t, double x0, double y0, double z0, double x1, double y1, double z1, double x2, double y2, double z2)
        {
            var mu1 = 1d - t;
            var mu12 = mu1 * mu1;
            var mu2 = t * t;

            return (
                (x0 * mu12) + (2d * x1 * mu1 * t) + (x2 * mu2),
                (y0 * mu12) + (2d * y1 * mu1 * t) + (y2 * mu2),
                (z0 * mu12) + (2d * z1 * mu1 * t) + (z2 * mu2));
        }

        /// <summary>
        /// Evaluate a point on a Bézier-curve. t goes from 0 to 1.0
        /// </summary>
        /// <param name="t"></param>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="z0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="z1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="z2"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://www.cubic.org/docs/bezier.htm
        /// </acknowledgment>
        [DisplayName("Quadratic Bezier Interpolate 2")]
        [Description("Simple Quadratic Bezier Interpolation.")]
        [Acknowledgment("http://www.cubic.org/docs/bezier.htm")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) QuadraticBezierInterpolate3D_1(double t, double x0, double y0, double z0, double x1, double y1, double z1, double x2, double y2, double z2)
        {
            // point between a and b
            var ab = InterpolateLinear3DTests.LinearInterpolate3D(t, x0, y0, z0, x1, y1, z1);

            // point between b and c
            var bc = InterpolateLinear3DTests.LinearInterpolate3D(t, x1, y1, z1, x2, y2, z2);

            // point on the bezier-curve
            return InterpolateLinear3DTests.LinearInterpolate3D(t, ab.X, ab.Y, ab.Z, bc.X, bc.Y, bc.Z);
        }
    }
}
