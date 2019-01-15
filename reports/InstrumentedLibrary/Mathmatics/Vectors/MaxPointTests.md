# Max Point

Finds the maximum of two points.

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

../../InstrumentedLibrary/Mathmatics/Vectors/MaxPointTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double X, double Y) MaxPoint(double point1X, double point1Y, double point2X, double point2Y)
```

## Test Case Index

- [Test Case: (0, 0, 1, 1)](#0,-0,-1,-1)

### (0, 0, 1, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [MaxPoint0(0, 0, 1, 1)](#Max-Point) | (1, 1) != 15 | 10000 in 15 ms. 0.0015 ms. average |  |

## The Code

The code for the methods tested follows below.

### Max Point

Finds the maximum of two points.  
- [http://www.kevlindev.com/](http://www.kevlindev.com/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) MaxPoint0(double point1X, double point1Y, double point2X, double point2Y)
        {
            return (Max(point1X, point2X), Max(point1Y, point2Y));
        }
```

