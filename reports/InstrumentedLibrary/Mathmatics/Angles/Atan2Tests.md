# Atan2 Tests

Returns the Atan2 of a vector.

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

../../InstrumentedLibrary/Mathmatics/Angles/Atan2Tests.cs

The required method signature for this API is as follows:

```CSharp
public static double Atan2(double y, double x)
```

## Test Case Index

- [Test Case: (1, 0)](#1,-0)
- [Test Case: (0.25, 0.75)](#0.25,-0.75)

### (1, 0)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Atan2_0(1, 0)](#System.Math.Atan2) | 1.5707963267948966 == 1.5707963267948966 | 100000 in 64 ms. 0.00064 ms. average |  0, 1. |
| [Atan2_1(1, 0)](#Atan2) | 1.5707963267948966 == 1.5707963267948966 | 100000 in 128 ms. 0.00128 ms. average |  0, 1. |

### (0.25, 0.75)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Atan2_0(0.25, 0.75)](#System.Math.Atan2) | 0.32175055439664219 == 0.32175055439664219 | 100000 in 138 ms. 0.00138 ms. average | 0, 1 |
| [Atan2_1(0.25, 0.75)](#Atan2) | 0.31938649260687879 != 0.32175055439664219 | 100000 in 105 ms. 0.00105 ms. average | 0, 1 |

## The Code

The code for the methods tested follows below.

### System.Math.Atan2

  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Atan2_0(double y, double x)
        {
            return Atan2(y, x);
        }
```

### Atan2

  
- [http://www.java-gaming.org/index.php?topic=14647.0](http://www.java-gaming.org/index.php?topic=14647.0)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Atan2_1(double y, double x)
        {
            double add, mul;

            if (x < 0d)
            {
                if (y < 0d)
                {
                    x = -x;
                    y = -y;

                    mul = 1d;
                }
                else
                {
                    x = -x;
                    mul = -1d;
                }

                add = -PI;
            }
            else
            {
                if (y < 0d)
                {
                    y = -y;
                    mul = -1d;
                }
                else
                {
                    mul = 1d;
                }

                add = 0d;
            }

            var invDiv = 1d / (((x < y) ? y : x) * INV_ATAN2_DIM_MINUS_1);

            var xi = (int)(x * invDiv);
            var yi = (int)(y * invDiv);

            return (atan2[(yi * ATAN2_DIM) + xi] + add) * mul;
        }
```

