# 2D Absolute Angle Tests

Find the absolute angle of two points.

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

../../InstrumentedLibrary/Mathmatics/Angles/AbsoluteAngle2DTests.cs

The required method signature for this API is as follows:

```CSharp
public static double AbsoluteAngle(double aX, double aY, double bX, double bY)
```

## Test Case Index

- [Test Case: (0, 0, 1, 1)](#0,-0,-1,-1)

### (0, 0, 1, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [AbsoluteAngle1(0, 0, 1, 1)](#Absolute-Angle-Idea-1) | 2.3561944901923448 == 2.3561944901923448 | 10000 in 13 ms. 0.0013 ms. average |  0d, 0d, 1d, 1d. |
| [AbsoluteAngle2(0, 0, 1, 1)](#Absolute-Angle-Idea-2) | 2.3561944901923448 == 2.3561944901923448 | 10000 in 9 ms. 0.0009 ms. average |  0d, 0d, 1d, 1d. |

## The Code

The code for the methods tested follows below.

### Absolute Angle Idea 1

This one uses a while loop.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AbsoluteAngle1(double aX, double aY, double bX, double bY)
        {
            // Find the angle of point a and point b.
            var test = -Angle2DTests.Angle2D(aX, aY, bX, bY) % PI;

            // This should only loop once using the modulus of pi.
            while (test < 0d)
            {
                test += PI;
            }

            return test;
        }
```

### Absolute Angle Idea 2

Mostly inlined absolute angle method.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AbsoluteAngle2(double aX, double aY, double bX, double bY)
        {
            // Find the angle of point a and point b.
            var test = -Angle2DTests.Angle2D(aX, aY, bX, bY) % PI;
            return test < 0d ? test += PI : test;
        }
```

