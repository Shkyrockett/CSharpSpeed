using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The unrotated ellipse line segment intersection tests class.
    /// </summary>
    [DisplayName("Orthogonal Ellipse Line Segment Intersection Tests")]
    [Description("Finds the intersection points of an Orthogonal Ellipse and a Line Segment Intersection.")]
    [SourceCodeLocationProvider]
    public static class OrthogonalEllipseLineSegmentIntersectionTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(OrthogonalEllipseLineSegmentIntersectionTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 2d, 2d, 1d, 1d, 3d, 3d, Epsilon }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        /// <param name="rx"></param>
        /// <param name="ry"></param>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Intersection UnrotatedEllipseLineSegmentIntersection(double cx, double cy, double rx, double ry, double x0, double y0, double x1, double y1, double epsilon = Epsilon)
            => Intersect(cx, cy, rx, ry, x0, y0, x1, y1, epsilon);

        /// <summary>
        /// Find the points of the intersection between an unrotated ellipse and a line segment.
        /// </summary>
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        /// <param name="rx"></param>
        /// <param name="ry"></param>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2012/09/calculate-where-a-line-segment-and-an-ellipse-intersect-in-c/
        /// </acknowledgment>
        [DisplayName("Orthogonal Ellipse Line Segment Intersection Tests")]
        [Description("Finds the intersection points of an Orthogonal Ellipse and a Line Segment Intersection.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (bool, (double, double)?, bool, (double, double)?) FindEllipseSegmentIntersections(
                double cx, double cy,
                double rx, double ry,
                double x0, double y0,
                double x1, double y1,
                double epsilon = Epsilon)
        {
            _ = epsilon;
            // If the ellipse or line segment are empty, return no intersections.
            if ((cx == 0d) || (cy == 0d) ||
                ((x0 == x1) && (y0 == y1)))
            {
                return (false, null, false, null);
            }

            // Translate lines to meet the ellipse translated centered at the origin.
            var p1X = x0 - cx;
            var p1Y = y0 - cy;
            var p2X = x1 - cx;
            var p2Y = y1 - cy;

            // Calculate the quadratic parameters.
            var a = (p2X - p1X) * (p2X - p1X) / rx / rx + (p2Y - p1Y) * (p2Y - p1Y) / ry / ry;
            var b = 2d * p1X * (p2X - p1X) / rx / rx + 2 * p1Y * (p2Y - p1Y) / ry / ry;
            var c = p1X * p1X / rx / rx + p1Y * p1Y / ry / ry - 1d;

            // Calculate the discriminant.
            var discriminant = b * b - 4d * a * c;

            if (discriminant == 0)
            {
                // One real solution.
                var t = 0.5d * -b / a;

                // Return the point. If the point is on the segment set the bool to true.
                return ((t >= 0d) && (t <= 1d),
                        (p1X + (p2X - p1X) * t + cx,
                        p1Y + (p2Y - p1Y) * t + cy),
                        false, null);
            }
            else if (discriminant > 0)
            {
                // Two real solutions.
                var t1 = 0.5d * (-b + Sqrt(discriminant)) / a;
                var t2 = 0.5d * (-b - Sqrt(discriminant)) / a;

                // Return the points. If the points are on the segment set the bool to true.
                return ((t1 >= 0d) && (t1 <= 1d), (p1X + (p2X - p1X) * t1 + cx, p1Y + (p2Y - p1Y) * t1 + cy),
                        (t2 >= 0d) && (t2 <= 1d), (p1X + (p2X - p1X) * t2 + cx, p1Y + (p2Y - p1Y) * t2 + cy));
            }

            // Return the points.
            return (false, null, false, null);
        }

        /// <summary>
        /// The ellipse line segment.
        /// </summary>
        /// <param name="cX">The cX.</param>
        /// <param name="cY">The cY.</param>
        /// <param name="rX">The rX.</param>
        /// <param name="rY">The rY.</param>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="epsilon"></param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <acknowledgment>
        /// http://forums.codeguru.com/showthread.php?157823-How-to-get-ellipse-and-line-Intersection-points
        /// </acknowledgment>
        [DisplayName("Orthogonal Ellipse Line Segment Intersection Tests")]
        [Description("Finds the intersection points of an Orthogonal Ellipse and a Line Segment Intersection.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (bool, (double, double)?, bool, (double, double)?) EllipseLineSegment(
            double cX, double cY,
            double rX, double rY,
            double x1, double y1,
            double x2, double y2,
            double epsilon = Epsilon)
        {
            _ = epsilon;
            double a;
            double b;
            double c;
            var m = 0d;

            // Check whether line is vertical.
            if (x1 != x2)
            {
                m = (y2 - y1) / (x2 - x1);
                var cc = y1 - m * x1;

                // Non-vertical line case.
                a = rY * rY + rX * rX * m * m;
                b = 2d * rX * rX * cc * m - 2d * rX * rX * cY * m - 2d * cX * rY * rY;
                c = rY * rY * cX * cX + rX * rX * cc * cc - 2 * rX * rX * cY * cc + rX * rX * cY * cY - rX * rX * rY * rY;
            }
            else
            {
                // vertical line case.
                a = rX * rX;
                b = -2d * cY * rX * rX;
                c = -rX * rX * rY * rY + rY * rY * (x1 - cX) * (x1 - cX);
            }

            var discriminant = b * b - 4d * a * c;

            if (discriminant == 0)
            {
                if (x1 != x2)
                {
                    var t = 0.5d * -b / a;
                    return ((t >= 0d) && (t <= 1d), (t, y1 + m * (t - x1)), false, null);
                }
                else
                {
                    var t = 0.5d * -b / a;
                    return ((t >= 0d) && (t <= 1d), (x1, t), false, null);
                }
            }
            else if (discriminant > 0d)
            {
                if (x1 != x2)
                {
                    var t1 = (-b + Sqrt(discriminant)) / (2d * a);
                    var t2 = (-b - Sqrt(discriminant)) / (2d * a);
                    return ((t1 >= 0d) && (t1 <= 1d), (t1, y1 + m * (t1 - x1)),
                            (t2 >= 0d) && (t2 <= 1d), (t2, y1 + m * (t2 - x1)));
                }
                else
                {
                    var t1 = (-b + Sqrt(discriminant)) / (2d * a);
                    var t2 = (-b - Sqrt(discriminant)) / (2d * a);
                    return ((t1 >= 0d) && (t1 <= 1d), (x1, t1),
                            (t2 >= 0d) && (t2 <= 1d), (x2, t2));
                }
            }
            else
            {
                // no intersections
                return (false, null, false, null);
            }
        }

        /// <summary>
        /// Find the points of the intersection of an unrotated ellipse and a line segment.
        /// </summary>
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        /// <param name="rx"></param>
        /// <param name="ry"></param>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2012/09/calculate-where-a-line-segment-and-an-ellipse-intersect-in-c/
        /// </acknowledgment>
        [DisplayName("Orthogonal Ellipse Line Segment Intersection Tests")]
        [Description("Finds the intersection points of an Orthogonal Ellipse and a Line Segment Intersection.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection UnrotatedEllipseLineSegmentIntersection2(
            double cx, double cy,
            double rx, double ry,
            double x0, double y0,
            double x1, double y1,
            double epsilon = Epsilon)
        {
            var result = new Intersection(IntersectionStates.NoIntersection);

            // If the ellipse or line segment are empty, return no intersections.
            if ((rx == 0d) || (ry == 0d) ||
                ((x0 == x1) && (y0 == y1)))
            {
                return result;
            }

            // Translate the line to put the ellipse centered at the origin.
            var u1 = x0 - cx;
            var v1 = y0 - cy;
            var u2 = x1 - cx;
            var v2 = y1 - cy;

            // Calculate the quadratic parameters.
            var a = (u2 - u1) * (u2 - u1) / (rx * rx) + (v2 - v1) * (v2 - v1) / (ry * ry);
            var b = 2d * u1 * (u2 - u1) / (rx * rx) + 2d * v1 * (v2 - v1) / (ry * ry);
            var c = u1 * u1 / (rx * rx) + v1 * v1 / (ry * ry) - 1d;

            // Calculate the discriminant.
            var discriminant = b * b - 4d * a * c;

            if ((a <= epsilon) || (discriminant < 0))
            {
                // No real solutions.
            }
            else if (discriminant == 0)
            {
                // One real possible solution.
                var t = 0.5d * -b / a;

                // Add the points if it is between the end points of the line segment.
                if ((t >= 0d) && (t <= 1d))
                {
                    result.AppendPoint(new Point2D(u1 + (u2 - u1) * t + cx, v1 + (v2 - v1) * t + cy));
                    result.State = IntersectionStates.Intersection;
                }
            }
            else if (discriminant > 0)
            {
                // Two real possible solutions.
                var t1 = 0.5d * (-b + Sqrt(discriminant)) / a;
                var t2 = 0.5d * (-b - Sqrt(discriminant)) / a;

                // Add the points if they are between the end points of the line segment.
                if ((t1 >= 0d) && (t1 <= 1d))
                {
                    result.AppendPoint(new Point2D(u1 + (u2 - u1) * t1 + cx, v1 + (v2 - v1) * t1 + cy));
                    result.State = IntersectionStates.Intersection;
                }

                if ((t2 >= 0d) && (t2 <= 1d))
                {
                    result.AppendPoint(new Point2D(u1 + (u2 - u1) * t2 + cx, v1 + (v2 - v1) * t2 + cy));
                    result.State = IntersectionStates.Intersection;
                }
            }

            return result;
        }

        /// <summary>
        /// The unrotated ellipse line segment intersection.
        /// </summary>
        /// <param name="centerX">The centerX.</param>
        /// <param name="centerY">The centerY.</param>
        /// <param name="rx">The rx.</param>
        /// <param name="ry">The ry.</param>
        /// <param name="a1X">The a1X.</param>
        /// <param name="a1Y">The a1Y.</param>
        /// <param name="a2X">The a2X.</param>
        /// <param name="a2Y">The a2Y.</param>
        /// <param name="epsilon"></param>
        /// <returns>The <see cref="Intersection"/>.</returns>
        /// <acknowledgment>
        /// http://www.kevlindev.com/
        /// </acknowledgment>
        [DisplayName("Orthogonal Ellipse Line Segment Intersection Tests")]
        [Description("Finds the intersection points of an Orthogonal Ellipse and a Line Segment Intersection.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection UnrotatedEllipseLineSegmentIntersection0(
            double centerX, double centerY,
            double rx, double ry,
            double a1X, double a1Y,
            double a2X, double a2Y,
            double epsilon = Epsilon)
        {
            _ = epsilon;
            var origin = new Vector2D(a1X, a1Y);
            var dir = new Vector2D(a1X, a1Y, a2X, a2Y);
            var diff = origin - new Vector2D(centerX, centerY);
            var mDir = new Vector2D(dir.I / (rx * rx), dir.J / (ry * ry));
            var mDiff = new Vector2D(diff.I / (rx * rx), diff.J / (ry * ry));
            var a = DotProduct2Vector2DTests.DotProduct2D(dir.I, dir.J, mDir.I, mDir.J);
            var b = DotProduct2Vector2DTests.DotProduct2D(dir.I, dir.J, mDiff.I, mDiff.J);
            var c = DotProduct2Vector2DTests.DotProduct2D(diff.I, diff.J, mDiff.I, mDiff.J) - 1d;
            var d = b * b - a * c;
            Intersection result;
            if (d < 0)
            {
                result = new Intersection(IntersectionStates.Outside);
            }
            else if (d > 0)
            {
                var root = Sqrt(d);
                var t_a = (-b - root) / a;
                var t_b = (-b + root) / a;
                if ((t_a < 0 || 1 < t_a) && (t_b < 0 || 1 < t_b))
                {
                    result = (t_a < 0 && t_b < 0) || (t_a > 1 && t_b > 1) ? new Intersection(IntersectionStates.Outside) : new Intersection(IntersectionStates.Inside);
                }
                else
                {
                    result = new Intersection(IntersectionStates.Intersection);
                    if (0 <= t_a && t_a <= 1)
                    {
                        result.AppendPoint(InterpolateLinear2DTests.LinearInterpolate2D(t_a, a1X, a1Y, a2X, a2Y));
                    }

                    if (0 <= t_b && t_b <= 1)
                    {
                        result.AppendPoint(InterpolateLinear2DTests.LinearInterpolate2D(t_b, a1X, a1Y, a2X, a2Y));
                    }
                }
            }
            else
            {
                var t = -b / a; if (0 <= t && t <= 1)
                {
                    result = new Intersection(IntersectionStates.Intersection);
                    result.AppendPoint(InterpolateLinear2DTests.LinearInterpolate2D(t, a1X, a1Y, a2X, a2Y));
                }
                else
                {
                    result = new Intersection(IntersectionStates.Outside);
                }
            }

            return result;
        }

        /// <summary>
        /// Finds the Intersection of a Ellipse and a Line
        /// </summary>
        /// <param name="centerX"></param>
        /// <param name="centerY"></param>
        /// <param name="rx"></param>
        /// <param name="ry"></param>
        /// <param name="a1X"></param>
        /// <param name="a1Y"></param>
        /// <param name="a2X"></param>
        /// <param name="a2Y"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection Intersect(
            double centerX, double centerY,
            double rx, double ry,
            double a1X, double a1Y,
            double a2X, double a2Y,
            double epsilon = Epsilon)
        {
            _ = epsilon;
            var (Center, MajorRadius, MinorRadius) = ((X: centerX, Y: centerY), rx, ry);
            var (A, B) = ((X: a1X, Y: a1Y), (X: a2X, Y: a2Y));

            var result = new Intersection(IntersectionStates.NoIntersection);

            var slopeA = Slope2Points2DTests.Slope(A.X, A.Y, B.X, B.Y);
            var slopeB = A.Y - (slopeA * A.X);

            var a = 1 + (slopeA * slopeA);
            var b = (2 * (slopeA * (slopeB - Center.Y))) - (2d * Center.X);
            var c = (Center.X * Center.X) + (((slopeB - Center.Y) * (slopeB - Center.X)) - (MajorRadius * MajorRadius));

            var xA = ((b * -1) + Sqrt((b * b) - (a * c))) / (2d * a);
            var xB = (b - Sqrt((b * b) - (a * c))) * -1d / (2d * a);
            var yA = (slopeA * xA) + slopeB;
            var yB = (slopeA * xB) + slopeB;

            result.AppendPoint((xA, yA));
            result.AppendPoint((xB, yB));
            result.State = IntersectionStates.Intersection;
            return result;
        }
    }
}
