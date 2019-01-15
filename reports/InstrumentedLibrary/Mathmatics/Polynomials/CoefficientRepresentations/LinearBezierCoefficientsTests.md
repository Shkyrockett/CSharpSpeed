# Linear Polynomial Coefficients

Find the Polynomial Coefficients of a Linear Bezier Curve.

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

../../InstrumentedLibrary/Mathmatics/Polynomials/CoefficientRepresentations/LinearBezierCoefficientsTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double A, double B) LinearBezierCoefficients(double a, double b)
```

## Test Case Index

- [Test Case: (1, 2)](#1,-2)

### (1, 2)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [LinearBezierCoefficients0(1, 2)](#Linear-Polynomial-Coefficients) | (1, 1) == (1, 1) | 1000 in 0 ms. 0 ms. average | Dumb Polynomial test. |
| [LinearBezierCoefficientsGeneral(1, 2)](#Linear-Polynomial-Coefficients) | (1, 1) == (1, 1) | 1000 in 1 ms. 0.001 ms. average | Dumb Polynomial test. |
| [LinearBezierCoefficientsRecursive(1, 2)](#Linear-Polynomial-Coefficients) | (1, 1) == (1, 1) | 1000 in 0 ms. 0 ms. average | Dumb Polynomial test. |

## The Code

The code for the methods tested follows below.

### Linear Polynomial Coefficients

Find the Polynomial Coefficients of a Linear Bezier Curve.  
- [http://fontforge.github.io/bezier.html](http://fontforge.github.io/bezier.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B) LinearBezierCoefficients0(double a, double b)
        {
            return (b - a, a);
        }
```

### Linear Polynomial Coefficients

Find the Polynomial Coefficients of a Linear Bezier Curve.  
- [https://github.com/superlloyd/Poly](https://github.com/superlloyd/Poly)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B) LinearBezierCoefficientsGeneral(double a, double b)
        {
            Polynomial polynomial = RecursiveBezierCoefficientsTests.BezierCoefficientsRecursive(a, b);
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b]);
        }
```

### Linear Polynomial Coefficients

Find the Polynomial Coefficients of a Linear Bezier Curve.  
- [https://github.com/superlloyd/Poly](https://github.com/superlloyd/Poly)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B) LinearBezierCoefficientsRecursive(double a, double b)
        {
            Polynomial polynomial = (Polynomial.OneMinusT * a) + (Polynomial.T * b);
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b]);
        }
```

