# Angle Between Angles

Determine whether an angle lies within the sweep angle starting from an angle.

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

../../InstrumentedLibrary/Mathmatics/Angles/AngleWithinAngleTests.cs

The required method signature for this API is as follows:

```CSharp
public static bool Within(double angle, double startAngle, double sweepAngle)
```

## Test Case Index

- [Test Case: (1.5707963267949, 0, 3.14159265358979)](#1.5707963267949,-0,-3.14159265358979)

### (1.5707963267949, 0, 3.14159265358979)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Within0(1.5707963267949, 0, 3.14159265358979)](#Within-1) | True == True | 10000 in 12 ms. 0.0012 ms. average | Angle lies inside of sweep angle. |

## The Code

The code for the methods tested follows below.

### Within 1

Check whether an angle lies within the sweep angle.  
- [http://www.xarg.org/2010/06/is-an-angle-between-two-other-angles/](http://www.xarg.org/2010/06/is-an-angle-between-two-other-angles/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Within0(double angle, double startAngle, double sweepAngle)
        {
            // If the sweep angle is greater than 360 degrees it is overlapping, so any angle would intersect the sweep angle.
            if (sweepAngle > Tau)
            {
                return true;
            }

            // Wrap the angles to values between 2PI and -2PI.
            var s = WrapAngleTests.WrapAngle(startAngle);
            var e = WrapAngleTests.WrapAngle(s + sweepAngle);
            var a = WrapAngleTests.WrapAngle(angle);

            // return whether the angle is contained within the sweep angle.
            // The calculations are opposite when the sweep angle is negative.
            return (sweepAngle >= 0d) ?
                (s < e) ? a >= s && a <= e : a >= s || a <= e :
                (s > e) ? a <= s && a >= e : a <= s || a >= e;
        }
```

