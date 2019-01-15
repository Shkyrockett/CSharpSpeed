# Cubic Roots

Find the real roots of a Cubic polynomial.

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

../../InstrumentedLibrary/Mathmatics/Polynomials/Roots/CubicRootsTests.cs

The required method signature for this API is as follows:

```CSharp
public static IList<double> CubicRoots(double a, double b, double c, double d, double epsilon = Epsilon)
```

## Test Case Index

- [Test Case: (1, 2, 3, 4, 5.6843418860808E-12)](#1,-2,-3,-4,-5.6843418860808E-12)
- [Test Case: (4, 3, 2, 1, 5.6843418860808E-12)](#4,-3,-2,-1,-5.6843418860808E-12)
- [Test Case: (1, 3, -6, 18, 5.6843418860808E-12)](#1,-3,--6,-18,-5.6843418860808E-12)

### (1, 2, 3, 4, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CubicRootsKevinLinDev(1, 2, 3, 4, 5.6843418860808E-12)](#Cubic-Roots-Kevin-Lin) | List\<double\> {-1.6506291914393882} == List\<double\> {-1.6506291914393882} | 10000 in 20 ms. 0.002 ms. average | Dumb Polynomial test. |
| [CubicRootsStephenRSchmitt(1, 2, 3, 4, 5.6843418860808E-12)](#Cubic-Roots) | List\<double\> {-1.6506291914393882} == List\<double\> {-1.6506291914393882} | 10000 in 19 ms. 0.0019 ms. average | Dumb Polynomial test. |

### (4, 3, 2, 1, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CubicRootsKevinLinDev(4, 3, 2, 1, 5.6843418860808E-12)](#Cubic-Roots-Kevin-Lin) | List\<double\> {-0.605829586188268} == List\<double\> {-0.605829586188268} | 10000 in 24 ms. 0.0024 ms. average | Dumb Polynomial test. |
| [CubicRootsStephenRSchmitt(4, 3, 2, 1, 5.6843418860808E-12)](#Cubic-Roots) | List\<double\> {-0.605829586188268} == List\<double\> {-0.605829586188268} | 10000 in 23 ms. 0.0023 ms. average | Dumb Polynomial test. |

### (1, 3, -6, 18, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CubicRootsKevinLinDev(1, 3, -6, 18, 5.6843418860808E-12)](#Cubic-Roots-Kevin-Lin) | List\<double\> {-4.9478859233751713} == List\<double\> {-4.9478859233751713} | 10000 in 22 ms. 0.0022 ms. average | Dumb Polynomial test. |
| [CubicRootsStephenRSchmitt(1, 3, -6, 18, 5.6843418860808E-12)](#Cubic-Roots) | List\<double\> {-4.9478859233751713} == List\<double\> {-4.9478859233751713} | 10000 in 18 ms. 0.0018 ms. average | Dumb Polynomial test. |

## The Code

The code for the methods tested follows below.

### Cubic Roots Kevin Lin

Find real Cubic Roots.  
- [http://www.kevlindev.com/geometry/2D/intersections/](http://www.kevlindev.com/geometry/2D/intersections/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IList<double> CubicRootsKevinLinDev(double a, double b, double c, double d, double epsilon = Epsilon)
        {
            // If a is 0 the polynomial is quadratic.
            if (a is 0d)
            {
                return QuadraticRootsTests.QuadraticRoots(b, c, d, epsilon);
            }

            var results = new List<double>();
            var c2 = b / a;
            var c1 = c / a;
            var c0 = d / a;

            var Q = ((3 * c1) - (c2 * c2)) * OneThird;
            var R = ((2 * c2 * c2 * c2) - (9 * c1 * c2) + (27 * c0)) * OneTwentySeventh;

            var offset = c2 * OneThird;
            var discriminant = (R * R * OneQuarter) + (Q * Q * Q * OneTwentySeventh);

            var halfB = OneHalf * R;
            //var ZEROepsilon = ZeroErrorEstimate();

            if (Abs(discriminant) <= epsilon)//ZEROepsilon)
            {
                discriminant = 0;
            }

            if (discriminant > 0)
            {
                var e = Sqrt(discriminant);
                var tmp = -halfB + e;
                double root;
                root = tmp >= 0 ? Pow(tmp, OneThird) : -Pow(-tmp, OneThird);
                tmp = -halfB - e;
                if (tmp >= 0)
                {
                    root += Pow(tmp, OneThird);
                }
                else
                {
                    root -= Pow(-tmp, OneThird);
                }

                results.Add(root - offset);
            }
            else if (discriminant < 0)
            {
                var distance = Sqrt(-Q * OneThird);
                var angle = Atan2(Sqrt(-discriminant), -halfB) * OneThird;
                var cos = Cos(angle);
                var sin = Sin(angle);
                results.Add((2 * distance * cos) - offset);
                results.Add((-distance * (cos + (Sqrt3 * sin))) - offset);
                results.Add((-distance * (cos - (Sqrt3 * sin))) - offset);
            }
            else
            {
                double tmp;
                tmp = halfB >= 0 ? -Pow(halfB, OneThird) : Pow(-halfB, OneThird);
                results.Add((2 * tmp) - offset);
                // really should return next root twice, but we return only one
                results.Add(-tmp - offset);
            }
            return results;
        }
```

### Cubic Roots

Find real Cubic Roots  Stephen R. Schmitt.  
- [https://web.archive.org/web/20170322034124/http://abecedarical.com/javascript/script_exact_cubic.html](https://web.archive.org/web/20170322034124/http://abecedarical.com/javascript/script_exact_cubic.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IList<double> CubicRootsStephenRSchmitt(double a, double b, double c, double d, double epsilon = Epsilon)
        {
            // If a is 0 the polynomial is quadratic.
            if (a is 0d)
            {
                return QuadraticRootsTests.QuadraticRoots(b, c, d, epsilon);
            }

            var A = b / a;
            var B = c / a;
            var C = d / a;

            var Q = ((3d * B) - (A * A)) / 9d;
            var R = (-(2d * A * A * A) + (9d * A * B) - (27d * C)) / 54d;

            var offset = A * OneThird;

            // Polynomial discriminant
            var discriminant = (R * R) + (Q * Q * Q);

            // ToDo: May need to switch from a hash set to a list for scan-beams.
            var results = new HashSet<double>();

            if (Abs(discriminant) <= epsilon)
            {
                discriminant = 0d;
            }

            if (discriminant == 0d)
            {
                var t = Sign(R) * Pow(Abs(R), OneThird);

                // Real root.
                results.Add(-offset + (t + t));

                // Real part of complex root.
                results.Add(-offset - ((t + t) * OneHalf));
            }
            if (discriminant > 0)
            {
                var s = Sign(R + Sqrt(discriminant)) * Pow(Abs(R + Sqrt(discriminant)), OneThird);
                var t = Sign(R - Sqrt(discriminant)) * Pow(Abs(R - Sqrt(discriminant)), OneThird);

                // Real root.
                results.Add(-offset + (s + t));

                // Complex part of root pair.
                var Im = Abs(Sqrt(3d) * (s - t) * OneHalf);
                if (Im == 0d)
                {
                    // Real part of complex root.
                    results.Add(-offset - ((s + t) * OneHalf));
                }
            }
            else if (discriminant < 0)
            {
                // Distinct real roots.
                var th = Acos(R / Sqrt(-Q * Q * Q));

                results.Add((2d * Sqrt(-Q) * Cos(th * OneThird)) - offset);
                results.Add((2d * Sqrt(-Q) * Cos((th + Tau) * OneThird)) - offset);
                results.Add((2d * Sqrt(-Q) * Cos((th + (4d * PI)) * OneThird)) - offset);
            }

            return results.ToList();
        }
```

