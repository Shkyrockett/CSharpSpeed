using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;
using System.Diagnostics;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The shortest path tests class.
    /// </summary>
    [DisplayName("Shortest Path Polygon Tests")]
    [Description("Find the shortest path from one point to another through a polygon.")]
    [SourceCodeLocationProvider]
    public static class ShortestPathTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the wrapped angle of an angle.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(ShortestPathTests))]
        public static List<SpeedTester> TestHarness()
        {
            var set = new Polygon2D(
                new List<PolygonContour2D>(
                    new List<PolygonContour2D> {
                        new PolygonContour2D( // Boundary
                            new List<Point2D> {
                                new Point2D(10, 10),
                                new Point2D(300, 10),
                                new Point2D(300, 300),
                                new Point2D(10, 300),
                                // Cut out
                                new Point2D(10, 200),
                                new Point2D(200, 80),
                                new Point2D(10, 150)
                            }
                        ),
                        new PolygonContour2D( // First inner triangle
                            new List<Point2D> {
                                new Point2D(20, 100),
                                new Point2D(175, 60),
                                new Point2D(40, 30)
                            }
                        ),
                        new PolygonContour2D( // Second inner triangle
                            new List<Point2D> {
                                new Point2D(250, 150),
                                new Point2D(150, 150),
                                new Point2D(250, 200)
                            }
                        )
                    }
                )
            );
            var trials = 100;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { set, new Point2D(20, 20), new Point2D(200, 200) }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: new Point2D(1.625d, 1.25d), epsilon: double.Epsilon) },
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
        /// <param name="polygons"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static Polyline2D? ShortestPath(Polygon2D polygons, Point2D start, Point2D end)
            => ShortestPath0(polygons, start, end);

        /// <summary>
        /// Finds the shortest path from sX,sY to eX,eY that stays within the polygon set.
        /// Note:  To be safe, the solutionX and solutionY arrays should be large enough
        ///  to accommodate all the corners of your polygon set (although it is
        /// unlikely that anywhere near that many elements will ever be needed).
        /// Returns YES if the optimal solution was found, or NO if there is no solution.
        /// If a solution was found, solutionX and solutionY will contain the coordinates
        /// of the intermediate nodes of the path, in order.  (The start point and endpoint
        /// are assumed, and will not be included in the solution.)
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="polygons"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// Public-domain code by Darel Rex Finley, 2006.
        /// http://alienryderflex.com/shortest_path/
        /// </acknowledgment>
        [DisplayName("Shortest Path in Polygon")]
        [Description("AlienRyderFlex Shortest Path in Polygon method.")]
        [Acknowledgment("http://alienryderflex.com/shortest_path/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Polyline2D? ShortestPath0(Polygon2D polygons, Point2D start, Point2D end)
        {
            // (larger than total solution dist could ever be)
            const double maxLength = double.MaxValue;// 9999999.0;

            var pointList = new List<AccumulatorPoint2D>();
            var solution = new List<Point2D>();

            int pointCount, solutionNodes;

            int treeCount, polyI, i, j, bestI = 0, bestJ;
            double bestDist, newDist;

            //  Fail if either the start point or endpoint is outside the polygon set.
            if (!PolygonContainsPointTests.PolygonContainsPoint(polygons, start)
            || !PolygonContainsPointTests.PolygonContainsPoint(polygons, end))
            {
                return null;
            }

            //  If there is a straight-line solution, return with it immediately.
            if (PolygonContainsLineSegmentTests.PolygonContainsLineSegment(polygons, start, end))
            {
                return new Polyline2D(new List<Point2D> { start, end });
            }

            //  Build a point list that refers to the corners of the
            //  polygons, as well as to the start point and endpoint.
            pointList.Add(start);
            pointCount = 1;
            for (polyI = 0; polyI < polygons.Count; polyI++)
            {
                for (i = 0; i < ((polygons.Contours as List<PolygonContour2D>)[polyI].Points as List<Point2D>).Count; i++)
                {
                    pointList.Add(((polygons.Contours as List<PolygonContour2D>)[polyI].Points as List<Point2D>)[i]);
                    pointCount++;
                }
            }

            pointList.Add(end);
            pointCount++;

            //  Initialize the shortest-path tree to include just the start point.
            treeCount = 1;
            pointList[0] = new AccumulatorPoint2D(pointList[0].X, pointList[0].Y) { TotalDistance = 0d };

            //  Iteratively grow the shortest-path tree until it reaches the endpoint
            //  -- or until it becomes unable to grow, in which case exit with failure.
            bestJ = 0;
            while (bestJ < pointCount - 1)
            {
                bestDist = maxLength;
                for (i = 0; i < treeCount; i++)
                {
                    for (j = treeCount; j < pointCount; j++)
                    {
                        if (PolygonContainsLineSegmentTests.PolygonContainsLineSegment(polygons, pointList[i], pointList[j]))
                        {
                            newDist = pointList[i].TotalDistance + Distance2Point2DTests.Distance2D(pointList[i], pointList[j]);
                            if (newDist < bestDist)
                            {
                                bestDist = newDist;
                                bestI = i;
                                bestJ = j;
                            }
                        }
                    }
                }

                if (Abs(bestDist - maxLength) < DoubleEpsilon)
                {
                    return null;   //  (no solution)
                }

                pointList[bestJ] = new AccumulatorPoint2D(pointList[bestJ].X, pointList[bestJ].Y) { PreviousIndex = bestI, TotalDistance = bestDist };

                // Swap
                var temp = pointList[bestJ];
                pointList[bestJ] = pointList[treeCount];
                pointList[treeCount] = temp;

                treeCount++;
            }

            //  Load the solution arrays.
            solution.Add(start);
            solutionNodes = -1;
            i = treeCount - 1;
            while (i > 0)
            {
                i = pointList[i].PreviousIndex;
                solutionNodes++;
            }
            j = solutionNodes - 1;
            i = treeCount - 1;
            while (j >= 0)
            {
                i = pointList[i].PreviousIndex;
                solution.Insert(1, pointList[i]);
                j--;
            }
            solution.Add(end);

            //  Success.
            return new Polyline2D(solution);
        }

        /// <summary>
        /// Finds the shortest path from sX,sY to eX,eY that stays within the polygon set.
        /// Note:  To be safe, the solutionX and solutionY arrays should be large enough
        ///  to accommodate all the corners of your polygon set (although it is
        /// unlikely that anywhere near that many elements will ever be needed).
        /// Returns YES if the optimal solution was found, or NO if there is no solution.
        /// If a solution was found, solutionX and solutionY will contain the coordinates
        /// of the intermediate nodes of the path, in order.  (The start point and endpoint
        /// are assumed, and will not be included in the solution.)
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="polygons"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// Public-domain code by Darel Rex Finley, 2006.
        /// http://alienryderflex.com/shortest_path/
        /// </acknowledgment>
        [DisplayName("Shortest Path in Polygon")]
        [Description("AlienRyderFlex Shortest Path in Polygon method.")]
        [Acknowledgment("http://alienryderflex.com/shortest_path/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Polyline2D? ShortestPath1(Polygon2D polygons, Point2D start, Point2D end)
        {
            // (larger than total solution dist could ever be)
            const double maxLength = double.MaxValue;

            var pointList = new List<AccumulatorPoint2D>();
            var solution = new List<Point2D>();

            int pointCount;
            int solutionNodes;

            int treeCount;
            var bestI = 0;
            int bestJ;
            double bestDist;
            double newDist;

            //  Fail if either the start point or endpoint is outside the polygon set.
            if (!PolygonContainsPointTests.PolygonContainsPoint(polygons, start)
            || !PolygonContainsPointTests.PolygonContainsPoint(polygons, end))
            {
                return null;
            }

            //  If there is a straight-line solution, return with it immediately.
            if (PolygonContainsLineSegmentTests.PolygonContainsLineSegment(polygons, start, end))
            {
                return new Polyline2D(new List<Point2D> { start, end });
            }

            //  Build a point list that refers to the corners of the
            //  polygons, as well as to the start point and endpoint.
            pointList.Add(start);
            pointCount = 1;
            foreach (var poly in polygons.Contours)
            {
                foreach (var point in poly.Points)
                {
                    pointList.Add(point);
                    pointCount++;
                }
            }

            pointList.Add(end);
            pointCount++;

            //  Initialize the shortest-path tree to include just the start point.
            treeCount = 1;
            pointList[0] = new AccumulatorPoint2D(pointList[0]) { TotalDistance = 0d };

            //  Iteratively grow the shortest-path tree until it reaches the endpoint
            //  -- or until it becomes unable to grow, in which case exit with failure.
            bestJ = 0;
            while (bestJ < pointCount - 1)
            {
                bestDist = maxLength;
                for (var ti = 0; ti < treeCount; ti++)
                {
                    for (var tj = treeCount; tj < pointCount; tj++)
                    {
                        if (PolygonContainsPointTests.PolygonContainsPoint(polygons, pointList[ti]) && PolygonContainsPointTests.PolygonContainsPoint(polygons, pointList[tj]))
                        {
                            newDist = pointList[ti].TotalDistance + Distance2Point2DTests.Distance2D((Point2D)pointList[ti], (Point2D)pointList[tj]);
                            if (newDist < bestDist)
                            {
                                bestDist = newDist;
                                bestI = ti;
                                bestJ = tj;
                            }
                        }
                    }
                }

                if (Abs(bestDist - maxLength) < DoubleEpsilon)
                {
                    return null;   //  (no solution)
                }

                pointList[bestJ] = new AccumulatorPoint2D(pointList[bestJ]) { TotalDistance = bestDist, PreviousIndex = bestI, };

                // Swap
                var temp = pointList[bestJ];
                pointList[bestJ] = pointList[treeCount];
                pointList[treeCount] = temp;

                treeCount++;
            }

            //  Load the solution arrays.
            solution.Add(start);
            solutionNodes = -1;
            var i = treeCount - 1;
            while (i > 0)
            {
                i = pointList[i].PreviousIndex;
                solutionNodes++;
            }
            var j = solutionNodes - 1;
            i = treeCount - 1;
            while (j >= 0)
            {
                i = pointList[i].PreviousIndex;
                solution.Insert(1, pointList[i]);
                j--;
            }
            solution.Add(end);

            //  Success.
            return new Polyline2D(solution);
        }

        /// <summary>
        /// Finds the shortest path from sX,sY to eX,eY that stays within the polygon set.
        /// Note:  To be safe, the solutionX and solutionY arrays should be large enough
        ///  to accommodate all the corners of your polygon set (although it is
        /// unlikely that anywhere near that many elements will ever be needed).
        /// Returns YES if the optimal solution was found, or NO if there is no solution.
        /// If a solution was found, solutionX and solutionY will contain the coordinates
        /// of the intermediate nodes of the path, in order.  (The start point and endpoint
        /// are assumed, and will not be included in the solution.)
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="polygons"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// Public-domain code by Darel Rex Finley, 2006.
        /// http://alienryderflex.com/shortest_path/
        /// </acknowledgment>
        [DisplayName("Shortest Path in Polygon")]
        [Description("AlienRyderFlex Shortest Path in Polygon method.")]
        [Acknowledgment("http://alienryderflex.com/shortest_path/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Polyline2D? ShortestPath2(Polygon2D polygons, Point2D start, Point2D end)
        {
            // Fail if either the start point or endpoint is outside the polygon set.
            if (!PolygonContainsPointTests.PolygonContainsPoint(polygons, start)
            || !PolygonContainsPointTests.PolygonContainsPoint(polygons, end))
            {
                return null;
            }

            // If there is a straight-line solution, return with it immediately.
            if (PolygonContainsLineSegmentTests.PolygonContainsLineSegment(polygons, start, end))
            {
                return new Polyline2D(new List<Point2D> { start, end });
            }

            // (larger than total solution dist could ever be)
            const double maxLength = double.MaxValue;

            var pointList = new List<(double X, double Y, double TotalDistance, int Previous)>();
            var solution = new List<Point2D>();

            int solutionNodes;

            int treeCount;
            var bestI = 0;
            int bestJ;
            double bestDist;
            double newDist;

            // Build a point list that refers to the corners of the
            // polygons, as well as to the start point and endpoint.
            pointList.Add((start.X, start.Y, 0, 0));
            foreach (var poly in polygons.Contours)
            {
                foreach (var point in poly.Points)
                {
                    pointList.Add((point.X, point.Y, 0, 0));
                }
            }

            pointList.Add((end.X, end.Y, 0, 0));

            // Initialize the shortest-path tree to include just the start point.
            treeCount = 1;
            //pointList[0].TotalDistance = 0d;

            // Iteratively grow the shortest-path tree until it reaches the endpoint
            // or until it becomes unable to grow, in which case exit with failure.
            bestJ = 0;
            while (bestJ < pointList.Count - 1)
            {
                bestDist = maxLength;
                for (var ti = 0; ti < treeCount; ti++)
                {
                    for (var tj = treeCount; tj < pointList.Count; tj++)
                    {
                        if (PolygonContainsPointsTests.PolygonContainsPoints(polygons, new Point2D(pointList[ti].X, pointList[ti].Y), new Point2D(pointList[tj].X, pointList[tj].Y)) == Inclusion.Inside)
                        {
                            newDist = pointList[ti].TotalDistance + Distance2Point2DTests.Distance2D(new Point2D(pointList[ti].X, pointList[ti].Y), new Point2D(pointList[tj].X, pointList[tj].Y));
                            if (newDist < bestDist)
                            {
                                bestDist = newDist;
                                bestI = ti;
                                bestJ = tj;
                            }
                        }
                    }
                }

                if (bestDist == maxLength)
                {
                    return null; // (no solution)
                }

                pointList[bestJ] = (pointList[bestJ].X, pointList[bestJ].Y, bestDist, bestI);

                // Swap
                var temp = pointList[bestJ];
                pointList[bestJ] = pointList[treeCount];
                pointList[treeCount] = temp;

                treeCount++;
            }

            // Load the solution arrays.
            solution.Add(start);
            solutionNodes = -1;
            var i = treeCount - 1;
            while (i > 0)
            {
                i = pointList[i].Previous;
                solutionNodes++;
            }

            var j = solutionNodes - 1;
            i = treeCount - 1;
            while (j >= 0)
            {
                i = pointList[i].Previous;
                solution.Insert(1, new Point2D(pointList[i].X, pointList[i].Y));
                j--;
            }

            solution.Add(end);

            // Success.
            return new Polyline2D(solution);
        }
    }
}
