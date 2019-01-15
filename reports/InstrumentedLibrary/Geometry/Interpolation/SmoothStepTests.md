# Smooth Step Between Two Values

Smooth step between two values.

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

../../InstrumentedLibrary/Geometry/Interpolation/SmoothStepTests.cs

The required method signature for this API is as follows:

```CSharp
public static double SmoothStep(double value1, double value2, double amount)
```

## Test Case Index

- [Test Case: (0, 1, 0.5)](#0,-1,-0.5)

### (0, 1, 0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [SmoothStep_(0, 1, 0.5)](#Smooth-Step-Between-Two-Values) | 0.5 != 0.49999999999999994 | 10000 in 9 ms. 0.0009 ms. average |  |

## The Code

The code for the methods tested follows below.

### Smooth Step Between Two Values

Smooth step between two values.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SmoothStep_(double value1, double value2, double amount)
        {
            // It is expected that 0 < amount < 1
            // If amount < 0, return value1
            // If amount > 1, return value2
            var result = ClampTests.Clamp(amount, 0d, 1d);
            result = HermiteInterpolate1DTests.Hermite(value1, 0d, value2, 0d, result, 1d, 0d);

            return result;
        }
```

