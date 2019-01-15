# Normalize two 3D Vectors Tests

Normalizes two 3D Vectors.

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

../../InstrumentedLibrary/Mathmatics/Vectors/NormalizeTwoVectors3DTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double I, double J, double K) Normalize(double aI, double aJ, double aK, double bI, double bJ, double bK)
```

## Test Case Index

- [Test Case: (0, 1, 0, 1, 2, 0)](#0,-1,-0,-1,-2,-0)

### (0, 1, 0, 1, 2, 0)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Normalize0(0, 1, 0, 1, 2, 0)](#Normalize-two-3D-Vectors) | (0, 0.70710678118654746, 0) != (0, 1) | 10000 in 10 ms. 0.001 ms. average | . |

## The Code

The code for the methods tested follows below.

### Normalize two 3D Vectors

Normalize two 3D Vectors.  
- [http://www.fundza.com/vectors/normalize/](http://www.fundza.com/vectors/normalize/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double I, double J, double K) Normalize0(
            double aI, double aJ, double aK,
            double bI, double bJ, double bK)
        {
            return (
                aI / Sqrt((aI * bI) + (aJ * bJ) + (aK * bK)),
                aJ / Sqrt((aI * bI) + (aJ * bJ) + (aK * bK)),
                aK / Sqrt((aI * bI) + (aJ * bJ) + (aK * bK))
                );
        }
```

