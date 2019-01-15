# Cubic Bezier Interpolate 2D Tests

Find a point on a 2D Cubic Bezier curve.

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

../../InstrumentedLibrary/Geometry/Interpolation/InterpolateCubicBezier2DTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double X, double Y) CubicBezierInterpolate2D(double x0, double y0, double x1, double y1, double x2, double y2, double x3, double y3, double t)
```

## Test Case Index

- [Test Case: (0, 1, 2, 3, 4, 5, 6, 7, 0.5)](#0,-1,-2,-3,-4,-5,-6,-7,-0.5)

### (0, 1, 2, 3, 4, 5, 6, 7, 0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CubicBezierCurve(0, 1, 2, 3, 4, 5, 6, 7, 0.5)](#Cubic-Bezier-Interpolate-9) | (3, 4) == (3, 4) | 10000 in 33 ms. 0.0033 ms. average |  |
| [CubicBezierInterpolate2D_0(0, 1, 2, 3, 4, 5, 6, 7, 0.5)](#Cubic-Bezier-Interpolate-1) | (3, 4) == (3, 4) | 10000 in 25 ms. 0.0025 ms. average |  |
| [CubicBezierInterpolate2D_1(0, 1, 2, 3, 4, 5, 6, 7, 0.5)](#Cubic-Bezier-Interpolate-2) | (3, 4) == (3, 4) | 10000 in 20 ms. 0.002 ms. average |  |
| [CubicBezierInterpolate2D_2(0, 1, 2, 3, 4, 5, 6, 7, 0.5)](#Cubic-Bezier-Interpolate-3) | (3, 4) == (3, 4) | 10000 in 22 ms. 0.0022 ms. average |  |
| [CubicBezierInterpolate2D_3(0, 1, 2, 3, 4, 5, 6, 7, 0.5)](#Cubic-Bezier-Interpolate-4) | (3, 4) == (3, 4) | 10000 in 16 ms. 0.0016 ms. average |  |
| [CubicBezierInterpolate2D_4(0, 1, 2, 3, 4, 5, 6, 7, 0.5)](#Cubic-Bezier-Interpolate-5) | (3, 4) == (3, 4) | 10000 in 23 ms. 0.0023 ms. average |  |
| [CubicBezierInterpolate2D_5(0, 1, 2, 3, 4, 5, 6, 7, 0.5)](#Cubic-Bezier-Interpolate-6) | (4.5, 5.5) != (3, 4) | 10000 in 13 ms. 0.0013 ms. average |  |
| [CubicBezierInterpolate2D_6(0, 1, 2, 3, 4, 5, 6, 7, 0.5)](#Cubic-Bezier-Interpolate-7) | (2.25, 3.125) != (3, 4) | 10000 in 17 ms. 0.0017 ms. average |  |
| [InterpolateCubic(0, 1, 2, 3, 4, 5, 6, 7, 0.5)](#Cubic-Bezier-Interpolate-8) | (3, 4) == (3, 4) | 10000 in 20 ms. 0.002 ms. average |  |

## The Code

The code for the methods tested follows below.

### Cubic Bezier Interpolate 9

Simple Cubic Bezier Interpolation.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) CubicBezierCurve(double p0X, double p0Y, double p1X, double p1Y, double p2X, double p2Y, double p3X, double p3Y, double t)
        {
            return (
                (float)((Pow(1 - t, 3) * p0X) + (3 * Pow(1 - t, 2) * t * p1X) + (3 * (1 - t) * Pow(t, 2) * p2X) + (Pow(t, 3) * p3X)),
                (float)((Pow(1 - t, 3) * p0Y) + (3 * Pow(1 - t, 2) * t * p1Y) + (3 * (1 - t) * Pow(t, 2) * p2Y) + (Pow(t, 3) * p3Y)));
        }
```

### Cubic Bezier Interpolate 1

Simple Cubic Bezier Interpolation.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) CubicBezierInterpolate2D_0(
            double x0, double y0,
            double x1, double y1,
            double x2, double y2,
            double x3, double y3,
            double t)
        {
            var mum1 = 1 - t;
            var mum13 = mum1 * mum1 * mum1;
            var mu3 = t * t * t;

            return (
                (mum13 * x0) + (3 * t * mum1 * mum1 * x1) + (3 * t * t * mum1 * x2) + (mu3 * x3),
                (mum13 * y0) + (3 * t * mum1 * mum1 * y1) + (3 * t * t * mum1 * y2) + (mu3 * y3)
                );
        }
```

### Cubic Bezier Interpolate 2

Simple Cubic Bezier Interpolation.  
- [http://www.lemoda.net/maths/bezier-length/index.html](http://www.lemoda.net/maths/bezier-length/index.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) CubicBezierInterpolate2D_1(
        double aX, double aY,
        double bX, double bY,
        double cX, double cY,
        double dX, double dY,
        double t)
        {
            // Formula from Wikipedia article on Bézier curves.
            return (
                (aX * (1.0 - t) * (1.0 - t) * (1.0 - t)) + (3.0 * bX * (1.0 - t) * (1.0 - t) * t) + (3.0 * cX * (1.0 - t) * t * t) + (dX * t * t * t),
                (aY * (1.0 - t) * (1.0 - t) * (1.0 - t)) + (3.0 * bY * (1.0 - t) * (1.0 - t) * t) + (3.0 * cY * (1.0 - t) * t * t) + (dY * t * t * t));
        }
```

### Cubic Bezier Interpolate 3

