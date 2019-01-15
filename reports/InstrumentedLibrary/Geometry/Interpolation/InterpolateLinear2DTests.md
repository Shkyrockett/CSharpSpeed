# Linear Interpolate Tests

Find a point on a line.

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

../../InstrumentedLibrary/Geometry/Interpolation/InterpolateLinear2DTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double X, double Y) LinearInterpolate2D(double x0, double y0, double x1, double y1, double t)
```

## Test Case Index

- [Test Case: (0, 0, 1, 1, 0.5)](#0,-0,-1,-1,-0.5)

### (0, 0, 1, 1, 0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Lerp_(0, 0, 1, 1, 0.5)](#Lerp) | (0.5, 0.5) == (0.5, 0.5) | 10000 in 10 ms. 0.001 ms. average |  |
| [LinearInterpolate2D_0(0, 0, 1, 1, 0.5)](#Linear-Interpolate-1) | (0.5, 0.5) == (0.5, 0.5) | 10000 in 10 ms. 0.001 ms. average |  |
| [LinearInterpolate2D_1(0, 0, 1, 1, 0.5)](#Linear-Interpolate-2) | (0.5, 0.5) == (0.5, 0.5) | 10000 in 8 ms. 0.0008 ms. average |  |
| [LinearInterpolate2D_2(0, 0, 1, 1, 0.5)](#Linear-Interpolate-3) | (0.5, 0.5) == (0.5, 0.5) | 10000 in 11 ms. 0.0011 ms. average |  |
| [LinearInterpolate2D_3(0, 0, 1, 1, 0.5)](#Linear-Interpolate-4) | (0.5, 0.5) == (0.5, 0.5) | 10000 in 11 ms. 0.0011 ms. average |  |

## The Code

The code for the methods tested follows below.

### Lerp

Simple Linear Interpolation.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) Lerp_(
            double x0, double y0,
            double x1, double y1,
            double t)
        {
            return (x0 + (x1 - x0) * t, y0 + (y1 - y0) * t);
        }
```

### Linear Interpolate 1

Simple Linear Interpolation.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) LinearInterpolate2D_0(
            double x1, double y1,
            double x2, double y2,
            double t)
        {
            return (
                ((1 - t) * x1) + (t * x2),
                ((1 - t) * y1) + (t * y2)
                );
        }
```

### Linear Interpolate 2

Simple Linear Interpolation.  
- [http://www.cubic.org/docs/bezier.htm](http://www.cubic.org/docs/bezier.htm)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) LinearInterpolate2D_1(
            double x1, double y1,
            double x2, double y2,
            double t)
        {
            return (
                x1 + (t * (x2 - x1)),
                y1 + (t * (y2 - y1))
                );
        }
```

### Linear Interpolate 3

Simple Linear Interpolation.  
- [http://www.cubic.org/docs/bezier.htm](http://www.cubic.org/docs/bezier.htm)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) LinearInterpolate2D_2(
            double x1, double y1,
            double x2, double y2,
            double t)
        {
            return (
                InterpolateLinear1DTests.LinearInterpolate1D(x1, x2, t),
                InterpolateLinear1DTests.LinearInterpolate1D(y1, y2, t)
                );
        }
```

### Linear Interpolate 4

Simple Linear Interpolation.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) LinearInterpolate2D_3(
            double x1, double y1,
            double x2, double y2,
            double t)
        {
            return (
                (Abs(x1 - x2) < DoubleEpsilon) ? 0 : x1 - (1 / (x1 - x2) * t),
                (Abs(y1 - y2) < DoubleEpsilon) ? 0 : y1 - (1 / (y1 - y2) * t)
                );
        }
```

