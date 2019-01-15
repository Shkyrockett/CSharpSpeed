# Point Near Point Tests

Determines whether a point near another point.

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

../../InstrumentedLibrary/Geometry/Intersections/PointsAreCloseTests.cs

The required method signature for this API is as follows:

```CSharp
public static bool PointsAreClose(double x1, double y1, double x2, double y2, double epsilon = DoubleEpsilon)
```

## Test Case Index

- [Test Case: (1, 1, 2, 2, 2.22044604925031E-16)](#1,-1,-2,-2,-2.22044604925031E-16)

### (1, 1, 2, 2, 2.22044604925031E-16)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [AreClose0(1, 1, 2, 2, 2.22044604925031E-16)](#Point-Near-Point) | False != 15 | 10000 in 22 ms. 0.0022 ms. average | 1, 2, 3, 4, 5 |
| [AreClose1(1, 1, 2, 2, 2.22044604925031E-16)](#Point-Near-Point) | False != 15 | 10000 in 13 ms. 0.0013 ms. average | 1, 2, 3, 4, 5 |

## The Code

The code for the methods tested follows below.

### Point Near Point

Determines whether a point is on a line segment.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AreClose0(double x1, double y1, double x2, double y2, double epsilon = DoubleEpsilon)
        {
            return (Abs(x2 - x1) <= epsilon) && (Abs(y2 - y1) <= epsilon);
        }
```

### Point Near Point

Determines whether a point is on a line segment.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AreClose1(double x1, double y1, double x2, double y2, double epsilon = DoubleEpsilon)
        {
            return AreCloseTests.AreClose(x1, x2, epsilon)
                && AreCloseTests.AreClose(y1, y2, epsilon);
        }
```

