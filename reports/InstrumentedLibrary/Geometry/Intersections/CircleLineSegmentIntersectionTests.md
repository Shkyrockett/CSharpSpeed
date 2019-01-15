# Intersection of Circle and Line Segment

Finds the intersection points of a circle and a line segment.

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

../../InstrumentedLibrary/Geometry/Intersections/CircleLineSegmentIntersectionTests.cs

The required method signature for this API is as follows:

```CSharp
public static Intersection CircleLineSegmentIntersection(double cX, double cY, double r, double lAX, double lAY, double lBX, double lBY, double epsilon = Epsilon)
```

## Test Case Index

- [Test Case: (1, 1, 2, 1.5, 1.5, 3, 3, 5.6843418860808E-12)](#1,-1,-2,-1.5,-1.5,-3,-3,-5.6843418860808E-12)

### (1, 1, 2, 1.5, 1.5, 3, 3, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CircleLineSegmentIntersection1(1, 1, 2, 1.5, 1.5, 3, 3, 5.6843418860808E-12)](#Intersection-of-Circle-and-Line-Segment) | Intersection{State:NoIntersection, Points:System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]] } != 15 | 10000 in 18 ms. 0.0018 ms. average |  |
| [CircleLineSegmentIntersectionKevLinDev(1, 1, 2, 1.5, 1.5, 3, 3, 5.6843418860808E-12)](#Intersection-of-Circle-and-Line-Segment) | Intersection{State:NoIntersection, Points:System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]] } != 15 | 10000 in 14 ms. 0.0014 ms. average |  |

## The Code

The code for the methods tested follows below.

### Intersection of Circle and Line Segment

Finds the intersection points of a circle and a line segment.  
- [http://csharphelper.com/blog/2014/09/determine-where-a-line-intersects-a-circle-in-c/](http://csharphelper.com/blog/2014/09/determine-where-a-line-intersects-a-circle-in-c/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection CircleLineSegmentIntersection1(
            double cX, double cY,
            double r,
            double lAX, double lAY,
            double lBX, double lBY,
            double epsilon = Epsilon)
        {
            var result = new Intersection(IntersectionState.NoIntersection);

            // If the circle or line segment are empty, return no intersections.
            if ((r == 0d) || ((lAX == lBX) && (lAY == lBY)))
            {
                return result;
            }

            var dx = lBX - lAX;
            var dy = lBY - lAY;

            // Calculate the quadratic parameters.
            var a = dx * dx + dy * dy;
            var b = 2 * (dx * (lAX - cX) + dy * (lAY - cY));
            var c = (lAX - cX) * (lAX - cX) + (lAY - cY) * (lAY - cY) - r * r;

            // Calculate the discriminant.
            var discriminant = b * b - 4d * a * c;

            if ((a <= Epsilon) || (discriminant < 0))
            {
                // No real solutions.
            }
            else if (discriminant == 0)
            {
                // One possible solution.
                var t = -b / (2 * a);

                // Add the points if they are between the end points of the line segment.
                if ((t >= 0d) && (t <= 1d))
                {
                    result = new Intersection(IntersectionState.Intersection);
                    result.AppendPoint(new Point2D(lAX + t * dx, lAY + t * dy));
                }
            }
            else if (discriminant > 0)
            {
                // Two possible solutions.
                var t1 = (-b + Sqrt(discriminant)) / (2 * a);
                var t2 = (-b - Sqrt(discriminant)) / (2 * a);

                // Add the points if they are between the end points of the line segment.
                result = new Intersection(IntersectionState.Intersection);
                if ((t1 >= 0d) && (t1 <= 1d))
                {
                    result.AppendPoint(new Point2D(lAX + t1 * dx, lAY + t1 * dy));
                }

                if ((t2 >= 0d) && (t2 <= 1d))
                {
                    result.AppendPoint(new Point2D(lAX + t2 * dx, lAY + t2 * dy));
                }
            }

            return result;
        }
```

### Intersection of Circle and Line Segment

Finds the intersection points of a circle and a line segment.  
- [http://www.kevlindev.com/](http://www.kevlindev.com/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection CircleLineSegmentIntersectionKevLinDev(
            double cX, double cY,
            double r,
            double lAX, double lAY,
            double lBX, double lBY,
            double epsilon = Epsilon)
        {
            Intersection result;

            var a = (lBX - lAX) * (lBX - lAX) + (lBY - lAY) * (lBY - lAY);
            var b = 2 * ((lBX - lAX) * (lAX - cX) + (lBY - lAY) * (lAY - cY));
            var c = cX * cX + cY * cY + lAX * lAX + lAY * lAY - 2 * (cX * lAX + cY * lAY) - r * r;

            var determinant = b * b - 4 * a * c;
            if (determinant < 0)
            {
                result = new Intersection(IntersectionState.Outside);
            }
            else if (determinant == 0)
            {
                result = new Intersection(IntersectionState.Tangent | IntersectionState.Intersection);
                var u1 = (-b) / (2 * a);
                if (u1 < 0 || u1 > 1)
                {
                    result = (u1 < 0) || (u1 > 1) ? new Intersection(IntersectionState.Outside) : new Intersection(IntersectionState.Inside);
                }
                else
                {
                    result = new Intersection(IntersectionState.Intersection);
                    if (0 <= u1 && u1 <= 1)
                    {
                        result.Points.Add(InterpolateLinear2DTests.LinearInterpolate2D(lAX, lAY, lBX, lBY, u1));
                    }
                }
            }
            else
            {
                var e = Sqrt(determinant);
                var u1 = (-b + e) / (2 * a);
                var u2 = (-b - e) / (2 * a);
                if ((u1 < 0 || u1 > 1) && (u2 < 0 || u2 > 1))
                {
                    result = (u1 < 0 && u2 < 0) || (u1 > 1 && u2 > 1) ? new Intersection(IntersectionState.Outside) : new Intersection(IntersectionState.Inside);
                }
                else
                {
                    result = new Intersection(IntersectionState.Intersection);
                    if (0 <= u1 && u1 <= 1)
                    {
                        result.Points.Add(InterpolateLinear2DTests.LinearInterpolate2D(lAX, lAY, lBX, lBY, u1));
                    }

                    if (0 <= u2 && u2 <= 1)
                    {
                        result.Points.Add(InterpolateLinear2DTests.LinearInterpolate2D(lAX, lAY, lBX, lBY, u2));
                    }
                }
            }
            return result;
        }
```

