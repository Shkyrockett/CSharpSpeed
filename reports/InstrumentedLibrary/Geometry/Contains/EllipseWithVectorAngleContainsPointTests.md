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

../../InstrumentedLibrary/Geometry/Contains/EllipseWithVectorAngleContainsPointTests.cs

The required method signature for this API is as follows:

```CSharp
public static Inclusion EllipseContainsPoint(double cX, double cY, double rx, double ry, double cosT, double sinT, double pX, double pY, double epsilon = Epsilon)
```

## Test Case Index

- [Test Case: (0, 0, 2, 2, 1, 0, 0.5, 0.5, 5.6843418860808E-12)](#0,-0,-2,-2,-1,-0,-0.5,-0.5,-5.6843418860808E-12)

### (0, 0, 2, 2, 1, 0, 0.5, 0.5, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [EllipseContainsPoint1(0, 0, 2, 2, 1, 0, 0.5, 0.5, 5.6843418860808E-12)](#Point-In-Ellipse-Tests) | Inside != True | 10000 in 25 ms. 0.0025 ms. average |  |
| [EllipseContainsPoint2(0, 0, 2, 2, 1, 0, 0.5, 0.5, 5.6843418860808E-12)](#Point-In-Ellipse-Tests) | Inside != True | 10000 in 36 ms. 0.0036 ms. average |  |

## The Code

The code for the methods tested follows below.

### Point In Ellipse Tests

Determines whether a point is in an Ellipse.  
- [http://stackoverflow.com/questions/7946187/point-and-ellipse-rotated-position-test-algorithm](http://stackoverflow.com/questions/7946187/point-and-ellipse-rotated-position-test-algorithm)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion EllipseContainsPoint1(
            double cX, double cY, double rx, double ry, double cosT, double sinT,
            double pX, double pY,
            double epsilon = Epsilon)
        {
            if (rx <= 0d || ry <= 0d)
            {
                return Inclusion.Outside;
            }

            // Translate point to origin.
            var u = pX - cX;
            var v = pY - cY;

            // Apply the rotation transformation.
            var a = u * cosT + v * sinT;
            var b = u * sinT - v * cosT;

            var normalizedRadius = (a * a / (rx * rx)) + (b * b / (ry * ry));

            return (normalizedRadius <= 1d)
                ? ((Abs(normalizedRadius - 1d) < Epsilon)
                ? Inclusion.Boundary : Inclusion.Inside) : Inclusion.Outside;
        }
```

### Point In Ellipse Tests

Determines whether a point is in an Ellipse.  
- [https://www.khanacademy.org/math/trigonometry/conics_precalc/ellipses-precalc/v/conic-sections--intro-to-ellipses](https://www.khanacademy.org/math/trigonometry/conics_precalc/ellipses-precalc/v/conic-sections--intro-to-ellipses)
- [https://www.khanacademy.org/computer-programming/ellipse-collision-detector/5514890244521984](https://www.khanacademy.org/computer-programming/ellipse-collision-detector/5514890244521984)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion EllipseContainsPoint2(
            double cx, double cy, double rx, double ry, double cosT, double sinT,
            double x, double y,
            double epsilon = Epsilon)
        {
            if (rx <= 0d || ry <= 0d)
            {
                return Inclusion.Outside;
            }

            // Translate point to origin.
            var u = x - cx;
            var v = y - cy;

            // Apply the rotation transformation.
            var a = cosT * u + sinT * v;
            var b = sinT * u - cosT * v;

            // sqrt x/y terms
            var termX = 2 * a / rx;
            var termY = 2 * b / ry;

            var normalizedRadius = (termX * termX) + (termY * termY);
            return (normalizedRadius <= 1d)
                ? ((Abs(normalizedRadius - 1d) < epsilon)
                ? Inclusion.Boundary : Inclusion.Inside) : Inclusion.Outside;
        }
```

