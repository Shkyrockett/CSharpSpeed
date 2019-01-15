# Point in Polygon

Determine whether a point is contained within a Polygon.

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

../../InstrumentedLibrary/Geometry/Contains/PolygonContourContainsPointTests.cs

The required method signature for this API is as follows:

```CSharp
public static bool PointInPolygonContour(List<Point2D> polygon, Point2D point)
```

## Test Case Index

- [Test Case: (System.Collections.Generic.List`1[InstrumentedLibrary.Point2D], Point2D{X:1, Y:1 })](#System.Collections.Generic.List`1[InstrumentedLibrary.Point2D],-Point2D{X:1,-Y:1-})

### (System.Collections.Generic.List`1[InstrumentedLibrary.Point2D], Point2D{X:1, Y:1 })

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [PointInPolygonContourAlienRyderFlex(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D], Point2D{X:1, Y:1 })](#Point-in-Polygon) | True == True | 10000 in 29 ms. 0.0029 ms. average | polygon, point. |
| [PointInPolygonContourBobStein(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D], Point2D{X:1, Y:1 })](#Point-in-Polygon) | True == True | 10000 in 34 ms. 0.0034 ms. average | polygon, point. |
| [PointInPolygonContourDarelRexFinley(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D], Point2D{X:1, Y:1 })](#Point-in-Polygon) | True == True | 10000 in 35 ms. 0.0035 ms. average | polygon, point. |
| [PointInPolygonContourGilKr(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D], Point2D{X:1, Y:1 })](#Point-in-Polygon) | False != True | 10000 in 30 ms. 0.003 ms. average | polygon, point. |
| [PointInPolygonContourHormannAgathosNewFor(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D], Point2D{X:1, Y:1 })](#Point-in-Polygon) | True == True | 10000 in 39 ms. 0.0039 ms. average | polygon, point. |
| [PointInPolygonContourJerryKnauss(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D], Point2D{X:1, Y:1 })](#Point-in-Polygon) | False != True | 10000 in 38 ms. 0.0038 ms. average | polygon, point. |
| [PointInPolygonContourJerryKnauss2(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D], Point2D{X:1, Y:1 })](#Point-in-Polygon) | False != True | 10000 in 38 ms. 0.0038 ms. average | polygon, point. |
| [PointInPolygonContourKeith(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D], Point2D{X:1, Y:1 })](#Point-in-Polygon) | False != True | 10000 in 34 ms. 0.0034 ms. average | polygon, point. |
| [PointInPolygonContourLaschaLagidse(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D], Point2D{X:1, Y:1 })](#Point-in-Polygon) | True == True | 10000 in 20 ms. 0.002 ms. average | polygon, point. |
| [PointInPolygonContourLaschaLagidse2(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D], Point2D{X:1, Y:1 })](#Point-in-Polygon) | True == True | 10000 in 15 ms. 0.0015 ms. average | polygon, point. |
| [PointInPolygonContourMeowNET(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D], Point2D{X:1, Y:1 })](#Point-in-Polygon) | True == True | 10000 in 23 ms. 0.0023 ms. average | polygon, point. |
| [PointInPolygonContourMKatzWRandolphFranklin(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D], Point2D{X:1, Y:1 })](#Point-in-Polygon) | False != True | 10000 in 46 ms. 0.0046 ms. average | polygon, point. |
| [PointInPolygonContourNathanMercer(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D], Point2D{X:1, Y:1 })](#Point-in-Polygon) | True == True | 10000 in 35 ms. 0.0035 ms. average | polygon, point. |
| [PointInPolygonContourPaulBourke(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D], Point2D{X:1, Y:1 })](#Point-in-Polygon) | True == True | 10000 in 31 ms. 0.0031 ms. average | polygon, point. |
| [PointInPolygonContourPhilippeReverdy(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D], Point2D{X:1, Y:1 })](#Point-in-Polygon) | True == True | 10000 in 30 ms. 0.003 ms. average | polygon, point. |
| [PointInPolygonContourRodStephens(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D], Point2D{X:1, Y:1 })](#Point-in-Polygon) | True == True | 10000 in 35 ms. 0.0035 ms. average | polygon, point. |
| [PointInPolygonContourSaeedAmiri(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D], Point2D{X:1, Y:1 })](#Point-in-Polygon) | True == True | 10000 in 51 ms. 0.0051 ms. average | polygon, point. |
| [PointInPolygonContourWRandolphFranklin(System.Collections.Generic.List`1[InstrumentedLibrary.Point2D], Point2D{X:1, Y:1 })](#Point-in-Polygon) | False != True | 10000 in 44 ms. 0.0044 ms. average | polygon, point. |

## The Code

The code for the methods tested follows below.

### Point in Polygon

AlienRyderFlex Point in Polygon method.  
- [http://alienryderflex.com/polygon/](http://alienryderflex.com/polygon/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourAlienRyderFlex(
            List<Point2D> polygon, Point2D point)
        {
            int i;
            var j = polygon.Count - 1;
            var oddNodes = false;

            for (i = 0; i < polygon.Count; i++)
            {
                if (polygon[i].Y < point.Y && polygon[j].Y >= point.Y
                || polygon[j].Y < point.Y && polygon[i].Y >= point.Y)
                {
                    if (polygon[i].X + ((point.Y - polygon[i].Y)
                        / (polygon[j].Y - polygon[i].Y)
                        * (polygon[j].X - polygon[i].X)) < point.X)
                    {
                        oddNodes = !oddNodes;
                    }
                }
                j = i;
            }

            return oddNodes;
        }
```

### Point in Polygon

Bob Stein Point in Polygon method.  
- [http://www.visibone.com/inpoly/](http://www.visibone.com/inpoly/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourBobStein(
            List<Point2D> polygon, Point2D point)
        {
            double xnew, ynew;
            double xold, yold;
            double x1, y1;
            double x2, y2;
            int i;
            var inside = false;
            var npoints = polygon.Count;
            if (npoints < 3)
            {
                return false;
            }

            xold = polygon[npoints - 1].X;
            yold = polygon[npoints - 1].Y;
            for (i = 0; i < npoints; i++)
            {
                xnew = polygon[i].X;
                ynew = polygon[i].Y;
                if (xnew > xold)
                {
                    x1 = xold;
                    x2 = xnew;
                    y1 = yold;
                    y2 = ynew;
                }
                else
                {
                    x1 = xnew;
                    x2 = xold;
                    y1 = ynew;
                    y2 = yold;
                }
                if ((xnew < point.X) == (point.X <= xold)          /* edge "open" at one end */
                 && ((long)point.Y - (long)y1) * (long)(x2 - x1)
                  < ((long)point.Y - (long)y1) * (long)(point.X - x1))
                {
                    inside = !inside;
                }
                xold = xnew;
                yold = ynew;
            }
            return inside;
        }
```

### Point in Polygon

Darel Rex Finley Point in Polygon method.  
- [http://alienryderflex.com/polygon/](http://alienryderflex.com/polygon/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourDarelRexFinley(
            List<Point2D> polygon, Point2D point)
        {
            var j = polygon.Count - 1;
            var oddNodes = false;

            for (var i = 0; i < polygon.Count; i++)
            {
                if (
                    polygon[i].Y < point.Y
                    && polygon[j].Y >= point.Y
                    || polygon[j].Y < point.Y
                    && polygon[i].Y >= point.Y)
                {
                    if (polygon[i].X + ((point.Y - polygon[i].Y)
                        / (polygon[j].Y - polygon[i].Y)
                        * (polygon[j].X - polygon[i].X)) < point.X)
                    {
                        oddNodes = !oddNodes;
                    }
                }
                j = i;
            }

            return oddNodes;
        }
```

### Point in Polygon

GilKr Point in Polygon method.  
- [http://stackoverflow.com/questions/4243042/c-sharp-point-in-polygon](http://stackoverflow.com/questions/4243042/c-sharp-point-in-polygon)
- [http://stackoverflow.com/questions/217578/point-in-polygon-aka-hit-test](http://stackoverflow.com/questions/217578/point-in-polygon-aka-hit-test)
- [http://www.ecse.rpi.edu/Homepages/wrf/Research/Short_Notes/pnpoly.html](http://www.ecse.rpi.edu/Homepages/wrf/Research/Short_Notes/pnpoly.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourGilKr(
            List<Point2D> polygon, Point2D point)
        {
            var nvert = polygon.Count;
            var c = false;
            for (int i = 0, j = nvert - 1; i < nvert; j = i++)
            {
                if (((polygon[i].Y > point.Y) != (polygon[j].Y > point.Y))
                 && (point.X < ((polygon[j].X - polygon[i].X)
                 * (point.Y - polygon[i].Y)
                 / (polygon[j].Y - polygon[i].Y)) + polygon[i].X))
                {
                    c = !c;
                }
            }
            return c;
        }
```

### Point in Polygon

Hormann Agathos Point in Polygon method.  
- [http://angusj.com/delphi/clipper.php](http://angusj.com/delphi/clipper.php)
- [http://www.inf.usi.ch/hormann/papers/Hormann.2001.TPI.pdf](http://www.inf.usi.ch/hormann/papers/Hormann.2001.TPI.pdf)

```CSharp
        [DebuggerStepThrough]
        public static bool PointInPolygonContourHormannAgathosNewFor(List<Point2D> polygon, Point2D point)
            => PointInPolygonContourHormannAgathosNewFor(polygon, point, Epsilon) != Inclusion.Outside;

        /// <summary>
        /// Determines whether the specified point is contained withing the region defined by this <see cref="PolygonContour2D"/>.
        /// </summary>
        /// <param name="points">The points that form the corners of the polygon.</param>
        /// <param name="p">The coordinate of the test point.</param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns>
        /// Returns Outside (0) if false, Inside (+1) if true, Boundary (-1) if the point is on a polygon boundary.
        /// </returns>
        /// <acknowledgment>
        /// Adapted from Clipper library: http://www.angusj.com/delphi/clipper.php
        /// See "The Point in Polygon Problem for Arbitrary Polygons" by Hormann and Agathos
        /// http://www.inf.usi.ch/hormann/papers/Hormann.2001.TPI.pdf
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion PointInPolygonContourHormannAgathosNewFor(
            List<Point2D> points,
            Point2D p,
            double epsilon = Epsilon)
        {
            // Default value is no inclusion.
            var result = Inclusion.Outside;

            // Special cases for points and line segments.
            if (points.Count < 3)
            {
                if (points.Count == 1)
                {
                    // If the polygon has 1 point, it is a point and has no interior, but a point can intersect a point.
                    return (p.X == points[0].X && p.Y == points[0].Y) ? Inclusion.Boundary : Inclusion.Outside;
                }
                else if (points.Count == 2)
                {
                    // If the polygon has 2 points, it is a line and has no interior, but a point can intersect a line.
                    return ((p.X == points[0].X) && (p.Y == points[0].Y))
                        || ((p.X == points[1].X) && (p.Y == points[1].Y))
                        || (((p.X > points[0].X) == (p.X < points[1].X))
                        && ((p.Y > points[0].Y) == (p.Y < points[1].Y))
                        && ((p.X - points[0].X) * (points[1].Y - points[0].Y) == (p.Y - points[0].Y) * (points[1].X - points[0].X))) ? Inclusion.Boundary : Inclusion.Outside;
                }
                else
                {
                    // Empty geometry.
                    return Inclusion.Outside;
                }
            }

            // Loop through each line segment.
            Point2D curPoint;
            Point2D nextPoint;
            for (int i = points.Count - 1, j = 0; j < points.Count; i = j++)
            {
                curPoint = points[i];
                nextPoint = points[j];
                // Special case for horizontal lines. Check whether the point is on one of the ends, or whether the point is on the segment, if the line is horizontal.
                if (nextPoint.Y == p.Y && (nextPoint.X == p.X || ((curPoint.Y == p.Y) && ((nextPoint.X > p.X) == (curPoint.X < p.X)))))
                //if ((Abs(nextPoint.Y - pY) < epsilon) && ((Abs(nextPoint.X - pX) < epsilon) || (Abs(curPoint.Y - pY) < epsilon && ((nextPoint.X > pX) == (curPoint.X < pX)))))
                {
                    return Inclusion.Boundary;
                }

                // If Point between start and end points horizontally.
                //if ((curPoint.Y < pY) == (nextPoint.Y >= pY))
                if ((curPoint.Y < p.Y) != (nextPoint.Y < p.Y))
                {
                    // If point between start and end points vertically.
                    if (curPoint.X >= p.X)
                    {
                        if (nextPoint.X > p.X)
                        {
                            result = 1 - result;
                        }
                        else
                        {
                            var determinant = ((curPoint.X - p.X) * (nextPoint.Y - p.Y)) - ((nextPoint.X - p.X) * (curPoint.Y - p.Y));
                            if (Abs(determinant) < epsilon)
                            {
                                return Inclusion.Boundary;
                            }
                            else if ((determinant > 0) == (nextPoint.Y > curPoint.Y))
                            {
                                result = 1 - result;
                            }
                        }
                    }
                    else if (nextPoint.X > p.X)
                    {
                        var determinant = ((curPoint.X - p.X) * (nextPoint.Y - p.Y)) - ((nextPoint.X - p.X) * (curPoint.Y - p.Y));
                        if (Abs(determinant) < epsilon)
                        {
                            return Inclusion.Boundary;
                        }

                        if ((determinant > 0) == (nextPoint.Y > curPoint.Y))
                        {
                            result = 1 - result;
                        }
                    }
                }
            }

            return result;
        }
```

### Point in Polygon

Jerry Knauss Point in Polygon method.  
- [http://paulbourke.net/geometry/polygonmesh/](http://paulbourke.net/geometry/polygonmesh/)
- [http://paulbourke.net/geometry/polygonmesh/contains.txt](http://paulbourke.net/geometry/polygonmesh/contains.txt)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourJerryKnauss(
            List<Point2D> polygon, Point2D point)
        {
            var result = false;

            for (var i = 0; i < polygon.Count - 1; i++)
            {
                if ((((polygon[i + 1].Y < point.Y) && (point.Y < polygon[i].Y))
                    || ((polygon[i].Y < point.Y) && (point.Y < polygon[i + 1].Y)))
                    && (point.X < ((polygon[i].X - polygon[i + 1].X)
                    * (point.Y - polygon[i + 1].Y)
                    / (polygon[i].Y - polygon[i + 1].Y)) + polygon[i + 1].X))
                {
                    result = !result;
                }
            }
            return result;
        }
```

### Point in Polygon

Jerry Knauss Point in Polygon method 2.  
- [http://paulbourke.net/geometry/polygonmesh/](http://paulbourke.net/geometry/polygonmesh/)
- [http://paulbourke.net/geometry/polygonmesh/contains.txt](http://paulbourke.net/geometry/polygonmesh/contains.txt)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourJerryKnauss2(
            List<Point2D> polygon, Point2D point)
        {
            var j = polygon.Count - 1;
            var result = false;

            for (var i = 0; i < polygon.Count; i++)
            {
                if (((
                    (polygon[j].Y < point.Y)
                    && (point.Y < polygon[i].Y))
                    || ((polygon[i].Y < point.Y)
                    && (point.Y < polygon[j].Y)))
                    && (point.X < ((polygon[i].X - polygon[j].X)
                    * (point.Y - polygon[j].Y)
                    / (polygon[i].Y - polygon[j].Y)) + polygon[j].X))
                {
                    result = !result;
                }

                j = i;
            }
            return result;
        }
```

### Point in Polygon

Keith Point in Polygon method.  
- [http://stackoverflow.com/questions/4243042/c-sharp-point-in-polygon](http://stackoverflow.com/questions/4243042/c-sharp-point-in-polygon)
- [https://social.msdn.microsoft.com/Forums/windows/en-US/95055cdc-60f8-4c22-8270-ab5f9870270a/determine-if-the-point-is-in-the-polygon-c?forum=winforms](https://social.msdn.microsoft.com/Forums/windows/en-US/95055cdc-60f8-4c22-8270-ab5f9870270a/determine-if-the-point-is-in-the-polygon-c?forum=winforms)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourKeith(
            List<Point2D> polygon, Point2D point)
        {
            Point2D p1, p2;

            var inside = false;

            if (polygon.Count < 3)
            {
                return inside;
            }

            var oldPoint = polygon[polygon.Count - 1];

            for (var i = 0; i < polygon.Count; i++)
            {
                var newPoint = polygon[i];

                if (newPoint.X > oldPoint.X)
                {
                    p1 = oldPoint;
                    p2 = newPoint;
                }
                else
                {
                    p1 = newPoint;
                    p2 = oldPoint;
                }

                if ((newPoint.X < point.X) == (point.X <= oldPoint.X)
                    && (point.Y - (long)p1.Y) * (p2.X - p1.X)
                    < (p2.Y - (long)p1.Y) * (point.X - p1.X))
                {
                    inside = !inside;
                }

                oldPoint = newPoint;
            }

            return inside;
        }
```

### Point in Polygon

LaschaLagidse Point in Polygon method.  
- [http://alienryderflex.com/polygon/](http://alienryderflex.com/polygon/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourLaschaLagidse(
            List<Point2D> polygon, Point2D point)
        {
            int i;
            var j = polygon.Count - 1;
            var oddNodes = false;

            for (i = 0; i < polygon.Count; i++)
            {
                //  Note that division by zero is avoided because the division is protected
                //  by the "if" clause which surrounds it.
                if ((polygon[i].Y < point.Y && polygon[j].Y >= point.Y
                || polygon[j].Y < point.Y && polygon[i].Y >= point.Y)
                && (polygon[i].X <= point.X || polygon[j].X <= point.X))
                {
                    oddNodes ^= polygon[i].X + ((point.Y - polygon[i].Y)
                        / (polygon[j].Y - polygon[i].Y)
                        * (polygon[j].X - polygon[i].X)) < point.X;
                }

                j = i;
            }

            return oddNodes;
        }
```

### Point in Polygon

Lascha Lagidse 2 Point in Polygon method.  
- [http://alienryderflex.com/polygon/](http://alienryderflex.com/polygon/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourLaschaLagidse2(
            List<Point2D> polygon, Point2D point)
        {
            int i;
            var j = polygon.Count - 1;
            var oddNodes = false;

            for (i = 0; i < polygon.Count; i++)
            {
                if ((polygon[i].Y < point.Y && polygon[j].Y >= point.Y
                || polygon[j].Y < point.Y && polygon[i].Y >= point.Y)
                && (polygon[i].X <= point.X || polygon[j].X <= point.X))
                {
                    oddNodes ^= polygon[i].X + ((point.Y - polygon[i].Y)
                        / (polygon[j].Y - polygon[i].Y)
                        * (polygon[j].X - polygon[i].X)) < point.X;
                }
                j = i;
            }

            return oddNodes;
        }
```

### Point in Polygon

Contour Meow NET Point in Polygon method.  
- [http://stackoverflow.com/questions/4243042/c-sharp-point-in-polygon](http://stackoverflow.com/questions/4243042/c-sharp-point-in-polygon)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourMeowNET(
            List<Point2D> polygon, Point2D point)
        {
            var result = false;
            var j = polygon.Count - 1;
            for (var i = 0; i < polygon.Count; i++)
            {
                if (polygon[i].Y < point.Y && polygon[j].Y >= point.Y || polygon[j].Y < point.Y && polygon[i].Y >= point.Y)
                {
                    if (polygon[i].X + ((point.Y - polygon[i].Y)
                        / (polygon[j].Y - polygon[i].Y)
                        * (polygon[j].X - polygon[i].X)) < point.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }
```

### Point in Polygon

GilKr Point in Polygon method.  
- [http://stackoverflow.com/questions/217578/how-can-i-determine-whether-a-2d-point-is-within-a-polygon](http://stackoverflow.com/questions/217578/how-can-i-determine-whether-a-2d-point-is-within-a-polygon)
- [http://stackoverflow.com/questions/217578/point-in-polygon-aka-hit-test](http://stackoverflow.com/questions/217578/point-in-polygon-aka-hit-test)
- [http://www.ecse.rpi.edu/Homepages/wrf/Research/Short_Notes/pnpoly.html](http://www.ecse.rpi.edu/Homepages/wrf/Research/Short_Notes/pnpoly.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourMKatzWRandolphFranklin(
            List<Point2D> polygon, Point2D point)
        {
            var minX = polygon[0].X;
            var maxX = polygon[0].X;
            var minY = polygon[0].Y;
            var maxY = polygon[0].Y;
            for (var i = 1; i < polygon.Count; i++)
            {
                var q = polygon[i];
                minX = Min(q.X, minX);
                maxX = Max(q.X, maxX);
                minY = Min(q.Y, minY);
                maxY = Max(q.Y, maxY);
            }

            if (point.X < minX || point.X > maxX || point.Y < minY || point.Y > maxY)
            {
                return false;
            }

            // http://www.ecse.rpi.edu/Homepages/wrf/Research/Short_Notes/pnpoly.html
            var inside = false;
            for (int i = 0, j = polygon.Count - 1; i < polygon.Count; j = i++)
            {
                if ((polygon[i].Y > point.Y) != (polygon[j].Y > point.Y)
                     && point.X < ((polygon[j].X - polygon[i].X) * (point.Y - polygon[i].Y)
                     / (polygon[j].Y - polygon[i].Y)) + polygon[i].X)
                {
                    inside = !inside;
                }
            }

            return inside;
        }
```

### Point in Polygon

Nathan Mercer Point in Polygon method.  
- [http://alienryderflex.com/polygon/](http://alienryderflex.com/polygon/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourNathanMercer(
            List<Point2D> polygon, Point2D point)
        {
            var j = polygon.Count - 1;
            var oddNodes = false;

            for (var i = 0; i < polygon.Count; i++)
            {
                //  Note that division by zero is avoided because the division is protected
                //  by the "if" clause which surrounds it.
                if (polygon[i].Y < point.Y && polygon[j].Y >= point.Y
                || polygon[j].Y < point.Y && polygon[i].Y >= point.Y
                && (polygon[i].X <= point.X || polygon[j].X <= point.X))
                {
                    if (polygon[i].X + ((point.Y - polygon[i].Y)
                        / (polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X)) < point.X)
                    {
                        oddNodes = !oddNodes;
                    }
                }

                j = i;
            }

            return oddNodes;
        }
```

### Point in Polygon

Paul Bourke Point in Polygon method.  
- [http://paulbourke.net/geometry/polygonmesh/](http://paulbourke.net/geometry/polygonmesh/)
- [http://astronomy.swin.edu.au/pbourke/geometry/](http://astronomy.swin.edu.au/pbourke/geometry/)
- [http://www.eecs.umich.edu/courses/eecs380/HANDOUTS/PROJ2/InsidePoly.html](http://www.eecs.umich.edu/courses/eecs380/HANDOUTS/PROJ2/InsidePoly.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourPaulBourke(
            List<Point2D> polygon, Point2D point)
        {
            Point2D p1, p2;
            var counter = 0;
            int i;
            var N = polygon.Count;
            double xinters;
            p1 = polygon[0];
            for (i = 1; i <= N; i++)
            {
                p2 = polygon[i % N];
                if (point.Y > Min(p1.Y, p2.Y))
                {
                    if (point.Y <= Max(p1.Y, p2.Y))
                    {
                        if (point.X <= Max(p1.X, p2.X))
                        {
                            if (Abs(p1.Y - p2.Y) > DoubleEpsilon)
                            {
                                xinters = ((point.Y - p1.Y) * (p2.X - p1.X) / (p2.Y - p1.Y)) + p1.X;
                                if (Abs(p1.X - p2.X) < DoubleEpsilon || point.X <= xinters)
                                {
                                    counter++;
                                }
                            }
                        }
                    }
                }
                p1 = p2;
            }

            return counter % 2 != 0;
        }
```

### Point in Polygon

Philippe Reverdy Point in Polygon method.  
- [http://paulbourke.net/geometry/polygonmesh/](http://paulbourke.net/geometry/polygonmesh/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourPhilippeReverdy(
            List<Point2D> polygon, Point2D point)
        {
            int i;
            double angle = 0;
            var p1 = new Point2D();
            var p2 = new Point2D();
            var n = polygon.Count;
            for (i = 0; i < n; i++)
            {
                p1.X = polygon[i].X - point.X;
                p1.Y = polygon[i].Y - point.Y;
                p2.X = polygon[(i + 1) % n].X - point.X;
                p2.Y = polygon[(i + 1) % n].Y - point.Y;
                angle += Angle2DTests.Angle2DPhilippeReverdy(p1.X, p1.Y, p2.X, p2.Y);
            }

            return !(Abs(angle) < PI);
        }
```

### Point in Polygon

Rod Stephens Point in Polygon method.  
- [http://paulbourke.net/geometry/polygonmesh/](http://paulbourke.net/geometry/polygonmesh/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourRodStephens(
            List<Point2D> polygon, Point2D point)
        {
            // Get the angle between the point and the
            // first and last vertices.
            var max_point = polygon.Count - 1;
            var total_angle = Angle3Vector2DTests.AngleVector(
                polygon[max_point].X, polygon[max_point].Y,
                point.X, point.Y,
                polygon[0].X, polygon[0].Y);

            // Add the angles from the point
            // to each other pair of vertices.
            for (var i = 0; i < max_point; i++)
            {
                total_angle += Angle3Vector2DTests.AngleVector(
                    polygon[i].X, polygon[i].Y,
                    point.X, point.Y,
                    polygon[i + 1].X, polygon[i + 1].Y);
            }

            // The total angle should be 2 * PI or -2 * PI if
            // the point is in the polygon and close to zero
            // if the point is outside the polygon.
            return Abs(total_angle) > 0.000001;
        }
```

### Point in Polygon

Saeed Amiri Point in Polygon method.  
- [http://stackoverflow.com/questions/4243042/c-sharp-point-in-polygon](http://stackoverflow.com/questions/4243042/c-sharp-point-in-polygon)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourSaeedAmiri(
            List<Point2D> polygon, Point2D point)
        {
            var coef = polygon.Skip(1).Select((p, i) =>
                  ((p.X - polygon[i].X) * (point.Y - polygon[i].Y))
                - ((p.Y - polygon[i].Y) * (point.X - polygon[i].X))
                ).ToList();

            if (coef.Any(p => Abs(p) < DoubleEpsilon))
            {
                return true;
            }

            for (var i = 1; i < coef.Count; i++)
            {
                if (coef[i] * coef[i - 1] < 0)
                {
                    return false;
                }
            }

            return true;
        }
```

### Point in Polygon

W Randolph Franklin Point in Polygon method.  
- [https://www.ecse.rpi.edu/Homepages/wrf/Research/Short_Notes/pnpoly.html](https://www.ecse.rpi.edu/Homepages/wrf/Research/Short_Notes/pnpoly.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool PointInPolygonContourWRandolphFranklin(
            List<Point2D> polygon, Point2D point)
        {
            var inside = false;
            var nvert = polygon.Count;
            for (int i = 0, j = nvert - 1; i < nvert; j = i++)
            {
                if (((polygon[i].Y > point.Y) != (polygon[j].Y > point.Y))
                 && (point.X < ((polygon[j].X - polygon[i].X) * (point.Y - polygon[i].Y)
                 / (polygon[j].Y - polygon[i].Y)) + polygon[i].X))
                {
                    inside = !inside;
                }
            }
            return inside;
        }
```

