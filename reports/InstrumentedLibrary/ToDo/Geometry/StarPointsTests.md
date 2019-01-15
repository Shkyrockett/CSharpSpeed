# Star Points Tests

Star Points.

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

../../InstrumentedLibrary/ToDo/Geometry/StarPointsTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double X, double Y)[] StarPoints(double x, double y, double width, double height, int num_points)
```

## Test Case Index

- [Test Case: (0, 0, 4, 4, 5)](#0,-0,-4,-4,-5)

### (0, 0, 4, 4, 5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [StarPoints0(0, 0, 4, 4, 5)](#Star-Points-Tests) | System.ValueTuple`2[System.Double,System.Double][] != True | 10000 in 19 ms. 0.0019 ms. average |  |

## The Code

The code for the methods tested follows below.

### Star Points Tests

Star Points.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y)[] StarPoints0(double x, double y, double width, double height, int num_points)
        {
            // Make room for the points.
            var pts = new (double X, double Y)[num_points];

            var rx = width / 2d;
            var ry = height / 2d;
            var cx = x + rx;
            var cy = y + ry;

            // Start at the top.
            var theta = -PI / 2d;
            var dtheta = 4d * PI / num_points;
            for (var i = 0; i < num_points; i++)
            {
                pts[i] = (
                    cx + rx * Cos(theta),
                    cy + ry * Sin(theta));
                theta += dtheta;
            }

            return pts;
        }
```

