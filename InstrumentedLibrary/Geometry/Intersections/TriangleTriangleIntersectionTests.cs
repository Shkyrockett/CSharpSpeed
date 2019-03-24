using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;
using System.Diagnostics;
using System.Reflection;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Intersection of Two Triangles")]
    [Description("Find the intersection points of two Triangles.")]
    [SourceCodeLocationProvider]
    public static class TriangleTriangleIntersectionTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 3D Hermite interpolation of points.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(LineSegmentLineSegmentIntersectionTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 2d, 2d, 1d, 2d, 0d, 1d, 2d, 2d, 0d, 2d, Epsilon }, new TestCaseResults(description: "Triangle, Triangle intersection.", trials: trials, expectedReturnValue: new Intersection(), epsilon: double.Epsilon) },
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
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <param name="x4"></param>
        /// <param name="y4"></param>
        /// <param name="x5"></param>
        /// <param name="y5"></param>
        /// <param name="x6"></param>
        /// <param name="y6"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Intersection TriangleTriangleIntersection(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4, double x5, double y5, double x6, double y6, double epsilon = Epsilon)
            => TriangleTriangleIntersection1(x1, y1, x2, y2, x3, y3, x4, y4, x5, y5, x6, y6, epsilon);

        /// <summary>
        /// Find the intersection between two triangles.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="x3">The x3.</param>
        /// <param name="y3">The y3.</param>
        /// <param name="x4">The x4.</param>
        /// <param name="y4">The y4.</param>
        /// <param name="x5">The x5.</param>
        /// <param name="y5">The y5.</param>
        /// <param name="x6">The x6.</param>
        /// <param name="y6">The y6.</param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns>Returns an <see cref="Intersection"/> struct with a <see cref="Intersection.State"/>, and an array of <see cref="Point2D"/> structs containing any points of intersection found.</returns>
        [DisplayName("Intersection of Two Triangles")]
        [Description("Find the intersection points of two Triangles.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection TriangleTriangleIntersection1(
            double x1, double y1, double x2, double y2, double x3, double y3,
            double x4, double y4, double x5, double y5, double x6, double y6,
            double epsilon = Epsilon)
        {
            // ToDo: Need to determine if duplicates are acceptable, or if this attempt at performance boost is going to waste.
            var intersections = new HashSet<(double X, double Y)>();

            var intersection = LineSegmentLineSegmentIntersectionTests.LineSegmentLineSegmentIntersection(x1, y1, x2, y2, x4, y4, x5, y5, epsilon).point;
            if (intersection != null) intersections.Add(intersection.Value);
            intersection = LineSegmentLineSegmentIntersectionTests.LineSegmentLineSegmentIntersection(x1, y1, x2, y2, x5, y5, x6, y6, epsilon).point;
            if (intersection != null) intersections.Add(intersection.Value);
            intersection = LineSegmentLineSegmentIntersectionTests.LineSegmentLineSegmentIntersection(x1, y1, x2, y2, x4, y4, x6, y6, epsilon).point;
            if (intersection != null) intersections.Add(intersection.Value);

            intersection = LineSegmentLineSegmentIntersectionTests.LineSegmentLineSegmentIntersection(x2, y2, x3, y3, x4, y4, x5, y5, epsilon).point;
            if (intersection != null) intersections.Add(intersection.Value);
            intersection = LineSegmentLineSegmentIntersectionTests.LineSegmentLineSegmentIntersection(x2, y2, x3, y3, x5, y5, x6, y6, epsilon).point;
            if (intersection != null) intersections.Add(intersection.Value);
            intersection = LineSegmentLineSegmentIntersectionTests.LineSegmentLineSegmentIntersection(x2, y2, x3, y3, x4, y4, x6, y6, epsilon).point;
            if (intersection != null) intersections.Add(intersection.Value);

            intersection = LineSegmentLineSegmentIntersectionTests.LineSegmentLineSegmentIntersection(x1, y1, x3, y3, x4, y4, x5, y5, epsilon).point;
            if (intersection != null) intersections.Add(intersection.Value);
            intersection = LineSegmentLineSegmentIntersectionTests.LineSegmentLineSegmentIntersection(x1, y1, x3, y3, x5, y5, x6, y6, epsilon).point;
            if (intersection != null) intersections.Add(intersection.Value);
            intersection = LineSegmentLineSegmentIntersectionTests.LineSegmentLineSegmentIntersection(x1, y1, x3, y3, x4, y4, x6, y6, epsilon).point;
            if (intersection != null) intersections.Add(intersection.Value);

            // ToDo: Return IntersectionState.Inside if all of the points of one triangle are inside the other triangle.

            var result = new Intersection(IntersectionState.NoIntersection, intersections);
            if (result.Points.Count > 0)
            {
                result.State = IntersectionState.Intersection;
            }

            return result;
        }
    }
}
