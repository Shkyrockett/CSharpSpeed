# Circle to Ellipse Tests

Convert a Circle to an Ellipse.

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

../../InstrumentedLibrary/Geometry/Conversions/CircleToEllipseTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double X, double Y, double A, double B, double angle) CircleToEllipse(double x, double y, double r)
```

## Test Case Index

- [Test Case: (0, 0, 1)](#0,-0,-1)

### (0, 0, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [CircleToEllipse0(0, 0, 1)](#Circle-to-Ellipse) | (0, 0, 1, 1, 0) != (0, 1, 1.33333333333333, 2.33333333333333, 4.66666666666667, 5.66666666666667, 6, 7) | 10000 in 16 ms. 0.0016 ms. average |  |

## The Code

The code for the methods tested follows below.

### Circle to Ellipse

Convert a Circle to an Ellipse.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double A, double B, double angle) CircleToEllipse0(
            double x, double y,
            double r)
        {
            return (x, y, r, r, 0);
        }
```

