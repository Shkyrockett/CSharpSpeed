# Rectangle Near Rectangle Tests

Determines whether a Rectangle is near another Rectangle.

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

../../InstrumentedLibrary/Geometry/Intersections/RectanglesAreCloseTests.cs

The required method signature for this API is as follows:

```CSharp
public static bool AreRectanglesClose(Rectangle2D rect1, Rectangle2D rect2, double epsilon = DoubleEpsilon)
```

## Test Case Index

- [Test Case: (Rectangle2D{X:0, Y:0, Width:1, Height:1 }, Rectangle2D{X:1, Y:1, Width:2, Height:2 }, 2.22044604925031E-16)](#Rectangle2D{X:0,-Y:0,-Width:1,-Height:1-},-Rectangle2D{X:1,-Y:1,-Width:2,-Height:2-},-2.22044604925031E-16)

### (Rectangle2D{X:0, Y:0, Width:1, Height:1 }, Rectangle2D{X:1, Y:1, Width:2, Height:2 }, 2.22044604925031E-16)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [AreClose(Rectangle2D{X:0, Y:0, Width:1, Height:1 }, Rectangle2D{X:1, Y:1, Width:2, Height:2 }, 2.22044604925031E-16)](#Rectangle-Near-Rectangle) | False != 15 | 10000 in 9 ms. 0.0009 ms. average | . |

## The Code

The code for the methods tested follows below.

### Rectangle Near Rectangle

Determines whether a Rectangle is near another Rectangle.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AreClose(Rectangle2D rect1, Rectangle2D rect2, double epsilon = DoubleEpsilon)
        {
            // If they're both empty, don't bother with the double logic.
            if (RectangleIsEmptyTests.IsRectangleEmpty(rect1.Width, rect1.Height))
            {
                return RectangleIsEmptyTests.IsRectangleEmpty(rect2.Width, rect2.Height);
            }

            // At this point, rect1 isn't empty, so the first thing we can test is
            // rect2.IsEmpty, followed by property-wise compares.
            return (!RectangleIsEmptyTests.IsRectangleEmpty(rect2.Width, rect2.Height))
                && AreCloseTests.AreClose(rect1.X, rect2.X, epsilon)
                && AreCloseTests.AreClose(rect1.Y, rect2.Y, epsilon)
                && AreCloseTests.AreClose(rect1.Height, rect2.Height, epsilon)
                && AreCloseTests.AreClose(rect1.Width, rect2.Width, epsilon);
        }
```

