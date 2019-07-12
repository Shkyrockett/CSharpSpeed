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
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(InterpolateLinear3DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0.5d, 0d, 0d, 0d, 1d, 1d, 1d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:(0.5, 0.5, 0.5), epsilon: double.Epsilon) },
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
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="z1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="z2"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y, double Z) LinearInterpolate3D(double t, double x1, double y1, double z1, double x2, double y2, double z2)
            => LinearInterpolate3D0(t, x1, y1, z1, x2, y2, z2);

        /// <summary>
        /// Precise method which guarantees v = v1 when t = 1.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="z1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="z2"></param>
        /// <returns></returns>
        [DisplayName("Linear Interpolate 1")]
        [Description("Simple Linear Interpolation.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) LinearInterpolate3D0(double t, double x1, double y1, double z1, double x2, double y2, double z2)
        {
            return (((1d - t) * x1) + (t * x2),
                    ((1d - t) * y1) + (t * y2),
                    ((1d - t) * z1) + (t * z2));
        }

        /// <summary>
        /// Imprecise method which does not guarantee v = v1 when t = 1, due to floating-point arithmetic error.
        /// This form may be used when the hardware has a native Fused Multiply-Add instruction.
        /// </summary>
        /// <param name="t"></param>
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
        [DisplayName("Linear Interpolate 2")]
        [Description("Simple Linear Interpolation.")]
        [Acknowledgment("http://www.cubic.org/docs/bezier.htm")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) LinearInterpolate3D1(double t, double x1, double y1, double z1, double x2, double y2, double z2)
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
        /// <param name="t"></param>
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
        [DisplayName("Linear Interpolate 3")]
        [Description("Simple Linear Interpolation.")]
        [Acknowledgment("http://www.cubic.org/docs/bezier.htm")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) LinearInterpolate3D2(double t, double x1, double y1, double z1, double x2, double y2, double z2)
        {
            return (
                InterpolateLinear1DTests.LinearInterpolate1D(t, x1, x2),
                InterpolateLinear1DTests.LinearInterpolate1D(t, y1, y2),
                InterpolateLinear1DTests.LinearInterpolate1D(t, z1, z2)
                );
        }

        /// <summary>
        /// The linear interpolate3d 3.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="z1">The z1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="z2">The z2.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        [DisplayName("Linear Interpolate 4")]
        [Description("Simple Linear Interpolation.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) LinearInterpolate3D3(
            double t, double x1, double y1,
            double z1, double x2, double y2,
            double z2)
        {
            return (
                (Abs(x1 - x2) < DoubleEpsilon) ? 0d : x1 - (1d / (x1 - x2) * t),
                (Abs(y1 - y2) < DoubleEpsilon) ? 0d : y1 - (1d / (y1 - y2) * t),
                (Abs(z1 - z2) < DoubleEpsilon) ? 0d : z1 - (1d / (z1 - z2) * t)
                );
        }
    }
}
