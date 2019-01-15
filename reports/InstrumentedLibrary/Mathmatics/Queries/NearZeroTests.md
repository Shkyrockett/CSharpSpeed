# Is Value Near Zero Query

Determines whether a value is near zero.

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

../../InstrumentedLibrary/Mathmatics/Queries/NearZeroTests.cs

The required method signature for this API is as follows:

```CSharp
public static bool NearZero(double value, double epsilon = NearZeroEpsilon)
```

## Test Case Index

- [Test Case: (1E-09, 1E-20)](#1E-09,-1E-20)

### (1E-09, 1E-20)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [NearZero0(1E-09, 1E-20)](#Is-Value-Near-Zero-Query) | False == False | 10000 in 6 ms. 0.0006 ms. average | . |
| [NearZero1(1E-09, 1E-20)](#Is-Value-Near-Zero-Query) | False == False | 10000 in 6 ms. 0.0006 ms. average | . |

## The Code

The code for the methods tested follows below.

### Is Value Near Zero Query

Determines whether a value is near zero.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NearZero0(double value, double epsilon = NearZeroEpsilon)
        {
            return (value > -epsilon) && (value < -epsilon);
        }
```

### Is Value Near Zero Query

Determines whether a value is near zero.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NearZero1(double value, double epsilon = NearZeroEpsilon)
        {
            return Abs(value) <= epsilon;
        }
```

