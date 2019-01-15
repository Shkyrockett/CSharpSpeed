# Is Multiplication Safe

Determines whether the multiplication of two values is likely to overflow.

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

../../InstrumentedLibrary/Mathmatics/Queries/IsMultiplicationSafeTests.cs

The required method signature for this API is as follows:

```CSharp
public static bool IsMultiplicationSafe(int a, int b)
```

## Test Case Index

- [Test Case: (2, 1073741823)](#2,-1073741823)

### (2, 1073741823)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [IsMultiplicationSafe0(2, 1073741823)](#Is-Multiplication-Safe) | False == False | 10000 in 8 ms. 0.0008 ms. average | . |
| [IsMultiplicationSafe1(2, 1073741823)](#Is-Multiplication-Safe) | False == False | 10000 in 6 ms. 0.0006 ms. average | . |
| [IsMultiplicationSafe2(2, 1073741823)](#Is-Multiplication-Safe) | False == False | 10000 in 11 ms. 0.0011 ms. average | . |
| [IsMultiplicationSafe3(2, 1073741823)](#Is-Multiplication-Safe) | True != False | 10000 in 9 ms. 0.0009 ms. average | . |

## The Code

The code for the methods tested follows below.

### Is Multiplication Safe

Determines whether the multiplication of two values is likely to overflow.  
- [http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c?rq=1](http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c?rq=1)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsMultiplicationSafe0(int a, int b)
        {
            return Log2Tests.Log2(a) + Log2Tests.Log2(b) <= sizeof(int);
        }
```

### Is Multiplication Safe

Determines whether the multiplication of two values is likely to overflow.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsMultiplicationSafe1(int a, int b)
        {
            return Round(Log(a, 2) + Log(b, 2), MidpointRounding.AwayFromZero) <= sizeof(int);
        }
```

### Is Multiplication Safe

Determines whether the multiplication of two values is likely to overflow.  
- [http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c?rq=1](http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c?rq=1)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsMultiplicationSafe2(int a, int b)
        {
            if (a == 0)
            {
                return true;
            }
            // a * b would overflow
            return b > int.MaxValue / a;
        }
```

### Is Multiplication Safe

Determines whether the multiplication of two values is likely to overflow.  
- [http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c?rq=1](http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c?rq=1)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsMultiplicationSafe3(int a, int b)
        {
            if (a == 0)
            {
                return true;
            }

            if (a > int.MaxValue / b)
            {
                return false /* `a * x` would overflow */;
            }

            if (a < int.MinValue / b)
            {
                return false /* `a * x` would underflow */;
            }
            // there may be need to check for -1 for two's complement machines
            if ((a == -1) && (b == int.MinValue))
            {
                return false /* `a * x` can overflow */;
            }

            if ((b == -1) && (a == int.MinValue))
            {
                return false /* `a * x` (or `a / x`) can overflow */;
            }

            return true;
        }
```

