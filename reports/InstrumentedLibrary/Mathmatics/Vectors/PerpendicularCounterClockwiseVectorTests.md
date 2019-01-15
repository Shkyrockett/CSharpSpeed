# Counter Clockwise Perpendicular Vector

Find the counter clockwise perpendicular of a Vector.

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

../../InstrumentedLibrary/Mathmatics/Vectors/PerpendicularCounterClockwiseVectorTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double I, double J) PerpendicularCounterClockwiseVector(double i, double j)
```

## Test Case Index

- [Test Case: (0, 0.5)](#0,-0.5)

### (0, 0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [PerpendicularCounterClockwiseVector0(0, 0.5)](#Counter-Clockwise-Perpendicular-Vector) | (0.5, -0) != 6.2831853071795862 | 10000 in 11 ms. 0.0011 ms. average |  |

## The Code

The code for the methods tested follows below.

### Counter Clockwise Perpendicular Vector

Find the counter clockwise perpendicular of a Vector.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double I, double J) PerpendicularCounterClockwiseVector0(double i, double j)
        {
            return (j, -i);
        }
```

