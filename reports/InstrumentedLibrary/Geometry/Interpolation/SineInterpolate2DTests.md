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

../../InstrumentedLibrary/Geometry/Interpolation/SineInterpolate2DTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double X, double Y) Sine(double x1, double y1, double x2, double y2, double t)
```

## Test Case Index

- [Test Case: (0, 0, 1, 1, 0.5)](#0,-0,-1,-1,-0.5)

### (0, 0, 1, 1, 0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [InterpolateSine(0, 0, 1, 1, 0.5)](#Sine-Interpolate-2D) | (0.053001668199721075, 0.053001668199721075) != (0.49999999999999994, 0.49999999999999994) | 10000 in 12 ms. 0.0012 ms. average |  |
| [Sine_(0, 0, 1, 1, 0.5)](#Sine-Interpolate-2D) | (0, 0) != (0.49999999999999994, 0.49999999999999994) | 10000 in 10 ms. 0.001 ms. average |  |

## The Code

The code for the methods tested follows below.

### Sine Interpolate 2D

Sine Interpolation.  
- [http://paulbourke.net/miscellaneous/interpolation/](http://paulbourke.net/miscellaneous/interpolation/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) InterpolateSine(
            double x1, double y1,
            double x2, double y2,
            double index)
        {
            var a = new Point2D(x1, y1);
            var b = new Point2D(x2, y2);
            //Single MU2 = (double)((1.0 - Cos(index * 180)) * 0.5);
            //return Y1 * (1.0 - MU2) + Y2 * MU2;
            var MU2 = (1d - Sin(index * 180d)) * 0.5d;
            var ret = a * (1d - MU2) + (b * MU2);
            return (ret.I, ret.J);
        }
```

### Sine Interpolate 2D

Sine Interpolation.  
- [http://paulbourke.net/miscellaneous/interpolation/](http://paulbourke.net/miscellaneous/interpolation/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) Sine_(
            double x1, double y1,
            double x2, double y2,
            double t)
        {
            var mu2 = (1d - Sin(t * PI)) / 2d;
            return (x1 * (1d - mu2) + x2 * mu2, y1 * (1d - mu2) + y2 * mu2);
        }
```

