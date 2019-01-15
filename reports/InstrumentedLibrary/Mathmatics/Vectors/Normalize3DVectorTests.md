# Normalize 3D Vector Tests

Normalizes a 3D Vector.

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

../../InstrumentedLibrary/Mathmatics/Vectors/Normalize3DVectorTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double i, double j, double k) Normalize(double i, double j, double k)
```

## Test Case Index

- [Test Case: (0, 1, 0)](#0,-1,-0)

### (0, 1, 0)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Normalize0(0, 1, 0)](#Normalize-3D-Vector) | (0, 1, 0) == (0, 1, 0) | 10000 in 7 ms. 0.0007 ms. average | 0, 1, 0. |

## The Code

The code for the methods tested follows below.

### Normalize 3D Vector

Normalize a 3D Vector.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double i, double j, double k) Normalize0(double i, double j, double k)
        {
            return (
                i / Sqrt((i * i) + (j * j) + (k * k)),
                j / Sqrt((i * i) + (j * j) + (k * k)),
                k / Sqrt((i * i) + (j * j) + (k * k))
                );
        }
```

