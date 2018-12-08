using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The bounds of polygon contour tests class.
    /// </summary>
    [DisplayName("Polygon Contour Bounds Tests")]
    [Description("Calculate bounding rectangle of a polygon contour.")]
    [Signature("public static double PolygonContourBounds(IEnumerable<(double X, double Y)> points)")]
    [SourceCodeLocationProvider]
    public static class BoundsOfPolygonContourTests
    {
        /// <summary>
        /// Set of tests to run testing methods that Find the bounds of polygons.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(BoundsOfPolygonContourTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { new List<(double X, double Y)> { (10d, 10d), (25d, 5d), (5d, 30d) } }, new TestCaseResults(description:"Circle test case.", trials:trials, expectedReturnValue:Tau, epsilon:double.Epsilon) },
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
        /// Calculate the external bounding rectangle of a Polygon.
        /// </summary>
        /// <param name="polygon">The points of the polygon.</param>
        /// <returns></returns>
        [DisplayName("Polygon Contour Bounds")]
        [Description("Find bounds of a polygon.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rectangle2D? PolygonBounds0(IEnumerable<(double X, double Y)> polygon)
        {
            var points = polygon as List<(double X, double Y)>;
            if (points?.Count < 1)
            {
                return null;
            }

            var left = points[0].X;
            var top = points[0].Y;
            var right = points[0].X;
            var bottom = points[0].Y;

            foreach (var point in points)
            {
                // ToDo: Measure performance impact of overwriting each time.
                left = point.X <= left ? point.X : left;
                top = point.Y <= top ? point.Y : top;
                right = point.X >= right ? point.X : right;
                bottom = point.Y >= bottom ? point.Y : bottom;
            }

            return Rectangle2D.FromLTRB(left, top, right, bottom);
        }

        /// <summary>
        /// The polygon bounds1.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>The <see cref="Rectangle2D"/>.</returns>
        [DisplayName("Polygon Contour Bounds")]
        [Description("Find bounds of a polygon.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rectangle2D PolygonBounds1(List<(double X, double Y)> path)
        {
            var result = new Rectangle2D
            {
                Left = path[0].X,
                Top = path[0].Y,
                Right = path[0].X,
                Bottom = path[0].Y
            };

            for (var i = 0; i < path.Count; i++)
            {
                if (path[i].X < result.Left)
                {
                    result.Left = path[i].X;
                }
                else if (path[i].X > result.Right)
                {
                    result.Right = path[i].X;
                }

                if (path[i].Y < result.Top)
                {
                    result.Top = path[i].Y;
                }
                else if (path[i].Y > result.Bottom)
                {
                    result.Bottom = path[i].Y;
                }
            }

            return result;
        }
    }
}
