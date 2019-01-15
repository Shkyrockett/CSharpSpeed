# Point In Ellipse Tests

Determines whether a point is in an Ellipse.

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

../../InstrumentedLibrary/Geometry/Contains/EllipseContainsPointTests.cs

The required method signature for this API is as follows:

```CSharp
public static Inclusion PointInEllipse(double x, double y, double rX, double rY, double angle, double pX, double pY)
```

## Test Case Index

- [Test Case: (0, 0, 2, 2, 0, 0.5, 0.5)](#0,-0,-2,-2,-0,-0.5,-0.5)

### (0, 0, 2, 2, 0, 0.5, 0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [PointInEllipse0(0, 0, 2, 2, 0, 0.5, 0.5)](#Point-In-Ellipse-Tests) | Inside != True | 10000 in 26 ms. 0.0026 ms. average |  |

## The Code

The code for the methods tested follows below.

### Point In Ellipse Tests

Determines whether a point is in an Ellipse.  
- [http://stackoverflow.com/questions/7946187/point-and-ellipse-rotated-position-test-algorithm](http://stackoverflow.com/questions/7946187/point-and-ellipse-rotated-position-test-algorithm)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion PointInEllipse0(double x, double y, double rX, double rY, double angle, double pX, double pY)
        {
            if (rX <= 0d || rY <= 0d)
            {
                return Inclusion.Outside;
            }

            var cosT = Cos(-angle);
            var sinT = Sin(-angle);

            var u = pX - x;
            var v = pY - y;

            var a = (cosT * u + sinT * v) * (cosT * u + sinT * v);
            var b = (sinT * u - cosT * v) * (sinT * u - cosT * v);

            var d1Squared = 4 * rX * rX;
            var d2Squared = 4 * rY * rY;

            var normalizedRadius = (a / d1Squared) + (b / d2Squared);

            return (normalizedRadius <= 1d) ? ((Abs(normalizedRadius - 1d) < DoubleEpsilon) ? Inclusion.Boundary : Inclusion.Inside) : Inclusion.Outside;
        }
```

