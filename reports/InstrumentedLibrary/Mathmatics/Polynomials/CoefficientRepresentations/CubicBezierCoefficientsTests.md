# Cubic Polynomial Coefficients

Find the Polynomial Coefficients of a Cubic Bezier Curve.

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

../../InstrumentedLibrary/Mathmatics/Polynomials/CoefficientRepresentations/CubicBezierCoefficientsTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double A, double B, double C, double D) CubicBezierCoefficients(double a, double b, double c, double d)
```

## Test Case Index

- [Test Case: (1, 2, 3, 4)](#1,-2,-3,-4)

### (1, 2, 3, 4)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [BezierCoefficients1(1, 2, 3, 4)](#Cubic-Polynomial-Coefficients) | (0, 0, 3, 1) == (0, 0, 3, 1) | 1000 in 1 ms. 0.001 ms. average | Dumb Polynomial test. |
| [CubicBezierCoefficients0(1, 2, 3, 4)](#Cubic-Polynomial-Coefficients) | (0, 0, 3, 1) == (0, 0, 3, 1) | 1000 in 1 ms. 0.001 ms. average | Dumb Polynomial test. |
| [CubicBezierCoefficientsGeneral(1, 2, 3, 4)](#Cubic-Polynomial-Coefficients) | (0, 0, 3, 1) == (0, 0, 3, 1) | 1000 in 4 ms. 0.004 ms. average | Dumb Polynomial test. |
| [CubicBezierCoefficientsRecursive(1, 2, 3, 4)](#Cubic-Polynomial-Coefficients) | (0, 0, 3, 1) == (0, 0, 3, 1) | 1000 in 1 ms. 0.001 ms. average | Dumb Polynomial test. |

## The Code

The code for the methods tested follows below.

### Cubic Polynomial Coefficients

Find the Polynomial Coefficients of a Cubic Bezier Curve.  
- [https://www.particleincell.com/2013/cubic-line-intersection/](https://www.particleincell.com/2013/cubic-line-intersection/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D) BezierCoefficients1(double a, double b, double c, double d)
            => (-a + (3d * b) + (-3d * c) + d,
                (3d * a) - (6d * b) + (3d * c),
                (-3d * a) + (3d * b),
                a);

        /// <summary>
        /// The cubic bezier coefficients.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <returns>The <see cref="Polynomial"/>.</returns>
        [DisplayName("Cubic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Cubic Bezier Curve.")]
        [Acknowledgment("https://github.com/superlloyd/Poly")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D) CubicBezierCoefficientsGeneral(double a, double b, double c, double d)
        {
            Polynomial polynomial = RecursiveBezierCoefficientsTests.BezierCoefficientsRecursive(a, b, c, d);
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c], polynomial[PolynomialTerm.d]);
        }
```

### Cubic Polynomial Coefficients

Find the Polynomial Coefficients of a Cubic Bezier Curve.  
- [http://www.gamedev.net/topic/643117-coefficients-for-bezier-curves/](http://www.gamedev.net/topic/643117-coefficients-for-bezier-curves/)
- [http://fontforge.github.io/bezier.html](http://fontforge.github.io/bezier.html)
- [http://idav.ucdavis.edu/education/CAGDNotes/Matrix-Cubic-Bezier-Curve/Matrix-Cubic-Bezier-Curve.html](http://idav.ucdavis.edu/education/CAGDNotes/Matrix-Cubic-Bezier-Curve/Matrix-Cubic-Bezier-Curve.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D) CubicBezierCoefficients0(double a, double b, double c, double d)
        {
            return (d - (3d * c) + (3d * b) - a,
                    (3d * c) - (6d * b) + (3d * a),
                    3d * (b - a),
                    a);
        }
```

### Cubic Polynomial Coefficients

Find the Polynomial Coefficients of a Cubic Bezier Curve.  
- [https://github.com/superlloyd/Poly](https://github.com/superlloyd/Poly)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D) CubicBezierCoefficientsGeneral(double a, double b, double c, double d)
        {
            Polynomial polynomial = RecursiveBezierCoefficientsTests.BezierCoefficientsRecursive(a, b, c, d);
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c], polynomial[PolynomialTerm.d]);
        }
```

### Cubic Polynomial Coefficients

Find the Polynomial Coefficients of a Cubic Bezier Curve.  
- [https://github.com/superlloyd/Poly](https://github.com/superlloyd/Poly)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D) CubicBezierCoefficientsRecursive(double a, double b, double c, double d)
        {
            Polynomial polynomial = (Polynomial.OneMinusT * QuadraticBezierCoefficientsTests.QuadraticBezierCoefficients(a, b, c)) + (Polynomial.T * QuadraticBezierCoefficientsTests.QuadraticBezierCoefficients(b, c, d));
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c], polynomial[PolynomialTerm.d]);
        }
```

