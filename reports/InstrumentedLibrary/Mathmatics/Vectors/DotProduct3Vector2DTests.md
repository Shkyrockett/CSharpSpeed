# Dot Product Tests

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

../../InstrumentedLibrary/Mathmatics/Vectors/DotProduct3Vector2DTests.cs

The required method signature for this API is as follows:

```CSharp
public static double DotProductVector2D(double x1, double y1, double x2, double y2, double x3, double y3)
```

## Test Case Index

- [Test Case: (0, 0, 1, 0, 1, 1)](#0,-0,-1,-0,-1,-1)

### (0, 0, 1, 0, 1, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [DotProductVector2D_0(0, 0, 1, 0, 1, 1)](#Dot-Product-of-three-2D-Vectors-1) | 0 == 0 | 10000 in 19 ms. 0.0019 ms. average |  0, 0, 1, 0, 1, 1. |
| [DotProductVector2D_2(0, 0, 1, 0, 1, 1)](#Dot-Product-of-three-2D-Vectors-1) | 0 == 0 | 10000 in 8 ms. 0.0008 ms. average |  0, 0, 1, 0, 1, 1. |

## The Code

The code for the methods tested follows below.

### Dot Product of three 2D Vectors 1

Dot Product of three 2D Vectors  
- [http://csharphelper.com/blog/2014/07/perform-geometric-operations-on-polygons-in-c/](http://csharphelper.com/blog/2014/07/perform-geometric-operations-on-polygons-in-c/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DotProductVector2D_0(
            double x1, double y1,
            double x2, double y2,
            double x3, double y3)
        {
            return ((x1 - x2) * (x3 - x2)) + ((y1 - y2) * (y3 - y2));
        }
```

### Dot Product of three 2D Vectors 1

Dot Product of three 2D Vectors  
- [http://csharphelper.com/blog/2014/07/perform-geometric-operations-on-polygons-in-c/](http://csharphelper.com/blog/2014/07/perform-geometric-operations-on-polygons-in-c/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DotProductVector2D_2(
            double x1, double y1,
            double x2, double y2,
            double x3, double y3)
        {
            // Get the vectors' coordinates.
            var BAx = x1 - x2;
            var BAy = y1 - y2;
            var BCx = x3 - x2;
            var BCy = y3 - y2;

            // Calculate the dot product.
            return (BAx * BCx) + (BAy * BCy);
        }
```

