# Polygon Perimeter Tests

Calculate the Perimeter of a polygon.

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

../../InstrumentedLibrary/Geometry/Length/PolygonPerimeterTests.cs

The required method signature for this API is as follows:

```CSharp
public static List<(double X, double Y)> PolygonPerimeter(List<(double X, double Y)> points)
```

## Test Case Index

- [Test Case: (System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]])](#System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]])

### (System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]])

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [PolygonPerimeter0(System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]])](#Perimeter-of-Polygon) | Null != 6.2831853071795862 | 10000 in 14 ms. 0.0014 ms. average | Circle test case. |

## The Code

The code for the methods tested follows below.

### Perimeter of Polygon

Find Perimeter of a polygon.  
- [http://alienryderflex.com/polygon_perimeter/](http://alienryderflex.com/polygon_perimeter/)

```CSharp
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<(double X, double Y)> PolygonPerimeter0(List<(double X, double Y)> points)
        {
            var corners = points.Count;

            const int MAX_SEGS = 1000;

            var segS = new (double X, double Y)[corners];
            var segE = new (double X, double Y)[corners];
            var segAngle = new List<double>();
            var segRet = new List<(double X, double Y)>();
            (double X, double Y)? intersect;
            var start = points[0];
            var lastAngle = PI;
            var j = corners - 1;
            var segs = 0;

            if (corners > MAX_SEGS)
            {
                return null;
            }

            //  1,3.  Reformulate the polygon as a set of line segments, and choose a
            //        starting point that must be on the perimeter.
            for (var i = 0; i < corners; i++)
            {
                if (points[i].X != points[j].X || points[i].Y != points[j].Y)
                {
                    segS[segs] = (points[i].X, points[i].Y);
                    segE[segs] = (points[j].X, points[j].Y);
                }
                j = i;
                if (points[i].Y > start.Y || points[i].Y == start.Y && points[i].X < start.X)
                {
                    start.X = points[i].X;
                    start.Y = points[i].Y;
                }
            }
            if (segs == 0)
            {
                return null;
            }

            //  2.  Break the segments up at their intersection points.
            for (var i = 0; i < segs - 1; i++)
            {
                for (j = i + 1; j < segs; j++)
                {
                    var (intersects, point) = LineSegmentLineSegmentIntersectionTests.LineSegmentLineSegmentIntersection(
                    segS[i].X, segS[i].Y, segE[i].X, segE[i].Y,
                    segS[j].X, segS[j].Y, segE[j].X, segE[j].Y);
                    intersect = point;
                    if (intersects)
                    {
                        if ((intersect?.X != segS[i].X || intersect?.Y != segS[i].Y)
                        && (intersect?.X != segE[i].X || intersect?.Y != segE[i].Y))
                        {
                            if (segs == MAX_SEGS)
                            {
                                return null;
                            }

                            segS[segs] = (segS[i].X, segS[i].Y);
                            segE[segs] = ((double)intersect?.X, (double)intersect?.Y);
                            segS[i] = ((double)intersect?.X, (double)intersect?.Y);
                        }
                        if ((intersect?.X != segS[j].X || intersect?.Y != segS[j].Y)
                        && (intersect?.X != segE[j].X || intersect?.Y != segE[j].Y))
                        {
                            if (segs == MAX_SEGS)
                            {
                                return null;
                            }

                            segS[segs] = (segS[j].X, segS[j].Y);
                            segE[segs] = ((double)intersect?.X, (double)intersect?.Y);
                            segS[j] = ((double)intersect?.X, (double)intersect?.Y);
                        }
                    }
                }
            }

            //  Calculate the angle of each segment.
            for (var i = 0; i < segs; i++)
            {
                segAngle[i] = AngleofVector2DTests.AngleOfVector2D(segE[i].X - segS[i].X, segE[i].Y - segS[i].Y);
            }

            //  4.  Build the perimeter polygon.
            var c = start.X;
            var d = start.Y;
            var a = c - 1d;
            var b = d;
            double e = 0;
            double f = 0;

            double angleDif = 0;
            var bestAngleDif = Tau;

            segRet.Add((c, d));
            corners = 1;
            while (true)
            {
                bestAngleDif = Tau;
                for (var i = 0; i < segs; i++)
                {
                    if (segS[i].X == c && segS[i].Y == d && (segE[i].X != a || segE[i].Y != b))
                    {
                        angleDif = lastAngle - segAngle[i];
                        while (angleDif >= Tau)
                        {
                            angleDif -= Tau;
                        }

                        while (angleDif < 0)
                        {
                            angleDif += Tau;
                        }

                        if (angleDif < bestAngleDif)
                        {
                            bestAngleDif = angleDif; e = segE[i].X; f = segE[i].Y;
                        }
                    }
                    if (segE[i].X == c && segE[i].Y == d && (segS[i].X != a || segS[i].Y != b))
                    {
                        angleDif = lastAngle - segAngle[i] + (.5 * Tau);
                        while (angleDif >= Tau)
                        {
                            angleDif -= Tau;
                        }

                        while (angleDif < 0)
                        {
                            angleDif += Tau;
                        }

                        if (angleDif < bestAngleDif)
                        {
                            bestAngleDif = angleDif;
                            e = segS[i].X;
                            f = segS[i].Y;
                        }
                    }
                }
                if (corners > 1
                    && c == segRet[0].X
                    && d == segRet[0].Y
                    && e == segRet[1].X
                    && f == segRet[1].Y)
                {
                    corners--;
                    return segRet;
                }
                if (bestAngleDif == Tau || corners == MAX_SEGS)
                {
                    return null;
                }

                lastAngle -= bestAngleDif + (.5 * Tau);
                segRet[corners++] = (e, f);
                a = c;
                b = d;
                c = e;
                d = f;
            }
        }
```

