using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;
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
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(ShortestPathTests))]
        public static List<SpeedTester> TestHarness()
        {
            var set = new List<List<(double X, double Y)>>{
                // Boundary
                new List<(double X, double Y)> {
                    new Point2D(10, 10),
                    new Point2D(300, 10),
                    new Point2D(300, 300),
                    new Point2D(10, 300),
                    // Cut out
                    new Point2D(10, 200),
                    new Point2D(200, 80),
                    new Point2D(10, 150)
                },
                // First inner triangle
                new List<(double X, double Y)> {
                    new Point2D(20, 100),
                    new Point2D(175, 60),
                    new Point2D(40, 30)
                },
                // Second inner triangle
                new List<(double X, double Y)> {
                    new Point2D(250, 150),
                    new Point2D(150, 150),
                    new Point2D(250, 200)
                }
            };
            var trials = 100;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { set, new Point2D(20, 20), new Point2D(200, 200) }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: new Point2D(1.625d, 1.25d), epsilon: double.Epsilon) },
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
        /// <param name="polygons"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static List<(double X, double Y)> ShortestPath(List<List<(double X, double Y)>> polygons, Point2D start, Point2D end)
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
        public static List<(double X, double Y)> ShortestPath0(List<List<(double X, double Y)>> polygons, Point2D start, Point2D end)
        {
            // (larger than total solution dist could ever be)
            const double maxLength = double.MaxValue;// 9999999.0;

            var pointList = new List<AccumulatorPoint2D>();
            var solution = new List<(double x, double y)>();

            int pointCount, solutionNodes;

            int treeCount, polyI, i, j, bestI = 0, bestJ;
            double bestDist, newDist;

            //  Fail if either the start point or endpoint is outside the polygon set.
            if (!PolygonContainsPointTests.PolygonContainsPoint(polygons, start.X, start.Y)
            || !PolygonContainsPointTests.PolygonContainsPoint(polygons, end.X, end.Y))
            {
                return null;
            }

            //  If there is a straight-line solution, return with it immediately.
            if (PolygonContainsLineSegmentTests.PolygonContainsLineSegment(polygons, start, end))
            {
                return new List<(double X, double Y)> { start, end };
            }

            //  Build a point list that refers to the corners of the
            //  polygons, as well as to the start point and endpoint.
            pointList.Add(start);
            pointCount = 1;
            for (polyI = 0; polyI < polygons?.Count; polyI++)
            {
                for (i = 0; i < polygons[polyI].Count; i++)
                {
                    pointList.Add(new AccumulatorPoint2D(polygons[polyI][i]));
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
            return solution;
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
        public static List<(double X, double Y)> ShortestPath1(List<List<(double X, double Y)>> polygons, Point2D start, Point2D end)
        {
            // (larger than total solution dist could ever be)
            const double maxLength = double.MaxValue;

            var pointList = new List<AccumulatorPoint2D>();
            var solution = new List<(double X, double Y)>();

            int pointCount;
            int solutionNodes;

            int treeCount;
            var bestI = 0;
            int bestJ;
            double bestDist;
            double newDist;

            //  Fail if either the start point or endpoint is outside the polygon set.
            if (!PolygonContainsPointTests.PolygonContainsPoint(polygons, start.X, start.Y)
            || !PolygonContainsPointTests.PolygonContainsPoint(polygons, end.X, end.Y))
            {
                return null;
            }

            //  If there is a straight-line solution, return with it immediately.
            if (PolygonContainsLineSegmentTests.PolygonContainsLineSegment(polygons, start, end))
            {
                return new List<(double X, double Y)> { start, end };
            }

            //  Build a point list that refers to the corners of the
            //  polygons, as well as to the start point and endpoint.
            pointList.Add(start);
            pointCount = 1;
            if (!(polygons is null))
                foreach (var poly in polygons)
                {
                    foreach (var point in poly)
                    {
                        pointList.Add(new AccumulatorPoint2D(point));
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
                        if (PolygonContainsPointTests.PolygonContainsPoint(polygons, pointList[ti].X, pointList[ti].Y) && PolygonContainsPointTests.PolygonContainsPoint(polygons, pointList[tj].X, pointList[tj].Y))
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
            return solution;
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
        public static List<(double X, double Y)> ShortestPath2(List<List<(double X, double Y)>> polygons, Point2D start, Point2D end)
        {
            // Fail if either the start point or endpoint is outside the polygon set.
            if (!PolygonContainsPointTests.PolygonContainsPoint(polygons, start.X, start.Y)
            || !PolygonContainsPointTests.PolygonContainsPoint(polygons, end.X, end.Y))
            {
                return null;
            }

            // If there is a straight-line solution, return with it immediately.
            if (PolygonContainsLineSegmentTests.PolygonContainsLineSegment(polygons, start, end))
            {
                return new List<(double X, double Y)> { start, end };
            }

            // (larger than total solution dist could ever be)
            const double maxLength = double.MaxValue;

            var pointList = new List<(double X, double Y, double TotalDistance, int Previous)>();
            var solution = new List<(double X, double Y)>();

            int solutionNodes;

            int treeCount;
            var bestI = 0;
            int bestJ;
            double bestDist;
            double newDist;

            // Build a point list that refers to the corners of the
            // polygons, as well as to the start point and endpoint.
            pointList.Add((start.X, start.Y, 0, 0));
            if (!(polygons is null))
                foreach (var poly in polygons)
                {
                    foreach (var point in poly)
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
                        if (PolygonContainsPointsTests.PolygonContainsPoints(polygons, new Point2D(pointList[ti].X, pointList[ti].Y), new Point2D(pointList[tj].X, pointList[tj].Y)) == Inclusions.Inside)
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
            return solution;
        }
    }
}
