﻿using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The unrotated elliptical arc line segment intersection tests class.
    /// </summary>
    [DisplayName("Intersection of unrotated elliptical arc and line segment")]
    [Description("Find the intersection points between unrotated elliptical and arc line segment.")]
    [Signature("public static Intersection UnrotatedEllipticalArcLineSegmentIntersection(double cx, double cy, double rx, double ry, double startAngle, double sweepAngle, double x0, double y0, double x1, double y1, double epsilon = Epsilon)")]
    [SourceCodeLocationProvider]
    public static class UnrotatedEllipticalArcLineSegmentIntersectionTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(UnrotatedEllipticalArcLineSegmentIntersectionTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 2d, 2d, Maths.ToRadians(0d), Maths.ToRadians(45d), 2d, 2d, 1d, 1d, Epsilon }, new TestCaseResults(description:"Line Segment Line Segment intersection.", trials:trials, expectedReturnValue:new Intersection(), epsilon:double.Epsilon) },
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
        /// 
        /// </summary>
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        /// <param name="rx"></param>
        /// <param name="ry"></param>
        /// <param name="startAngle"></param>
        /// <param name="sweepAngle"></param>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Intersection UnrotatedEllipticalArcLineSegmentIntersection(double cx, double cy, double rx, double ry, double startAngle, double sweepAngle, double x0, double y0, double x1, double y1, double epsilon = Epsilon)
            => UnrotatedEllipticalArcLineSegmentIntersection0(cx, cy, rx, ry, startAngle, sweepAngle, x0, y0, x1, y1, epsilon);

        /// <summary>
        /// The unrotated elliptical arc line segment intersection.
        /// </summary>
        /// <param name="cx">The cx.</param>
        /// <param name="cy">The cy.</param>
        /// <param name="rx">The rx.</param>
        /// <param name="ry">The ry.</param>
        /// <param name="startAngle">The startAngle.</param>
        /// <param name="sweepAngle">The sweepAngle.</param>
        /// <param name="x0">The x0.</param>
        /// <param name="y0">The y0.</param>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="epsilon"></param>
        /// <returns>The <see cref="Intersection"/>.</returns>
        /// <acknowledgment>
        /// http://www.kevlindev.com/
        /// </acknowledgment>
        [DisplayName("Intersection of unrotated elliptical arc and line segment")]
        [Description("Find the intersection points between unrotated elliptical and arc line segment.")]
        [Acknowledgment("http://www.kevlindev.com/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection UnrotatedEllipticalArcLineSegmentIntersection0(
            double cx, double cy,
            double rx, double ry,
            double startAngle, double sweepAngle,
            double x0, double y0,
            double x1, double y1, double epsilon = Epsilon)
        {
            // Initialize the resulting intersection structure.
            var result = new Intersection(IntersectionState.NoIntersection);

            // Translate the line to put the ellipse centered at the origin.
            var origin = new Vector2D(x0, y0);
            var dir = new Vector2D(x0, y0, x1, y1);
            var diff = origin - new Vector2D(cx, cy);
            var mDir = new Vector2D(dir.I / (rx * rx), dir.J / (ry * ry));
            var mDiff = new Vector2D(diff.I / (rx * rx), diff.J / (ry * ry));

            // Calculate the quadratic parameters.
            var a = DotProduct2Vector2DTests.DotProduct2D(dir.I, dir.J, mDir.I, mDir.J);
            var b = DotProduct2Vector2DTests.DotProduct2D(dir.I, dir.J, mDiff.I, mDiff.J);
            var c = DotProduct2Vector2DTests.DotProduct2D(diff.I, diff.J, mDiff.I, mDiff.J) - 1d;

            // Calculate the discriminant of the quadratic. The 4 is omitted.
            var discriminant = b * b - a * c;

            // Check whether line segment is outside of the ellipse.
            if (discriminant < 0)
            {
                return new Intersection(IntersectionState.Outside);
            }

            // Find the start and end angles.
            var sa = EllipticalPolarAngleTests.EllipticalPolarAngle(startAngle, rx, ry);
            var ea = EllipticalPolarAngleTests.EllipticalPolarAngle(startAngle + sweepAngle, rx, ry);

            // Get the ellipse rotation transform.
            var cosT = Cos(0);
            var sinT = Sin(0);

            // Ellipse equation for an ellipse at origin for the chord end points.
            var u1 = rx * Cos(sa);
            var v1 = -(ry * Sin(sa));
            var u2 = rx * Cos(ea);
            var v2 = -(ry * Sin(ea));

            // Find the points of the chord.
            var sX = cx + (u1 * cosT + v1 * sinT);
            var sY = cy + (u1 * sinT - v1 * cosT);
            var eX = cx + (u2 * cosT + v2 * sinT);
            var eY = cy + (u2 * sinT - v2 * cosT);

            if (discriminant > 0)
            {
                // Two real possible solutions.
                var root = Sqrt(discriminant);
                var t1 = (-b - root) / a;
                var t2 = (-b + root) / a;
                if ((t1 < 0 || 1 < t1) && (t2 < 0 || 1 < t2))
                {
                    result = (t1 < 0 && t2 < 0) || (t1 > 1 && t2 > 1) ? new Intersection(IntersectionState.Outside) : new Intersection(IntersectionState.Inside);
                }
                else
                {
                    var p = InterpolateLinear2DTests.LinearInterpolate2D(x0, y0, x1, y1, t1);
                    // Find the determinant of the chord.
                    var determinant = (sX - p.X) * (eY - p.Y) - (eX - p.X) * (sY - p.Y);

                    // Check whether the point is on the side of the chord as the center.
                    if (0 <= t1 && t1 <= 1 && (Sign(determinant) != Sign(sweepAngle)))
                    {
                        result.AppendPoint(p);
                    }

                    p = InterpolateLinear2DTests.LinearInterpolate2D(x0, y0, x1, y1, t2);
                    // Find the determinant of the chord.
                    determinant = (sX - p.X) * (eY - p.Y) - (eX - p.X) * (sY - p.Y);
                    if (0 <= t2 && t2 <= 1 && (Sign(determinant) != Sign(sweepAngle)))
                    {
                        result.AppendPoint(p);
                    }
                }
            }
            else // discriminant == 0.
            {
                // One real possible solution.
                var t = -b / a;
                if (t >= 0d && t <= 1d)
                {
                    var p = InterpolateLinear2DTests.LinearInterpolate2D(x0, y0, x1, y1, t);

                    // Find the determinant of the matrix representing the chord.
                    var determinant = (sX - p.X) * (eY - p.Y) - (eX - p.X) * (sY - p.Y);

                    // Add the point if it is on the sweep side of the chord.
                    if (Sign(determinant) != Sign(sweepAngle))
                    {
                        result.AppendPoint(InterpolateLinear2DTests.LinearInterpolate2D(x0, y0, x1, y1, t));
                    }
                }
                else
                {
                    result = new Intersection(IntersectionState.Outside);
                }
            }

            if (result.Count > 0)
            {
                result.State |= IntersectionState.Intersection;
            }

            return result;
        }
    }
}