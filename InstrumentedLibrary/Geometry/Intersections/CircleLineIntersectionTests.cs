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
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(CircleLineIntersectionTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 1d, 2d, 1.5d, 1.5d, 3d, 3d, Epsilon }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:15d, epsilon: double.Epsilon) },
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
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <param name="radius"></param>
        /// <param name="lAX"></param>
        /// <param name="lAY"></param>
        /// <param name="lBX"></param>
        /// <param name="lBY"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Intersection CircleLineSegmentIntersection(double cX, double cY, double radius, double lAX, double lAY, double lBX, double lBY, double epsilon = Epsilon)
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
        public static Intersection LineCircle(
            double cX, double cY,
            double radius,
            double lAX, double lAY,
            double lBX, double lBY,
            double epsilon = Epsilon)
        {
            double t;

            var dx = lBX - lAX;
            var dy = lBY - lAY;

            var A = dx * dx + dy * dy;
            var B = 2d * (dx * (lAX - cX) + dy * (lAY - cY));
            var C = (lAX - cX) * (lAX - cX) + (lAY - cY) * (lAY - cY) - radius * radius;

            var det = B * B - 4 * A * C;
            if ((A <= epsilon) || (det < 0))
            {
                // No real solutions.
                return new Intersection(IntersectionState.NoIntersection);
            }
            else if (Abs(det) < DoubleEpsilon)
            {
                // One solution.
                t = -B / (2 * A);
                var intersection = new Intersection(IntersectionState.Intersection);
                intersection.AppendPoint((lAX + t * dx, lAY + t * dy));
                return intersection;
            }
            else
            {
                // Two solutions.
                var intersection = new Intersection(IntersectionState.Intersection);
                t = (-B + Sqrt(det)) / (2d * A);
                intersection.AppendPoint((lAX + t * dx, lAY + t * dy));
                t = (-B - Sqrt(det)) / (2d * A);
                intersection.AppendPoint((lAX + t * dx, lAY + t * dy));
                return intersection;
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
        public static Intersection CircleLineIntersection(
            double cX, double cY,
            double r,
            double lAX, double lAY,
            double lBX, double lBY,
            double epsilon = Epsilon)
        {
            var result = new Intersection(IntersectionState.NoIntersection);

            // If the circle or line segment are empty, return no intersections.
            if ((r == 0d) || ((lAX == lBX) && (lAY == lBY)))
            {
                return result;
            }

            var dx = lBX - lAX;
            var dy = lBY - lAY;

            // Calculate the quadratic parameters.
            var a = dx * dx + dy * dy;
            var b = 2 * (dx * (lAX - cX) + dy * (lAY - cY));
            var c = (lAX - cX) * (lAX - cX) + (lAY - cY) * (lAY - cY) - r * r;

            // Calculate the discriminant.
            var discriminant = b * b - 4 * a * c;

            if ((a <= Epsilon) || (discriminant < 0))
            {
                // No real solutions.
            }
            else if (discriminant == 0)
            {
                // One possible solution.
                var t = -b / (2 * a);

                // Add the points.
                result = new Intersection(IntersectionState.Intersection);
                result.AppendPoint(new Point2D(lAX + t * dx, lAY + t * dy));
            }
            else if (discriminant > 0)
            {
                // Two possible solutions.
                var t1 = (-b + Sqrt(discriminant)) / (2 * a);
                var t2 = (-b - Sqrt(discriminant)) / (2 * a);

                // Add the points.
                result = new Intersection(IntersectionState.Intersection);
                result.AppendPoint(new Point2D(lAX + t1 * dx, lAY + t1 * dy));
                result.AppendPoint(new Point2D(lAX + t2 * dx, lAY + t2 * dy));
            }

            return result;
        }
    }
}
