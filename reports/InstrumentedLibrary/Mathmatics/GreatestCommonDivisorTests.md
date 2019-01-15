# greatest common divisor Tests

greatest common divisor.

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

../../InstrumentedLibrary/Mathmatics/GreatestCommonDivisorTests.cs

The required method signature for this API is as follows:

```CSharp
public static long GreatestCommonDivisor(long a, long b)
```

## Test Case Index

- [Test Case: (6, 9)](#6,-9)

### (6, 9)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [GCD(6, 9)](#greatest-common-divisor-Tests) | 3 != True | 10000 in 9 ms. 0.0009 ms. average |  |

## The Code

The code for the methods tested follows below.

### greatest common divisor Tests

greatest common divisor.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long GCD(long a, long b)
        {
            long remainder;

            // Pull out remainders.
            for (; ; )
            {
                remainder = a % b;
                if (remainder == 0)
                {
                    break;
                }

                a = b;
                b = remainder;
            }

            return b;
        }
```

