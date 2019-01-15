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

../../InstrumentedLibrary/Geometry/Interpolation/CosineInterpolate1DTests.cs

The required method signature for this API is as follows:

```CSharp
public static double CosineInterpolate1D(double v1, double v2, double t)
```

## Test Case Index

- [Test Case: (0, 1, 0.5)](#0,-1,-0.5)

### (0, 1, 0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CosineInterpolate1D_(0, 1, 0.5)](#Cosine-Interpolate-1D) | 0.49999999999999994 == 0.49999999999999994 | 10000 in 13 ms. 0.0013 ms. average |  |

## The Code

The code for the methods tested follows below.

### Cosine Interpolate 1D

Cosine Interpolation.  
- [http://paulbourke.net/miscellaneous/interpolation/](http://paulbourke.net/miscellaneous/interpolation/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CosineInterpolate1D_(double v1, double v2, double t)
        {
            var mu2 = (1d - Cos(t * PI)) / 2d;
            return v1 * (1d - mu2) + v2 * mu2;
        }
```
