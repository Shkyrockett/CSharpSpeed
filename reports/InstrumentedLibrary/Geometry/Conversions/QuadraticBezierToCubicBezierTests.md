# Quadratic Bézier to Cubic Bézier Tests

Convert a Quadratic Bézier to a Cubic Bézier.

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

../../InstrumentedLibrary/Geometry/Conversions/QuadraticBezierToCubicBezierTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY) QuadraticBezierToCubicBezier(double aX, double aY, double bX, double bY, double cX, double cY)
```

## Test Case Index

- [Test Case: (0, 1, 2, 3, 4, 5)](#0,-1,-2,-3,-4,-5)

### (0, 1, 2, 3, 4, 5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [QuadraticBezierToCubicBezierTuple(0, 1, 2, 3, 4, 5)](#Quadratic-Bézier-to-Cubic-Bézier-Tests) | (0, 1, 1.33333333333333, 2.33333333333333, 2.66666666666667, 3.66666666666667, 4, 5) != (0, 1, 1.33333333333333, 2.33333333333333, 4.66666666666667, 5.66666666666667, 6, 7) | 10000 in 20 ms. 0.002 ms. average |  |

## The Code

The code for the methods tested follows below.

### Quadratic Bézier to Cubic Bézier Tests

Raise a Quadratic Bézier to a Cubic Bézier.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY) QuadraticBezierToCubicBezierTuple(
            double aX, double aY,
            double bX, double bY,
            double cX, double cY)
        {
            return (aX, aY,
                    aX + TwoThirds * (bX - aX), aY + TwoThirds * (bY - aY),
                    cX + TwoThirds * (bX - cX), cY + TwoThirds * (bY - cY),
                    cX, cY);
        }
```

