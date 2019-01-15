# Polygon Signed Area

Determine signed area of a polygon.

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

../../InstrumentedLibrary/Geometry/Area/PolygonSignedAreaTests.cs

The required method signature for this API is as follows:

```CSharp
public static double SignedPolygonArea(List<Point2D> polygon)
```

## Test Case Index

- [Test Case: (System.Collections.Generic.List`1[InstrumentedLibrary.Point2D])](#System.Collections.Generic.List`1[InstrumentedLibrary.Point2D])

### (System.Collections.Generic.List`1[InstrumentedLibrary.Point2D])

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [SignedPolygonArea0(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D])](#Polygon-area-2) | -0.5 == -0.5 | 1000 in 3 ms. 0.003 ms. average | polygon. |
| [SignedPolygonArea1(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D])](#Polygon-area-3) | -0.5 == -0.5 | 1000 in 9 ms. 0.009 ms. average | polygon. |
| [SignedPolygonArea2(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D])](#Polygon-area-4) | -0.5 == -0.5 | 1000 in 48 ms. 0.048 ms. average | polygon. |
| [SignedPolygonArea3(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D])](#Polygon-area-5) | -0.5 == -0.5 | 1000 in 151 ms. 0.151 ms. average | polygon. |
| [SignedPolygonArea5(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D])](#Polygon-area-6) | -0.5 == -0.5 | 1000 in 46 ms. 0.046 ms. average | polygon. |

## The Code

The code for the methods tested follows below.

### Polygon area 2

Find the area of a polygon.  
- [http://alienryderflex.com/polygon_area/](http://alienryderflex.com/polygon_area/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SignedPolygonArea0(IEnumerable<Point2D> polygon)
        {
            var points = polygon as List<Point2D>;
            var j = points.Count - 1;
            var area = 0d;
            for (var i = 0; i < points.Count; i++)
            {
                area += (points[j].X + points[i].X) * (points[j].Y - points[i].Y); j = i;
            }

            return area * 0.5d;
        }
```

### Polygon area 3

Find the area of a polygon.  
- [http://paulbourke.net/geometry/polygonmesh/source1.c](http://paulbourke.net/geometry/polygonmesh/source1.c)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SignedPolygonArea1(List<Point2D> polygon)
        {
            var area = 0d;

            for (var i = 0; i < polygon.Count; i++)
            {
                var j = (i + 1) % polygon.Count;
                area += polygon[i].X * polygon[j].Y;
                area -= polygon[i].Y * polygon[j].X;
            }

            area /= 2d;
            return -area;
        }
```

### Polygon area 4

Find the area of a polygon.  
- [http://stackoverflow.com/questions/2034540/calculating-area-of-irregular-polygon-in-c-sharp](http://stackoverflow.com/questions/2034540/calculating-area-of-irregular-polygon-in-c-sharp)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SignedPolygonArea2(List<Point2D> polygon)
        {
            var points = polygon;

            points.Add(points[0]);
            return points.Take(points.Count - 1)
               .Select((p, i) => (points[i + 1].X - p.X) * (points[i + 1].Y + p.Y))
               .Sum() / 2d;
        }
```

### Polygon area 5

Find the area of a polygon.  
- [http://stackoverflow.com/questions/2034540/calculating-area-of-irregular-polygon-in-c-sharp](http://stackoverflow.com/questions/2034540/calculating-area-of-irregular-polygon-in-c-sharp)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SignedPolygonArea3(List<Point2D> polygon)
        {
            polygon.Add(polygon[0]);
            return -polygon.Take(polygon.Count - 1).Select((p, i) => (p.X * polygon[i + 1].Y) - (p.Y * polygon[i + 1].X)).Sum() / 2d;
        }
```

### Polygon area 6

Find the area of a polygon.  
- [http://csharphelper.com/blog/2014/07/perform-geometric-operations-on-polygons-in-c/](http://csharphelper.com/blog/2014/07/perform-geometric-operations-on-polygons-in-c/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SignedPolygonArea5(List<Point2D> polygon)
        {
            // Add the first point to the end.
            var num_points = polygon.Count;
            var pts = new Point2D[num_points + 1];
            polygon.CopyTo(pts, 0);
            pts[num_points] = polygon[0];

            // Get the areas.
            var area = 0d;
            for (var i = 0; i < num_points; i++)
            {
                area += (pts[i + 1].X - pts[i].X) * (pts[i + 1].Y + pts[i].Y) / 2d;
            }

            // Return the result.
            return area;
        }
```

