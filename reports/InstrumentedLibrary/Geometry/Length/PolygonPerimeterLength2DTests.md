# Polygon Perimeter Length Tests

Calculate the length of the Perimeter of a polygon.

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

../../InstrumentedLibrary/Geometry/Length/PolygonPerimeterLength2DTests.cs

The required method signature for this API is as follows:

```CSharp
public static double PolygonPerimeterLength2D(IEnumerable<(double X, double Y)> points)
```

## Test Case Index

- [Test Case: (System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]])](#System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]])

### (System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]])

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Perimeter0(System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]])](#Perimeter-of-Polygon) | 2.4142135623730949 != 6.2831853071795862 | 10000 in 33 ms. 0.0033 ms. average | Circle test case. |
| [Perimeter1(System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]])](#Perimiter-of-Polygon) | 2 != 6.2831853071795862 | 10000 in 32 ms. 0.0032 ms. average | Circle test case. |

## The Code

The code for the methods tested follows below.

### Perimeter of Polygon

Find Perimeter length of a polygon.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Perimeter0(IEnumerable<(double X, double Y)> points)
        {
            var last = (points as List<(double X, double Y)>)[0];
            double dist = 0;
            foreach (var cur in points.Skip(1))
            {
                dist += Distance2DTests.Distance2D(last.X, last.Y, cur.X, cur.Y);
                last = cur;
            }
            return dist;
        }
```

### Perimiter of Polygon

Find Perimeter length of a polygon.  
- [http://stackoverflow.com/questions/2227828/find-the-distance-required-to-navigate-a-list-of-points-using-linq](http://stackoverflow.com/questions/2227828/find-the-distance-required-to-navigate-a-list-of-points-using-linq)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Perimeter1(IEnumerable<(double X, double Y)> points)
        {
            return points.Zip(points.Skip(1), Distance2Point2DTests.Distance2D_1).Sum();
        }
```

