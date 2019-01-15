# Square Distance to line segment from point

Calculates the square distance from a point to the nearest point on a line segment.

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

../../InstrumentedLibrary/Geometry/Length/SquareDistanceToLineTests.cs

The required method signature for this API is as follows:

```CSharp
public static double SquareDistanceToLine(double x1, double y1, double x2_, double y2_, double x3_, double y3_)
```

## Test Case Index

- [Test Case: (1, 1, 2, 2, 1.5, 1.5)](#1,-1,-2,-2,-1.5,-1.5)

### (1, 1, 2, 2, 1.5, 1.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [SquareDistanceToLine0(1, 1, 2, 2, 1.5, 1.5)](#Square-Distance-to-line-segment-from-point) | 0 != 15 | 10000 in 11 ms. 0.0011 ms. average | 1, 2, 3, 4, 5 |

## The Code

The code for the methods tested follows below.

### Square Distance to line segment from point

Calculates the square distance from a point to the nearest point on a line segment.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SquareDistanceToLine0(
            double x1, double y1,
            double x2_, double y2_,
            double x3_, double y3_)
        {
            var A = y2_ - y3_;
            var B = x3_ - x2_;
            var C = A * x1 + B * y1 - (A * x2_ + B * y2_);
            return C * C / (A * A + B * B);
        }
```

