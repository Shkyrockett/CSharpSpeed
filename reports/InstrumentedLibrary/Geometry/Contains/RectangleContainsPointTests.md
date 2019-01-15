# Rectangle Contains Point

Determine whether a point is contained within a Rectangle.

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

../../InstrumentedLibrary/Geometry/Contains/RectangleContainsPointTests.cs

The required method signature for this API is as follows:

```CSharp
public static Inclusion RectangleContainsPoint2D(Rectangle2D rectangle, Point2D point)
```

## Test Case Index

- [Test Case: (Rectangle2D{X:0, Y:0, Width:2, Height:2 }, Point2D{X:1, Y:1 })](#Rectangle2D{X:0,-Y:0,-Width:2,-Height:2-},-Point2D{X:1,-Y:1-})

### (Rectangle2D{X:0, Y:0, Width:2, Height:2 }, Point2D{X:1, Y:1 })

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Contains(Rectangle2D{X:0, Y:0, Width:2, Height:2 }, Point2D{X:1, Y:1 })](#Point-in-Rectangle) | Inside != True | 10000 in 13 ms. 0.0013 ms. average | rectangle, point. |
| [Contains2(Rectangle2D{X:0, Y:0, Width:2, Height:2 }, Point2D{X:1, Y:1 })](#Point-in-Rectangle) | Inside != True | 10000 in 12 ms. 0.0012 ms. average | rectangle, point. |
| [PointOnRectangleX(Rectangle2D{X:0, Y:0, Width:2, Height:2 }, Point2D{X:1, Y:1 })](#Point-in-Rectangle) | Inside != True | 10000 in 19 ms. 0.0019 ms. average | rectangle, point. |

## The Code

The code for the methods tested follows below.

### Point in Rectangle

Point in Rectangle method.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion Contains(Rectangle2D rectangle, Point2D point)
        {
            return (rectangle.X <= point.X
                && point.X < rectangle.X + rectangle.Width
                && rectangle.Y <= point.Y
                && point.Y < rectangle.Y + rectangle.Height) ? Inclusion.Inside : Inclusion.Outside;
        }
```

### Point in Rectangle

Point in Rectangle method.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion Contains2(Rectangle2D rectangle, Point2D point)
        {
            if (((Abs(rectangle.X - point.X) < DoubleEpsilon
                || Abs(rectangle.Bottom - point.X) < DoubleEpsilon)
                && ((rectangle.Y <= point.Y) == (rectangle.Bottom >= point.Y)))
             || ((Abs(rectangle.Right - point.Y) < DoubleEpsilon
             || Abs(rectangle.Left - point.Y) < DoubleEpsilon)
             && ((rectangle.X <= point.X) == (rectangle.Right >= point.X))))
            {
                return Inclusion.Boundary;
            }

            return (rectangle.X <= point.X
                && point.X < rectangle.X + rectangle.Width
                && rectangle.Y <= point.Y
                && point.Y < rectangle.Y + rectangle.Height) ? Inclusion.Inside : Inclusion.Outside;
        }
```

### Point in Rectangle

Point in Rectangle method.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion PointOnRectangleX(Rectangle2D rectangle, Point2D point)
        {
            var top = Sqrt((rectangle.Right - rectangle.Left) * (rectangle.Right - rectangle.Left) + (rectangle.Top - rectangle.Top) * (rectangle.Top - rectangle.Top));
            var right = Sqrt((rectangle.Right - rectangle.Right) * (rectangle.Right - rectangle.Right) + (rectangle.Bottom - rectangle.Top) * (rectangle.Bottom - rectangle.Top));
            var tlp = (point.X - rectangle.Left) * (point.X - rectangle.Left) + (point.Y - rectangle.Top) * (point.Y - rectangle.Top);
            var trp = (point.X - rectangle.Right) * (point.X - rectangle.Right) + (point.Y - rectangle.Top) * (point.Y - rectangle.Top);
            var brp = (point.X - rectangle.Right) * (point.X - rectangle.Right) + (point.Y - rectangle.Bottom) * (point.Y - rectangle.Bottom);
            var blp = (point.X - rectangle.Left) * (point.X - rectangle.Left) + (point.Y - rectangle.Bottom) * (point.Y - rectangle.Bottom);

            if (Abs(top - Sqrt(tlp - trp)) < DoubleEpsilon
                || Abs(right - Sqrt(trp - brp)) < DoubleEpsilon
                || Abs(top - Sqrt(brp - blp)) < DoubleEpsilon
                || Abs(right - Sqrt(blp - tlp)) < DoubleEpsilon)
            {
                return Inclusion.Boundary;
            }

            return (rectangle.X <= point.X
                && point.X < rectangle.X + rectangle.Width
                && rectangle.Y <= point.Y
                && point.Y < rectangle.Y + rectangle.Height) ? Inclusion.Inside : Inclusion.Outside;
        }
```

