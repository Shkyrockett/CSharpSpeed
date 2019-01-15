# Slope of 2D Vector Tests

Estimations on the length of the Perimeter of an ellipse.

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

../../InstrumentedLibrary/Mathmatics/Vectors/SlopeVector2DTests.cs

The required method signature for this API is as follows:

```CSharp
public static double Slope(double i, double j)
```

## Test Case Index

- [Test Case: (0, 0.5)](#0,-0.5)

### (0, 0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Slope0(0, 0.5)](#Slope-of-a-Vector) | 9.2233720368547758E+18 != 6.2831853071795862 | 10000 in 7 ms. 0.0007 ms. average | Circle test case. |

## The Code

The code for the methods tested follows below.

### Slope of a Vector

Find the slope a Vector.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Slope0(double i, double j)
        {
            return Abs(i) < DoubleEpsilon ? SlopeMax : (j / i);
        }
```

