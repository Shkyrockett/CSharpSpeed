﻿using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The interpolate cubic bezier2d tests class.
    /// </summary>
    [DisplayName("Cubic Bezier Interpolate 2D Tests")]
    [Description("Find a point on a 2D Cubic Bezier curve.")]
    [SourceCodeLocationProvider]
    public static class BezierInterpolateCubic2DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 2D cubic interpolation of a point.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(BezierInterpolateCubic2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 1d, 1d, 2d, 1d, 3d, 0d, 0.5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (1.5d, 0.75d), epsilon: double.Epsilon) },
                { new object[] { 0d, 1d, 2d, 3d, 4d, 5d, 6d, 7d, 0.5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (3d, 4d), epsilon: double.Epsilon) },
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
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y) CubicBezierInterpolate2D(double x0, double y0, double x1, double y1, double x2, double y2, double x3, double y3, double t)
            => CubicBezierInterpolate2D_0(x0, y0, x1, y1, x2, y2, x3, y3, t);

        /// <summary>
        /// Four control point Bezier interpolation mu ranges from 0 to 1, start to end of curve.
        /// </summary>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [DisplayName("Cubic Bezier Interpolate 1")]
        [Description("Simple Cubic Bezier Interpolation.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) CubicBezierInterpolate2D_0(
            double x0, double y0,
            double x1, double y1,
            double x2, double y2,
            double x3, double y3,
            double t)
        {
            var mum1 = 1d - t;
            var mum13 = mum1 * mum1 * mum1;
            var mu3 = t * t * t;

            return (
                (mum13 * x0) + (3d * t * mum1 * mum1 * x1) + (3d * t * t * mum1 * x2) + (mu3 * x3),
                (mum13 * y0) + (3d * t * mum1 * mum1 * y1) + (3d * t * t * mum1 * y2) + (mu3 * y3)
                );
        }

        /// <summary>
        /// Calculate parametric value of x or y given t and the four point
        /// coordinates of a cubic bezier curve. This is a separate function
        /// because we need it for both x and y values.
        /// </summary>
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <param name="dX"></param>
        /// <param name="dY"></param>
        /// <param name="t"></param>
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
        public static (double X, double Y) CubicBezierInterpolate2D_1(
        double aX, double aY,
        double bX, double bY,
        double cX, double cY,
        double dX, double dY,
        double t)
        {
            // Formula from Wikipedia article on Bézier curves.
            return (
                (aX * (1d - t) * (1d - t) * (1d - t)) + (3d * bX * (1d - t) * (1d - t) * t) + (3d * cX * (1d - t) * t * t) + (dX * t * t * t),
                (aY * (1d - t) * (1d - t) * (1d - t)) + (3d * bY * (1d - t) * (1d - t) * t) + (3d * cY * (1d - t) * t * t) + (dY * t * t * t)
                );
        }

        /// <summary>
        /// evaluate a point on a bezier-curve. t goes from 0 to 1.0
        /// </summary>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://www.cubic.org/docs/bezier.htm
        /// </acknowledgment>
        [DisplayName("Cubic Bezier Interpolate 3")]
        [Description("Simple Cubic Bezier Interpolation.")]
        [Acknowledgment("http://www.cubic.org/docs/bezier.htm")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) CubicBezierInterpolate2D_2(
            double x0, double y0,
            double x1, double y1,
            double x2, double y2,
            double x3, double y3,
            double t)
        {
            // point between a and b
            (var abX, var abY) = InterpolateLinear2DTests.LinearInterpolate2D(x0, y0, x1, y1, t);
            // point between b and c
            (var bcX, var bcY) = InterpolateLinear2DTests.LinearInterpolate2D(x1, y1, x2, y2, t);
            // point between c and d
            (var cdX, var cdY) = InterpolateLinear2DTests.LinearInterpolate2D(x2, y2, x3, y3, t);
            // point between ab and bc
            (var abbcX, var abbcY) = InterpolateLinear2DTests.LinearInterpolate2D(abX, abY, bcX, bcY, t);
            // point between bc and cd
            (var bccdX, var bccdY) = InterpolateLinear2DTests.LinearInterpolate2D(bcX, bcY, cdX, cdY, t);
            // point on the bezier-curve
            return InterpolateLinear2DTests.LinearInterpolate2D(abbcX, abbcY, bccdX, bccdY, t);
        }

        /// <summary>
        /// Function to Plot a Cubic Bezier
        /// </summary>
        /// <param name="aX">the starting point, or A in the above diagram</param>
        /// <param name="aY">the starting point, or A in the above diagram</param>
        /// <param name="bX">the first control point, or B</param>
        /// <param name="bY">the first control point, or B</param>
        /// <param name="cX">the second control point, or C</param>
        /// <param name="cY">the second control point, or C</param>
        /// <param name="dX">the end point, or D</param>
        /// <param name="dY">the end point, or D</param>
        /// <param name="t"></param>
        /// <returns></returns>
        [DisplayName("Cubic Bezier Interpolate 4")]
        [Description("Simple Cubic Bezier Interpolation.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) CubicBezierInterpolate2D_3(
            double aX, double aY,
            double bX, double bY,
            double cX, double cY,
            double dX, double dY,
            double t)
        {
            var v = 1d - t;
            return (
                (aX * v * v * v) + (3 * bX * t * v * v) + (3 * cX * t * t * v) + (dX * v * v * v),
                (aY * v * v * v) + (3 * bY * t * v * v) + (3 * cY * t * t * v) + (dY * v * v * v));
        }

        /// <summary>
        /// The interpolate cubic.
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
        /// <returns>The <see cref="T:(double X, double Y)"/>.</returns>
        /// <acknowledgment>
        /// https://groups.google.com/d/msg/comp.graphics.algorithms/SRm97nRWlw4/R1Rn38ep8n0J
        /// </acknowledgment>
        [DisplayName("Cubic Bezier Interpolate 8")]
        [Description("Simple Cubic Bezier Interpolation.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) InterpolateCubic(double x0, double y0, double x1, double y1, double x2, double y2, double x3, double y3, double t)
        {
            return (
                (-(t * t * t) * (x0 - (3 * x1) + (3 * x2) - x3)) + (3 * t * t * (x0 - (2 * x1) + x2)) + (3 * t * (x1 - x0)) + x0,
                (-(t * t * t) * (y0 - (3 * y1) + (3 * y2) - y3)) + (3 * t * t * (y0 - (2 * y1) + y2)) + (3 * t * (y1 - y0)) + y0
                );
        }

        /// <summary>
        /// The cubic bezier curve.
        /// </summary>
        /// <param name="p0X">The p0X.</param>
        /// <param name="p0Y">The p0Y.</param>
        /// <param name="p1X">The p1X.</param>
        /// <param name="p1Y">The p1Y.</param>
        /// <param name="p2X">The p2X.</param>
        /// <param name="p2Y">The p2Y.</param>
        /// <param name="p3X">The p3X.</param>
        /// <param name="p3Y">The p3Y.</param>
        /// <param name="t">The t.</param>
        /// <returns>The <see cref="T:(double X, double Y)"/>.</returns>
        /// <acknowledgment>
        /// http://en.wikipedia.org/wiki/B%C3%A9zier_curve
        /// </acknowledgment>
        [DisplayName("Cubic Bezier Interpolate 9")]
        [Description("Simple Cubic Bezier Interpolation.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) CubicBezierCurve(double p0X, double p0Y, double p1X, double p1Y, double p2X, double p2Y, double p3X, double p3Y, double t)
        {
            return (
                (Pow(1 - t, 3) * p0X) + (3 * Pow(1 - t, 2) * t * p1X) + (3 * (1 - t) * Pow(t, 2) * p2X) + (Pow(t, 3) * p3X),
                (Pow(1 - t, 3) * p0Y) + (3 * Pow(1 - t, 2) * t * p1Y) + (3 * (1 - t) * Pow(t, 2) * p2Y) + (Pow(t, 3) * p3Y));
        }

        /// <summary>
        /// The cubic bezier curve.
        /// </summary>
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <param name="dX"></param>
        /// <param name="dY"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <returns>The <see cref="T:(double X, double Y)"/>.</returns>
        /// <acknowledgment>
        /// http://jwezorek.com/2015/01/my-code-for-doing-two-things-that-sooner-or-later-you-will-want-to-do-with-bezier-curves/
        /// </acknowledgment>
        [DisplayName("Cubic Bezier Interpolate 9")]
        [Description("Simple Cubic Bezier Interpolation.")]
        [Acknowledgment("http://jwezorek.com/2015/01/my-code-for-doing-two-things-that-sooner-or-later-you-will-want-to-do-with-bezier-curves/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) CubicBezierInterpolateGetPoint(double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY, double t)
        {
            return (
                aX + (t * ((-aX * 3d) + (t * ((3d * aX) - aX * t)))) + (t * ((3d * bX) + (t * ((-6d * bX) + bX * 3d * t)))) + (t * t * (cX * 3d - cX * 3d * t)) + dX * t * t * t,
                aY + (t * ((-aY * 3d) + (t * ((3d * aY) - aY * t)))) + (t * ((3d * bY) + (t * ((-6d * bY) + bY * 3d * t)))) + (t * t * (cY * 3d - cY * 3d * t)) + dY * t * t * t
                );
        }
    }
}