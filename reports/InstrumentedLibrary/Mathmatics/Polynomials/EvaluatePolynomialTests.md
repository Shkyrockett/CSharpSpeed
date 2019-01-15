# Evaluate Polynomial Tests

Evaluate a Polynomial.

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

../../InstrumentedLibrary/Mathmatics/Polynomials/EvaluatePolynomialTests.cs

The required method signature for this API is as follows:

```CSharp
public static double Evaluate(double[] coefficients, double x)
```

## Test Case Index

- [Test Case: (System.Double[], 0.5)](#System.Double[],-0.5)

### (System.Double[], 0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Compute(System.Double[], 0.5)](#Evaluate-Polynomial-Tests) | 150 != Quadratic | 10000 in 13 ms. 0.0013 ms. average |  |
| [Evaluate0(System.Double[], 0.5)](#Evaluate-Polynomial-Tests) | 150 != Quadratic | 10000 in 12 ms. 0.0012 ms. average |  |
| [Horner(System.Double[], 0.5)](#Evaluate-Polynomial-Tests) | 150 != Quadratic | 10000 in 21 ms. 0.0021 ms. average |  |

## The Code

The code for the methods tested follows below.

### Evaluate Polynomial Tests

Evaluate a Polynomial.  
- [https://github.com/superlloyd/Poly](https://github.com/superlloyd/Poly)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Compute(double[] coefficients, double x)
        {
            if (double.IsNaN(x))
            {
                throw new ArithmeticException($"{nameof(Compute)}: parameter {nameof(x)} must be a number");
            }

            var degree = coefficients.Length - 1;
            var result = 0d;
            var ncoef = 1d;
            for (var i = 0; i <= degree; i++)
            {
                result += coefficients[i] * ncoef;
                ncoef *= x;
            }

            return result;
        }
```

### Evaluate Polynomial Tests

Evaluate a Polynomial.  
- [https://en.wikipedia.org/wiki/Horner%27s_method](https://en.wikipedia.org/wiki/Horner%27s_method)
- [https://github.com/thelonious/kld-polynomial](https://github.com/thelonious/kld-polynomial)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Evaluate0(double[] coefficients, double x)
        {
            if (double.IsNaN(x))
            {
                throw new ArithmeticException($"{nameof(Evaluate)}: parameter {nameof(x)} must be a number");
            }

            var degree = coefficients.Length - 1;
            var result = 0d;

            for (var i = degree; i >= 0; i--)
            {
                result = result * x + coefficients[i];
            }

            return result;
        }
```

### Evaluate Polynomial Tests

Evaluate a Polynomial.  
- [http://rosettacode.org/wiki/Horner%27s_rule_for_polynomial_evaluation](http://rosettacode.org/wiki/Horner%27s_rule_for_polynomial_evaluation)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Horner(double[] coefficients, double x)
        {
            if (double.IsNaN(x))
            {
                throw new ArithmeticException($"{nameof(Horner)}: parameter {nameof(x)} must be a number");
            }

            return coefficients.Reverse().Aggregate(
                    (accumulator, coefficient) => accumulator * x + coefficient);
        }
```

