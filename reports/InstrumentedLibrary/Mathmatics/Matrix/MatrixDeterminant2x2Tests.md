# Determinant of a 2x2 matrix

Find the determinant of a 2x2 matrix.

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

../../InstrumentedLibrary/Mathmatics/Matrix/MatrixDeterminant2x2Tests.cs

The required method signature for this API is as follows:

```CSharp
public static double Determinant(double r1c1, double r1c2, double r2c1, double r2c2)
```

## Test Case Index

- [Test Case: (1, 2, 3, 4)](#1,-2,-3,-4)

### (1, 2, 3, 4)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Determinant0(1, 2, 3, 4)](#Determinant-of-a-2x2-matrix) | -2 == -2 | 10000 in 7 ms. 0.0007 ms. average | polygon, point. |

## The Code

The code for the methods tested follows below.

### Determinant of a 2x2 matrix

Jerry J. Chen's method for finding the determinant of a 2x2 matrix.  
- [https://github.com/onlyuser/Legacy/blob/master/msvb/Dex3d/Math.bas](https://github.com/onlyuser/Legacy/blob/master/msvb/Dex3d/Math.bas)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Determinant0(
            double m1x1, double m1x2,
            double m2x1, double m2x2)
        {
            return (m1x1 * m2x2) - (m1x2 * m2x1);
        }
```

