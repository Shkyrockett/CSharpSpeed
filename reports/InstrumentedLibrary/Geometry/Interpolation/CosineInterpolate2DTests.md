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

../../InstrumentedLibrary/Geometry/Interpolation/CosineInterpolate2DTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double X, double Y) CosineInterpolate2D(double x1, double y1, double x2, double y2, double t)
```

## Test Case Index

- [Test Case: (0, 0, 1, 1, 0.5)](#0,-0,-1,-1,-0.5)

### (0, 0, 1, 1, 0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CosineInterpolate(0, 0, 1, 1, 0.5)](#Cosine-Interpolate-2D) | (0.49999999999999994, 0.49999999999999994) == (0.49999999999999994, 0.49999999999999994) | 10000 in 15 ms. 0.0015 ms. average |  |
| [CosineInterpolate2D_(0, 0, 1, 1, 0.5)](#Cosine-Interpolate-2D) | (0.49999999999999994, 0.49999999999999994) == (0.49999999999999994, 0.49999999999999994) | 10000 in 15 ms. 0.0015 ms. average |  |
| [Interpolate(0, 0, 1, 1, 0.5)](#Cosine-Interpolate-2D) | (0.49999999999999994, 0.49999999999999994) == (0.49999999999999994, 0.49999999999999994) | 10000 in 20 ms. 0.002 ms. average |  |

## The Code

The code for the methods tested follows below.

### Cosine Interpolate 2D

Cosine Interpolation.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) CosineInterpolate(
            double x1, double y1,
            double x2, double y2,
            double index)
        {
            //var mu = (1d - Cos(index * 180d)) * 0.5d;
            var mu = (1d - Cos(index * PI)) * 0.5d;
            return new Point2D(
                (x1 * (1d - mu)) + (x2 * mu),
                (y1 * (1d - mu)) + (y2 * mu)
                );
        }
```

### Cosine Interpolate 2D

Cosine Interpolation.  
- [http://paulbourke.net/miscellaneous/interpolation/](http://paulbourke.net/miscellaneous/interpolation/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) CosineInterpolate2D_(
            double x1, double y1,
            double x2, double y2,
            double t)
        {
            var mu2 = (1d - Cos(t * PI)) * 0.5d;
            return (
                (x1 * (1d - mu2)) + x2 * mu2,
                (y1 * (1d - mu2)) + y2 * mu2);
        }
```

### Cosine Interpolate 2D

Cosine Interpolation.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) Interpolate(
            double x1, double y1,
            double x2, double y2,
            double index)
        {
            var a = new Point2D(x1, y1);
            var b = new Point2D(x2, y2);
            //var mu = (1d - Cos(index * 180d)) * 0.5d;
            //return Y1 * (1d - mu) + Y2 * mu;
            var mu = (1d - Cos(index * PI)) * 0.5d;
            var ret = (a * (1d - mu)) + (b * mu);
            return (ret.I, ret.J);
        }
```

