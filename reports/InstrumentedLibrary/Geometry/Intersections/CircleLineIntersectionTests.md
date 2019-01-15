# Intersection of Circle and Line

Finds the intersection points of a circle and a line.

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

../../InstrumentedLibrary/Geometry/Intersections/CircleLineIntersectionTests.cs

The required method signature for this API is as follows:

```CSharp
public static Intersection CircleLineSegmentIntersection(double cX, double cY, double radius, double lAX, double lAY, double lBX, double lBY, double epsilon = Epsilon)
```

## Test Case Index

- [Test Case: (1, 1, 2, 1.5, 1.5, 3, 3, 5.6843418860808E-12)](#1,-1,-2,-1.5,-1.5,-3,-3,-5.6843418860808E-12)

### (1, 1, 2, 1.5, 1.5, 3, 3, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CircleLineIntersection(1, 1, 2, 1.5, 1.5, 3, 3, 5.6843418860808E-12)](#Intersection-of-Circle-and-Line) | Intersection{State:NoIntersection, Points:System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]] } != 15 | 10000 in 16 ms. 0.0016 ms. average |  |
| [LineCircle(1, 1, 2, 1.5, 1.5, 3, 3, 5.6843418860808E-12)](#Intersection-of-Circle-and-Line) | Intersection{State:NoIntersection, Points:System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]] } != 15 | 10000 in 18 ms. 0.0018 ms. average |  |

## The Code

The code for the methods tested follows below.

### Intersection of Circle and Line

Finds the intersection points of a circle and a line.  
- [http://csharphelper.com/blog/2014/09/determine-where-a-line-intersects-a-circle-in-c/](http://csharphelper.com/blog/2014/09/determine-where-a-line-intersects-a-circle-in-c/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection CircleLineIntersection(
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
            var discriminant = b * b - 4 * a * c;

            if ((a <= Epsilon) || (discriminant < 0))
            {
                // No real solutions.
            }
            else if (discriminant == 0)
            {
                // One possible solution.
                var t = -b / (2 * a);

                // Add the points.
                result = new Intersection(IntersectionState.Intersection);
                result.AppendPoint(new Point2D(lAX + t * dx, lAY + t * dy));
            }
            else if (discriminant > 0)
            {
                // Two possible solutions.
                var t1 = (-b + Sqrt(discriminant)) / (2 * a);
                var t2 = (-b - Sqrt(discriminant)) / (2 * a);

                // Add the points.
                result = new Intersection(IntersectionState.Intersection);
                result.AppendPoint(new Point2D(lAX + t1 * dx, lAY + t1 * dy));
                result.AppendPoint(new Point2D(lAX + t2 * dx, lAY + t2 * dy));
            }

            return result;
        }
```

### Intersection of Circle and Line

Finds the intersection points of a circle and a line.  
- [http://csharphelper.com/blog/2014/09/determine-where-a-line-intersects-a-circle-in-c/](http://csharphelper.com/blog/2014/09/determine-where-a-line-intersects-a-circle-in-c/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection LineCircle(
            double cX, double cY,
            double radius,
            double lAX, double lAY,
            double lBX, double lBY,
            double epsilon = Epsilon)
        {
            double t;

            var dx = lBX - lAX;
            var dy = lBY - lAY;

            var A = dx * dx + dy * dy;
            var B = 2d * (dx * (lAX - cX) + dy * (lAY - cY));
            var C = (lAX - cX) * (lAX - cX) + (lAY - cY) * (lAY - cY) - radius * radius;

            var det = B * B - 4 * A * C;
            if ((A <= epsilon) || (det < 0))
            {
                // No real solutions.
                return new Intersection(IntersectionState.NoIntersection);
            }
            else if (Abs(det) < DoubleEpsilon)
            {
                // One solution.
                t = -B / (2 * A);
                var intersection = new Intersection(IntersectionState.Intersection);
                intersection.AppendPoint((lAX + t * dx, lAY + t * dy));
                return intersection;
            }
            else
            {
                // Two solutions.
                var intersection = new Intersection(IntersectionState.Intersection);
                t = (-B + Sqrt(det)) / (2d * A);
                intersection.AppendPoint((lAX + t * dx, lAY + t * dy));
                t = (-B - Sqrt(det)) / (2d * A);
                intersection.AppendPoint((lAX + t * dx, lAY + t * dy));
                return intersection;
            }
        }
```

