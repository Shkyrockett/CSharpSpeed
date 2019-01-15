# Catmull-Rom Interpolate Tests

Find a point on a CatmullRom curve.

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

../../InstrumentedLibrary/Geometry/Interpolation/CatmullRomSplineInterpolation3DTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double X, double Y, double Z) CatmullRomInterpolate3D(double x1, double y1, double z1, double x2, double y2, double z2, double x3, double y3, double z3, double x4, double y4, double z4, double t)
```

## Test Case Index

- [Test Case: (0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0.5)](#0,-0,-0,-0,-0,-1,-1,-1,-1,-1,-0,-0,-0.5)
- [Test Case: (0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 0.5)](#0,-1,-2,-3,-4,-5,-6,-7,-8,-9,-10,-11,-0.5)

### (0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CatmullRom(0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0.5)](#Catmull-Rom-Interpolate-2D) | (0.5, 0.5625, 1.125) == (0.5, 0.5625, 1.125) | 10000 in 38 ms. 0.0038 ms. average |  |
| [CatmullRomSpline(0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0.5)](#Catmull-Rom-Interpolate-3D) | (0.5, 0.5625, 1.125) == (0.5, 0.5625, 1.125) | 10000 in 32 ms. 0.0032 ms. average |  |

### (0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CatmullRom(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 0.5)](#Catmull-Rom-Interpolate-2D) | (4.5, 4.5, 6.5) == (4.5, 4.5, 6.5) | 10000 in 33 ms. 0.0033 ms. average |  |
| [CatmullRomSpline(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 0.5)](#Catmull-Rom-Interpolate-3D) | (4.5, 5.5, 6.5) != (4.5, 4.5, 6.5) | 10000 in 23 ms. 0.0023 ms. average |  |

## The Code

The code for the methods tested follows below.

### Catmull-Rom Interpolate 2D

Catmull-Rom Interpolation.  
- [http://www.mvps.org/directx/articles/catmull/](http://www.mvps.org/directx/articles/catmull/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) CatmullRom(
            double x1, double y1, double z1,
            double x2, double y2, double z2,
            double x3, double y3, double z3,
            double x4, double y4, double z4,
            double t)
        {
            var tSquared = t * t;
            var tCubed = tSquared * t;
            return (
                0.5d * (2d * x2
                + (x3 - x1) * t
                + (2d * x1 - 5d * x2 + 4d * x3 - x4) * tSquared
                + (3d * x2 - x1 - 3d * x3 + x4) * tCubed),
                0.5d * (2d * x2
                + (y3 - y1) * t
                + (2d * y1 - 5d * y2 + 4d * y3 - y4) * tSquared
                + (3d * y2 - y1 - 3d * y3 + y4) * tCubed),
                0.5d * (2d * z2
                + (z3 - z1) * t
                + (2d * z1 - 5d * z2 + 4d * z3 - z4) * tSquared
                + (3d * z2 - z1 - 3d * z3 + z4) * tCubed));
        }
```

### Catmull-Rom Interpolate 3D

Catmull-Rom Interpolation.  
- [http://paulbourke.net/miscellaneous/interpolation/](http://paulbourke.net/miscellaneous/interpolation/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) CatmullRomSpline(
            double x0, double y0, double z0,
            double x1, double y1, double z1,
            double x2, double y2, double z2,
            double x3, double y3, double z3,
            double t)
        {
            var mu2 = t * t;

            var aX0 = -0.5d * x0 + 1.5d * x1 - 1.5d * x2 + 0.5d * x3;
            var aY0 = -0.5d * y0 + 1.5d * y1 - 1.5d * y2 + 0.5d * y3;
            var aZ0 = -0.5d * z0 + 1.5d * z1 - 1.5d * z2 + 0.5d * z3;
            var aX1 = x0 - 2.5d * x1 + 2d * x2 - 0.5d * x3;
            var aY1 = y0 - 2.5d * y1 + 2d * y2 - 0.5d * y3;
            var aZ1 = z0 - 2.5d * z1 + 2d * z2 - 0.5d * z3;
            var aX2 = -0.5d * x0 + 0.5d * x2;
            var aY2 = -0.5d * y0 + 0.5d * y2;
            var aZ2 = -0.5d * z0 + 0.5d * z2;

            return (
                aX0 * t * mu2 + aX1 * mu2 + aX2 * t + x1,
                aY0 * t * mu2 + aY1 * mu2 + aY2 * t + y1,
                aZ0 * t * mu2 + aZ1 * mu2 + aZ2 * t + z1);
        }
```

