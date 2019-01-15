# Interpolate Unrotated Elliptical Arc Tests

Find a point on an unrotated elliptical arc.

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

../../InstrumentedLibrary/Geometry/Interpolation/InterpolateUnrotatedEllipticalArcTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double X, double Y) EllipticalArc(double cX, double cY, double r1, double r2, double startAngle, double sweepAngle, double t)
```

## Test Case Index

- [Test Case: (0, 0, 3, 4, 0, 0.523598775598299, 0.5)](#0,-0,-3,-4,-0,-0.523598775598299,-0.5)

### (0, 0, 3, 4, 0, 0.523598775598299, 0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [EllipticalArc_(0, 0, 3, 4, 0, 0.523598775598299, 0.5)](#Interpolate-Unrotated-Elliptical-Arc-1) | (2.9411967076827623, 0.788091282604673) == (2.9411967076827623, 0.788091282604673) | 10000 in 12 ms. 0.0012 ms. average | Find the point in the middle of an elliptical arc of 3:4 centered about the origin. |

## The Code

The code for the methods tested follows below.

### Interpolate Unrotated Elliptical Arc 1

Interpolates the unrotated elliptical Arc.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) EllipticalArc_(
            double cX, double cY,
            double r1, double r2,
            double startAngle, double sweepAngle,
            double t)
        {
            var phi = startAngle + (sweepAngle * t);
            var theta = phi % PI;

            var tanAngle = Abs(Tan(theta));
            var x = Sqrt(r1 * r1 * (r2 * r2) / ((r2 * r2) + (r1 * r1 * (tanAngle * tanAngle))));
            var y = x * tanAngle;

            return (theta >= 0d) && (theta < 90d.ToRadians())
                ? (cX + x, cY + y)
                : (theta >= 90d.ToRadians()) && (theta < 180d.ToRadians())
                ? (cX - x, cY + y)
                : (theta >= 180d.ToRadians()) && (theta < 270d.ToRadians()) ? (cX - x, cY - y) : (cX + x, cY - y);
        }
```