Simple Cubic Bezier Interpolation.  
- [http://www.cubic.org/docs/bezier.htm](http://www.cubic.org/docs/bezier.htm)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) CubicBezierInterpolate2D_2(
            double x0, double y0,
            double x1, double y1,
            double x2, double y2,
            double x3, double y3,
            double t)
        {
            // point between a and b
            (var abX, var abY) = InterpolateLinear2DTests.LinearInterpolate2D(x0, y0, x1, y1, t);
            // point between b and c
            (var bcX, var bcY) = InterpolateLinear2DTests.LinearInterpolate2D(x1, y1, x2, y2, t);
            // point between c and d
            (var cdX, var cdY) = InterpolateLinear2DTests.LinearInterpolate2D(x2, y2, x3, y3, t);
            // point between ab and bc
            (var abbcX, var abbcY) = InterpolateLinear2DTests.LinearInterpolate2D(abX, abY, bcX, bcY, t);
            // point between bc and cd
            (var bccdX, var bccdY) = InterpolateLinear2DTests.LinearInterpolate2D(bcX, bcY, cdX, cdY, t);
            // point on the bezier-curve
            return InterpolateLinear2DTests.LinearInterpolate2D(abbcX, abbcY, bccdX, bccdY, t);
        }
```

### Cubic Bezier Interpolate 4

Simple Cubic Bezier Interpolation.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) CubicBezierInterpolate2D_3(
            double aX, double aY,
            double bX, double bY,
            double cX, double cY,
            double dX, double dY,
            double t)
        {
            var V1 = t;
            var V2 = 1 - t;
            return (
                (aX * V2 * V2 * V2) + (3 * bX * V1 * V2 * V2) + (3 * cX * V1 * V1 * V2) + (dX * V2 * V2 * V2),
                (aY * V2 * V2 * V2) + (3 * bY * V1 * V2 * V2) + (3 * cY * V1 * V1 * V2) + (dY * V2 * V2 * V2));
        }
```

### Cubic Bezier Interpolate 5

Simple Cubic Bezier Interpolation.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) CubicBezierInterpolate2D_4(
            double aX, double aY,
            double bX, double bY,
            double cX, double cY,
            double dX, double dY,
            double t)
        {
            //(double X, double Y) P = (v3 - v2) - (v0 - v1);
            //(double X, double Y) Q = (v0 - v1) - P;
            //(double X, double Y) R = v2 - v0;
            //(double X, double Y) S = v1;
            //(double X, double Y) P * Pow(x, 3) + Q * Pow(x, 2) + R * x + S;
            var PX = dX - cX - (aX - bX);
            var PY = dY - cY - (aY - bY);
            var QX = aX - bX - PX;
            var QY = aY - bY - PY;
            var RX = cX - aX;
            var RY = cY - aY;
            var SX = bX;
            var SY = bY;
            return (
                (PX * (t * t * t)) + (QX * (t * t)) + (RX * t) + SX,
                (PY * (t * t * t)) + (QY * (t * t)) + (RY * t) + SY);
        }
```

### Cubic Bezier Interpolate 6

Simple Cubic Bezier Interpolation.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) CubicBezierInterpolate2D_5(
            double aX, double aY,
            double bX, double bY,
            double cX, double cY,
            double dX, double dY,
            double t)
        {
            //  Warning - untested code

            // calculate the curve point at parameter value t
            var tSquared = t * t;
            var tCubed = tSquared * t;

            // calculate the polynomial coefficients
            var cC = (3 * (bX - aX), 3 * (bY - aY));
            var cB = ((3 * (cX - bX)) - cC.Item1, (3 * (cY - bY)) - cC.Item2);
            var cA = (dX - (aX - (cC.Item1 - cB.Item1)), dY - (aY - (cC.Item2 - cB.Item2)));
            return ((cA.Item1 * tCubed) + ((cB.Item1 * tSquared) + ((cC.Item1 * t) + aX)), (cA.Item2 * tCubed) + ((cB.Item2 * tSquared) + ((cC.Item2 * t) + aY)));
        }
```

### Cubic Bezier Interpolate 7

Simple Cubic Bezier Interpolation.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) CubicBezierInterpolate2D_6(
            double aX, double aY,
            double bX, double bY,
            double cX, double cY,
            double dX, double dY,
            double t)
        {
            var c1 = (dX - cX - (aX - bX), dY - cY - (aY - bY));
            var c2 = (aX - bX - aX, aY - bY - aY);
            var c3 = (cX - aX, cY - aY);
            var c4 = (aX, aY);
            return (
                (c1.Item1 * t * t * t) + (c2.Item1 * t * t * t) + (c3.Item1 * t) + c4.aX,
                (c1.Item2 * t * t * t) + (c2.Item2 * t * t * t) + (c3.Item2 * t) + c4.aY);
        }
```

### Cubic Bezier Interpolate 8

Simple Cubic Bezier Interpolation.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) InterpolateCubic(double x0, double y0, double x1, double y1, double x2, double y2, double x3, double y3, double t)
        {
            var x = (-(t * t * t) * (x0 - (3 * x1) + (3 * x2) - x3))
                + (3 * t * t * (x0 - (2 * x1) + x2)) + (3 * t * (x1 - x0)) + x0;
            var y = (-(t * t * t) * (y0 - (3 * y1) + (3 * y2) - y3))
                + (3 * t * t * (y0 - (2 * y1) + y2)) + (3 * t * (y1 - y0)) + y0;
            return (x, y);
        }
```

