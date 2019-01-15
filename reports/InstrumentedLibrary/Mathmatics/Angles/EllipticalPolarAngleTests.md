# Elliptical Polar Angle

Find the elliptical t that matches the coordinates of a circular angle.

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

../../InstrumentedLibrary/Mathmatics/Angles/EllipticalPolarAngleTests.cs

The required method signature for this API is as follows:

```CSharp
public static double EllipticalPolarAngle(double angle, double rx, double ry)
```

## Test Case Index

- [Test Case: (0.523598775598299, 3, 2)](#0.523598775598299,-3,-2)

### (0.523598775598299, 3, 2)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [EllipticalPolarAngle0(0.523598775598299, 3, 2)](#Elliptical-Polar-Angle-1) | 0.71372437894476559 == 0.71372437894476559 | 10000 in 7 ms. 0.0007 ms. average | Find the angle on a 3:2 ellipse a 30 polar degrees. |
| [EllipticalPolarAngle1(0.523598775598299, 3, 2)](#Elliptical-Polar-Angle-Vector) | 0.71372437894476559 == 0.71372437894476559 | 10000 in 10 ms. 0.001 ms. average | Find the angle on a 3:2 ellipse a 30 polar degrees. |

## The Code

The code for the methods tested follows below.

### Elliptical Polar Angle 1

flup's method of finding the polar angle from elliptical angle.  
- [https://stackoverflow.com/a/17762156/7004229](https://stackoverflow.com/a/17762156/7004229)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipticalPolarAngle0(double angle, double rx, double ry)
        {
            // Wrap the angle between -2PI and 2PI.
            var theta = angle % Tau;

            // Find the elliptical t that matches the circular angle.
            if (Abs(theta) == HalfPi || Abs(theta) == Pau)
            {
                return angle;
            }

            if (theta > HalfPi && theta < Pau)
            {
                return Atan(rx * Tan(theta) / ry) + PI;
            }

            if (theta < -HalfPi && theta > -Pau)
            {
                return Atan(rx * Tan(theta) / ry) - PI;
            }

            return Atan(rx * Tan(theta) / ry);
        }
```

### Elliptical Polar Angle Vector

Find the angle of the Elliptical Polar Angle Vector.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipticalPolarAngle1(double angle, double rx, double ry)
        {
            var (cosT, sinT) = EllipticalPolarVectorTests.EllipticalPolarVector(Cos(angle), Sin(angle), rx, ry);
            return Atan2(sinT, cosT);
        }
```

