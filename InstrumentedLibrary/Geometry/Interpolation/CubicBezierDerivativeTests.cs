﻿using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The cubic bezier derivative tests class.
    /// </summary>
    [DisplayName("Cubic Bezier Derivative Tests")]
    [Description("Cubic Bezier Derivative.")]
    [Signature("public static double TripointCircleBounds(double aX, double aY, double bX, double bY, double cX, double cY)")]
    [SourceCodeLocationProvider]
    public static class CubicBezierDerivativeTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(CubicBezierDerivativeTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 1d, 1d, 2d, 1d, 3d, 0d, 0.5d }, new TestCaseResults(description:"", trials:trials, expectedReturnValue:true, epsilon:double.Epsilon) },
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
        /// The cubic bezier derivative0.
        /// </summary>
        /// <param name="p0X"></param>
        /// <param name="p0Y"></param>
        /// <param name="p1X"></param>
        /// <param name="p1Y"></param>
        /// <param name="p2X"></param>
        /// <param name="p2Y"></param>
        /// <param name="p3X"></param>
        /// <param name="p3Y"></param>
        /// <param name="t">The t.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        /// <acknowledgment>
        /// http://www.cs.mtu.edu/~shene/COURSES/cs3621/NOTES/spline/Bezier/bezier-der.html
        /// </acknowledgment>
        [DisplayName("Cubic Bezier Derivative Tests")]
        [Description("Cubic Bezier Derivative.")]
        [Acknowledgment("http://www.cs.mtu.edu/~shene/COURSES/cs3621/NOTES/spline/Bezier/bezier-der.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        public static (double X, double Y) CubicBezierDerivative0(
            double p0X, double p0Y,
            double p1X, double p1Y,
            double p2X, double p2Y,
            double p3X, double p3Y,
            double t)
        {
            return (
                3d * Pow(1d - t, 2d) * (p1X - p0X) + 6d * (1d - t) * t * (p2X - p1X) + 3d * Pow(t, 2d) * (p3X - p2X),
                3d * Pow(1d - t, 2d) * (p1Y - p0Y) + 6d * (1d - t) * t * (p2Y - p1Y) + 3d * Pow(t, 2d) * (p3Y - p2Y)
                );
        }

        /// <summary>
        /// The cubic bezier derivative1.
        /// </summary>
        /// <param name="p0X"></param>
        /// <param name="p0Y"></param>
        /// <param name="p1X"></param>
        /// <param name="p1Y"></param>
        /// <param name="p2X"></param>
        /// <param name="p2Y"></param>
        /// <param name="p3X"></param>
        /// <param name="p3Y"></param>
        /// <param name="t">The t.</param>
        /// <returns>The <see cref="PointF"/>.</returns>
        /// <acknowledgment>
        /// http://www.cs.mtu.edu/~shene/COURSES/cs3621/NOTES/spline/Bezier/bezier-der.html
        /// </acknowledgment>
        [DisplayName("Cubic Bezier Derivative Tests")]
        [Description("Cubic Bezier Derivative.")]
        [Acknowledgment("http://www.cs.mtu.edu/~shene/COURSES/cs3621/NOTES/spline/Bezier/bezier-der.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        public static (double X, double Y) CubicBezierDerivative1(
            double p0X, double p0Y,
            double p1X, double p1Y,
            double p2X, double p2Y,
            double p3X, double p3Y,
            double t)
        {
            var mu1 = 1d - t;
            var mu12 = mu1 * mu1;
            var mu2 = t * t;

            return (
                3d * mu12 * (p1X - p0X) + 6d * mu1 * t * (p2X - p1X) + 3d * mu2 * (p3X - p2X),
                3d * mu12 * (p1Y - p0Y) + 6d * mu1 * t * (p2Y - p1Y) + 3d * mu2 * (p3Y - p2Y)
                );
        }
    }
}
