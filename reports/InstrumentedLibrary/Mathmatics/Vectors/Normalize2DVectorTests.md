# Normalize 2D Vector Tests

Normalizes a 2D Vector.

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

../../InstrumentedLibrary/Mathmatics/Vectors/Normalize2DVectorTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double i, double j) Normalize(double i, double j)
```

## Test Case Index

- [Test Case: (0, 1)](#0,-1)

### (0, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Normalize0(0, 1)](#Normalize-2D-Vector) | (0, 1) == (0, 1) | 10000 in 13 ms. 0.0013 ms. average | 0, 1. |

## The Code

The code for the methods tested follows below.

### Normalize 2D Vector

Normalize a 2D Vector.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double i, double j) Normalize0(double i, double j)
        {
            return (
                i / Sqrt((i * i) + (j * j)),
                j / Sqrt((i * i) + (j * j))
                );
        }
```

