# 2 Point 2D Distance Tests

Find the distance between two points.

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

../../InstrumentedLibrary/Geometry/Length/Distance2Point2DTests.cs

The required method signature for this API is as follows:

```CSharp
public static double Distance2D((double X, double Y) a, (double X, double Y) b)
```

## Test Case Index

- [Test Case: ((0, 0), (1, 0))](#(0,-0),-(1,-0))

### ((0, 0), (1, 0))

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Distance_2((0, 0), (1, 0))](#Distance-Method-1) | 1 == 1 | 10000 in 5 ms. 0.0005 ms. average | Horizontal Line. |
| [Distance2D_1((0, 0), (1, 0))](#Distance-Method-1) | 1 == 1 | 10000 in 11 ms. 0.0011 ms. average | Horizontal Line. |

## The Code

The code for the methods tested follows below.

### Distance Method 1

Find the distance between two points.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Distance_2(
            (double X, double Y) a,
            (double X, double Y) b)
        {
            var dx = a.X - b.X;
            var dy = a.Y - b.Y;
            return Sqrt((dx * dx) + (dy * dy));
        }
```

### Distance Method 1

Find the distance between two points.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Distance2D_1(
            (double X, double Y) a,
            (double X, double Y) b)
        {
            return Sqrt(((b.X - a.X) * (b.X - a.X)) + ((b.Y - a.Y) * (b.X - a.Y)));
        }
```

