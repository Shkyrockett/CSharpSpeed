# Is Power of Two

Determines whether a number is a power of 2.

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

../../InstrumentedLibrary/Mathmatics/Queries/IsPowerOfTwoTests.cs

The required method signature for this API is as follows:

```CSharp
public static bool IsPowerOfTwo(int value)
```

## Test Case Index

- [Test Case: (4)](#4)

### (4)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [IsPowerOfTwo0(4)](#Is-Power-of-Two) | True == True | 10000 in 4 ms. 0.0004 ms. average | . |

## The Code

The code for the methods tested follows below.

### Is Power of Two

Determines whether a number is a power of 2.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPowerOfTwo0(int value)
        {
            return (value > 0) && ((value & (value - 1)) == 0);
        }
```

