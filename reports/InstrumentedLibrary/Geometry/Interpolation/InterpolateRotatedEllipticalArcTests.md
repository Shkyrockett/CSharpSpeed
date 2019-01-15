# Interpolate Rotated Elliptical Arc Tests

Find a point on an rotated elliptical arc.

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

../../InstrumentedLibrary/Geometry/Interpolation/InterpolateRotatedEllipticalArcTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double X, double Y) EllipticalArc(double cX, double cY, double r1, double r2, double angle, double startAngle, double sweepAngle, double t)
```

## Test Case Index

- [Test Case: (0, 0, 3, 4, 0.523598775598299, 0, 0.523598775598299, 0.5)](#0,-0,-3,-4,-0.523598775598299,-0,-0.523598775598299,-0.5)

### (0, 0, 3, 4, 0.523598775598299, 0, 0.523598775598299, 0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [EllipticalArc_(0, 0, 3, 4, 0.523598775598299, 0, 0.523598775598299, 0.5)](#Interpolate-Unrotated-Elliptical-Arc-1) | (2.1531054250780892, 2.1531054250780888) == (2.1531054250780892, 2.1531054250780888) | 10000 in 12 ms. 0.0012 ms. average | Find the point in the middle of a rotated elliptical arc of 3:4 centered about the origin. |

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
            double angle,
            double startAngle, double sweepAngle,
            double t)
        {
            return InterpolateRotatedEllipseTests.Ellipse(cX, cY, r1, r2, angle, EllipticalPolarAngleTests.EllipticalPolarAngle(startAngle + (sweepAngle * t), r1, r2));
        }
```

