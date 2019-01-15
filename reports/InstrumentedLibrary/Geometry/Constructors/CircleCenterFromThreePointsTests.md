# Circle center from Three Points Tests

Find the center of a circle that intersects three points.

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

../../InstrumentedLibrary/Geometry/Constructors/CircleCenterFromThreePointsTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double X, double Y)? CircleCenterFromPoints(double p1X, double p1Y, double p2X, double p2Y, double p3X, double p3Y)
```

## Test Case Index

- [Test Case: (0, 0, 0, 1, 1, 1)](#0,-0,-0,-1,-1,-1)

### (0, 0, 0, 1, 1, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CircleCenterFromPoints0(0, 0, 0, 1, 1, 1)](#Circle-center-from-three-points) | (0.5, 0.5) != 6.2831853071795862 | 10000 in 29 ms. 0.0029 ms. average | Circle test case. |
| [TripointCircleCenter(0, 0, 0, 1, 1, 1)](#Circle-center-from-three-points) | (NaN, -∞) != 6.2831853071795862 | 10000 in 22 ms. 0.0022 ms. average | Circle test case. |

## The Code

The code for the methods tested follows below.

### Circle center from three points

Find the center of a circle that intersects with three points.  
- [http://stackoverflow.com/questions/4103405/what-is-the-algorithm-for-finding-the-center-of-a-circle-from-three-points](http://stackoverflow.com/questions/4103405/what-is-the-algorithm-for-finding-the-center-of-a-circle-from-three-points)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y)? CircleCenterFromPoints0(
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

            return (
                ((bc * (p2Y - p3Y)) - (cd * (p1Y - p2Y))) / determinant,
                ((cd * (p1X - p2X)) - (bc * (p2X - p3X))) / determinant);
        }
```

### Circle center from three points

Find the center of a circle that intersects with three points.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) TripointCircleCenter(
            double pointAX, double pointAY,
            double pointBX, double pointBY,
            double pointCX, double pointCY)
        {
            //  Calculate the slopes of the lines.
            var slopeA = Slope2Points2DTests.Slope(pointAX, pointAY, pointBX, pointBY);
            var slopeB = Slope2Points2DTests.Slope(pointCX, pointCY, pointBX, pointBY);
            var fY = (((pointAX - pointBX) * (pointAX + pointBX)) + ((pointAY - pointBY) * (pointAY + pointBY))) / (2d * (pointAX - pointBX));
            var fX = (((pointCX - pointBX) * (pointCX + pointBX)) + ((pointCY - pointBY) * (pointCY + pointBY))) / (2d * (pointCX - pointBX));
            var newY = (fX - fY) / (slopeB - slopeA);
            var newX = fX - (slopeB * newY);
            return (newX, newY);
        }
```

