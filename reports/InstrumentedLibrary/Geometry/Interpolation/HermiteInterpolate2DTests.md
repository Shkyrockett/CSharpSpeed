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

../../InstrumentedLibrary/Geometry/Interpolation/HermiteInterpolate2DTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double X, double Y) HermiteInterpolate2D(double x0, double y0, double x1, double y1, double x2, double y2, double x3, double y3, double index, double tension, double bias)
```

## Test Case Index

- [Test Case: (0, 1, 2, 3, 4, 5, 6, 7, 0.5, 1, 0)](#0,-1,-2,-3,-4,-5,-6,-7,-0.5,-1,-0)

### (0, 1, 2, 3, 4, 5, 6, 7, 0.5, 1, 0)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [HermiteInterpolate2D_(0, 1, 2, 3, 4, 5, 6, 7, 0.5, 1, 0)](#Hermite-Interpolate-2D) | (3, 4) != 0.5 | 10000 in 22 ms. 0.0022 ms. average |  |
| [Interpolate1(0, 1, 2, 3, 4, 5, 6, 7, 0.5, 1, 0)](#Hermite-Interpolate-2D) | (2.5, 3.625) != 0.5 | 10000 in 25 ms. 0.0025 ms. average |  |
| [Interpolate2(0, 1, 2, 3, 4, 5, 6, 7, 0.5, 1, 0)](#Hermite-Interpolate-2D) | (5.75, 9) != 0.5 | 10000 in 29 ms. 0.0029 ms. average |  |

## The Code

The code for the methods tested follows below.

### Hermite Interpolate 2D

Hermite Interpolation.  
- [http://paulbourke.net/miscellaneous/interpolation/](http://paulbourke.net/miscellaneous/interpolation/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) HermiteInterpolate2D_(
            double x0, double y0,
            double x1, double y1,
            double x2, double y2,
            double x3, double y3,
            double index, double tension, double bias)
        {
            var mu2 = index * index;
            var mu3 = mu2 * index;

            var mX0 = (x1 - x0) * (1d + bias) * (1d - tension) * 0.5d;
            mX0 += (x2 - x1) * (1d - bias) * (1d - tension) * 0.5d;
            var mY0 = (y1 - y0) * (1d + bias) * (1d - tension) * 0.5d;
            mY0 += (y2 - y1) * (1d - bias) * (1d - tension) * 0.5d;
            var mX1 = (x2 - x1) * (1d + bias) * (1d - tension) * 0.5d;
            mX1 += (x3 - x2) * (1d - bias) * (1d - tension) * 0.5d;
            var mY1 = (y2 - y1) * (1d + bias) * (1d - tension) * 0.5d;
            mY1 += (y3 - y2) * (1d - bias) * (1d - tension) * 0.5d;
            var a0 = 2d * mu3 - 3d * mu2 + 1d;
            var a1 = mu3 - 2d * mu2 + index;
            var a2 = mu3 - mu2;
            var a3 = -2d * mu3 + 3d * mu2;

            return (
                a0 * x1 + a1 * mX0 + a2 * mX1 + a3 * x2,
                a0 * y1 + a1 * mY0 + a2 * mY1 + a3 * y2);
        }
```

### Hermite Interpolate 2D

Hermite Interpolation.  
- [http://paulbourke.net/miscellaneous/interpolation/](http://paulbourke.net/miscellaneous/interpolation/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) Interpolate1(
            double x0, double y0,
            double x1, double y1,
            double x2, double y2,
            double x3, double y3,
            double index, double tension, double bias)
        {
            var a = new Point2D(x0, y0);
            var aTan = new Point2D(x1, y1);
            var b = new Point2D(x2, y2);
            var bTan = new Point2D(x3, y3);
            //double mu2 = mu * mu;
            //double mu3 = mu2 * mu;
            //Point2D m0 = (y1 - y0) * (1 + bias) * (1 - tension) * 0.5;
            //m0 += (y2 - y1) * (1 - bias) * (1 - tension) * 0.5;
            //Point2D m1 = (y2 - y1) * (1 + bias) * (1 - tension) * 0.5;
            //m1 += (y3 - y2) * (1 - bias) * (1 - tension) * 0.5;
            //double a0 = 2 * mu3 - 3 * mu2 + 1;
            //double a1 = mu3 - 2 * mu2 + mu;
            //double a2 = mu3 - mu2;
            //double a3 = -2 * mu3 + 3 * mu2;
            //return (a0 * y1 + a1 * m0 + a2 * m1 + a3 * y2);
            var mu2 = index * index;
            var mu3 = mu2 * index;
            var m0 = aTan - (a * (1d + bias * (1d - tension) * 0.5d));
            m0 = m0 + (b - (aTan * (1d - bias) * (1d - tension) * 0.5d));
            var m1 = b - aTan * (1d + bias) * (1d - tension) * 0.5d;
            m1 = m1 + (bTan - b * (1d - bias) * (1d - tension) * 0.5d);
            var a0 = 2d * mu3 - 3d * mu2 + 1d;
            var a1 = mu3 - 2d * mu2 + index;
            var a2 = mu3 - mu2;
            var a3 = -2d * mu3 + 3d * mu2;
            var result = aTan * a0 + (m0 * a1) + (m1 * a2) + (b * a3);
            return (result.I, result.J);
        }
```

### Hermite Interpolate 2D

Hermite Interpolation.  
- [http://paulbourke.net/miscellaneous/interpolation/](http://paulbourke.net/miscellaneous/interpolation/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) Interpolate2(
            double x0, double y0,
            double x1, double y1,
            double x2, double y2,
            double x3, double y3,
            double index, double tension, double bias)
        {
            var a = new Point2D(x0, y0);
            var aTan = new Point2D(x1, y1);
            var b = new Point2D(x2, y2);
            var bTan = new Point2D(x3, y3);
            var t2 = index * index;
            var t3 = t2 * index;
            var tb = (1d + bias) * ((1d - tension) / 2d);
            var ret = aTan * ((2d * t3) - (3d * t2) + 1d) + (aTan - a + ((b - aTan) * (t3 - (2d * t2) + index)) + (b - aTan + ((bTan - b) * (t3 - t2))) * tb + (b * ((3d * t2) - (2d * t3))));
            return (ret.I, ret.J);
        }
```

