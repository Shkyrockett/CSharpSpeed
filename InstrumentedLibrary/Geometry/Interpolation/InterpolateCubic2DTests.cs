using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The interpolate cubic2d tests class.
    /// </summary>
    [DisplayName("Cubic Interpolate 2D Tests")]
    [Description("Find a point on a 2D Cubic curve.")]
    [SourceCodeLocationProvider]
    public static class InterpolateCubic2DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 2D cubic interpolation of a point.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(InterpolateCubic2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0.5d, 0d, 0d, 1d, 1d, 2d, 1d, 3d, 0d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (1.5d, 1.25d), epsilon: double.Epsilon) },
                { new object[] { 0.5d, 0d, 1d, 2d, 3d, 4d, 5d, 6d, 7d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:(3d, 4d), epsilon: double.Epsilon) },
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
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y) CubicInterpolate2D(double t, double x0, double y0, double x1, double y1, double x2, double y2, double x3, double y3)
            => CubicInterpolate2D1(t, x0, y0, x1, y1, x2, y2, x3, y3);

        /// <summary>
        /// The cubic interpolate2d.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="x0">The x0.</param>
        /// <param name="y0">The y0.</param>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="x3">The x3.</param>
        /// <param name="y3">The y3.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
        /// <acknowledgment>
        /// http://paulbourke.net/miscellaneous/interpolation/
        /// </acknowledgment>
        [DisplayName("Cubic Interpolate 1")]
        [Description("Simple Cubic Interpolation.")]
        [Acknowledgment("http://paulbourke.net/miscellaneous/interpolation/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) CubicInterpolate2D1(double t, double x0, double y0, double x1, double y1, double x2, double y2, double x3, double y3)
        {
            var mu2 = t * t;

            var aX0 = x3 - x2 - x0 + x1;
            var aY0 = y3 - y2 - y0 + y1;
            var aX1 = x0 - x1 - aX0;
            var aY1 = y0 - y1 - aY0;
            var aX2 = x2 - x0;
            var aY2 = y2 - y0;

            return (
                (aX0 * t * mu2) + (aX1 * mu2) + (aX2 * t) + x1,
                (aY0 * t * mu2) + (aY1 * mu2) + (aY2 * t) + y1);
        }

        /// <summary>
        /// The cubic bezier interpolate2d 4.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="aX">The aX.</param>
        /// <param name="aY">The aY.</param>
        /// <param name="bX">The bX.</param>
        /// <param name="bY">The bY.</param>
        /// <param name="cX">The cX.</param>
        /// <param name="cY">The cY.</param>
        /// <param name="dX">The dX.</param>
        /// <param name="dY">The dY.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
        [DisplayName("Cubic Bezier Interpolate 5")]
        [Description("Simple Cubic Bezier Interpolation.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) CubicBezierInterpolate2D4(double t, double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY)
        {
            //(double X, double Y) P = (v3 - v2) - (v0 - v1);
            //(double X, double Y) Q = (v0 - v1) - P;
            //(double X, double Y) R = v2 - v0;
            //(double X, double Y) S = v1;
            //(double X, double Y) P * Pow(x, 3) + Q * Pow(x, 2) + R * x + S;
            var PX = dX - cX - (aX - bX);
            var PY = dY - cY - (aY - bY);
            var QX = aX - bX - PX;
            var QY = aY - bY - PY;
            var RX = cX - aX;
            var RY = cY - aY;
            var SX = bX;
            var SY = bY;
            return (
                (PX * (t * t * t)) + (QX * (t * t)) + (RX * t) + SX,
                (PY * (t * t * t)) + (QY * (t * t)) + (RY * t) + SY);
        }
    }
}
