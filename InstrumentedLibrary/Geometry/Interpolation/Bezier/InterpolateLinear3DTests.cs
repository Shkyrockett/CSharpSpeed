using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The interpolate linear3d tests class.
    /// </summary>
    [DisplayName("Linear Interpolate Tests")]
    [Description("Find a point on a line.")]
    [SourceCodeLocationProvider]
    public static class InterpolateLinear3DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the linear interpolation point for a value between two 2D points.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(InterpolateLinear3DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 0d, 1d, 1d, 1d, 0.5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:(0.5, 0.5, 0.5), epsilon: double.Epsilon) },
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
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y, double Z) LinearInterpolate3D(double x1, double y1, double z1, double x2, double y2, double z2, double t)
            => LinearInterpolate3D_0(x1, y1, z1, x2, y2, z2, t);

        /// <summary>
        /// Precise method which guarantees v = v1 when t = 1.
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="z1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="z2"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [DisplayName("Linear Interpolate 1")]
        [Description("Simple Linear Interpolation.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) LinearInterpolate3D_0(
            double x1, double y1, double z1,
            double x2, double y2, double z2,
            double t)
        {
            return (((1 - t) * x1) + (t * x2),
                    ((1 - t) * y1) + (t * y2),
                    ((1 - t) * z1) + (t * z2));
        }

        /// <summary>
        /// Imprecise method which does not guarantee v = v1 when t = 1, due to floating-point arithmetic error.
        /// This form may be used when the hardware has a native Fused Multiply-Add instruction.
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="z1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="z2"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://www.cubic.org/docs/bezier.htm
        /// </acknowledgment>
        [DisplayName("Linear Interpolate 2")]
        [Description("Simple Linear Interpolation.")]
        [Acknowledgment("http://www.cubic.org/docs/bezier.htm")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) LinearInterpolate3D_1(
            double x1, double y1, double z1,
            double x2, double y2, double z2,
            double t)
        {
            return (
                x1 + (t * (x2 - x1)),
                y1 + (t * (y2 - y1)),
                z1 + (t * (z2 - z1))
                );
        }

        /// <summary>
        /// simple linear interpolation between two points
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="z1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="z2"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://www.cubic.org/docs/bezier.htm
        /// </acknowledgment>
        [DisplayName("Linear Interpolate 3")]
        [Description("Simple Linear Interpolation.")]
        [Acknowledgment("http://www.cubic.org/docs/bezier.htm")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) LinearInterpolate3D_2(
            double x1, double y1, double z1,
            double x2, double y2, double z2,
            double t)
        {
            return (
                InterpolateLinear1DTests.LinearInterpolate1D(x1, x2, t),
                InterpolateLinear1DTests.LinearInterpolate1D(y1, y2, t),
                InterpolateLinear1DTests.LinearInterpolate1D(z1, z2, t)
                );
        }

        /// <summary>
        /// The linear interpolate3d 3.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="z1">The z1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="z2">The z2.</param>
        /// <param name="t">The t.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        [DisplayName("Linear Interpolate 4")]
        [Description("Simple Linear Interpolation.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) LinearInterpolate3D_3(
            double x1, double y1, double z1,
            double x2, double y2, double z2,
            double t)
        {
            return (
                (Abs(x1 - x2) < DoubleEpsilon) ? 0 : x1 - (1 / (x1 - x2) * t),
                (Abs(y1 - y2) < DoubleEpsilon) ? 0 : y1 - (1 / (y1 - y2) * t),
                (Abs(z1 - z2) < DoubleEpsilon) ? 0 : z1 - (1 / (z1 - z2) * t)
                );
        }
    }
}
