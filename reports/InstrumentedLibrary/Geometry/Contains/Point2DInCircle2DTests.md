# 2D Point in 2D Circle Tests

Test whether a 2D point is contained within a 2D circle.

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

../../InstrumentedLibrary/Geometry/Contains/Point2DInCircle2DTests.cs

The required method signature for this API is as follows:

```CSharp
public static Inclusion PointInCircle(double centerX, double centerY, double radius, double x, double y)
```

## Test Case Index

- [Test Case: (0, 0, 2, 1, 1)](#0,-0,-2,-1,-1)
- [Test Case: (0, 0, 2, 3, 3)](#0,-0,-2,-3,-3)

### (0, 0, 2, 1, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [PointInCircle0(0, 0, 2, 1, 1)](#Point-in-Circle-Method-1) | Inside == Inside | 10000 in 36 ms. 0.0036 ms. average | Point Inside |
| [PointInCircleInline(0, 0, 2, 1, 1)](#Point-in-Circle-Method-2) | Inside == Inside | 10000 in 35 ms. 0.0035 ms. average | Point Inside |
| [PointInCircleNPhilcolbourn(0, 0, 2, 1, 1)](#Point-in-Circle-Method-4) | Inside == Inside | 10000 in 36 ms. 0.0036 ms. average | Point Inside |
| [PointInCirclePhilcolbourn(0, 0, 2, 1, 1)](#Point-in-Circle-Method-3) | Inside == Inside | 10000 in 39 ms. 0.0039 ms. average | Point Inside |
| [PointInCircleWilliamMorrison(0, 0, 2, 1, 1)](#Point-in-Circle-Method-5) | Inside == Inside | 10000 in 34 ms. 0.0034 ms. average | Point Inside |
| [PointInCircleX(0, 0, 2, 1, 1)](#Point-in-Circle-Method-6) | Inside == Inside | 10000 in 28 ms. 0.0028 ms. average | Point Inside |

### (0, 0, 2, 3, 3)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [PointInCircle0(0, 0, 2, 3, 3)](#Point-in-Circle-Method-1) | Outside == Outside | 10000 in 41 ms. 0.0041 ms. average | Point Outside |
| [PointInCircleInline(0, 0, 2, 3, 3)](#Point-in-Circle-Method-2) | Outside == Outside | 10000 in 31 ms. 0.0031 ms. average | Point Outside |
| [PointInCircleNPhilcolbourn(0, 0, 2, 3, 3)](#Point-in-Circle-Method-4) | Outside == Outside | 10000 in 38 ms. 0.0038 ms. average | Point Outside |
| [PointInCirclePhilcolbourn(0, 0, 2, 3, 3)](#Point-in-Circle-Method-3) | Outside == Outside | 10000 in 43 ms. 0.0043 ms. average | Point Outside |
| [PointInCircleWilliamMorrison(0, 0, 2, 3, 3)](#Point-in-Circle-Method-5) | Outside == Outside | 10000 in 30 ms. 0.003 ms. average | Point Outside |
| [PointInCircleX(0, 0, 2, 3, 3)](#Point-in-Circle-Method-6) | Outside == Outside | 10000 in 38 ms. 0.0038 ms. average | Point Outside |

## The Code

The code for the methods tested follows below.

### Point in Circle Method 1

Determine whether a point is contained within a circle by calling a distance method.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion PointInCircle0(
                double centerX, double centerY,
                double radius,
                double x, double y)
        {
            var distance = Distance2DTests.Distance2D(centerX, centerY, x, y);
            return (radius >= distance) ? ((Abs(radius - distance) < DoubleEpsilon) ? Inclusion.Boundary : Inclusion.Inside) : Inclusion.Outside;
        }
```

### Point in Circle Method 2

A modified version of Jason Punyon's method to determine whether a point is contained within a circle by comparing the distance between the point and the center of the circle to the radius.  
- [https://stackoverflow.com/a/481151](https://stackoverflow.com/a/481151)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion PointInCircleInline(
            double centerX, double centerY,
            double radius,
            double x, double y)
        {
            var distance = Sqrt(((x - centerX) * (x - centerX)) + ((y - centerY) * (y - centerY)));
            return (radius >= distance) ? ((Abs(radius - distance) < DoubleEpsilon) ? Inclusion.Boundary : Inclusion.Inside) : Inclusion.Outside;
        }
```

### Point in Circle Method 4

Phil Colbourn's n method for determining whether a point is contained within a circle.  
- [https://stackoverflow.com/a/7227057](https://stackoverflow.com/a/7227057)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion PointInCircleNPhilcolbourn(
            double centerX,
            double centerY,
            double radius,
            double x,
            double y)
        {
            var dx = Abs(x - centerX);
            var dy = Abs(y - centerY);
            var distanceSquared = (dx * dx) + (dy * dy);
            var radiusSquared = radius * radius;
            return (radiusSquared >= distanceSquared) ? ((Abs(radiusSquared - distanceSquared) < DoubleEpsilon) ? Inclusion.Boundary : Inclusion.Inside) : Inclusion.Outside;
        }
```

### Point in Circle Method 3

Phil Colbourn's method for determining whether a point is contained within a circle.  
- [https://stackoverflow.com/a/7227057](https://stackoverflow.com/a/7227057)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion PointInCirclePhilcolbourn(
            double centerX,
            double centerY,
            double radius,
            double x,
            double y)
        {
            var dx = Abs(x - centerX);
            if (dx > radius)
            {
                return Inclusion.Outside;
            }

            var dy = Abs(y - centerY);
            if (dy > radius)
            {
                return Inclusion.Outside;
            }
            //if (dx + dy <= radius) return InsideOutside.Inside;
            var distanceSquared = (dx * dx) + (dy * dy);
            var radiusSquared = radius * radius;
            return (radiusSquared >= distanceSquared) ? ((Abs(radiusSquared - distanceSquared) < DoubleEpsilon) ? Inclusion.Boundary : Inclusion.Inside) : Inclusion.Outside;
        }
```

### Point in Circle Method 5

William Morrison's method for determining whether a point is contained within a circle.  
- [https://stackoverflow.com/a/6311501](https://stackoverflow.com/a/6311501)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion PointInCircleWilliamMorrison(
            double centerX,
            double centerY,
            double radius,
            double x,
            double y)
        {
            if (x >= centerX - radius && x <= centerX + radius
                && y >= centerY - radius && y <= centerY + radius)
            {
                var dx = centerX - x;
                var dy = centerY - y;
                dx *= dx;
                dy *= dy;
                var distanceSquared = dx + dy;
                var radiusSquared = radius * radius;
                return (radiusSquared >= distanceSquared) ? ((Abs(radiusSquared - distanceSquared) < DoubleEpsilon) ? Inclusion.Boundary : Inclusion.Inside) : Inclusion.Outside;
            }
            return Inclusion.Outside;
        }
```

### Point in Circle Method 6

A modified version of William Morrison's method for determining whether a point is contained within a circle.  
- [https://stackoverflow.com/a/6311501](https://stackoverflow.com/a/6311501)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion PointInCircleX(
            double centerX,
            double centerY,
            double radius,
            double x,
            double y)
        {
            if (x >= centerX - radius && x <= centerX + radius
                && y >= centerY - radius && y <= centerY + radius)
            {
                var dx = (centerX > x) ? (x - centerX) : (centerX - x);
                var dy = (centerY > y) ? (y - centerY) : (centerY - y);
                if (dx > radius || dy > radius)
                {
                    return Inclusion.Outside;
                }

                dx *= dx;
                dy *= dy;
                var distanceSquared = dx + dy;
                var radiusSquared = radius * radius;
                return (radiusSquared >= distanceSquared) ? ((Abs(radiusSquared - distanceSquared) < DoubleEpsilon) ? Inclusion.Boundary : Inclusion.Inside) : Inclusion.Outside;
            }
            return Inclusion.Outside;
        }
```

