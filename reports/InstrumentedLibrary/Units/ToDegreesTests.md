# Convert an angle in Radians to Degrees

Convert an angle in Radians to Degrees.

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

../../InstrumentedLibrary/Units/ToDegreesTests.cs

The required method signature for this API is as follows:

```CSharp
public static double ToDegrees(this double radiens)
```

## Test Case Index

- [Test Case: (3.14159265358979)](#3.14159265358979)

### (3.14159265358979)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [ToDegrees0(3.14159265358979)](#Convert-an-angle-in-Radians-to-Degrees) | 180 == 180 | 10000 in 4 ms. 0.0004 ms. average | 180 degrees |

## The Code

The code for the methods tested follows below.

### Convert an angle in Radians to Degrees

Convert an angle in Radians to Degrees.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDegrees0(double radiens)
        {
            return radiens * Degree;
        }
```

