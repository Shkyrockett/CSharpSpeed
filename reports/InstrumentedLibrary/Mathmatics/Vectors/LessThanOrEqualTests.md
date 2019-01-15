# Less Than Or Equal Point

Less Than Or Equal Points.

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

../../InstrumentedLibrary/Mathmatics/Vectors/LessThanOrEqualTests.cs

The required method signature for this API is as follows:

```CSharp
public static bool LessThanOrEqual(double aX, double aY, double bX, double bY)
```

## Test Case Index

- [Test Case: (0, 0, 1, 1)](#0,-0,-1,-1)

### (0, 0, 1, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [LessThanOrEqual0(0, 0, 1, 1)](#Greater-Than-Or-Equal-Point) | True != 15 | 10000 in 9 ms. 0.0009 ms. average |  |

## The Code

The code for the methods tested follows below.

### Greater Than Or Equal Point

Greater Than Or Equal Points.  
- [http://www.kevlindev.com/](http://www.kevlindev.com/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool LessThanOrEqual0(double aX, double aY, double bX, double bY)
        {
            return aX <= bX && aY <= bY;
        }
```

