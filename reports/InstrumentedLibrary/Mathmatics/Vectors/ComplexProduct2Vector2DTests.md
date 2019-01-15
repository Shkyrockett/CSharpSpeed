# Complex Product 2 Vector2D Tests

Returns the Complex product of two 2D vectors.

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

../../InstrumentedLibrary/Mathmatics/Vectors/ComplexProduct2Vector2DTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double X, double Y) ComplexProduct(double x0, double y0, double x1, double y1)
```

## Test Case Index

- [Test Case: (0, 0, 1, 1)](#0,-0,-1,-1)

### (0, 0, 1, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [ComplexProduct0(0, 0, 1, 1)](#Complex-Product-of-two-2D-Vectors-1) | (0, 0) != -1 | 10000 in 12 ms. 0.0012 ms. average | 0, 0, 1, 0, 1, 1. |

## The Code

The code for the methods tested follows below.

### Complex Product of two 2D Vectors 1

Complex Product of two 2D Vectors  
- [http://stackoverflow.com/questions/1476497/multiply-two-point-objects](http://stackoverflow.com/questions/1476497/multiply-two-point-objects)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) ComplexProduct0(
            double x0, double y0,
            double x1, double y1)
        {
            return ((x0 * x1) - (y0 * y1), (x0 * y1) + (y0 * x1));
        }
```

