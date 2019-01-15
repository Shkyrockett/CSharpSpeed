# Rectangle has NaN Tests

Rectangle has NaN.

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

../../InstrumentedLibrary/Geometry/RectangleHasNaNTests.cs

The required method signature for this API is as follows:

```CSharp
public static bool RectHasNaN(Rectangle2D rect)
```

## Test Case Index

- [Test Case: (Rectangle2D{X:NaN, Y:NaN, Width:NaN, Height:NaN })](#Rectangle2D{X:NaN,-Y:NaN,-Width:NaN,-Height:NaN-})

### (Rectangle2D{X:NaN, Y:NaN, Width:NaN, Height:NaN })

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [RectHasNaN0(Rectangle2D{X:NaN, Y:NaN, Width:NaN, Height:NaN })](#Rectangle-has-NaN-Tests) | True == True | 10000 in 6 ms. 0.0006 ms. average | Circle from three points test case. |

## The Code

The code for the methods tested follows below.

### Rectangle has NaN Tests

Rectangle has NaN.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool RectHasNaN0(Rectangle2D rect)
        {
            return double.IsNaN(rect.X)
                || double.IsNaN(rect.Y)
                || double.IsNaN(rect.Height)
                || double.IsNaN(rect.Width);
        }
```

