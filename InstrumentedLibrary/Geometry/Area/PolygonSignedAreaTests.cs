using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using CSharpSpeed;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The polygon area tests class.
    /// </summary>
    [DisplayName("Polygon Signed Area")]
    [Description("Determine signed area of a polygon.")]
    [Signature("public static double SignedPolygonArea(List<List<Point2D>> polygon)")]
    [SourceCodeLocationProvider]
    public static class PolygonSignedAreaTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the area of a polygon.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(PolygonSignedAreaTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 1000;
            var polygon = new List<Point2D> { new Point2D(0d, 0d), new Point2D(1d, 0d), new Point2D(1d, 1d) };
            //var PatrickMullenValues = PrecalcPointInPolygonContourPatrickMullenValues(polygon);
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { polygon }, new TestCaseResults(description:"polygon.", trials:trials, expectedReturnValue:-0.5d, epsilon:double.Epsilon) },
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
        /// The polygon area0.
        /// </summary>
        /// <param name="polygon">The polygon.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://alienryderflex.com/polygon_area/
        /// </acknowledgment>
        [DisplayName("Polygon area 2")]
        [Description("Find the area of a polygon.")]
        [Acknowledgment("http://alienryderflex.com/polygon_area/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SignedPolygonArea0(IEnumerable<Point2D> polygon)
        {
            var points = polygon as List<Point2D>;
            var j = points.Count - 1;
            var area = 0d;
            for (var i = 0; i < points.Count; i++)
            {
                area += (points[j].X + points[i].X) * (points[j].Y - points[i].Y); j = i;
            }

            return area * 0.5d;
        }

        /// <summary>
        /// The polygon area1.
        /// </summary>
        /// <param name="polygon">The polygon.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://paulbourke.net/geometry/polygonmesh/source1.c
        /// </acknowledgment>
        [DisplayName("Polygon area 3")]
        [Description("Find the area of a polygon.")]
        [Acknowledgment("http://paulbourke.net/geometry/polygonmesh/source1.c")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SignedPolygonArea1(List<Point2D> polygon)
        {
            var area = 0d;

            for (var i = 0; i < polygon.Count; i++)
            {
                var j = (i + 1) % polygon.Count;
                area += polygon[i].X * polygon[j].Y;
                area -= polygon[i].Y * polygon[j].X;
            }

            area /= 2d;
            return -area;
        }

        /// <summary>
        /// The polygon area2.
        /// </summary>
        /// <param name="polygon">The polygon.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/2034540/calculating-area-of-irregular-polygon-in-c-sharp
        /// </acknowledgment>
        [DisplayName("Polygon area 4")]
        [Description("Find the area of a polygon.")]
        [Acknowledgment("http://stackoverflow.com/questions/2034540/calculating-area-of-irregular-polygon-in-c-sharp")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SignedPolygonArea2(List<Point2D> polygon)
        {
            var points = polygon;

            points.Add(points[0]);
            return points.Take(points.Count - 1)
               .Select((p, i) => (points[i + 1].X - p.X) * (points[i + 1].Y + p.Y))
               .Sum() / 2d;
        }

        /// <summary>
        /// The polygon area3.
        /// </summary>
        /// <param name="polygon">The polygon.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/2034540/calculating-area-of-irregular-polygon-in-c-sharp
        /// </acknowledgment>
        [DisplayName("Polygon area 5")]
        [Description("Find the area of a polygon.")]
        [Acknowledgment("http://stackoverflow.com/questions/2034540/calculating-area-of-irregular-polygon-in-c-sharp")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SignedPolygonArea3(List<Point2D> polygon)
        {
            polygon.Add(polygon[0]);
            return -polygon.Take(polygon.Count - 1).Select((p, i) => (p.X * polygon[i + 1].Y) - (p.Y * polygon[i + 1].X)).Sum() / 2d;
        }

        /// <summary>
        /// Return the polygon's area in "square units."
        /// Add the areas of the trapezoids defined by the
        /// polygon's edges dropped to the X-axis. When the
        /// program considers a bottom edge of a polygon, the
        /// calculation gives a negative area so the space
        /// between the polygon and the axis is subtracted,
        /// leaving the polygon's area. This method gives odd
        /// results for non-simple polygons.
        /// The value will be negative if the polygon is
        /// oriented clockwise.
        /// </summary>
        /// <param name="polygon">todo: describe polygon parameter on PolygonArea5</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/07/perform-geometric-operations-on-polygons-in-c/
        /// </acknowledgment>
        [DisplayName("Polygon area 6")]
        [Description("Find the area of a polygon.")]
        [Acknowledgment("http://csharphelper.com/blog/2014/07/perform-geometric-operations-on-polygons-in-c/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SignedPolygonArea5(List<Point2D> polygon)
        {
            // Add the first point to the end.
            var num_points = polygon.Count;
            var pts = new Point2D[num_points + 1];
            polygon.CopyTo(pts, 0);
            pts[num_points] = polygon[0];

            // Get the areas.
            var area = 0d;
            for (var i = 0; i < num_points; i++)
            {
                area += (pts[i + 1].X - pts[i].X) * (pts[i + 1].Y + pts[i].Y) / 2d;
            }

            // Return the result.
            return area;
        }
    }
}
