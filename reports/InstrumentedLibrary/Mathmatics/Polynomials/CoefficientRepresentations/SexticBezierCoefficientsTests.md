# Sextic Polynomial Coefficients

Find the Polynomial Coefficients of a Sextic Bezier Curve.

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

../../InstrumentedLibrary/Mathmatics/Polynomials/CoefficientRepresentations/SexticBezierCoefficientsTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double A, double B, double C, double D, double E, double F, double G) SexticBezierCoefficients(double a, double b, double c, double d, double e, double f, double g)
```

## Test Case Index

- [Test Case: (1, 2, 3, 4, 5, 6, 7)](#1,-2,-3,-4,-5,-6,-7)

### (1, 2, 3, 4, 5, 6, 7)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [SexticBezierCoefficients0(1, 2, 3, 4, 5, 6, 7)](#Sextic-Polynomial-Coefficients) | (0, 0, 0, 0, 0, 6, 1) == (0, 0, 0, 0, 0, 6, 1) | 1000 in 2 ms. 0.002 ms. average | Dumb Polynomial test. |
| [SexticBezierCoefficientsGeneral(1, 2, 3, 4, 5, 6, 7)](#Sextic-Polynomial-Coefficients) | (0, 0, 0, 0, 0, 6, 1) == (0, 0, 0, 0, 0, 6, 1) | 1000 in 31 ms. 0.031 ms. average | Dumb Polynomial test. |
| [SexticBezierCoefficientsRecursive(1, 2, 3, 4, 5, 6, 7)](#Sextic-Polynomial-Coefficients) | (0, 0, 0, 0, 0, 6, 1) == (0, 0, 0, 0, 0, 6, 1) | 1000 in 1 ms. 0.001 ms. average | Dumb Polynomial test. |

## The Code

The code for the methods tested follows below.

### Sextic Polynomial Coefficients

Find the Polynomial Coefficients of a Sextic Bezier Curve.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F, double G) SexticBezierCoefficients0(double a, double b, double c, double d, double e, double f, double g)
        {
            return (g - (6d * f) + (15d * e) - (20d * d) + (15d * c) - (6d * b) + a,
                    (6d * f) - (30d * e) + (60d * d) - (60d * c) + (30d * b) - (6d * a),
                    (15d * e) - (60d * d) + (90d * c) - (60d * b) + (15d * a),
                    (20d * d) - (60d * c) + (60d * b) - (20d * a),
                    (15d * c) - (30d * b) + (15d * a),
                    (6d * b) - (6d * a),
                    a);
        }
```

### Sextic Polynomial Coefficients

Find the Polynomial Coefficients of a Sextic Bezier Curve.  
- [https://github.com/superlloyd/Poly](https://github.com/superlloyd/Poly)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F, double G) SexticBezierCoefficientsGeneral(double a, double b, double c, double d, double e, double f, double g)
        {
            Polynomial polynomial = RecursiveBezierCoefficientsTests.BezierCoefficientsRecursive(a, b, c, d, e, f, g);
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c], polynomial[PolynomialTerm.d], polynomial[PolynomialTerm.e], polynomial[PolynomialTerm.f], polynomial[PolynomialTerm.g]);
        }
```

### Sextic Polynomial Coefficients

Find the Polynomial Coefficients of a Sextic Bezier Curve.  
- [https://github.com/superlloyd/Poly](https://github.com/superlloyd/Poly)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F, double G) SexticBezierCoefficientsRecursive(double a, double b, double c, double d, double e, double f, double g)
        {
            Polynomial polynomial = (Polynomial.OneMinusT * QuinticBezierCoefficientsTests.QuinticBezierCoefficients(a, b, c, d, e, f)) + (Polynomial.T * QuinticBezierCoefficientsTests.QuinticBezierCoefficients(b, c, d, e, f, g));
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c], polynomial[PolynomialTerm.d], polynomial[PolynomialTerm.e], polynomial[PolynomialTerm.f], polynomial[PolynomialTerm.g]);
        }
```

