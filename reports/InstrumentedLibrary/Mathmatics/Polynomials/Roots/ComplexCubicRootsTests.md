# Complex Cubic Roots

Find the Complex roots of a Cubic polynomial.

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

../../InstrumentedLibrary/Mathmatics/Polynomials/Roots/ComplexCubicRootsTests.cs

The required method signature for this API is as follows:

```CSharp
public static IList<Complex> ComplexCubicRoots(double a, double b, double c, double d, double epsilon = Epsilon)
```

## Test Case Index

- [Test Case: (1, 2, 3, 4, 5.6843418860808E-12)](#1,-2,-3,-4,-5.6843418860808E-12)
- [Test Case: (4, 3, 2, 1, 5.6843418860808E-12)](#4,-3,-2,-1,-5.6843418860808E-12)
- [Test Case: (1, 3, -6, 18, 5.6843418860808E-12)](#1,-3,--6,-18,-5.6843418860808E-12)

### (1, 2, 3, 4, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [SolveCubicDDanbe(1, 2, 3, 4, 5.6843418860808E-12)](#Solve-Cubic-Roots) | List\<Complex\> {(-1.6506291914393878, -0), (-0.17468540428030593, 1.546868887231396), (-0.17468540428030593, -1.546868887231396)} != List\<Complex\> {(-1.6506291914393878, 0), (-0.17468540428030593, 1.546868887231396), (-0.17468540428030593, -1.546868887231396)} | 10000 in 31 ms. 0.0031 ms. average | Dumb Polynomial test. |

### (4, 3, 2, 1, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [SolveCubicDDanbe(4, 3, 2, 1, 5.6843418860808E-12)](#Solve-Cubic-Roots) | List\<Complex\> {(-0.60582958618826788, -0), (-0.07208520690586602, 0.63832673514837635), (-0.07208520690586602, -0.63832673514837635)} != List\<Complex\> {(-0.60582958618826788, 0), (-0.07208520690586602, 0.63832673514837635), (-0.07208520690586602, -0.63832673514837635)} | 10000 in 28 ms. 0.0028 ms. average | Dumb Polynomial test. |

### (1, 3, -6, 18, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [SolveCubicDDanbe(1, 3, -6, 18, 5.6843418860808E-12)](#Solve-Cubic-Roots) | List\<Complex\> {(-4.94788592337517, -0), (0.97394296168758532, 1.6399245250888428), (0.97394296168758532, -1.6399245250888428)} != List\<Complex\> {(-4.94788592337517, 0), (0.97394296168758532, 1.6399245250888428), (0.97394296168758532, -1.6399245250888428)} | 10000 in 20 ms. 0.002 ms. average | Dumb Polynomial test. |

## The Code

The code for the methods tested follows below.

### Solve Cubic Roots

Find real Cubic Roots.  
- [https://www.daniweb.com/programming/software-development/code/454493/solving-the-cubic-equation-using-the-complex-struct](https://www.daniweb.com/programming/software-development/code/454493/solving-the-cubic-equation-using-the-complex-struct)
- [http://en.wikipedia.org/wiki/Cubic_function#General_formula_for_roots](http://en.wikipedia.org/wiki/Cubic_function#General_formula_for_roots)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IList<Complex> SolveCubicDDanbe(double a, double b, double c, double d, double epsilon = Epsilon)
        {
            const int NRoots = 3;
            var SquareRootof3 = Sqrt(3);

            // the 3 cubic roots of 1
            var CubicUnity = new List<Complex>(NRoots) { new Complex(1, 0), new Complex(-0.5d, -SquareRootof3 / 2d), new Complex(-0.5d, SquareRootof3 / 2d) };

            // intermediate calculations
            var DELTA = (18d * a * b * c * d) - (4d * b * b * b * d) + (b * b * c * c) - (4d * a * c * c * c) - (27d * a * a * d * d);
            var DELTA0 = (b * b) - (3d * a * c);
            var DELTA1 = (2d * b * b * b) - (9d * a * b * c) + (27d * a * a * d);
            Complex DELTA2 = -27d * a * a * DELTA;
            var C = Complex.Pow((DELTA1 + Complex.Pow(DELTA2, 0.5d)) / 2d, 1d / 3d); //Phew...

            var R = new List<Complex>(NRoots);
            for (var i = 0; i < NRoots; i++)
            {
                var M = CubicUnity[i] * C;
                var Root = -1d / (3d * a) * (b + M + (DELTA0 / M));
                R.Add(Root);
            }
            return R;
        }
```

