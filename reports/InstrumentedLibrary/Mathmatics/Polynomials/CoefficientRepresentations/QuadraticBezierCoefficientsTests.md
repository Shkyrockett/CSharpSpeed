# Quadratic Polynomial Coefficients

Find the Polynomial Coefficients of a Quadratic Bezier Curve.

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

../../InstrumentedLibrary/Mathmatics/Polynomials/CoefficientRepresentations/QuadraticBezierCoefficientsTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double A, double B, double C) QuadraticBezierCoefficients(double a, double b, double c)
```

## Test Case Index

- [Test Case: (1, 2, 3)](#1,-2,-3)

### (1, 2, 3)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [QuadraticBezierCoefficients0(1, 2, 3)](#Quadratic-Polynomial-Coefficients) | (0, 2, 1) == (0, 2, 1) | 1000 in 1 ms. 0.001 ms. average | Dumb Polynomial test. |
| [QuadraticBezierCoefficientsGeneral(1, 2, 3)](#Quadratic-Polynomial-Coefficients) | (0, 2, 1) == (0, 2, 1) | 1000 in 2 ms. 0.002 ms. average | Dumb Polynomial test. |
| [QuadraticBezierCoefficientsRecursive(1, 2, 3)](#Quadratic-Polynomial-Coefficients) | (0, 2, 1) == (0, 2, 1) | 1000 in 1 ms. 0.001 ms. average | Dumb Polynomial test. |

## The Code

The code for the methods tested follows below.

### Quadratic Polynomial Coefficients

Find the Polynomial Coefficients of a Quadratic Bezier Curve.  
- [http://fontforge.github.io/bezier.html](http://fontforge.github.io/bezier.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C) QuadraticBezierCoefficients0(double a, double b, double c)
        {
            return (c - (2d * b) + a,
                    2d * (b - a),
                    a);
        }
```

### Quadratic Polynomial Coefficients

Find the Polynomial Coefficients of a Quadratic Bezier Curve.  
- [http://fontforge.github.io/bezier.html](http://fontforge.github.io/bezier.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C) QuadraticBezierCoefficientsGeneral(double a, double b, double c)
        {
            Polynomial polynomial = RecursiveBezierCoefficientsTests.BezierCoefficientsRecursive(a, b, c);
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c]);
        }
```

### Quadratic Polynomial Coefficients

Find the Polynomial Coefficients of a Quadratic Bezier Curve.  
- [https://github.com/superlloyd/Poly](https://github.com/superlloyd/Poly)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C) QuadraticBezierCoefficientsRecursive(double a, double b, double c)
        {
            Polynomial polynomial = (Polynomial.OneMinusT * LinearBezierCoefficientsTests.LinearBezierCoefficients(a, b)) + (Polynomial.T * LinearBezierCoefficientsTests.LinearBezierCoefficients(b, c));
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c]);
        }
```

