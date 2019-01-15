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

../../InstrumentedLibrary/Mathmatics/Vectors/DotProduct2Vector2DTests.cs

The required method signature for this API is as follows:

```CSharp
public static double DotProduct2D(double x1, double y1, double x2, double y2)
```

## Test Case Index

- [Test Case: (0, 0, 1, 0)](#0,-0,-1,-0)

### (0, 0, 1, 0)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [DotProduct2D_0(0, 0, 1, 0)](#Dot-Product-of-two-2D-Vectors-1) | 0 == 0 | 10000 in 18 ms. 0.0018 ms. average | 0, 0, 1, 1. |

## The Code

The code for the methods tested follows below.

### Dot Product of two 2D Vectors 1

Dot Product of two 2D Vectors  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DotProduct2D_0(
            double x1, double y1,
            double x2, double y2)
        {
            return (x1 * x2) + (y1 * y2);
        }
```

