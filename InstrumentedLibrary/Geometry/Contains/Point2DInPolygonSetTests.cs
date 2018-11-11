using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using CSharpSpeed;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The point2d in polygon set tests class.
    /// </summary>
    [DisplayName("Point in Polygon set")]
    [Description("Determine whether a point is contained within a Polygon set.")]
    [Signature("public static double PointInPolygonSet(List<List<Point2D>> polygon, Point2D point)")]
    [SourceCodeLocationProvider]
    public static class Point2DInPolygonSetTests
    {
        /// <summary>
        /// The point2d in polygon set test.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(Point2DInPolygonSetTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var point = new Point2D(1, 1);
            var polygon = new List<List<Point2D>> { new List<Point2D> { new Point2D(0, 0), new Point2D(2, 0), new Point2D(0, 2) } };
            //var PatrickMullenValues = PrecalcPointInPolygonContourPatrickMullenValues(polygon);
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { polygon, point }, new TestCaseResults(description:"polygon, point.", trials:trials, expectedReturnValue:true, epsilon:double.Epsilon) }
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
        /// This function automatically knows that enclosed polygons are "no-go" areas.
        /// </summary>
        /// <param name="point"></param>
        /// <param name="polygons"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// Public-domain code by Darel Rex Finley, 2006.
        /// http://alienryderflex.com/shortest_path/
        /// </acknowledgment>
        [DisplayName("Point in Polygon set")]
        [Description("AlienRyderFlex Point in Polygon set method.")]
        [Acknowledgment("http://alienryderflex.com/shortest_path/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonSetAlienRyderFlex(
            List<List<Point2D>> polygons,
            Point2D point)
        {
            var oddNodes = false;
            int j;

            for (var polyI = 0; polyI < polygons.Count; polyI++)
            {
                for (var i = 0; i < polygons[polyI].Count; i++)
                {
                    j = i + 1;
                    if (j == polygons[polyI].Count)
                    {
                        j = 0;
                    }

                    if (polygons[polyI][i].Y < point.Y
                    && polygons[polyI][j].Y >= point.Y
                    || polygons[polyI][j].Y < point.Y
                    && polygons[polyI][i].Y >= point.Y)
                    {
                        if (polygons[polyI][i].X + ((point.Y - polygons[polyI][i].Y)
                        / (polygons[polyI][j].Y - polygons[polyI][i].Y)
                        * (polygons[polyI][j].X - polygons[polyI][i].X)) < point.X)
                        {
                            oddNodes = !oddNodes;
                        }
                    }
                }
            }

            return oddNodes;
        }

        /// <summary>
        /// The point in polygon set.
        /// </summary>
        /// <param name="polygon">The polygon.</param>
        /// <param name="point">The point.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DisplayName("Point in Polygon set")]
        [Description("Point in Polygon set method.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonSet(List<List<Point2D>> polygon, Point2D point)
            => PointInPolygonSetShkyrockett(polygon, point) != Inclusion.Outside;

        /// <summary>
        /// This function automatically knows that enclosed polygons are "no-go" areas.
        /// </summary>
        /// <param name="point"></param>
        /// <param name="polygons"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion PointInPolygonSetShkyrockett(
            List<List<Point2D>> polygons,
            Point2D point)
        {
            var returnValue = Inclusion.Outside;

            foreach (List<Point2D> poly in polygons)
            {
                // Use alternating rule with XOR to determine if the point is in a polygon or a hole.
                // If the point is in an odd number of polygons, it is inside. If even, it is a hole.
                returnValue ^= Point2DInPolygonContourTests.PointInPolygonContourHormannAgathosExpanded(poly, point);

                // Any point on any boundary is on a boundary.
                if (returnValue == Inclusion.Boundary)
                {
                    return Inclusion.Boundary;
                }
            }

            return returnValue;
        }
    }
}
