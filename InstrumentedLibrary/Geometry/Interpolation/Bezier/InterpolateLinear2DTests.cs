﻿using CSharpSpeed;
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
    /// The interpolate linear2d tests class.
    /// </summary>
    [DisplayName("Linear Interpolate Tests")]
    [Description("Find a point on a line.")]
    [SourceCodeLocationProvider]
    public static class InterpolateLinear2DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the linear interpolation point for a value between two 2D points.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(InterpolateLinear2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 1d, 1d, 0d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:(0d, 0d), epsilon: double.Epsilon) },
                { new object[] { 0d, 0d, 1d, 1d, 0.5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:(0.5d, 0.5d), epsilon: double.Epsilon) },
                { new object[] { 0d, 0d, 1d, 1d, 1d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:(1d, 1d), epsilon: double.Epsilon) },
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
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y) LinearInterpolate2D(double x0, double y0, double x1, double y1, double t)
            => Lerp_(x0, y0, x1, y1, t);

        /// <summary>
        /// The linear interpolation method.
        /// </summary>
        /// <param name="x0">The x0.</param>
        /// <param name="y0">The y0.</param>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="t">The t.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
        [DisplayName("Lerp")]
        [Description("Simple Linear Interpolation.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) Lerp_(
            double x0, double y0,
            double x1, double y1,
            double t)
        {
            return (x0 + (x1 - x0) * t, y0 + (y1 - y0) * t);
        }

        /// <summary>
        /// Precise method which guarantees v = v1 when t = 1.
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://en.wikipedia.org/wiki/Linear_interpolation
        /// http://jwezorek.com/2015/01/my-code-for-doing-two-things-that-sooner-or-later-you-will-want-to-do-with-bezier-curves/
        /// </acknowledgment>
        [DisplayName("Linear Interpolate 1")]
        [Description("Simple Linear Interpolation.")]
        [Acknowledgment("https://en.wikipedia.org/wiki/Linear_interpolation", "http://jwezorek.com/2015/01/my-code-for-doing-two-things-that-sooner-or-later-you-will-want-to-do-with-bezier-curves/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) LinearInterpolate2D_0(
            double x1, double y1,
            double x2, double y2,
            double t)
        {
            return (
                ((1d - t) * x1) + (t * x2),
                ((1d - t) * y1) + (t * y2)
                );
        }

        /// <summary>
        /// Imprecise method which does not guarantee v = v1 when t = 1, due to floating-point arithmetic error.
        /// This form may be used when the hardware has a native Fused Multiply-Add instruction.
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://en.wikipedia.org/wiki/Linear_interpolation
        /// http://www.cubic.org/docs/bezier.htm
        /// </acknowledgment>
        [DisplayName("Linear Interpolate 2")]
        [Description("Simple Linear Interpolation.")]
        [Acknowledgment("https://en.wikipedia.org/wiki/Linear_interpolation", "http://www.cubic.org/docs/bezier.htm")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) LinearInterpolate2D_1(
            double x1, double y1,
            double x2, double y2,
            double t)
        {
            return (
                x1 + (t * (x2 - x1)),
                y1 + (t * (y2 - y1))
                );
        }

        /// <summary>
        /// simple linear interpolation between two points
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
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
        public static (double X, double Y) LinearInterpolate2D_2(
            double x1, double y1,
            double x2, double y2,
            double t)
        {
            return (
                InterpolateLinear1DTests.LinearInterpolate1D(x1, x2, t),
                InterpolateLinear1DTests.LinearInterpolate1D(y1, y2, t)
                );
        }

        /// <summary>
        /// The linear interpolate2d 3.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="t">The t.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
        [DisplayName("Linear Interpolate 4")]
        [Description("Simple Linear Interpolation.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) LinearInterpolate2D_3(
            double x1, double y1,
            double x2, double y2,
            double t)
        {
            return (
                (Abs(x1 - x2) < DoubleEpsilon) ? 0 : x1 - (1 / (x1 - x2) * t),
                (Abs(y1 - y2) < DoubleEpsilon) ? 0 : y1 - (1 / (y1 - y2) * t)
                );
        }
    }
}