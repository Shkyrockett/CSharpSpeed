# Barycentric Tests

Cartesian coordinate of the specified point with respect to the axis being used.

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

../../InstrumentedLibrary/Geometry/Centers/BarycentricTests.cs

The required method signature for this API is as follows:

```CSharp
public static double Barycentric(double value1, double value2, double value3, double amount1, double amount2)
```

## Test Case Index

- [Test Case: (1, 2, 3, 4, 5)](#1,-2,-3,-4,-5)

### (1, 2, 3, 4, 5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Barycentric0(1, 2, 3, 4, 5)](#Barycentric) | 15 == 15 | 10000 in 19 ms. 0.0019 ms. average | 1, 2, 3, 4, 5 |

## The Code

The code for the methods tested follows below.

### Barycentric

Returns the Cartesian coordinate for one axis of a point that is defined by a given triangle and two normalized barycentric (areal) coordinates.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Barycentric0(double value1, double value2, double value3, double amount1, double amount2)
        {
            return value1 + ((value2 - value1) * amount1) + ((value3 - value1) * amount2);
        }
```

