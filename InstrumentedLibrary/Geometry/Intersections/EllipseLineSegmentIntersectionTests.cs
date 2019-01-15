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
    /// The ellipse line segment intersection tests class.
    /// </summary>
    [DisplayName("Ellipse Line Segment Intersection Tests")]
    [Description("Finds the intersection points of an Ellipse and a Line Segment Intersection.")]
    [SourceCodeLocationProvider]
    public static class EllipseLineSegmentIntersectionTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(EllipseLineSegmentIntersectionTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 2d, 2d, 0d, 1d, 1d, 3d, 3d, Epsilon }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: true, epsilon:DoubleEpsilon) },
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
        /// <param name="angle"></param>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Intersection EllipseLineSegmentIntersection(double cx, double cy, double rx, double ry, double angle, double x0, double y0, double x1, double y1, double epsilon = Epsilon)
            => EllipseLineSegmentIntersection_(cx, cy, rx, ry, angle, x0, y0, x1, y1, epsilon);

        /// <summary>
        /// Find the points of the intersection of an unrotated ellipse and a line segment.
        /// </summary>
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        /// <param name="rx"></param>
        /// <param name="ry"></param>
        /// <param name="angle"></param>
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
        [Acknowledgment("http://csharphelper.com/blog/2012/09/calculate-where-a-line-segment-and-an-ellipse-intersect-in-c/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection EllipseLineSegmentIntersection_(
            double cx, double cy,
            double rx, double ry,
            double angle,
            double x0, double y0,
            double x1, double y1,
            double epsilon = Epsilon)
        {
            var result = new Intersection(IntersectionState.NoIntersection);

            // If the ellipse or line segment are empty, return no intersections.
            if ((rx == 0d) || (ry == 0d) ||
                ((x0 == x1) && (y0 == y1)))
            {
                return result;
            }

            // Get the Sine and Cosine of the angle.
            var sinA = Sin(angle);
            var cosA = Cos(angle);

            // Translate the line to put the ellipse centered at the origin.
            var u1 = x0 - cx;
            var v1 = y0 - cy;
            var u2 = x1 - cx;
            var v2 = y1 - cy;

            // Apply Rotation Transform to line at the origin.
            var u1A = 0 + (u1 * cosA - v1 * sinA);
            var v1A = 0 + (u1 * sinA + v1 * cosA);
            var u2A = 0 + (u2 * cosA - v2 * sinA);
            var v2A = 0 + (u2 * sinA + v2 * cosA);

            // Calculate the quadratic parameters.
            var a = (u2A - u1A) * (u2A - u1A) / (rx * rx) + (v2A - v1A) * (v2A - v1A) / (ry * ry);
            var b = 2d * u1A * (u2A - u1A) / (rx * rx) + 2d * v1A * (v2A - v1A) / (ry * ry);
            var c = u1A * u1A / (rx * rx) + v1A * v1A / (ry * ry) - 1d;

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

                // Add the point if it is between the end points of the line segment.
                if ((t >= 0d) && (t <= 1d))
                {
                    result.AppendPoint(new Point2D(u1 + (u2 - u1) * t + cx, v1 + (v2 - v1) * t + cy));
                    result.State = IntersectionState.Intersection;
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
                    result.State = IntersectionState.Intersection;
                }

                if ((t2 >= 0d) && (t2 <= 1d))
                {
                    result.AppendPoint(new Point2D(u1 + (u2 - u1) * t2 + cx, v1 + (v2 - v1) * t2 + cy));
                    result.State = IntersectionState.Intersection;
                }

                // ToDo: Figure out why the results are weird between 30 degrees and 5 degrees.
            }

            return result;
        }
    }
}
