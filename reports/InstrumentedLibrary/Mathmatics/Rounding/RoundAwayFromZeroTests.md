# Rounding Tests

Rounding.

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

../../InstrumentedLibrary/Mathmatics/Rounding/RoundAwayFromZeroTests.cs

The required method signature for this API is as follows:

```CSharp
public static double Round(double value)
```

## Test Case Index

- [Test Case: (0.5)](#0.5)

### (0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Round0(0.5)](#Rounding-Tests) | 1 == 1 | 10000 in 9 ms. 0.0009 ms. average | . |

## The Code

The code for the methods tested follows below.

### Rounding Tests

Rounding.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Round0(double value)
        {
            return value < 0 ? (int)(value - 0.5) : (int)(value + 0.5);
        }
```

