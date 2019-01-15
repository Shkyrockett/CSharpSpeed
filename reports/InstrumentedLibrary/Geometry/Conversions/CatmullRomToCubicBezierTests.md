# Catmull-Rom to Cubic Bézier Tests

Convert a Catmull-Rom curve to a Cubic Bézier segment.

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

../../InstrumentedLibrary/Geometry/Conversions/CatmullRomToCubicBezierTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY) CatmullRomToBezier(double aX, double aY, double bX, double bY, double cX, double cY)
```

## Test Case Index

- [Test Case: (0, 1, 2, 3, 4, 5)](#0,-1,-2,-3,-4,-5)

### (0, 1, 2, 3, 4, 5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CatmullRomToBezier0(0, 1, 2, 3, 4, 5)](#Catmull-Rom-to-Cubic-Bézier) | (0, 1, 0, 1, 1.33333333333333, 2.33333333333333, 2, 3) != (0, 1, 1.33333333333333, 2.33333333333333, 4.66666666666667, 5.66666666666667, 6, 7) | 10000 in 26 ms. 0.0026 ms. average |  |

## The Code

The code for the methods tested follows below.

### Catmull-Rom to Cubic Bézier

Convert a Catmull-Rom curve to a list of Cubic Bézier segments.  
- [https://github.com/ariutta/catmullrom2bezier/blob/master/catmullrom2bezier.js](https://github.com/ariutta/catmullrom2bezier/blob/master/catmullrom2bezier.js)

```CSharp
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY) CatmullRomToBezier0(
            double aX, double aY,
            double bX, double bY,
            double cX, double cY
            )
        {
            var p = new List<(double x, double y)>
            {
                (bX, bY),
                (aX, aY),
                (bX, bY),
                (cX, cY)
            };

            // Catmull-Rom to Cubic Bézier conversion matrix 
            //    0       1       0       0
            //  -1/6      1      1/6      0
            //    0      1/6      1     -1/6
            //    0       0       1       0
            return (p[1].x, p[1].y, (-p[0].x + 6d * p[1].x + p[2].x) / 6d,
                (-p[0].y + 6d * p[1].y + p[2].y) / 6d, (p[1].x + 6d * p[2].x - p[3].x) / 6d,
                (p[1].y + 6d * p[2].y - p[3].y) / 6d,
                p[2].x, p[2].y);
        }
```

