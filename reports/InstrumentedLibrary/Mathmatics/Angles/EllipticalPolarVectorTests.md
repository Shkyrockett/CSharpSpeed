# Elliptical Polar Angle Vector

Find the Cos and Sin of the Elliptical Polar Angle Vector.

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

../../InstrumentedLibrary/Mathmatics/Angles/EllipticalPolarVectorTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double cosT, double sinT) EllipticalPolarVector(double cosA, double sinA, double rx, double ry)
```

## Test Case Index

- [Test Case: (0.707106781186548, 0.707106781186548, 2, 1)](#0.707106781186548,-0.707106781186548,-2,-1)

### (0.707106781186548, 0.707106781186548, 2, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [EllipticalPolarAngleVector0(0.707106781186548, 0.707106781186548, 2, 1)](#Elliptical-Polar-Angle-Vector) | (-0.44721359549995793, -0.89442719099991586) != True | 10000 in 12 ms. 0.0012 ms. average |  |
| [EllipticalPolarVector0(0.707106781186548, 0.707106781186548, 2, 1)](#Elliptical-Polar-Angle-Vector) | (0.44721359549995793, 0.89442719099991586) != True | 10000 in 19 ms. 0.0019 ms. average |  |

## The Code

The code for the methods tested follows below.

### Elliptical Polar Angle Vector

Find the Cos and Sin of the Elliptical Polar Angle Vector.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double cosT, double sinT) EllipticalPolarAngleVector0(double cosA, double sinA, double rx, double ry)
        {
            // Get angle.
            var angle = Atan2(sinA, cosA);

            // Wrap the angle between -2PI and 2PI.
            var theta = angle % Tau;

            // Find the elliptical t that matches the circular angle.
            if (cosA == 1d)
            {
                return (cosA, sinA);
            }
            if (cosA < 0d)
            {
                var t = Atan(rx * Tan(theta) / ry) + PI;
                return (Cos(t), Sin(t));
            }
            if (cosA > 0d)
            {
                var t = Atan(rx * Tan(theta) / ry) - PI;
                return (Cos(t), Sin(t));
            }
            {
                var t = Atan(rx * Tan(theta) / ry);
                return (Cos(t), Sin(t));
            }
        }
```

### Elliptical Polar Angle Vector

Find the Cos and Sin of the Elliptical Polar Angle Vector.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double cosT, double sinT) EllipticalPolarVector0(double cosA, double sinA, double rx, double ry)
        {
            // Find the elliptical t that matches the circular angle.
            if (cosA > -1 && cosA < 0 || cosA > 0 && cosA < 1)
            {
                var d = Sign(cosA);
                return (d / Sqrt(1d + rx * rx * sinA * sinA / (ry * ry * cosA * cosA)),
                        d * (rx * sinA / (ry * cosA * Sqrt(1 + rx * rx * sinA * sinA / (ry * ry * cosA * cosA)))));
            }

            return (cosA, sinA);
        }
```

