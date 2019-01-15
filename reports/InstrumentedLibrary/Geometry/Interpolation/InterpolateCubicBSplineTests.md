# Cubic B-Spline Interpolate 2D Tests

Find a point on a 2D Cubic B-Spline curve.

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

../../InstrumentedLibrary/Geometry/Interpolation/InterpolateCubicBSplineTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double X, double Y) InterpolateBSpline(IList<(double X, double Y)> points, double index)
```

## Test Case Index

- [Test Case: (System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]], 0.5)](#System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]],-0.5)

### (System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]], 0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Interpolate(System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]], 0.5)](#Cubic-B-Spline-Interpolate-2D-Tests) | (1.5, 0.5) != (3, 4) | 10000 in 51 ms. 0.0051 ms. average |  |
| [InterpolateBSpline_(System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]], 0.5)](#Cubic-B-Spline-Interpolate-2D-Tests) | (1.875, 0.875) != (3, 4) | 10000 in 37 ms. 0.0037 ms. average |  |
| [InterpolateCubicBSplinePoint(System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]], 0.5)](#Cubic-B-Spline-Interpolate-2D-Tests) | (1.875, 0.875) != (3, 4) | 10000 in 16 ms. 0.0016 ms. average |  |

## The Code

The code for the methods tested follows below.

### Cubic B-Spline Interpolate 2D Tests

Find a point on a 2D Cubic B-Spline curve.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) Interpolate(IList<(double X, double Y)> points, double index)
        {
            var n = points.Count - 1;
            int kn;
            int nn;
            int nkn;

            double blend;
            double muk = 1;
            var munk = Pow(1 - index, n);

            var b = (X: 0d, Y: 0d);

            for (var k = 0; k <= n; k++)
            {
                nn = n;
                kn = k;
                nkn = n - k;
                blend = muk * munk;
                muk *= index;
                munk /= 1 - index;
                while (nn >= 1)
                {
                    blend *= nn;
                    nn--;
                    if (kn > 1)
                    {
                        blend /= kn;
                        kn--;
                    }
                    if (nkn > 1)
                    {
                        blend /= nkn;
                        nkn--;
                    }
                }

                b = (
                b.X + points[k].X * blend,
                b.Y + points[k].Y * blend
                    );
            }

            return b;
        }
```

### Cubic B-Spline Interpolate 2D Tests

Find a point on a 2D Cubic B-Spline curve.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) InterpolateBSpline_(IList<(double X, double Y)> points, double index)
        {
            if (points.Count >= 4)
            {
                var VPoints = new List<(double X, double Y)>(4);

                const int A = 0;
                const int B = 1;
                const int C = 2;
                const int D = 3;

                VPoints.Add((
                    points[D].X - points[C].X - (points[A].X - points[B].X),
                    points[D].Y - points[C].Y - (points[A].Y - points[B].Y)
                    ));

                VPoints.Add((
                    points[A].X - points[B].X - VPoints[A].X,
                    points[A].Y - points[B].Y - VPoints[A].Y
                    ));

                VPoints.Add((
                    points[C].X - points[A].X,
                    points[C].Y - points[A].Y
                    ));

                VPoints.Add(points[1]);

                return (
                    VPoints[0].X * index * index * index + VPoints[1].X * index * index * index + VPoints[2].X * index + VPoints[3].X,
                    VPoints[0].Y * index * index * index + VPoints[1].Y * index * index * index + VPoints[2].Y * index + VPoints[3].Y
                );
            }

            return (0, 0);
        }
```

### Cubic B-Spline Interpolate 2D Tests

Find a point on a 2D Cubic B-Spline curve.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) InterpolateCubicBSplinePoint(IList<(double X, double Y)> Points, double Index)
        {
            var VPoints = new (double X, double Y)[4];

            VPoints[0] = (
                Points[3].X - Points[2].X - (Points[0].X - Points[1].X),
                Points[3].Y - Points[2].Y - (Points[0].Y - Points[1].Y)
                );

            VPoints[1] = (
                Points[0].X - Points[1].X - VPoints[0].X,
                Points[0].Y - Points[1].Y - VPoints[0].Y
                );

            VPoints[2] = (
                Points[2].X - Points[0].X,
                Points[2].Y - Points[0].Y
                );

            VPoints[3] = Points[1];

            return (
                VPoints[0].X * Index * Index * Index + VPoints[1].X * Index * Index * Index + VPoints[2].X * Index + VPoints[3].X,
                VPoints[0].Y * Index * Index * Index + VPoints[1].Y * Index * Index * Index + VPoints[2].Y * Index + VPoints[3].Y
            );
        }
```

