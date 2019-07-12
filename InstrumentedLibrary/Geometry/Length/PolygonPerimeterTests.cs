using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The polygon perimeter tests class.
    /// </summary>
    [DisplayName("Polygon Perimeter Tests")]
    [Description("Calculate the Perimeter of a polygon.")]
    [SourceCodeLocationProvider]
    public static class PolygonPerimeterTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(Distance2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { new List<(double X, double Y)> {(0d, 0d), (1d, 0d), (0d, 1d)} }, new TestCaseResults(description: "Circle test case.", trials: trials, expectedReturnValue:Tau, epsilon: double.Epsilon) },
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
        /// <param name="points"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static List<(double X, double Y)> PolygonPerimeter(List<(double X, double Y)> points)
            => PolygonPerimeter0(points);

        /// <summary>
        ///  Returns the perimeter polygon.
        ///  If for any reason the procedure fails, it will return null.
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://alienryderflex.com/polygon_perimeter/
        /// </acknowledgment>
        [DisplayName("Perimeter of Polygon")]
        [Description("Find Perimeter of a polygon.")]
        [Acknowledgment("http://alienryderflex.com/polygon_perimeter/")]
        [SourceCodeLocationProvider]
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<(double X, double Y)> PolygonPerimeter0(List<(double X, double Y)> points)
        {
            var corners = (points?.Count).Value;

            const int MAX_SEGS = 1000;

            var segS = new (double X, double Y)[corners];
            var segE = new (double X, double Y)[corners];
            var segAngle = new List<double>();
            var segRet = new List<(double X, double Y)>();
            (double X, double Y)? intersect;
            var start = points[0];
            var lastAngle = PI;
            var j = corners - 1;
            var segs = 0;

            if (corners > MAX_SEGS)
            {
                return null;
            }

            //  1,3.  Reformulate the polygon as a set of line segments, and choose a
            //        starting point that must be on the perimeter.
            for (var i = 0; i < corners; i++)
            {
                if (points[i].X != points[j].X || points[i].Y != points[j].Y)
                {
                    segS[segs] = (points[i].X, points[i].Y);
                    segE[segs] = (points[j].X, points[j].Y);
                }
                j = i;
                if (points[i].Y > start.Y || points[i].Y == start.Y && points[i].X < start.X)
                {
                    start.X = points[i].X;
                    start.Y = points[i].Y;
                }
            }
            if (segs == 0)
            {
                return null;
            }

            //  2.  Break the segments up at their intersection points.
            for (var i = 0; i < segs - 1; i++)
            {
                for (j = i + 1; j < segs; j++)
                {
                    var (intersects, point) = LineSegmentLineSegmentIntersectionTests.LineSegmentLineSegmentIntersection(
                    segS[i].X, segS[i].Y, segE[i].X, segE[i].Y,
                    segS[j].X, segS[j].Y, segE[j].X, segE[j].Y);
                    intersect = point;
                    if (intersects)
                    {
                        if ((intersect?.X != segS[i].X || intersect?.Y != segS[i].Y)
                        && (intersect?.X != segE[i].X || intersect?.Y != segE[i].Y))
                        {
                            if (segs == MAX_SEGS)
                            {
                                return null;
                            }

                            segS[segs] = (segS[i].X, segS[i].Y);
                            segE[segs] = ((double)intersect?.X, (double)intersect?.Y);
                            segS[i] = ((double)intersect?.X, (double)intersect?.Y);
                        }
                        if ((intersect?.X != segS[j].X || intersect?.Y != segS[j].Y)
                        && (intersect?.X != segE[j].X || intersect?.Y != segE[j].Y))
                        {
                            if (segs == MAX_SEGS)
                            {
                                return null;
                            }

                            segS[segs] = (segS[j].X, segS[j].Y);
                            segE[segs] = ((double)intersect?.X, (double)intersect?.Y);
                            segS[j] = ((double)intersect?.X, (double)intersect?.Y);
                        }
                    }
                }
            }

            //  Calculate the angle of each segment.
            for (var i = 0; i < segs; i++)
            {
                segAngle[i] = AngleofVector2DTests.AngleOfVector2D(segE[i].X - segS[i].X, segE[i].Y - segS[i].Y);
            }

            //  4.  Build the perimeter polygon.
            var c = start.X;
            var d = start.Y;
            var a = c - 1d;
            var b = d;
            double e = 0;
            double f = 0;
            segRet.Add((c, d));
            corners = 1;
            while (true)
            {
                var bestAngleDif = Tau;
                for (var i = 0; i < segs; i++)
                {
                    double angleDif;
                    if (segS[i].X == c && segS[i].Y == d && (segE[i].X != a || segE[i].Y != b))
                    {
                        angleDif = lastAngle - segAngle[i];
                        while (angleDif >= Tau)
                        {
                            angleDif -= Tau;
                        }

                        while (angleDif < 0)
                        {
                            angleDif += Tau;
                        }

                        if (angleDif < bestAngleDif)
                        {
                            bestAngleDif = angleDif; e = segE[i].X; f = segE[i].Y;
                        }
                    }
                    if (segE[i].X == c && segE[i].Y == d && (segS[i].X != a || segS[i].Y != b))
                    {
                        angleDif = lastAngle - segAngle[i] + (.5 * Tau);
                        while (angleDif >= Tau)
                        {
                            angleDif -= Tau;
                        }

                        while (angleDif < 0)
                        {
                            angleDif += Tau;
                        }

                        if (angleDif < bestAngleDif)
                        {
                            bestAngleDif = angleDif;
                            e = segS[i].X;
                            f = segS[i].Y;
                        }
                    }
                }
                if (corners > 1
                    && c == segRet[0].X
                    && d == segRet[0].Y
                    && e == segRet[1].X
                    && f == segRet[1].Y)
                {
                    corners--;
                    return segRet;
                }
                if (bestAngleDif == Tau || corners == MAX_SEGS)
                {
                    return null;
                }

                lastAngle -= bestAngleDif + (.5 * Tau);
                segRet[corners++] = (e, f);
                a = c;
                b = d;
                c = e;
                d = f;
            }
        }
    }
}
