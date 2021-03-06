﻿using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Right Bisect Line Segment")]
    [Description("Right Bisect Line Segment.")]
    [SourceCodeLocationProvider]
    public static class RightBisectLineSegmentTests
    {
        /// <summary>
        /// The polygon centroid test.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(RightBisectLineSegmentTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 1000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 5d, 5d, 0.5d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static IShapeSegment RightBisectLineSegment(double aX, double aY, double bX, double bY, double t)
            => RightBisectLineSegment1(aX, aY, bX, bY, t);

        /// <summary>
        /// The split.
        /// </summary>
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        [DisplayName("Right Bisect Line Segment")]
        [Description("Right Bisect Line Segment.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IShapeSegment RightBisectLineSegment1(double aX, double aY, double bX, double bY, double t)
        {
            if (t <= 0d)
            {
                return new LineSegment2D(aX, aY, bX, bY);
            }

            if (t >= 1d)
            {
                return new Point2D(bX, bY);
            }

            var (cX, cY) = InterpolateLinear2DTests.LinearInterpolate2D(t, aX, aY, bX, bY);

            return new LineSegment2D(cX, cY, bX, bY);
        }
    }
}
