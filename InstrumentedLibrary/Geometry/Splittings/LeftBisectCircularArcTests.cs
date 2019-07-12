﻿using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Left Bisect Circular Arc")]
    [Description("Left Bisect Circular Arc.")]
    [SourceCodeLocationProvider]
    public static class LeftBisectCircularArcTests
    {
        /// <summary>
        /// The polygon centroid test.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(LeftBisectCircularArcTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 1000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 5d, 5d, 5d, 0d, Math.PI, 0.5 }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="radius"></param>
        /// <param name="startAngle"></param>
        /// <param name="sweepAngle"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static CircularArc2D LeftBisectCircularArc(double x, double y, double radius, double startAngle, double sweepAngle, double t)
            => LeftBisectCircularArc1(x, y, radius, startAngle, sweepAngle, t);

        /// <summary>
        /// The split.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="radius"></param>
        /// <param name="startAngle"></param>
        /// <param name="sweepAngle"></param>
        /// <param name="t"></param>
        /// <returns>The <see cref="Array"/>.</returns>
        [DisplayName("Left Bisect Circular Arc")]
        [Description("Left Bisect Circular Arc.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CircularArc2D LeftBisectCircularArc1(double x, double y, double radius, double startAngle, double sweepAngle, double t)
        {
            if (t < 0d || t > 1d)
            {
                throw new ArgumentOutOfRangeException(nameof(t));
            }

            return new CircularArc2D(x, y, radius, startAngle, sweepAngle * t);
        }
    }
}
