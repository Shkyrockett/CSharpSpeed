# Intersection of Two Circles

Find the intersection points of two Circles.

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

../../InstrumentedLibrary/Geometry/Intersections/CircleCircleIntersectionTests.cs

The required method signature for this API is as follows:

```CSharp
public static (int, (double X, double Y), (double X, double Y)) FindCircleCircleIntersections(double cx0, double cy0, double radius0, double cx1, double cy1, double radius1, double epsilon = Epsilon)
```

## Test Case Index

- [Test Case: (1, 1, 1, 1.5, 1, 1, 5.6843418860808E-12)](#1,-1,-1,-1.5,-1,-1,-5.6843418860808E-12)

### (1, 1, 1, 1.5, 1, 1, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [FindCircleCircleIntersections_(1, 1, 1, 1.5, 1, 1, 5.6843418860808E-12)](#Circle,-circle-Intersection) | (2, (1.25, 0.0317541634481457), (1.25, 1.96824583655185)) != Intersection{State:NoIntersection, Points: } | 10000 in 17 ms. 0.0017 ms. average | Cubic Bezier Cubic Bezier intersection. |

## The Code

The code for the methods tested follows below.

### Circle, circle Intersection

Find the intersection between two Circles.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (int, (double X, double Y), (double X, double Y)) FindCircleCircleIntersections_(
            double cx0, double cy0, double radius0,
            double cx1, double cy1, double radius1,
            double epsilon = Epsilon)
        {
            // Find the distance between the centers.
            var dx = cx0 - cx1;
            var dy = cy0 - cy1;
            var dist = Sqrt((dx * dx) + (dy * dy));

            (double X, double Y) intersection1;
            (double X, double Y) intersection2;

            // See how many solutions there are.
            if (dist > radius0 + radius1)
            {
                // No solutions, the circles are too far apart.
                intersection1 = (double.NaN, double.NaN);
                intersection2 = (double.NaN, double.NaN);
                return (0, intersection1, intersection2);
            }
            else if (dist < Abs(radius0 - radius1))
            {
                // No solutions, one circle contains the other.
                intersection1 = (double.NaN, double.NaN);
                intersection2 = (double.NaN, double.NaN);
                return (0, intersection1, intersection2);
            }
            else if ((Abs(dist) < DoubleEpsilon) && (Abs(radius0 - radius1) < DoubleEpsilon))
            {
                // No solutions, the circles coincide.
                intersection1 = (double.NaN, double.NaN);
                intersection2 = (double.NaN, double.NaN);
                return (0, intersection1, intersection2);
            }
            else
            {
                // Find a and h.
                var a = ((radius0 * radius0)
                    - (radius1 * radius1) + (dist * dist)) / (2 * dist);
                var h = Sqrt((radius0 * radius0) - (a * a));

                // Find P2.
                var cx2 = cx0 + (a * (cx1 - cx0) / dist);
                var cy2 = cy0 + (a * (cy1 - cy0) / dist);

                // Get the points P3.
                intersection1 = (
                    cx2 + (h * (cy1 - cy0) / dist),
                    cy2 - (h * (cx1 - cx0) / dist));
                intersection2 = (
                    cx2 - (h * (cy1 - cy0) / dist),
                    cy2 + (h * (cx1 - cx0) / dist));

                // See if we have 1 or 2 solutions.
                if (Abs(dist - radius0 + radius1) < DoubleEpsilon)
                {
                    return (1, intersection1, intersection2);
                }

                return (2, intersection1, intersection2);
            }
        }
```

