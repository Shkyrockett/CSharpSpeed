# Point Near Orthogonal Ellipse Tests

Determines whether a point is near an Orthogonal Ellipse.

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

../../InstrumentedLibrary/Geometry/Contains/PointNearUnrotatedEllipseTests.cs

The required method signature for this API is as follows:

```CSharp
public static bool PointNearEllipse(double x1, double y1, double x2, double y2, double px, double py, double close_distance)
```

## Test Case Index

- [Test Case: (0, 0, 2, 2, 0.5, 0.5, 5.6843418860808E-12)](#0,-0,-2,-2,-0.5,-0.5,-5.6843418860808E-12)

### (0, 0, 2, 2, 0.5, 0.5, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [PointNearEllipse0(0, 0, 2, 2, 0.5, 0.5, 5.6843418860808E-12)](#Point-Near-Unrotated-Ellipse-Tests) | True == True | 10000 in 22 ms. 0.0022 ms. average |  |

## The Code

The code for the methods tested follows below.

### Point Near Unrotated Ellipse Tests

Determines whether a point is near an Unrotated Ellipse.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointNearEllipse0(double x1, double y1, double x2, double y2, double px, double py, double close_distance)
        {
            var a = (Abs(x2 - x1) / 2d) + close_distance;
            var b = (Abs(y2 - y1) / 2d) + close_distance;
            px = px - (x2 + x1) / 2d;
            py = py - (y2 + y1) / 2d;
            return (px * px / (a * a)) + (py * py / (b * b)) <= 1d;
        }
```

