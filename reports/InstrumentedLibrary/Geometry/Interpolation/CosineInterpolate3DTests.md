# Cosine Interpolate Tests

Find a point on a Cosine curve.

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

../../InstrumentedLibrary/Geometry/Interpolation/CosineInterpolate3DTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double X, double Y, double Z) CosineInterpolate3D(double x1, double y1, double z1, double x2, double y2, double z2, double t)
```

## Test Case Index

- [Test Case: (0, 0, 0, 1, 1, 1, 0.5)](#0,-0,-0,-1,-1,-1,-0.5)

### (0, 0, 0, 1, 1, 1, 0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CosineInterpolate3D_(0, 0, 0, 1, 1, 1, 0.5)](#Cosine-Interpolate-3D) | (0.49999999999999994, 0.49999999999999994, 0.49999999999999994) == (0.49999999999999994, 0.49999999999999994, 0.49999999999999994) | 10000 in 21 ms. 0.0021 ms. average |  |

## The Code

The code for the methods tested follows below.

### Cosine Interpolate 3D

Cosine Interpolation.  
- [http://paulbourke.net/miscellaneous/interpolation/](http://paulbourke.net/miscellaneous/interpolation/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) CosineInterpolate3D_(
            double x1, double y1, double z1,
            double x2, double y2, double z2,
            double t)
        {
            var mu2 = (1d - Cos(t * PI)) / 2d;
            return (
                x1 * (1d - mu2) + x2 * mu2,
                y1 * (1d - mu2) + y2 * mu2,
                z1 * (1d - mu2) + z2 * mu2);
        }
```

