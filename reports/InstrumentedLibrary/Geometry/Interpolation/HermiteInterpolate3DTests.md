# Cubic Hermite Interpolate Tests

Find a point on a Hermite curve.

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

../../InstrumentedLibrary/Geometry/Interpolation/HermiteInterpolate3DTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double X, double Y, double Z) HermiteInterpolate3D(double x0, double y0, double z0, double x1, double y1, double z1, double x2, double y2, double z2, double x3, double y3, double z3, double mu, double tension, double bias)
```

## Test Case Index

- [Test Case: (0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 0.5, 1, 0)](#0,-1,-2,-3,-4,-5,-6,-7,-8,-9,-10,-11,-0.5,-1,-0)

### (0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 0.5, 1, 0)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [HermiteInterpolate3D_(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 0.5, 1, 0)](#Hermite-Interpolate-3D) | (4.5, 5.5, 6.5) != 0.5 | 10000 in 31 ms. 0.0031 ms. average |  |

## The Code

The code for the methods tested follows below.

### Hermite Interpolate 3D

Hermite Interpolation.  
- [http://paulbourke.net/miscellaneous/interpolation/](http://paulbourke.net/miscellaneous/interpolation/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) HermiteInterpolate3D_(
            double x0, double y0, double z0,
            double x1, double y1, double z1,
            double x2, double y2, double z2,
            double x3, double y3, double z3,
            double mu, double tension, double bias)
        {
            var mu2 = mu * mu;
            var mu3 = mu2 * mu;

            var mX0 = (x1 - x0) * (1d + bias) * (1d - tension) / 2d;
            mX0 += (x2 - x1) * (1d - bias) * (1d - tension) / 2d;
            var mY0 = (y1 - y0) * (1d + bias) * (1d - tension) / 2d;
            mY0 += (y2 - y1) * (1d - bias) * (1d - tension) / 2d;
            var mZ0 = (z1 - z0) * (1d + bias) * (1d - tension) / 2d;
            mZ0 += (z2 - z1) * (1d - bias) * (1d - tension) / 2d;
            var mX1 = (x2 - x1) * (1d + bias) * (1d - tension) / 2d;
            mX1 += (x3 - x2) * (1d - bias) * (1d - tension) / 2d;
            var mY1 = (y2 - y1) * (1d + bias) * (1d - tension) / 2d;
            mY1 += (y3 - y2) * (1d - bias) * (1d - tension) / 2d;
            var mZ1 = (z2 - z1) * (1d + bias) * (1d - tension) / 2d;
            mZ1 += (z3 - z2) * (1d - bias) * (1d - tension) / 2d;
            var a0 = 2d * mu3 - 3d * mu2 + 1d;
            var a1 = mu3 - 2 * mu2 + mu;
            var a2 = mu3 - mu2;
            var a3 = -2d * mu3 + 3d * mu2;

            return (
                a0 * x1 + a1 * mX0 + a2 * mX1 + a3 * x2,
                a0 * y1 + a1 * mY0 + a2 * mY1 + a3 * y2,
                a0 * z1 + a1 * mZ0 + a2 * mZ1 + a3 * z2);
        }
```

