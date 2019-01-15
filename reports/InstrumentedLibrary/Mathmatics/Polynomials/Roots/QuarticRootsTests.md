# Quartic Roots

Find the real roots of a Quartic polynomial.

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

../../InstrumentedLibrary/Mathmatics/Polynomials/Roots/QuarticRootsTests.cs

The required method signature for this API is as follows:

```CSharp
public static IList<double> QuarticRoots(double a, double b, double c, double d, double e, double epsilon = Epsilon)
```

## Test Case Index

- [Test Case: (1, 2, 3, 4, 5, 5.6843418860808E-12)](#1,-2,-3,-4,-5,-5.6843418860808E-12)
- [Test Case: (5, 4, 3, 2, 1, 5.6843418860808E-12)](#5,-4,-3,-2,-1,-5.6843418860808E-12)

### (1, 2, 3, 4, 5, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [QuarticRoots0(1, 2, 3, 4, 5, 5.6843418860808E-12)](#Quartic-Roots) | List\<double\> {} == List\<double\> {} | 10000 in 32 ms. 0.0032 ms. average | Dumb Polynomial test. |
| [QuarticRootsStephanSmola(1, 2, 3, 4, 5, 5.6843418860808E-12)](#Quartic-Roots-Stephan-Smola) | List\<double\> {} == List\<double\> {} | 10000 in 34 ms. 0.0034 ms. average | Dumb Polynomial test. |

### (5, 4, 3, 2, 1, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [QuarticRoots0(5, 4, 3, 2, 1, 5.6843418860808E-12)](#Quartic-Roots) | List\<double\> {} == List\<double\> {} | 10000 in 29 ms. 0.0029 ms. average | Dumb Polynomial test. |
| [QuarticRootsStephanSmola(5, 4, 3, 2, 1, 5.6843418860808E-12)](#Quartic-Roots-Stephan-Smola) | List\<double\> {} == List\<double\> {} | 10000 in 32 ms. 0.0032 ms. average | Dumb Polynomial test. |

## The Code

The code for the methods tested follows below.

### Quartic Roots

Find real Quartic Roots.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IList<double> QuarticRoots0(double a, double b, double c, double d, double e, double epsilon = Epsilon)
        {
            // If a is 0 the polynomial is cubic.
            if (a is 0d)
            {
                return CubicRootsTests.CubicRoots(b, c, d, e, epsilon);
            }

            var A = b / a;
            var B = c / a;
            var C = d / a;
            var D = e / a;

            var resolveRoots = CubicRootsTests.CubicRoots(
                (-A * A * D) + (4d * B * D) - (C * C),
                (A * C) - (4d * D),
                -B,
                1d,
                epsilon);
            var y = resolveRoots[0];
            var discriminant = (A * A * OneQuarter) - B + y;

            // ToDo: May need to switch from a hash set to a list for scan-beams.
            var results = new HashSet<double>();

            if (Abs(discriminant) <= epsilon)
            {
                discriminant = 0d;
            }

            if (discriminant > 0d)
            {
                var ee = Sqrt(discriminant);
                var t1 = (3d * A * A * OneQuarter) - (ee * ee) - (2d * B);
                var t2 = ((4d * A * B) - (8d * C) - (A * A * A)) / (4d * ee);
                var plus = t1 + t2;
                var minus = t1 - t2;
                if (Abs(plus) <= epsilon)
                {
                    plus = 0d;
                }

                if (Abs(minus) <= epsilon)
                {
                    minus = 0d;
                }

                if (plus >= 0d)
                {
                    var f = Sqrt(plus);
                    results.Add((-A * OneQuarter) + ((ee + f) * OneHalf));
                    results.Add((-A * OneQuarter) + ((ee - f) * OneHalf));
                }
                if (minus >= 0d)
                {
                    var f = Sqrt(minus);
                    results.Add((-A * OneQuarter) + ((f - ee) * OneHalf));
                    results.Add((-A * OneQuarter) - ((f + ee) * OneHalf));
                }
            }
            else if (discriminant < 0d)
            {
            }
            else
            {
                var t2 = (y * y) - (4d * D);
                if (t2 >= -epsilon)
                {
                    if (t2 < 0)
                    {
                        t2 = 0d;
                    }

                    t2 = 2d * Sqrt(t2);
                    var t1 = (3d * A * A * OneQuarter) - (2d * B);
                    if (t1 + t2 >= epsilon)
                    {
                        var d0 = Sqrt(t1 + t2);
                        results.Add((-A * OneQuarter) + (d0 * OneHalf));
                        results.Add((-A * OneQuarter) - (d0 * OneHalf));
                    }
                    if (t1 - t2 >= epsilon)
                    {
                        var d1 = Sqrt(t1 - t2);
                        results.Add((-A * OneQuarter) + (d1 * OneHalf));
                        results.Add((-A * OneQuarter) - (d1 * OneHalf));
                    }
                }
            }

            return results.ToList();
        }
```

### Quartic Roots Stephan Smola

Stephan Smola's method for finding real Quartic Roots.  
- [https://gist.github.com/drawable/92792f59b6ff8869d8b1](https://gist.github.com/drawable/92792f59b6ff8869d8b1)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IList<double> QuarticRootsStephanSmola(double a, double b, double c, double d, double e, double epsilon = Epsilon)
        {
            // If a is 0 the polynomial is cubic.
            if (a is 0d)
            {
                return CubicRootsTests.CubicRoots(b, c, d, e, epsilon);
            }

            var delta = (256d * a * a * a * e * e * e) - (192d * a * a * b * d * e * e) - (128d * a * a * c * c * e * e) + (144d * a * a * c * d * d * e) - (27d * a * a * d * d * d * d) + (144d * a * b * b * c * e * e) - (6d * a * b * b * d * d * e) - (80d * a * b * c * c * d * e) + (18d * a * b * c * d * d * d) + (16d * a * c * c * c * c * e) - (4d * a * c * c * c * d * d) - (27d * b * b * b * b * e * e) + (18d * b * b * b * c * d * e) - (4d * b * b * b * d * d * d) - (4d * b * b * c * c * c * e) + (b * b * c * c * d * d);
            var P = (8d * a * c) - (3d * b * b);
            var D = (64d * a * a * a * e) - (16d * a * a * c * c) + (16d * a * b * b * c) - (16d * a * a * b * d) - (3d * b * b * b * b);
            var d0 = (c * c) - (3d * b * d) + (12d * a * e);
            var d1 = (2d * c * c * c) - (9d * b * c * d) + (27d * b * b * e) + (27d * a * d * d) - (72d * a * c * e);
            var p = ((8 * a * c) - (3d * b * b)) / (8d * a * a);
            var q = ((b * b * b) - (4d * a * b * c) + (8 * a * a * d)) / (8d * a * a * a);
            var Q = 0d;
            var S = 0d;

            var phi = Acos(d1 / (2d * Sqrt(d0 * d0 * d0)));

            if (double.IsNaN(phi) && (d1 == 0d))
            {
                // if (delta < 0) I guess the new test is ok because we're only interested in real roots
                Q = d1 + Sqrt((d1 * d1) - (4d * d0 * d0 * d0));
                Q = Q / 2d;
                Q = Pow(Q, 1d / 3d);
                S = 0.5d * Sqrt((-2d / 3d * p) + (1d / (3d * a) * (Q + (d0 / Q))));
            }
            else
            {
                S = 0.5d * Sqrt((-2d / 3d * p) + (2d / (3d * a) * Sqrt(d0) * Cos(phi / 3d)));
            }

            var y = new List<double>();
            if (S != 0d)
            {
                var R = (-4d * S * S) - (2d * p) + (q / S);

                if (Abs(R) < epsilon)
                {
                    R = 0d;
                }

                if (R > 0d)
                {
                    R = 0.5d * Sqrt(R);
                    y.Add((-b / (4 * a)) - S + R);
                    y.Add((-b / (4 * a)) - S - R);
                }
                else if (Abs(R) < epsilon)
                {
                    y.Add((-b / (4d * a)) - S);
                }

                R = (-4d * S * S) - (2d * p) - (q / S);

                if (Abs(R) < epsilon)
                {
                    R = 0d;
                }

                if (R > 0d)
                {
                    R = 0.5d * Sqrt(R);
                    y.Add((-b / (4d * a)) + S + R);
                    y.Add((-b / (4d * a)) + S - R);
                }
                else if (R == 0d)
                {
                    y.Add((-b / (4d * a)) + S);
                }
            }

            return y;
        }
```

