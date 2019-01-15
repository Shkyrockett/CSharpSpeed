# Gets the Segment overlap

Determines whether segments overlap and retrieves the locations.

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

../../InstrumentedLibrary/Geometry/Intersections/LineSegmentsOverlapTests.cs

The required method signature for this API is as follows:

```CSharp
public static (bool Overlap, double Left, double Right) LineSegmentsOverlap(double a1, double a2, double b1, double b2)
```

## Test Case Index

- [Test Case: (1, 0, 3, 0)](#1,-0,-3,-0)

### (1, 0, 3, 0)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [GetOverlap(1, 0, 3, 0)](#Gets-the-Segment-overlap) | (True, 0, 1) != True | 10000 in 7 ms. 0.0007 ms. average | . |

## The Code

The code for the methods tested follows below.

### Gets the Segment overlap

Determines whether segments overlap and retrieves the locations.  
- [http://www.angusj.com/delphi/clipper.php](http://www.angusj.com/delphi/clipper.php)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (bool Overlap, double Left, double Right) GetOverlap(double a1, double a2, double b1, double b2)
        {
            (var Overlap, var Left, var Right) = (false, 0d, 0d);
            if (a1 < a2)
            {
                if (b1 < b2)
                {
                    Left = Max(a1, b1);
                    Right = Min(a2, b2);
                }
                else
                {
                    Left = Max(a1, b2);
                    Right = Min(a2, b1);
                }
            }
            else
            {
                if (b1 < b2)
                {
                    Left = Max(a2, b1);
                    Right = Min(a1, b2);
                }
                else
                {
                    Left = Max(a2, b2);
                    Right = Min(a1, b1);
                }
            }

            return (Left < Right, Left, Right);
        }
```

