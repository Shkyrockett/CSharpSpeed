# Cross Product 2 Vector3D Tests

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

../../InstrumentedLibrary/Mathmatics/Vectors/CrossProduct2Vector3DTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double X, double Y, double Z) CrossProduct2Points3D(double x1, double y1, double z1, double x2, double y2, double z2)
```

## Test Case Index

- [Test Case: (0, 0, 0, 1, 1, 1)](#0,-0,-0,-1,-1,-1)

### (0, 0, 0, 1, 1, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CrossProduct2Points3D_0(0, 0, 0, 1, 1, 1)](#Cross-Product-of-two-3D-Vectors-1) | (0, 0, 0) != 0 | 10000 in 16 ms. 0.0016 ms. average | 0, 0, 1, 1. |

## The Code

The code for the methods tested follows below.

### Cross Product of two 3D Vectors 1

Cross Product of two 3D Vectors  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) CrossProduct2Points3D_0(
            double x1, double y1, double z1,
            double x2, double y2, double z2)
        {
            return (
                    (y1 * z2) - (z1 * y2), // X
                    (z1 * x2) - (x1 * z2), // Y
                    (x1 * y2) - (y1 * x2)  // Z
                );
        }
```

