# Circle to Circular Arc Tests

Convert a Circle to a Circular Arc.

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

../../InstrumentedLibrary/Geometry/Conversions/CircleToCircularArcTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double X, double Y, double R, double startEngle, double SweepAngle) CircleToCircularArc(double x, double y, double r)
```

## Test Case Index

- [Test Case: (0, 0, 1)](#0,-0,-1)

### (0, 0, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CircleToCircularArc0(0, 0, 1)](#Circle-to-Circular-Arc) | (0, 0, 1, 0, 6.28318530717959) != (0, 1, 1.33333333333333, 2.33333333333333, 4.66666666666667, 5.66666666666667, 6, 7) | 10000 in 17 ms. 0.0017 ms. average |  |

## The Code

The code for the methods tested follows below.

### Circle to Circular Arc

Convert a Circle to a Circular Arc.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double R, double startEngle, double SweepAngle) CircleToCircularArc0(
            double x, double y,
            double r)
        {
            return (x, y, r, 0, Tau);
        }
```

