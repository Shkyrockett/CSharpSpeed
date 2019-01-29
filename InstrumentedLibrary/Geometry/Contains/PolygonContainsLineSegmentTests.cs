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
    /// The line segment in polygon set tests class.
    /// </summary>
    [DisplayName("Line Segment In Polygon Tests")]
    [Description("Determine whether a line segment is contained within a Polygon set.")]
    [SourceCodeLocationProvider]
    public static class PolygonContainsLineSegmentTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(PolygonContainsLineSegmentTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var pointA = new Point2D(1, 1);
            var pointB = new Point2D(2, 2);
            var triangle = new Polygon2D(new List<PolygonContour2D> { new PolygonContour2D(new List<Point2D> { new Point2D(0, 0), new Point2D(2, 0), new Point2D(0, 2) }) });
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] {  triangle, pointA, pointB}, new TestCaseResults(description: "triangle, line segment outside.", trials: trials, expectedReturnValue: false, epsilon: double.Epsilon) },
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
        /// <param name="allPolys"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool PolygonContainsLineSegment(Polygon2D allPolys, Point2D start, Point2D end)
            => LineInPolygonSet1( allPolys,  start,  end);

        /// <summary>
        /// This function should be called with the full set of *all* relevant polygons.
        /// (The algorithm automatically knows that enclosed polygons are “no-go” areas.)
        /// Note:  As much as possible, this algorithm tries to return YES when the
        /// test line-segment is exactly on the border of the polygon, particularly
        /// if the test line-segment *is* a side of a polygon.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="allPolys"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// Public-domain code by Darel Rex Finley, 2006.
        /// http://alienryderflex.com/shortest_path/
        /// </acknowledgment>
        [DisplayName("Line in Polygon Set")]
        [Description("AlienRyderFlex Line in Polygon set method.")]
        [Acknowledgment("http://alienryderflex.com/shortest_path/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool LineInPolygonSet1(Polygon2D allPolys, Point2D start, Point2D end)
        {
            double theCos, theSin, dist, sX, sY, eX, eY, rotSX, rotSY, rotEX, rotEY, crossX;
            int i, j, polyI;

            end.X -= start.X;
            end.Y -= start.Y;
            dist = Sqrt((end.X * end.X) + (end.Y * end.Y));
            theCos = end.X / dist;
            theSin = end.Y / dist;

            for (polyI = 0; polyI < allPolys.Count; polyI++)
            {
                for (i = 0; i < ((allPolys.Contours as List<PolygonContour2D>)[polyI].Points as List<Point2D>).Count; i++)
                {
                    j = i + 1;
                    if (j == ((allPolys.Contours as List<PolygonContour2D>)[polyI].Points as List<Point2D>).Count)
                    {
                        j = 0;
                    }

                    sX = ((allPolys.Contours as List<PolygonContour2D>)[polyI].Points as List<Point2D>)[i].X - start.X;
                    sY = ((allPolys.Contours as List<PolygonContour2D>)[polyI].Points as List<Point2D>)[i].Y - start.Y;
                    eX = ((allPolys.Contours as List<PolygonContour2D>)[polyI].Points as List<Point2D>)[j].X - start.X;
                    eY = ((allPolys.Contours as List<PolygonContour2D>)[polyI].Points as List<Point2D>)[j].Y - start.Y;
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
                        if (crossX >= 0d && crossX <= dist)
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
            }

            return PolygonContainsPointTests.PolygonContainsPoint(allPolys, new Point2D(start.X + (end.X * 0.5d), start.Y + (end.Y * 0.5d)));
        }
    }
}
