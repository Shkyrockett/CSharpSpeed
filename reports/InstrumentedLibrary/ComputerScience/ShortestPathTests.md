# Shortest Path Polygon Tests

Find the shortest path from one point to another through a polygon.

> ## Machine Specs for this Runs Results
> The test cases below were run on a system with the following hardware specifications. Results will vary on the same system depending on current processing work load. So, take the numbers in the tables with a grain of salt.  
> **Processor:**  
> Name: Intel(R) Core(TM) i5-7200U CPU @ 2.50GHz  
  > **Physical Memory:**  
> Capacity: 8 GB  
> Speed: 1600 nanoseconds  
  > **Library Compiled as:**  
> Release  

## Results

../../InstrumentedLibrary/ComputerScience/ShortestPathTests.cs

The required method signature for this API is as follows:

```CSharp
public static Polyline2D? ShortestPath(Polygon2D polygons, Point2D start, Point2D end)
```

## Test Case Index

- [Test Case: (Polygon2D{PolygonContour2D{Point2D{X:10, Y:10 },Point2D{X:300, Y:10 },Point2D{X:300, Y:300 },Point2D{X:10, Y:300 },Point2D{X:10, Y:200 },Point2D{X:200, Y:80 },Point2D{X:10, Y:150 } },PolygonContour2D{Point2D{X:20, Y:100 },Point2D{X:175, Y:60 },Point2D{X:40, Y:30 } },PolygonContour2D{Point2D{X:250, Y:150 },Point2D{X:150, Y:150 },Point2D{X:250, Y:200 } } }, Point2D{X:20, Y:20 }, Point2D{X:200, Y:200 })](#Polygon2D{PolygonContour2D{Point2D{X:10,-Y:10-},Point2D{X:300,-Y:10-},Point2D{X:300,-Y:300-},Point2D{X:10,-Y:300-},Point2D{X:10,-Y:200-},Point2D{X:200,-Y:80-},Point2D{X:10,-Y:150-}-},PolygonContour2D{Point2D{X:20,-Y:100-},Point2D{X:175,-Y:60-},Point2D{X:40,-Y:30-}-},PolygonContour2D{Point2D{X:250,-Y:150-},Point2D{X:150,-Y:150-},Point2D{X:250,-Y:200-}-}-},-Point2D{X:20,-Y:20-},-Point2D{X:200,-Y:200-})

### (Polygon2D{PolygonContour2D{Point2D{X:10, Y:10 },Point2D{X:300, Y:10 },Point2D{X:300, Y:300 },Point2D{X:10, Y:300 },Point2D{X:10, Y:200 },Point2D{X:200, Y:80 },Point2D{X:10, Y:150 } },PolygonContour2D{Point2D{X:20, Y:100 },Point2D{X:175, Y:60 },Point2D{X:40, Y:30 } },PolygonContour2D{Point2D{X:250, Y:150 },Point2D{X:150, Y:150 },Point2D{X:250, Y:200 } } }, Point2D{X:20, Y:20 }, Point2D{X:200, Y:200 })

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [ShortestPath0(Polygon2D{PolygonContour2D{Point2D{X:10, Y:10 },Point2D{X:300, Y:10 },Point2D{X:300, Y:300 },Point2D{X:10, Y:300 },Point2D{X:10, Y:200 },Point2D{X:200, Y:80 },Point2D{X:10, Y:150 } },PolygonContour2D{Point2D{X:20, Y:100 },Point2D{X:175, Y:60 },Point2D{X:40, Y:30 } },PolygonContour2D{Point2D{X:250, Y:150 },Point2D{X:150, Y:150 },Point2D{X:250, Y:200 } } }, Point2D{X:20, Y:20 }, Point2D{X:200, Y:200 })](#Shortest-Path-in-Polygon) | Polyline2D{Point2D{X:20, Y:20 },Point2D{X:20, Y:100 },Point2D{X:200, Y:80 },Point2D{X:150, Y:150 },Point2D{X:200, Y:200 } } != Point2D{X:1.625, Y:1.25 } | 100 in 244 ms. 2.44 ms. average | Warp a point |
| [ShortestPath1(Polygon2D{PolygonContour2D{Point2D{X:10, Y:10 },Point2D{X:300, Y:10 },Point2D{X:300, Y:300 },Point2D{X:10, Y:300 },Point2D{X:10, Y:200 },Point2D{X:200, Y:80 },Point2D{X:10, Y:150 } },PolygonContour2D{Point2D{X:20, Y:100 },Point2D{X:175, Y:60 },Point2D{X:40, Y:30 } },PolygonContour2D{Point2D{X:250, Y:150 },Point2D{X:150, Y:150 },Point2D{X:250, Y:200 } } }, Point2D{X:20, Y:20 }, Point2D{X:200, Y:200 })](#Shortest-Path-in-Polygon) | Polyline2D{Point2D{X:20, Y:20 },Point2D{X:20, Y:100 },Point2D{X:200, Y:200 } } != Point2D{X:1.625, Y:1.25 } | 100 in 26 ms. 0.26 ms. average | Warp a point |

## The Code

The code for the methods tested follows below.

### Shortest Path in Polygon

AlienRyderFlex Shortest Path in Polygon method.  
- [http://alienryderflex.com/shortest_path/](http://alienryderflex.com/shortest_path/)

```CSharp
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
            if (!Point2DInPolygonSetTests.PointInPolygonSetAlienRyderFlex(polygons, start)
            || !Point2DInPolygonSetTests.PointInPolygonSetAlienRyderFlex(polygons, end))
            {
                return null;
            }

            //  If there is a straight-line solution, return with it immediately.
            if (LineSegmentInPolygonSetTests.LineInPolygonSet(polygons, start, end))
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
                        if (LineSegmentInPolygonSetTests.LineInPolygonSet(polygons, pointList[i], pointList[j]))
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
```

### Shortest Path in Polygon

AlienRyderFlex Shortest Path in Polygon method.  
- [http://alienryderflex.com/shortest_path/](http://alienryderflex.com/shortest_path/)

```CSharp
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
            if (!Point2DInPolygonSetTests.PointInPolygonSetAlienRyderFlex(polygons, start)
            || !Point2DInPolygonSetTests.PointInPolygonSetAlienRyderFlex(polygons, end))
            {
                return null;
            }

            //  If there is a straight-line solution, return with it immediately.
            if (LineSegmentInPolygonSetTests.LineInPolygonSet(polygons, start, end))
            {
                return new Polyline2D(new List<Point2D> { start, end });
            }

            //  Build a point list that refers to the corners of the
            //  polygons, as well as to the start point and endpoint.
            pointList.Add(start);
            pointCount = 1;
            foreach (PolygonContour2D poly in polygons.Contours)
            {
                foreach (Point2D point in poly.Points)
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
                        if (Point2DInPolygonSetTests.PointInPolygonSetAlienRyderFlex(polygons, pointList[ti]) && Point2DInPolygonSetTests.PointInPolygonSetAlienRyderFlex(polygons, pointList[tj]))
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
```

