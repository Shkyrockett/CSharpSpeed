# 2D Distance Tests

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

../../InstrumentedLibrary/Geometry/Length/Distance2DTests.cs

The required method signature for this API is as follows:

```CSharp
public static double Distance2D(double ax, double ay, double bx, double by)
```

## Test Case Index

- [Test Case: (0, 0, 1, 0)](#0,-0,-1,-0)

### (0, 0, 1, 0)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Distance2D_1(0, 0, 1, 0)](#Distance-Method-1) | 1 == 1 | 10000 in 16 ms. 0.0016 ms. average | Horizontal Line. |
| [Distance2D_2(0, 0, 1, 0)](#Distance-Method-2) | 1 == 1 | 10000 in 20 ms. 0.002 ms. average | Horizontal Line. |
| [Distance2D_3(0, 0, 1, 0)](#Distance-Method-3) | 1 == 1 | 10000 in 17 ms. 0.0017 ms. average | Horizontal Line. |

## The Code

The code for the methods tested follows below.

### Distance Method 1

This is the simple, most obvious implementation of the distance method.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Distance2D_1(
            double x1, double y1,
            double x2, double y2)
        {
            return Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
        }
```

### Distance Method 2

This method calls another distance method using Tuples. The allocation of the Tuples, and calling the other method seems to add a little more time.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Distance2D_2(
            double ax, double ay,
            double bx, double by)
            => Distance2Point2DTests.Distance2D((ax, ay), (bx, by));

        /// <summary>
        /// Distance between two 2D points.
        /// </summary>
        /// <param name="x1">First X component.</param>
        /// <param name="y1">First Y component.</param>
        /// <param name="x2">Second X component.</param>
        /// <param name="y2">Second Y component.</param>
        /// <returns>The distance between two points.</returns>
        [DisplayName("Distance Method 3")]
        [Description("This method uses two delta local variables. The allocation of the variables seems to make the method slightly slower.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Distance2D_3(
            double x1, double y1,
            double x2, double y2)
        {
            var x = x2 - x1;
            var y = y2 - y1;
            return Sqrt((x * x) + (y * y));
        }
```

### Distance Method 3

This method uses two delta local variables. The allocation of the variables seems to make the method slightly slower.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Distance2D_3(
            double x1, double y1,
            double x2, double y2)
        {
            var x = x2 - x1;
            var y = y2 - y1;
            return Sqrt((x * x) + (y * y));
        }
```

