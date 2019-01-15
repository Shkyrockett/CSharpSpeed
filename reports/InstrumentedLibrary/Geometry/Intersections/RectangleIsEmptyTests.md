# Are values zero

Determines whether a set of values is zero.

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

../../InstrumentedLibrary/Geometry/Intersections/RectangleIsEmptyTests.cs

The required method signature for this API is as follows:

```CSharp
public static bool IsRectangleEmpty(double width, double height)
```

## Test Case Index

- [Test Case: (0, 0)](#0,-0)

### (0, 0)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [IsEmpty(0, 0)](#Are-values-zero) | True == True | 10000 in 5 ms. 0.0005 ms. average | . |

## The Code

The code for the methods tested follows below.

### Are values zero

Determines whether a set of values is zero.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEmpty(double width, double height)
        {
            return (Abs(width) <= 0) || (Abs(height) <= 0);
        }
```

