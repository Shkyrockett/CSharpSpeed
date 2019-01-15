# Cubic Bezier Curve Segment Length Tests

Estimations on the length of the Perimeter of an ellipse.

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

../../InstrumentedLibrary/Geometry/Length/QuadraticBezierSegmentLengthTests.cs

The required method signature for this API is as follows:

```CSharp
public static double QuadraticBezierArcLength(double ax, double ay, double bx, double by, double cx, double cy)
```

## Test Case Index

- [Test Case: (0, 5, 10, 15, 30, 5)](#0,-5,-10,-15,-30,-5)

### (0, 5, 10, 15, 30, 5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [QuadraticBezierApproxArcLength(0, 5, 10, 15, 30, 5)](#The-Quadratic-bezier-arc-length) | 32.196578277164434 != 6.2831853071795862 | 10000 in 10 ms. 0.001 ms. average | . |
| [QuadraticBezierArcLengthByIntegral(0, 5, 10, 15, 30, 5)](#The-Quadratic-bezier-arc-length) | 32.196552137530063 != 6.2831853071795862 | 10000 in 10 ms. 0.001 ms. average | . |
| [QuadraticBezierArcLengthBySegments(0, 5, 10, 15, 30, 5)](#The-Quadratic-bezier-arc-length) | 33.801040112848163 != 6.2831853071795862 | 10000 in 102 ms. 0.0102 ms. average | . |

## The Code

The code for the methods tested follows below.

### The Quadratic bezier arc length

The Quadratic bezier arc length.  
- [https://algorithmist.wordpress.com/2009/01/05/quadratic-bezier-arc-length/](https://algorithmist.wordpress.com/2009/01/05/quadratic-bezier-arc-length/)
- [https://code.google.com/archive/p/degrafa/source/default/source](https://code.google.com/archive/p/degrafa/source/default/source)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double QuadraticBezierApproxArcLength(
            double ax, double ay,
            double bx, double by,
            double cx, double cy)
        {
            double sum = 0;

            // Compute the quadratic bezier polynomial coefficients.
            var coeff0X = ax;
            var coeff0Y = ay;
            var coeff1X = 2d * (bx - ax);
            var coeff1Y = 2d * (by - ay);
            var coeff2X = ax - (2d * bx) + cx;
            var coeff2Y = ay - (2d * by) + cy;

            // Count should be between 2 and 8 to align with MathExtensions.abscissa and MathExtensions.weight.
            const int count = 5;
            const int startl = (count == 2) ? 0 : (count * (count - 1) / 2) - 1;

            // Minimum, maximum, and scalers.
            const double min = 0;
            const double max = 1;
            const double mult = 0.5 * (max - min);
            const double ab2 = 0.5 * (min + max);

            var theta = 0d;
            var xPrime = 0d;
            var yPrime = 0d;
            var integrand = 0d;

            // Evaluate the integral arc length along entire curve from t=0 to t=1.
            for (var index = 0; index < count; ++index)
            {
                theta = ab2 + (mult * abscissa[startl + index]);

                // First-derivative of the quadratic bezier.
                xPrime = coeff1X + (2d * coeff2X * theta);
                yPrime = coeff1Y + (2d * coeff2Y * theta);

                // Integrand for Gauss-Legendre numerical integration.
                integrand = Sqrt((xPrime * xPrime) + (yPrime * yPrime));

                sum += integrand * weight[startl + index];
            }

            return Abs(mult) < DoubleEpsilon ? sum : mult * sum;
        }
```

### The Quadratic bezier arc length

The Quadratic bezier arc length.  
- [https://algorithmist.wordpress.com/2009/01/05/quadratic-bezier-arc-length/](https://algorithmist.wordpress.com/2009/01/05/quadratic-bezier-arc-length/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double QuadraticBezierArcLengthByIntegral(
            double ax, double ay,
            double bx, double by,
            double cx, double cy)
        {
            var _ax = ax - (2d * bx) + cx;
            var _ay = ay - (2d * by) + cy;
            var _bx = (2d * bx) - (2d * ax);
            var _by = (2d * by) - (2d * ay);

            var a = 4d * ((_ax * _ax) + (_ay * _ay));
            var b = 4d * ((_ax * _bx) + (_ay * _by));
            var c = (_bx * _bx) + (_by * _by);

            var abc = 2d * Sqrt(a + b + c);
            var a2 = Sqrt(a);
            var a32 = 2d * a * a2;
            var c2 = 2d * Sqrt(c);
            var ba = b / a2;

            return ((a32 * abc) + (a2 * b * (abc - c2)) + (((4d * c * a) - (b * b)) * Log(((2d * a2) + ba + abc) / (ba + c2)))) / (4d * a32);
        }
```

### The Quadratic bezier arc length

The Quadratic bezier arc length.  
- [https://algorithmist.wordpress.com/2009/01/05/quadratic-bezier-arc-length/](https://algorithmist.wordpress.com/2009/01/05/quadratic-bezier-arc-length/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double QuadraticBezierArcLengthBySegments(
            double ax, double ay,
            double bx, double by,
            double cx, double cy)
        {
            var length = 0d;
            var p = InterpolateQuadraticBezier2DTests.QuadraticBezierInterpolate2D(ax, ay, bx, by, cx, cy, 0);
            var prevX = p.X;
            var prevY = p.Y;
            for (var t = 0.005; t <= 1.0; t += 0.005)
            {
                p = InterpolateQuadraticBezier2DTests.QuadraticBezierInterpolate2D(ay, ax, by, bx, cx, cy, t);
                var deltaX = p.X - prevX;
                var deltaY = p.Y - prevY;
                length += Sqrt((deltaX * deltaX) + (deltaY * deltaY));

                prevX = p.X;
                prevY = p.Y;
            }

            // Exercise:  due to roundoff, it's possible to miss a small segment at the end.  how to compensate??
            return length;
        }
```

