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

../../InstrumentedLibrary/Geometry/Interpolation/CatmullRomSplineInterpolation2DTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double X, double Y) CatmullRomInterpolate2D(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4, double t)
```

## Test Case Index

- [Test Case: (0, 0, 0, 1, 1, 1, 1, 0, 0.5)](#0,-0,-0,-1,-1,-1,-1,-0,-0.5)
- [Test Case: (0, 1, 2, 3, 4, 5, 6, 7, 0.5)](#0,-1,-2,-3,-4,-5,-6,-7,-0.5)

### (0, 0, 0, 1, 1, 1, 1, 0, 0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CatmullRomSpline(0, 0, 0, 1, 1, 1, 1, 0, 0.5)](#Catmull-Rom-Interpolate-2D) | (0.5, 1.125) == (0.5, 1.125) | 10000 in 17 ms. 0.0017 ms. average |  |
| [InterpolateCatmullRom(0, 0, 0, 1, 1, 1, 1, 0, 0.5)](#Catmull-Rom-Interpolate-2D) | (0.5, 1.125) == (0.5, 1.125) | 10000 in 17 ms. 0.0017 ms. average |  |

### (0, 1, 2, 3, 4, 5, 6, 7, 0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CatmullRomSpline(0, 1, 2, 3, 4, 5, 6, 7, 0.5)](#Catmull-Rom-Interpolate-2D) | (3, 4) == (3, 4) | 10000 in 19 ms. 0.0019 ms. average |  |
| [InterpolateCatmullRom(0, 1, 2, 3, 4, 5, 6, 7, 0.5)](#Catmull-Rom-Interpolate-2D) | (3, 4) == (3, 4) | 10000 in 18 ms. 0.0018 ms. average |  |

## The Code

The code for the methods tested follows below.

### Catmull-Rom Interpolate 2D

Catmull-Rom Interpolation.  
- [http://paulbourke.net/miscellaneous/interpolation/](http://paulbourke.net/miscellaneous/interpolation/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) CatmullRomSpline(
            double x0, double y0,
            double x1, double y1,
            double x2, double y2,
            double x3, double y3,
            double t)
        {
            var mu2 = t * t;

            var aX0 = -0.5d * x0 + 1.5d * x1 - 1.5d * x2 + 0.5d * x3;
            var aY0 = -0.5d * y0 + 1.5d * y1 - 1.5d * y2 + 0.5d * y3;
            var aX1 = x0 - 2.5d * x1 + 2d * x2 - 0.5d * x3;
            var aY1 = y0 - 2.5d * y1 + 2d * y2 - 0.5d * y3;
            var aX2 = -0.5d * x0 + 0.5d * x2;
            var aY2 = -0.5d * y0 + 0.5d * y2;

            return (
                aX0 * t * mu2 + aX1 * mu2 + aX2 * t + x1,
                aY0 * t * mu2 + aY1 * mu2 + aY2 * t + y1);
        }
```

### Catmull-Rom Interpolate 2D

Catmull-Rom Interpolation.  
- [http://tehc0dez.blogspot.com/2010/04/nice-curves-catmullrom-spline-in-c.html](http://tehc0dez.blogspot.com/2010/04/nice-curves-catmullrom-spline-in-c.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) InterpolateCatmullRom(
            double t0X, double t0Y,
            double p1X, double p1Y,
            double p2X, double p2Y,
            double t3X, double t3Y,
            double t)
        {
            var tSquared = t * t;
            var tCubed = tSquared * t;
            return (
                0.5d * (2d * p1X
                + (-t0X + p2X) * t
                + (2d * t0X - 5d * p1X + 4d * p2X - t3X) * tSquared
                + (-t0X + 3d * p1X - 3d * p2X + t3X) * tCubed),
                0.5d * (2d * p1Y
                + (-t0Y + p2Y) * t
                + (2d * t0Y - 5d * p1Y + 4d * p2Y - t3Y) * tSquared
                + (-t0Y + 3d * p1Y - 3d * p2Y + t3Y) * tCubed));
        }
```

