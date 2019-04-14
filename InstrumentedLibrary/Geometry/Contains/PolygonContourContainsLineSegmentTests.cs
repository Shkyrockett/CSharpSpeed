using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
    [Description("Determine whether a line segment is contained within a Polygon contour.")]
    [SourceCodeLocationProvider]
    public static class PolygonContourContainsLineSegmentTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(PolygonContourContainsLineSegmentTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            (double X, double Y) pointA = (1, 1);
            (double X, double Y) pointB = (2, 2);
            var triangle = new List<(double X, double Y)> { (0, 0), (2, 0), (0, 2) };
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { triangle, pointA, pointB }, new TestCaseResults(description: "Triangle, line segment outside.", trials: trials, expectedReturnValue: false, epsilon: double.Epsilon) },
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
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool PolygonContourContainsLineSegment(List<(double X, double Y)> polygon, (double X, double Y) start, (double X, double Y) end)
            => LineInPolygon0(polygon, start, end);

        /// <summary>
        /// This function should be called with the full set of *all* relevant polygons.
        /// (The algorithm automatically knows that enclosed polygons are “no-go” areas.)
        /// Note:  As much as possible, this algorithm tries to return YES when the
        /// test line-segment is exactly on the border of the polygon, particularly
        /// if the test line-segment *is* a side of a polygon.
        /// </summary>
        /// <param name="polygon"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
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
        public static bool LineInPolygon0(List<(double X, double Y)> polygon, (double X, double Y) start, (double X, double Y) end)
        {
            end.X -= start.X;
            end.Y -= start.Y;
            var dist = Sqrt((end.X * end.X) + (end.Y * end.Y));
            var theCos = end.X / dist;
            var theSin = end.Y / dist;
            var poly = polygon as List<(double X, double Y)>;
            for (var i = 0; i < poly.Count; i++)
            {
                var j = i + 1;
                if (j == poly.Count)
                {
                    j = 0;
                }

                var sX = poly[i].X - start.X;
                var sY = poly[i].Y - start.Y;
                var eX = poly[j].X - start.X;
                var eY = poly[j].Y - start.Y;
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

                var rotSX = (sX * theCos) + (sY * theSin);
                var rotSY = (sY * theCos) - (sX * theSin);
                var rotEX = (eX * theCos) + (eY * theSin);
                var rotEY = (eY * theCos) - (eX * theSin);
                if (rotSY < 0d && rotEY > 0d
                || rotEY < 0d && rotSY > 0d)
                {
                    var crossX = rotSX + ((rotEX - rotSX) * (0d - rotSY) / (rotEY - rotSY));
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

            return PolygonContourContainsPointTests.PolygonContourContainsPoint(poly, start.X + (end.X * 0.5d), start.Y + (end.Y * 0.5d));
        }
    }
}
