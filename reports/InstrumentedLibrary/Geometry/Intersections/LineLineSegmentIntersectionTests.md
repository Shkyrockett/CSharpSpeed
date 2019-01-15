# Intersection of a line and a line segment

Find the intersection between a line and a line segment.

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

../../InstrumentedLibrary/Geometry/Intersections/LineLineSegmentIntersectionTests.cs

The required method signature for this API is as follows:

```CSharp
public static Intersection LineLineSegmentIntersection(double a1X, double a1Y, double a2X, double a2Y, double b1X, double b1Y, double b2X, double b2Y, double epsilon = Epsilon)
```

## Test Case Index

- [Test Case: (0, 0, 2, 2, 0, 2, 2, 0, 5.6843418860808E-12)](#0,-0,-2,-2,-0,-2,-2,-0,-5.6843418860808E-12)

### (0, 0, 2, 2, 0, 2, 2, 0, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [LineLineSegmentIntersection0(0, 0, 2, 2, 0, 2, 2, 0, 5.6843418860808E-12)](#Intersection-of-a-line-and-a-line-segment) | Intersection{State:NoIntersection, Points:System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]] } != Intersection{State:NoIntersection, Points: } | 10000 in 18 ms. 0.0018 ms. average | Line Segment Line Segment intersection. |
| [LineLineSegmentIntersection1(0, 0, 2, 2, 0, 2, 2, 0, 5.6843418860808E-12)](#Intersection-of-a-line-and-a-line-segment) | Intersection{State:NoIntersection, Points:System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]] } != Intersection{State:NoIntersection, Points: } | 10000 in 25 ms. 0.0025 ms. average | Line Segment Line Segment intersection. |
| [LineLineSegmentIntersection2(0, 0, 2, 2, 0, 2, 2, 0, 5.6843418860808E-12)](#Intersection-of-a-line-and-a-line-segment) | Intersection{State:NoIntersection, Points:System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]] } != Intersection{State:NoIntersection, Points: } | 10000 in 19 ms. 0.0019 ms. average | Line Segment Line Segment intersection. |

## The Code

The code for the methods tested follows below.

### Intersection of a line and a line segment

Find the intersection between a line and a line segment.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection LineLineSegmentIntersection0(
            double aX, double aY, // Line
            double bX, double bY,
            double cX, double cY,  // Segment
            double dX, double dY,
            double epsilon = Epsilon)
        {
            //test for parallel case
            var denom = (dY - cY) * (bX - aX) - (dX - cX) * (bY - aY);
            if (Abs(denom) < epsilon)
            {
                return new Intersection(IntersectionState.NoIntersection);
            }

            //calculate segment parameter and ensure its within bounds
            var t = ((bX - aX) * (aY - cY) - (bY - aY) * (aX - cX)) / denom;
            if (t < 0d || t > 1d)
            {
                return new Intersection(IntersectionState.NoIntersection);
            }

            //store actual intersection
            var result = new Intersection(IntersectionState.Intersection);
            result.AppendPoint(new Point2D(cX + (dX - cX) * t, cY + (dY - cY) * t));
            return result;

        }
```

### Intersection of a line and a line segment

Find the intersection between a line and a line segment.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection LineLineSegmentIntersection1(
            double a1X, double a1Y,
            double a2X, double a2Y,
            double b1X, double b1Y,
            double b2X, double b2Y,
            double epsilon = Epsilon)
        {
            Intersection result;
            var ua_t = (b2X - b1X) * (a1Y - b1Y) - (b2Y - b1Y) * (a1X - b1X);
            var ub_t = (a2X - a1X) * (a1Y - b1Y) - (a2Y - a1Y) * (a1X - b1X);
            var u_b = (b2Y - b1Y) * (a2X - a1X) - (b2X - b1X) * (a2Y - a1Y);
            if (u_b != 0)
            {
                var ua = ua_t / u_b;
                var ub = ub_t / u_b;
                if (//true
                    //0 <= ua && ua <= 1
                    //&&
                    0 <= ub && ub <= 1
                    )
                {
                    result = new Intersection(IntersectionState.Intersection);
                    result.AppendPoint(new Point2D(a1X + ua * (a2X - a1X), a1Y + ua * (a2Y - a1Y)));
                    //result.AppendPoint(new Point2D(b1X + ub * (b2X - b1X), b1Y + ub * (b2Y - b1Y)));
                }
                else
                {
                    result = new Intersection(IntersectionState.NoIntersection);
                }
            }
            else
            {
                if (ua_t == 0 || ub_t == 0)
                {
                    result = new Intersection(IntersectionState.Coincident | IntersectionState.Parallel | IntersectionState.Intersection);
                    result.AppendPoints(new List<(double X, double Y)> { (b1X, b1Y), (b2X, b2Y) });
                }
                else
                {
                    result = new Intersection(IntersectionState.Parallel | IntersectionState.NoIntersection);
                }
            }
            return result;
        }
```

### Intersection of a line and a line segment

Find the intersection between a line and a line segment.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection LineLineSegmentIntersection2(
            double x0, double y0,
            double x1, double y1,
            double x2, double y2,
            double x3, double y3,
            double epsilon = Epsilon)
        {
            var result = new Intersection(IntersectionState.NoIntersection);

            // Translate lines to origin.
            var u1 = x1 - x0;
            var v1 = y1 - y0;
            var u2 = x3 - x2;
            var v2 = y3 - y2;

            // Calculate the determinant of the coefficient matrix.
            var determinant = (v2 * u1) - (u2 * v1);

            // Check if the lines are parallel or coincident.
            if (Abs(determinant) < Epsilon)
            {
                return result;
            }

            // Find the index where the intersection point lies on the line.
            //var s = ((x0 - x2) * v1 + (y2 - y0) * u1) / -determinant;
            var t = ((x2 - x0) * v2 + (y0 - y2) * u2) / determinant;

            // Check whether the point is on the segment.
            if (t >= 0d && t <= 1d)
            {
                result = new Intersection(IntersectionState.Intersection);
                result.AppendPoint(new Point2D(x0 + t * u1, y0 + t * v1));
            }

            return result;
        }
```

