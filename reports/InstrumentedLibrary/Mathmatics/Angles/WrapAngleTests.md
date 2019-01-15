# Wrap Angle Tests

Reduces a given angle to a value between 2π and -2π.

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

../../InstrumentedLibrary/Mathmatics/Angles/WrapAngleTests.cs

The required method signature for this API is as follows:

```CSharp
public static double WrapAngle(this double angle)
```

## Test Case Index

- [Test Case: (8.37758040957278)](#8.37758040957278)
- [Test Case: (0.785398163397448)](#0.785398163397448)

### (8.37758040957278)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [WrapAngle0(8.37758040957278)](#Wrap-Angle-2) | -4.1887902047863914 == -4.1887902047863914 | 100000 in 96 ms. 0.00096 ms. average | An angle that wraps more than 360 degrees. |
| [WrapAngle00(8.37758040957278)](#Wrap-Angle-1) | -4.1887902047863914 == -4.1887902047863914 | 100000 in 61 ms. 0.00061 ms. average | An angle that wraps more than 360 degrees. |
| [WrapAngle1(8.37758040957278)](#Wrap-Angle-3) | -4.1887902047863914 == -4.1887902047863914 | 100000 in 58 ms. 0.00058 ms. average | An angle that wraps more than 360 degrees. |
| [WrapAngle2(8.37758040957278)](#Wrap-Angle-4) | 2.0943951023931948 != -4.1887902047863914 | 100000 in 71 ms. 0.00071 ms. average | An angle that wraps more than 360 degrees. |
| [WrapAngle3(8.37758040957278)](#Wrap-Angle-5) | -4.1887902047863914 == -4.1887902047863914 | 100000 in 60 ms. 0.0006 ms. average | An angle that wraps more than 360 degrees. |

### (0.785398163397448)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [WrapAngle0(0.785398163397448)](#Wrap-Angle-2) | -5.497787143782138 == -5.497787143782138 | 100000 in 90 ms. 0.0009 ms. average | An angle that wraps less than 360 degrees. |
| [WrapAngle00(0.785398163397448)](#Wrap-Angle-1) | -5.497787143782138 == -5.497787143782138 | 100000 in 70 ms. 0.0007 ms. average | An angle that wraps less than 360 degrees. |
| [WrapAngle1(0.785398163397448)](#Wrap-Angle-3) | -5.497787143782138 == -5.497787143782138 | 100000 in 58 ms. 0.00058 ms. average | An angle that wraps less than 360 degrees. |
| [WrapAngle2(0.785398163397448)](#Wrap-Angle-4) | 0.78539816339744828 != -5.497787143782138 | 100000 in 62 ms. 0.00062 ms. average | An angle that wraps less than 360 degrees. |
| [WrapAngle3(0.785398163397448)](#Wrap-Angle-5) | -5.497787143782138 == -5.497787143782138 | 100000 in 83 ms. 0.00083 ms. average | An angle that wraps less than 360 degrees. |

## The Code

The code for the methods tested follows below.

### Wrap Angle 2

Reduces a given angle to a value between 2π and -2π.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double WrapAngle0(double angle)
        {
            // The IEEERemainder method works better than the % modulus operator in this case, even if it is slower.
            var value = IEEERemainder(angle, Tau);
            return (value <= -PI) ? value + Tau : value - Tau;
        }
```

### Wrap Angle 1

Reduces a given angle to a value between 2π and -2π.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double WrapAngle00(double angle)
        {
            if (double.IsNaN(angle))
            {
                return angle;
            }

            // The IEEERemainder method works better than the % modulus operator in this case, even if it is slower.
            //double value = IEEERemainder(angle, Tau);
            // The active ingredient of the IEEERemainder method is extracted here for performance reasons.
            var value = angle - (Tau * Round(angle * InverseTau));
            return (value <= -PI) ? value + Tau : value - Tau;
        }
```

### Wrap Angle 3

Reduces a given angle to a value between 2π and -2π.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double WrapAngle1(double angle)
        {
            // The active ingredient of the IEEERemainder method.
            var value = angle - (Tau * Round(angle * InverseTau));
            return (value <= -PI) ? value + Tau : value - Tau;
        }
```

### Wrap Angle 4

Reduces a given angle to a value between 2π and -2π.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double WrapAngle2(double angle)
        {
            var test = IEEERemainder(angle, Tau);
            if (test <= -PI)
            {
                test += Tau;
            }
            else if (test > PI)
            {
                test -= Tau;
            }

            return test;
        }
```

### Wrap Angle 5

Reduces a given angle to a value between 2π and -2π.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double WrapAngle3(double angle)
        {
            var test = angle % Tau;
            return (test <= -PI) ? test + Tau : test - Tau;
        }
```

