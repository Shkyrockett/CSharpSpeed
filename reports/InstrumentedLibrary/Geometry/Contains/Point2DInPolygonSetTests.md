# Point in Polygon set

Determine whether a point is contained within a Polygon set.

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

../../InstrumentedLibrary/Geometry/Contains/Point2DInPolygonSetTests.cs

The required method signature for this API is as follows:

```CSharp
public static bool PointInPolygonSet(List<List<Point2D>> polygon, Point2D point)
```

## Test Case Index

- [Test Case: (System.Collections.Generic.List`1[System.Collections.Generic.List`1[InstrumentedLibrary.Point2D]], Point2D{X:1, Y:1 })](#System.Collections.Generic.List`1[System.Collections.Generic.List`1[InstrumentedLibrary.Point2D]],-Point2D{X:1,-Y:1-})

### (System.Collections.Generic.List`1[System.Collections.Generic.List`1[InstrumentedLibrary.Point2D]], Point2D{X:1, Y:1 })

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [PointInPolygonSetAlienRyderFlex(System.Collections.Generic.List`1[System.Collections.Generic.List`1[InstrumentedLibrary.Point2D]], Point2D{X:1, Y:1 })](#Point-in-Polygon-set) | True == True | 10000 in 17 ms. 0.0017 ms. average | polygon, point. |
| [PointInPolygonSetShkyrockett0(System.Collections.Generic.List`1[System.Collections.Generic.List`1[InstrumentedLibrary.Point2D]], Point2D{X:1, Y:1 })](#Point-in-Polygon-set) | True == True | 10000 in 28 ms. 0.0028 ms. average | polygon, point. |

## The Code

The code for the methods tested follows below.

### Point in Polygon set

AlienRyderFlex Point in Polygon set method.  
- [http://alienryderflex.com/shortest_path/](http://alienryderflex.com/shortest_path/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonSetAlienRyderFlex(
            List<List<Point2D>> polygons,
            Point2D point)
        {
            var oddNodes = false;
            int j;

            for (var polyI = 0; polyI < polygons.Count; polyI++)
            {
                for (var i = 0; i < polygons[polyI].Count; i++)
                {
                    j = i + 1;
                    if (j == polygons[polyI].Count)
                    {
                        j = 0;
                    }

                    if (polygons[polyI][i].Y < point.Y
                    && polygons[polyI][j].Y >= point.Y
                    || polygons[polyI][j].Y < point.Y
                    && polygons[polyI][i].Y >= point.Y)
                    {
                        if (polygons[polyI][i].X + ((point.Y - polygons[polyI][i].Y)
                        / (polygons[polyI][j].Y - polygons[polyI][i].Y)
                        * (polygons[polyI][j].X - polygons[polyI][i].X)) < point.X)
                        {
                            oddNodes = !oddNodes;
                        }
                    }
                }
            }

            return oddNodes;
        }
```

### Point in Polygon set

Point in Polygon set method.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonSetShkyrockett0(List<List<Point2D>> polygon, Point2D point)
            => PointInPolygonSetShkyrockett(polygon, point) != Inclusion.Outside;

        /// <summary>
        /// This function automatically knows that enclosed polygons are "no-go" areas.
        /// </summary>
        /// <param name="point"></param>
        /// <param name="polygons"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion PointInPolygonSetShkyrockett(
            List<List<Point2D>> polygons,
            Point2D point)
        {
            var returnValue = Inclusion.Outside;

            foreach (List<Point2D> poly in polygons)
            {
                // Use alternating rule with XOR to determine if the point is in a polygon or a hole.
                // If the point is in an odd number of polygons, it is inside. If even, it is a hole.
                returnValue ^= PolygonContourContainsPointTests.PointInPolygonContourHormannAgathosExpanded(poly, point);

                // Any point on any boundary is on a boundary.
                if (returnValue == Inclusion.Boundary)
                {
                    return Inclusion.Boundary;
                }
            }

            return returnValue;
        }
```

