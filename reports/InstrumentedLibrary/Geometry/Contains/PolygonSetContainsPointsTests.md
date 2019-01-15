# Polygon Set Contains Points

Find out whether a Polygon Set Contains a point.

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

../../InstrumentedLibrary/Geometry/Contains/PolygonSetContainsPointsTests.cs

The required method signature for this API is as follows:

```CSharp
public static Inclusion PolygonSetContainsPoints(Polygon2D polygons, Point2D start, Point2D end, double epsilon = Epsilon)
```

## Test Case Index

- [Test Case: (Polygon2D{PolygonContour2D{Point2D{X:0, Y:0 },Point2D{X:2, Y:0 },Point2D{X:0, Y:2 } } }, Point2D{X:1, Y:1 }, Point2D{X:2, Y:2 }, 5.6843418860808E-12)](#Polygon2D{PolygonContour2D{Point2D{X:0,-Y:0-},Point2D{X:2,-Y:0-},Point2D{X:0,-Y:2-}-}-},-Point2D{X:1,-Y:1-},-Point2D{X:2,-Y:2-},-5.6843418860808E-12)

### (Polygon2D{PolygonContour2D{Point2D{X:0, Y:0 },Point2D{X:2, Y:0 },Point2D{X:0, Y:2 } } }, Point2D{X:1, Y:1 }, Point2D{X:2, Y:2 }, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [PolygonSetContainsPoints0(Polygon2D{PolygonContour2D{Point2D{X:0, Y:0 },Point2D{X:2, Y:0 },Point2D{X:0, Y:2 } } }, Point2D{X:1, Y:1 }, Point2D{X:2, Y:2 }, 5.6843418860808E-12)](#Polygon-Set-Contains-Points) | Outside != 1 | 10000 in 21 ms. 0.0021 ms. average | . |

## The Code

The code for the methods tested follows below.

### Polygon Set Contains Points

Find out whether a Polygon Set Contains a point.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion PolygonSetContainsPoints0(
            Polygon2D polygons,
            Point2D start, Point2D end,
            double epsilon = Epsilon)
        {
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

            foreach (PolygonContour2D poly in polygons.Contours)
            {
                for (var i = 0; i < poly.Points.Count(); i++)
                {
                    j = i + 1;
                    if (j == poly.Points.Count())
                    {
                        j = 0;
                    }

                    sX = (poly.Points as List<Point2D>)[i].X - start.X;
                    sY = (poly.Points as List<Point2D>)[i].Y - start.Y;
                    eX = (poly.Points as List<Point2D>)[j].X - start.X;
                    eY = (poly.Points as List<Point2D>)[j].Y - start.Y;

                    if (Abs(sX) < epsilon && Abs(sY) < epsilon
                        && Abs(eX - end.X) < epsilon && Abs(eY - end.Y) < epsilon
                        || Abs(eX) < epsilon
                        && Abs(eY) < epsilon && Abs(sX - end.X) < epsilon
                        && Abs(sY - end.Y) < epsilon)
                    {
                        return Inclusion.Inside;
                    }

                    rotSX = (sX * theCos) + (sY * theSin);
                    rotSY = (sY * theCos) - (sX * theSin);
                    rotEX = (eX * theCos) + (eY * theSin);
                    rotEY = (eY * theCos) - (eX * theSin);

                    if (rotSY < 0.0 && rotEY > 0.0
                    || rotEY < 0.0 && rotSY > 0.0)
                    {
                        crossX = rotSX + ((rotEX - rotSX) * (0.0 - rotSY) / (rotEY - rotSY));
                        if (crossX >= 0.0 && crossX <= dist)
                        {
                            return Inclusion.Outside;
                        }
                    }

                    if (Abs(rotSY) < epsilon
                        && Abs(rotEY) < epsilon
                        && (rotSX >= 0.0 || rotEX >= 0.0)
                        && (rotSX <= dist || rotEX <= dist)
                        && (rotSX < 0.0 || rotEX < 0.0
                        || rotSX > dist || rotEX > dist))
                    {
                        return Inclusion.Outside;
                    }
                }
            }

            return Point2DInPolygonSetTests.PointInPolygonSetAlienRyderFlex(polygons, new Point2D(start.X + (end.X / 2.0), start.Y + (end.Y / 2.0))) ? Inclusion.Inside : Inclusion.Outside;
        }
```

