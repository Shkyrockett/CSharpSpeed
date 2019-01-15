# Cubic Bezier Segment Bounds Tests

Calculate bounding rectangle of a cubic bezier curve segment.

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

../../InstrumentedLibrary/Geometry/Bounds/BoundsOfCubicBezierSegmentTests.cs

The required method signature for this API is as follows:

```CSharp
public static Rectangle2D CubicBezierBounds(double ax, double ay, double bx, double by, double cx, double cy, double dx, double dy)
```

## Test Case Index

- [Test Case: (0, 5, 10, 15, 20, 15, 30, 5)](#0,-5,-10,-15,-20,-15,-30,-5)

### (0, 5, 10, 15, 20, 15, 30, 5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CubicBezierBounds1(0, 5, 10, 15, 20, 15, 30, 5)](#Cubic-Bezier-Bounds) | Rectangle2D{X:10, Y:15, Width:9.4036865234375, Height:2.5 } != 6.2831853071795862 | 10000 in 441 ms. 0.0441 ms. average | Circle test case. |
| [CubicBezierBounds2(0, 5, 10, 15, 20, 15, 30, 5)](#Cubic-Bezier-Bounds) | Rectangle2D{X:0, Y:30, Width:5, Height:5 } != 6.2831853071795862 | 10000 in 21 ms. 0.0021 ms. average | Circle test case. |

## The Code

The code for the methods tested follows below.

### Cubic Bezier Bounds

Find bounds of a Cubic Bezier.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rectangle2D CubicBezierBounds1(
            double ax, double ay,
            double bx, double by,
            double cx, double cy,
            double dx, double dy)
        {
            var sortOfCloseLength = (int)CubicBezierSegmentLengthTests.CubicBezierArcLength(ax, ay, bx, by, cx, cy, dx, dy);
            var points = new List<(double X, double Y)>(FunctionalInterpolationTests.Interpolate0to1((i) => InterpolateCubic2DTests.CubicInterpolate2D(ax, ay, bx, by, cx, cy, dx, dy, i), sortOfCloseLength));

            var left = points[0].X;
            var top = points[0].Y;
            var right = points[0].X;
            var bottom = points[0].Y;

            foreach (var point in points)
            {
                // ToDo: Measure performance impact of overwriting each time.
                left = point.X <= left ? point.X : left;
                top = point.Y <= top ? point.Y : top;
                right = point.X >= right ? point.X : right;
                bottom = point.Y >= bottom ? point.Y : bottom;
            }

            return Rectangle2D.FromLTRB(left, top, right, bottom);
        }
```

### Cubic Bezier Bounds

Find bounds of a Cubic Bezier.  
- [http://stackoverflow.com/questions/24809978/calculating-the-bounding-box-of-cubic-bezier-curve](http://stackoverflow.com/questions/24809978/calculating-the-bounding-box-of-cubic-bezier-curve)
- [http://floris.briolas.nl/floris/2009/10/bounding-box-of-cubic-bezier/](http://floris.briolas.nl/floris/2009/10/bounding-box-of-cubic-bezier/)
- [http://jsfiddle.net/SalixAlba/QQnvm/4/](http://jsfiddle.net/SalixAlba/QQnvm/4/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rectangle2D CubicBezierBounds2(
            double ax, double ay,
            double bx, double by,
            double cx, double cy,
            double dx, double dy)
        {
            var a = (3 * dx) - (9d * cx) + (9d * bx) - (3d * ax);
            var b = (6d * ax) - (12d * bx) + (6d * cx);
            var c = (3d * bx) - (3d * ax);

            var disc = (b * b) - (4d * a * c);
            var xl = ax;
            var xh = ax;
            if (dx < xl)
            {
                xl = dx;
            }

            if (dx > xh)
            {
                xh = dx;
            }

            if (disc >= 0d)
            {
                var t1 = (-b + Sqrt(disc)) / (2d * a);

                if (t1 > 0d && t1 < 1d)
                {
                    var x1 = InterpolateCubic1DTests.CubicInterpolate1D(ax, bx, cx, dx, t1);
                    if (x1 < xl)
                    {
                        xl = x1;
                    }

                    if (x1 > xh)
                    {
                        xh = x1;
                    }
                }

                var t2 = (-b - Sqrt(disc)) / (2d * a);

                if (t2 > 0d && t2 < 1d)
                {
                    var x2 = InterpolateCubic1DTests.CubicInterpolate1D(ax, bx, cx, dx, t2);
                    if (x2 < xl)
                    {
                        xl = x2;
                    }

                    if (x2 > xh)
                    {
                        xh = x2;
                    }
                }
            }

            a = (3d * dy) - (9d * cy) + (9d * by) - (3d * ay);
            b = (6d * ay) - (12d * by) + (6d * cy);
            c = (3d * by) - (3d * ay);
            disc = (b * b) - (4d * a * c);
            var yl = ay;
            var yh = ay;
            if (dy < yl)
            {
                yl = dy;
            }

            if (dy > yh)
            {
                yh = dy;
            }

            if (disc >= 0d)
            {
                var t1 = (-b + Sqrt(disc)) / (2d * a);

                if (t1 > 0d && t1 < 1d)
                {
                    var y1 = InterpolateCubic1DTests.CubicInterpolate1D(ay, by, cy, dy, t1);
                    if (y1 < yl)
                    {
                        yl = y1;
                    }

                    if (y1 > yh)
                    {
                        yh = y1;
                    }
                }

                var t2 = (-b - Sqrt(disc)) / (2d * a);

                if (t2 > 0 && t2 < 1)
                {
                    var y2 = InterpolateCubic1DTests.CubicInterpolate1D(ay, by, cy, dy, t2);
                    if (y2 < yl)
                    {
                        yl = y2;
                    }

                    if (y2 > yh)
                    {
                        yh = y2;
                    }
                }
            }

            return new Rectangle2D(xl, xh, yl, yh);
        }
```

