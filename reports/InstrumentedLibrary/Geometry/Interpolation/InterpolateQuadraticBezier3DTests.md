# Quadratic Bezier Interpolate 3D Tests

Find a point on a 3D Quadratic Bezier curve.

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

../../InstrumentedLibrary/Geometry/Interpolation/InterpolateQuadraticBezier3DTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double X, double Y, double Z) QuadraticBezierInterpolate3D(double x0, double y0, double z0, double x1, double y1, double z1, double x2, double y2, double z2, double t)
```

## Test Case Index

- [Test Case: (0, 1, 2, 3, 4, 5, 6, 7, 8, 0.5)](#0,-1,-2,-3,-4,-5,-6,-7,-8,-0.5)

### (0, 1, 2, 3, 4, 5, 6, 7, 8, 0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [QuadraticBezierInterpolate3D_0(0, 1, 2, 3, 4, 5, 6, 7, 8, 0.5)](#Quadratic-Bezier-Interpolate-1) | (3, 4, 5) == (3, 4, 5) | 10000 in 26 ms. 0.0026 ms. average |  |
| [QuadraticBezierInterpolate3D_1(0, 1, 2, 3, 4, 5, 6, 7, 8, 0.5)](#Quadratic-Bezier-Interpolate-2) | (3, 4, 5) == (3, 4, 5) | 10000 in 18 ms. 0.0018 ms. average |  |

## The Code

The code for the methods tested follows below.

### Quadratic Bezier Interpolate 1

Simple Quadratic Bezier Interpolation.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) QuadraticBezierInterpolate3D_0(
            double x0, double y0, double z0,
            double x1, double y1, double z1,
            double x2, double y2, double z2,
            double t)
        {
            var mu1 = 1 - t;
            var mu12 = mu1 * mu1;
            var mu2 = t * t;

            return (
                (x0 * mu12) + (2 * x1 * mu1 * t) + (x2 * mu2),
                (y0 * mu12) + (2 * y1 * mu1 * t) + (y2 * mu2),
                (z0 * mu12) + (2 * z1 * mu1 * t) + (z2 * mu2));
        }
```

### Quadratic Bezier Interpolate 2

Simple Quadratic Bezier Interpolation.  
- [http://www.cubic.org/docs/bezier.htm](http://www.cubic.org/docs/bezier.htm)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) QuadraticBezierInterpolate3D_1(
            double x0, double y0, double z0,
            double x1, double y1, double z1,
            double x2, double y2, double z2,
            double t)
        {
            // point between a and b
            var ab = InterpolateLinear3DTests.LinearInterpolate3D(x0, y0, z0, x1, y1, z1, t);

            // point between b and c
            var bc = InterpolateLinear3DTests.LinearInterpolate3D(x1, y1, z1, x2, y2, z2, t);

            // point on the bezier-curve
            return InterpolateLinear3DTests.LinearInterpolate3D(ab.X, ab.Y, ab.Z, bc.X, bc.Y, bc.Z, t);
        }
```

