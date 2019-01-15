# Slopes Near Collinear Tests

Determines whether slopes are collinear.

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

../../InstrumentedLibrary/Mathmatics/Angles/SlopesNearCollinearTests.cs

The required method signature for this API is as follows:

```CSharp
public static bool SlopesNearCollinear(Point2D a, Point2D b, Point2D c, double distSqrd)
```

## Test Case Index

- [Test Case: (Point2D{X:1, Y:2 }, Point2D{X:2, Y:1 }, Point2D{X:1, Y:2 }, 1)](#Point2D{X:1,-Y:2-},-Point2D{X:2,-Y:1-},-Point2D{X:1,-Y:2-},-1)

### (Point2D{X:1, Y:2 }, Point2D{X:2, Y:1 }, Point2D{X:1, Y:2 }, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [SlopesNearCollinear0(Point2D{X:1, Y:2 }, Point2D{X:2, Y:1 }, Point2D{X:1, Y:2 }, 1)](#Slopes-Near-Collinear) | True == True | 10000 in 10 ms. 0.001 ms. average | 1, 2, 3, 4, 5 |

## The Code

The code for the methods tested follows below.

### Slopes Near Collinear

Determines whether slopes are collinear.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SlopesNearCollinear0(Point2D a, Point2D b, Point2D c, double distSqrd)
        {
            // This function is more accurate when the point that is GEOMETRICALLY
            // between the other 2 points is the one that is tested for distance.
            // nb: with 'spikes', either pt1 or pt3 is geometrically between the other pts.
            if (Abs(a.X - b.X) > Abs(a.Y - b.Y))
            {
                if ((a.X > b.X) == (a.X < c.X))
                {
                    return SquareDistanceToLineTests.SquareDistanceToLine(a.X, a.Y, b.X, b.Y, c.X, c.Y) < distSqrd;
                }
                else if ((b.X > a.X) == (b.X < c.X))
                {
                    return SquareDistanceToLineTests.SquareDistanceToLine(b.X, b.Y, a.X, a.Y, c.X, c.Y) < distSqrd;
                }
                else
                {
                    return SquareDistanceToLineTests.SquareDistanceToLine(c.X, c.Y, a.X, a.Y, b.X, b.Y) < distSqrd;
                }
            }
            else
            {
                if ((a.Y > b.Y) == (a.Y < c.Y))
                {
                    return SquareDistanceToLineTests.SquareDistanceToLine(a.X, a.Y, b.X, b.Y, c.X, c.Y) < distSqrd;
                }
                else if ((b.Y > a.Y) == (b.Y < c.Y))
                {
                    return SquareDistanceToLineTests.SquareDistanceToLine(b.X, b.Y, a.X, a.Y, c.X, c.Y) < distSqrd;
                }
                else
                {
                    return SquareDistanceToLineTests.SquareDistanceToLine(c.X, c.Y, a.X, a.Y, b.X, b.Y) < distSqrd;
                }
            }
        }
```

