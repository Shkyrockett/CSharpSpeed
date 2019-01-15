# Cubic Interpolate 2D Tests

Find a point on a 2D Cubic curve.

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

../../InstrumentedLibrary/Geometry/Interpolation/InterpolateCubic2DTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double X, double Y) CubicInterpolate2D(double x0, double y0, double x1, double y1, double x2, double y2, double x3, double y3, double t)
```

## Test Case Index

- [Test Case: (0, 1, 2, 3, 4, 5, 6, 7, 0.5)](#0,-1,-2,-3,-4,-5,-6,-7,-0.5)

### (0, 1, 2, 3, 4, 5, 6, 7, 0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CubicInterpolate2D_(0, 1, 2, 3, 4, 5, 6, 7, 0.5)](#Cubic-Interpolate-1) | (3, 4) == (3, 4) | 10000 in 17 ms. 0.0017 ms. average |  |

## The Code

The code for the methods tested follows below.

### Cubic Interpolate 1

Simple Cubic Interpolation.  
- [http://paulbourke.net/miscellaneous/interpolation/](http://paulbourke.net/miscellaneous/interpolation/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) CubicInterpolate2D_(
            double x0, double y0,
            double x1, double y1,
            double x2, double y2,
            double x3, double y3,
            double t)
        {
            var mu2 = t * t;

            var aX0 = x3 - x2 - x0 + x1;
            var aY0 = y3 - y2 - y0 + y1;
            var aX1 = x0 - x1 - aX0;
            var aY1 = y0 - y1 - aY0;
            var aX2 = x2 - x0;
            var aY2 = y2 - y0;

            return (
                (aX0 * t * mu2) + (aX1 * mu2) + (aX2 * t) + x1,
                (aY0 * t * mu2) + (aY1 * mu2) + (aY2 * t) + y1);
        }
```

