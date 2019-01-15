# Square Distance between two points

Calculates the square distance between two points.

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

../../InstrumentedLibrary/Geometry/Length/SquareDistanceTests.cs

The required method signature for this API is as follows:

```CSharp
public static double SquareDistance(double x1, double y1, double x2, double y2)
```

## Test Case Index

- [Test Case: (1, 1, 2, 2)](#1,-1,-2,-2)

### (1, 1, 2, 2)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [SquareDistance0(1, 1, 2, 2)](#Square-Distance-between-two-points) | 2 != 15 | 10000 in 7 ms. 0.0007 ms. average | 1, 2, 3, 4, 5 |

## The Code

The code for the methods tested follows below.

### Square Distance between two points

Calculates the square distance between two points.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SquareDistance0(
            double x1, double y1,
            double x2, double y2)
        {
            return (x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1);
        }
```

