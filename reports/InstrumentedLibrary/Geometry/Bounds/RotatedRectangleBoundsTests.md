# Rotated Rectangle Bounds Tests

Finds the bounding rectangle of a rotated rectangle.

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

../../InstrumentedLibrary/Geometry/Bounds/RotatedRectangleBoundsTests.cs

The required method signature for this API is as follows:

```CSharp
public static Rectangle2D RotatedRectangleBounds(double x, double y, double width, double height, double fulcrumX, double fulcrumY, double angle)
```

## Test Case Index

- [Test Case: (0, 0, 2, 2, 1, 1, 0.785398163397448)](#0,-0,-2,-2,-1,-1,-0.785398163397448)

### (0, 0, 2, 2, 1, 1, 0.785398163397448)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [RotatedRectangleBounds0(0, 0, 2, 2, 1, 1, 0.785398163397448)](#Rotated-Rectangle-Bounds) | Rectangle2D{X:-0.41421356237309515, Y:-0.41421356237309515, Width:3.2426406871192857, Height:3.2426406871192857 } != Rectangle2D{X:-0.20710678118654757, Y:-0.20710678118654757, Width:1.4142135623730949, Height:1.4142135623730949 } | 10000 in 34 ms. 0.0034 ms. average | Circle from three points test case. |

## The Code

The code for the methods tested follows below.

### Rotated Rectangle Bounds

Finds the bounding rectangle of a rotated rectangle.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rectangle2D RotatedRectangleBounds0(double x, double y, double width, double height, double fulcrumX, double fulcrumY, double angle)
        {
            var cosAngle = Abs(Cos(angle));
            var sinAngle = Abs(Sin(angle));

            var size = new Size2D(
                (cosAngle * width) + (sinAngle * height),
                (cosAngle * height) + (sinAngle * width)
                );

            var loc = new Point2D(
                fulcrumX + (-width / 2d * cosAngle + -height / 2d * sinAngle),
                fulcrumY + (-width / 2d * sinAngle + -height / 2d * cosAngle)
                );

            return new Rectangle2D(loc, size);
        }
```

