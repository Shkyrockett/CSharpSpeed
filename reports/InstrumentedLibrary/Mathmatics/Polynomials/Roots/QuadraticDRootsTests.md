# Quadratic D Roots

Find the real D roots of a Quadratic polynomial.

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

../../InstrumentedLibrary/Mathmatics/Polynomials/Roots/QuadraticDRootsTests.cs

The required method signature for this API is as follows:

```CSharp
public static IList<double> QuadraticDRoots(double a, double b, double c, double epsilon = Epsilon)
```

## Test Case Index

- [Test Case: (-2, 2, 12, 5.6843418860808E-12)](#-2,-2,-12,-5.6843418860808E-12)
- [Test Case: (1, 2, 1, 5.6843418860808E-12)](#1,-2,-1,-5.6843418860808E-12)
- [Test Case: (3, 9, 6, 5.6843418860808E-12)](#3,-9,-6,-5.6843418860808E-12)
- [Test Case: (-4, 16, 19, 5.6843418860808E-12)](#-4,-16,-19,-5.6843418860808E-12)
- [Test Case: (1, 2, 1, 5.6843418860808E-12)](#1,-2,-1,-5.6843418860808E-12)
- [Test Case: (3, 6, 5, 5.6843418860808E-12)](#3,-6,-5,-5.6843418860808E-12)

### (-2, 2, 12, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [QuadraticDRootsPoMax(-2, 2, 12, 5.6843418860808E-12)](#Quadratic-Roots-PoMax) | List\<double\> {0.21525043702153024, -1.5485837703548635} != List\<double\> {3, -2} | 10000 in 21 ms. 0.0021 ms. average | A test to find the roots of the Polynomial: -2x² + 2x + 12 |

### (1, 2, 1, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [QuadraticDRootsPoMax(1, 2, 1, 5.6843418860808E-12)](#Quadratic-Roots-PoMax) | List\<double\> {-0.3660254037844386, 1.3660254037844386} != List\<double\> {-1} | 10000 in 15 ms. 0.0015 ms. average | A test to find the roots of the Polynomial: x² + 2x + 1 |

### (3, 9, 6, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [QuadraticDRootsPoMax(3, 9, 6, 5.6843418860808E-12)](#Quadratic-Roots-PoMax) | List\<double\> {-0.21525043702153024, 1.5485837703548637} != List\<double\> {-1, -2} | 10000 in 14 ms. 0.0014 ms. average | A test to find the roots of the Polynomial: 3x² + 9x + 6 |

### (-4, 16, 19, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [QuadraticDRootsPoMax(-4, 16, 19, 5.6843418860808E-12)](#Quadratic-Roots-PoMax) | List\<double\> {0.10465487304184716, 2.248286303428741} != List\<double\> {4.9580398915498076, -0.95803989154980806} | 10000 in 19 ms. 0.0019 ms. average | A test to find the roots of the Polynomial: -4x² + 16x, 19 |

### (1, 2, 1, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [QuadraticDRootsPoMax(1, 2, 1, 5.6843418860808E-12)](#Quadratic-Roots-PoMax) | List\<double\> {-0.3660254037844386, 1.3660254037844386} != List\<double\> {-1} | 10000 in 15 ms. 0.0015 ms. average | A test to find the roots of the Polynomial: x² + 2x + 1 |

### (3, 6, 5, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [QuadraticDRootsPoMax(3, 6, 5, 5.6843418860808E-12)](#Quadratic-Roots-PoMax) | List\<double\> {-0.39564392373895996, 1.89564392373896} != List\<double\> {} | 10000 in 22 ms. 0.0022 ms. average | A test to find the roots of the Polynomial: 3x² + 6x + 5 |

## The Code

The code for the methods tested follows below.

### Quadratic Roots PoMax

Find real Quadratic Roots.  
- [http://pomax.github.io/bezierinfo](http://pomax.github.io/bezierinfo)
- [https://github.com/Pomax/bezierjs/blob/gh-pages/lib/utils.js](https://github.com/Pomax/bezierjs/blob/gh-pages/lib/utils.js)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IList<double> QuadraticDRootsPoMax(double a, double b, double c, double epsilon = Epsilon)
        {
            // If a is 0 the polynomial is linear.
            if (a is 0d)
            {
                return LinearRootsTests.LinearRoots(b, c, epsilon);
            }

            var d = a - (2d * b) + c;
            if (d != 0)
            {
                // The 4 is missing?
                var m1 = -Sqrt((b * b) - (a * c));
                var m2 = -a + b;
                var v1 = -(m1 + m2) / d;
                var v2 = -(-m1 + m2) / d;
                return new List<double> { v1, v2 };
            }
            else if (b != c && d == 0d)
            {
                return new List<double> { ((2d * b) - c) / (2d * (b - c)) };
            }

            return new List<double>();
        }
```

