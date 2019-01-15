# Polygon Contour Bounds Tests

Calculate bounding rectangle of a polygon contour.

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

../../InstrumentedLibrary/Geometry/Bounds/BoundsOfPolygonContourTests.cs

The required method signature for this API is as follows:

```CSharp
public static Rectangle2D? PolygonBounds(List<(double X, double Y)> path)
```

## Test Case Index

- [Test Case: (System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]])](#System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]])

### (System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]])

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [PolygonBounds0(System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]])](#Polygon-Contour-Bounds) | Rectangle2D{X:5, Y:5, Width:20, Height:25 } != 6.2831853071795862 | 10000 in 35 ms. 0.0035 ms. average | Circle test case. |
| [PolygonBounds1(System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]])](#Polygon-Contour-Bounds) | Rectangle2D{X:5, Y:5, Width:20, Height:25 } != 6.2831853071795862 | 10000 in 29 ms. 0.0029 ms. average | Circle test case. |

## The Code

The code for the methods tested follows below.

### Polygon Contour Bounds

Find bounds of a polygon.  

```CSharp
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
```

### Polygon Contour Bounds

Find bounds of a polygon.  

```CSharp
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
```

