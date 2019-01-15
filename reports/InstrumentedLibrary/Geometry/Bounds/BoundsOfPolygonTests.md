# Polygon Bounds Tests

Calculate bounding rectangle of a polygon.

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

../../InstrumentedLibrary/Geometry/Bounds/BoundsOfPolygonTests.cs

The required method signature for this API is as follows:

```CSharp
public static Rectangle2D PolygonBounds(List<List<(double X, double Y)>> paths)
```

## Test Case Index

- [Test Case: (System.Collections.Generic.List`1[System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]]])](#System.Collections.Generic.List`1[System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]]])

### (System.Collections.Generic.List`1[System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]]])

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [GetBounds0(System.Collections.Generic.List`1[System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]]])](#Polygon-Bounds) | Rectangle2D{X:0, Y:0, Width:25, Height:30 } != 6.2831853071795862 | 10000 in 48 ms. 0.0048 ms. average | Circle test case. |

## The Code

The code for the methods tested follows below.

### Polygon Bounds

Find bounds of a polygon.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rectangle2D GetBounds0(List<List<(double X, double Y)>> paths)
        {
            var i = 0;
            var cnt = paths.Count;
            while (i < cnt && paths[i].Count == 0)
            {
                i++;
            }

            if (i == cnt)
            {
                return new Rectangle2D(0, 0, 0, 0);
            }

            var result = new Rectangle2D
            {
                Left = paths[i][0].X
            };
            result.Right = result.Left;
            result.Top = paths[i][0].Y;
            result.Bottom = result.Top;
            for (; i < cnt; i++)
            {
                for (var j = 0; j < paths[i].Count; j++)
                {
                    if (paths[i][j].X < result.Left)
                    {
                        result.Left = paths[i][j].X;
                    }
                    else if (paths[i][j].X > result.Right)
                    {
                        result.Right = paths[i][j].X;
                    }

                    if (paths[i][j].Y < result.Top)
                    {
                        result.Top = paths[i][j].Y;
                    }
                    else if (paths[i][j].Y > result.Bottom)
                    {
                        result.Bottom = paths[i][j].Y;
                    }
                }
            }

            return result;
        }
```

