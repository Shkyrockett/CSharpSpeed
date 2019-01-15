# Polygon Clockwise

Determine the winding order of a polygon.

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

../../InstrumentedLibrary/Geometry/Polygon/PolygonIsOrientedClockwiseTests.cs

The required method signature for this API is as follows:

```CSharp
public static bool PolygonIsOrientedClockwise(List<Point2D> polygon)
```

## Test Case Index

- [Test Case: (System.Collections.Generic.List`1[InstrumentedLibrary.Point2D])](#System.Collections.Generic.List`1[InstrumentedLibrary.Point2D])

### (System.Collections.Generic.List`1[InstrumentedLibrary.Point2D])

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [PolygonIsOrientedClockwise0(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D])](#Polygon-Clockwise-6) | True == True | 1000 in 2 ms. 0.002 ms. average | polygon. |

## The Code

The code for the methods tested follows below.

### Polygon Clockwise 6

Determine if the polygon is built in a clockwise direction.  
- [http://csharphelper.com/blog/2014/07/find-the-centroid-of-a-polygon-in-c/](http://csharphelper.com/blog/2014/07/find-the-centroid-of-a-polygon-in-c/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PolygonIsOrientedClockwise0(List<Point2D> polygon)
        {
            return PolygonSignedAreaTests.SignedPolygonArea(polygon) < 0d;
        }
```

