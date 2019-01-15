# Linear D Roots

Find the real D roots of a Linear polynomial.

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

../../InstrumentedLibrary/Mathmatics/Polynomials/Roots/LinearDRootsTests.cs

The required method signature for this API is as follows:

```CSharp
public static List<double> LinearDRoots(double a, double b, double epsilon = Epsilon)
```

## Test Case Index

- [Test Case: (1, 2, 5.6843418860808E-12)](#1,-2,-5.6843418860808E-12)
- [Test Case: (2, 1, 5.6843418860808E-12)](#2,-1,-5.6843418860808E-12)

### (1, 2, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [LinearDRoots0(1, 2, 5.6843418860808E-12)](#Linear-D-Roots) | double\[\] {-1} != List\<double\> {-2} | 10000 in 14 ms. 0.0014 ms. average | Dumb Polynomial test. |
| [LinearDRootsPoMax(1, 2, 5.6843418860808E-12)](#Linear-D-Roots) | List\<double\> {-1} != List\<double\> {-2} | 10000 in 27 ms. 0.0027 ms. average | Dumb Polynomial test. |

### (2, 1, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [LinearDRoots0(2, 1, 5.6843418860808E-12)](#Linear-D-Roots) | double\[\] {2} != List\<double\> {-0.5} | 10000 in 13 ms. 0.0013 ms. average | Dumb Polynomial test. |
| [LinearDRootsPoMax(2, 1, 5.6843418860808E-12)](#Linear-D-Roots) | List\<double\> {2} != List\<double\> {-0.5} | 10000 in 22 ms. 0.0022 ms. average | Dumb Polynomial test. |

## The Code

The code for the methods tested follows below.

### Linear D Roots

Find real Linear D Roots.  
- [http://pomax.github.io/bezierinfo/](http://pomax.github.io/bezierinfo/)
- [https://github.com/Pomax/bezierjs/blob/gh-pages/lib/utils.js](https://github.com/Pomax/bezierjs/blob/gh-pages/lib/utils.js)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IList<double> LinearDRoots0(double a, double b, double epsilon = Epsilon)
        {
            return a != b ? (new double[] { a / (a - b) }) : (new double[] { });
        }
```

### Linear D Roots

Find real Linear D Roots.  
- [http://pomax.github.io/bezierinfo](http://pomax.github.io/bezierinfo)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<double> LinearDRootsPoMax(double a, double b, double epsilon = Epsilon)
        {
            if (a != b)
            {
                return new List<double> { a / (a - b) };
            }

            return new List<double>();
        }
```

