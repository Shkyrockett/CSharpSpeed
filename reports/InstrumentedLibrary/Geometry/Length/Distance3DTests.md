# 3D Distance Tests

Find the distance between two 3D points.

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

../../InstrumentedLibrary/Geometry/Length/Distance3DTests.cs

The required method signature for this API is as follows:

```CSharp
public static double Distance3D(double x1, double y1, double z1, double x2, double y2, double z2)
```

## Test Case Index

- [Test Case: (0, 0, 0, 1, 0, 0)](#0,-0,-0,-1,-0,-0)
- [Test Case: (0, 0, 0, 1, 0, 1)](#0,-0,-0,-1,-0,-1)

### (0, 0, 0, 1, 0, 0)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Distance3D_1(0, 0, 0, 1, 0, 0)](#Distance-Method-1) | 1 == 1 | 10000 in 11 ms. 0.0011 ms. average | Horizontal Line. |
| [Distance3D_2(0, 0, 0, 1, 0, 0)](#Distance-Method-2) | 1 == 1 | 10000 in 9 ms. 0.0009 ms. average | Horizontal Line. |

### (0, 0, 0, 1, 0, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Distance3D_1(0, 0, 0, 1, 0, 1)](#Distance-Method-1) | 1.4142135623730951 != 1 | 10000 in 12 ms. 0.0012 ms. average | Horizontal Line. |
| [Distance3D_2(0, 0, 0, 1, 0, 1)](#Distance-Method-2) | 1.4142135623730951 != 1 | 10000 in 8 ms. 0.0008 ms. average | Horizontal Line. |

## The Code

The code for the methods tested follows below.

### Distance Method 1

This is the simple, most obvious implementation of the distance method.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Distance3D_1(
            double x1, double y1, double z1,
            double x2, double y2, double z2)
        {
            return Sqrt(((x2 - x1) * (x2 - x1))
                           + ((y2 - y1) * (y2 - y1))
                           + ((z2 - z1) * (z2 - z1)));
        }
```

### Distance Method 2

This method uses two delta local variables. The allocation of the variables seems to make the method slightly slower.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Distance3D_2(
            double x1, double y1, double z1,
            double x2, double y2, double z2)
        {
            var x = x2 - x1;
            var y = y2 - y1;
            var z = z2 - z1;
            return Sqrt((x * x) + (y * y) + (z * z));
        }
```

