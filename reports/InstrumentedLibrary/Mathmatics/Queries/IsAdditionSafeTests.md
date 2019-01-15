# Is Addition Safe

Determines whether the addition of two values is likely to overflow.

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

../../InstrumentedLibrary/Mathmatics/Queries/IsAdditionSafeTests.cs

The required method signature for this API is as follows:

```CSharp
public static bool IsAdditionSafe(int a, int b)
```

## Test Case Index

- [Test Case: (1073741823, 1073741823)](#1073741823,-1073741823)

### (1073741823, 1073741823)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [IsAdditionSafe0(1073741823, 1073741823)](#Is-Addition-Safe) | False != True | 10000 in 6 ms. 0.0006 ms. average | . |
| [IsAdditionSafe2(1073741823, 1073741823)](#Is-Addition-Safe) | True == True | 10000 in 8 ms. 0.0008 ms. average | . |
| [IsAdditionSafe3(1073741823, 1073741823)](#Is-Addition-Safe) | False != True | 10000 in 6 ms. 0.0006 ms. average | . |
| [IsAdditionSafe4(1073741823, 1073741823)](#Is-Addition-Safe) | True == True | 10000 in 10 ms. 0.001 ms. average | . |
| [IsAdditionSafe5(1073741823, 1073741823)](#Is-Addition-Safe) | True == True | 10000 in 9 ms. 0.0009 ms. average | . |
| [IsAdditionSafe6(1073741823, 1073741823)](#Is-Addition-Safe) | False != True | 10000 in 8 ms. 0.0008 ms. average | . |

## The Code

The code for the methods tested follows below.

### Is Addition Safe

Determines whether the addition of two values is likely to overflow.  
- [http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c](http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAdditionSafe0(int a, int b)
        {
            return Log2Tests.Log2(a) < sizeof(int) && Log2Tests.Log2(b) < sizeof(int);
        }
```

### Is Addition Safe

Determines whether the addition of two values is likely to overflow.  
- [http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c](http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAdditionSafe2(int a, int b)
        {
            var L_Mask = int.MaxValue;
            L_Mask >>= 1;
            L_Mask = ~L_Mask;

            a &= L_Mask;
            b &= L_Mask;

            return a == 0 || b == 0 || a == -0 || b == -0;
        }
```

### Is Addition Safe

Determines whether the addition of two values is likely to overflow.  
- [http://stackoverflow.com/questions/15920639/how-to-check-if-ab-exceed-long-long-both-a-and-b-is-long-long?noredirect=1](http://stackoverflow.com/questions/15920639/how-to-check-if-ab-exceed-long-long-both-a-and-b-is-long-long?noredirect=1)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAdditionSafe3(int a, int b)
        {
            if (a > 0)
            {
                return b > (int.MaxValue - a);
            }

            if (a < 0)
            {
                return b > (int.MinValue + a);
            }

            return true;
        }
```

### Is Addition Safe

Determines whether the addition of two values is likely to overflow.  
- [http://stackoverflow.com/questions/15920639/how-to-check-if-ab-exceed-long-long-both-a-and-b-is-long-long?noredirect=1](http://stackoverflow.com/questions/15920639/how-to-check-if-ab-exceed-long-long-both-a-and-b-is-long-long?noredirect=1)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAdditionSafe4(int a, int b)
        {
            return a < 0 != b < 0 || (a < 0
                ? b > int.MinValue - a
                : b < int.MaxValue - a);
        }
```

### Is Addition Safe

Determines whether the addition of two values is likely to overflow.  
- [http://stackoverflow.com/questions/15920639/how-to-check-if-ab-exceed-long-long-both-a-and-b-is-long-long?noredirect=1](http://stackoverflow.com/questions/15920639/how-to-check-if-ab-exceed-long-long-both-a-and-b-is-long-long?noredirect=1)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAdditionSafe5(int a, int b)
        {
            if (a == 0 || b == 0 || a == -0 || b == -0)
            {
                return true;
            }

            if (a < 0)
            {
                return b >= (int.MinValue - a);
            }

            if (a > 0)
            {
                return b <= (int.MaxValue - a);
            }

            return true;
        }
```

### Is Addition Safe

Determines whether the addition of two values is likely to overflow.  
- [http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c?rq=1](http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c?rq=1)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAdditionSafe6(int a, int b)
        {
            if (a == 0 || b == 0 || a == -0 || b == -0)
            {
                return true;
            }

            if (b > 0)
            {
                return a > int.MaxValue - b;
            }

            if (b < 0)
            {
                return a < int.MinValue - b;
            }

            return true;
        }
```

