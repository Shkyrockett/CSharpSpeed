# Are Values Near Each Other Query

Determines whether a value is near another.

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

../../InstrumentedLibrary/Mathmatics/Queries/AreCloseTests.cs

The required method signature for this API is as follows:

```CSharp
public static bool AreClose(double value1, double value2, double epsilon = DoubleEpsilon)
```

## Test Case Index

- [Test Case: (0, 1E-20, 4.94065645841247E-324)](#0,-1E-20,-4.94065645841247E-324)

### (0, 1E-20, 4.94065645841247E-324)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [AreClose0(0, 1E-20, 4.94065645841247E-324)](#Are-Values-Near-Each-Other) | True == True | 10000 in 10 ms. 0.001 ms. average | . |

## The Code

The code for the methods tested follows below.

### Are Values Near Each Other

Determines whether a value is near another.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AreClose0(double value1, double value2, double epsilon = DoubleEpsilon)
        {
            // in case they are Infinities (then epsilon check does not work)
            if (Abs(value1 - value2) < DoubleEpsilon)
            {
                return true;
            }

            // This computes (|value1-value2| / (|value1| + |value2| + 10.0)) < DBL_EPSILON
            var eps = (Abs(value1) + Abs(value2) + 10d) * epsilon;
            var delta = value1 - value2;
            return (-eps < delta) && (eps > delta);
        }
```

