# Quintic Roots

Find the real roots of a Quintic polynomial.

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

../../InstrumentedLibrary/Mathmatics/Polynomials/Roots/QuinticRootsTests.cs

The required method signature for this API is as follows:

```CSharp
public static IList<double> QuinticRoots(double a, double b, double c, double d, double e, double f, double epsilon = Epsilon)
```

## Test Case Index

- [Test Case: (1, 2, 3, 4, 5, 6, 5.6843418860808E-12)](#1,-2,-3,-4,-5,-6,-5.6843418860808E-12)
- [Test Case: (6, 5, 4, 3, 2, 1, 5.6843418860808E-12)](#6,-5,-4,-3,-2,-1,-5.6843418860808E-12)

### (1, 2, 3, 4, 5, 6, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [QuinticRoots0(1, 2, 3, 4, 5, 6, 5.6843418860808E-12)](#Quintic-Roots) | List\<double\> {-0.6723782435877943, -3.234022892850585, -0.046799431780802481, -0.046799431780802481, 0, 0} != List\<double\> {-0.6723782435877943, -3.234022892850585, -0.046799431780810474, -0.046799431780810474, 0, 0} | 10000 in 153 ms. 0.0153 ms. average | Dumb Polynomial test. |

### (6, 5, 4, 3, 2, 1, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [QuinticRoots0(6, 5, 4, 3, 2, 1, 5.6843418860808E-12)](#Quintic-Roots) | List\<double\> {-1.6665418277880788, -1.6665418277880788, 0.1665418277880788, 0.1665418277880788, 0, 0} != List\<double\> {-1.6665418277880788, -1.6665418277880788, 0.16654182778807858, 0.16654182778807858, 0, 0} | 10000 in 116 ms. 0.0116 ms. average | Dumb Polynomial test. |

## The Code

The code for the methods tested follows below.

### Quintic Roots

Find real Quintic Roots.  
- [https://web.archive.org/web/20150504111126/http://abecedarical.com/javascript/script_quintic.html](https://web.archive.org/web/20150504111126/http://abecedarical.com/javascript/script_quintic.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IList<double> QuinticRoots0(double a, double b, double c, double d, double e, double f, double epsilon = Epsilon)
        {
            // If a is 0 the polynomial is quartic.
            if (a is 0d)
            {
                return QuarticRootsTests.QuarticRoots(b, c, d, e, f, epsilon);
            }

            var A = b / a;
            var B = c / a;
            var C = d / a;
            var D = e / a;
            var E = f / a;

            var coeff = new List<double> { a, b, c, d, e, f };

            var beta2 = 0d;
            var delta1 = 0d;
            var delta2 = 0d;
            var delta3 = 0d;

            // order
            var n = 4;// 5;
            var n1 = 5;// 6;
            var n2 = 6;// 7;

            var a_ = new List<double> { 0d, 0d, 0d, 0d, 0d, 0d };
            var b_ = new List<double> { 0d, 0d, 0d, 0d, 0d, 0d };
            var c_ = new List<double> { 0d, 0d, 0d, 0d, 0d, 0d };
            var d_ = new List<double> { 0d, 0d, 0d, 0d, 0d, 0d };
            var real = new List<double> { 0d, 0d, 0d, 0d, 0d, 0d };
            var imag = new List<double> { 0d, 0d, 0d, 0d, 0d, 0d };

            // is the coefficient of the highest term zero?
            if (Abs(coeff[0]) < epsilon)
            {
                return new List<double>();
            }

            //  copy into working array
            for (var i = 0; i <= n; i++)
            {
                a_[a_.Count - 1 - i] = coeff[i];
            }

            // initialize root counter
            var count = 0;

            // start the main Lin-Bairstow iteration loop
            do
            {
                // initialize the counter and guesses for the coefficients of quadratic factor: p(x) = x^2 + alfa1*x + beta1
                var alfa1 = Maths.Random(OneHalf, 1d);
                var alfa2 = 0d;
                var beta1 = Maths.Random(OneHalf, 1d);
                var limit = 1000;

                do
                {
                    b_[0] = 0d;
                    d_[0] = 0d;
                    b_[1] = 1d;
                    d_[1] = 1d;

                    for (int i = 2, j = 1, k = 0; i < a_.Count; i++)
                    {
                        b_[i] = a_[i] - (alfa1 * b_[j]) - (beta1 * b_[k]);
                        d_[i] = b_[i] - (alfa1 * d_[j]) - (beta1 * d_[k]);
                        j = j + 1;
                        k = k + 1;
                    }

                    {
                        var j = n - 1;
                        var k = n - 2;
                        delta1 = (d_[j] * d_[j]) - ((d_[n] - b_[n]) * d_[k]);
                        alfa2 = ((b_[n] * d_[j]) - (b_[n1] * d_[k])) / delta1;
                        beta2 = ((b_[n1] * d_[j]) - ((d_[n] - b_[n]) * b_[n])) / delta1;
                        alfa1 = alfa1 + alfa2;
                        beta1 = beta1 + beta2;
                    }

                    if (--limit < 0)
                    {
                        // cannot solve
                        return new List<double>();
                    }

                    if (Abs(alfa2) < epsilon && Abs(beta2) < epsilon)
                    {
                        break;
                    }
                }
                while (true);

                delta1 = (alfa1 * alfa1) - (4d * beta1);

                // imaginary roots
                if (delta1 < 0)
                {
                    delta2 = Sqrt(Abs(delta1)) * OneHalf;
                    delta3 = -alfa1 * OneHalf;

                    real[count] = delta3;
                    imag[count] = delta2;

                    real[count + 1] = delta3;
                    // sign is inverted on display
                    imag[count + 1] = delta2;
                }
                else
                {
                    // roots are real
                    delta2 = Sqrt(delta1);

                    real[count] = (delta2 - alfa1) * OneHalf;
                    imag[count] = 0;

                    real[count + 1] = (delta2 + alfa1) * -OneHalf;
                    imag[count + 1] = 0;
                }

                // update root counter
                count = count + 2;

                // reduce polynomial order
                n = n - 2;
                n1 = n1 - 2;
                n2 = n2 - 2;

                // for n >= 2 calculate coefficients of
                //  the new polynomial
                if (n >= 2)
                {
                    for (var i = 1; i <= n1; i++)
                    {
                        a_[i] = b_[i];
                    }
                }

                if (n < 2)
                {
                    break;
                }
            }
            while (true);

            if (n == 1)
            {
                // obtain last single real root
                real[count] = -b_[2];
                imag[count] = 0;
            }

            return real;
        }
```

