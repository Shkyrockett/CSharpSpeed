# Vector between Vectors Tests

Determine whether a vector is between two other vectors.

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

../../InstrumentedLibrary/Geometry/Contains/VectorBetweenVectorsTests.cs

The required method signature for this API is as follows:

```CSharp
public static bool VectorBetween(double i, double j, double i2, double j2, double i3, double j3)
```

## Test Case Index

- [Test Case: (0.707106781186548, 0.707106781186548, 1, 6.12323399573677E-17, 0, 1)](#0.707106781186548,-0.707106781186548,-1,-6.12323399573677E-17,-0,-1)

### (0.707106781186548, 0.707106781186548, 1, 6.12323399573677E-17, 0, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [VectorBetween0(0.707106781186548, 0.707106781186548, 1, 6.12323399573677E-17, 0, 1)](#Vector-between-Vectors) | True == True | 10000 in 17 ms. 0.0017 ms. average | polygon, point. |
| [VectorBetween1(0.707106781186548, 0.707106781186548, 1, 6.12323399573677E-17, 0, 1)](#Vector-between-Vectors) | True == True | 10000 in 15 ms. 0.0015 ms. average | polygon, point. |

## The Code

The code for the methods tested follows below.

### Vector between Vectors

Determine whether a vector is between two other vectors.  
- [http://math.stackexchange.com/questions/1698835/find-if-a-vector-is-between-2-vectors](http://math.stackexchange.com/questions/1698835/find-if-a-vector-is-between-2-vectors)
- [http://stackoverflow.com/questions/13640931/how-to-determine-if-a-vector-is-between-two-other-vectors](http://stackoverflow.com/questions/13640931/how-to-determine-if-a-vector-is-between-two-other-vectors)
- [http://gamedev.stackexchange.com/questions/22392/what-is-a-good-way-to-determine-if-a-vector-is-between-two-other-vectors-in-2d](http://gamedev.stackexchange.com/questions/22392/what-is-a-good-way-to-determine-if-a-vector-is-between-two-other-vectors-in-2d)
- [http://math.stackexchange.com/questions/169998/figure-out-if-a-fourth-point-resides-within-an-angle-created-by-three-other-poin](http://math.stackexchange.com/questions/169998/figure-out-if-a-fourth-point-resides-within-an-angle-created-by-three-other-poin)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool VectorBetween0(double i, double j, double i2, double j2, double i3, double j3)
        {
            return CrossProduct2Vector2DTests.CrossProduct2Vector2D(i2, j2, i, j) * CrossProduct2Vector2DTests.CrossProduct2Vector2D(i2, j2, i3, j3) >= 0
                && CrossProduct2Vector2DTests.CrossProduct2Vector2D(i3, j3, i, j) * CrossProduct2Vector2DTests.CrossProduct2Vector2D(i3, j3, i2, j2) >= 0;
        }
```

### Vector between Vectors

Determine whether a vector is between two other vectors.  
- [http://math.stackexchange.com/questions/1698835/find-if-a-vector-is-between-2-vectors](http://math.stackexchange.com/questions/1698835/find-if-a-vector-is-between-2-vectors)
- [http://stackoverflow.com/questions/13640931/how-to-determine-if-a-vector-is-between-two-other-vectors](http://stackoverflow.com/questions/13640931/how-to-determine-if-a-vector-is-between-two-other-vectors)
- [http://gamedev.stackexchange.com/questions/22392/what-is-a-good-way-to-determine-if-a-vector-is-between-two-other-vectors-in-2d](http://gamedev.stackexchange.com/questions/22392/what-is-a-good-way-to-determine-if-a-vector-is-between-two-other-vectors-in-2d)
- [http://math.stackexchange.com/questions/169998/figure-out-if-a-fourth-point-resides-within-an-angle-created-by-three-other-poin](http://math.stackexchange.com/questions/169998/figure-out-if-a-fourth-point-resides-within-an-angle-created-by-three-other-poin)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool VectorBetween1(double i, double j, double i2, double j2, double i3, double j3)
        {
            return ((i2 * j) - (j2 * i)) * ((i2 * j3) - (j2 * i3)) >= 0
                && ((i3 * j) - (j3 * i)) * ((i3 * j2) - (j3 * i2)) >= 0;
        }
```

