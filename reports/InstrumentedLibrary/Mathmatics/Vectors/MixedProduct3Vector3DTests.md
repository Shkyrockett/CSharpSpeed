# Mixed Product 3 Vector2D Tests

Returns the Mixed product of three 2D vectors.

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

../../InstrumentedLibrary/Mathmatics/Vectors/MixedProduct3Vector3DTests.cs

The required method signature for this API is as follows:

```CSharp
public static double MixedProduct3D(double x1, double y1, double z1, double x2, double y2, double z2, double x3, double y3, double z3)
```

## Test Case Index

- [Test Case: (0, 0, 0, 1, 1, 1, 2, 2, 2)](#0,-0,-0,-1,-1,-1,-2,-2,-2)

### (0, 0, 0, 1, 1, 1, 2, 2, 2)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [MixedProduct3D_0(0, 0, 0, 1, 1, 1, 2, 2, 2)](#Mixed-Product-of-three-2D-Vectors-1) | 0 != -1 | 10000 in 18 ms. 0.0018 ms. average | 0, 0, 1, 0, 1, 1. |

## The Code

The code for the methods tested follows below.

### Mixed Product of three 2D Vectors 1

Mixed Product of two 2D Vectors  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double MixedProduct3D_0(
            double x1, double y1, double z1,
            double x2, double y2, double z2,
            double x3, double y3, double z3)
        {
            var (cx, cy, cz) = CrossProduct2Vector3DTests.CrossProduct2Points3D(x1, y1, z1, x2, y2, z2);
            return DotProduct2Vector3DTests.DotProduct(cx, cy, cz, x3, y3, z3);
        }
```

