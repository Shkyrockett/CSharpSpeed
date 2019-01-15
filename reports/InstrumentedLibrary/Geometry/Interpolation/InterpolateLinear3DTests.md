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

../../InstrumentedLibrary/Geometry/Interpolation/InterpolateLinear3DTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double X, double Y, double Z) LinearInterpolate3D(double x1, double y1, double z1, double x2, double y2, double z2, double t)
```

## Test Case Index

- [Test Case: (0, 0, 0, 1, 1, 1, 0.5)](#0,-0,-0,-1,-1,-1,-0.5)

### (0, 0, 0, 1, 1, 1, 0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [LinearInterpolate3D_0(0, 0, 0, 1, 1, 1, 0.5)](#Linear-Interpolate-1) | (0.5, 0.5, 0.5) == (0.5, 0.5, 0.5) | 10000 in 21 ms. 0.0021 ms. average |  |
| [LinearInterpolate3D_1(0, 0, 0, 1, 1, 1, 0.5)](#Linear-Interpolate-2) | (0.5, 0.5, 0.5) == (0.5, 0.5, 0.5) | 10000 in 20 ms. 0.002 ms. average |  |
| [LinearInterpolate3D_2(0, 0, 0, 1, 1, 1, 0.5)](#Linear-Interpolate-3) | (0.5, 0.5, 0.5) == (0.5, 0.5, 0.5) | 10000 in 15 ms. 0.0015 ms. average |  |
| [LinearInterpolate3D_3(0, 0, 0, 1, 1, 1, 0.5)](#Linear-Interpolate-4) | (0.5, 0.5, 0.5) == (0.5, 0.5, 0.5) | 10000 in 13 ms. 0.0013 ms. average |  |

## The Code

The code for the methods tested follows below.

### Linear Interpolate 1

Simple Linear Interpolation.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) LinearInterpolate3D_0(
            double x1, double y1, double z1,
            double x2, double y2, double z2,
            double t)
        {
            return (((1 - t) * x1) + (t * x2),
                    ((1 - t) * y1) + (t * y2),
                    ((1 - t) * z1) + (t * z2));
        }
```

### Linear Interpolate 2

Simple Linear Interpolation.  
- [http://www.cubic.org/docs/bezier.htm](http://www.cubic.org/docs/bezier.htm)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) LinearInterpolate3D_1(
            double x1, double y1, double z1,
            double x2, double y2, double z2,
            double t)
        {
            return (
                x1 + (t * (x2 - x1)),
                y1 + (t * (y2 - y1)),
                z1 + (t * (z2 - z1))
                );
        }
```

### Linear Interpolate 3

Simple Linear Interpolation.  
- [http://www.cubic.org/docs/bezier.htm](http://www.cubic.org/docs/bezier.htm)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) LinearInterpolate3D_2(
            double x1, double y1, double z1,
            double x2, double y2, double z2,
            double t)
        {
            return (
                InterpolateLinear1DTests.LinearInterpolate1D(x1, x2, t),
                InterpolateLinear1DTests.LinearInterpolate1D(y1, y2, t),
                InterpolateLinear1DTests.LinearInterpolate1D(z1, z2, t)
                );
        }
```

### Linear Interpolate 4

Simple Linear Interpolation.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) LinearInterpolate3D_3(
            double x1, double y1, double z1,
            double x2, double y2, double z2,
            double t)
        {
            return (
                (Abs(x1 - x2) < DoubleEpsilon) ? 0 : x1 - (1 / (x1 - x2) * t),
                (Abs(y1 - y2) < DoubleEpsilon) ? 0 : y1 - (1 / (y1 - y2) * t),
                (Abs(z1 - z2) < DoubleEpsilon) ? 0 : z1 - (1 / (z1 - z2) * t)
                );
        }
```

