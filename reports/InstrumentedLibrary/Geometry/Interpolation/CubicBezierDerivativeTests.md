# Cubic Bezier Derivative Tests

Cubic Bezier Derivative.

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

../../InstrumentedLibrary/Geometry/Interpolation/CubicBezierDerivativeTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double X, double Y) CubicBezierDerivative(double p0X, double p0Y, double p1X, double p1Y, double p2X, double p2Y, double p3X, double p3Y, double t)
```

## Test Case Index

- [Test Case: (0, 0, 1, 1, 2, 1, 3, 0, 0.5)](#0,-0,-1,-1,-2,-1,-3,-0,-0.5)

### (0, 0, 1, 1, 2, 1, 3, 0, 0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CubicBezierDerivative0(0, 0, 1, 1, 2, 1, 3, 0, 0.5)](#Cubic-Bezier-Derivative-Tests) | (3, 0) != True | 10000 in 21 ms. 0.0021 ms. average |  |
| [CubicBezierDerivative1(0, 0, 1, 1, 2, 1, 3, 0, 0.5)](#Cubic-Bezier-Derivative-Tests) | (3, 0) != True | 10000 in 24 ms. 0.0024 ms. average |  |

## The Code

The code for the methods tested follows below.

### Cubic Bezier Derivative Tests

Cubic Bezier Derivative.  
- [http://www.cs.mtu.edu/~shene/COURSES/cs3621/NOTES/spline/Bezier/bezier-der.html](http://www.cs.mtu.edu/~shene/COURSES/cs3621/NOTES/spline/Bezier/bezier-der.html)

```CSharp
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [DebuggerStepThrough]
        public static (double X, double Y) CubicBezierDerivative0(
            double p0X, double p0Y,
            double p1X, double p1Y,
            double p2X, double p2Y,
            double p3X, double p3Y,
            double t)
        {
            return (
                3d * Pow(1d - t, 2d) * (p1X - p0X) + 6d * (1d - t) * t * (p2X - p1X) + 3d * Pow(t, 2d) * (p3X - p2X),
                3d * Pow(1d - t, 2d) * (p1Y - p0Y) + 6d * (1d - t) * t * (p2Y - p1Y) + 3d * Pow(t, 2d) * (p3Y - p2Y)
                );
        }
```

### Cubic Bezier Derivative Tests

Cubic Bezier Derivative.  
- [http://www.cs.mtu.edu/~shene/COURSES/cs3621/NOTES/spline/Bezier/bezier-der.html](http://www.cs.mtu.edu/~shene/COURSES/cs3621/NOTES/spline/Bezier/bezier-der.html)

```CSharp
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [DebuggerStepThrough]
        public static (double X, double Y) CubicBezierDerivative1(
            double p0X, double p0Y,
            double p1X, double p1Y,
            double p2X, double p2Y,
            double p3X, double p3Y,
            double t)
        {
            var mu1 = 1d - t;
            var mu12 = mu1 * mu1;
            var mu2 = t * t;

            return (
                3d * mu12 * (p1X - p0X) + 6d * mu1 * t * (p2X - p1X) + 3d * mu2 * (p3X - p2X),
                3d * mu12 * (p1Y - p0Y) + 6d * mu1 * t * (p2Y - p1Y) + 3d * mu2 * (p3Y - p2Y)
                );
        }
```

