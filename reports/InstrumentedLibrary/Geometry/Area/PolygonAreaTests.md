# Polygon Signed Area

Determine area of a polygon.

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

../../InstrumentedLibrary/Geometry/Area/PolygonAreaTests.cs

The required method signature for this API is as follows:

```CSharp
public static double PolygonArea(List<Point2D> polygon)
```

## Test Case Index

- [Test Case: (System.Collections.Generic.List`1[InstrumentedLibrary.Point2D])](#System.Collections.Generic.List`1[InstrumentedLibrary.Point2D])

### (System.Collections.Generic.List`1[InstrumentedLibrary.Point2D])

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [PolygonArea2(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D])](#Polygon-area-4) | 0.5 == 0.5 | 1000 in 63 ms. 0.063 ms. average | polygon. |
| [PolygonArea3(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D])](#Polygon-area-5) | 0.5 == 0.5 | 1000 in 159 ms. 0.159 ms. average | polygon. |
| [PolygonArea5(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D])](#Polygon-area-6) | 0.5 == 0.5 | 1000 in 91 ms. 0.091 ms. average | polygon. |
| [PolygonAreaAlienRyderFlex(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D])](#Polygon-area-2) | 0.5 == 0.5 | 1000 in 71 ms. 0.071 ms. average | polygon. |
| [PolygonAreaAngusJ(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D])](#Polygon-area-1) | 0.5 == 0.5 | 1000 in 96 ms. 0.096 ms. average | polygon. |
| [PolygonAreaOnlyUser(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D])](#Polygon-area-6) | 0.5 == 0.5 | 1000 in 102 ms. 0.102 ms. average | polygon. |
| [PolygonAreaPaulBourke(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D])](#Polygon-area-3) | 0.5 == 0.5 | 1000 in 140 ms. 0.14 ms. average | polygon. |

## The Code

The code for the methods tested follows below.

### Polygon area 4

Find the area of a polygon.  
- [http://stackoverflow.com/questions/2034540/calculating-area-of-irregular-polygon-in-c-sharp](http://stackoverflow.com/questions/2034540/calculating-area-of-irregular-polygon-in-c-sharp)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double PolygonArea2(List<Point2D> polygon)
        {
            var points = polygon;

            points.Add(points[0]);
            return Abs(points.Take(points.Count - 1)
               .Select((p, i) => (points[i + 1].X - p.X) * (points[i + 1].Y + p.Y))
               .Sum() / 2d);
        }
```

### Polygon area 5

Find the area of a polygon.  
- [http://stackoverflow.com/questions/2034540/calculating-area-of-irregular-polygon-in-c-sharp](http://stackoverflow.com/questions/2034540/calculating-area-of-irregular-polygon-in-c-sharp)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double PolygonArea3(List<Point2D> polygon)
        {
            polygon.Add(polygon[0]);
            return Abs(polygon.Take(polygon.Count - 1).Select((p, i) => (p.X * polygon[i + 1].Y) - (p.Y * polygon[i + 1].X)).Sum() / 2d);
        }
```

### Polygon area 6

Find the area of a polygon.  
- [http://csharphelper.com/blog/2014/07/perform-geometric-operations-on-polygons-in-c/](http://csharphelper.com/blog/2014/07/perform-geometric-operations-on-polygons-in-c/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double PolygonArea5(IEnumerable<Point2D> polygon)
        {
            return Abs(PolygonSignedAreaTests.SignedPolygonArea(polygon as List<Point2D>));
        }
```

### Polygon area 2

Find the area of a polygon.  
- [http://alienryderflex.com/polygon_area/](http://alienryderflex.com/polygon_area/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double PolygonAreaAlienRyderFlex(IEnumerable<Point2D> polygon)
        {
            var points = polygon as List<Point2D>;
            var j = points.Count - 1;
            var area = 0d;
            for (var i = 0; i < points.Count; i++)
            {
                area += (points[j].X + points[i].X) * (points[j].Y - points[i].Y); j = i;
            }
            area *= 0.5d;
            return area < 0d ? -area : area;
        }
```

### Polygon area 1

Find the area of a polygon.  
- [http://www.angusj.com](http://www.angusj.com)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double PolygonAreaAngusJ(List<Point2D> polygon)
        {
            var cnt = polygon.Count;
            if (cnt < 3)
            {
                return 0d;
            }

            var area = 0d;
            for (int i = 0, j = cnt - 1; i < cnt; ++i)
            {
                area += (polygon[j].X + polygon[i].X) * (polygon[j].Y - polygon[i].Y);
                j = i;
            }

            return -area * 0.5d;
        }
```

### Polygon area 6

Find the area of a polygon.  
- [https://github.com/onlyuser/Legacy/blob/master/msvb/Dex3d/Math.bas](https://github.com/onlyuser/Legacy/blob/master/msvb/Dex3d/Math.bas)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double PolygonAreaOnlyUser(List<Point2D> polygon)
        {
            if (polygon.Count < 3)
            {
                return 0d;
            }

            var area = MatrixDeterminant2x2Tests.Determinant(polygon[polygon.Count - 1].X, polygon[polygon.Count - 1].Y, polygon[0].X, polygon[0].Y);
            for (var i = 1; i < polygon.Count; i++)
            {
                area += MatrixDeterminant2x2Tests.Determinant(polygon[i - 1].X, polygon[i - 1].Y, polygon[i].X, polygon[i].Y);
            }
            return area / 2d;
        }
```

### Polygon area 3

Find the area of a polygon.  
- [http://paulbourke.net/geometry/polygonmesh/source1.c](http://paulbourke.net/geometry/polygonmesh/source1.c)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double PolygonAreaPaulBourke(List<Point2D> polygon)
        {
            var area = 0d;

            for (var i = 0; i < polygon.Count; i++)
            {
                var j = (i + 1) % polygon.Count;
                area += polygon[i].X * polygon[j].Y;
                area -= polygon[i].Y * polygon[j].X;
            }

            area /= 2d;
            return area < 0d ? -area : area;
        }
```

