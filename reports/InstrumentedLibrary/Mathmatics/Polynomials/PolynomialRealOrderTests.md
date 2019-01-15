# Real Order of Polynomial

Find the real order of a polynomial.

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

../../InstrumentedLibrary/Mathmatics/Polynomials/PolynomialRealOrderTests.cs

The required method signature for this API is as follows:

```CSharp
public static PolynomialDegree RealOrder(double[] coefficients, double epsilon = Epsilon)
```

## Test Case Index

- [Test Case: (System.Double[], 5.6843418860808E-12)](#System.Double[],-5.6843418860808E-12)

### (System.Double[], 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [RealOrder0(System.Double[], 5.6843418860808E-12)](#Real-Order-of-Polynomial) | Quadratic == Quadratic | 10000 in 31 ms. 0.0031 ms. average | 3d, 4d, 5d. |
| [RealOrderSuperLloyd(System.Double[], 5.6843418860808E-12)](#Real-Order-of-Polynomial-Super-Lloyd) | Quadratic == Quadratic | 10000 in 30 ms. 0.003 ms. average | 3d, 4d, 5d. |

## The Code

The code for the methods tested follows below.

### Real Order of Polynomial

Find the real order of a polynomial.  
- [http://www.kevlindev.com/](http://www.kevlindev.com/)
- [https://github.com/superlloyd/Poly](https://github.com/superlloyd/Poly)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PolynomialDegree RealOrder0(double[] coefficients, double epsilon = Epsilon)
        {
            var pos = 1;
            var count = coefficients.Length;

            // Monomial can be a zero constant, skip them and check the rest.
            if (count > 1)
            {
                // Count the number of leading zeros. Because the coefficients array is reversed, start at the end.
                for (var i = count - 1; i >= 1 /* Monomials can be 0. */; i--)
                {
                    // Check if coefficient is a leading zero.
                    if (Abs(coefficients[i]) <= epsilon)
                    {
                        pos++;
                    }
                    else
                    {
                        // Break early if a non zero value was found. This indicates the end of any leading zeros.
                        break;
                    }
                }
            }

            return (PolynomialDegree)(coefficients?.Length - pos ?? 0);
        }
```

### Real Order of Polynomial Super Lloyd

Find the real order of a polynomial.  
- [https://github.com/superlloyd/Poly](https://github.com/superlloyd/Poly)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PolynomialDegree RealOrderSuperLloyd(double[] coefficients, double epsilon = Epsilon)
        {
            if (coefficients is null)
            {
                return PolynomialDegree.Empty;
            }

            var order = 0;
            for (var i = 0; i < coefficients.Length; i++)
            {
                if (Abs(coefficients[i]) > epsilon)
                {
                    order = i;
                }
            }

            return (PolynomialDegree)order;
        }
```

