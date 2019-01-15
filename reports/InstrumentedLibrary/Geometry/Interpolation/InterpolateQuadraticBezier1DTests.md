# Quadratic Bezier Interpolate 1D Tests

Find a point on a 1D Quadratic Bezier curve.

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

../../InstrumentedLibrary/Geometry/Interpolation/InterpolateQuadraticBezier1DTests.cs

The required method signature for this API is as follows:

```CSharp
public static double QuadraticBezierInterpolate1D(double v0, double v1, double v2, double t)
```

## Test Case Index

- [Test Case: (0, 1, 2, 0.5)](#0,-1,-2,-0.5)

### (0, 1, 2, 0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [QuadraticBezierInterpolate1D_0(0, 1, 2, 0.5)](#Quadratic-Bezier-Interpolate-1) | 1 == 1 | 10000 in 8 ms. 0.0008 ms. average | . |
| [QuadraticBezierInterpolate1D_1(0, 1, 2, 0.5)](#Quadratic-Bezier-Interpolate-2) | 1 == 1 | 10000 in 7 ms. 0.0007 ms. average | . |

## The Code

The code for the methods tested follows below.

### Quadratic Bezier Interpolate 1

Simple Quadratic Bezier Interpolation.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double QuadraticBezierInterpolate1D_0(
            double v0,
            double v1,
            double v2,
            double t)
        {
            var mu1 = 1 - t;
            var mu12 = mu1 * mu1;
            var mu2 = t * t;

            return (v0 * mu12) + (2 * v1 * mu1 * t) + (v2 * mu2);
        }
```

### Quadratic Bezier Interpolate 2

Simple Quadratic Bezier Interpolation.  
- [http://www.cubic.org/docs/bezier.htm](http://www.cubic.org/docs/bezier.htm)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double QuadraticBezierInterpolate1D_1(
            double v0,
            double v1,
            double v2,
            double t)
        {
            // point between a and b
            var ab = InterpolateLinear1DTests.LinearInterpolate1D(v0, v1, t);

            // point between b and c
            var bc = InterpolateLinear1DTests.LinearInterpolate1D(v1, v2, t);

            // point on the bezier-curve
            return InterpolateLinear1DTests.LinearInterpolate1D(ab, bc, t);
        }
```

