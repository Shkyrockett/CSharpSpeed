using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using CSharpSpeed;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The polygon area tests class.
    /// </summary>
    [DisplayName("Polygon Signed Area")]
    [Description("Determine area of a polygon.")]
    [Signature("public static double PolygonArea(List<List<Point2D>> polygon)")]
    [SourceCodeLocationProvider]
    public static class PolygonAreaTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the area of a polygon.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(PolygonAreaTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 1000;
            var polygon = new List<Point2D> { new Point2D(0, 0), new Point2D(1, 0), new Point2D(1, 1) };
            //var PatrickMullenValues = PrecalcPointInPolygonContourPatrickMullenValues(polygon);
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { polygon }, new TestCaseResults(description:"polygon.", trials:trials, expectedReturnValue:0.5d, epsilon:double.Epsilon) },
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
        /// The polygon area00.
        /// </summary>
        /// <param name="polygon">The polygon.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// From http://www.angusj.com
        /// </acknowledgment>
        [DisplayName("Polygon area 1")]
        [Description("Find the area of a polygon.")]
        [Acknowledgment("http://www.angusj.com")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double PolygonArea00(List<Point2D> polygon)
        {
            var cnt = polygon.Count;
            if (cnt < 3)
            {
                return 0d;
            }

            var area = 0d;
            for (int i = 0, j = cnt - 1; i < cnt; ++i)
            {
                area += (polygon[j].X + polygon[i].X) * (polygon[j].Y - polygon[i].Y);
                j = i;
            }

            return -area * 0.5d;
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
        public static double PolygonArea0(IEnumerable<Point2D> polygon)
        {
            var points = polygon as List<Point2D>;
            var j = points.Count - 1;
            var area = 0d;
            for (var i = 0; i < points.Count; i++)
            {
                area += (points[j].X + points[i].X) * (points[j].Y - points[i].Y); j = i;
            }
            area *= 0.5d;
            return area < 0d ? -area : area;
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
        public static double PolygonArea1(List<Point2D> polygon)
        {
            var area = 0d;

            for (var i = 0; i < polygon.Count; i++)
            {
                var j = (i + 1) % polygon.Count;
                area += polygon[i].X * polygon[j].Y;
                area -= polygon[i].Y * polygon[j].X;
            }

            area /= 2d;
            return area < 0d ? -area : area;
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
        public static double PolygonArea2(List<Point2D> polygon)
        {
            var points = polygon;

            points.Add(points[0]);
            return Abs(points.Take(points.Count - 1)
               .Select((p, i) => (points[i + 1].X - p.X) * (points[i + 1].Y + p.Y))
               .Sum() / 2d);
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
        public static double PolygonArea3(List<Point2D> polygon)
        {
            polygon.Add(polygon[0]);
            return Abs(polygon.Take(polygon.Count - 1).Select((p, i) => (p.X * polygon[i + 1].Y) - (p.Y * polygon[i + 1].X)).Sum() / 2d);
        }

        /// <summary>
        /// The polygon area4.
        /// </summary>
        /// <param name="polygon">The polygon.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// https://github.com/onlyuser/Legacy/blob/master/msvb/Dex3d/Math.bas
        /// </acknowledgment>
        [DisplayName("Polygon area 6")]
        [Description("Find the area of a polygon.")]
        [Acknowledgment("https://github.com/onlyuser/Legacy/blob/master/msvb/Dex3d/Math.bas")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double PolygonArea4(List<Point2D> polygon)
        {
            if (polygon.Count < 3)
            {
                return 0d;
            }

            var area = MatrixDeterminant2x2Tests.Determinant(polygon[polygon.Count - 1].X, polygon[polygon.Count - 1].Y, polygon[0].X, polygon[0].Y);
            for (var i = 1; i < polygon.Count; i++)
            {
                area += MatrixDeterminant2x2Tests.Determinant(polygon[i - 1].X, polygon[i - 1].Y, polygon[i].X, polygon[i].Y);
            }
            return area / 2d;
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
        /// </summary>
        /// <param name="polygon">todo: describe polygon parameter on PolygonArea5</param>
        /// <returns>
        /// Return the absolute value of the signed area.
        /// The signed area is negative if the polygon is
        /// oriented clockwise.
        /// </returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/07/perform-geometric-operations-on-polygons-in-c/
        /// </acknowledgment>
        [DisplayName("Polygon area 6")]
        [Description("Find the area of a polygon.")]
        [Acknowledgment("http://csharphelper.com/blog/2014/07/perform-geometric-operations-on-polygons-in-c/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double PolygonArea5(IEnumerable<Point2D> polygon)
        {
            return Abs(PolygonSignedAreaTests.SignedPolygonArea5(polygon as List<Point2D>));
        }
    }
}
