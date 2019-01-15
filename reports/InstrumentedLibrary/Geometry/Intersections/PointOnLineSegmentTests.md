# Point On Line Segment Tests

Determines whether a point is on a line segment.

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

../../InstrumentedLibrary/Geometry/Intersections/PointOnLineSegmentTests.cs

The required method signature for this API is as follows:

```CSharp
public static bool PointOnLineSegment(double segmentAX, double segmentAY, double segmentBX, double segmentBY, double pointX, double pointY)
```

## Test Case Index

- [Test Case: (1, 1, 2, 2, 1.5, 1.5)](#1,-1,-2,-2,-1.5,-1.5)

### (1, 1, 2, 2, 1.5, 1.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [PointLineSegment(1, 1, 2, 2, 1.5, 1.5)](#Point-On-Line-Segment-Tests) | True != 15 | 10000 in 9 ms. 0.0009 ms. average | 1, 2, 3, 4, 5 |
| [PointLineSegment2(1, 1, 2, 2, 1.5, 1.5)](#Point-On-Line-Segment-Tests) | False != 15 | 10000 in 11 ms. 0.0011 ms. average | 1, 2, 3, 4, 5 |
| [PointOnLine(1, 1, 2, 2, 1.5, 1.5)](#Point-On-Line-Segment-Tests) | False != 15 | 10000 in 10 ms. 0.001 ms. average | 1, 2, 3, 4, 5 |

## The Code

The code for the methods tested follows below.

### Point On Line Segment Tests

Determines whether a point is on a line segment.  
- [http://www.angusj.com/delphi/clipper.php](http://www.angusj.com/delphi/clipper.php)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointLineSegment(
            double segmentAX,
            double segmentAY,
            double segmentBX,
            double segmentBY,
            double pointX,
            double pointY)
        {
            return ((pointX == segmentAX) && (pointY == segmentAY)) ||
                ((pointX == segmentBX) && (pointY == segmentBY)) ||
                (((pointX > segmentAX) == (pointX < segmentBX)) &&
                ((pointY > segmentAY) == (pointY < segmentBY)) &&
                ((pointX - segmentAX) * (segmentBY - segmentAY) ==
                (segmentBX - segmentAX) * (pointY - segmentAY)));
        }
```

### Point On Line Segment Tests

Determines whether a point is on a line segment.  
- [http://stackoverflow.com/questions/2255842/detecting-coincident-subset-of-two-coincident-line-segments/2255848](http://stackoverflow.com/questions/2255842/detecting-coincident-subset-of-two-coincident-line-segments/2255848)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointLineSegment2(
            double segmentAX,
            double segmentAY,
            double segmentBX,
            double segmentBY,
            double pointX,
            double pointY)
        {
            return DistanceToLineSegmentTests.DistanceToSegment(pointX, pointY, segmentAX, segmentAY, segmentBX, segmentBY) < Epsilon;
        }
```

### Point On Line Segment Tests

Determines whether a point is on a line segment.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointOnLine(
            double segmentAX,
            double segmentAY,
            double segmentBX,
            double segmentBY,
            double pointX,
            double pointY)
        {
            var Length1 = Distance2DTests.Distance2D(pointX, pointY, segmentBX, segmentBY);
            // Sqrt((Point.X - Line.B.X) ^ 2 + (Point.Y - Line.B.Y))
            var Length2 = Distance2DTests.Distance2D(pointX, pointY, segmentAX, segmentAY);
            // Sqrt((Point.X - Line.A.X) ^ 2 + (Point.Y - Line.A.Y))
            return Abs(Distance2DTests.Distance2D(segmentAX, segmentAY, segmentBX, segmentBY) - Length1 + Length2) < DoubleEpsilon;
        }
```

