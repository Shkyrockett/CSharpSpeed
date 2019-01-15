# Clamp Value

Clamp a value between a max and min.

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

../../InstrumentedLibrary/Mathmatics/ClampTests.cs

The required method signature for this API is as follows:

```CSharp
public static double Clamp(double value, double min, double max)
```

## Test Case Index

- [Test Case: (2, 0, 1)](#2,-0,-1)

### (2, 0, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Clamp0(2, 0, 1)](#Clamp-1) | 1 == 1 | 10000 in 15 ms. 0.0015 ms. average | . |
| [Clamp1(2, 0, 1)](#Clamp-1) | 1 == 1 | 10000 in 13 ms. 0.0013 ms. average | . |

## The Code

The code for the methods tested follows below.

### Clamp 1

Clamp a value between a max and min.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Clamp0(double value, double min, double max)
        {
            return value > max ? max : value < min ? min : value;
        }
```

### Clamp 1

Clamp a value between a max and min.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Clamp1(double value, double min, double max)
        {
            return Max(min, Min(value, max));
        }
```

