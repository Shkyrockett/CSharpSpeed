# Cubic Catmull-Rom Interpolate Tests

Find a point on a Cubic CatmullRom curve.

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

../../InstrumentedLibrary/Geometry/Interpolation/CatmullRomSplineInterpolation1DTests.cs

The required method signature for this API is as follows:

```CSharp
public static double CatmullRomInterpolate1D(double v1, double v2, double v3, double v4, double t)
```

## Test Case Index

- [Test Case: (0, 0, 1, 1, 0.5)](#0,-0,-1,-1,-0.5)
- [Test Case: (0, 1, 2, 3, 0.5)](#0,-1,-2,-3,-0.5)

### (0, 0, 1, 1, 0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CatmullRom(0, 0, 1, 1, 0.5)](#Catmull-Rom-Interpolate-1D) | 0.5 == 0.5 | 10000 in 26 ms. 0.0026 ms. average |  |
| [CatmullRomSpline(0, 0, 1, 1, 0.5)](#Catmull-Rom-Interpolate-1D) | 0.5 == 0.5 | 10000 in 19 ms. 0.0019 ms. average |  |

### (0, 1, 2, 3, 0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CatmullRom(0, 1, 2, 3, 0.5)](#Catmull-Rom-Interpolate-1D) | 1.5 == 1.5 | 10000 in 13 ms. 0.0013 ms. average |  |
| [CatmullRomSpline(0, 1, 2, 3, 0.5)](#Catmull-Rom-Interpolate-1D) | 1.5 == 1.5 | 10000 in 16 ms. 0.0016 ms. average |  |

## The Code

The code for the methods tested follows below.

### Catmull-Rom Interpolate 1D

Catmull-Rom Interpolation.  
- [http://www.mvps.org/directx/articles/catmull/](http://www.mvps.org/directx/articles/catmull/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CatmullRom(
            double v1,
            double v2,
            double v3,
            double v4,
            double t)
        {
            var tSquared = t * t;
            var tCubed = tSquared * t;
            return
                0.5d * (2d * v2
                + (v3 - v1) * t
                + (2d * v1 - 5d * v2 + 4d * v3 - v4) * tSquared
                + (3d * v2 - v1 - 3.0d * v3 + v4) * tCubed);
        }
```

### Catmull-Rom Interpolate 1D

Catmull-Rom Interpolation.  
- [http://paulbourke.net/miscellaneous/interpolation/](http://paulbourke.net/miscellaneous/interpolation/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CatmullRomSpline(
            double v0,
            double v1,
            double v2,
            double v3,
            double t)
        {
            var mu2 = t * t;
            var a0 = -0.5d * v0 + 1.5d * v1 - 1.5d * v2 + 0.5d * v3;
            var a1 = v0 - 2.5d * v1 + 2d * v2 - 0.5d * v3;
            var a2 = -0.5d * v0 + 0.5d * v2;
            var a3 = v1;
            return a0 * t * mu2 + a1 * mu2 + a2 * t + a3;
        }
```

