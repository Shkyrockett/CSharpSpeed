# Intersection of Quadratic Bezier and Line Segment

Finds the intersection points of a Quadratic Bezier and Line Segment.

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

../../InstrumentedLibrary/Geometry/Intersections/QuadraticBezierLineSegmentIntersectionTests.cs

The required method signature for this API is as follows:

```CSharp
public static Intersection QuadraticBezierLineSegmentIntersection(double p1X, double p1Y, double p2X, double p2Y, double p3X, double p3Y, double a1X, double a1Y, double a2X, double a2Y, double epsilon = Epsilon)
```

## Test Case Index

- [Test Case: (0, 5, 10, 15, 20, 0, 5, 10, -5, 20, 5.6843418860808E-12)](#0,-5,-10,-15,-20,-0,-5,-10,--5,-20,-5.6843418860808E-12)

### (0, 5, 10, 15, 20, 0, 5, 10, -5, 20, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [QuadraticBezierLineIntersection(0, 5, 10, 15, 20, 0, 5, 10, -5, 20, 5.6843418860808E-12)](#Intersection-of-Quadratic-Bezier-and-Line-Segment) | Intersection{State:NoIntersection, Points:System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]] } != 15 | 10000 in 32 ms. 0.0032 ms. average |  |
| [QuadraticBezierLineSegmentIntersection0(0, 5, 10, 15, 20, 0, 5, 10, -5, 20, 5.6843418860808E-12)](#Intersection-of-Quadratic-Bezier-and-Line-Segment) | Intersection{State:NoIntersection, Points:System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]] } != 15 | 10000 in 31 ms. 0.0031 ms. average |  |
| [QuadraticBezierLineSegmentIntersection1(0, 5, 10, 15, 20, 0, 5, 10, -5, 20, 5.6843418860808E-12)](#Intersection-of-Quadratic-Bezier-and-Line-Segment) | Intersection{State:NoIntersection, Points:System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]] } != 15 | 10000 in 55 ms. 0.0055 ms. average |  |

## The Code

The code for the methods tested follows below.

### Intersection of Quadratic Bezier and Line Segment

Finds the intersection points of a Quadratic Bezier and Line Segment.  
- [http://www.kevlindev.com/](http://www.kevlindev.com/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection QuadraticBezierLineIntersection(
            double p1X, double p1Y,
            double p2X, double p2Y,
            double p3X, double p3Y,
            double a1X, double a1Y,
            double a2X, double a2Y,
            double epsilon = Epsilon)
        {
            var min = MinPointTests.MinPoint(a1X, a1Y, a2X, a2Y);
            var max = MaxPointTests.MaxPoint(a1X, a1Y, a2X, a2Y);
            var result = new Intersection(IntersectionState.NoIntersection);
            var a = new Vector2D(p2X, p2Y) * (-2);
            var c2 = new Vector2D(p1X, p1Y) + (a + new Vector2D(p3X, p3Y));
            a = new Vector2D(p1X, p1Y) * (-2);
            var b = new Vector2D(p2X, p2Y) * 2;
            var c1 = a + b;
            var c0 = new Point2D(p1X, p1Y);
            var n = new Point2D(a1Y - a2Y, a2X - a1X);
            var cl = a1X * a2Y - a2X * a1Y;
            var roots = QuadraticRootsTests.QuadraticRoots(
                DotProduct2Vector2DTests.DotProduct2D(n.X, n.Y, c2.I, c2.J),
                DotProduct2Vector2DTests.DotProduct2D(n.X, n.Y, c1.I, c1.J),
                DotProduct2Vector2DTests.DotProduct2D(n.X, n.Y, c0.X + cl, c0.Y + cl),
                epsilon);
            for (var i = 0; i < roots.Count; i++)
            {
                var t = roots[i];
                if (0 <= t && t <= 1)
                {
                    var p4 = InterpolateLinear2DTests.LinearInterpolate2D(p1X, p1Y, p2X, p2Y, t);
                    var p5 = InterpolateLinear2DTests.LinearInterpolate2D(p2X, p2Y, p3X, p3Y, t);
                    var p6 = InterpolateLinear2DTests.LinearInterpolate2D(p4.X, p4.Y, p5.X, p5.Y, t);
                    if (a1X == a2X)
                    {
                        result.AppendPoint(p6);
                    }
                    else if (a1Y == a2Y)
                    {
                        result.AppendPoint(p6);
                    }
                    else if (GreaterThanOrEqualTests.GreaterThanOrEqual(p6.X, p6.Y, min.X, min.Y) && LessThanOrEqualTests.LessThanOrEqual(p6.X, p6.Y, max.X, max.Y))
                    {
                        result.AppendPoint(p6);
                    }
                }
            }

            if (result.Count > 0)
            {
                result.State |= IntersectionState.Intersection;
            }

            return result;
        }
```

### Intersection of Quadratic Bezier and Line Segment

Finds the intersection points of a Quadratic Bezier and Line Segment.  
- [http://www.kevlindev.com/](http://www.kevlindev.com/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection QuadraticBezierLineSegmentIntersection0(
            double p1X, double p1Y,
            double p2X, double p2Y,
            double p3X, double p3Y,
            double a1X, double a1Y,
            double a2X, double a2Y,
            double epsilon = Epsilon)
        {
            var min = MinPointTests.MinPoint(a1X, a1Y, a2X, a2Y);
            var max = MaxPointTests.MaxPoint(a1X, a1Y, a2X, a2Y);
            var result = new Intersection(IntersectionState.NoIntersection);
            var a = new Vector2D(p2X, p2Y) * (-2);
            var c2 = new Vector2D(p1X, p1Y) + (a + new Vector2D(p3X, p3Y));
            a = new Vector2D(p1X, p1Y) * (-2);
            var b = new Vector2D(p2X, p2Y) * 2;
            var c1 = a + b;
            var c0 = new Point2D(p1X, p1Y);
            var n = new Point2D(a1Y - a2Y, a2X - a1X);
            var cl = a1X * a2Y - a2X * a1Y;
            var roots = QuadraticRootsTests.QuadraticRoots(
                DotProduct2Vector2DTests.DotProduct2D(n.X, n.Y, c2.I, c2.J),
                DotProduct2Vector2DTests.DotProduct2D(n.X, n.Y, c1.I, c1.J),
                DotProduct2Vector2DTests.DotProduct2D(n.X, n.Y, c0.X + cl, c0.Y + cl),
                epsilon);
            for (var i = 0; i < roots.Count; i++)
            {
                var t = roots[i];
                if (0 <= t && t <= 1)
                {
                    var p4 = InterpolateLinear2DTests.LinearInterpolate2D(p1X, p1Y, p2X, p2Y, t);
                    var p5 = InterpolateLinear2DTests.LinearInterpolate2D(p2X, p2Y, p3X, p3Y, t);
                    var p6 = InterpolateLinear2DTests.LinearInterpolate2D(p4.X, p4.Y, p5.X, p5.Y, t);
                    if (a1X == a2X)
                    {
                        if (min.Y <= p6.Y && p6.Y <= max.Y)
                        {
                            result.State = IntersectionState.Intersection;
                            result.AppendPoint(p6);
                        }
                    }
                    else if (a1Y == a2Y)
                    {
                        if (min.X <= p6.X && p6.X <= max.X)
                        {
                            result.State = IntersectionState.Intersection;
                            result.AppendPoint(p6);
                        }
                    }
                    else if (GreaterThanOrEqualTests.GreaterThanOrEqual(p6.X, p6.Y, min.X, min.Y) && LessThanOrEqualTests.LessThanOrEqual(p6.X, p6.Y, max.X, max.Y))
                    {
                        result.State = IntersectionState.Intersection;
                        result.AppendPoint(p6);
                    }
                }
            }
            return result;
        }
```

### Intersection of Quadratic Bezier and Line Segment

Finds the intersection points of a Quadratic Bezier and Line Segment.  
- [http://stackoverflow.com/questions/27664298/calculating-intersection-point-of-quadratic-bezier-curve](http://stackoverflow.com/questions/27664298/calculating-intersection-point-of-quadratic-bezier-curve)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection QuadraticBezierLineSegmentIntersection1(
            double p1X, double p1Y,
            double p2X, double p2Y,
            double p3X, double p3Y,
            double a1X, double a1Y,
            double a2X, double a2Y,
            double epsilon = Epsilon)
        {
            var intersections = new Intersection(IntersectionState.NoIntersection);

            // inverse line normal
            var normal = new Point2D(a1Y - a2Y, a2X - a1X);

            // Q-coefficients
            var c2 = new Point2D(p1X + p2X * -2 + p3X, p1Y + p2Y * -2 + p3Y);
            var c1 = new Point2D(p1X * -2 + p2X * 2, p1Y * -2 + p2Y * 2);
            var c0 = new Point2D(p1X, p1Y);

            // Transform to line
            var coefficient = a1X * a2Y - a2X * a1Y;
            var a = normal.X * c2.X + normal.Y * c2.Y;
            var b = (normal.X * c1.X + normal.Y * c1.Y) / a;
            var c = (normal.X * c0.X + normal.Y * c0.Y + coefficient) / a;

            // solve the roots
            var roots = new List<double>();
            var d = b * b - 4 * c;
            if (d > 0)
            {
                var e = Sqrt(d);
                roots.Add((-b + Sqrt(d)) / 2d);
                roots.Add((-b - Sqrt(d)) / 2d);
            }
            else if (d == 0)
            {
                roots.Add(-b / 2d);
            }

            // Calculate the solution points
            for (var i = 0; i < roots.Count; i++)
            {
                var minX = Min(a1X, a2X);
                var minY = Min(a1Y, a2Y);
                var maxX = Max(a1X, a2X);
                var maxY = Max(a1Y, a2Y);
                var t = roots[i];
                if (t >= 0 && t <= 1)
                {
                    // Possible point -- pending bounds check
                    var point = new Point2D(
                        InterpolateLinear1DTests.LinearInterpolate1D(InterpolateLinear1DTests.LinearInterpolate1D(p1X, p2X, t), InterpolateLinear1DTests.LinearInterpolate1D((double)p2X, (double)p3X, (double)t), t),
                        InterpolateLinear1DTests.LinearInterpolate1D(InterpolateLinear1DTests.LinearInterpolate1D(p1Y, p2Y, t), InterpolateLinear1DTests.LinearInterpolate1D(p2Y, p3Y, t), t));
                    var x = point.X;
                    var y = point.Y;
                    var result = new Intersection(IntersectionState.Intersection);
                    // bounds checks
                    if (a1X == a2X && y >= minY && y <= maxY)
                    {
                        // vertical line
                        intersections.AppendPoint(point);
                    }
                    else if (a1Y == a2Y && x >= minX && x <= maxX)
                    {
                        // horizontal line
                        intersections.AppendPoint(point);
                    }
                    else if (x >= minX && y >= minY && x <= maxX && y <= maxY)
                    {
                        // line passed bounds check
                        intersections.AppendPoint(point);
                    }
                }
            }
            return intersections;
        }
```

