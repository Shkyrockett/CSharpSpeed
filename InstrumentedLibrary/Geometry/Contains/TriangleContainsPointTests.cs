﻿using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The triangle tests class.
    /// </summary>
    [DisplayName("Point in Triangle")]
    [Description("Determine whether a point is contained within a Triangle.")]
    [SourceCodeLocationProvider]
    public static class TriangleContainsPointTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(TriangleContainsPointTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 2d, 0d, 2d, 2d, 1d, 1d }, new TestCaseResults(description: "triangle contains point.", trials: trials, expectedReturnValue: Inclusions.Inside, epsilon: double.Epsilon) },
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
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool TriangleContainsPoint(double x1, double y1, double x2, double y2, double x3, double y3, double x, double y)
            => TriangleContainsPoint1(x1, y1, x2, y2, x3, y3, x, y);

        /// <summary>
        /// Return true iff point (x, y) in the triangle
        /// described by the last six parameters.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="x3">The x3.</param>
        /// <param name="y3">The y3.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DisplayName("Point in Triangle")]
        [Description("Determine whether a point is contained within a Triangle.")]
        [Acknowledgment("https://www.khanacademy.org/cs/p/5211412870725632")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TriangleContainsPoint1(double x1, double y1, double x2, double y2, double x3, double y3, double x, double y)
        {
            var tri = new List<(double X, double Y)> { (x1, y1), (x2, y2), (x3, y3) };
            return PolygonContourContainsPointTests.PolygonContourContainsPoint(tri, x, y);
        }
    }
}
