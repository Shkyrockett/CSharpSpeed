# Cross Product 2 Vector2D Tests

Returns the cross product of two 2D vectors.

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

../../InstrumentedLibrary/Mathmatics/Vectors/CrossProduct2Vector2DTests.cs

The required method signature for this API is as follows:

```CSharp
public static double CrossProduct2Vector2D(double x1, double y1, double x2, double y2)
```

## Test Case Index

- [Test Case: (0, 0, 1, 0)](#0,-0,-1,-0)

### (0, 0, 1, 0)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CrossProduct2Vector2D_0(0, 0, 1, 0)](#Cross-Product-of-two-2D-Vectors-1) | 0 != -1 | 10000 in 13 ms. 0.0013 ms. average | 0, 0, 1, 0, 1, 1. |

## The Code

The code for the methods tested follows below.

### Cross Product of two 2D Vectors 1

Cross Product of two 2D Vectors  
- [http://csharphelper.com/blog/2014/07/determine-whether-a-point-is-inside-a-polygon-in-c/](http://csharphelper.com/blog/2014/07/determine-whether-a-point-is-inside-a-polygon-in-c/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProduct2Vector2D_0(
            double x1, double y1,
            double x2, double y2)
        {
            return (x1 * y2) - (y1 * x2);
        }
```

