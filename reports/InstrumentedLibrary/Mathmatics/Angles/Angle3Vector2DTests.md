# Three Vector2D Angle Tests

Returns the Angle of three vectors.

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

../../InstrumentedLibrary/Mathmatics/Angles/Angle3Vector2DTests.cs

The required method signature for this API is as follows:

```CSharp
public static double AngleVector(double x1, double y1, double x2, double y2, double x3, double y3)
```

## Test Case Index

- [Test Case: (0, 0, 1, 0, 1, 1)](#0,-0,-1,-0,-1,-1)

### (0, 0, 1, 0, 1, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [AngleVector_0(0, 0, 1, 0, 1, 1)](#Dot-Product-of-three-2D-Vectors-1) | -1.5707963267948966 == -1.5707963267948966 | 10000 in 19 ms. 0.0019 ms. average | 0, 0, 1, 0, 1, 1. |
| [AngleVector_1(0, 0, 1, 0, 1, 1)](#Dot-Product-of-three-2D-Vectors-1) | -1.5707963267948966 == -1.5707963267948966 | 10000 in 11 ms. 0.0011 ms. average | 0, 0, 1, 0, 1, 1. |

## The Code

The code for the methods tested follows below.

### Dot Product of three 2D Vectors 1

Dot Product of three 2D Vectors  
- [http://csharphelper.com/blog/2014/07/perform-geometric-operations-on-polygons-in-c/](http://csharphelper.com/blog/2014/07/perform-geometric-operations-on-polygons-in-c/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AngleVector_0(
            double x1, double y1,
            double x2, double y2,
            double x3, double y3)
        {
            return Atan2(CrossProduct3Vector2DTests.CrossProductVector2D(x1, y1, x2, y2, x3, y3), DotProduct3Vector2DTests.DotProductVector2D(x1, y1, x2, y2, x3, y3));
        }
```

### Dot Product of three 2D Vectors 1

Dot Product of three 2D Vectors  
- [http://csharphelper.com/blog/2014/07/perform-geometric-operations-on-polygons-in-c/](http://csharphelper.com/blog/2014/07/perform-geometric-operations-on-polygons-in-c/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AngleVector_1(
            double aX, double aY,
            double bX, double bY,
            double cX, double cY)
        {
            // Get the dot product.
            var dotProduct = DotProduct3Vector2DTests.DotProductVector2D(aX, aY, bX, bY, cX, cY);

            // Get the cross product.
            var crossProduct = CrossProduct3Vector2DTests.CrossProductVector2D(aX, aY, bX, bY, cX, cY);

            // Calculate the angle.
            return Atan2(crossProduct, dotProduct);
        }
```

