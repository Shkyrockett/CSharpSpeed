using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using CSharpSpeed;
using static System.Math;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The line segment in polygon tests class.
    /// </summary>
    [DisplayName("Line Segment In Polygon Tests")]
    [Description("Determine whether a line segment is contained within a Polygon set.")]
    [Signature("public static double PointInPolygonSet(List<List<Point2D>> polygon, Point2D point)")]
    [SourceCodeLocationProvider]
    public static class LineSegmentInPolygonTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(LineSegmentInPolygonTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var pointA = new Point2D(1, 1);
            var pointB = new Point2D(2, 2);
            var polygon = new PolygonContour(new List<Point2D> { new Point2D(0, 0), new Point2D(2, 0), new Point2D(0, 2) });
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { pointA, pointB, polygon }, new TestCaseResults(description:"polygon, point.", trials:trials, expectedReturnValue:true, epsilon:double.Epsilon) },
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
        /// This function should be called with the full set of *all* relevant polygons.
        /// (The algorithm automatically knows that enclosed polygons are “no-go” areas.)
        /// Note:  As much as possible, this algorithm tries to return YES when the
        /// test line-segment is exactly on the border of the polygon, particularly
        /// if the test line-segment *is* a side of a polygon.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// Public-domain code by Darel Rex Finley, 2006.
        /// http://alienryderflex.com/shortest_path/
        /// </acknowledgment>
        [DisplayName("Line in Polygon")]
        [Description("AlienRyderFlex Line in Polygon method.")]
        [Acknowledgment("http://alienryderflex.com/shortest_path/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool LineInPolygon(Point2D start, Point2D end, PolygonContour polygon)
        {
            int i;
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
            for (i = 0; i < polygon.Points.Count(); i++)
            {
                j = i + 1;
                if (j == polygon.Points.Count())
                {
                    j = 0;
                }

                sX = (polygon.Points as List<Point2D>)[i].X - start.X;
                sY = (polygon.Points as List<Point2D>)[i].Y - start.Y;
                eX = (polygon.Points as List<Point2D>)[j].X - start.X;
                eY = (polygon.Points as List<Point2D>)[j].Y - start.Y;
                if (Abs(sX) < DoubleEpsilon
                    && Abs(sY) < DoubleEpsilon
                    && Abs(eX - end.X) < DoubleEpsilon
                    && Abs(eY - end.Y) < DoubleEpsilon
                    || Abs(eX) < DoubleEpsilon
                    && Abs(eY) < DoubleEpsilon
                    && Abs(sX - end.X) < DoubleEpsilon
                    && Abs(sY - end.Y) < DoubleEpsilon)
                {
                    return true;
                }

                rotSX = (sX * theCos) + (sY * theSin);
                rotSY = (sY * theCos) - (sX * theSin);
                rotEX = (eX * theCos) + (eY * theSin);
                rotEY = (eY * theCos) - (eX * theSin);
                if (rotSY < 0d && rotEY > 0d
                || rotEY < 0d && rotSY > 0d)
                {
                    crossX = rotSX + ((rotEX - rotSX) * (0d - rotSY) / (rotEY - rotSY));
                    if (crossX >= 0.0 && crossX <= dist)
                    {
                        return false;
                    }
                }

                if (Abs(rotSY) < DoubleEpsilon
                    && Abs(rotEY) < DoubleEpsilon
                    && (rotSX >= 0d || rotEX >= 0d)
                    && (rotSX <= dist || rotEX <= dist)
                    && (rotSX < 0d || rotEX < 0d
                    || rotSX > dist || rotEX > dist))
                {
                    return false;
                }
            }

            return PolygonContourContainsPointTests.PointInPolygonContourAlienRyderFlex(polygon.Points.ToList(), new Point2D(start.X + (end.X * 0.5d), start.Y + (end.Y * 0.5d)));
        }
    }
}
