# Intersection of Two Line Segments

Find the intersection points of two line segments.

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

../../InstrumentedLibrary/Geometry/Intersections/LineSegmentLineSegmentIntersectionTests.cs

The required method signature for this API is as follows:

```CSharp
public static (bool intersects, (double X, double Y)? point) LineSegmentLineSegmentIntersection(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4, double epsilon = Epsilon)
```

## Test Case Index

- [Test Case: (0, 0, 2, 2, 0, 2, 2, 0, 5.6843418860808E-12)](#0,-0,-2,-2,-0,-2,-2,-0,-5.6843418860808E-12)

### (0, 0, 2, 2, 0, 2, 2, 0, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [FindIntersection(0, 0, 2, 2, 0, 2, 2, 0, 5.6843418860808E-12)](#Intersection-of-Two-Line-Segments) | (True, (1, 1)) != Intersection{State:NoIntersection, Points: } | 10000 in 10 ms. 0.001 ms. average | Line Segment Line Segment intersection. |
| [Intersection0(0, 0, 2, 2, 0, 2, 2, 0, 5.6843418860808E-12)](#Intersection-of-Two-Line-Segments) | (True, (1, 1)) != Intersection{State:NoIntersection, Points: } | 10000 in 15 ms. 0.0015 ms. average | Line Segment Line Segment intersection. |
| [Intersection1(0, 0, 2, 2, 0, 2, 2, 0, 5.6843418860808E-12)](#Intersection-of-Two-Line-Segments) | (True, (1, 1)) != Intersection{State:NoIntersection, Points: } | 10000 in 13 ms. 0.0013 ms. average | Line Segment Line Segment intersection. |
| [Intersection2(0, 0, 2, 2, 0, 2, 2, 0, 5.6843418860808E-12)](#Intersection-of-Two-Line-Segments) | (True, (1, 1)) != Intersection{State:NoIntersection, Points: } | 10000 in 13 ms. 0.0013 ms. average | Line Segment Line Segment intersection. |
| [Intersection3(0, 0, 2, 2, 0, 2, 2, 0, 5.6843418860808E-12)](#Intersection-of-Two-Line-Segments) | (True, (1, 1)) != Intersection{State:NoIntersection, Points: } | 10000 in 16 ms. 0.0016 ms. average | Line Segment Line Segment intersection. |
| [Intersection4(0, 0, 2, 2, 0, 2, 2, 0, 5.6843418860808E-12)](#Intersection-of-Two-Line-Segments) | (True, (1, 1)) != Intersection{State:NoIntersection, Points: } | 10000 in 13 ms. 0.0013 ms. average | Line Segment Line Segment intersection. |
| [Intersection5(0, 0, 2, 2, 0, 2, 2, 0, 5.6843418860808E-12)](#Intersection-of-Two-Line-Segments) | (True, (1, 1)) != Intersection{State:NoIntersection, Points: } | 10000 in 18 ms. 0.0018 ms. average | Line Segment Line Segment intersection. |
| [IntersectLineLine(0, 0, 2, 2, 0, 2, 2, 0, 5.6843418860808E-12)](#Intersection-of-Two-Line-Segments) | System.Collections.Generic.List`1[InstrumentedLibrary.Point2D] != Intersection{State:NoIntersection, Points: } | 10000 in 26 ms. 0.0026 ms. average | Line Segment Line Segment intersection. |
| [LineIntersection(0, 0, 2, 2, 0, 2, 2, 0, 5.6843418860808E-12)](#Intersection-of-Two-Line-Segments) | (True, (1, 1)) != Intersection{State:NoIntersection, Points: } | 10000 in 21 ms. 0.0021 ms. average | Line Segment Line Segment intersection. |
| [LineSegmentIntersection(0, 0, 2, 2, 0, 2, 2, 0, 5.6843418860808E-12)](#Intersection-of-Two-Line-Segments) | (True, (1, 1)) != Intersection{State:NoIntersection, Points: } | 10000 in 16 ms. 0.0016 ms. average | Line Segment Line Segment intersection. |

## The Code

The code for the methods tested follows below.

### Intersection of Two Line Segments

Find the intersection between two Line Segments.  
- [http://csharphelper.com/blog/2014/07/perform-geometric-operations-on-polygons-in-c/](http://csharphelper.com/blog/2014/07/perform-geometric-operations-on-polygons-in-c/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (bool, (double X, double Y)?) FindIntersection(
            double X1, double Y1,
            double X2, double Y2,
            double A1, double B1,
            double A2, double B2,
            double epsilon = Epsilon)
        {
            var dx = X2 - X1;
            var dy = Y2 - Y1;
            var da = A2 - A1;
            var db = B2 - B1;

            // If the segments are parallel, return False.
            if (Abs((da * dy) - (db * dx)) < Epsilon)
            {
                return (false, null);
            }

            // Find the point of intersection.
            var s = ((dx * (B1 - Y1)) + (dy * (X1 - A1))) / ((da * dy) - (db * dx));
            var t = ((da * (Y1 - B1)) + (db * (A1 - X1))) / ((db * dx) - (da * dy));

            return (true, (X1 + (t * dx), Y1 + (t * dy)));
        }
```

### Intersection of Two Line Segments

Find the intersection between two Line Segments.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (bool intersects, (double X, double Y)? point) Intersection0(
            double x1, double y1,
            double x2, double y2,
            double x3, double y3,
            double x4, double y4,
            double epsilon = Epsilon)
        {
            // Calculate the delta length vectors for the line segments.
            var deltaBAI = x2 - x1;
            var deltaBAJ = y2 - y1;
            var deltaDCI = x4 - x3;
            var deltaDCJ = y4 - y3;
            var deltaCAI = x3 - x1;
            var deltaCAJ = y3 - y1;

            //  If the segments are parallel return false.
            if (Abs((deltaDCI * deltaBAJ) - (deltaDCJ * deltaBAI)) < DoubleEpsilon)
            {
                return (false, null);
            }

            // Find the index where the intersection point lies on the line.
            var s = ((deltaBAI * deltaCAJ) + (deltaBAJ * -deltaCAI)) / ((deltaDCI * deltaBAJ) - (deltaDCJ * deltaBAI));
            var t = ((deltaDCI * -deltaCAJ) + (deltaDCJ * deltaCAI)) / ((deltaDCJ * deltaBAI) - (deltaDCI * deltaBAJ));

            return (
                // Check whether the point is on the segment.
                (s >= 0d) && (s <= 1d) && (t >= 0d) && (t <= 1d),
                // If the point exists, the point of intersection is:
                (x1 + (t * deltaBAI), y1 + (t * deltaBAJ)));
        }
```

### Intersection of Two Line Segments

Find the intersection between two Line Segments.  
- [https://www.topcoder.com/community/data-science/data-science-tutorials/geometry-concepts-line-intersection-and-its-applications/](https://www.topcoder.com/community/data-science/data-science-tutorials/geometry-concepts-line-intersection-and-its-applications/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (bool, (double X, double Y)?) Intersection1(
            double x1, double y1,
            double x2, double y2,
            double x3, double y3,
            double x4, double y4,
            double epsilon = Epsilon)
        {
            // Calculate the delta length vectors for the line segments.
            var deltaAI = x1 - x2;
            var deltaAJ = y2 - y1;
            var deltaBI = y4 - y3;
            var deltaBJ = x3 - x4;

            // Calculate the determinant of the vectors.
            var determinant = (deltaAJ * deltaBJ) - (deltaBI * deltaAI);

            // Check if the lines are parallel.
            if (Abs(determinant) < DoubleEpsilon)
            {
                return (false, null);
            }

            // Find the index where the intersection point lies on the line.
            var s = ((deltaAJ * x1) + (deltaAI * y1)) / -determinant;
            var t = ((deltaBI * x3) + (deltaBJ * y3)) / determinant;

            // Interpolate the point of intersection.
            return (
                // Check whether the point is on the segment.
                (s >= 0d) && (s <= 1d) && (t >= 0d) && (t <= 1d),
                // If the point exists, the point of intersection is:
                (-((deltaAI * t) + (deltaBJ * s)), (deltaAJ * t) + (deltaBI * s)));
        }
```

### Intersection of Two Line Segments

Find the intersection between two Line Segments.  
- [http://www.vb-helper.com/howto_segments_intersect.html](http://www.vb-helper.com/howto_segments_intersect.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (bool, (double X, double Y)?) Intersection2(
            double x1, double y1,
            double x2, double y2,
            double x3, double y3,
            double x4, double y4,
            double epsilon = Epsilon)
        {
            // Calculate the delta length vectors for the line segments.
            var deltaAI = x2 - x1;
            var deltaAJ = y2 - y1;
            var deltaBI = x4 - x3;
            var deltaBJ = y4 - y3;

            // Calculate the determinant of the coefficient matrix.
            var determinant = (deltaBJ * deltaAI) - (deltaBI * deltaAJ);

            // Check if the line are parallel.
            if (Abs(determinant) < DoubleEpsilon)
            {
                return (false, null);
            }

            // Find the index where the intersection point lies on the line.
            var s = (((x1 - x3) * deltaAJ) + ((y3 - y1) * deltaAI)) / -determinant;
            var t = (((x3 - x1) * deltaBJ) + ((y1 - y3) * deltaBI)) / determinant;

            return (
                 // Check whether the point is on the segment.
                 (t >= 0d) && (t <= 1d) && (s >= 0d) && (s <= 1d),
                // If it exists, the point of intersection is:
                (x1 + (t * deltaAI), y1 + (t * deltaAJ)));
        }
```

### Intersection of Two Line Segments

Find the intersection between two Line Segments.  
- [http://csharphelper.com/blog/2014/08/determine-where-two-lines-intersect-in-c/](http://csharphelper.com/blog/2014/08/determine-where-two-lines-intersect-in-c/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (bool, (double X, double Y)?) Intersection3(
            double x1, double y1,
            double x2, double y2,
            double x3, double y3,
            double x4, double y4,
            double epsilon = Epsilon)
        {
            // Calculate the delta length vectors for the line segments.
            var deltaAI = x2 - x1;
            var deltaAJ = y2 - y1;
            var deltaBI = x4 - x3;
            var deltaBJ = y4 - y3;

            // Calculate the determinant of the coefficient matrix.
            var determinant = (deltaBI * deltaAJ) - (deltaBJ * deltaAI);

            // Check if the lines are parallel.
            if (Abs(determinant) < DoubleEpsilon)
            {
                return (false, null);
            }

            // Find the index where the intersection point lies on the line.
            var s = (((x3 - x1) * deltaAJ) + ((y1 - y3) * deltaAI)) / -determinant;
            var t = (((x1 - x3) * deltaBJ) + ((y3 - y1) * deltaBI)) / determinant;

            // Interpolate the point of intersection.
            return (
                // The segments intersect if t1 and t2 are between 0 and 1.
                (t >= 0d) && (t <= 1d) && (s >= 0d) && (s <= 1d),
                // If it exists, the point of intersection is:
                (x1 + (t * deltaAI), y1 + (t * deltaAJ)));

            //// Find the closest points on the segments.
            //if (t < 0) t = 0;
            //else if (t > 1) t = 1;
            //if (s < 0) s = 0;
            //else if (s > 1) s = 1;

            //Point2D close_p1 = new Point2D(aX + deltaAI * t, aY + deltaAJ * t);
            //Point2D close_p2 = new Point2D(cX + deltaBI * s, cY + deltaBJ * s);
        }
```

### Intersection of Two Line Segments

Find the intersection between two Line Segments.  
- [http://www.gamedev.net/page/resources/_/technical/math-and-physics/fast-2d-line-intersection-algorithm-r423](http://www.gamedev.net/page/resources/_/technical/math-and-physics/fast-2d-line-intersection-algorithm-r423)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (bool, (double X, double Y)?) Intersection4(
            double x0, double y0,
            double x1, double y1,
            double x2, double y2,
            double x3, double y3,
            double epsilon = Epsilon)
        {
            // Compute the slopes of each line. Note the kludge for infinity, however, this will be close enough.
            var m1 = (Abs(x1 - x0) < DoubleEpsilon) ? SlopeMax : (y1 - y0) / (x1 - x0);
            var m2 = (Abs(x3 - x2) < DoubleEpsilon) ? SlopeMax : (y3 - y2) / (x3 - x2);

            // Check if the lines are parallel.
            if (Abs(m1 - m2) < DoubleEpsilon)
            {
                return (false, null);
            }

            // Compute the determinate of the coefficient matrix.
            var determinate = m2 - m1;

            var s = (y0 - (m1 * x0)) / determinate;
            var t = (y2 - (m2 * x2)) / -determinate;

            // Use Cramer's rule to compute the return values.
            return (
                (t >= 0d) && (t <= 1d) && (s >= 0d) && (s <= 1d),
                (s + t, (m2 * s) + (m1 * t)));
        }
```

### Intersection of Two Line Segments

Find the intersection between two Line Segments.  
- [http://rosettacode.org/wiki/Sutherland-Hodgman_polygon_clipping#C.23](http://rosettacode.org/wiki/Sutherland-Hodgman_polygon_clipping#C.23)
- [http://stackoverflow.com/questions/14480124/how-do-i-detect-triangle-and-rectangle-intersection](http://stackoverflow.com/questions/14480124/how-do-i-detect-triangle-and-rectangle-intersection)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (bool, (double X, double Y)?) Intersection5(
            double x0, double y0,
            double x1, double y1,
            double x2, double y2,
            double x3, double y3,
            double epsilon = Epsilon)
        {
            var direction1I = x1 - x0;
            var direction1J = y1 - y0;
            var direction2I = x3 - x2;
            var direction2J = y3 - y2;

            var dotPerp = (direction1I * direction2J) - (direction1J * direction2I);

            // Check if the lines are parallel.
            if (Abs(dotPerp) < DoubleEpsilon)
            {
                return (false, null);
            }

            // If it's 0, it means the lines are parallel so have infinite intersection points
            if (NearZeroTests.NearZero(dotPerp))
            {
                return (false, null);
            }

            var cI = x2 - x0;
            var cJ = y2 - y0;
            var t = ((cI * direction2J) - (cJ * direction2I)) / dotPerp;
            //if ((t < 0) || (t > 1)) return null; // lies outside the line segment

            var u = ((cI * direction1J) - (cJ * direction1I)) / dotPerp;
            //if ((u < 0) || (u > 1)) return null; // lies outside the line segment

            //	Return the intersection point
            return (
                (t > 0) && (t < 1) && (u > 0) && (u < 1),
                (
                x0 + (t * direction1I),
                y0 + (t * direction1J)));
        }
```

### Intersection of Two Line Segments

Find the intersection between two Line Segments.  
- [https://github.com/thelonious/kld-intersections](https://github.com/thelonious/kld-intersections)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<Point2D> IntersectLineLine(
            double Ax, double Ay,
            double Bx, double By,
            double Cx, double Cy,
            double Dx, double Dy,
            double epsilon = Epsilon)
        {
            List<Point2D> result;

            var ua_t = ((Dx - Cx) * (Ay - Cy)) - ((Dy - Cy) * (Ax - Cx));
            var ub_t = ((Bx - Ax) * (Ay - Cy)) - ((By - Ay) * (Ax - Cx));
            var u_b = ((Dy - Cy) * (Bx - Ax)) - ((Dx - Cx) * (By - Ay));

            if (u_b != 0)
            {
                var ua = ua_t / u_b;
                var ub = ub_t / u_b;

                result = 0 <= ua && ua <= 1 && 0 <= ub && ub <= 1 ? new List<Point2D>
                    {
                        new Point2D(
                            Ax + (ua * (Bx - Ax)),
                            Ay + (ua * (By - Ay))
                        )
                    } : new List<Point2D>();
            }
            else
            {
                result = null;
            }

            return result;
        }
```

### Intersection of Two Line Segments

Find the intersection between two Line Segments.  
- [http://alienryderflex.com/intersect/](http://alienryderflex.com/intersect/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (bool, (double X, double Y)?) LineIntersection(
            double Ax, double Ay,
            double Bx, double By,
            double Cx, double Cy,
            double Dx, double Dy,
            double epsilon = Epsilon)
        {
            double distAB, theCos, theSin, newX, ABpos;

            //  Fail if either line is undefined.
            if (Ax == Bx && Ay == By || Cx == Dx && Cy == Dy)
            {
                return (false, null);
            }

            //  (1) Translate the system so that point A is on the origin.
            Bx -= Ax; By -= Ay;
            Cx -= Ax; Cy -= Ay;
            Dx -= Ax; Dy -= Ay;

            //  Discover the length of segment A-B.
            distAB = Sqrt((Bx * Bx) + (By * By));

            //  (2) Rotate the system so that point B is on the positive X axis.
            theCos = Bx / distAB;
            theSin = By / distAB;
            newX = (Cx * theCos) + (Cy * theSin);
            Cy = (Cy * theCos) - (Cx * theSin); Cx = newX;
            newX = (Dx * theCos) + (Dy * theSin);
            Dy = (Dy * theCos) - (Dx * theSin); Dx = newX;

            //  Fail if the lines are parallel.
            if (Cy == Dy)
            {
                return (false, null);
            }

            //  (3) Discover the position of the intersection point along line A-B.
            ABpos = Dx + ((Cx - Dx) * Dy / (Dy - Cy));

            //  Success.
            //  (4) Apply the discovered position to line A-B in the original coordinate system.
            return (true, (Ax + (ABpos * theCos), Ay + (ABpos * theSin)));
        }
```

### Intersection of Two Line Segments

Find the intersection between two Line Segments.  
- [http://alienryderflex.com/intersect/](http://alienryderflex.com/intersect/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (bool, (double X, double Y)?) LineSegmentIntersection(
            double Ax, double Ay,
            double Bx, double By,
            double Cx, double Cy,
            double Dx, double Dy,
            double epsilon = Epsilon)
        {
            double distAB, theCos, theSin, newX, ABpos;

            //  Fail if either line segment is zero-length.
            if (Ax == Bx && Ay == By || Cx == Dx && Cy == Dy)
            {
                return (false, null);
            }

            //  Fail if the segments share an end-point.
            if (Ax == Cx && Ay == Cy || Bx == Cx && By == Cy
           || Ax == Dx && Ay == Dy || Bx == Dx && By == Dy)
            {
                return (false, null);
            }

            //  (1) Translate the system so that point A is on the origin.
            Bx -= Ax; By -= Ay;
            Cx -= Ax; Cy -= Ay;
            Dx -= Ax; Dy -= Ay;

            //  Discover the length of segment A-B.
            distAB = Sqrt((Bx * Bx) + (By * By));

            //  (2) Rotate the system so that point B is on the positive X axis.
            theCos = Bx / distAB;
            theSin = By / distAB;
            newX = (Cx * theCos) + (Cy * theSin);
            Cy = (Cy * theCos) - (Cx * theSin); Cx = newX;
            newX = (Dx * theCos) + (Dy * theSin);
            Dy = (Dy * theCos) - (Dx * theSin); Dx = newX;

            //  Fail if segment C-D doesn't cross line A-B.
            if (Cy < 0d && Dy < 0d || Cy >= 0d && Dy >= 0d)
            {
                return (false, null);
            }

            //  (3) Discover the position of the intersection point along line A-B.
            ABpos = Dx + ((Cx - Dx) * Dy / (Dy - Cy));

            //  Fail if segment C-D crosses line A-B outside of segment A-B.
            if (ABpos < 0d || ABpos > distAB)
            {
                return (false, (Ax + (ABpos * theCos), Ay + (ABpos * theSin)));
            }

            //  Success.
            //  (4) Apply the discovered position to line A-B in the original coordinate system.
            return (true, (Ax + (ABpos * theCos), Ay + (ABpos * theSin)));
        }
```

