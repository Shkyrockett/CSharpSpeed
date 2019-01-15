# Decic Polynomial Coefficients

Find the Polynomial Coefficients of a Decic Bezier Curve.

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

../../InstrumentedLibrary/Mathmatics/Polynomials/CoefficientRepresentations/DecicBezierCoefficientsTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double A, double B, double C, double D, double E, double F, double G, double H, double I, double J, double K) DecicBezierCoefficients(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j, double k)
```

## Test Case Index

- [Test Case: (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11)](#1,-2,-3,-4,-5,-6,-7,-8,-9,-10,-11)

### (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [DecicBezierCoefficients0(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11)](#Decic-Polynomial-Coefficients) | (0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 1) == (0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 1) | 1000 in 2 ms. 0.002 ms. average | Dumb Polynomial test. |
| [DecicBezierCoefficientsGeneral0(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11)](#Decic-Polynomial-Coefficients) | (0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 1) == (0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 1) | 1000 in 670 ms. 0.67 ms. average | Dumb Polynomial test. |
| [DecicBezierCoefficientsRecursive(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11)](#Decic-Polynomial-Coefficients) | (0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 1) == (0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 1) | 1000 in 2 ms. 0.002 ms. average | Dumb Polynomial test. |

## The Code

The code for the methods tested follows below.

### Decic Polynomial Coefficients

Find the Polynomial Coefficients of a Decic Bezier Curve.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F, double G, double H, double I, double J, double K) DecicBezierCoefficients0(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j, double k)
        {
            return (k - (10 * j) + (45 * i) - (120 * h) + (210 * g) - (252 * f) + (210 * e) - (120 * d) + (45 * c) - (10 * b) + a,
                    (10 * j) - (90d * i) + (360d * h) - (840d * g) + (1260d * f) - (1260d * e) + (840d * d) - (360d * c) + (90d * b) - (10 * a),
                    (45d * i) - (360d * h) + (1260d * g) - (2520d * f) + (3150d * e) - (2520d * d) + (1260d * c) - (360d * b) + (45d * a),
                    (120d * h) - (840d * g) + (2520d * f) - (4200d * e) + (4200d * d) - (2520d * c) + (840d * b) - (120d * a),
                    (210d * g) - (1260d * f) + (3150d * e) - (4200d * d) + (3150d * c) - (1260d * b) + (210d * a),
                    (252d * f) - (1260d * e) + (2520d * d) - (2520d * c) + (1260d * b) - (252d * a),
                    (210d * e) - (840d * d) + (1260d * c) - (840d * b) + (210d * a),
                    (120d * d) - (360d * c) + (360d * b) - (120d * a),
                    (45d * c) - (90d * b) + (45d * a),
                    (10d * b) - (10d * a),
                    a);
        }
```

### Decic Polynomial Coefficients

Find the Polynomial Coefficients of a Decic Bezier Curve.  
- [https://github.com/superlloyd/Poly](https://github.com/superlloyd/Poly)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F, double G, double H, double I, double J, double K) DecicBezierCoefficientsGeneral0(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j, double k)
        {
            Polynomial polynomial = RecursiveBezierCoefficientsTests.BezierCoefficientsRecursive(a, b, c, d, e, f, g, h, i, j, k);
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c], polynomial[PolynomialTerm.d], polynomial[PolynomialTerm.e], polynomial[PolynomialTerm.f], polynomial[PolynomialTerm.g], polynomial[PolynomialTerm.h], polynomial[PolynomialTerm.i], polynomial[PolynomialTerm.j], polynomial[PolynomialTerm.k]);
        }
```

### Decic Polynomial Coefficients

Find the Polynomial Coefficients of a Decic Bezier Curve.  
- [https://github.com/superlloyd/Poly](https://github.com/superlloyd/Poly)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F, double G, double H, double I, double J, double K) DecicBezierCoefficientsRecursive(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j, double k)
        {
            Polynomial polynomial = (Polynomial.OneMinusT * NonicBezierCoefficientsTests.NonicBezierCoefficients(a, b, c, d, e, f, g, h, i, j)) + (Polynomial.T * NonicBezierCoefficientsTests.NonicBezierCoefficients(b, c, d, e, f, g, h, i, j, k));
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c], polynomial[PolynomialTerm.d], polynomial[PolynomialTerm.e], polynomial[PolynomialTerm.f], polynomial[PolynomialTerm.g], polynomial[PolynomialTerm.h], polynomial[PolynomialTerm.i], polynomial[PolynomialTerm.j], polynomial[PolynomialTerm.k]);
        }
```

