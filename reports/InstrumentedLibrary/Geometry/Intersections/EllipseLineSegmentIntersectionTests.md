# Ellipse Line Segment Intersection Tests

Finds the intersection points of an Ellipse and a Line Segment Intersection.

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

../../InstrumentedLibrary/Geometry/Intersections/EllipseLineSegmentIntersectionTests.cs

The required method signature for this API is as follows:

```CSharp
public static Intersection EllipseLineSegmentIntersection(double cx, double cy, double rx, double ry, double angle, double x0, double y0, double x1, double y1, double epsilon = Epsilon)
```

## Test Case Index

- [Test Case: (0, 0, 2, 2, 0, 1, 1, 3, 3, 5.6843418860808E-12)](#0,-0,-2,-2,-0,-1,-1,-3,-3,-5.6843418860808E-12)

### (0, 0, 2, 2, 0, 1, 1, 3, 3, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [EllipseLineSegmentIntersection_(0, 0, 2, 2, 0, 1, 1, 3, 3, 5.6843418860808E-12)](#Orthogonal-Ellipse-Line-Segment-Intersection-Tests) | Intersection{State:Intersection, Points:System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]] } != True | 10000 in 25 ms. 0.0025 ms. average |  |

## The Code

The code for the methods tested follows below.

### Orthogonal Ellipse Line Segment Intersection Tests

Finds the intersection points of an Orthogonal Ellipse and a Line Segment Intersection.  
- [http://csharphelper.com/blog/2012/09/calculate-where-a-line-segment-and-an-ellipse-intersect-in-c/](http://csharphelper.com/blog/2012/09/calculate-where-a-line-segment-and-an-ellipse-intersect-in-c/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection EllipseLineSegmentIntersection_(
            double cx, double cy,
            double rx, double ry,
            double angle,
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

            // Get the Sine and Cosine of the angle.
            var sinA = Sin(angle);
            var cosA = Cos(angle);

            // Translate the line to put the ellipse centered at the origin.
            var u1 = x0 - cx;
            var v1 = y0 - cy;
            var u2 = x1 - cx;
            var v2 = y1 - cy;

            // Apply Rotation Transform to line at the origin.
            var u1A = 0 + (u1 * cosA - v1 * sinA);
            var v1A = 0 + (u1 * sinA + v1 * cosA);
            var u2A = 0 + (u2 * cosA - v2 * sinA);
            var v2A = 0 + (u2 * sinA + v2 * cosA);

            // Calculate the quadratic parameters.
            var a = (u2A - u1A) * (u2A - u1A) / (rx * rx) + (v2A - v1A) * (v2A - v1A) / (ry * ry);
            var b = 2d * u1A * (u2A - u1A) / (rx * rx) + 2d * v1A * (v2A - v1A) / (ry * ry);
            var c = u1A * u1A / (rx * rx) + v1A * v1A / (ry * ry) - 1d;

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

                // Add the point if it is between the end points of the line segment.
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

                // ToDo: Figure out why the results are weird between 30 degrees and 5 degrees.
            }

            return result;
        }
```

