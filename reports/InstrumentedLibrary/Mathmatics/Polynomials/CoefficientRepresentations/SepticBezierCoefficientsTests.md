# Septic Polynomial Coefficients

Find the Polynomial Coefficients of a Septic Bezier Curve.

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

../../InstrumentedLibrary/Mathmatics/Polynomials/CoefficientRepresentations/SepticBezierCoefficientsTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double A, double B, double C, double D, double E, double F, double G, double H) SepticBezierCoefficients(double a, double b, double c, double d, double e, double f, double g, double h)
```

## Test Case Index

- [Test Case: (1, 2, 3, 4, 5, 6, 7, 8)](#1,-2,-3,-4,-5,-6,-7,-8)

### (1, 2, 3, 4, 5, 6, 7, 8)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [SepticBezierCoefficients0(1, 2, 3, 4, 5, 6, 7, 8)](#Septic-Polynomial-Coefficients) | (0, 0, 0, 0, 0, 0, 7, 1) == (0, 0, 0, 0, 0, 0, 7, 1) | 1000 in 1 ms. 0.001 ms. average | Dumb Polynomial test. |
| [SepticBezierCoefficientsGeneral(1, 2, 3, 4, 5, 6, 7, 8)](#Septic-Polynomial-Coefficients) | (0, 0, 0, 0, 0, 0, 7, 1) == (0, 0, 0, 0, 0, 0, 7, 1) | 1000 in 77 ms. 0.077 ms. average | Dumb Polynomial test. |
| [SepticBezierCoefficientsRecursive(1, 2, 3, 4, 5, 6, 7, 8)](#Septic-Polynomial-Coefficients) | (0, 0, 0, 0, 0, 0, 7, 1) == (0, 0, 0, 0, 0, 0, 7, 1) | 1000 in 4 ms. 0.004 ms. average | Dumb Polynomial test. |

## The Code

The code for the methods tested follows below.

### Septic Polynomial Coefficients

Find the Polynomial Coefficients of a Septic Bezier Curve.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F, double G, double H) SepticBezierCoefficients0(double a, double b, double c, double d, double e, double f, double g, double h)
        {
            return (h - (7d * g) + (21d * f) - (35d * e) + (35d * d) - (21d * c) + (7d * b) - a,
                    (7d * g) - (42d * f) + (105d * e) - (140d * d) + (105d * c) - (42d * b) + (7d * a),
                    (21d * f) - (105d * e) + (210d * d) - (210d * c) + (105d * b) - (21d * a),
                    (35d * e) - (140d * d) + (210d * c) - (140d * b) + (35d * a),
                    (35d * d) - (105d * c) + (105d * b) - (35d * a),
                    (21d * c) - (42d * b) + (21d * a),
                    (7d * b) - (7d * a),
                    a);
        }
```

### Septic Polynomial Coefficients

Find the Polynomial Coefficients of a Septic Bezier Curve.  
- [https://github.com/superlloyd/Poly](https://github.com/superlloyd/Poly)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F, double G, double H) SepticBezierCoefficientsGeneral(double a, double b, double c, double d, double e, double f, double g, double h)
        {
            Polynomial polynomial = RecursiveBezierCoefficientsTests.BezierCoefficientsRecursive(a, b, c, d, e, f, g, h);
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c], polynomial[PolynomialTerm.d], polynomial[PolynomialTerm.e], polynomial[PolynomialTerm.f], polynomial[PolynomialTerm.g], polynomial[PolynomialTerm.h]);
        }
```

### Septic Polynomial Coefficients

Find the Polynomial Coefficients of a Septic Bezier Curve.  
- [https://github.com/superlloyd/Poly](https://github.com/superlloyd/Poly)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F, double G, double H) SepticBezierCoefficientsRecursive(double a, double b, double c, double d, double e, double f, double g, double h)
        {
            Polynomial polynomial = (Polynomial.OneMinusT * SexticBezierCoefficientsTests.SexticBezierCoefficients(a, b, c, d, e, f, g)) + (Polynomial.T * SexticBezierCoefficientsTests.SexticBezierCoefficients(b, c, d, e, f, g, h));
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c], polynomial[PolynomialTerm.d], polynomial[PolynomialTerm.e], polynomial[PolynomialTerm.f], polynomial[PolynomialTerm.g], polynomial[PolynomialTerm.h]);
        }
```

