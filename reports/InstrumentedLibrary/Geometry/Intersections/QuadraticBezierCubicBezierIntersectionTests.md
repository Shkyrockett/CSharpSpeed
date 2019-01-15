# Intersection of Quadratic Bezier and Cubic Bezier

Finds the intersection points of a Quadratic Bezier and Cubic Bezier.

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

../../InstrumentedLibrary/Geometry/Intersections/QuadraticBezierCubicBezierIntersectionTests.cs

The required method signature for this API is as follows:

```CSharp
public static Intersection QuadraticBezierSegmentCubicBezierSegmentIntersection(double a1X, double a1Y, double a2X, double a2Y, double a3X, double a3Y, double b1X, double b1Y, double b2X, double b2Y, double b3X, double b3Y, double b4X, double b4Y, double epsilon = Epsilon)
```

## Test Case Index

- [Test Case: (0, 5, 10, 15, 20, 0, 5, 10, -5, 20, 10, 30, 5, 0, 5.6843418860808E-12)](#0,-5,-10,-15,-20,-0,-5,-10,--5,-20,-10,-30,-5,-0,-5.6843418860808E-12)

### (0, 5, 10, 15, 20, 0, 5, 10, -5, 20, 10, 30, 5, 0, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [QuadraticBezierSegmentCubicBezierSegmentIntersection1(0, 5, 10, 15, 20, 0, 5, 10, -5, 20, 10, 30, 5, 0, 5.6843418860808E-12)](#Intersection-of-Quadratic-Bezier-and-Cubic-Bezier) | Intersection{State:NoIntersection, Points:System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]] } != 15 | 10000 in 106 ms. 0.0106 ms. average |  |
| [QuadraticBezierSegmentCubicBezierSegmentIntersection2(0, 5, 10, 15, 20, 0, 5, 10, -5, 20, 10, 30, 5, 0, 5.6843418860808E-12)](#Intersection-of-Quadratic-Bezier-and-Cubic-Bezier) | Intersection{State:NoIntersection, Points:System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]] } != 15 | 10000 in 149 ms. 0.0149 ms. average |  |

## The Code

The code for the methods tested follows below.

### Intersection of Quadratic Bezier and Cubic Bezier

Finds the intersection points of a Quadratic Bezier and Cubic Bezier.  
- [http://www.kevlindev.com/](http://www.kevlindev.com/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection QuadraticBezierSegmentCubicBezierSegmentIntersection1(
            double a1X, double a1Y, double a2X, double a2Y, double a3X, double a3Y,
            double b1X, double b1Y, double b2X, double b2Y, double b3X, double b3Y, double b4X, double b4Y,
            double epsilon = Epsilon)
        {
            var a = new Vector2D(a2X, a2Y) * -2;
            var c12 = new Vector2D(a1X, a1Y) + a + new Vector2D(a3X, a3Y);
            a = new Vector2D(a1X, a1Y) * -2;
            var b = new Vector2D(a2X, a2Y) * 2;
            var c11 = a + b;
            var c10 = new Vector2D(a1X, a1Y);
            a = new Vector2D(b1X, b1Y) * -1;
            b = new Vector2D(b2X, b2Y) * 3;
            var c = new Vector2D(b3X, b3Y) * -3;
            var d = a + b + c + new Vector2D(b4X, b4Y);
            var c23 = new Vector2D(d.I, d.J);
            a = new Vector2D(b1X, b1Y) * 3;
            b = new Vector2D(b2X, b2Y) * -6;
            c = new Vector2D(b3X, b3Y) * 3;
            d = a + b + c;
            var c22 = new Vector2D(d.I, d.J);
            a = new Vector2D(b1X, b1Y) * -3;
            b = new Vector2D(b2X, b2Y) * 3;
            c = a + b;
            var c21 = new Vector2D(c.I, c.J);
            var c20 = new Vector2D(b1X, b1Y);

            var c10x2 = c10.I * c10.I;
            var c10y2 = c10.J * c10.J;
            var c11x2 = c11.I * c11.I;
            var c11y2 = c11.J * c11.J;
            var c12x2 = c12.I * c12.I;
            var c12y2 = c12.J * c12.J;
            var c20x2 = c20.I * c20.I;
            var c20y2 = c20.J * c20.J;
            var c21x2 = c21.I * c21.I;
            var c21y2 = c21.J * c21.J;
            var c22x2 = c22.I * c22.I;
            var c22y2 = c22.J * c22.J;
            var c23x2 = c23.I * c23.I;
            var c23y2 = c23.J * c23.J;

            var roots = new Polynomial(
                -2 * c12.I * c12.J * c22.I * c23.J - 2 * c12.I * c12.J * c22.J * c23.I + 2 * c12y2 * c22.I * c23.I + 2 * c12x2 * c22.J * c23.J,
                -2 * c12.I * c12.J * c23.I * c23.J + c12x2 * c23y2 + c12y2 * c23x2,
                -2 * c12.I * c21.I * c12.J * c23.J - 2 * c12.I * c12.J * c21.J * c23.I - 2 * c12.I * c12.J * c22.I * c22.J + 2 * c21.I * c12y2 * c23.I + c12y2 * c22x2 + c12x2 * (2 * c21.J * c23.J + c22y2),
                2 * c10.I * c12.I * c12.J * c23.J + 2 * c10.J * c12.I * c12.J * c23.I + c11.I * c11.J * c12.I * c23.J + c11.I * c11.J * c12.J * c23.I - 2 * c20.I * c12.I * c12.J * c23.J - 2 * c12.I * c20.J * c12.J * c23.I - 2 * c12.I * c21.I * c12.J * c22.J - 2 * c12.I * c12.J * c21.J * c22.I - 2 * c10.I * c12y2 * c23.I - 2 * c10.J * c12x2 * c23.J + 2 * c20.I * c12y2 * c23.I + 2 * c21.I * c12y2 * c22.I - c11y2 * c12.I * c23.I - c11x2 * c12.J * c23.J + c12x2 * (2 * c20.J * c23.J + 2 * c21.J * c22.J),
                2 * c10.I * c12.I * c12.J * c22.J + 2 * c10.J * c12.I * c12.J * c22.I + c11.I * c11.J * c12.I * c22.J + c11.I * c11.J * c12.J * c22.I - 2 * c20.I * c12.I * c12.J * c22.J - 2 * c12.I * c20.J * c12.J * c22.I - 2 * c12.I * c21.I * c12.J * c21.J - 2 * c10.I * c12y2 * c22.I - 2 * c10.J * c12x2 * c22.J + 2 * c20.I * c12y2 * c22.I - c11y2 * c12.I * c22.I - c11x2 * c12.J * c22.J + c21x2 * c12y2 + c12x2 * (2 * c20.J * c22.J + c21y2),
                2 * c10.I * c12.I * c12.J * c21.J + 2 * c10.J * c12.I * c21.I * c12.J + c11.I * c11.J * c12.I * c21.J + c11.I * c11.J * c21.I * c12.J - 2 * c20.I * c12.I * c12.J * c21.J - 2 * c12.I * c20.J * c21.I * c12.J - 2 * c10.I * c21.I * c12y2 - 2 * c10.J * c12x2 * c21.J + 2 * c20.I * c21.I * c12y2 - c11y2 * c12.I * c21.I - c11x2 * c12.J * c21.J + 2 * c12x2 * c20.J * c21.J,
                -2 * c10.I * c10.J * c12.I * c12.J - c10.I * c11.I * c11.J * c12.J - c10.J * c11.I * c11.J * c12.I + 2 * c10.I * c12.I * c20.J * c12.J + 2 * c10.J * c20.I * c12.I * c12.J + c11.I * c20.I * c11.J * c12.J + c11.I * c11.J * c12.I * c20.J - 2 * c20.I * c12.I * c20.J * c12.J - 2 * c10.I * c20.I * c12y2 + c10.I * c11y2 * c12.I + c10.J * c11x2 * c12.J - 2 * c10.J * c12x2 * c20.J - c20.I * c11y2 * c12.I - c11x2 * c20.J * c12.J + c10x2 * c12y2 + c10y2 * c12x2 + c20x2 * c12y2 + c12x2 * c20y2
                ).RootsInInterval();

            var result = new Intersection(IntersectionState.NoIntersection);

            for (var i = 0; i < roots.Length; i++)
            {
                var s = roots[i];
                var xRoots = QuadraticRootsTests.QuadraticRoots(
                    c12.I,
                    c11.I,
                    c10.I - c20.I - s * c21.I - s * s * c22.I - s * s * s * c23.I,
                    epsilon);
                var yRoots = QuadraticRootsTests.QuadraticRoots(
                    c12.J,
                    c11.J,
                    c10.J - c20.J - s * c21.J - s * s * c22.J - s * s * s * c23.J,
                    epsilon);
                if (xRoots.Count > 0 && yRoots.Count > 0)
                {
                    for (var j = 0; j < xRoots.Count; j++)
                    {
                        var xRoot = xRoots[j];
                        if (0 <= xRoot && xRoot <= 1)
                        {
                            for (var k = 0; k < yRoots.Count; k++)
                            {
                                if (Abs(xRoot - yRoots[k]) < epsilon)
                                {
                                    result.Points.Add((Point2D)c23 * s * s * s + (c22 * s * s + (c21 * s + c20)));
                                    goto checkRoots;
                                }
                            }
                        }
                    }
                checkRoots:;
                }
            }

            if (result.Points.Count > 0)
            {
                result.State = IntersectionState.Intersection;
            }

            return result;
        }
```

### Intersection of Quadratic Bezier and Cubic Bezier

Finds the intersection points of a Quadratic Bezier and Cubic Bezier.  
- [http://www.kevlindev.com/](http://www.kevlindev.com/)
- [https://github.com/thelonious/kld-intersections/](https://github.com/thelonious/kld-intersections/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection QuadraticBezierSegmentCubicBezierSegmentIntersection2(
            double a1X, double a1Y, double a2X, double a2Y, double a3X, double a3Y,
            double b1X, double b1Y, double b2X, double b2Y, double b3X, double b3Y, double b4X, double b4Y,
            double epsilon = Epsilon)
        {
            var result = new Intersection(IntersectionState.NoIntersection);

            // ToDo: Break early if the AABB bounding box of the curve does not intersect.

            var c12 = new Vector2D(a1X - a2X * 2 + a3X, a1Y - a2Y * 2 + a3Y);
            var c11 = new Vector2D(2 * (a2X - a1X), 2 * (a2Y - a1Y));
            var c23 = new Vector2D(b4X - b3X * 3 + b2X * 3 - b1X * 1, b4Y - b3Y * 3 + b2Y * 3 - b1Y * 1);
            var c22 = new Vector2D(3 * (b3X - b2X * 2 + b1X), 3 * (b3Y - b2Y * 2 + b1Y));
            var c21 = new Vector2D(3 * (b2X - b1X), 3 * (b2Y - b1Y));

            var c10x2 = a1X * a1X;
            var c10y2 = a1Y * a1Y;
            var c11x2 = c11.I * c11.I;
            var c11y2 = c11.J * c11.J;
            var c12x2 = c12.I * c12.I;
            var c12y2 = c12.J * c12.J;

            var c20x2 = b1X * b1X;
            var c20y2 = b1Y * b1Y;
            var c21x2 = c21.I * c21.I;
            var c21y2 = c21.J * c21.J;
            var c22x2 = c22.I * c22.I;
            var c22y2 = c22.J * c22.J;
            var c23x2 = c23.I * c23.I;
            var c23y2 = c23.J * c23.J;

            var roots = new Polynomial(
                /* t^0 */ -2 * c12.I * c12.J * c22.I * c23.J - 2 * c12.I * c12.J * c22.J * c23.I + 2 * c12y2 * c22.I * c23.I + 2 * c12x2 * c22.J * c23.J,
                /* t^1 */ -2 * c12.I * c12.J * c23.I * c23.J + c12x2 * c23y2 + c12y2 * c23x2,
                /* t^2 */ -2 * c12.I * c21.I * c12.J * c23.J - 2 * c12.I * c12.J * c21.J * c23.I - 2 * c12.I * c12.J * c22.I * c22.J + 2 * c21.I * c12y2 * c23.I + c12y2 * c22x2 + c12x2 * (2 * c21.J * c23.J + c22y2),
                /* t^3 */ 2 * a1X * c12.I * c12.J * c23.J + 2 * a1Y * c12.I * c12.J * c23.I + c11.I * c11.J * c12.I * c23.J + c11.I * c11.J * c12.J * c23.I - 2 * b1X * c12.I * c12.J * c23.J - 2 * c12.I * b1Y * c12.J * c23.I - 2 * c12.I * c21.I * c12.J * c22.J - 2 * c12.I * c12.J * c21.J * c22.I - 2 * a1X * c12y2 * c23.I - 2 * a1Y * c12x2 * c23.J + 2 * b1X * c12y2 * c23.I + 2 * c21.I * c12y2 * c22.I - c11y2 * c12.I * c23.I - c11x2 * c12.J * c23.J + c12x2 * (2 * b1Y * c23.J + 2 * c21.J * c22.J),
                /* t^4 */ 2 * a1X * c12.I * c12.J * c22.J + 2 * a1Y * c12.I * c12.J * c22.I + c11.I * c11.J * c12.I * c22.J + c11.I * c11.J * c12.J * c22.I - 2 * b1X * c12.I * c12.J * c22.J - 2 * c12.I * b1Y * c12.J * c22.I - 2 * c12.I * c21.I * c12.J * c21.J - 2 * a1X * c12y2 * c22.I - 2 * a1Y * c12x2 * c22.J + 2 * b1X * c12y2 * c22.I - c11y2 * c12.I * c22.I - c11x2 * c12.J * c22.J + c21x2 * c12y2 + c12x2 * (2 * b1Y * c22.J + c21y2),
                /* t^5 */ 2 * a1X * c12.I * c12.J * c21.J + 2 * a1Y * c12.I * c21.I * c12.J + c11.I * c11.J * c12.I * c21.J + c11.I * c11.J * c21.I * c12.J - 2 * b1X * c12.I * c12.J * c21.J - 2 * c12.I * b1Y * c21.I * c12.J - 2 * a1X * c21.I * c12y2 - 2 * a1Y * c12x2 * c21.J + 2 * b1X * c21.I * c12y2 - c11y2 * c12.I * c21.I - c11x2 * c12.J * c21.J + 2 * c12x2 * b1Y * c21.J,
                /* t^6 */ -2 * a1X * a1Y * c12.I * c12.J - a1X * c11.I * c11.J * c12.J - a1Y * c11.I * c11.J * c12.I + 2 * a1X * c12.I * b1Y * c12.J + 2 * a1Y * b1X * c12.I * c12.J + c11.I * b1X * c11.J * c12.J + c11.I * c11.J * c12.I * b1Y - 2 * b1X * c12.I * b1Y * c12.J - 2 * a1X * b1X * c12y2 + a1X * c11y2 * c12.I + a1Y * c11x2 * c12.J - 2 * a1Y * c12x2 * b1Y - b1X * c11y2 * c12.I - c11x2 * b1Y * c12.J + c10x2 * c12y2 + c10y2 * c12x2 + c20x2 * c12y2 + c12x2 * c20y2
                ).RootsInInterval(0, 1);

            foreach (var s in roots)
            {
                var point = new Point2D(c23.I * s * s * s + c22.I * s * s + c21.I * s + b1X, c23.J * s * s * s + c22.J * s * s + c21.J * s + b1Y);
                var xRoots = QuadraticRootsTests.QuadraticRoots(
                    /* c */ c12.I,
                    /* t^1 */ c11.I,
                    /* t^2 */ a1X - point.X,
                    epsilon);
                var yRoots = QuadraticRootsTests.QuadraticRoots(
                    /* c */ c12.J,
                    /* t^1 */ c11.J,
                    /* t^2 */ a1Y - point.Y,
                    epsilon);
                if (xRoots.Count > 0 && yRoots.Count > 0)
                {
                    foreach (var xRoot in xRoots)
                    {
                        if (0 <= xRoot && xRoot <= 1)
                        {
                            foreach (var yRoot in yRoots)
                            {
                                var t = xRoot - yRoot;
                                if ((t >= 0 ? t : -t) < epsilon)
                                {
                                    result.Points.Add(point);
                                    goto checkRoots;
                                }
                            }
                        }
                    }
                checkRoots:;
                }
            }

            if (result.Points.Count > 0)
            {
                result.State = IntersectionState.Intersection;
            }

            return result;
        }
```

