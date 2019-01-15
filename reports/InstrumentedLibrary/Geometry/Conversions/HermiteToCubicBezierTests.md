# Hermite to Cubic Bézier Tests

Convert a Hermite curve to a Cubic Bézier.

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

../../InstrumentedLibrary/Geometry/Conversions/HermiteToCubicBezierTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY) HermiteToCubicBezier(double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY, double tension, double bias)
```

## Test Case Index

- [Test Case: (0, 1, 2, 3, 4, 5, 6, 7, 1, 0)](#0,-1,-2,-3,-4,-5,-6,-7,-1,-0)

### (0, 1, 2, 3, 4, 5, 6, 7, 1, 0)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [ToCubicBezier(0, 1, 2, 3, 4, 5, 6, 7, 1, 0)](#Hermite-to-Cubic-Bézier-Tests) | (0, 1, 1.33333333333333, 2.33333333333333, 4.66666666666667, 5.66666666666667, 6, 7) != (0, 1, 1.33333333333333, 2.33333333333333, 4.66666666666667, 5.66666666666667, 6, 7) | 10000 in 26 ms. 0.0026 ms. average |  |

## The Code

The code for the methods tested follows below.

### Hermite to Cubic Bézier Tests

Convert a Hermite curve to a Cubic Bézier.  
- [http://stackoverflow.com/questions/29087503/how-to-create-jigsaw-puzzle-pieces-using-opengl-and-bezier-curve/29089681#29089681](http://stackoverflow.com/questions/29087503/how-to-create-jigsaw-puzzle-pieces-using-opengl-and-bezier-curve/29089681#29089681)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY) ToCubicBezier(
            double aX, double aY,
            double bX, double bY,
            double cX, double cY,
            double dX, double dY,
            double tension, double bias)
        {
            return (aX, aY, bX - (cX - aX) / 6d, bY - (cY - aY) / 6d, cX + (dX - bX) / 6d, cY + (dY - bY) / 6d, dX, dY);
        }
```

