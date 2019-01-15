# Angle of a 2D Vector Tests

Find the angle of a 2D vector.

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

../../InstrumentedLibrary/Mathmatics/Angles/AngleofVector2DTests.cs

The required method signature for this API is as follows:

```CSharp
public static double AngleOfVector2D(double i, double j)
```

## Test Case Index

- [Test Case: (0, 1)](#0,-1)
- [Test Case: (0.25, 0.75)](#0.25,-0.75)

### (0, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [AngleOf(0, 1)](#Angle-of-Vector) | 1.5707963267948966 != 7.8539816339744828 | 10000 in 6 ms. 0.0006 ms. average |  0, 1. |
| [GetAngle(0, 1)](#Vector-Angle-1) | 7.8539816339744828 == 7.8539816339744828 | 10000 in 11 ms. 0.0011 ms. average |  0, 1. |
| [GetAngle0(0, 1)](#Vector-Angle-1) | 3.1415926535897931 != 7.8539816339744828 | 10000 in 6 ms. 0.0006 ms. average |  0, 1. |
| [GetAngleAtan2v2(0, 1)](#Vector-Angle-1) | 0 != 7.8539816339744828 | 10000 in 12 ms. 0.0012 ms. average |  0, 1. |

### (0.25, 0.75)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [AngleOf(0.25, 0.75)](#Angle-of-Vector) | 1.2490457723982544 != 7.5322310795778407 | 10000 in 6 ms. 0.0006 ms. average | 0, 1 |
| [GetAngle(0.25, 0.75)](#Vector-Angle-1) | 7.5322310795778407 == 7.5322310795778407 | 10000 in 8 ms. 0.0008 ms. average | 0, 1 |
| [GetAngle0(0.25, 0.75)](#Vector-Angle-1) | 2.819842099193151 != 7.5322310795778407 | 10000 in 9 ms. 0.0009 ms. average | 0, 1 |
| [GetAngleAtan2v2(0.25, 0.75)](#Vector-Angle-1) | 0.32175055439664219 != 7.5322310795778407 | 10000 in 12 ms. 0.0012 ms. average | 0, 1 |

## The Code

The code for the methods tested follows below.

### Angle of Vector

Get the angle.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AngleOf(double x, double y)
        {
            var dist = Sqrt((x * x) + (y * y));
            if (y >= 0d)
            {
                return Acos(x / dist);
            }
            else
            {
                return Acos(-x / dist) + PI;
            }
        }
```

### Vector Angle 1

Get the angle using Trig.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetAngle(double i, double j)
        {
            return Tau + ((j > 0.0d ? 1.0d : -1.0d) * Acos(i / Sqrt((i * i) + (j * j))) % Tau);
        }
```

### Vector Angle 1

Angle with tangent opp/hyp.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetAngle0(double i, double j)
        {
            return Atan2(i, -j);// * 180 / PI; // Original source method converted radians to degrees.
        }
```

### Vector Angle 1

Returns the Angle of two deltas.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetAngleAtan2v2(double i, double j)
        {
            if ((Abs(i) < DoubleEpsilon) && (Abs(j) < DoubleEpsilon))
            {
                return 0d;
            }

            var value = Asin(i / Sqrt((i * i) + (j * j)));
            if (j < 0d)
            {
                value = PI - value;
            }

            if (value < 0d)
            {
                value = value + (2d * PI);
            }

            return value;
        }
```

