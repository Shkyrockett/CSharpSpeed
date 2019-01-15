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

../../InstrumentedLibrary/Geometry/Length/CubicBezierSegmentLengthTests.cs

The required method signature for this API is as follows:

```CSharp
public static double CubicBezierArcLength(double ax, double ay, double bx, double by, double cx, double cy, double dx, double dy)
```

## Test Case Index

- [Test Case: (0, 5, 10, 15, 20, 15, 30, 5)](#0,-5,-10,-15,-20,-15,-30,-5)

### (0, 5, 10, 15, 20, 15, 30, 5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CubicBezierArcLength0(0, 5, 10, 15, 20, 15, 30, 5)](#The-cubic-bezier-arc-length) | 32.750411296700328 != 6.2831853071795862 | 10000 in 85 ms. 0.0085 ms. average | . |
| [CubicBezierLength(0, 5, 10, 15, 20, 15, 30, 5)](#Approximate-length-of-the-Bézier-curve) | 11.227306736204149 != 6.2831853071795862 | 10000 in 17 ms. 0.0017 ms. average | . |

## The Code

The code for the methods tested follows below.

### The cubic bezier arc length

The cubic bezier arc length.  
- [http://steve.hollasch.net/cgindex/curves/cbezarclen.html](http://steve.hollasch.net/cgindex/curves/cbezarclen.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CubicBezierArcLength0(
            double ax, double ay,
            double bx, double by,
            double cx, double cy,
            double dx, double dy)
        {
            var k1 = (X: -ax + (3d * (bx - cx)) + dx, Y: -ay + (3d * (by - cy)) + dy);
            var k2 = (X: (3d * (ax + cx)) - (6d * bx), Y: (3d * (ay + cy)) - (6d * by));
            var k3 = (X: 3d * (bx - ax), Y: 3d * (by - ax));
            //var k4 = (X: ax, y: ay);

            var q1 = 9d * (Sqrt(Abs(k1.X)) + Sqrt(Abs(k1.Y)));
            var q2 = 12d * ((k1.X * k2.X) + (k1.Y * k2.Y));
            var q3 = (3d * ((k1.X * k3.X) + (k1.Y * k3.Y))) + (4d * (Sqrt(Abs(k2.X)) + Sqrt(Abs(k2.Y))));
            var q4 = 4d * ((k2.X * k3.X) + (k2.Y * k3.Y));
            var q5 = Sqrt(Abs(k3.X)) + Sqrt(Abs(k3.Y));

            // Approximation algorithm based on Simpson.
            const double a = 0d;
            const double b = 1d;
            const int n_limit = 1024;
            const double TOLERANCE = 0.001d;

            var n = 1;

            var multiplier = (b - a) / 6d;
            var endsum = CubicBezierArcLengthHelper(ref q1, ref q2, ref q3, ref q4, ref q5, a) + CubicBezierArcLengthHelper(ref q1, ref q2, ref q3, ref q4, ref q5, b);
            var interval = (b - a) * 0.5d;
            var asum = 0d;
            var bsum = CubicBezierArcLengthHelper(ref q1, ref q2, ref q3, ref q4, ref q5, a + interval);
            var est1 = multiplier * (endsum + (2d * asum) + (4d * bsum));
            var est0 = 2d * est1;

            while (n < n_limit && Abs(est1) > 0d && Abs((est1 - est0) / est1) > TOLERANCE)
            {
                n *= 2;
                multiplier /= 2d;
                interval /= 2d;
                asum += bsum;
                bsum = 0d;
                est0 = est1;
                var interval_div_2n = interval / (2d * n);

                for (var i = 1; i < 2 * n; i += 2)
                {
                    var t = a + (i * interval_div_2n);
                    bsum += CubicBezierArcLengthHelper(ref q1, ref q2, ref q3, ref q4, ref q5, t);
                }

                est1 = multiplier * (endsum + (2d * asum) + (4d * bsum));
            }

            return est1 * 10d;
        }
```

### Approximate length of the Bézier curve

Approximate length of the Bézier curve.  
- [http://www.lemoda.net/maths/bezier-length/index.html](http://www.lemoda.net/maths/bezier-length/index.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CubicBezierLength(
            double ax, double ay,
            double bx, double by,
            double cx, double cy,
            double dx, double dy)
        {
            const int steps = 10;// Probably should be a parameter.
            double t;
            (double X, double Y) previous_dot = (0d, 0d);
            var length = 0d;
            for (var i = 0; i <= steps; i++)
            {
                t = (double)i / steps;
                var dot = InterpolateCubic2DTests.CubicInterpolate2D(ax, ay, bx, by, cx, cy, dx, dy, t);
                if (i > 0)
                {
                    var x_diff = dot.X - previous_dot.X;
                    var y_diff = dot.Y - previous_dot.Y;
                    length += Sqrt((x_diff * x_diff) + (y_diff * y_diff));
                }
                previous_dot = dot;
            }
            return length;
        }
```

