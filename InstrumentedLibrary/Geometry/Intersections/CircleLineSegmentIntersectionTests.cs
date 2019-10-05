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
    /// The circle line segment intersection tests class.
    /// </summary>
    [DisplayName("Intersection of Circle and Line Segment")]
    [Description("Finds the intersection points of a circle and a line segment.")]
    [SourceCodeLocationProvider]
    public static class CircleLineSegmentIntersectionTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(CircleLineSegmentIntersectionTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 1d, 2d, 1.5d, 1.5d, 3d, 3d, Epsilon }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:15d, epsilon: double.Epsilon) },
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
        /// <param name="r">The r.</param>
        /// <param name="lAX">The l ax.</param>
        /// <param name="lAY">The l ay.</param>
        /// <param name="lBX">The l bx.</param>
        /// <param name="lBY">The l by.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Intersection CircleLineSegmentIntersection(double cX, double cY, double r, double lAX, double lAY, double lBX, double lBY, double epsilon = Epsilon)
            => CircleLineSegmentIntersection1(cX, cY, r, lAX, lAY, lBX, lBY, epsilon);

        /// <summary>
        /// Find the points of the intersection of a circle and a line segment.
        /// </summary>
        /// <param name="cX">The c x.</param>
        /// <param name="cY">The c y.</param>
        /// <param name="r">The r.</param>
        /// <param name="lAX">The l ax.</param>
        /// <param name="lAY">The l ay.</param>
        /// <param name="lBX">The l bx.</param>
        /// <param name="lBY">The l by.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/09/determine-where-a-line-intersects-a-circle-in-c/
        /// </acknowledgment>
        [DisplayName("Intersection of Circle and Line Segment")]
        [Description("Finds the intersection points of a circle and a line segment.")]
        [Acknowledgment("http://csharphelper.com/blog/2014/09/determine-where-a-line-intersects-a-circle-in-c/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection CircleLineSegmentIntersection1(
            double cX, double cY,
            double r,
            double lAX, double lAY,
            double lBX, double lBY,
            double epsilon = Epsilon)
        {
            _ = epsilon;
            var result = new Intersection(IntersectionStates.NoIntersection);

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
            var discriminant = b * b - 4d * a * c;

            if ((a <= Epsilon) || (discriminant < 0))
            {
                // No real solutions.
            }
            else if (discriminant == 0)
            {
                // One possible solution.
                var t = -b / (2 * a);

                // Add the points if they are between the end points of the line segment.
                if ((t >= 0d) && (t <= 1d))
                {
                    result = new Intersection(IntersectionStates.Intersection);
                    result.AppendPoint(new Point2D(lAX + t * dx, lAY + t * dy));
                }
            }
            else if (discriminant > 0)
            {
                // Two possible solutions.
                var t1 = (-b + Sqrt(discriminant)) / (2 * a);
                var t2 = (-b - Sqrt(discriminant)) / (2 * a);

                // Add the points if they are between the end points of the line segment.
                result = new Intersection(IntersectionStates.Intersection);
                if ((t1 >= 0d) && (t1 <= 1d))
                {
                    result.AppendPoint(new Point2D(lAX + t1 * dx, lAY + t1 * dy));
                }

                if ((t2 >= 0d) && (t2 <= 1d))
                {
                    result.AppendPoint(new Point2D(lAX + t2 * dx, lAY + t2 * dy));
                }
            }

            return result;
        }

        /// <summary>
        /// The circle line segment intersection.
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
        /// http://www.kevlindev.com/
        /// </acknowledgment>
        [DisplayName("Intersection of Circle and Line Segment")]
        [Description("Finds the intersection points of a circle and a line segment.")]
        [Acknowledgment("http://www.kevlindev.com/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection CircleLineSegmentIntersectionKevLinDev(
            double cX, double cY,
            double r,
            double lAX, double lAY,
            double lBX, double lBY,
            double epsilon = Epsilon)
        {
            _ = epsilon;
            Intersection result;

            var a = (lBX - lAX) * (lBX - lAX) + (lBY - lAY) * (lBY - lAY);
            var b = 2 * ((lBX - lAX) * (lAX - cX) + (lBY - lAY) * (lAY - cY));
            var c = cX * cX + cY * cY + lAX * lAX + lAY * lAY - 2 * (cX * lAX + cY * lAY) - r * r;

            var determinant = b * b - 4 * a * c;
            if (determinant < 0)
            {
                result = new Intersection(IntersectionStates.Outside);
            }
            else if (determinant == 0)
            {
                result = new Intersection(IntersectionStates.Tangent | IntersectionStates.Intersection);
                var u1 = (-b) / (2 * a);
                if (u1 < 0 || u1 > 1)
                {
                    result = (u1 < 0) || (u1 > 1) ? new Intersection(IntersectionStates.Outside) : new Intersection(IntersectionStates.Inside);
                }
                else
                {
                    result = new Intersection(IntersectionStates.Intersection);
                    if (0 <= u1 && u1 <= 1)
                    {
                        result.Items.Add(InterpolateLinear2DTests.LinearInterpolate2D(u1, lAX, lAY, lBX, lBY));
                    }
                }
            }
            else
            {
                var e = Sqrt(determinant);
                var u1 = (-b + e) / (2 * a);
                var u2 = (-b - e) / (2 * a);
                if ((u1 < 0 || u1 > 1) && (u2 < 0 || u2 > 1))
                {
                    result = (u1 < 0 && u2 < 0) || (u1 > 1 && u2 > 1) ? new Intersection(IntersectionStates.Outside) : new Intersection(IntersectionStates.Inside);
                }
                else
                {
                    result = new Intersection(IntersectionStates.Intersection);
                    if (0 <= u1 && u1 <= 1)
                    {
                        result.Items.Add(InterpolateLinear2DTests.LinearInterpolate2D(u1, lAX, lAY, lBX, lBY));
                    }

                    if (0 <= u2 && u2 <= 1)
                    {
                        result.Items.Add(InterpolateLinear2DTests.LinearInterpolate2D(u2, lAX, lAY, lBX, lBY));
                    }
                }
            }
            return result;
        }
    }
}
