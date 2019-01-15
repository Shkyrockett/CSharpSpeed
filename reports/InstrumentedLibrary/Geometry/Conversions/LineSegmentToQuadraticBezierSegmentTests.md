# Line Segment to Quadratic Bézier Tests

Convert a Line Segment to a Quadratic Bézier.

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

../../InstrumentedLibrary/Geometry/Conversions/LineSegmentToQuadraticBezierSegmentTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double aX, double aY, double bX, double bY, double cX, double cY) LineSegmentToQuadraticBezier(double x0, double y0, double x1, double y1)
```

## Test Case Index

- [Test Case: (0, 1, 2, 3)](#0,-1,-2,-3)

### (0, 1, 2, 3)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [LineSegmentToQuadraticBezier0(0, 1, 2, 3)](#Line-Segment-to-Quadratic-Bézier-Tests) | (0, 1, 1, 2, 2, 3) != (0, 1, 1.33333333333333, 2.33333333333333, 4.66666666666667, 5.66666666666667, 6, 7) | 10000 in 12 ms. 0.0012 ms. average |  |

## The Code

The code for the methods tested follows below.

### Line Segment to Quadratic Bézier Tests

Raise a Line segment to a Quadratic Bézier.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double aX, double aY, double bX, double bY, double cX, double cY) LineSegmentToQuadraticBezier0(
            double x0, double y0,
            double x1, double y1)
        {
            (double X, double Y) p = InterpolateLinear2DTests.LinearInterpolate2D(x0, y0, x1, y1, OneHalf);
            return (x0, y0, p.X, p.Y, x1, y1);
        }
```

