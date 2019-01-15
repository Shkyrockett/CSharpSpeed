# Horizontal Segments overlap

Determines whether horizontal segments overlap.

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

../../InstrumentedLibrary/Geometry/Intersections/HorizontalSegmentsOverlapTests.cs

The required method signature for this API is as follows:

```CSharp
public static bool HorizontalSegmentsOverlap(double segAX, double segAY, double segBX, double segBY)
```

## Test Case Index

- [Test Case: (1, 0, 3, 0)](#1,-0,-3,-0)

### (1, 0, 3, 0)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [HorzSegmentsOverlap(1, 0, 3, 0)](#Horizontal-Segments-overlap) | True == True | 10000 in 9 ms. 0.0009 ms. average | . |

## The Code

The code for the methods tested follows below.

### Horizontal Segments overlap

Determines whether horizontal segments overlap.  
- [http://www.angusj.com/delphi/clipper.php](http://www.angusj.com/delphi/clipper.php)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HorzSegmentsOverlap(double segAX, double segAY, double segBX, double segBY)
        {
            if (segAX > segAY)
            {
                SwapTests.Swap(ref segAX, ref segAY);
            }

            if (segBX > segBY)
            {
                SwapTests.Swap(ref segBX, ref segBY);
            }

            return (segAX < segBY) && (segBX < segAY);
        }
```

