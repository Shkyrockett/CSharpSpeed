# Normalize two 2D Vectors Tests

Normalizes two 2D Vectors.

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

../../InstrumentedLibrary/Mathmatics/Vectors/NormalizeTwoVectors2DTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double I, double J) Normalize(double aI, double aJ, double bI, double bJ)
```

## Test Case Index

- [Test Case: (0, 1, 1, 2)](#0,-1,-1,-2)

### (0, 1, 1, 2)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Normalize0(0, 1, 1, 2)](#Normalize-two-2D-Vectors) | (0, 0.70710678118654746) != (0, 1) | 10000 in 9 ms. 0.0009 ms. average | 0, 1. |

## The Code

The code for the methods tested follows below.

### Normalize two 2D Vectors

Normalize two 2D Vectors.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double I, double J) Normalize0(
            double aI, double aJ,
            double bI, double bJ)
        {
            return (
                aI / Sqrt((aI * bI) + (aJ * bJ)),
                aJ / Sqrt((aI * bI) + (aJ * bJ))
                );
        }
```

