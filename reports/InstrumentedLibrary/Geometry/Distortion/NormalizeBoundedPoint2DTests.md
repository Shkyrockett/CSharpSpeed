# Normalize Point to Bounding Box

Normalize the position of a point to a surrounding bounding box as a percentage of that box.

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

../../InstrumentedLibrary/Geometry/Distortion/NormalizeBoundedPoint2DTests.cs

The required method signature for this API is as follows:

```CSharp
public static Point2D NormalizeBoundedPoint(Rectangle2D bounds, Point2D point)
```

## Test Case Index

- [Test Case: (Rectangle2D{X:0, Y:0, Width:10, Height:10 }, Point2D{X:5, Y:5 })](#Rectangle2D{X:0,-Y:0,-Width:10,-Height:10-},-Point2D{X:5,-Y:5-})

### (Rectangle2D{X:0, Y:0, Width:10, Height:10 }, Point2D{X:5, Y:5 })

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [NormalizePoint(Rectangle2D{X:0, Y:0, Width:10, Height:10 }, Point2D{X:5, Y:5 })](#Normalize-2D-Point-to-Bounding-Rectangle) | Point2D{X:0.5, Y:0.5 } == Point2D{X:0.5, Y:0.5 } | 10000 in 11 ms. 0.0011 ms. average | Point Inside |

## The Code

The code for the methods tested follows below.

### Normalize 2D Point to Bounding Rectangle

Normalizes a point, so that it is expressed as percentage coordinates relative to the bounding box.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D NormalizePoint(Rectangle2D bounds, Point2D point)
        {
            return new Point2D(
                (point.X - bounds.X) / bounds.Width,
                (point.Y - bounds.Top) / bounds.Height
                );
        }
```

