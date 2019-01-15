# Is Number Valid

Determines whether a number is a valid number. Not NAN or infinite.

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

../../InstrumentedLibrary/Mathmatics/Queries/IsNumberValidTests.cs

The required method signature for this API is as follows:

```CSharp
public static bool IsNumberValid(double value)
```

## Test Case Index

- [Test Case: (NaN)](#NaN)
- [Test Case: (1)](#1)
- [Test Case: (-∞)](#-∞)
- [Test Case: (1.79769313486232E+308)](#1.79769313486232E+308)
- [Test Case: (∞)](#∞)
- [Test Case: (-1.79769313486232E+308)](#-1.79769313486232E+308)

### (NaN)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [IsNumber(NaN)](#Is-Number-Valid) | False == False | 10000 in 5 ms. 0.0005 ms. average | . |
| [IsValid(NaN)](#Is-Number-Valid) | False == False | 10000 in 9 ms. 0.0009 ms. average | . |
| [IsValid1(NaN)](#Is-Number-Valid) | False == False | 10000 in 6 ms. 0.0006 ms. average | . |

### (1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [IsNumber(1)](#Is-Number-Valid) | True == True | 10000 in 5 ms. 0.0005 ms. average | . |
| [IsValid(1)](#Is-Number-Valid) | True == True | 10000 in 7 ms. 0.0007 ms. average | . |
| [IsValid1(1)](#Is-Number-Valid) | True == True | 10000 in 6 ms. 0.0006 ms. average | . |

### (-∞)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [IsNumber(-∞)](#Is-Number-Valid) | False == False | 10000 in 5 ms. 0.0005 ms. average | . |
| [IsValid(-∞)](#Is-Number-Valid) | False == False | 10000 in 7 ms. 0.0007 ms. average | . |
| [IsValid1(-∞)](#Is-Number-Valid) | False == False | 10000 in 5 ms. 0.0005 ms. average | . |

### (1.79769313486232E+308)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [IsNumber(1.79769313486232E+308)](#Is-Number-Valid) | True == True | 10000 in 5 ms. 0.0005 ms. average | . |
| [IsValid(1.79769313486232E+308)](#Is-Number-Valid) | True == True | 10000 in 5 ms. 0.0005 ms. average | . |
| [IsValid1(1.79769313486232E+308)](#Is-Number-Valid) | True == True | 10000 in 9 ms. 0.0009 ms. average | . |

### (∞)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [IsNumber(∞)](#Is-Number-Valid) | False == False | 10000 in 7 ms. 0.0007 ms. average | . |
| [IsValid(∞)](#Is-Number-Valid) | False == False | 10000 in 4 ms. 0.0004 ms. average | . |
| [IsValid1(∞)](#Is-Number-Valid) | False == False | 10000 in 6 ms. 0.0006 ms. average | . |

### (-1.79769313486232E+308)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [IsNumber(-1.79769313486232E+308)](#Is-Number-Valid) | True == True | 10000 in 7 ms. 0.0007 ms. average | . |
| [IsValid(-1.79769313486232E+308)](#Is-Number-Valid) | True == True | 10000 in 11 ms. 0.0011 ms. average | . |
| [IsValid1(-1.79769313486232E+308)](#Is-Number-Valid) | True == True | 10000 in 9 ms. 0.0009 ms. average | . |

## The Code

The code for the methods tested follows below.

### Is Number Valid

Determines whether a number is a valid number. Not NAN or infinite.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNumber(double number)
        {
            return !(double.IsNaN(number) || double.IsInfinity(number));
        }
```

### Is Number Valid

Determines whether a number is a valid number. Not NAN or infinite.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsValid(double value)
        {
            return !double.IsNaN(value) && !double.IsInfinity(value);
        }
```

### Is Number Valid

Determines whether a number is a valid number. Not NAN or infinite.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsValid1(double x)
        {
            if (double.IsNaN(x))
            {
                // NaN.
                return false;
            }

            return !double.IsInfinity(x);
        }
```

