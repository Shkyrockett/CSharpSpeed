# Point Near Line Segment Tests

Determines whether a point is near to a line segment.

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

../../InstrumentedLibrary/Geometry/Intersections/PointNearLineSegmentTests.cs

The required method signature for this API is as follows:

```CSharp
public static bool PointNearSegment(double px, double py, double x1, double y1, double x2, double y2, double close_distance)
```

## Test Case Index

- [Test Case: (1, 1, 2, 2, 1.5, 1.5, 5.6843418860808E-12)](#1,-1,-2,-2,-1.5,-1.5,-5.6843418860808E-12)

### (1, 1, 2, 2, 1.5, 1.5, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [PointNearSegment1(1, 1, 2, 2, 1.5, 1.5, 5.6843418860808E-12)](#Point-Near-Line-Segment-Tests) | False != 15 | 10000 in 11 ms. 0.0011 ms. average | 1, 2, 3, 4, 5 |

## The Code

The code for the methods tested follows below.

### Point Near Line Segment Tests

Determines whether a point is near to a line segment.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointNearSegment1(double px, double py, double x1, double y1, double x2, double y2, double close_distance)
        {
            return DistanceToLineSegmentTests.DistanceToSegment(px, py, x1, y1, x2, y2) <= close_distance;
        }
```

