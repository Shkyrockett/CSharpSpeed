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

../../InstrumentedLibrary/Geometry/Interpolation/HermiteInterpolate1DTests.cs

The required method signature for this API is as follows:

```CSharp
public static double HermiteInterpolate1D(double v0, double v1, double v2, double v3, double s, double tension, double bias)
```

## Test Case Index

- [Test Case: (0, 1, 2, 3, 0.5, 1, 0)](#0,-1,-2,-3,-0.5,-1,-0)

### (0, 1, 2, 3, 0.5, 1, 0)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Hermite(0, 1, 2, 3, 0.5, 1, 0)](#Hermite-Interpolate-1D) | 0.75 != 0.5 | 10000 in 18 ms. 0.0018 ms. average |  |
| [HermiteInterpolate1D_(0, 1, 2, 3, 0.5, 1, 0)](#Hermite-Interpolate-1D) | 1.5 != 0.5 | 10000 in 22 ms. 0.0022 ms. average |  |

## The Code

The code for the methods tested follows below.

### Hermite Interpolate 1D

Hermite Interpolation.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Hermite(
            double v1,
            double t1,
            double v2,
            double t2,
            double s, double tension, double bias)
        {
            double result;
            var sSquared = s * s;
            var sCubed = sSquared * s;

            if (s == 0d)
            {
                result = v1;
            }
            else
            {
                result = s == 1d ? v2 : (2d * v1 - 2d * v2 + t2 + t1) * sCubed
                   + (3d * v2 - 3d * v1 - 2d * t1 - t2) * sSquared
                   + t1 * s
                   + v1;
            }

            return result;
        }
```

### Hermite Interpolate 1D

Hermite Interpolation.  
- [http://paulbourke.net/miscellaneous/interpolation/](http://paulbourke.net/miscellaneous/interpolation/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double HermiteInterpolate1D_(
            double v0,
            double v1,
            double v2,
            double v3,
            double s, double tension, double bias)
        {
            var sSquared = s * s;
            var sCubed = sSquared * s;
            var m0 = (v1 - v0) * (1d + bias) * (1d - tension) / 2d;
            m0 += (v2 - v1) * (1d - bias) * (1d - tension) / 2d;
            var m1 = (v2 - v1) * (1d + bias) * (1d - tension) / 2d;
            m1 += (v3 - v2) * (1d - bias) * (1d - tension) / 2d;
            var a0 = 2d * sCubed - 3d * sSquared + 1d;
            var a1 = sCubed - 2d * sSquared + s;
            var a2 = sCubed - sSquared;
            var a3 = -2d * sCubed + 3d * sSquared;

            return a0 * v1 + a1 * m0 + a2 * m1 + a3 * v2;
        }
```

