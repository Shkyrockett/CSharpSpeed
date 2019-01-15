# Quartic Polynomial Coefficients

Find the Polynomial Coefficients of a Quartic Bezier Curve.

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

../../InstrumentedLibrary/Mathmatics/Polynomials/CoefficientRepresentations/QuarticBezierCoefficientsTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double A, double B, double C, double D, double E) QuarticBezierCoefficients(double a, double b, double c, double d, double e)
```

## Test Case Index

- [Test Case: (1, 2, 3, 4, 5)](#1,-2,-3,-4,-5)

### (1, 2, 3, 4, 5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [QuarticBezierCoefficients0(1, 2, 3, 4, 5)](#Quartic-Polynomial-Coefficients) | (0, 0, 0, 4, 1) == (0, 0, 0, 4, 1) | 1000 in 1 ms. 0.001 ms. average | Dumb Polynomial test. |
| [QuarticBezierCoefficientsGeneral(1, 2, 3, 4, 5)](#Quartic-Polynomial-Coefficients) | (0, 0, 0, 4, 1) == (0, 0, 0, 4, 1) | 1000 in 5 ms. 0.005 ms. average | Dumb Polynomial test. |
| [QuarticBezierCoefficientsRecursive(1, 2, 3, 4, 5)](#Quartic-Polynomial-Coefficients) | (0, 0, 0, 4, 1) == (0, 0, 0, 4, 1) | 1000 in 1 ms. 0.001 ms. average | Dumb Polynomial test. |

## The Code

The code for the methods tested follows below.

### Quartic Polynomial Coefficients

Find the Polynomial Coefficients of a Quartic Bezier Curve.  
- [http://www.dglr.de/publikationen/2016/420062.pdf](http://www.dglr.de/publikationen/2016/420062.pdf)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E) QuarticBezierCoefficients0(double a, double b, double c, double d, double e)
        {
            return (e - (4d * d) + (6d * c) - (4d * b) + a,
                    (4d * d) - (12d * c) + (12d * b) - (4d * a),
                    (6d * c) - (12d * b) + (6d * a),
                    4d * (b - a),
                    a);
        }
```

### Quartic Polynomial Coefficients

Find the Polynomial Coefficients of a Quartic Bezier Curve.  
- [https://github.com/superlloyd/Poly](https://github.com/superlloyd/Poly)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E) QuarticBezierCoefficientsGeneral(double a, double b, double c, double d, double e)
        {
            Polynomial polynomial = RecursiveBezierCoefficientsTests.BezierCoefficientsRecursive(a, b, c, d, e);
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c], polynomial[PolynomialTerm.d], polynomial[PolynomialTerm.e]);
        }
```

### Quartic Polynomial Coefficients

Find the Polynomial Coefficients of a Quartic Bezier Curve.  
- [https://github.com/superlloyd/Poly](https://github.com/superlloyd/Poly)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E) QuarticBezierCoefficientsRecursive(double a, double b, double c, double d, double e)
        {
            Polynomial polynomial = (Polynomial.OneMinusT * CubicBezierCoefficientsTests.CubicBezierCoefficients(a, b, c, d)) + (Polynomial.T * CubicBezierCoefficientsTests.CubicBezierCoefficients(b, c, d, e));
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c], polynomial[PolynomialTerm.d], polynomial[PolynomialTerm.e]);
        }
```

