# Area Intersection Two Circles

Find the area of the section of the intersection of two circles.

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

../../InstrumentedLibrary/Geometry/Area/IntersectionCirclesTestsArea.cs

The required method signature for this API is as follows:

```CSharp
public static double Area(double centerX1, double centerY1, double radius1, double centerX2, double centerY2, double radius2)
```

## Test Case Index

- [Test Case: (0, 0, 1, 1, 0, 1)](#0,-0,-1,-1,-0,-1)

### (0, 0, 1, 1, 0, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Area0(0, 0, 1, 1, 0, 1)](#Area-Intersection-Two-Circles) | 1.2283696986087567 == 1.2283696986087567 | 10000 in 22 ms. 0.0022 ms. average | Two unit circles, one at origin, the other shifted to the right one unit. |
| [Area1(0, 0, 1, 1, 0, 1)](#Area-Intersection-Two-Circles) | 1.2283696986087567 == 1.2283696986087567 | 10000 in 26 ms. 0.0026 ms. average | Two unit circles, one at origin, the other shifted to the right one unit. |

## The Code

The code for the methods tested follows below.

### Area Intersection Two Circles

Find the area of the section of the intersection of two circles.  
- [http://www.xarg.org/2016/07/calculate-the-intersection-area-of-two-circles/](http://www.xarg.org/2016/07/calculate-the-intersection-area-of-two-circles/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Area0(double x1, double y1, double r1, double x2, double y2, double r2)
        {
            var d = Sqrt(Pow(x2 - x1, 2) + Pow(y2 - y1, 2));
            if (d < r1 + r2)
            {
                var a = r1 * r1;
                var b = r2 * r2;
                var x = (a - b + (d * d)) / (2d * d);
                var z = x * x;
                var y = Sqrt(a - z);
                if (d < Abs(r2 - r1))
                {
                    return PI * Min(a, b);
                }

                return (a * Asin(y / r1)) + (b * Asin(y / r2)) - (y * (x + Sqrt(z + b - a)));
            }

            return 0d;
        }
```

### Area Intersection Two Circles

Find the area of the section of the intersection of two circles.  
- [http://www.xarg.org/2016/07/calculate-the-intersection-area-of-two-circles/](http://www.xarg.org/2016/07/calculate-the-intersection-area-of-two-circles/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Area1(double x1, double y1, double r1, double x2, double y2, double r2)
        {
            var d = Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            if (d < r1 + r2)
            {
                var a = r1 * r1;
                var b = r2 * r2;
                var x = (a - b + (d * d)) / (2d * d);
                var z = x * x;
                var y = Sqrt(a - z);
                if (d < Abs(r2 - r1))
                {
                    return PI * (a < b ? a : b);
                }

                return (a * Asin(y / r1)) + (b * Asin(y / r2)) - (y * (x + Sqrt(z + b - a)));
            }

            return 0d;
        }
```

