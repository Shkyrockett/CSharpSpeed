﻿using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The interpolate elliptical arc tests class.
    /// </summary>
    [DisplayName("Interpolate Rotated Elliptical Arc Tests")]
    [Description("Find a point on an rotated elliptical arc.")]
    [SourceCodeLocationProvider]
    public static class InterpolateRotatedEllipticalArcTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the angle between Two 3D points.
        /// </summary>
        /// <returns></returns>
        [DisplayName(nameof(InterpolateRotatedEllipticalArcTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0.5d, 0d, 0d, 3d, 4d, 30d.ToRadians(), 0d.ToRadians(), 30d.ToRadians() }, new TestCaseResults(description: "Find the point in the middle of a rotated elliptical arc of 3:4 centered about the origin.", trials: trials, expectedReturnValue:(2.1531054250780892d, 2.1531054250780888d), epsilon: double.Epsilon) },
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
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        /// <param name="angle"></param>
        /// <param name="startAngle"></param>
        /// <param name="sweepAngle"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y) EllipticalArc(double t, double cX, double cY, double r1, double r2, double angle, double startAngle, double sweepAngle)
            => EllipticalArc1(t, cX, cY, r1, r2, angle, startAngle, sweepAngle);

        /// <summary>
        /// Interpolates the Elliptical Arc, corrected for Polar coordinates.
        /// </summary>
        /// <param name="t">Theta of interpolation.</param>
        /// <param name="cX">Center x-coordinate.</param>
        /// <param name="cY">Center y-coordinate.</param>
        /// <param name="r1">The first radius of the Ellipse.</param>
        /// <param name="r2">The second radius of the Ellipse.</param>
        /// <param name="angle">Angle of rotation of Ellipse about it's center.</param>
        /// <param name="startAngle">The angle to start the arc.</param>
        /// <param name="sweepAngle">The difference of the angle to where the arc should end.</param>
        /// <returns>Interpolated point at theta.</returns>
        [DisplayName("Interpolate Unrotated Elliptical Arc 1")]
        [Description("Interpolates the unrotated elliptical Arc.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) EllipticalArc1(
            double t, double cX,
            double cY, double r1,
            double r2,
            double angle, double startAngle,
            double sweepAngle)
        {
            return InterpolateRotatedEllipseTests.Ellipse(EllipticalPolarAngleTests.EllipticalPolarAngle(startAngle + (sweepAngle * t), r1, r2), cX, cY, r1, r2, angle);
        }
    }
}
