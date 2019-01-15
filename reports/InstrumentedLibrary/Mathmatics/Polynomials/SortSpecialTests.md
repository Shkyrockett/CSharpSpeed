# SortSpecial

SortSpecial.

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

../../InstrumentedLibrary/Mathmatics/Polynomials/SortSpecialTests.cs

The required method signature for this API is as follows:

```CSharp
public static double[] SortSpecial(double[] a)
```

## Test Case Index

- [Test Case: (System.Double[])](#System.Double[])

### (System.Double[])

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [SortSpecial0(System.Double[])](#Special-Sorting-method) | double\[\] {1, 2, 4, 5, -3} != Quadratic | 10000 in 11 ms. 0.0011 ms. average | Dumb Polynomial test. |

## The Code

The code for the methods tested follows below.

### Special Sorting method

Special Sorting method.  
- [http://abecedarical.com/javascript/script_exact_cubic.html](http://abecedarical.com/javascript/script_exact_cubic.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[] SortSpecial0(double[] a)
        {
            bool flip;
            double temp;

            do
            {
                flip = false;
                for (var i = 0; i < a.Length - 1; i++)
                {
                    if ((a[i + 1] >= 0d && a[i] > a[i + 1]) ||
                        (a[i] < 0d && a[i + 1] >= 0d))
                    {
                        flip = true;
                        temp = a[i];
                        a[i] = a[i + 1];
                        a[i + 1] = temp;
                    }
                }
            } while (flip);
            return a;
        }
```

