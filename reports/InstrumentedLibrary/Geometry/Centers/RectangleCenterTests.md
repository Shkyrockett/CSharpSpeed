# Center of Rectangle Tests

Find the center of a rectangle.

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

../../InstrumentedLibrary/Geometry/Centers/RectangleCenterTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double X, double Y) RectangleCenter(Rectangle2D rectangle)
```

## Test Case Index

- [Test Case: (Rectangle2D{X:0, Y:0, Width:2, Height:2 })](#Rectangle2D{X:0,-Y:0,-Width:2,-Height:2-})

### (Rectangle2D{X:0, Y:0, Width:2, Height:2 })

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Center0(Rectangle2D{X:0, Y:0, Width:2, Height:2 })](#Center-of-Rectangle) | (1, 1) != 15 | 10000 in 17 ms. 0.0017 ms. average | 1, 2, 3, 4, 5 |
| [Center1(Rectangle2D{X:0, Y:0, Width:2, Height:2 })](#Center-of-Rectangle) | (1, 1) != 15 | 10000 in 15 ms. 0.0015 ms. average | 1, 2, 3, 4, 5 |

## The Code

The code for the methods tested follows below.

### Center of Rectangle

Find the center of a rectangle.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) Center0(Rectangle2D rectangle)
        {
            return (
                rectangle.Left + (rectangle.Right - rectangle.Left) * 0.5d,
                rectangle.Top + (rectangle.Bottom - rectangle.Top) * 0.5d
                );
        }
```

### Center of Rectangle

Find the center of a rectangle.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) Center1(Rectangle2D rectangle)
        {
            return (
                (rectangle.Left + rectangle.Right) * 0.5d,
                (rectangle.Top + rectangle.Bottom) * 0.5d
                );
        }
```

