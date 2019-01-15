# General Polynomial Coefficients

Find the Polynomial Coefficients of a General Bezier Curve.

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

../../InstrumentedLibrary/Mathmatics/Polynomials/CoefficientRepresentations/RecursiveBezierCoefficientsTests.cs

The required method signature for this API is as follows:

```CSharp
public static Polynomial RecursiveBezierCoefficients(params double[] values)
```

## Test Case Index

- [Test Case: (System.Double[])](#System.Double[])
- [Test Case: (System.Double[])](#System.Double[])
- [Test Case: (System.Double[])](#System.Double[])
- [Test Case: (System.Double[])](#System.Double[])
- [Test Case: (System.Double[])](#System.Double[])
- [Test Case: (System.Double[])](#System.Double[])
- [Test Case: (System.Double[])](#System.Double[])
- [Test Case: (System.Double[])](#System.Double[])
- [Test Case: (System.Double[])](#System.Double[])
- [Test Case: (System.Double[])](#System.Double[])
- [Test Case: (System.Double[])](#System.Double[])

### (System.Double[])

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [BezierCoefficientsRecursive(System.Double[])](#General-Polynomial-Coefficients) | 1 != Null | 1000 in 1 ms. 0.001 ms. average | Dumb Polynomial test. |

### (System.Double[])

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [BezierCoefficientsRecursive(System.Double[])](#General-Polynomial-Coefficients) | x + 1 != Null | 1000 in 2 ms. 0.002 ms. average | Dumb Polynomial test. |

### (System.Double[])

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [BezierCoefficientsRecursive(System.Double[])](#General-Polynomial-Coefficients) | 2x + 1 != Null | 1000 in 1 ms. 0.001 ms. average | Dumb Polynomial test. |

### (System.Double[])

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [BezierCoefficientsRecursive(System.Double[])](#General-Polynomial-Coefficients) | 3x + 1 != Null | 1000 in 3 ms. 0.003 ms. average | Dumb Polynomial test. |

### (System.Double[])

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [BezierCoefficientsRecursive(System.Double[])](#General-Polynomial-Coefficients) | 4x + 1 != Null | 1000 in 9 ms. 0.009 ms. average | Dumb Polynomial test. |

### (System.Double[])

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [BezierCoefficientsRecursive(System.Double[])](#General-Polynomial-Coefficients) | 5x + 1 != Null | 1000 in 12 ms. 0.012 ms. average | Dumb Polynomial test. |

### (System.Double[])

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [BezierCoefficientsRecursive(System.Double[])](#General-Polynomial-Coefficients) | 6x + 1 != Null | 1000 in 24 ms. 0.024 ms. average | Dumb Polynomial test. |

### (System.Double[])

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [BezierCoefficientsRecursive(System.Double[])](#General-Polynomial-Coefficients) | 7x + 1 != Null | 1000 in 59 ms. 0.059 ms. average | Dumb Polynomial test. |

### (System.Double[])

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [BezierCoefficientsRecursive(System.Double[])](#General-Polynomial-Coefficients) | 8x + 1 != Null | 1000 in 132 ms. 0.132 ms. average | Dumb Polynomial test. |

### (System.Double[])

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [BezierCoefficientsRecursive(System.Double[])](#General-Polynomial-Coefficients) | 9x + 1 != Null | 1000 in 237 ms. 0.237 ms. average | Dumb Polynomial test. |

### (System.Double[])

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [BezierCoefficientsRecursive(System.Double[])](#General-Polynomial-Coefficients) | 10x + 1 != Null | 1000 in 465 ms. 0.465 ms. average | Dumb Polynomial test. |

## The Code

The code for the methods tested follows below.

### General Polynomial Coefficients

Find the Polynomial Coefficients of a General Bezier Curve.  
- [https://github.com/superlloyd/Poly](https://github.com/superlloyd/Poly)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Polynomial BezierCoefficientsRecursive(params double[] values)
        {
            if (values is null || values.Length < 1)
            {
                throw new ArgumentNullException(nameof(values), "At least 2 different points must be given");
            }

            return BezierCoefficientsRecursive(0, values.Length - 1, values);
        }
```

