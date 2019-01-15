# Nonic Polynomial Coefficients

Find the Polynomial Coefficients of a Nonic Bezier Curve.

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

../../InstrumentedLibrary/Mathmatics/Polynomials/CoefficientRepresentations/NonicBezierCoefficientsTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double A, double B, double C, double D, double E, double F, double G, double H, double I, double J) NonicBezierCoefficients(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j)
```

## Test Case Index

- [Test Case: (1, 2, 3, 4, 5, 6, 7, 8, 9, 10)](#1,-2,-3,-4,-5,-6,-7,-8,-9,-10)

### (1, 2, 3, 4, 5, 6, 7, 8, 9, 10)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [NonicBezierCoefficients0(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)](#Nonic-Polynomial-Coefficients) | (0, 0, 0, 0, 0, 0, 0, 0, 9, 1) == (0, 0, 0, 0, 0, 0, 0, 0, 9, 1) | 1000 in 2 ms. 0.002 ms. average | Dumb Polynomial test. |
| [NonicBezierCoefficientsGeneral(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)](#Nonic-Polynomial-Coefficients) | (0, 0, 0, 0, 0, 0, 0, 0, 9, 1) == (0, 0, 0, 0, 0, 0, 0, 0, 9, 1) | 1000 in 263 ms. 0.263 ms. average | Dumb Polynomial test. |
| [NonicBezierCoefficientsRecursive(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)](#Nonic-Polynomial-Coefficients) | (0, 0, 0, 0, 0, 0, 0, 0, 9, 1) == (0, 0, 0, 0, 0, 0, 0, 0, 9, 1) | 1000 in 3 ms. 0.003 ms. average | Dumb Polynomial test. |

## The Code

The code for the methods tested follows below.

### Nonic Polynomial Coefficients

Find the Polynomial Coefficients of a Nonic Bezier Curve.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F, double G, double H, double I, double J) NonicBezierCoefficients0(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j)
        {
            return (j - (9d * i) + (36d * h) - (84d * g) + (126d * f) - (126d * e) + (84d * d) - (36d * c) + (9d * b) - a,
                    (9d * i) - (72d * h) + (252d * g) - (504d * f) + (630d * e) - (504d * d) + (252d * c) - (72d * b) + (9d * a),
                    (36d * h) - (252d * g) + (756d * f) - (1260d * e) + (1260d * d) - (756d * c) + (252 * b) - (36 * a),
                    (84d * g) - (504 * f) + (1260d * e) - (1680d * d) + (1260d * c) - (504d * b) + (84d * a),
                    (126d * f) - (630d * e) + (1260d * d) - (1260d * c) + (630d * b) - (126d * a),
                    (126d * e) - (504d * d) + (756d * c) - (504d * b) + (126d * a),
                    (84d * d) - (252d * c) + (252d * b) - (84d * a),
                    (36d * c) - (72d * b) + (36d * a),
                    (9d * b) - (9d * a),
                    a);
        }
```

### Nonic Polynomial Coefficients

Find the Polynomial Coefficients of a Nonic Bezier Curve.  
- [https://github.com/superlloyd/Poly](https://github.com/superlloyd/Poly)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F, double G, double H, double I, double J) NonicBezierCoefficientsGeneral(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j)
        {
            Polynomial polynomial = RecursiveBezierCoefficientsTests.BezierCoefficientsRecursive(a, b, c, d, e, f, g, h, i, j);
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c], polynomial[PolynomialTerm.d], polynomial[PolynomialTerm.e], polynomial[PolynomialTerm.f], polynomial[PolynomialTerm.g], polynomial[PolynomialTerm.h], polynomial[PolynomialTerm.i], polynomial[PolynomialTerm.j]);
        }
```

### Nonic Polynomial Coefficients

Find the Polynomial Coefficients of a Nonic Bezier Curve.  
- [https://github.com/superlloyd/Poly](https://github.com/superlloyd/Poly)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F, double G, double H, double I, double J) NonicBezierCoefficientsRecursive(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j)
        {
            Polynomial polynomial = (Polynomial.OneMinusT * OcticBezierCoefficientsTests.OcticBezierCoefficients(a, b, c, d, e, f, g, h, i)) + (Polynomial.T * OcticBezierCoefficientsTests.OcticBezierCoefficients(b, c, d, e, f, g, h, i, j));
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c], polynomial[PolynomialTerm.d], polynomial[PolynomialTerm.e], polynomial[PolynomialTerm.f], polynomial[PolynomialTerm.g], polynomial[PolynomialTerm.h], polynomial[PolynomialTerm.i], polynomial[PolynomialTerm.j]);
        }
```

