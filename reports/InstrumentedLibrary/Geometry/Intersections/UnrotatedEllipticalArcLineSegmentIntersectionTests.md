# Intersection of unrotated elliptical arc and line segment

Find the intersection points between unrotated elliptical and arc line segment.

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

../../InstrumentedLibrary/Geometry/Intersections/UnrotatedEllipticalArcLineSegmentIntersectionTests.cs

The required method signature for this API is as follows:

```CSharp
public static Intersection UnrotatedEllipticalArcLineSegmentIntersection(double cx, double cy, double rx, double ry, double startAngle, double sweepAngle, double x0, double y0, double x1, double y1, double epsilon = Epsilon)
```

## Test Case Index

- [Test Case: (0, 0, 2, 2, 0, 0.785398163397448, 2, 2, 1, 1, 5.6843418860808E-12)](#0,-0,-2,-2,-0,-0.785398163397448,-2,-2,-1,-1,-5.6843418860808E-12)

### (0, 0, 2, 2, 0, 0.785398163397448, 2, 2, 1, 1, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [UnrotatedEllipticalArcLineSegmentIntersection0(0, 0, 2, 2, 0, 0.785398163397448, 2, 2, 1, 1, 5.6843418860808E-12)](#Intersection-of-unrotated-elliptical-arc-and-line-segment) | Intersection{State:NoIntersection, Points:System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]] } != Intersection{State:NoIntersection, Points: } | 10000 in 22 ms. 0.0022 ms. average | Line Segment Line Segment intersection. |

## The Code

The code for the methods tested follows below.

### Intersection of unrotated elliptical arc and line segment

Find the intersection points between unrotated elliptical and arc line segment.  
- [http://www.kevlindev.com/](http://www.kevlindev.com/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection UnrotatedEllipticalArcLineSegmentIntersection0(
            double cx, double cy,
            double rx, double ry,
            double startAngle, double sweepAngle,
            double x0, double y0,
            double x1, double y1, double epsilon = Epsilon)
        {
            // Initialize the resulting intersection structure.
            var result = new Intersection(IntersectionState.NoIntersection);

            // Translate the line to put the ellipse centered at the origin.
            var origin = new Vector2D(x0, y0);
            var dir = new Vector2D(x0, y0, x1, y1);
            var diff = origin - new Vector2D(cx, cy);
            var mDir = new Vector2D(dir.I / (rx * rx), dir.J / (ry * ry));
            var mDiff = new Vector2D(diff.I / (rx * rx), diff.J / (ry * ry));

            // Calculate the quadratic parameters.
            var a = DotProduct2Vector2DTests.DotProduct2D(dir.I, dir.J, mDir.I, mDir.J);
            var b = DotProduct2Vector2DTests.DotProduct2D(dir.I, dir.J, mDiff.I, mDiff.J);
            var c = DotProduct2Vector2DTests.DotProduct2D(diff.I, diff.J, mDiff.I, mDiff.J) - 1d;

            // Calculate the discriminant of the quadratic. The 4 is omitted.
            var discriminant = b * b - a * c;

            // Check whether line segment is outside of the ellipse.
            if (discriminant < 0)
            {
                return new Intersection(IntersectionState.Outside);
            }

            // Find the start and end angles.
            var sa = EllipticalPolarAngleTests.EllipticalPolarAngle(startAngle, rx, ry);
            var ea = EllipticalPolarAngleTests.EllipticalPolarAngle(startAngle + sweepAngle, rx, ry);

            // Get the ellipse rotation transform.
            var cosT = Cos(0);
            var sinT = Sin(0);

            // Ellipse equation for an ellipse at origin for the chord end points.
            var u1 = rx * Cos(sa);
            var v1 = -(ry * Sin(sa));
            var u2 = rx * Cos(ea);
            var v2 = -(ry * Sin(ea));

            // Find the points of the chord.
            var sX = cx + (u1 * cosT + v1 * sinT);
            var sY = cy + (u1 * sinT - v1 * cosT);
            var eX = cx + (u2 * cosT + v2 * sinT);
            var eY = cy + (u2 * sinT - v2 * cosT);

            if (discriminant > 0)
            {
                // Two real possible solutions.
                var root = Sqrt(discriminant);
                var t1 = (-b - root) / a;
                var t2 = (-b + root) / a;
                if ((t1 < 0 || 1 < t1) && (t2 < 0 || 1 < t2))
                {
                    result = (t1 < 0 && t2 < 0) || (t1 > 1 && t2 > 1) ? new Intersection(IntersectionState.Outside) : new Intersection(IntersectionState.Inside);
                }
                else
                {
                    var p = InterpolateLinear2DTests.LinearInterpolate2D(x0, y0, x1, y1, t1);
                    // Find the determinant of the chord.
                    var determinant = (sX - p.X) * (eY - p.Y) - (eX - p.X) * (sY - p.Y);

                    // Check whether the point is on the side of the chord as the center.
                    if (0 <= t1 && t1 <= 1 && (Sign(determinant) != Sign(sweepAngle)))
                    {
                        result.AppendPoint(p);
                    }

                    p = InterpolateLinear2DTests.LinearInterpolate2D(x0, y0, x1, y1, t2);
                    // Find the determinant of the chord.
                    determinant = (sX - p.X) * (eY - p.Y) - (eX - p.X) * (sY - p.Y);
                    if (0 <= t2 && t2 <= 1 && (Sign(determinant) != Sign(sweepAngle)))
                    {
                        result.AppendPoint(p);
                    }
                }
            }
            else // discriminant == 0.
            {
                // One real possible solution.
                var t = -b / a;
                if (t >= 0d && t <= 1d)
                {
                    var p = InterpolateLinear2DTests.LinearInterpolate2D(x0, y0, x1, y1, t);

                    // Find the determinant of the matrix representing the chord.
                    var determinant = (sX - p.X) * (eY - p.Y) - (eX - p.X) * (sY - p.Y);

                    // Add the point if it is on the sweep side of the chord.
                    if (Sign(determinant) != Sign(sweepAngle))
                    {
                        result.AppendPoint(InterpolateLinear2DTests.LinearInterpolate2D(x0, y0, x1, y1, t));
                    }
                }
                else
                {
                    result = new Intersection(IntersectionState.Outside);
                }
            }

            if (result.Count > 0)
            {
                result.State |= IntersectionState.Intersection;
            }

            return result;
        }
```

