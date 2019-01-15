# Point In Orthogonal Ellipse Tests

Determines whether a point is in an Orthogonal Ellipse.

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

../../InstrumentedLibrary/Geometry/Contains/UnrotatedEllipseContainsPointTests.cs

The required method signature for this API is as follows:

```CSharp
public static bool UnrotatedEllipseContainsPoint(double x, double y, double rX, double rY, double pX, double pY)
```

## Test Case Index

- [Test Case: (0, 0, 2, 2, 0.5, 0.5)](#0,-0,-2,-2,-0.5,-0.5)

### (0, 0, 2, 2, 0.5, 0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [UnrotatedEllipseContainsPoint1(0, 0, 2, 2, 0.5, 0.5)](#Point-In-Ellipse-Tests) | True == True | 10000 in 19 ms. 0.0019 ms. average |  |

## The Code

The code for the methods tested follows below.

### Point In Ellipse Tests

Determines whether a point is in an Ellipse.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool UnrotatedEllipseContainsPoint1(double x, double y, double rX, double rY, double pX, double pY)
        {
            if (rX <= 0d || rY <= 0d)
            {
                return false;
            }

            var u = pX - x;
            var v = pY - y;

            var a = u * u;
            var b = u * u;

            var d1Squared = rX * rX;
            var d2Squared = rY * rY;

            return (a / d1Squared) + (b / d2Squared) <= 1d;
        }
```

