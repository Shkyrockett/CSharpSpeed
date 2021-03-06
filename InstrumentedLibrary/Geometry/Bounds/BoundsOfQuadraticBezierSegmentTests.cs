﻿using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The bounds of quadratic bezier segment tests class.
    /// </summary>
    [DisplayName("Quadratic Bezier Segment Bounds Tests")]
    [Description("Calculate bounding rectangle of a Quadratic bezier curve segment.")]
    [SourceCodeLocationProvider]
    public static class BoundsOfQuadraticBezierSegmentTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(BoundsOfQuadraticBezierSegmentTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 5d, 10d, 15d, 30d, 5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: new Rectangle2D(0d, 5d, 26.1d, 5d), epsilon: double.Epsilon) },
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
        /// <param name="ax"></param>
        /// <param name="ay"></param>
        /// <param name="bx"></param>
        /// <param name="by"></param>
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Rectangle2D QuadraticBezierBounds(double ax, double ay, double bx, double by, double cx, double cy)
            => QuadraticBezierBounds0(ax, ay, bx, by, cx, cy);

        /// <summary>
        /// The quadratic bezier bounds.
        /// </summary>
        /// <param name="ax">The starting x-coordinate for the Quadratic Bezier curve.</param>
        /// <param name="ay">The starting y-coordinate for the Quadratic Bezier curve.</param>
        /// <param name="bx">The middle x-coordinate for the tangent control node for the Quadratic Bezier curve.</param>
        /// <param name="by">The middle y-coordinate for the tangent control node for the Quadratic Bezier curve.</param>
        /// <param name="cx">The closing x-coordinate for the Quadratic Bezier curve.</param>
        /// <param name="cy">The closing y-coordinate for the Quadratic Bezier curve.</param>
        /// <returns>The <see cref="Rectangle2D"/>.</returns>
        [DisplayName("Quadratic Bezier Bounds")]
        [Description("Find bounds of a Quadratic Bezier.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rectangle2D QuadraticBezierBounds0(
            double ax, double ay,
            double bx, double by,
            double cx, double cy)
        {
            var sortOfCloseLength = QuadraticBezierSegmentLengthTests.QuadraticBezierArcLength(ax, ay, bx, by, cx, cy);

            // ToDo: Need to make this more efficient. Don't need to rebuild the point array every time.
            var points = new List<(double X, double Y)>(FunctionalInterpolationTests.Interpolate0to1((int)(sortOfCloseLength / 3), (i) => InterpolateBezierQuadratic2DTests.QuadraticBezierInterpolate2D(i, ax, ay, bx, by, cx, cy)));

            var left = points[0].X;
            var top = points[0].Y;
            var right = points[0].X;
            var bottom = points[0].Y;

            foreach (var (X, Y) in points)
            {
                // ToDo: Measure performance impact of overwriting each time.
                left = X <= left ? X : left;
                top = Y <= top ? Y : top;
                right = X >= right ? X : right;
                bottom = Y >= bottom ? Y : bottom;
            }

            return Rectangle2D.FromLTRB(left, top, right, bottom);
        }

        ///// <summary>
        ///// Calculates the Axis Aligned Bounding Box (AABB) rectangle of a Quadratic Bézier curve.
        ///// </summary>
        ///// <param name="ax">The x-component of the starting point.</param>
        ///// <param name="ay">The y-component of the starting point.</param>
        ///// <param name="bx">The x-component of the handle point.</param>
        ///// <param name="by">The y-component of the handle point.</param>
        ///// <param name="cx">The x-component of the end point.</param>
        ///// <param name="cy">The y-component of the end point.</param>
        ///// <returns>Returns an Axis Aligned Bounding Box (AABB) rectangle that bounds the Quadratic Bézier curve.</returns>
        ///// <acknowledgment></acknowledgment>
        ///// <acknowledgment>
        ///// http://stackoverflow.com/questions/24809978/calculating-the-bounding-box-of-cubic-bezier-curve
        ///// http://jsfiddle.net/SalixAlba/QQnvm/4/
        ///// </acknowledgment>
        //[DebuggerStepThrough]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static Rectangle2D QuadraticBezierBounds(
        //    double ax, double ay,
        //    double bx, double by,
        //    double cx, double cy)
        //{
        //    var cubic = Conversions.QuadraticBezierToCubicBezier(ax, ay, bx, by, cx, cy);
        //    return CubicBezierBounds(cubic[0].X, cubic[0].Y, cubic[1].X, cubic[1].Y, cubic[2].X, cubic[2].Y, cubic[3].X, cubic[3].Y);
        //}
    }
}
