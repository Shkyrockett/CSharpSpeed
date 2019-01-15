# Orthogonal Ellipse Line Segment Intersection Tests

Finds the intersection points of an Orthogonal Ellipse and a Line Segment Intersection.

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

../../InstrumentedLibrary/Geometry/Intersections/UnrotatedEllipseLineSegmentIntersectionTests.cs

The required method signature for this API is as follows:

```CSharp
public static Intersection UnrotatedEllipseLineSegmentIntersection(double cx, double cy, double rx, double ry, double x0, double y0, double x1, double y1, double epsilon = Epsilon)
```

## Test Case Index

- [Test Case: (0, 0, 2, 2, 1, 1, 3, 3, 5.6843418860808E-12)](#0,-0,-2,-2,-1,-1,-3,-3,-5.6843418860808E-12)

### (0, 0, 2, 2, 1, 1, 3, 3, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [EllipseLineSegment(0, 0, 2, 2, 1, 1, 3, 3, 5.6843418860808E-12)](#Orthogonal-Ellipse-Line-Segment-Intersection-Tests) | (False, (1.4142135623731, 1.4142135623731), False, (-1.4142135623731, -1.41421356237309)) != True | 10000 in 29 ms. 0.0029 ms. average |  |
| [FindEllipseSegmentIntersections(0, 0, 2, 2, 1, 1, 3, 3, 5.6843418860808E-12)](#Orthogonal-Ellipse-Line-Segment-Intersection-Tests) | (False, , False, ) != True | 10000 in 18 ms. 0.0018 ms. average |  |
| [UnrotatedEllipseLineSegmentIntersection0(0, 0, 2, 2, 1, 1, 3, 3, 5.6843418860808E-12)](#Orthogonal-Ellipse-Line-Segment-Intersection-Tests) | Intersection{State:NoIntersection, Points:System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]] } != True | 10000 in 21 ms. 0.0021 ms. average |  |
| [UnrotatedEllipseLineSegmentIntersection2(0, 0, 2, 2, 1, 1, 3, 3, 5.6843418860808E-12)](#Orthogonal-Ellipse-Line-Segment-Intersection-Tests) | Intersection{State:Intersection, Points:System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]] } != True | 10000 in 19 ms. 0.0019 ms. average |  |

## The Code

The code for the methods tested follows below.

### Orthogonal Ellipse Line Segment Intersection Tests

Finds the intersection points of an Orthogonal Ellipse and a Line Segment Intersection.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (bool, (double, double)?, bool, (double, double)?) EllipseLineSegment(
            double cX, double cY,
            double rX, double rY,
            double x1, double y1,
            double x2, double y2,
            double epsilon = Epsilon)
        {
            double a;
            double b;
            double c;
            var m = 0d;

            // Check whether line is vertical.
            if (x1 != x2)
            {
                m = (y2 - y1) / (x2 - x1);
                var cc = y1 - m * x1;

                // Non-vertical line case.
                a = rY * rY + rX * rX * m * m;
                b = 2d * rX * rX * cc * m - 2d * rX * rX * cY * m - 2d * cX * rY * rY;
                c = rY * rY * cX * cX + rX * rX * cc * cc - 2 * rX * rX * cY * cc + rX * rX * cY * cY - rX * rX * rY * rY;
            }
            else
            {
                // vertical line case.
                a = rX * rX;
                b = -2d * cY * rX * rX;
                c = -rX * rX * rY * rY + rY * rY * (x1 - cX) * (x1 - cX);
            }

            var discriminant = b * b - 4d * a * c;

            if (discriminant == 0)
            {
                if (x1 != x2)
                {
                    var t = 0.5d * -b / a;
                    return ((t >= 0d) && (t <= 1d), (t, y1 + m * (t - x1)), false, null);
                }
                else
                {
                    var t = 0.5d * -b / a;
                    return ((t >= 0d) && (t <= 1d), (x1, t), false, null);
                }
            }
            else if (discriminant > 0d)
            {
                if (x1 != x2)
                {
                    var t1 = (-b + Sqrt(discriminant)) / (2d * a);
                    var t2 = (-b - Sqrt(discriminant)) / (2d * a);
                    return ((t1 >= 0d) && (t1 <= 1d), (t1, y1 + m * (t1 - x1)),
                            (t2 >= 0d) && (t2 <= 1d), (t2, y1 + m * (t2 - x1)));
                }
                else
                {
                    var t1 = (-b + Sqrt(discriminant)) / (2d * a);
                    var t2 = (-b - Sqrt(discriminant)) / (2d * a);
                    return ((t1 >= 0d) && (t1 <= 1d), (x1, t1),
                            (t2 >= 0d) && (t2 <= 1d), (x2, t2));
                }
            }
            else
            {
                // no intersections
                return (false, null, false, null);
            }
        }
```

### Orthogonal Ellipse Line Segment Intersection Tests

Finds the intersection points of an Orthogonal Ellipse and a Line Segment Intersection.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (bool, (double, double)?, bool, (double, double)?) FindEllipseSegmentIntersections(
                double cx, double cy,
                double rx, double ry,
                double x0, double y0,
                double x1, double y1,
                double epsilon = Epsilon)
        {
            // If the ellipse or line segment are empty, return no intersections.
            if ((cx == 0d) || (cy == 0d) ||
                ((x0 == x1) && (y0 == y1)))
            {
                return (false, null, false, null);
            }

            // Translate lines to meet the ellipse translated centered at the origin.
            var p1X = x0 - cx;
            var p1Y = y0 - cy;
            var p2X = x1 - cx;
            var p2Y = y1 - cy;

            // Calculate the quadratic parameters.
            var a = (p2X - p1X) * (p2X - p1X) / rx / rx + (p2Y - p1Y) * (p2Y - p1Y) / ry / ry;
            var b = 2d * p1X * (p2X - p1X) / rx / rx + 2 * p1Y * (p2Y - p1Y) / ry / ry;
            var c = p1X * p1X / rx / rx + p1Y * p1Y / ry / ry - 1d;

            // Calculate the discriminant.
            var discriminant = b * b - 4d * a * c;

            if (discriminant == 0)
            {
                // One real solution.
                var t = 0.5d * -b / a;

                // Return the point. If the point is on the segment set the bool to true.
                return ((t >= 0d) && (t <= 1d),
                        (p1X + (p2X - p1X) * t + cx,
                        p1Y + (p2Y - p1Y) * t + cy),
                        false, null);
            }
            else if (discriminant > 0)
            {
                // Two real solutions.
                var t1 = 0.5d * (-b + Sqrt(discriminant)) / a;
                var t2 = 0.5d * (-b - Sqrt(discriminant)) / a;

                // Return the points. If the points are on the segment set the bool to true.
                return ((t1 >= 0d) && (t1 <= 1d), (p1X + (p2X - p1X) * t1 + cx, p1Y + (p2Y - p1Y) * t1 + cy),
                        (t2 >= 0d) && (t2 <= 1d), (p1X + (p2X - p1X) * t2 + cx, p1Y + (p2Y - p1Y) * t2 + cy));
            }

            // Return the points.
            return (false, null, false, null);
        }
```

### Orthogonal Ellipse Line Segment Intersection Tests

Finds the intersection points of an Orthogonal Ellipse and a Line Segment Intersection.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection UnrotatedEllipseLineSegmentIntersection0(
            double centerX, double centerY,
            double rx, double ry,
            double a1X, double a1Y,
            double a2X, double a2Y,
            double epsilon = Epsilon)
        {
            var result = new Intersection(IntersectionState.NoIntersection);
            var origin = new Vector2D(a1X, a1Y);
            var dir = new Vector2D(a1X, a1Y, a2X, a2Y);
            var diff = origin - new Vector2D(centerX, centerY);
            var mDir = new Vector2D(dir.I / (rx * rx), dir.J / (ry * ry));
            var mDiff = new Vector2D(diff.I / (rx * rx), diff.J / (ry * ry));
            var a = DotProduct2Vector2DTests.DotProduct2D(dir.I, dir.J, mDir.I, mDir.J);
            var b = DotProduct2Vector2DTests.DotProduct2D(dir.I, dir.J, mDiff.I, mDiff.J);
            var c = DotProduct2Vector2DTests.DotProduct2D(diff.I, diff.J, mDiff.I, mDiff.J) - 1d;
            var d = b * b - a * c;
            if (d < 0)
            {
                result = new Intersection(IntersectionState.Outside);
            }
            else if (d > 0)
            {
                var root = Sqrt(d);
                var t_a = (-b - root) / a;
                var t_b = (-b + root) / a;
                if ((t_a < 0 || 1 < t_a) && (t_b < 0 || 1 < t_b))
                {
                    result = (t_a < 0 && t_b < 0) || (t_a > 1 && t_b > 1) ? new Intersection(IntersectionState.Outside) : new Intersection(IntersectionState.Inside);
                }
                else
                {
                    result = new Intersection(IntersectionState.Intersection);
                    if (0 <= t_a && t_a <= 1)
                    {
                        result.AppendPoint(InterpolateLinear2DTests.LinearInterpolate2D(a1X, a1Y, a2X, a2Y, t_a));
                    }

                    if (0 <= t_b && t_b <= 1)
                    {
                        result.AppendPoint(InterpolateLinear2DTests.LinearInterpolate2D(a1X, a1Y, a2X, a2Y, t_b));
                    }
                }
            }
            else
            {
                var t = -b / a; if (0 <= t && t <= 1)
                {
                    result = new Intersection(IntersectionState.Intersection);
                    result.AppendPoint(InterpolateLinear2DTests.LinearInterpolate2D(a1X, a1Y, a2X, a2Y, t));
                }
                else
                {
                    result = new Intersection(IntersectionState.Outside);
                }
            }

            return result;
        }
```

### Orthogonal Ellipse Line Segment Intersection Tests

Finds the intersection points of an Orthogonal Ellipse and a Line Segment Intersection.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection UnrotatedEllipseLineSegmentIntersection2(
            double cx, double cy,
            double rx, double ry,
            double x0, double y0,
            double x1, double y1,
            double epsilon = Epsilon)
        {
            var result = new Intersection(IntersectionState.NoIntersection);

            // If the ellipse or line segment are empty, return no intersections.
            if ((rx == 0d) || (ry == 0d) ||
                ((x0 == x1) && (y0 == y1)))
            {
                return result;
            }

            // Translate the line to put the ellipse centered at the origin.
            var u1 = x0 - cx;
            var v1 = y0 - cy;
            var u2 = x1 - cx;
            var v2 = y1 - cy;

            // Calculate the quadratic parameters.
            var a = (u2 - u1) * (u2 - u1) / (rx * rx) + (v2 - v1) * (v2 - v1) / (ry * ry);
            var b = 2d * u1 * (u2 - u1) / (rx * rx) + 2d * v1 * (v2 - v1) / (ry * ry);
            var c = u1 * u1 / (rx * rx) + v1 * v1 / (ry * ry) - 1d;

            // Calculate the discriminant.
            var discriminant = b * b - 4d * a * c;

            if ((a <= epsilon) || (discriminant < 0))
            {
                // No real solutions.
            }
            else if (discriminant == 0)
            {
                // One real possible solution.
                var t = 0.5d * -b / a;

                // Add the points if it is between the end points of the line segment.
                if ((t >= 0d) && (t <= 1d))
                {
                    result.AppendPoint(new Point2D(u1 + (u2 - u1) * t + cx, v1 + (v2 - v1) * t + cy));
                    result.State = IntersectionState.Intersection;
                }
            }
            else if (discriminant > 0)
            {
                // Two real possible solutions.
                var t1 = 0.5d * (-b + Sqrt(discriminant)) / a;
                var t2 = 0.5d * (-b - Sqrt(discriminant)) / a;

                // Add the points if they are between the end points of the line segment.
                if ((t1 >= 0d) && (t1 <= 1d))
                {
                    result.AppendPoint(new Point2D(u1 + (u2 - u1) * t1 + cx, v1 + (v2 - v1) * t1 + cy));
                    result.State = IntersectionState.Intersection;
                }

                if ((t2 >= 0d) && (t2 <= 1d))
                {
                    result.AppendPoint(new Point2D(u1 + (u2 - u1) * t2 + cx, v1 + (v2 - v1) * t2 + cy));
                    result.State = IntersectionState.Intersection;
                }
            }

            return result;
        }
```

