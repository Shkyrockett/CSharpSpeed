# Octic Polynomial Coefficients

Find the Polynomial Coefficients of a Octic Bezier Curve.

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

../../InstrumentedLibrary/Mathmatics/Polynomials/CoefficientRepresentations/OcticBezierCoefficientsTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double A, double B, double C, double D, double E, double F, double G, double H, double I) OcticBezierCoefficients(double a, double b, double c, double d, double e, double f, double g, double h, double i)
```

## Test Case Index

- [Test Case: (1, 2, 3, 4, 5, 6, 7, 8, 9)](#1,-2,-3,-4,-5,-6,-7,-8,-9)

### (1, 2, 3, 4, 5, 6, 7, 8, 9)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [OcticBezierCoefficients0(1, 2, 3, 4, 5, 6, 7, 8, 9)](#Octic-Polynomial-Coefficients) | (0, 0, 0, 0, 0, 0, 0, 8, 1) == (0, 0, 0, 0, 0, 0, 0, 8, 1) | 1000 in 1 ms. 0.001 ms. average | Dumb Polynomial test. |
| [OcticBezierCoefficientsGeneral(1, 2, 3, 4, 5, 6, 7, 8, 9)](#Octic-Polynomial-Coefficients) | (0, 0, 0, 0, 0, 0, 0, 8, 1) == (0, 0, 0, 0, 0, 0, 0, 8, 1) | 1000 in 113 ms. 0.113 ms. average | Dumb Polynomial test. |
| [OcticBezierCoefficientsRecursive(1, 2, 3, 4, 5, 6, 7, 8, 9)](#Octic-Polynomial-Coefficients) | (0, 0, 0, 0, 0, 0, 0, 8, 1) == (0, 0, 0, 0, 0, 0, 0, 8, 1) | 1000 in 2 ms. 0.002 ms. average | Dumb Polynomial test. |

## The Code

The code for the methods tested follows below.

### Octic Polynomial Coefficients

Find the Polynomial Coefficients of a Octic Bezier Curve.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F, double G, double H, double I) OcticBezierCoefficients0(double a, double b, double c, double d, double e, double f, double g, double h, double i)
        {
            return (i - (8d * h) + (28d * g) - (56d * f) + (70d * e) - (56d * d) + (28d * c) - (8d * b) + a,
                    (8d * h) - (56d * g) + (168d * f) - (280d * e) + (280d * d) - (168d * c) + (56d * b) - (8d * a),
                    (28d * g) - (168d * f) + (420d * e) - (560d * d) + (420d * c) - (168d * b) + (28d * a),
                    (56d * f) - (280d * e) + (560d * d) - (560d * c) + (280d * b) - (56d * a),
                    (70d * e) - (280d * d) + (420d * c) - (280d * b) + (70d * a),
                    (56d * d) - (168d * c) + (168d * b) - (56d * a),
                    (28d * c) - (56d * b) + (28d * a),
                    (8d * b) - (8d * a),
                    a);
        }
```

### Octic Polynomial Coefficients

Find the Polynomial Coefficients of a Octic Bezier Curve.  
- [https://github.com/superlloyd/Poly](https://github.com/superlloyd/Poly)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F, double G, double H, double I) OcticBezierCoefficientsGeneral(double a, double b, double c, double d, double e, double f, double g, double h, double i)
        {
            Polynomial polynomial = RecursiveBezierCoefficientsTests.BezierCoefficientsRecursive(a, b, c, d, e, f, g, h, i);
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c], polynomial[PolynomialTerm.d], polynomial[PolynomialTerm.e], polynomial[PolynomialTerm.f], polynomial[PolynomialTerm.g], polynomial[PolynomialTerm.h], polynomial[PolynomialTerm.i]);
        }
```

### Octic Polynomial Coefficients

Find the Polynomial Coefficients of a Octic Bezier Curve.  
- [https://github.com/superlloyd/Poly](https://github.com/superlloyd/Poly)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F, double G, double H, double I) OcticBezierCoefficientsRecursive(double a, double b, double c, double d, double e, double f, double g, double h, double i)
        {
            Polynomial polynomial = (Polynomial.OneMinusT * SepticBezierCoefficientsTests.SepticBezierCoefficients(a, b, c, d, e, f, g, h)) + (Polynomial.T * SepticBezierCoefficientsTests.SepticBezierCoefficients(b, c, d, e, f, g, h, i));
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c], polynomial[PolynomialTerm.d], polynomial[PolynomialTerm.e], polynomial[PolynomialTerm.f], polynomial[PolynomialTerm.g], polynomial[PolynomialTerm.h], polynomial[PolynomialTerm.i]);
        }
```

