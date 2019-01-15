# Cubic Interpolate 3D Tests

Find a point on a 3D cubic curve.

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

../../InstrumentedLibrary/Geometry/Interpolation/InterpolateCubic3DTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double X, double Y, double Z) CubicInterpolate3D(double x0, double y0, double z0, double x1, double y1, double z1, double x2, double y2, double z2, double x3, double y3, double z3, double t)
```

## Test Case Index

- [Test Case: (0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 0.5)](#0,-1,-2,-3,-4,-5,-6,-7,-8,-9,-10,-11,-0.5)

### (0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CubicInterpolate3D_(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 0.5)](#Cubic-Interpolate-1) | (4.5, 5.5, 6.5) == (4.5, 5.5, 6.5) | 10000 in 22 ms. 0.0022 ms. average |  |

## The Code

The code for the methods tested follows below.

### Cubic Interpolate 1

Simple Cubic Interpolation.  
- [http://paulbourke.net/miscellaneous/interpolation/](http://paulbourke.net/miscellaneous/interpolation/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) CubicInterpolate3D_(
            double x0, double y0, double z0,
            double x1, double y1, double z1,
            double x2, double y2, double z2,
            double x3, double y3, double z3,
            double t)
        {
            var mu2 = t * t;

            var aX0 = x3 - x2 - x0 + x1;
            var aY0 = y3 - y2 - y0 + y1;
            var aZ0 = z3 - z2 - z0 + z1;
            var aX1 = x0 - x1 - aX0;
            var aY1 = y0 - y1 - aY0;
            var aZ1 = z0 - z1 - aZ0;
            var aX2 = x2 - x0;
            var aY2 = y2 - y0;
            var aZ2 = z2 - z0;

            return (
                (aX0 * t * mu2) + (aX1 * mu2) + (aX2 * t) + x1,
                (aY0 * t * mu2) + (aY1 * mu2) + (aY2 * t) + y1,
                (aZ0 * t * mu2) + (aZ1 * mu2) + (aZ2 * t) + z1);
        }
```

