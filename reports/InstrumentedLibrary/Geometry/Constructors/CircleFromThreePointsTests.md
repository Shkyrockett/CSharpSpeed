# Circle from Three Points Tests

Find a circle that intersects three points.

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

../../InstrumentedLibrary/Geometry/Constructors/CircleFromThreePointsTests.cs

The required method signature for this API is as follows:

```CSharp
public static Circle2D? CircleFromPoints(double p1X, double p1Y, double p2X, double p2Y, double p3X, double p3Y)
```

## Test Case Index

- [Test Case: (0, 0, 0, 1, 1, 1)](#0,-0,-0,-1,-1,-1)

### (0, 0, 0, 1, 1, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CircleFromPoints0(0, 0, 0, 1, 1, 1)](#Circle-from-three-points) | Circle2D{X:0.5, Y:0.5, Radius:0.70710678118654757 } != 6.2831853071795862 | 10000 in 34 ms. 0.0034 ms. average | Circle test case. |
| [TripointCircle(0, 0, 0, 1, 1, 1)](#Circle-from-three-points) | Circle2D{X:0.5, Y:0.5, Radius:0.70710678118654757 } != 6.2831853071795862 | 10000 in 29 ms. 0.0029 ms. average | Circle test case. |

## The Code

The code for the methods tested follows below.

### Circle from three points

Find a circle that intersects with three points.  
- [http://stackoverflow.com/questions/4103405/what-is-the-algorithm-for-finding-the-center-of-a-circle-from-three-points](http://stackoverflow.com/questions/4103405/what-is-the-algorithm-for-finding-the-center-of-a-circle-from-three-points)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Circle2D? CircleFromPoints0(
            double p1X, double p1Y,
            double p2X, double p2Y,
            double p3X, double p3Y)
        {
            var offset = (p2X * p2X) + (p2Y * p2Y);
            var bc = ((p1X * p1X) + (p1Y * p1Y) - offset) * 0.5d;
            var cd = (offset - (p3X * p3X) - (p3Y * p3Y)) * 0.5d;
            var determinant = ((p1X - p2X) * (p2Y - p3Y)) - ((p2X - p3X) * (p1Y - p2Y));

            if (Abs(determinant) < DoubleEpsilon)
            {
                return null;
            }

            var centerx = ((bc * (p2Y - p3Y)) - (cd * (p1Y - p2Y))) / determinant;
            var centery = ((cd * (p1X - p2X)) - (bc * (p2X - p3X))) / determinant;

            var radius = Sqrt(((p2X - centerx) * (p2X - centerx)) + ((p2Y - centery) * (p2Y - centery)));

            return new Circle2D(centerx, centery, radius);
        }
```

### Circle from three points

Find a circle that intersects with three points.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Circle2D? TripointCircle(
            double PointAX, double PointAY,
            double PointBX, double PointBY,
            double PointCX, double PointCY)
        {
            (var X, var Y) = CircleCenterFromThreePointsTests.CircleCenterFromPoints(PointAX, PointAY, PointBX, PointBY, PointCX, PointCY) ?? (0d, 0d);
            var radius = Distance2DTests.Distance2D(X, Y, PointAX, PointAY);
            return new Circle2D(X, Y, radius);
        }
```

