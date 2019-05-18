using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The hermite interpolate3d tests class.
    /// </summary>
    [DisplayName("Cubic Hermite Interpolate Tests")]
    [Description("Find a point on a Hermite curve.")]
    [SourceCodeLocationProvider]
    public static class HermiteInterpolate3DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 3D Hermite interpolation of points.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(HermiteInterpolate3DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 1d, 2d, 3d, 4d, 5d, 6d, 7d, 8d, 9d, 10d, 11d, 0.5d, 1d, 0d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:0.5d, epsilon: double.Epsilon) },
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
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="z0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="z1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="z2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <param name="z3"></param>
        /// <param name="mu"></param>
        /// <param name="tension"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y, double Z) HermiteInterpolate3D(double x0, double y0, double z0, double x1, double y1, double z1, double x2, double y2, double z2, double x3, double y3, double z3, double mu, double tension, double bias)
            => HermiteInterpolate3D_(x0, y0, z0, x1, y1, z1, x2, y2, z2, x3, y3, z3, mu, tension, bias);

        /// <summary>
        /// The hermite interpolate3d.
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
        /// <param name="mu">The mu.</param>
        /// <param name="tension">1 is high, 0 normal, -1 is low</param>
        /// <param name="bias">0 is even,positive is towards first segment, negative towards the other</param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <acknowledgment>
        /// http://paulbourke.net/miscellaneous/interpolation/
        /// </acknowledgment>
        [DisplayName("Hermite Interpolate 3D")]
        [Description("Hermite Interpolation.")]
        [Acknowledgment("http://paulbourke.net/miscellaneous/interpolation/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) HermiteInterpolate3D_(
            double x0, double y0, double z0,
            double x1, double y1, double z1,
            double x2, double y2, double z2,
            double x3, double y3, double z3,
            double mu, double tension, double bias)
        {
            var mu2 = mu * mu;
            var mu3 = mu2 * mu;

            var mX0 = (x1 - x0) * (1d + bias) * (1d - tension) / 2d;
            mX0 += (x2 - x1) * (1d - bias) * (1d - tension) / 2d;
            var mY0 = (y1 - y0) * (1d + bias) * (1d - tension) / 2d;
            mY0 += (y2 - y1) * (1d - bias) * (1d - tension) / 2d;
            var mZ0 = (z1 - z0) * (1d + bias) * (1d - tension) / 2d;
            mZ0 += (z2 - z1) * (1d - bias) * (1d - tension) / 2d;
            var mX1 = (x2 - x1) * (1d + bias) * (1d - tension) / 2d;
            mX1 += (x3 - x2) * (1d - bias) * (1d - tension) / 2d;
            var mY1 = (y2 - y1) * (1d + bias) * (1d - tension) / 2d;
            mY1 += (y3 - y2) * (1d - bias) * (1d - tension) / 2d;
            var mZ1 = (z2 - z1) * (1d + bias) * (1d - tension) / 2d;
            mZ1 += (z3 - z2) * (1d - bias) * (1d - tension) / 2d;
            var a0 = 2d * mu3 - 3d * mu2 + 1d;
            var a1 = mu3 - 2 * mu2 + mu;
            var a2 = mu3 - mu2;
            var a3 = -2d * mu3 + 3d * mu2;

            return (
                a0 * x1 + a1 * mX0 + a2 * mX1 + a3 * x2,
                a0 * y1 + a1 * mY0 + a2 * mY1 + a3 * y2,
                a0 * z1 + a1 * mZ0 + a2 * mZ1 + a3 * z2);
        }
    }
}
