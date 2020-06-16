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
    /// The line line segment intersection tests class.
    /// </summary>
    [DisplayName("Intersection of a line and a line segment")]
    [Description("Find the intersection between a line and a line segment.")]
    [SourceCodeLocationProvider]
    public static class LineLineSegmentIntersectionTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 3D Hermite interpolation of points.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(LineLineSegmentIntersectionTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 2d, 2d, 0d, 2d, 2d, 0d, Epsilon }, new TestCaseResults(description: "Line Segment Line Segment intersection.", trials: trials, expectedReturnValue: new Intersection(), epsilon: double.Epsilon) },
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
        /// <param name="a1X"></param>
        /// <param name="a1Y"></param>
        /// <param name="a2X"></param>
        /// <param name="a2Y"></param>
        /// <param name="b1X"></param>
        /// <param name="b1Y"></param>
        /// <param name="b2X"></param>
        /// <param name="b2Y"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Intersection LineLineSegmentIntersection(double a1X, double a1Y, double a2X, double a2Y, double b1X, double b1Y, double b2X, double b2Y, double epsilon = Epsilon)
            => LineLineSegmentIntersection1(a1X, a1Y, a2X, a2Y, b1X, b1Y, b2X, b2Y, epsilon);

        /// <summary>
        /// The line line segment intersection0.
        /// </summary>
        /// <param name="aX">The aX.</param>
        /// <param name="aY">The aY.</param>
        /// <param name="bX">The bX.</param>
        /// <param name="bY">The bY.</param>
        /// <param name="cX">The cX.</param>
        /// <param name="cY">The cY.</param>
        /// <param name="dX">The dX.</param>
        /// <param name="dY">The dY.</param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns>The <see cref="Intersection"/>.</returns>
        /// <acknowledgment>
        /// https://www.gamedev.net/topic/488904-lineline-segment-intersection-in-2d/
        /// </acknowledgment>
        [DisplayName("Intersection of a line and a line segment")]
        [Description("Find the intersection between a line and a line segment.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection LineLineSegmentIntersection0(
            double aX, double aY, // Line
            double bX, double bY,
            double cX, double cY,  // Segment
            double dX, double dY,
            double epsilon = Epsilon)
        {
            //test for parallel case
            var denom = ((dY - cY) * (bX - aX)) - ((dX - cX) * (bY - aY));
            if (Abs(denom) < epsilon)
            {
                return new Intersection(IntersectionStates.NoIntersection);
            }

            //calculate segment parameter and ensure its within bounds
            var t = (((bX - aX) * (aY - cY)) - ((bY - aY) * (aX - cX))) / denom;
            if (t < 0d || t > 1d)
            {
                return new Intersection(IntersectionStates.NoIntersection);
            }

            //store actual intersection
            var result = new Intersection(IntersectionStates.Intersection);
            result.AppendPoint(new Point2D(cX + ((dX - cX) * t), cY + ((dY - cY) * t)));
            return result;

        }

        /// <summary>
        /// Find the intersection point between two line segments.
        /// </summary>
        /// <param name="a1X"></param>
        /// <param name="a1Y"></param>
        /// <param name="a2X"></param>
        /// <param name="a2Y"></param>
        /// <param name="b1X"></param>
        /// <param name="b1Y"></param>
        /// <param name="b2X"></param>
        /// <param name="b2Y"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://www.kevlindev.com/
        /// </acknowledgment>
        [DisplayName("Intersection of a line and a line segment")]
        [Description("Find the intersection between a line and a line segment.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection LineLineSegmentIntersection1(
            double a1X, double a1Y,
            double a2X, double a2Y,
            double b1X, double b1Y,
            double b2X, double b2Y,
            double epsilon = Epsilon)
        {
            _ = epsilon;
            Intersection result;
            var ua_t = ((b2X - b1X) * (a1Y - b1Y)) - ((b2Y - b1Y) * (a1X - b1X));
            var ub_t = ((a2X - a1X) * (a1Y - b1Y)) - ((a2Y - a1Y) * (a1X - b1X));
            var u_b = ((b2Y - b1Y) * (a2X - a1X)) - ((b2X - b1X) * (a2Y - a1Y));
            if (u_b != 0)
            {
                var ua = ua_t / u_b;
                var ub = ub_t / u_b;
                if (//true
                    //0 <= ua && ua <= 1
                    //&&
                    0 <= ub && ub <= 1
                    )
                {
                    result = new Intersection(IntersectionStates.Intersection);
                    result.AppendPoint(new Point2D(a1X + (ua * (a2X - a1X)), a1Y + (ua * (a2Y - a1Y))));
                    //result.AppendPoint(new Point2D(b1X + ub * (b2X - b1X), b1Y + ub * (b2Y - b1Y)));
                }
                else
                {
                    result = new Intersection(IntersectionStates.NoIntersection);
                }
            }
            else
            {
                if (ua_t == 0 || ub_t == 0)
                {
                    result = new Intersection(IntersectionStates.Coincident | IntersectionStates.Parallel | IntersectionStates.Intersection);
                    result.AppendPoints(new List<(double X, double Y)> { (b1X, b1Y), (b2X, b2Y) });
                }
                else
                {
                    result = new Intersection(IntersectionStates.Parallel | IntersectionStates.NoIntersection);
                }
            }
            return result;
        }

        /// <summary>
        /// Find the intersection point between a line and a line segment.
        /// </summary>
        /// <param name="x0">The x component of the first point of the first line.</param>
        /// <param name="y0">The y component of the first point of the first line.</param>
        /// <param name="x1">The x component of the second point of the first line.</param>
        /// <param name="y1">The y component of the second point of the first line.</param>
        /// <param name="x2">The x component of the first point of the second line.</param>
        /// <param name="y2">The y component of the first point of the second line.</param>
        /// <param name="x3">The x component of the second point of the second line.</param>
        /// <param name="y3">The y component of the second point of the second line.</param>
        /// <param name="epsilon"></param>
        /// <returns>Returns the point of intersection.</returns>
        /// <acknowledgment>
        /// http://www.vb-helper.com/howto_segments_intersect.html
        /// </acknowledgment>
        [DisplayName("Intersection of a line and a line segment")]
        [Description("Find the intersection between a line and a line segment.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection LineLineSegmentIntersection2(
            double x0, double y0,
            double x1, double y1,
            double x2, double y2,
            double x3, double y3,
            double epsilon = Epsilon)
        {
            _ = epsilon;
            var result = new Intersection(IntersectionStates.NoIntersection);

            // Translate lines to origin.
            var u1 = x1 - x0;
            var v1 = y1 - y0;
            var u2 = x3 - x2;
            var v2 = y3 - y2;

            // Calculate the determinant of the coefficient matrix.
            var determinant = (v2 * u1) - (u2 * v1);

            // Check if the lines are parallel or coincident.
            if (Abs(determinant) < Epsilon)
            {
                return result;
            }

            // Find the index where the intersection point lies on the line.
            //var s = ((x0 - x2) * v1 + (y2 - y0) * u1) / -determinant;
            var t = (((x2 - x0) * v2) + ((y0 - y2) * u2)) / determinant;

            // Check whether the point is on the segment.
            if (t >= 0d && t <= 1d)
            {
                result = new Intersection(IntersectionStates.Intersection);
                result.AppendPoint(new Point2D(x0 + (t * u1), y0 + (t * v1)));
            }

            return result;
        }
    }
}
