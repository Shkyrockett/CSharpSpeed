using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;
using static InstrumentedLibrary.Maths;
using System.Linq;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The polygon set contains points tests class.
    /// </summary>
    [DisplayName("2 Point 2D Distance Tests")]
    [Description("Find the distance between two points.")]
    [Signature("public static double Distance2D(double x1, double y1, double x2, double y2)")]
    [SourceCodeLocationProvider]
    public static class PolygonSetContainsPointsTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(PolygonSetContainsPointsTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var pointA = new Point2D(1, 1);
            var pointB = new Point2D(2, 2);
            var polygon = new Polygon(new List<PolygonContour> { new PolygonContour(new List<Point2D> { new Point2D(0, 0), new Point2D(2, 0), new Point2D(0, 2) }) });
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { polygon, pointA, pointB ,Epsilon }, new TestCaseResults(description:".", trials:trials, expectedReturnValue:1d, epsilon:double.Epsilon) },
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
        /// The polygon set contains points.
        /// This function should be called with the full set of *all* relevant polygons.
        /// (The algorithm automatically knows that enclosed polygons are “no-go” areas.)
        /// Note:  As much as possible, this algorithm tries to return YES when the
        /// test line-segment is exactly on the border of the polygon, particularly
        /// if the test line-segment *is* a side of a polygon.
        /// </summary>
        /// <param name="polygons">The polygons.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns>The <see cref="Inclusion"/>.</returns>
        /// <acknowledgment>
        /// Public-domain code by Darel Rex Finley, 2006.
        /// http://alienryderflex.com/shortest_path/
        /// </acknowledgment>
        [DisplayName("Envelope Warp Method Inlined Interpolation")]
        [Description("A method of warping a point using an envelope of Cubic Beziers.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion PolygonSetContainsPoints(
            Polygon polygons,
            Point2D start, Point2D end,
            double epsilon = Epsilon)
        {
            int j;
            double sX;
            double sY;
            double eX;
            double eY;
            double rotSX;
            double rotSY;
            double rotEX;
            double rotEY;
            double crossX;

            end.X -= start.X;
            end.Y -= start.Y;
            var dist = Sqrt((end.X * end.X) + (end.Y * end.Y));
            var theCos = end.X / dist;
            var theSin = end.Y / dist;

            foreach (PolygonContour poly in polygons.Contours)
            {
                for (var i = 0; i < poly.Points.Count(); i++)
                {
                    j = i + 1;
                    if (j == poly.Points.Count())
                    {
                        j = 0;
                    }

                    sX = (poly.Points as List<Point2D>)[i].X - start.X;
                    sY = (poly.Points as List<Point2D>)[i].Y - start.Y;
                    eX = (poly.Points as List<Point2D>)[j].X - start.X;
                    eY = (poly.Points as List<Point2D>)[j].Y - start.Y;

                    if (Abs(sX) < epsilon && Abs(sY) < epsilon
                        && Abs(eX - end.X) < epsilon && Abs(eY - end.Y) < epsilon
                        || Abs(eX) < epsilon
                        && Abs(eY) < epsilon && Abs(sX - end.X) < epsilon
                        && Abs(sY - end.Y) < epsilon)
                    {
                        return Inclusion.Inside;
                    }

                    rotSX = (sX * theCos) + (sY * theSin);
                    rotSY = (sY * theCos) - (sX * theSin);
                    rotEX = (eX * theCos) + (eY * theSin);
                    rotEY = (eY * theCos) - (eX * theSin);

                    if (rotSY < 0.0 && rotEY > 0.0
                    || rotEY < 0.0 && rotSY > 0.0)
                    {
                        crossX = rotSX + ((rotEX - rotSX) * (0.0 - rotSY) / (rotEY - rotSY));
                        if (crossX >= 0.0 && crossX <= dist)
                        {
                            return Inclusion.Outside;
                        }
                    }

                    if (Abs(rotSY) < epsilon
                        && Abs(rotEY) < epsilon
                        && (rotSX >= 0.0 || rotEX >= 0.0)
                        && (rotSX <= dist || rotEX <= dist)
                        && (rotSX < 0.0 || rotEX < 0.0
                        || rotSX > dist || rotEX > dist))
                    {
                        return Inclusion.Outside;
                    }
                }
            }

            return Point2DInPolygonSetTests.PointInPolygonSetAlienRyderFlex(polygons, new Point2D(start.X + (end.X / 2.0), start.Y + (end.Y / 2.0))) ? Inclusion.Inside : Inclusion.Outside;
        }
    }
}
