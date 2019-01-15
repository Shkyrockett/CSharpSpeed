# Functional Interpolation Tests

Run interpolation of a function.

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

../../InstrumentedLibrary/Geometry/Interpolation/FunctionalInterpolationTests.cs

The required method signature for this API is as follows:

```CSharp
public static List<(double X, double Y)> Interpolate0to1(Func<double, (double X, double Y)> func, int count)
```

## Test Case Index

- [Test Case: (System.Func`2[System.Double,System.ValueTuple`2[System.Double,System.Double]], 100)](#System.Func`2[System.Double,System.ValueTuple`2[System.Double,System.Double]],-100)

### (System.Func`2[System.Double,System.ValueTuple`2[System.Double,System.Double]], 100)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Interpolate0to1_(System.Func`2[System.Double,System.ValueTuple`2[System.Double,System.Double]], 100)](#The-cubic-bezier-arc-length) | System.Collections.Generic.List`1[System.ValueTuple`2[System.Double,System.Double]] != 6.2831853071795862 | 10000 in 191 ms. 0.0191 ms. average | . |

## The Code

The code for the methods tested follows below.

### The cubic bezier arc length

The cubic bezier arc length.  
- [http://steve.hollasch.net/cgindex/curves/cbezarclen.html](http://steve.hollasch.net/cgindex/curves/cbezarclen.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<(double X, double Y)> Interpolate0to1_(Func<double, (double X, double Y)> func, int count)
        {
            return new List<(double X, double Y)>(from i in Enumerable.Range(0, count) select func(1d / count * i));
        }
```

