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
    /// The circle line intersection tests class.
    /// </summary>
    [DisplayName("Intersection of Circle and Line")]
    [Description("Finds the intersection points of a circle and a line.")]
    [SourceCodeLocationProvider]
    public static class CircleLineIntersectionTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>
        /// The <see cref="List{T}" />.
        /// </returns>
        [DisplayName(nameof(CircleLineIntersectionTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 1d, 2d, 1.5d, 1.5d, 3d, 3d, Epsilon }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: new (double X, double Y)[]{(2.414213562373095d, 2.414213562373095d), (-0.4142135623730949d, -0.4142135623730949d)}, epsilon: double.Epsilon) },
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
        /// Circles the line segment intersection.
        /// </summary>
        /// <param name="cX">The c x.</param>
        /// <param name="cY">The c y.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="lAX">The l ax.</param>
        /// <param name="lAY">The l ay.</param>
        /// <param name="lBX">The l bx.</param>
        /// <param name="lBY">The l by.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y)[] CircleLineSegmentIntersection(double cX, double cY, double radius, double lAX, double lAY, double lBX, double lBY, double epsilon = Epsilon)
            => LineCircle(cX, cY, radius, lAX, lAY, lBX, lBY, epsilon);

        /// <summary>
        /// Find the points of intersection.
        /// </summary>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <param name="radius"></param>
        /// <param name="lAX"></param>
        /// <param name="lAY"></param>
        /// <param name="lBX"></param>
        /// <param name="lBY"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/09/determine-where-a-line-intersects-a-circle-in-c/
        /// </acknowledgment>
        [DisplayName("Intersection of Circle and Line")]
        [Description("Finds the intersection points of a circle and a line.")]
        [Acknowledgment("http://csharphelper.com/blog/2014/09/determine-where-a-line-intersects-a-circle-in-c/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y)[] LineCircle(double cX, double cY, double radius, double lAX, double lAY, double lBX, double lBY, double epsilon = Epsilon)
        {
            //double t;

            var dx = lBX - lAX;
            var dy = lBY - lAY;

            var A = (dx * dx) + (dy * dy);
            var B = 2d * ((dx * (lAX - cX)) + (dy * (lAY - cY)));
            var C = ((lAX - cX) * (lAX - cX)) + ((lAY - cY) * (lAY - cY)) - (radius * radius);

            var det = (B * B) - (4d * A * C);
            if ((A <= epsilon) || (det < 0d))
            {
                // No real solutions.
                //return new Intersection(IntersectionStates.NoIntersection);
                return Array.Empty<(double X, double Y)>();
            }
            else if (Abs(det) < DoubleEpsilon)
            {
                // One solution.
                var t = -B / (2d * A);
                //var intersection = new Intersection(IntersectionStates.Intersection);
                //intersection.AppendPoint((lAX + t * dx, lAY + t * dy));
                return new (double X, double Y)[] { (lAX + (t * dx), lAY + (t * dy)) };
                //return intersection;
            }
            else
            {
                // Two solutions.
                //var intersection = new Intersection(IntersectionStates.Intersection);
                var t1 = (-B + Sqrt(det)) / (2d * A);
                //intersection.AppendPoint((lAX + t1 * dx, lAY + t1 * dy));
                var t2 = (-B - Sqrt(det)) / (2d * A);
                //intersection.AppendPoint((lAX + t2 * dx, lAY + t2 * dy));
                return new (double X, double Y)[] { (lAX + (t1 * dx), lAY + (t1 * dy)), (lAX + (t2 * dx), lAY + (t2 * dy)) };
                //return intersection;
            }
        }

        /// <summary>
        /// The circle line intersection.
        /// </summary>
        /// <param name="cX">The cX.</param>
        /// <param name="cY">The cY.</param>
        /// <param name="r">The r.</param>
        /// <param name="lAX">The lAX.</param>
        /// <param name="lAY">The lAY.</param>
        /// <param name="lBX">The lBX.</param>
        /// <param name="lBY">The lBY.</param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns>The <see cref="Intersection"/>.</returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/09/determine-where-a-line-intersects-a-circle-in-c/
        /// </acknowledgment>
        [DisplayName("Intersection of Circle and Line")]
        [Description("Finds the intersection points of a circle and a line.")]
        [Acknowledgment("http://csharphelper.com/blog/2014/09/determine-where-a-line-intersects-a-circle-in-c/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y)[] CircleLineIntersection(double cX, double cY, double r, double lAX, double lAY, double lBX, double lBY, double epsilon = Epsilon)
        {
            _ = epsilon;
            //var result = new Intersection(IntersectionStates.NoIntersection);

            // If the circle or line segment are empty, return no intersections.
            if ((r == 0d) || ((lAX == lBX) && (lAY == lBY)))
            {
                return Array.Empty<(double X, double Y)>();
                //return result;
            }

            var dx = lBX - lAX;
            var dy = lBY - lAY;

            // Calculate the quadratic parameters.
            var a = (dx * dx) + (dy * dy);
            var b = 2 * ((dx * (lAX - cX)) + (dy * (lAY - cY)));
            var c = ((lAX - cX) * (lAX - cX)) + ((lAY - cY) * (lAY - cY)) - (r * r);

            // Calculate the discriminant.
            var discriminant = (b * b) - (4d * a * c);

            if ((a <= Epsilon) || (discriminant < 0d))
            {
                // No real solutions.
                return Array.Empty<(double X, double Y)>();
            }
            else if (discriminant == 0d)
            {
                // One possible solution.
                var t = -b / (2d * a);

                // Add the points.
                //result = new Intersection(IntersectionStates.Intersection);
                //result.AppendPoint(new Point2D(lAX + t * dx, lAY + t * dy));
                return new (double X, double Y)[] { (lAX + (t * dx), lAY + (t * dy)) };
            }
            else if (discriminant > 0d)
            {
                // Two possible solutions.
                var t1 = (-b + Sqrt(discriminant)) / (2d * a);
                var t2 = (-b - Sqrt(discriminant)) / (2d * a);

                // Add the points.
                //result = new Intersection(IntersectionStates.Intersection);
                //result.AppendPoint(new Point2D(lAX + t1 * dx, lAY + t1 * dy));
                //result.AppendPoint(new Point2D(lAX + t2 * dx, lAY + t2 * dy));
                return new (double X, double Y)[] { (lAX + (t1 * dx), lAY + (t1 * dy)), (lAX + (t2 * dx), lAY + (t2 * dy)) };
            }

            //return result;
            return Array.Empty<(double X, double Y)>();
        }
    }
}
