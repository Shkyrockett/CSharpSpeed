# Slope of 2 2D Points Tests

Estimations on the length of the Perimeter of an ellipse.

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

../../InstrumentedLibrary/Mathmatics/Vectors/Slope2Points2DTests.cs

The required method signature for this API is as follows:

```CSharp
public static double Slope(double x1, double y1, double x2, double y2)
```

## Test Case Index

- [Test Case: (0, 0, 1, 1)](#0,-0,-1,-1)

### (0, 0, 1, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Slope1(0, 0, 1, 1)](#Slope-of-two-Points) | 1 != 6.2831853071795862 | 10000 in 15 ms. 0.0015 ms. average | Circle test case. |
| [Slope2(0, 0, 1, 1)](#Slope-of-two-Points-2) | 1 != 6.2831853071795862 | 10000 in 15 ms. 0.0015 ms. average | Circle test case. |

## The Code

The code for the methods tested follows below.

### Slope of two Points

Find the slope of two points.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Slope1(
            double x1, double y1,
            double x2, double y2)
        {
            return (Abs(x1 - x2) < DoubleEpsilon) ? SlopeMax : ((y2 - y1) / (x2 - x1));
        }
```

### Slope of two Points 2

Find the slope of two points.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Slope2(
            double x1, double y1,
            double x2, double y2)
        {
            return SlopeVector2DTests.Slope(x2 - x1, y2 - y1);
        }
```

