using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using static InstrumentedLibrary.Maths;
using System.Runtime.CompilerServices;
using System;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The hermite interpolate2d tests class.
    /// </summary>
    [DisplayName("Cubic Hermite Interpolate Tests")]
    [Description("Find a point on a Hermite curve.")]
    [Signature("public static double HermiteInterpolate2D(double v0, double v1, double v2, double v3, double t)")]
    [SourceCodeLocationProvider]
    public static class HermiteInterpolate2DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 2D Hermite interpolation of points.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(HermiteInterpolate2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 1d, 2d, 3d, 4d, 5d, 6d, 7d, 0.5d, 1d, 0d }, new TestCaseResults(description:"", trials:trials, expectedReturnValue:0.5d, epsilon:DoubleEpsilon) },
            };

            var results = new List<SpeedTester>();
            foreach (var method in ReflectionHelper.ListStaticMethodsWithAttribute(MethodBase.GetCurrentMethod().DeclaringType, typeof(SourceCodeLocationProviderAttribute)))
            {
                var methodDescription = ((DescriptionAttribute)method.GetCustomAttribute(typeof(DescriptionAttribute)))?.Description;
                results.Add(new SpeedTester(method, methodDescription, tests));
            }
            return results;
        }

        /// <summary>
        /// The hermite interpolate2d.
        /// </summary>
        /// <param name="x0">The x0.</param>
        /// <param name="y0">The y0.</param>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="x3">The x3.</param>
        /// <param name="y3">The y3.</param>
        /// <param name="index">The mu.</param>
        /// <param name="tension">1 is high, 0 normal, -1 is low</param>
        /// <param name="bias">0 is even,positive is towards first segment, negative towards the other</param>
        /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
        /// <acknowledgment>
        /// http://paulbourke.net/miscellaneous/interpolation/
        /// </acknowledgment>
        [DisplayName("Hermite Interpolate 2D")]
        [Description("Hermite Interpolation.")]
        [Acknowledgment("http://paulbourke.net/miscellaneous/interpolation/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) HermiteInterpolate2D(
            double x0, double y0,
            double x1, double y1,
            double x2, double y2,
            double x3, double y3,
            double index, double tension, double bias)
        {
            var mu2 = index * index;
            var mu3 = mu2 * index;

            var mX0 = (x1 - x0) * (1d + bias) * (1d - tension) * 0.5d;
            mX0 += (x2 - x1) * (1d - bias) * (1d - tension) * 0.5d;
            var mY0 = (y1 - y0) * (1d + bias) * (1d - tension) * 0.5d;
            mY0 += (y2 - y1) * (1d - bias) * (1d - tension) * 0.5d;
            var mX1 = (x2 - x1) * (1d + bias) * (1d - tension) * 0.5d;
            mX1 += (x3 - x2) * (1d - bias) * (1d - tension) * 0.5d;
            var mY1 = (y2 - y1) * (1d + bias) * (1d - tension) * 0.5d;
            mY1 += (y3 - y2) * (1d - bias) * (1d - tension) * 0.5d;
            var a0 = 2d * mu3 - 3d * mu2 + 1d;
            var a1 = mu3 - 2d * mu2 + index;
            var a2 = mu3 - mu2;
            var a3 = -2d * mu3 + 3d * mu2;

            return (
                a0 * x1 + a1 * mX0 + a2 * mX1 + a3 * x2,
                a0 * y1 + a1 * mY0 + a2 * mY1 + a3 * y2);
        }

        /// <summary>
        /// Tension: 1 is high, 0 normal, -1 is low
        /// Bias: 0 is even,
        /// positive is towards First segment,
        /// negative towards the other
        /// </summary>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <param name="index"></param>
        /// <param name="tension"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        [DisplayName("Hermite Interpolate 2D")]
        [Description("Hermite Interpolation.")]
        [Acknowledgment("http://paulbourke.net/miscellaneous/interpolation/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) Interpolate1(
            double x0, double y0,
            double x1, double y1,
            double x2, double y2,
            double x3, double y3,
            double index, double tension, double bias)
        {
            var a = new Point2D(x0, y0);
            var aTan = new Point2D(x1, y1);
            var b = new Point2D(x2, y2);
            var bTan = new Point2D(x3, y3);
            //double mu2 = mu * mu;
            //double mu3 = mu2 * mu;
            //Point2D m0 = (y1 - y0) * (1 + bias) * (1 - tension) * 0.5;
            //m0 += (y2 - y1) * (1 - bias) * (1 - tension) * 0.5;
            //Point2D m1 = (y2 - y1) * (1 + bias) * (1 - tension) * 0.5;
            //m1 += (y3 - y2) * (1 - bias) * (1 - tension) * 0.5;
            //double a0 = 2 * mu3 - 3 * mu2 + 1;
            //double a1 = mu3 - 2 * mu2 + mu;
            //double a2 = mu3 - mu2;
            //double a3 = -2 * mu3 + 3 * mu2;
            //return (a0 * y1 + a1 * m0 + a2 * m1 + a3 * y2);
            var mu2 = index * index;
            var mu3 = mu2 * index;
            var m0 = aTan - (a * (1d + bias * (1d - tension) * 0.5d));
            m0 = m0 + (b - (aTan * (1d - bias) * (1d - tension) * 0.5d));
            var m1 = b - aTan * (1d + bias) * (1d - tension) * 0.5d;
            m1 = m1 + (bTan - b * (1d - bias) * (1d - tension) * 0.5d);
            var a0 = 2d * mu3 - 3d * mu2 + 1d;
            var a1 = mu3 - 2d * mu2 + index;
            var a2 = mu3 - mu2;
            var a3 = -2d * mu3 + 3d * mu2;
            var result = aTan * a0 + (m0 * a1) + (m1 * a2) + (b * a3);
            return (result.I, result.J);
        }

        /// <summary>
        /// Tension: 1 is high, 0 normal, -1 is low
        /// Bias: 0 is even,
        /// positive is towards First segment,
        /// negative towards the other
        /// </summary>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <param name="index"></param>
        /// <param name="tension"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        [DisplayName("Hermite Interpolate 2D")]
        [Description("Hermite Interpolation.")]
        [Acknowledgment("http://paulbourke.net/miscellaneous/interpolation/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) Interpolate2(
            double x0, double y0,
            double x1, double y1,
            double x2, double y2,
            double x3, double y3,
            double index, double tension, double bias)
        {
            var a = new Point2D(x0, y0);
            var aTan = new Point2D(x1, y1);
            var b = new Point2D(x2, y2);
            var bTan = new Point2D(x3, y3);
            var t2 = index * index;
            var t3 = t2 * index;
            var tb = (1d + bias) * ((1d - tension) / 2d);
            var ret = aTan * ((2d * t3) - (3d * t2) + 1d) + (aTan - a + ((b - aTan) * (t3 - (2d * t2) + index)) + (b - aTan + ((bTan - b) * (t3 - t2))) * tb + (b * ((3d * t2) - (2d * t3))));
            return (ret.I, ret.J);
        }
    }
}
