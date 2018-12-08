using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using CSharpSpeed;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The polygon centroid tests class.
    /// </summary>
    [DisplayName("Polygon Centroid")]
    [Description("Find the centroid point of a polygon.")]
    [Signature("public static Point2D Centroid(List<List<Point2D>> polygon)")]
    [SourceCodeLocationProvider]
    public static class PolygonCentroidTests
    {
        /// <summary>
        /// The polygon centroid test.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(PolygonCentroidTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 1000;
            var polygon = new List<Point2D> { new Point2D(0, 0), new Point2D(1, 0), new Point2D(1, 1) };
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { polygon }, new TestCaseResults(description:"polygon.", trials:trials, expectedReturnValue:new Point2D(0.66666666666666663d, 0.33333333333333331d), epsilon:double.Epsilon) },
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
        /// Find the polygon's centroid.
        /// </summary>
        /// <param name="polygon"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/07/find-the-centroid-of-a-polygon-in-c/
        /// </acknowledgment>
        [DisplayName("Polygon Centroid 6")]
        [Description("Find the centroid of a polygon.")]
        [Acknowledgment("http://csharphelper.com/blog/2014/07/find-the-centroid-of-a-polygon-in-c/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D Centroid(List<Point2D> polygon)
        {
            // Add the first point at the end of the array.
            var num_points = polygon.Count;
            var pts = new Point2D[num_points + 1];
            polygon.CopyTo(pts, 0);
            pts[num_points] = polygon[0];

            // Find the centroid.
            var X = 0d;
            var Y = 0d;
            double second_factor;
            for (var i = 0; i < num_points; i++)
            {
                second_factor =
                    (pts[i].X * pts[i + 1].Y)
                    - (pts[i + 1].X * pts[i].Y);
                X += (pts[i].X + pts[i + 1].X) * second_factor;
                Y += (pts[i].Y + pts[i + 1].Y) * second_factor;
            }

            // Divide by 6 times the polygon's area.
            var polygon_area = PolygonSignedAreaTests.SignedPolygonArea5(polygon);
            X /= 6d * polygon_area;
            Y /= 6d * polygon_area;

            // If the values are negative, the polygon is
            // oriented counterclockwise so reverse the signs.
            if (X < 0)
            {
                X = -X;
                Y = -Y;
            }

            return new Point2D(X, Y);
        }
    }
}
