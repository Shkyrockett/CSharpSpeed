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
    [SourceCodeLocationProvider]
    public static class PolygonContainsPointTests
    {
        /// <summary>
        /// The point2d in polygon set test.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(PolygonContainsPointTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var triangle = new List<List<(double X, double Y)>> { new List<(double X, double Y)> { (0d, 0d), (2d, 0d), (0d, 2d) } };
            //var PatrickMullenValues = PrecalcPointInPolygonContourPatrickMullenValues(polygon);
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { triangle, 1d, 1d }, new TestCaseResults(description: "Triangle, point inside.", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        /// <param name="polygon"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool PolygonContainsPoint(List<List<(double X, double Y)>> polygon, double X, double Y)
            => PointInPolygonSetShkyrockett0(polygon, X, Y);

        /// <summary>
        /// This function automatically knows that enclosed polygons are "no-go" areas.
        /// </summary>
        /// <param name="polygons"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
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
            List<List<(double X, double Y)>> polygons,
            double X, double Y)
        {
            var point = (X, Y);

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
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DisplayName("Point in Polygon set")]
        [Description("Point in Polygon set method.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonSetShkyrockett0(List<List<(double X, double Y)>> polygon, double X, double Y)
            => PointInPolygonSetShkyrockett(polygon, X, Y) != Inclusion.Outside;

        /// <summary>
        /// This function automatically knows that enclosed polygons are "no-go" areas.
        /// </summary>
        /// <param name="polygons"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion PointInPolygonSetShkyrockett(
            List<List<(double X, double Y)>> polygons,
             double X, double Y)
        {
            var returnValue = Inclusion.Outside;

            foreach (var poly in polygons)
            {
                // Use alternating rule with XOR to determine if the point is in a polygon or a hole.
                // If the point is in an odd number of polygons, it is inside. If even, it is a hole.
                returnValue ^= PolygonContourContainsPointTests.PointInPolygonContourHormannAgathosExpanded(poly, X, Y);

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
