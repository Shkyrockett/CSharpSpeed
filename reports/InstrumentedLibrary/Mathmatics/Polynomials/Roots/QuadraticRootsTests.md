# Quadratic Roots

Find the real roots of a Quadratic polynomial.

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

../../InstrumentedLibrary/Mathmatics/Polynomials/Roots/QuadraticRootsTests.cs

The required method signature for this API is as follows:

```CSharp
public static IList<double> QuadraticRoots(double a, double b, double c, double epsilon = Epsilon)
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
| [QuadraticEquation(-2, 2, 12, 5.6843418860808E-12)](#Quadratic-Equation) | List\<double\> {3, -2} == List\<double\> {3, -2} | 10000 in 35 ms. 0.0035 ms. average | A test to find the roots of the Polynomial: -2x² + 2x + 12 |
| [QuadraticRootsKevinLinDev(-2, 2, 12, 5.6843418860808E-12)](#Quadratic-Roots-Kevin-Lin-Dev) | List\<double\> {3, -2} == List\<double\> {3, -2} | 10000 in 15 ms. 0.0015 ms. average | A test to find the roots of the Polynomial: -2x² + 2x + 12 |

### (1, 2, 1, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [QuadraticEquation(1, 2, 1, 5.6843418860808E-12)](#Quadratic-Equation) | List\<double\> {-1, -1} != List\<double\> {-1} | 10000 in 29 ms. 0.0029 ms. average | A test to find the roots of the Polynomial: x² + 2x + 1 |
| [QuadraticRootsKevinLinDev(1, 2, 1, 5.6843418860808E-12)](#Quadratic-Roots-Kevin-Lin-Dev) | List\<double\> {-1} == List\<double\> {-1} | 10000 in 24 ms. 0.0024 ms. average | A test to find the roots of the Polynomial: x² + 2x + 1 |

### (3, 9, 6, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [QuadraticEquation(3, 9, 6, 5.6843418860808E-12)](#Quadratic-Equation) | List\<double\> {-2, -1} != List\<double\> {-1, -2} | 10000 in 22 ms. 0.0022 ms. average | A test to find the roots of the Polynomial: 3x² + 9x + 6 |
| [QuadraticRootsKevinLinDev(3, 9, 6, 5.6843418860808E-12)](#Quadratic-Roots-Kevin-Lin-Dev) | List\<double\> {-1, -2} == List\<double\> {-1, -2} | 10000 in 23 ms. 0.0023 ms. average | A test to find the roots of the Polynomial: 3x² + 9x + 6 |

### (-4, 16, 19, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [QuadraticEquation(-4, 16, 19, 5.6843418860808E-12)](#Quadratic-Equation) | List\<double\> {4.9580398915498076, -0.95803989154980806} == List\<double\> {4.9580398915498076, -0.95803989154980806} | 10000 in 29 ms. 0.0029 ms. average | A test to find the roots of the Polynomial: -4x² + 16x, 19 |
| [QuadraticRootsKevinLinDev(-4, 16, 19, 5.6843418860808E-12)](#Quadratic-Roots-Kevin-Lin-Dev) | List\<double\> {4.9580398915498076, -0.95803989154980806} == List\<double\> {4.9580398915498076, -0.95803989154980806} | 10000 in 19 ms. 0.0019 ms. average | A test to find the roots of the Polynomial: -4x² + 16x, 19 |

### (1, 2, 1, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [QuadraticEquation(1, 2, 1, 5.6843418860808E-12)](#Quadratic-Equation) | List\<double\> {-1, -1} != List\<double\> {-1} | 10000 in 21 ms. 0.0021 ms. average | A test to find the roots of the Polynomial: x² + 2x + 1 |
| [QuadraticRootsKevinLinDev(1, 2, 1, 5.6843418860808E-12)](#Quadratic-Roots-Kevin-Lin-Dev) | List\<double\> {-1} == List\<double\> {-1} | 10000 in 19 ms. 0.0019 ms. average | A test to find the roots of the Polynomial: x² + 2x + 1 |

### (3, 6, 5, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [QuadraticEquation(3, 6, 5, 5.6843418860808E-12)](#Quadratic-Equation) | List\<double\> {NaN, NaN} != List\<double\> {} | 10000 in 15 ms. 0.0015 ms. average | A test to find the roots of the Polynomial: 3x² + 6x + 5 |
| [QuadraticRootsKevinLinDev(3, 6, 5, 5.6843418860808E-12)](#Quadratic-Roots-Kevin-Lin-Dev) | List\<double\> {} == List\<double\> {} | 10000 in 17 ms. 0.0017 ms. average | A test to find the roots of the Polynomial: 3x² + 6x + 5 |

## The Code

The code for the methods tested follows below.

### Quadratic Equation

Quadratic Equation.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IList<double> QuadraticEquation(double a, double b, double c, double epsilon = Epsilon)
        {
            // If a is 0 the polynomial is linear.
            if (a is 0d)
            {
                return LinearRootsTests.LinearRoots(b, c, epsilon);
            }

            return new List<double>{
                (-b - Sqrt((b * b) - (4d * a * c))) / (2d * a),
                (-b + Sqrt((b * b) - (4d * a * c))) / (2d * a),
            };
        }
```

### Quadratic Roots Kevin Lin Dev

Find real Quadratic Roots.  
- [http://www.kevlindev.com/geometry/2D/intersections/](http://www.kevlindev.com/geometry/2D/intersections/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IList<double> QuadraticRootsKevinLinDev(double a, double b, double c, double epsilon = Epsilon)
        {
            // If a is 0 the polynomial is linear.
            if (a is 0d)
            {
                return LinearRootsTests.LinearRoots(b, c, epsilon);
            }

            var b_ = b / a;
            var c_ = c / a;

            // Polynomial discriminant.
            var discriminant = (b_ * b_) - (4d * c_);
            if (Abs(discriminant) <= epsilon)
            {
                discriminant = 0d;
            }

            // ToDo: May need to switch from a hash set to a list for scan-beams.
            var results = new HashSet<double>();
            if (discriminant > 0d)
            {
                // Complex or duplicate roots.
                var e = Sqrt(discriminant);
                results.Add(OneHalf * (-b_ + e));
                results.Add(OneHalf * (-b_ - e));
            }
            else if (discriminant == 0)
            {
                // There should actually be two roots with same value, but we will only return one.
                results.Add(OneHalf * -b_);
            }

            return results.ToList();
        }
```

