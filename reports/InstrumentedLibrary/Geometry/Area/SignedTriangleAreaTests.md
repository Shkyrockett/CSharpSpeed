# Signed Area of Triangle

Find the signed area of a triangle.

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

../../InstrumentedLibrary/Geometry/Area/SignedTriangleAreaTests.cs

The required method signature for this API is as follows:

```CSharp
public static double SignedTriangleArea(double aX, double aY, double bX, double bY, double cX, double cY)
```

## Test Case Index

- [Test Case: (0, 0, 0, 1, 1, 1)](#0,-0,-0,-1,-1,-1)

### (0, 0, 0, 1, 1, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [SignedTriangleAreaVelcroPhysics(0, 0, 0, 1, 1, 1)](#Signed-Area-of-Triangle) | -1 != 1.2283696986087567 | 10000 in 22 ms. 0.0022 ms. average | Two unit circles, one at origin, the other shifted to the right one unit. |
| [SignedTriangleAreaW8R(0, 0, 0, 1, 1, 1)](#Signed-Area-of-Triangle) | -1 != 1.2283696986087567 | 10000 in 25 ms. 0.0025 ms. average | Two unit circles, one at origin, the other shifted to the right one unit. |

## The Code

The code for the methods tested follows below.

### Signed Area of Triangle

Find the signed area of a triangle.  
- [https://github.com/VelcroPhysics/VelcroPhysics](https://github.com/VelcroPhysics/VelcroPhysics)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SignedTriangleAreaVelcroPhysics(double aX, double aY, double bX, double bY, double cX, double cY)
        {
            return aX * (bY - cY) + bX * (cY - aY) + cX * (aY - bY);
        }
```

### Signed Area of Triangle

Find the signed area of a triangle.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SignedTriangleAreaW8R(double aX, double aY, double bX, double bY, double cX, double cY)
        {
            return (aX - cX) * (bY - cY) - (bX - cX) * (aY - cY);
        }
```

