# Line Segment In Polygon Tests

Determine whether a line segment is contained within a Polygon set.

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

../../InstrumentedLibrary/Geometry/Contains/LineSegmentInPolygonTests.cs

The required method signature for this API is as follows:

```CSharp
public static bool LineInPolygon(Point2D start, Point2D end, PolygonContour2D polygon)
```

## Test Case Index

- [Test Case: (Point2D{X:1, Y:1 }, Point2D{X:2, Y:2 }, PolygonContour2D{Point2D{X:0, Y:0 },Point2D{X:2, Y:0 },Point2D{X:0, Y:2 } })](#Point2D{X:1,-Y:1-},-Point2D{X:2,-Y:2-},-PolygonContour2D{Point2D{X:0,-Y:0-},Point2D{X:2,-Y:0-},Point2D{X:0,-Y:2-}-})

### (Point2D{X:1, Y:1 }, Point2D{X:2, Y:2 }, PolygonContour2D{Point2D{X:0, Y:0 },Point2D{X:2, Y:0 },Point2D{X:0, Y:2 } })

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [LineInPolygon0(Point2D{X:1, Y:1 }, Point2D{X:2, Y:2 }, PolygonContour2D{Point2D{X:0, Y:0 },Point2D{X:2, Y:0 },Point2D{X:0, Y:2 } })](#Line-in-Polygon) | False != True | 10000 in 24 ms. 0.0024 ms. average | polygon, point. |

## The Code

The code for the methods tested follows below.

### Line in Polygon

AlienRyderFlex Line in Polygon method.  
- [http://alienryderflex.com/shortest_path/](http://alienryderflex.com/shortest_path/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool LineInPolygon0(Point2D start, Point2D end, PolygonContour2D polygon)
        {
            int i;
            int j;
            double sX;
            double sY;
            double eX;
            double eY;
            double rotSX;
            double rotSY;
            double rotEX;
            double rotEY;
            double crossX;

            end.X -= start.X;
            end.Y -= start.Y;
            var dist = Sqrt((end.X * end.X) + (end.Y * end.Y));
            var theCos = end.X / dist;
            var theSin = end.Y / dist;
            for (i = 0; i < polygon.Points.Count(); i++)
            {
                j = i + 1;
                if (j == polygon.Points.Count())
                {
                    j = 0;
                }

                sX = (polygon.Points as List<Point2D>)[i].X - start.X;
                sY = (polygon.Points as List<Point2D>)[i].Y - start.Y;
                eX = (polygon.Points as List<Point2D>)[j].X - start.X;
                eY = (polygon.Points as List<Point2D>)[j].Y - start.Y;
                if (Abs(sX) < DoubleEpsilon
                    && Abs(sY) < DoubleEpsilon
                    && Abs(eX - end.X) < DoubleEpsilon
                    && Abs(eY - end.Y) < DoubleEpsilon
                    || Abs(eX) < DoubleEpsilon
                    && Abs(eY) < DoubleEpsilon
                    && Abs(sX - end.X) < DoubleEpsilon
                    && Abs(sY - end.Y) < DoubleEpsilon)
                {
                    return true;
                }

                rotSX = (sX * theCos) + (sY * theSin);
                rotSY = (sY * theCos) - (sX * theSin);
                rotEX = (eX * theCos) + (eY * theSin);
                rotEY = (eY * theCos) - (eX * theSin);
                if (rotSY < 0d && rotEY > 0d
                || rotEY < 0d && rotSY > 0d)
                {
                    crossX = rotSX + ((rotEX - rotSX) * (0d - rotSY) / (rotEY - rotSY));
                    if (crossX >= 0.0 && crossX <= dist)
                    {
                        return false;
                    }
                }

                if (Abs(rotSY) < DoubleEpsilon
                    && Abs(rotEY) < DoubleEpsilon
                    && (rotSX >= 0d || rotEX >= 0d)
                    && (rotSX <= dist || rotEX <= dist)
                    && (rotSX < 0d || rotEX < 0d
                    || rotSX > dist || rotEX > dist))
                {
                    return false;
                }
            }

            return PolygonContourContainsPointTests.PointInPolygonContourAlienRyderFlex(polygon.Points.ToList(), new Point2D(start.X + (end.X * 0.5d), start.Y + (end.Y * 0.5d)));
        }
```

