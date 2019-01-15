# Linear Roots

Find the real roots of a Linear polynomial.

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

../../InstrumentedLibrary/Mathmatics/Polynomials/Roots/LinearRootsTests.cs

The required method signature for this API is as follows:

```CSharp
public static IList<double> LinearRoots(double a, double b, double epsilon = Epsilon)
```

## Test Case Index

- [Test Case: (1, 2, 5.6843418860808E-12)](#1,-2,-5.6843418860808E-12)
- [Test Case: (2, 1, 5.6843418860808E-12)](#2,-1,-5.6843418860808E-12)

### (1, 2, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [LinearRoots0(1, 2, 5.6843418860808E-12)](#Linear-Roots) | List\<double\> {-2} == List\<double\> {-2} | 10000 in 21 ms. 0.0021 ms. average | Dumb Polynomial test. |

### (2, 1, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [LinearRoots0(2, 1, 5.6843418860808E-12)](#Linear-Roots) | List\<double\> {-0.5} == List\<double\> {-0.5} | 10000 in 19 ms. 0.0019 ms. average | Dumb Polynomial test. |

## The Code

The code for the methods tested follows below.

### Linear Roots

Find real Linear Roots.  
- [http://www.kevlindev.com/geometry/2D/intersections/](http://www.kevlindev.com/geometry/2D/intersections/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IList<double> LinearRoots0(double a, double b, double epsilon = Epsilon)
        {
            // If a is 0 the polynomial is a constant expression.
            if (a is 0d)
            {
                return new List<double> { b };
            }

            var result = new HashSet<double>();
            if (!(Abs(a) <= epsilon))
            {
                result.Add(-b / a);
            }

            return result.ToList();
        }
```

