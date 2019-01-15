# Ellipse, Ellipse Intersection Tests

Finds the intersection points of two Ellipse.

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

../../InstrumentedLibrary/Geometry/Intersections/UnrotatedEllipseUnrotatedEllipseIntersectionTests.cs

The required method signature for this API is as follows:

```CSharp
public static Intersection UnrotatedEllipseUnrotatedEllipseIntersection(double acX, double acY, double arX, double arY, double bcX, double bcY, double brX, double brY, double epsilon = Epsilon)
```

## Test Case Index

- [Test Case: (0, 0, 2, 2, 1, 0, 2, 2, 5.6843418860808E-12)](#0,-0,-2,-2,-1,-0,-2,-2,-5.6843418860808E-12)

### (0, 0, 2, 2, 1, 0, 2, 2, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Intersect(0, 0, 2, 2, 1, 0, 2, 2, 5.6843418860808E-12)](#Ellipse,-Ellipse-Intersection-Tests) | Intersection{State:Intersection, Points:System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]] } != True | 10000 in 28 ms. 0.0028 ms. average |  |
| [IntersecttionUsingBinaryDivision(0, 0, 2, 2, 1, 0, 2, 2, 5.6843418860808E-12)](#Ellipse,-Ellipse-Intersection-Tests) | Intersection{State:NoIntersection, Points:System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]] } != True | 10000 in 481 ms. 0.0481 ms. average |  |
| [IntersecttionUsingNewtonsMethod(0, 0, 2, 2, 1, 0, 2, 2, 5.6843418860808E-12)](#Ellipse,-Ellipse-Intersection-Tests) | Intersection{State:NoIntersection, Points:System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]] } != True | 10000 in 2883 ms. 0.2883 ms. average |  |

## The Code

The code for the methods tested follows below.

### Ellipse, Ellipse Intersection Tests

Finds the intersection points of two Ellipse.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection Intersect(
            double acX, double acY, double arX, double arY,
            double bcX, double bcY, double brX, double brY,
            double epsilon = Epsilon)
        {
            var ellipseA = (Center: (X: acX, Y: acY), MajorRadius: Max(arX, arY));
            var ellipseB = (Center: (X: bcX, Y: bcY), MajorRadius: Max(brX, brY));

            var result = new Intersection(IntersectionState.NoIntersection);

            var d = ellipseB.Center.X * ellipseB.Center.X - ellipseA.Center.X * ellipseA.Center.X - ellipseB.MajorRadius * ellipseB.MajorRadius - Pow(ellipseB.Center.Y - ellipseA.Center.Y, 2) + ellipseA.MajorRadius * ellipseA.MajorRadius;
            var a = Pow(2d * ellipseA.Center.X - 2d * ellipseB.Center.X, 2d) + 4d * Pow(ellipseB.Center.Y - ellipseA.Center.Y, 2d);
            var b = 2d * d * (2d * ellipseA.Center.X - 2d * ellipseB.Center.X) - 8d * ellipseB.Center.X * Pow(ellipseB.Center.Y - ellipseA.Center.Y, 2d);
            var C = 4d * ellipseB.Center.X * ellipseB.Center.X * Pow(ellipseB.Center.Y - ellipseA.Center.Y, 2d) + d * d - 4d * Pow(ellipseB.Center.Y - ellipseA.Center.Y, 2d) * ellipseB.MajorRadius * ellipseB.MajorRadius;
            var XA = (-b + Sqrt(b * b - 4d * a * C)) / (2d * a);
            var XB = (-b - Sqrt(b * b - 4d * a * C)) / (2d * a);
            var YA = Sqrt(ellipseA.MajorRadius * ellipseA.MajorRadius - Pow(XA - ellipseA.Center.X, 2)) + ellipseA.Center.Y;
            var YB = -Sqrt(ellipseA.MajorRadius * ellipseA.MajorRadius - Pow(XA - ellipseA.Center.X, 2)) + ellipseA.Center.Y;
            var YC = Sqrt(ellipseA.MajorRadius * ellipseA.MajorRadius - Pow(XB - ellipseA.Center.X, 2)) + ellipseA.Center.Y;
            var YD = -Sqrt(ellipseA.MajorRadius * ellipseA.MajorRadius - Pow(XB - ellipseA.Center.X, 2)) + ellipseA.Center.Y;
            var e = XA - ellipseB.Center.X + Pow(YA - ellipseB.Center.Y, 2) - ellipseB.MajorRadius * ellipseB.MajorRadius;
            var F = XA - ellipseB.Center.X + Pow(YB - ellipseB.Center.Y, 2) - ellipseB.MajorRadius * ellipseB.MajorRadius;
            var g = XB - ellipseB.Center.X + Pow(YC - ellipseB.Center.Y, 2) - ellipseB.MajorRadius * ellipseB.MajorRadius;
            var H = XB - ellipseB.Center.X + Pow(YD - ellipseB.Center.Y, 2) - ellipseB.MajorRadius * ellipseB.MajorRadius;
            if (Abs(F) < Abs(e))
            {
                YA = YB;
            }

            if (Abs(H) < Abs(g))
            {
                YC = YD;
            }

            if (Abs(ellipseA.Center.Y - ellipseB.Center.Y) < DoubleEpsilon)
            {
                YC = 2 * ellipseA.Center.Y - YA;
            }

            result.AppendPoint((XA, YA));
            result.AppendPoint((XB, YC));
            result.State = IntersectionState.Intersection;
            return result;
        }
```

### Ellipse, Ellipse Intersection Tests

Finds the intersection points of two Ellipse.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection IntersecttionUsingBinaryDivision(
            double acX, double acY, double arX, double arY,
            double bcX, double bcY, double brX, double brY,
            double epsilon = Epsilon)
        {
            var result = new Intersection(IntersectionState.NoIntersection);

            (var Dx1, var Dy1, var Rx1, var Ry1, var A1, var B1, var C1, var D1, var E1, var F1) = GetEllipseFormula(acX, acY, arX, arY, epsilon);
            var Ellipse1 = new Rectangle2D(acX - arX, acY - arY, arX * 2d, arY * 2d);
            (var Dx2, var Dy2, var Rx2, var Ry2, var A2, var B2, var C2, var D2, var E2, var F2) = GetEllipseFormula(bcX, bcY, brX, brY, epsilon);
            var Ellipse2 = new Rectangle2D(bcX - brX, bcY - brY, brX * 2d, brY * 2d);

            // Find the difference tangents.
            var TangentX = 184d;
            (List<(double X, double Y)> TangentCenters, List<(double X, double Y)> TangentP1, List<(double X, double Y)> TangentP2) = FindDifferenceTangents(TangentX, A1, B1, C1, D1, E1, F1, A2, B2, C2, D2, E2, F2);

            // Find the roots of the difference equations
            // and thus the points of intersection.
            var xmin = Max(Ellipse1.Left, Ellipse2.Left);
            var xmax = Min(Ellipse1.Right, Ellipse2.Right);
            (var Roots, var RootSign1, var RootSign2, var PointsOfIntersection) = FindPointsOfIntersectionUsingBinaryDivision(xmin, xmax, A1, B1, C1, D1, E1, F1, A2, B2, C2, D2, E2, F2);

            return result;
        }
```

### Ellipse, Ellipse Intersection Tests

Finds the intersection points of two Ellipse.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection IntersecttionUsingNewtonsMethod(
            double acX, double acY, double arX, double arY,
            double bcX, double bcY, double brX, double brY,
            double epsilon = Epsilon)
        {
            var result = new Intersection(IntersectionState.NoIntersection);

            (var Dx1, var Dy1, var Rx1, var Ry1, var A1, var B1, var C1, var D1, var E1, var F1) = GetEllipseFormula(acX, acY, arX, arY, epsilon);
            var Ellipse1 = new Rectangle2D(acX - arX, acY - arY, arX * 2d, arY * 2d);
            (var Dx2, var Dy2, var Rx2, var Ry2, var A2, var B2, var C2, var D2, var E2, var F2) = GetEllipseFormula(bcX, bcY, brX, brY, epsilon);
            var Ellipse2 = new Rectangle2D(bcX - brX, bcY - brY, brX * 2d, brY * 2d);

            // Find the difference tangents.
            var TangentX = 184d;
            (List<(double X, double Y)> TangentCenters, List<(double X, double Y)> TangentP1, List<(double X, double Y)> TangentP2) = FindDifferenceTangents(TangentX, A1, B1, C1, D1, E1, F1, A2, B2, C2, D2, E2, F2);

            // Find the roots of the difference equations
            // and thus the points of intersection.
            var xmin = Max(Ellipse1.Left, Ellipse2.Left);
            var xmax = Min(Ellipse1.Right, Ellipse2.Right);
            (var Roots, var RootSign1, var RootSign2, var PointsOfIntersection) = FindPointsOfIntersectionNewtonsMethod(xmin, xmax, A1, B1, C1, D1, E1, F1, A2, B2, C2, D2, E2, F2);

            result.AppendPoints(PointsOfIntersection);

            return result;
        }
```

