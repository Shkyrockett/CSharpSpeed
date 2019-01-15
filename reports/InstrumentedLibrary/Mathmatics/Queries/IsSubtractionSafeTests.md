# Is Subtraction Safe

Determines whether the subtraction of two values is likely to overflow.

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

../../InstrumentedLibrary/Mathmatics/Queries/IsSubtractionSafeTests.cs

The required method signature for this API is as follows:

```CSharp
public static bool IsSubtractionSafe(int a, int b)
```

## Test Case Index

- [Test Case: (1073741823, 1073741823)](#1073741823,-1073741823)

### (1073741823, 1073741823)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [IsSubtractionSafe0(1073741823, 1073741823)](#Is-Subtraction-Safe) | False == False | 10000 in 7 ms. 0.0007 ms. average | . |

## The Code

The code for the methods tested follows below.

### Is Subtraction Safe

Determines whether the subtraction of two values is likely to overflow.  
- [http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c?rq=1](http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c?rq=1)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSubtractionSafe0(int a, int b)
        {
            if (a == 0 || b == 0 || a == -0 || b == -0)
            {
                return true;
            }

            if (b < 0)
            {
                return a > int.MaxValue + b;
            }

            if (b > 0)
            {
                return a < int.MinValue + b;
            }

            return true;
        }
```

