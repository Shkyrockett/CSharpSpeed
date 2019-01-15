# Sign of a Number

Find the Sign of a number.

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

../../InstrumentedLibrary/Mathmatics/Queries/SignOfNumberTests.cs

The required method signature for this API is as follows:

```CSharp
public static Signs Sign(double value)
```

## Test Case Index

- [Test Case: (1E-09)](#1E-09)
- [Test Case: (-1)](#-1)

### (1E-09)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [SignIf(1E-09)](#Sign-of-Number-Using-If) | Positive == Positive | 10000 in 5 ms. 0.0005 ms. average | . |
| [SignSwitch(1E-09)](#Sign-of-Number-Using-Switch) | Positive == Positive | 10000 in 5 ms. 0.0005 ms. average | . |
| [SignSystem(1E-09)](#Sign-of-Number-Using-System.Math.Sign) | Positive == Positive | 10000 in 5 ms. 0.0005 ms. average | . |
| [SignTernary(1E-09)](#Sign-of-Number-Using-Ternary) | Positive == Positive | 10000 in 6 ms. 0.0006 ms. average | . |

### (-1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [SignIf(-1)](#Sign-of-Number-Using-If) | Negative == Negative | 10000 in 5 ms. 0.0005 ms. average | . |
| [SignSwitch(-1)](#Sign-of-Number-Using-Switch) | Negative == Negative | 10000 in 9 ms. 0.0009 ms. average | . |
| [SignSystem(-1)](#Sign-of-Number-Using-System.Math.Sign) | Negative == Negative | 10000 in 9 ms. 0.0009 ms. average | . |
| [SignTernary(-1)](#Sign-of-Number-Using-Ternary) | Negative == Negative | 10000 in 12 ms. 0.0012 ms. average | . |

## The Code

The code for the methods tested follows below.

### Sign of Number Using If

Find the Sign of a number using a If statement.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Signs SignIf(double value)
        {
            if (value < 0)
            {
                return Signs.Negative;
            }
            else if (value > 0)
            {
                return Signs.Positive;
            }
            else if (value == 0)
            {
                return Signs.Zero;
            }

            throw new ArithmeticException("NAN is not a valid value for Sign.");
        }
```

### Sign of Number Using Switch

Find the Sign of a number using a Switch statement.  
- [https://referencesource.microsoft.com/#mscorlib/system/math.cs,8cbccaf4a250fb70](https://referencesource.microsoft.com/#mscorlib/system/math.cs,8cbccaf4a250fb70)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Signs SignSwitch(double value)
        {
            switch (value)
            {
                case double s when s < 0:
                    return Signs.Negative;
                case double s when s > 0:
                    return Signs.Positive;
                case double s when s == 0:
                    return Signs.Zero;
                default:
                    throw new ArithmeticException("NAN is not a valid value for Sign.");
            }
        }
```

### Sign of Number Using System.Math.Sign

Find the Sign of a number using System.Math.Sign.  
- [https://referencesource.microsoft.com/#mscorlib/system/math.cs,8cbccaf4a250fb70](https://referencesource.microsoft.com/#mscorlib/system/math.cs,8cbccaf4a250fb70)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Signs SignSystem(double value)
        {
            return (Signs)Math.Sign(value);
        }
```

### Sign of Number Using Ternary

Find the Sign of a number using a Ternary tree.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Signs SignTernary(double value)
        {
            return (value < 0d) ? Signs.Negative : (value > 0) ? Signs.Positive : (value == 0) ? Signs.Zero : throw new ArithmeticException("NAN is not a valid value for Sign.");
        }
```

