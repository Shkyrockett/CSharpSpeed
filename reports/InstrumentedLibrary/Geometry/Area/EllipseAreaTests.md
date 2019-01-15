# Area of Ellipse

Find the area of a Ellipse.

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

../../InstrumentedLibrary/Geometry/Area/EllipseAreaTests.cs

The required method signature for this API is as follows:

```CSharp
public static double EllipseArea(double radiusA, double radiusB)
```

## Test Case Index

- [Test Case: (1, 1)](#1,-1)

### (1, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [StandardEllipseArea(1, 1)](#Area-of-Ellipse) | 3.1415926535897931 != 1.2283696986087567 | 10000 in 13 ms. 0.0013 ms. average | Unit Circle. |

## The Code

The code for the methods tested follows below.

### Area of Ellipse

Find the area of a Ellipse.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double StandardEllipseArea(double rX, double rY)
        {
            return PI * rY * rX;
        }
```

