# ASin Tests

Returns the ASin of a value.

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

../../InstrumentedLibrary/Mathmatics/Angles/ASinTests.cs

The required method signature for this API is as follows:

```CSharp
public static double ASin(double d)
```

## Test Case Index

- [Test Case: (1)](#1)
- [Test Case: (0.25)](#0.25)

### (1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [ASin0(1)](#System.Math.Asin) | 1.5707963267948966 == 1.5707963267948966 | 100000 in 84 ms. 0.00084 ms. average | . |
| [ASin1(1)](#ASin) | 1.5707963267948966 == 1.5707963267948966 | 100000 in 58 ms. 0.00058 ms. average | . |

### (0.25)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [ASin0(0.25)](#System.Math.Asin) | 0.25268025514207865 == 0.25268025514207865 | 100000 in 65 ms. 0.00065 ms. average | . |
| [ASin1(0.25)](#ASin) | 0.25268025514207865 == 0.25268025514207865 | 100000 in 87 ms. 0.00087 ms. average | . |

## The Code

The code for the methods tested follows below.

### System.Math.Asin

  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ASin0(double d)
        {
            return Asin(d);
        }
```

### ASin

  
- [https://stackoverflow.com/q/40917676](https://stackoverflow.com/q/40917676)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ASin1(double d)
        {
            return Atan2(d, Sqrt(1d - d * d));
        }
```

