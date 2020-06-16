using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The hermite interpolate 1d tests class.
    /// </summary>
    [DisplayName("Cubic Hermite Interpolate Tests")]
    [Description("Find a point on a Hermite curve.")]
    [SourceCodeLocationProvider]
    public static class HermiteInterpolate1DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 1D Hermite interpolation of points.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(HermiteInterpolate1DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0.5d, 0d, 1d, 2d, 3d, 1d, 0d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:0.5d, epsilon: double.Epsilon) },
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
        /// <param name="s"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        /// <param name="tension"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double HermiteInterpolate1D(double s, double v0, double v1, double v2, double v3, double tension, double bias)
            => HermiteInterpolate1D1(s, v0, v1, v2, v3, tension, bias);

        /// <summary>
        /// The hermite interpolate1d.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="v0">The v0.</param>
        /// <param name="v1">The v1.</param>
        /// <param name="v2">The v2.</param>
        /// <param name="v3">The v3.</param>
        /// <param name="tension">1 is high, 0 normal, -1 is low</param>
        /// <param name="bias">0 is even,positive is towards first segment, negative towards the other</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://paulbourke.net/miscellaneous/interpolation/
        /// </acknowledgment>
        [DisplayName("Hermite Interpolate 1D")]
        [Description("Hermite Interpolation.")]
        [Acknowledgment("http://paulbourke.net/miscellaneous/interpolation/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double HermiteInterpolate1D1(double s, double v0, double v1, double v2, double v3, double tension, double bias)
        {
            var sSquared = s * s;
            var sCubed = sSquared * s;
            var m0 = (v1 - v0) * (1d + bias) * (1d - tension) / 2d;
            m0 += (v2 - v1) * (1d - bias) * (1d - tension) / 2d;
            var m1 = (v2 - v1) * (1d + bias) * (1d - tension) / 2d;
            m1 += (v3 - v2) * (1d - bias) * (1d - tension) / 2d;
            var a0 = (2d * sCubed) - (3d * sSquared) + 1d;
            var a1 = sCubed - (2d * sSquared) + s;
            var a2 = sCubed - sSquared;
            var a3 = (-2d * sCubed) + (3d * sSquared);

            return (a0 * v1) + (a1 * m0) + (a2 * m1) + (a3 * v2);
        }

        /// <summary>
        /// Performs a Hermite spline interpolation.
        /// </summary>
        /// <param name="s">Weighting factor.</param>
        /// <param name="v1">Source position.</param>
        /// <param name="t1">Source tangent.</param>
        /// <param name="v2">Source position.</param>
        /// <param name="t2">Source tangent.</param>
        /// <param name="tension"></param>
        /// <param name="bias"></param>
        /// <returns>The result of the Hermite spline interpolation.</returns>
        [DisplayName("Hermite Interpolate 1D")]
        [Description("Hermite Interpolation.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Hermite(double s, double v1, double t1, double v2, double t2, double tension, double bias)
        {
            _ = tension;
            _ = bias;
            double result;
            var sSquared = s * s;
            var sCubed = sSquared * s;

            if (s == 0d)
            {
                result = v1;
            }
            else
            {
                result = s == 1d ? v2 : (((2d * v1) - (2d * v2) + t2 + t1) * sCubed)
                   + (((3d * v2) - (3d * v1) - (2d * t1) - t2) * sSquared)
                   + (t1 * s)
                   + v1;
            }

            return result;
        }

        /// <summary>
        /// The hermite interpolate.
        /// </summary>
        /// <param name="mu">The mu.</param>
        /// <param name="y0">The y0.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="y3">The y3.</param>
        /// <param name="tension">Tension: 1 is high, 0 normal, -1 is low</param>
        /// <param name="bias">Bias: 0 is even,</param>
        /// <returns>The <see cref="double"/>. positive is towards First segment, negative towards the other</returns>
        public static double HermiteInterpolate(double mu, double y0, double y1, double y2, double y3, double tension, double bias)
        {
            var m0 = (y1 - y0) * ((1d + bias) * ((1d - tension) / 2d));
            m0 += (y2 - y1) * ((1d - bias) * ((1d - tension) / 2d));
            var m1 = (y2 - y1) * ((1d + bias) * ((1d - tension) / 2d));
            m1 += (y3 - y2) * ((1d - bias) * ((1d - tension) / 2d));
            var mu2 = mu * mu;
            var mu3 = mu2 * mu;
            var a0 = (2d * mu3) - (3d * mu2) + 1d;
            var a1 = mu3 - (2d * mu2) + mu;
            var a2 = mu3 - mu2;
            var a3 = (2d * mu3 * -1d) + (3d * mu2);
            return (a0 * y1) + ((a1 * m0) + ((a2 * m1) + (a3 * y2)));
        }

        /// <summary>
        /// The hermite interpolate.
        /// </summary>
        /// <param name="mu">The mu.</param>
        /// <param name="y0">The y0.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="y3">The y3.</param>
        /// <param name="tension">The tension.</param>
        /// <param name="bias">The bias.</param>
        /// <returns>The <see cref="double"/>.</returns>
        public static double HermiteInterpolate1(double mu, double y0, double y1, double y2, double y3, double tension, double bias)
        {
            var m0 = (y1 - y0) * ((1d + bias) * ((1d - tension) / 2d));
            m0 += (y2 - y1) * ((1d - bias) * ((1d - tension) / 2d));
            var m1 = (y2 - y1) * ((1d + bias) * ((1d - tension) / 2d));
            m1 += (y3 - y2) * ((1d - bias) * ((1d - tension) / 2d));
            var mu2 = mu * mu;
            var mu3 = mu2 * mu;
            var a0 = (2d * mu3) - (3d * mu2) + 1d;
            var a1 = mu3 - (2d * mu2) + mu;
            var a2 = mu3 - mu2;
            var a3 = (2d * mu3 * -1d) + (3d * mu2);

            return (a0 * y1) + ((a1 * m0) + ((a2 * m1) + (a3 * y2)));
        }
    }
}
