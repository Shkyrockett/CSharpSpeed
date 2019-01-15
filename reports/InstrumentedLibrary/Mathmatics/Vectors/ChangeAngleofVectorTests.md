# Change Angle of Vector Tests

Change the angle of a vector.

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

../../InstrumentedLibrary/Mathmatics/Vectors/ChangeAngleofVectorTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double I, double J) ChangeAngleOfVector(double i, double j, double angle)
```

## Test Case Index

- [Test Case: (0, 1, 1)](#0,-1,-1)

### (0, 1, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [SetAngle(0, 1, 1)](#Change-Angle-of-Vector) | (0.8414709848078965, -0.54030230586813977) != 6.2831853071795862 | 10000 in 17 ms. 0.0017 ms. average | . |

## The Code

The code for the methods tested follows below.

### Change Angle of Vector

Change the angle of a vector.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double I, double J) SetAngle(double i, double j, double angle)
        {
            //double rads = angle; // * (PI / 180); // Original code used degrees rather than radians.
            var dist = Sqrt((i * i) + (j * j));
            return (
                Sin(angle) * dist,
                -(Cos(angle) * dist));
        }
```

