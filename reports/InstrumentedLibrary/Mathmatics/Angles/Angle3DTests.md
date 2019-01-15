# 3D Angle Tests

Returns the Angle of a line that runs between two points.

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

../../InstrumentedLibrary/Mathmatics/Angles/Angle3DTests.cs

The required method signature for this API is as follows:

```CSharp
public static double Angle(double x1, double y1, double z1, double x2, double y2, double z2)
```

## Test Case Index

- [Test Case: (0, 0, 0, 1, 1, 1)](#0,-0,-0,-1,-1,-1)

### (0, 0, 0, 1, 1, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Angle0(0, 0, 0, 1, 1, 1)](#Angle-from-two-3D-points) | 0 != NaN | 10000 in 19 ms. 0.0019 ms. average | 0, 0, 0, 1, 1, 1. |

## The Code

The code for the methods tested follows below.

### Angle from two 3D points

This is the most common method of finding the angle of a line that runs between two points.  
- [http://www.codeproject.com/Articles/17425/A-Vector-Type-for-C](http://www.codeproject.com/Articles/17425/A-Vector-Type-for-C)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Angle0(
            double x1, double y1, double z1,
            double x2, double y2, double z2)
        {
            return (Abs(x1 - x2) < DoubleEpsilon
                && Abs(y1 - y2) < DoubleEpsilon
                && Abs(z1 - z2) < DoubleEpsilon)
                ? 0d : Acos(Min(1.0d, DotProduct2Vector3DTests.DotProduct(Normalize3DVectorTests.Normalize(x1, y1, z1), Normalize3DVectorTests.Normalize(x2, y2, z2))));
        }
```

