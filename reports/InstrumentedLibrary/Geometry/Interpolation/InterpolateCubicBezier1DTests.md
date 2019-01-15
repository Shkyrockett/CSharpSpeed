# Cubic Bezier Interpolate 1D Tests

Find a point on a 1D Cubic Bezier curve.

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

../../InstrumentedLibrary/Geometry/Interpolation/InterpolateCubicBezier1DTests.cs

The required method signature for this API is as follows:

```CSharp
public static double CubicBezier(double v0, double v1, double v2, double v3, double t)
```

## Test Case Index

- [Test Case: (0, 3, 6, 7, 0.5)](#0,-3,-6,-7,-0.5)

### (0, 3, 6, 7, 0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CubicBezier_(0, 3, 6, 7, 0.5)](#Cubic-Bezier-Interpolate-1) | 4.25 == 4.25 | 10000 in 16 ms. 0.0016 ms. average |  |

## The Code

The code for the methods tested follows below.

### Cubic Bezier Interpolate 1

Simple Cubic Bezier Interpolation.  
- [http://paulbourke.net/geometry/bezier/index.html](http://paulbourke.net/geometry/bezier/index.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CubicBezier_(
            double v0,
            double v1,
            double v2,
            double v3,
            double t)
        {
            // The inverse of t.
            var ti = 1d - t;

            // The inverse of t cubed.
            var ti3 = ti * ti * ti;

            // The t cubed.
            var t3 = t * t * t;

            return (ti3 * v0) + (3d * t * ti * ti * v1) + (3d * t * t * ti * v2) + (t3 * v3);
        }
```

