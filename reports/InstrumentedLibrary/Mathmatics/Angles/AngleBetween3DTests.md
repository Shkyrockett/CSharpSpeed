# Angle Between 3D Vectors Tests

Find the angle between two 3D vectors.

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

../../InstrumentedLibrary/Mathmatics/Angles/AngleBetween3DTests.cs

The required method signature for this API is as follows:

```CSharp
public static double AngleBetween(double uX, double uY, double uZ, double vX, double vY, double vZ)
```

## Test Case Index

- [Test Case: (0, 0, 0, 1, 1, 1)](#0,-0,-0,-1,-1,-1)

### (0, 0, 0, 1, 1, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [AngleBetween0(0, 0, 0, 1, 1, 1)](#AngleBetween) | NaN == NaN | 10000 in 13 ms. 0.0013 ms. average |  0, 0, 0, 1, 1, 1. |

## The Code

The code for the methods tested follows below.

### AngleBetween

James Ramsden's method of finding the angle between two 3D vectors.  
- [http://james-ramsden.com/angle-between-two-vectors/](http://james-ramsden.com/angle-between-two-vectors/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AngleBetween0(
            double uX, double uY, double uZ,
            double vX, double vY, double vZ)
        {
            return Acos(((uX * vX) + (uY * vY) + (uZ * vZ)) / Sqrt(((uX * uX) + (uY * uY) + (uZ * uZ)) * ((vX * vX) + (vY * vY) + (vZ * vZ))));
        }
```

