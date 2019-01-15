# Self Intersection of Cubic Bezier

Finds the self intersection points of a Cubic Bezier.

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

../../InstrumentedLibrary/Geometry/Intersections/CubicBezierSelfIntersectionTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double X, double Y)? CubicBezierSelfIntersection(double x0, double y0, double x1, double y1, double x2, double y2, double x3, double y3)
```

## Test Case Index

- [Test Case: (0, 5, 10, 15, 20, 0, 5, 10)](#0,-5,-10,-15,-20,-0,-5,-10)

### (0, 5, 10, 15, 20, 0, 5, 10)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CubicBezierSelfIntersection_(0, 5, 10, 15, 20, 0, 5, 10)](#Self-Intersection-of-Cubic-Bezier) | Null != 15 | 10000 in 48 ms. 0.0048 ms. average |  |
| [CubicBezierSelfIntersectionX(0, 5, 10, 15, 20, 0, 5, 10)](#Self-Intersection-of-Cubic-Bezier) | (7.1999999999999744, 8.60000000000002) != 15 | 10000 in 43 ms. 0.0043 ms. average |  |

## The Code

The code for the methods tested follows below.

### Self Intersection of Cubic Bezier

Finds the self intersection points of a Cubic Bezier.  
- [https://groups.google.com/d/msg/comp.graphics.algorithms/SRm97nRWlw4/R1Rn38ep8n0J](https://groups.google.com/d/msg/comp.graphics.algorithms/SRm97nRWlw4/R1Rn38ep8n0J)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y)? CubicBezierSelfIntersection_(double x0, double y0, double x1, double y1, double x2, double y2, double x3, double y3)
        {
            var (xCurveA, xCurveB, xCurveC, xCurveD) = CubicBezierCoefficientsTests.CubicBezierCoefficients(x0, x1, x2, x3);
            (var a, var b) = (xCurveD == 0d) ? (xCurveC, xCurveB) : (xCurveC / xCurveD, xCurveB / xCurveD);
            var (yCurveA, yCurveB, yCurveC, yCurveD) = CubicBezierCoefficientsTests.CubicBezierCoefficients(y0, y1, y2, y3);
            (var p, var q) = (yCurveD == 0d) ? (yCurveC, yCurveB) : (yCurveC / yCurveD, yCurveB / yCurveD);

            if (a == p || q == b)
            {
                return null;
            }

            var k = (q - b) / (a - p);

            var poly = new double[]
            {
                -k * k * k - a * k * k - b * k,
                3 * k * k + 2 * k * a + 2 * b,
                -3 * k,
                2
            };

            var roots = CubicRootsTests.CubicRoots(poly[3], poly[2], poly[1], poly[0])
                .OrderByDescending(c => c).ToArray();
            if (roots.Length != 3)
            {
                return null;
            }

            if (roots[0] >= 0d && roots[0] <= 1d && roots[2] >= 0d && roots[2] <= 1d)
            {
                return InterpolateCubic2DTests.CubicInterpolate2D(x0, y0, x1, y1, x2, y2, x3, y3, roots[0]);
            }

            return null;
        }
```

### Self Intersection of Cubic Bezier

Finds the self intersection points of a Cubic Bezier.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y)? CubicBezierSelfIntersectionX(double x0, double y0, double x1, double y1, double x2, double y2, double x3, double y3)
        {
            return CubicBezierSelfIntersectionX(
                CubicBezierCoefficientsTests.CubicBezierCoefficients(x0, x1, x2, x3),
                CubicBezierCoefficientsTests.CubicBezierCoefficients(y0, y1, y2, y3));
        }
```

