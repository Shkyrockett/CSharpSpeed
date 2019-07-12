using CSharpSpeed;
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
    /// The quadratic bezier line segment intersection tests class.
    /// </summary>
    [DisplayName("Intersection of Quadratic Bezier and Line Segment")]
    [Description("Finds the intersection points of a Quadratic Bezier and Line Segment.")]
    [SourceCodeLocationProvider]
    public static class QuadraticBezierLineSegmentIntersectionTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(QuadraticBezierLineSegmentIntersectionTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 5d, 10d, 15d, 20d, 0d, 5d, 10d, -5d, 20d, Epsilon }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:15d, epsilon: double.Epsilon) },
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
        /// <param name="p1X"></param>
        /// <param name="p1Y"></param>
        /// <param name="p2X"></param>
        /// <param name="p2Y"></param>
        /// <param name="p3X"></param>
        /// <param name="p3Y"></param>
        /// <param name="a1X"></param>
        /// <param name="a1Y"></param>
        /// <param name="a2X"></param>
        /// <param name="a2Y"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Intersection QuadraticBezierLineSegmentIntersection(double p1X, double p1Y, double p2X, double p2Y, double p3X, double p3Y, double a1X, double a1Y, double a2X, double a2Y, double epsilon = Epsilon)
            => QuadraticBezierLineSegmentIntersection1(p1X, p1Y, p2X, p2Y, p3X, p3Y, a1X, a1Y, a2X, a2Y, epsilon);

        /// <summary>
        /// The quadratic bezier line segment intersection1.
        /// </summary>
        /// <param name="p1X">The p1X.</param>
        /// <param name="p1Y">The p1Y.</param>
        /// <param name="p2X">The p2X.</param>
        /// <param name="p2Y">The p2Y.</param>
        /// <param name="p3X">The p3X.</param>
        /// <param name="p3Y">The p3Y.</param>
        /// <param name="a1X">The a1X.</param>
        /// <param name="a1Y">The a1Y.</param>
        /// <param name="a2X">The a2X.</param>
        /// <param name="a2Y">The a2Y.</param>
        /// <param name="epsilon"></param>
        /// <returns>The <see cref="Intersection"/>.</returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/27664298/calculating-intersection-point-of-quadratic-bezier-curve
        /// </acknowledgment>
        [DisplayName("Intersection of Quadratic Bezier and Line Segment")]
        [Description("Finds the intersection points of a Quadratic Bezier and Line Segment.")]
        [Acknowledgment("http://stackoverflow.com/questions/27664298/calculating-intersection-point-of-quadratic-bezier-curve")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection QuadraticBezierLineSegmentIntersection1(
            double p1X, double p1Y,
            double p2X, double p2Y,
            double p3X, double p3Y,
            double a1X, double a1Y,
            double a2X, double a2Y,
            double epsilon = Epsilon)
        {
            _ = epsilon;
            var intersections = new Intersection(IntersectionStates.NoIntersection);

            // inverse line normal
            var normal = new Point2D(a1Y - a2Y, a2X - a1X);

            // Q-coefficients
            var c2 = new Point2D(p1X + p2X * -2 + p3X, p1Y + p2Y * -2 + p3Y);
            var c1 = new Point2D(p1X * -2 + p2X * 2, p1Y * -2 + p2Y * 2);
            var c0 = new Point2D(p1X, p1Y);

            // Transform to line
            var coefficient = a1X * a2Y - a2X * a1Y;
            var a = normal.X * c2.X + normal.Y * c2.Y;
            var b = (normal.X * c1.X + normal.Y * c1.Y) / a;
            var c = (normal.X * c0.X + normal.Y * c0.Y + coefficient) / a;

            // solve the roots
            var roots = new List<double>();
            var d = b * b - 4 * c;
            if (d > 0)
            {
                var e = Sqrt(d);
                roots.Add((-b + Sqrt(d)) / 2d);
                roots.Add((-b - Sqrt(d)) / 2d);
            }
            else if (d == 0)
            {
                roots.Add(-b / 2d);
            }

            // Calculate the solution points
            for (var i = 0; i < roots.Count; i++)
            {
                var minX = Min(a1X, a2X);
                var minY = Min(a1Y, a2Y);
                var maxX = Max(a1X, a2X);
                var maxY = Max(a1Y, a2Y);
                var t = roots[i];
                if (t >= 0 && t <= 1)
                {
                    // Possible point -- pending bounds check
                    var point = new Point2D(
                        InterpolateLinear1DTests.LinearInterpolate1D(t, InterpolateLinear1DTests.LinearInterpolate1D(t, p1X, p2X), InterpolateLinear1DTests.LinearInterpolate1D((double)t, (double)p2X, (double)p3X)),
                        InterpolateLinear1DTests.LinearInterpolate1D(t, InterpolateLinear1DTests.LinearInterpolate1D(t, p1Y, p2Y), InterpolateLinear1DTests.LinearInterpolate1D(t, p2Y, p3Y)));
                    var x = point.X;
                    var y = point.Y;
                    var result = new Intersection(IntersectionStates.Intersection);
                    // bounds checks
                    if (a1X == a2X && y >= minY && y <= maxY)
                    {
                        // vertical line
                        intersections.AppendPoint(point);
                    }
                    else if (a1Y == a2Y && x >= minX && x <= maxX)
                    {
                        // horizontal line
                        intersections.AppendPoint(point);
                    }
                    else if (x >= minX && y >= minY && x <= maxX && y <= maxY)
                    {
                        // line passed bounds check
                        intersections.AppendPoint(point);
                    }
                }
            }
            return intersections;
        }

        /// <summary>
        /// The quadratic bezier line segment intersection.
        /// </summary>
        /// <param name="p1X">The p1X.</param>
        /// <param name="p1Y">The p1Y.</param>
        /// <param name="p2X">The p2X.</param>
        /// <param name="p2Y">The p2Y.</param>
        /// <param name="p3X">The p3X.</param>
        /// <param name="p3Y">The p3Y.</param>
        /// <param name="a1X">The a1X.</param>
        /// <param name="a1Y">The a1Y.</param>
        /// <param name="a2X">The a2X.</param>
        /// <param name="a2Y">The a2Y.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>The <see cref="Intersection"/>.</returns>
        /// <acknowledgment>
        /// http://www.kevlindev.com/
        /// </acknowledgment>
        [DisplayName("Intersection of Quadratic Bezier and Line Segment")]
        [Description("Finds the intersection points of a Quadratic Bezier and Line Segment.")]
        [Acknowledgment("http://www.kevlindev.com/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection QuadraticBezierLineSegmentIntersection0(
            double p1X, double p1Y,
            double p2X, double p2Y,
            double p3X, double p3Y,
            double a1X, double a1Y,
            double a2X, double a2Y,
            double epsilon = Epsilon)
        {
            var min = MinPointTests.MinPoint(a1X, a1Y, a2X, a2Y);
            var max = MaxPointTests.MaxPoint(a1X, a1Y, a2X, a2Y);
            var result = new Intersection(IntersectionStates.NoIntersection);
            var a = new Vector2D(p2X, p2Y) * (-2);
            var c2 = new Vector2D(p1X, p1Y) + (a + new Vector2D(p3X, p3Y));
            a = new Vector2D(p1X, p1Y) * (-2);
            var b = new Vector2D(p2X, p2Y) * 2;
            var c1 = a + b;
            var c0 = new Point2D(p1X, p1Y);
            var n = new Point2D(a1Y - a2Y, a2X - a1X);
            var cl = a1X * a2Y - a2X * a1Y;
            var roots = QuadraticRootsTests.QuadraticRoots(
                DotProduct2Vector2DTests.DotProduct2D(n.X, n.Y, c2.I, c2.J),
                DotProduct2Vector2DTests.DotProduct2D(n.X, n.Y, c1.I, c1.J),
                DotProduct2Vector2DTests.DotProduct2D(n.X, n.Y, c0.X + cl, c0.Y + cl),
                epsilon);
            for (var i = 0; i < roots.Count; i++)
            {
                var t = roots[i];
                if (0 <= t && t <= 1)
                {
                    var p4 = InterpolateLinear2DTests.LinearInterpolate2D(t, p1X, p1Y, p2X, p2Y);
                    var p5 = InterpolateLinear2DTests.LinearInterpolate2D(t, p2X, p2Y, p3X, p3Y);
                    var p6 = InterpolateLinear2DTests.LinearInterpolate2D(t, p4.X, p4.Y, p5.X, p5.Y);
                    if (a1X == a2X)
                    {
                        if (min.Y <= p6.Y && p6.Y <= max.Y)
                        {
                            result.State = IntersectionStates.Intersection;
                            result.AppendPoint(p6);
                        }
                    }
                    else if (a1Y == a2Y)
                    {
                        if (min.X <= p6.X && p6.X <= max.X)
                        {
                            result.State = IntersectionStates.Intersection;
                            result.AppendPoint(p6);
                        }
                    }
                    else if (GreaterThanOrEqualTests.GreaterThanOrEqual(p6.X, p6.Y, min.X, min.Y) && LessThanOrEqualTests.LessThanOrEqual(p6.X, p6.Y, max.X, max.Y))
                    {
                        result.State = IntersectionStates.Intersection;
                        result.AppendPoint(p6);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// The line quadratic bezier intersection.
        /// </summary>
        /// <param name="p1X">The p1X.</param>
        /// <param name="p1Y">The p1Y.</param>
        /// <param name="p2X">The p2X.</param>
        /// <param name="p2Y">The p2Y.</param>
        /// <param name="p3X">The p3X.</param>
        /// <param name="p3Y">The p3Y.</param>
        /// <param name="a1X">The a1X.</param>
        /// <param name="a1Y">The a1Y.</param>
        /// <param name="a2X">The a2X.</param>
        /// <param name="a2Y">The a2Y.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>The <see cref="Intersection"/>.</returns>
        /// <acknowledgment>
        /// http://www.kevlindev.com/
        /// </acknowledgment>
        [DisplayName("Intersection of Quadratic Bezier and Line Segment")]
        [Description("Finds the intersection points of a Quadratic Bezier and Line Segment.")]
        [Acknowledgment("http://www.kevlindev.com/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection QuadraticBezierLineIntersection(
            double p1X, double p1Y,
            double p2X, double p2Y,
            double p3X, double p3Y,
            double a1X, double a1Y,
            double a2X, double a2Y,
            double epsilon = Epsilon)
        {
            var min = MinPointTests.MinPoint(a1X, a1Y, a2X, a2Y);
            var max = MaxPointTests.MaxPoint(a1X, a1Y, a2X, a2Y);
            var result = new Intersection(IntersectionStates.NoIntersection);
            var a = new Vector2D(p2X, p2Y) * (-2);
            var c2 = new Vector2D(p1X, p1Y) + (a + new Vector2D(p3X, p3Y));
            a = new Vector2D(p1X, p1Y) * (-2);
            var b = new Vector2D(p2X, p2Y) * 2;
            var c1 = a + b;
            var c0 = new Point2D(p1X, p1Y);
            var n = new Point2D(a1Y - a2Y, a2X - a1X);
            var cl = a1X * a2Y - a2X * a1Y;
            var roots = QuadraticRootsTests.QuadraticRoots(
                DotProduct2Vector2DTests.DotProduct2D(n.X, n.Y, c2.I, c2.J),
                DotProduct2Vector2DTests.DotProduct2D(n.X, n.Y, c1.I, c1.J),
                DotProduct2Vector2DTests.DotProduct2D(n.X, n.Y, c0.X + cl, c0.Y + cl),
                epsilon);
            for (var i = 0; i < roots.Count; i++)
            {
                var t = roots[i];
                if (0 <= t && t <= 1)
                {
                    var p4 = InterpolateLinear2DTests.LinearInterpolate2D(t, p1X, p1Y, p2X, p2Y);
                    var p5 = InterpolateLinear2DTests.LinearInterpolate2D(t, p2X, p2Y, p3X, p3Y);
                    var p6 = InterpolateLinear2DTests.LinearInterpolate2D(t, p4.X, p4.Y, p5.X, p5.Y);
                    if (a1X == a2X)
                    {
                        result.AppendPoint(p6);
                    }
                    else if (a1Y == a2Y)
                    {
                        result.AppendPoint(p6);
                    }
                    else if (GreaterThanOrEqualTests.GreaterThanOrEqual(p6.X, p6.Y, min.X, min.Y) && LessThanOrEqualTests.LessThanOrEqual(p6.X, p6.Y, max.X, max.Y))
                    {
                        result.AppendPoint(p6);
                    }
                }
            }

            if (result.Count > 0)
            {
                result.State |= IntersectionStates.Intersection;
            }

            return result;
        }
    }
}
