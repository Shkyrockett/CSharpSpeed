using System;
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
            var polygon = new (double x, double y)[] { (0, 0), (1, 0), (1, 1) };
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { polygon }, new TestCaseResults(description: "polygon.", trials: trials, expectedReturnValue: (X: 0.66666666666666663d,YawRotateYOffsetTests: 0.33333333333333331d), epsilon: double.Epsilon) },
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
        /// <param name="polygon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Point2D Centroid((double x, double y)[] polygon)
            => Centroid0(polygon);

        /// <summary>
        /// Find the polygon's centroid.
        /// </summary>
        /// <param name="polygon"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/07/find-the-centroid-of-a-polygon-in-c/
        /// </acknowledgment>
        [DisplayName("Polygon Centroid")]
        [Description("Find the centroid of a polygon.")]
        [Acknowledgment("http://csharphelper.com/blog/2014/07/find-the-centroid-of-a-polygon-in-c/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D Centroid0((double x, double y)[] polygon)
        {
            // Add the first point at the end of the array.
            var num_points = polygon.Length;
            var pts = new (double X, double Y)[num_points + 1];
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
            var polygon_area = PolygonSignedAreaTests.SignedPolygonArea(polygon);
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

        /// <summary>
        /// Compute and return the centroid of the polygon.  See
        /// http://wikipedia.org/wiki/Centroid
        /// </summary>
        /// <param name="poly">The poly.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
        /// <acknowledgment>
        /// https://www.khanacademy.org/computer-programming/c/5567955982876672
        /// </acknowledgment>
        [DisplayName("Polygon Centroid")]
        [Description("Find the centroid of a polygon.")]
        [Acknowledgment("https://www.khanacademy.org/computer-programming/c/5567955982876672", "http://wikipedia.org/wiki/Centroid")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double x, double y) Centroid1((double x, double y)[] poly)
        {
            var area = 0d;
            var cx = 0d;
            var cy = 0d;
            for (int i = poly.Length - 1, j = 0; j < poly.Length; i = j, j++)
            {
                var a = (poly[i].x * poly[j].y) - (poly[j].x * poly[i].y);
                cx += (poly[i].x + poly[j].x) * a;
                cy += (poly[i].y + poly[j].y) * a;
                area += a;
            }
            area *= 3;
            return (x: cx / area, y: cy / area);
        }
    }
}
