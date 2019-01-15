# Rotated Rectangle Points

Find the corner points of a rotated rectangle.

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

../../InstrumentedLibrary/Geometry/Distortion/RotatedRectangleCornersTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double X, double Y)[] RotatedRectangleCorners(double x, double y, double width, double height, double fulcrumX, double fulcrumY, double angle)
```

## Test Case Index

- [Test Case: (0, 0, 10, 10, 5, 5, 0.785398163397448)](#0,-0,-10,-10,-5,-5,-0.785398163397448)

### (0, 0, 10, 10, 5, 5, 0.785398163397448)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [RotatedRectangleCorners0(0, 0, 10, 10, 5, 5, 0.785398163397448)](#Rotated-Rectangle-Points) | System.ValueTuple`2[System.Double,System.Double][] != Point2D{X:0.5, Y:0.5 } | 10000 in 39 ms. 0.0039 ms. average | Point Inside |

## The Code

The code for the methods tested follows below.

### Rotated Rectangle Points

Find the corner points of a rotated rectangle.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y)[] RotatedRectangleCorners0(double x, double y, double width, double height, double fulcrumX, double fulcrumY, double angle)
        {
            var xaxis = (X: Cos(angle), Y: Sin(angle));
            var yaxis = (X: -Sin(angle), Y: Cos(angle));

            // Apply the rotation transformation and translate to new center.
            var points = new List<(double X, double Y)>
            {
                (
                fulcrumX + (-width / 2d * xaxis.X + -height / 2d * xaxis.Y),
                fulcrumY + (-width / 2d * yaxis.X + -height / 2d * yaxis.Y)
                ),
                (
                fulcrumX + (width / 2d * xaxis.X + -height / 2d * xaxis.Y),
                fulcrumY + (width / 2d * yaxis.X + -height / 2d * yaxis.Y)
                ),
                (
                fulcrumX + (width / 2d * xaxis.X + height / 2d * xaxis.Y),
                fulcrumY + (width / 2d * yaxis.X + height / 2d * yaxis.Y)
                ),
                (
                fulcrumX + (-width / 2d * xaxis.X + height / 2d * xaxis.Y),
                fulcrumY + (-width / 2d * yaxis.X + height / 2d * yaxis.Y)
                )
            };

            return points.ToArray();
        }
```

