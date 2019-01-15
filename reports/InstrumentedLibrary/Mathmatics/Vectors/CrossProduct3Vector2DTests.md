# Cross Product 3 Vector2D Tests

Returns the cross product of three 2D vectors.

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

../../InstrumentedLibrary/Mathmatics/Vectors/CrossProduct3Vector2DTests.cs

The required method signature for this API is as follows:

```CSharp
public static double CrossProductVector2D(double aX, double aY, double bX, double bY, double cX, double cY)
```

## Test Case Index

- [Test Case: (0, 0, 1, 0, 1, 1)](#0,-0,-1,-0,-1,-1)

### (0, 0, 1, 0, 1, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CrossProductVector0(0, 0, 1, 0, 1, 1)](#Cross-Product-of-three-2D-Vectors-1) | -1 == -1 | 10000 in 22 ms. 0.0022 ms. average | 0, 0, 1, 0, 1, 1. |
| [CrossProductVector2D_0(0, 0, 1, 0, 1, 1)](#Cross-Product-of-three-2D-Vectors-1) | -1 == -1 | 10000 in 19 ms. 0.0019 ms. average | 0, 0, 1, 0, 1, 1. |
| [CrossProductVector2D_1(0, 0, 1, 0, 1, 1)](#Cross-Product-of-three-2D-Vectors-1) | -1 == -1 | 10000 in 17 ms. 0.0017 ms. average | 0, 0, 1, 0, 1, 1. |
| [CrossProductVector2D_2(0, 0, 1, 0, 1, 1)](#Cross-Product-of-three-2D-Vectors-2) | -1 == -1 | 10000 in 25 ms. 0.0025 ms. average | 0, 0, 1, 0, 1, 1. |

## The Code

The code for the methods tested follows below.

### Cross Product of three 2D Vectors 1

Cross Product of three 2D Vectors  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProductVector0(
            double x1, double y1,
            double x2, double y2,
            double x3, double y3)
        {
            return (x2 - x1) * (y1 - y3) - (x1 - x3) * (y2 - y1);
        }
```

### Cross Product of three 2D Vectors 1

Cross Product of three 2D Vectors  
- [http://csharphelper.com/blog/2014/07/determine-whether-a-point-is-inside-a-polygon-in-c/](http://csharphelper.com/blog/2014/07/determine-whether-a-point-is-inside-a-polygon-in-c/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProductVector2D_0(
            double aX, double aY,
            double bX, double bY,
            double cX, double cY)
        {
            return ((aX - bX) * (cY - bY)) - ((aY - bY) * (cX - bX));
        }
```

### Cross Product of three 2D Vectors 1

Cross Product of three 2D Vectors  
- [http://csharphelper.com/blog/2014/07/determine-whether-a-point-is-inside-a-polygon-in-c/](http://csharphelper.com/blog/2014/07/determine-whether-a-point-is-inside-a-polygon-in-c/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProductVector2D_1(
            double aX, double aY,
            double bX, double bY,
            double cX, double cY)
        {
            // Get the vectors' coordinates.
            var BAx = aX - bX;
            var BAy = aY - bY;
            var BCx = cX - bX;
            var BCy = cY - bY;

            // Calculate the Z coordinate of the cross product.
            return (BAx * BCy) - (BAy * BCx);
        }
```

### Cross Product of three 2D Vectors 2

Cross Product of three 2D Vectors  
- [http://csharphelper.com/blog/2014/07/perform-geometric-operations-on-polygons-in-c/](http://csharphelper.com/blog/2014/07/perform-geometric-operations-on-polygons-in-c/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProductVector2D_2(
            double Ax, double Ay,
            double Bx, double By,
            double Cx, double Cy)
        {
            // Get the vectors' coordinates.
            var BAx = Ax - Bx;
            var BAy = Ay - By;
            var BCx = Cx - Bx;
            var BCy = Cy - By;

            // Calculate the Z coordinate of the cross product.
            return (BAx * BCy) - (BAy * BCx);
        }
```

