# Quadratic Bezier Segment Bounds Tests

Calculate bounding rectangle of a Quadratic bezier curve segment.

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

../../InstrumentedLibrary/Geometry/Bounds/BoundsOfQuadraticBezierSegmentTests.cs

The required method signature for this API is as follows:

```CSharp
public static Rectangle2D QuadraticBezierBounds(double ax, double ay, double bx, double by, double cx, double cy)
```

## Test Case Index

- [Test Case: (0, 5, 10, 15, 30, 5)](#0,-5,-10,-15,-30,-5)

### (0, 5, 10, 15, 30, 5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [QuadraticBezierBounds0(0, 5, 10, 15, 30, 5)](#Quadratic-Bezier-Bounds) | Rectangle2D{X:0, Y:5, Width:26.1, Height:5 } != 6.2831853071795862 | 10000 in 84 ms. 0.0084 ms. average | Circle test case. |

## The Code

The code for the methods tested follows below.

### Quadratic Bezier Bounds

Find bounds of a Quadratic Bezier.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rectangle2D QuadraticBezierBounds0(
            double ax, double ay,
            double bx, double by,
            double cx, double cy)
        {
            var sortOfCloseLength = QuadraticBezierSegmentLengthTests.QuadraticBezierArcLength(ax, ay, bx, by, cx, cy);

            // ToDo: Need to make this more efficient. Don't need to rebuild the point array every time.
            var points = new List<(double X, double Y)>(FunctionalInterpolationTests.Interpolate0to1((i) => InterpolateQuadraticBezier2DTests.QuadraticBezierInterpolate2D(ax, ay, bx, by, cx, cy, i), (int)(sortOfCloseLength / 3)));

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

