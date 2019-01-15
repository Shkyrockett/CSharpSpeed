# Intersection of Cubic Bezier and Line Segment

Finds the intersection points of a Cubic Bezier and Line Segment.

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

../../InstrumentedLibrary/Geometry/Intersections/CubicBezierLineSegmentIntersectionTests.cs

The required method signature for this API is as follows:

```CSharp
public static Intersection CubicBezierLineSegmentIntersection(double p0x, double p0y, double p1x, double p1y, double p2x, double p2y, double p3x, double p3y, double l0x, double l0y, double l1x, double l1y, double epsilon = Epsilon)
```

## Test Case Index

- [Test Case: (0, 5, 10, 15, 20, 0, 5, 10, -5, 20, 10, 30, 5.6843418860808E-12)](#0,-5,-10,-15,-20,-0,-5,-10,--5,-20,-10,-30,-5.6843418860808E-12)

### (0, 5, 10, 15, 20, 0, 5, 10, -5, 20, 10, 30, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CubicBezierLineIntersection0(0, 5, 10, 15, 20, 0, 5, 10, -5, 20, 10, 30, 5.6843418860808E-12)](#Intersection-of-Cubic-Bezier-and-Line-Segment) | Intersection{State:NoIntersection, Points:System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]] } != 15 | 10000 in 28 ms. 0.0028 ms. average |  |
| [CubicBezierLineSegmentIntersection1(0, 5, 10, 15, 20, 0, 5, 10, -5, 20, 10, 30, 5.6843418860808E-12)](#Intersection-of-Cubic-Bezier-and-Line-Segment) | Intersection{State:NoIntersection, Points:System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]] } != 15 | 10000 in 23 ms. 0.0023 ms. average |  |
| [CubicBezierLineSegmentIntersection2(0, 5, 10, 15, 20, 0, 5, 10, -5, 20, 10, 30, 5.6843418860808E-12)](#Intersection-of-Cubic-Bezier-and-Line-Segment) | Intersection{State:NoIntersection, Points:System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]] } != 15 | 10000 in 38 ms. 0.0038 ms. average |  |

## The Code

The code for the methods tested follows below.

### Intersection of Cubic Bezier and Line Segment

Finds the intersection points of a Cubic Bezier and Line Segment.  
- [http://www.kevlindev.com/](http://www.kevlindev.com/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection CubicBezierLineIntersection0(
            double p1X, double p1Y,
            double p2X, double p2Y,
            double p3X, double p3Y,
            double p4X, double p4Y,
            double a1X, double a1Y,
            double a2X, double a2Y,
            double epsilon = Epsilon)
        {
            Vector2D a, b, c, d;
            Vector2D c3, c2, c1, c0;
            double cl;
            Vector2D n;
            var min = MinPointTests.MinPoint(a1X, a1Y, a2X, a2Y);
            var max = MaxPointTests.MaxPoint(a1X, a1Y, a2X, a2Y);
            var result = new Intersection(IntersectionState.NoIntersection);
            a = new Vector2D(p1X, p1Y) * (-1);
            b = new Vector2D(p2X, p2Y) * 3;
            c = new Vector2D(p3X, p3Y) * (-3);
            d = a + (b + (c + new Vector2D(p4X, p4Y)));
            c3 = new Vector2D(d.I, d.J);
            a = new Vector2D(p1X, p1Y) * 3;
            b = new Vector2D(p2X, p2Y) * (-6);
            c = new Vector2D(p3X, p3Y) * 3;
            d = a + (b + c);
            c2 = new Vector2D(d.I, d.J);
            a = new Vector2D(p1X, p1Y) * (-3);
            b = new Vector2D(p2X, p2Y) * 3;
            c = a + b;
            c1 = new Vector2D(c.I, c.J);
            c0 = new Vector2D(p1X, p1Y);
            n = new Vector2D(a1Y - a2Y, a2X - a1X);
            cl = a1X * a2Y - a2X * a1Y;
            var roots = CubicRootsTests.CubicRoots(
                DotProduct2Vector2DTests.DotProduct2D(n.I, n.J, c3.I, c3.J),
                DotProduct2Vector2DTests.DotProduct2D(n.I, n.J, c2.I, c2.J),
                DotProduct2Vector2DTests.DotProduct2D(n.I, n.J, c1.I, c1.J),
                DotProduct2Vector2DTests.DotProduct2D(n.I, n.J, c0.I + cl, c0.J + cl),
                epsilon);
            for (var i = 0; i < roots.Count; i++)
            {
                var t = roots[i];
                if (0 <= t && t <= 1)
                {
                    var p5 = InterpolateLinear2DTests.LinearInterpolate2D(p1X, p1Y, p2X, p2Y, t);
                    var p6 = InterpolateLinear2DTests.LinearInterpolate2D(p2X, p2Y, p3X, p3Y, t);
                    var p7 = InterpolateLinear2DTests.LinearInterpolate2D(p3X, p3Y, p4X, p4Y, t);
                    var p8 = InterpolateLinear2DTests.LinearInterpolate2D(p5.X, p5.Y, p6.X, p6.Y, t);
                    var p9 = InterpolateLinear2DTests.LinearInterpolate2D(p6.X, p6.Y, p7.X, p7.Y, t);
                    var p10 = InterpolateLinear2DTests.LinearInterpolate2D(p8.X, p8.Y, p9.X, p9.Y, t);
                    if (a1X == a2X)
                    {
                        result.State = IntersectionState.Intersection;
                        result.AppendPoint(p10);
                    }
                    else if (a1Y == a2Y)
                    {
                        result.State = IntersectionState.Intersection;
                        result.AppendPoint(p10);
                    }
                    else if (GreaterThanOrEqualTests.GreaterThanOrEqual(p10.X, p10.Y, min.X, min.Y) && LessThanOrEqualTests.LessThanOrEqual(p10.X, p10.Y, max.X, max.Y))
                    {
                        result.State = IntersectionState.Intersection;
                        result.AppendPoint(p10);
                    }
                }
            }

            return result;
        }
```

### Intersection of Cubic Bezier and Line Segment

Finds the intersection points of a Cubic Bezier and Line Segment.  
- [https://www.particleincell.com/2013/cubic-line-intersection/](https://www.particleincell.com/2013/cubic-line-intersection/)
- [http://www.abecedarical.com/javascript/script_cubic.html](http://www.abecedarical.com/javascript/script_cubic.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection CubicBezierLineSegmentIntersection1(
            double p0x, double p0y,
            double p1x, double p1y,
            double p2x, double p2y,
            double p3x, double p3y,
            double l0x, double l0y,
            double l1x, double l1y,
            double epsilon = Epsilon)
        {
            // ToDo: Figure out why this can't handle intersection with horizontal lines.
            var I = new Intersection(IntersectionState.NoIntersection);

            var A = l1y - l0y;      //A=y2-y1
            var B = l0x - l1x;      //B=x1-x2
            var C = l0x * (l0y - l1y) + l0y * (l1x - l0x);  //C=x1*(y1-y2)+y1*(x2-x1)

            var xCoeff = CubicBezierCoefficientsTests.CubicBezierCoefficients(p0x, p1x, p2x, p3x);
            var yCoeff = CubicBezierCoefficientsTests.CubicBezierCoefficients(p0y, p1y, p2y, p3y);

            var r = CubicRootsTests.CubicRoots(
                /* t^3 */ A * xCoeff.D + B * yCoeff.D,
                /* t^2 */ A * xCoeff.C + B * yCoeff.C,
                /* t^1 */ A * xCoeff.B + B * yCoeff.B,
                /* 1 */ A * xCoeff.A + B * yCoeff.A + C
                );

            /*verify the roots are in bounds of the linear segment*/
            for (var i = 0; i < 3; i++)
            {
                var t = r[i];

                var x = xCoeff.D * t * t * t + xCoeff.C * t * t + xCoeff.B * t + xCoeff.A;
                var y = yCoeff.D * t * t * t + yCoeff.C * t * t + yCoeff.B * t + yCoeff.A;

                /*above is intersection point assuming infinitely long line segment,
                  make sure we are also in bounds of the line*/
                double m;
                m = (l1x - l0x) != 0 ? (x - l0x) / (l1x - l0x) : (y - l0y) / (l1y - l0y);

                /*in bounds?*/
                if (t < 0 || t > 1d || m < 0 || m > 1d)
                {
                    x = 0;// -100;  /*move off screen*/
                    y = 0;// -100;
                }
                else
                {
                    /*intersection point*/
                    I.AppendPoint(new Point2D(x, y));
                    I.State = IntersectionState.Intersection;
                }
            }
            return I;
        }
```

### Intersection of Cubic Bezier and Line Segment

Finds the intersection points of a Cubic Bezier and Line Segment.  
- [http://www.kevlindev.com/](http://www.kevlindev.com/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection CubicBezierLineSegmentIntersection2(
            double p1X, double p1Y,
            double p2X, double p2Y,
            double p3X, double p3Y,
            double p4X, double p4Y,
            double a1X, double a1Y,
            double a2X, double a2Y,
            double epsilon = Epsilon)
        {
            Vector2D a, b, c, d;
            Vector2D c3, c2, c1, c0;
            double cl;
            Vector2D n;
            var min = MinPointTests.MinPoint(a1X, a1Y, a2X, a2Y);
            var max = MaxPointTests.MaxPoint(a1X, a1Y, a2X, a2Y);
            var result = new Intersection(IntersectionState.NoIntersection);
            a = new Vector2D(p1X, p1Y) * (-1);
            b = new Vector2D(p2X, p2Y) * 3;
            c = new Vector2D(p3X, p3Y) * (-3);
            d = a + (b + (c + new Vector2D(p4X, p4Y)));
            c3 = new Vector2D(d.I, d.J);
            a = new Vector2D(p1X, p1Y) * 3;
            b = new Vector2D(p2X, p2Y) * (-6);
            c = new Vector2D(p3X, p3Y) * 3;
            d = a + (b + c);
            c2 = new Vector2D(d.I, d.J);
            a = new Vector2D(p1X, p1Y) * (-3);
            b = new Vector2D(p2X, p2Y) * 3;
            c = a + b;
            c1 = new Vector2D(c.I, c.J);
            c0 = new Vector2D(p1X, p1Y);
            n = new Vector2D(a1Y - a2Y, a2X - a1X);
            cl = a1X * a2Y - a2X * a1Y;
            var roots = CubicRootsTests.CubicRoots(
                DotProduct2Vector2DTests.DotProduct2D(n.I, n.J, c3.I, c3.J),
                DotProduct2Vector2DTests.DotProduct2D(n.I, n.J, c2.I, c2.J),
                DotProduct2Vector2DTests.DotProduct2D(n.I, n.J, c1.I, c1.J),
                DotProduct2Vector2DTests.DotProduct2D(n.I, n.J, c0.I + cl, c0.J + cl),
                epsilon);
            for (var i = 0; i < roots.Count; i++)
            {
                var t = roots[i];
                if (0 <= t && t <= 1)
                {
                    var p5 = InterpolateLinear2DTests.LinearInterpolate2D(p1X, p1Y, p2X, p2Y, t);
                    var p6 = InterpolateLinear2DTests.LinearInterpolate2D(p2X, p2Y, p3X, p3Y, t);
                    var p7 = InterpolateLinear2DTests.LinearInterpolate2D(p3X, p3Y, p4X, p4Y, t);
                    var p8 = InterpolateLinear2DTests.LinearInterpolate2D(p5.X, p5.Y, p6.X, p6.Y, t);
                    var p9 = InterpolateLinear2DTests.LinearInterpolate2D(p6.X, p6.Y, p7.X, p7.Y, t);
                    var p10 = InterpolateLinear2DTests.LinearInterpolate2D(p8.X, p8.Y, p9.X, p9.Y, t);
                    if (a1X == a2X)
                    {
                        if (min.Y <= p10.Y && p10.Y <= max.Y)
                        {
                            result.State = IntersectionState.Intersection;
                            result.AppendPoint(p10);
                        }
                    }
                    else if (a1Y == a2Y)
                    {
                        if (min.X <= p10.X && p10.X <= max.X)
                        {
                            result.State = IntersectionState.Intersection;
                            result.AppendPoint(p10);
                        }
                    }
                    else if (GreaterThanOrEqualTests.GreaterThanOrEqual(p10.X, p10.X, min.Y, min.Y) && LessThanOrEqualTests.LessThanOrEqual(p10.X, p10.Y, max.X, max.Y))
                    {
                        result.State = IntersectionState.Intersection;
                        result.AppendPoint(p10);
                    }
                }
            }
            return result;
        }
```

