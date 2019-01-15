# Quintic Polynomial Coefficients

Find the Polynomial Coefficients of a Quintic Bezier Curve.

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

../../InstrumentedLibrary/Mathmatics/Polynomials/CoefficientRepresentations/QuinticBezierCoefficientsTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double A, double B, double C, double D, double E, double F) QuinticBezierCoefficients(double a, double b, double c, double d, double e, double f)
```

## Test Case Index

- [Test Case: (1, 2, 3, 4, 5, 6)](#1,-2,-3,-4,-5,-6)

### (1, 2, 3, 4, 5, 6)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [QuinticBezierCoefficients0(1, 2, 3, 4, 5, 6)](#Quintic-Polynomial-Coefficients) | (0, 0, 0, 0, 5, 1) == (0, 0, 0, 0, 5, 1) | 1000 in 0 ms. 0 ms. average | Dumb Polynomial test. |
| [QuinticBezierCoefficientsGeneral(1, 2, 3, 4, 5, 6)](#Quintic-Polynomial-Coefficients) | (0, 0, 0, 0, 5, 1) == (0, 0, 0, 0, 5, 1) | 1000 in 20 ms. 0.02 ms. average | Dumb Polynomial test. |
| [QuinticBezierCoefficientsRecursive(1, 2, 3, 4, 5, 6)](#Quintic-Polynomial-Coefficients) | (0, 0, 0, 0, 5, 1) == (0, 0, 0, 0, 5, 1) | 1000 in 1 ms. 0.001 ms. average | Dumb Polynomial test. |

## The Code

The code for the methods tested follows below.

### Quintic Polynomial Coefficients

Find the Polynomial Coefficients of a Quintic Bezier Curve.  
- [https://simtk.org/api_docs/opensim/api_docs/classOpenSim_1_1SegmentedQuinticBezierToolkit.html](https://simtk.org/api_docs/opensim/api_docs/classOpenSim_1_1SegmentedQuinticBezierToolkit.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F) QuinticBezierCoefficients0(double a, double b, double c, double d, double e, double f)
        {
            return (f - (5d * e) + (10d * d) - (10d * c) + (5d * b) - a,
                    (5d * e) - (20d * d) + (30d * c) - (20d * b) + (5d * a),
                    (10d * d) - (30d * c) + (30d * b) - (10d * a),
                    (10d * c) - (20d * b) + (10d * a),
                    5d * (b - a),
                    a);
        }
```

### Quintic Polynomial Coefficients

Find the Polynomial Coefficients of a Quintic Bezier Curve.  
- [https://github.com/superlloyd/Poly](https://github.com/superlloyd/Poly)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F) QuinticBezierCoefficientsGeneral(double a, double b, double c, double d, double e, double f)
        {
            Polynomial polynomial = RecursiveBezierCoefficientsTests.BezierCoefficientsRecursive(a, b, c, d, e, f);
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c], polynomial[PolynomialTerm.d], polynomial[PolynomialTerm.e], polynomial[PolynomialTerm.f]);
        }
```

### Quintic Polynomial Coefficients

Find the Polynomial Coefficients of a Quintic Bezier Curve.  
- [https://github.com/superlloyd/Poly](https://github.com/superlloyd/Poly)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F) QuinticBezierCoefficientsRecursive(double a, double b, double c, double d, double e, double f)
        {
            Polynomial polynomial = (Polynomial.OneMinusT * QuarticBezierCoefficientsTests.QuarticBezierCoefficients(a, b, c, d, e)) + (Polynomial.T * QuarticBezierCoefficientsTests.QuarticBezierCoefficients(b, c, d, e, f));
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c], polynomial[PolynomialTerm.d], polynomial[PolynomialTerm.e], polynomial[PolynomialTerm.f]);
        }
```

