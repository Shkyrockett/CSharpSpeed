# Is Exponentiation Safe

Determines whether the Exponentiation of two values is likely to overflow.

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

../../InstrumentedLibrary/Mathmatics/Queries/IsExponentiationSafeTests.cs

The required method signature for this API is as follows:

```CSharp
public static bool IsExponentiationSafe(int a, int b)
```

## Test Case Index

- [Test Case: (2, 39)](#2,-39)

### (2, 39)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [IsExponentiationSafe0(2, 39)](#Is-Exponentiation-Safe) | False == False | 10000 in 11 ms. 0.0011 ms. average | . |

## The Code

The code for the methods tested follows below.

### Is Exponentiation Safe

Determines whether the Exponentiation of two values is likely to overflow.  
- [http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c](http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsExponentiationSafe0(int a, int b)
        {
            return Log2Tests.Log2(a) * b <= sizeof(int);
        }
```

