# Polygon Centroid

Find the centroid point of a polygon.

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

../../InstrumentedLibrary/Geometry/Polygon/PolygonCentroidTests.cs

The required method signature for this API is as follows:

```CSharp
public static Point2D Centroid(List<Point2D> polygon)
```

## Test Case Index

- [Test Case: (System.Collections.Generic.List`1[InstrumentedLibrary.Point2D])](#System.Collections.Generic.List`1[InstrumentedLibrary.Point2D])

### (System.Collections.Generic.List`1[InstrumentedLibrary.Point2D])

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Centroid0(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D])](#Polygon-Centroid-6) | Point2D{X:0.66666666666666663, Y:0.33333333333333331 } == Point2D{X:0.66666666666666663, Y:0.33333333333333331 } | 1000 in 3 ms. 0.003 ms. average | polygon. |

## The Code

The code for the methods tested follows below.

### Polygon Centroid 6

Find the centroid of a polygon.  
- [http://csharphelper.com/blog/2014/07/find-the-centroid-of-a-polygon-in-c/](http://csharphelper.com/blog/2014/07/find-the-centroid-of-a-polygon-in-c/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D Centroid0(List<Point2D> polygon)
        {
            // Add the first point at the end of the array.
            var num_points = polygon.Count;
            var pts = new Point2D[num_points + 1];
            polygon.CopyTo(pts, 0);
            pts[num_points] = polygon[0];

            // Find the centroid.
            var X = 0d;
            var Y = 0d;
            double second_factor;
            for (var i = 0; i < num_points; i++)
            {
                second_factor =
                    (pts[i].X * pts[i + 1].Y)
                    - (pts[i + 1].X * pts[i].Y);
                X += (pts[i].X + pts[i + 1].X) * second_factor;
                Y += (pts[i].Y + pts[i + 1].Y) * second_factor;
            }

            // Divide by 6 times the polygon's area.
            var polygon_area = PolygonSignedAreaTests.SignedPolygonArea(polygon);
            X /= 6d * polygon_area;
            Y /= 6d * polygon_area;

            // If the values are negative, the polygon is
            // oriented counterclockwise so reverse the signs.
            if (X < 0)
            {
                X = -X;
                Y = -Y;
            }

            return new Point2D(X, Y);
        }
```

