# 2D Angle Tests

Returns the Angle of a line that runs between two points.

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

../../InstrumentedLibrary/Mathmatics/Angles/Angle2DTests.cs

The required method signature for this API is as follows:

```CSharp
public static double Angle2D(double x1, double y1, double x2, double y2)
```

## Test Case Index

- [Test Case: (0, 0, 1, 1)](#0,-0,-1,-1)

### (0, 0, 1, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Angle2D0(0, 0, 1, 1)](#Angle-from-two-points-using-Atan2) | -2.3561944901923448 == -2.3561944901923448 | 100000 in 140 ms. 0.0014 ms. average | 0d, 0d, 1d, 1d. |
| [Angle2DMashup(0, 0, 1, 1)](#Angle-from-two-points) | 0.78539816339744828 != -2.3561944901923448 | 100000 in 127 ms. 0.00127 ms. average | 0d, 0d, 1d, 1d. |
| [Angle2DMashup2(0, 0, 1, 1)](#Angle-from-two-points-using-Atan2) | -2.3561944901923448 == -2.3561944901923448 | 100000 in 109 ms. 0.00109 ms. average | 0d, 0d, 1d, 1d. |
| [Angle2DPhilippeReverdy(0, 0, 1, 1)](#Angle-from-two-points) | 0.78539816339744828 != -2.3561944901923448 | 100000 in 105 ms. 0.00105 ms. average | 0d, 0d, 1d, 1d. |

## The Code

The code for the methods tested follows below.

### Angle from two points using Atan2

This is the most common method of finding the angle of a line that runs between two points.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Angle2D0(
            double x1, double y1,
            double x2, double y2)
        {
            return /*PI +*/ Atan2(y1 - y2, x1 - x2);
        }
```

### Angle from two points

Angle from two points mashup method.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Angle2DMashup(
            double x1, double y1,
            double x2, double y2)
        {
            var dtheta = /*-PI +*/ Atan2(y2, x2) - Atan2(y1, x1);
            return (dtheta < -PI) ? dtheta + Tau : (dtheta > PI) ? dtheta - Tau : dtheta;
        }
```

### Angle from two points using Atan2

This is the most common method of finding the angle of a line that runs between two points.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Angle2DMashup2(
            double x1, double y1,
            double x2, double y2)
        {
            var value = /*PI +*/ Atan2(y1 - y2, x1 - x2);
            return (value < -PI) ? value + Tau : (value > PI) ? value - Tau : value;
        }
```

### Angle from two points

Philippe Reverdy Angle from two points method.  
- [http://paulbourke.net/geometry/polygonmesh/](http://paulbourke.net/geometry/polygonmesh/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Angle2DPhilippeReverdy(
            double x1, double y1,
            double x2, double y2)
        {
            var theta1 = Atan2(y1, x1);
            var theta2 = Atan2(y2, x2);
            var dtheta = /*-PI +*/ theta2 - theta1;

            while (dtheta > PI)
            {
                dtheta -= PI * 2d;
            }

            while (dtheta < -PI)
            {
                dtheta += PI * 2d;
            }

            return dtheta;
        }
```

