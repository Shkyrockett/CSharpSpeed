# Min Point

Finds the minimum of two points.

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

../../InstrumentedLibrary/Mathmatics/Vectors/MinPointTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double X, double Y) MinPoint(double point1X, double point1Y, double point2X, double point2Y)
```

## Test Case Index

- [Test Case: (0, 0, 1, 1)](#0,-0,-1,-1)

### (0, 0, 1, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [MinPoint0(0, 0, 1, 1)](#Min-Point) | (0, 0) != 15 | 10000 in 10 ms. 0.001 ms. average |  |

## The Code

The code for the methods tested follows below.

### Min Point

Finds the minimum of two points.  
- [http://www.kevlindev.com/](http://www.kevlindev.com/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) MinPoint0(double point1X, double point1Y, double point2X, double point2Y)
        {
            return (Min(point1X, point2X), Min(point1Y, point2Y));
        }
```

