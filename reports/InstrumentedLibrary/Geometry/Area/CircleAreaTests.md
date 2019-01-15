# Area of Circle

Find the area of a circle.

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

../../InstrumentedLibrary/Geometry/Area/CircleAreaTests.cs

The required method signature for this API is as follows:

```CSharp
public static double CircleArea(double radius)
```

## Test Case Index

- [Test Case: (1)](#1)

### (1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [StandardCircleArea(1)](#Area-of-Circle) | 3.1415926535897931 != 1.2283696986087567 | 10000 in 12 ms. 0.0012 ms. average | Unit Circle. |

## The Code

The code for the methods tested follows below.

### Area of Circle

Find the area of a circle.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double StandardCircleArea(double r)
        {
            return PI * r * r;
        }
```

