# Log 2 of a Number

Find the Log 2 of a number.

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

../../InstrumentedLibrary/Mathmatics/Log2Tests.cs

The required method signature for this API is as follows:

```CSharp
public static int Log2(int value)
```

## Test Case Index

- [Test Case: (12)](#12)

### (12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Log2_0(12)](#Log-2-of-a-Number) | 4 == 4 | 10000 in 6 ms. 0.0006 ms. average |  |
| [Log2_1(12)](#Log-2-of-a-Number) | 3 != 4 | 10000 in 9 ms. 0.0009 ms. average |  |
| [SystemLog2(12)](#Log-2-of-a-Number) | 4 == 4 | 10000 in 6 ms. 0.0006 ms. average |  |

## The Code

The code for the methods tested follows below.

### Log 2 of a Number

Find the Log 2 of a number.  
- [http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c](http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Log2_0(int value)
        {
            byte bits = 0;
            while (value != 0)
            {
                ++bits;
                value >>= 1;
            }
            return bits;
        }
```

### Log 2 of a Number

Find the Log 2 of a number.  
- [http://graphics.stanford.edu/~seander/bithacks.html](http://graphics.stanford.edu/~seander/bithacks.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Log2_1(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "must be positive");
            }

            if (value == 1)
            {
                return 0;
            }

            // Locate the highest set bit.
            var v = unchecked((uint)value);
            v |= v >> 1;
            v |= v >> 2;
            v |= v >> 4;
            v |= v >> 8;
            v |= v >> 16;

            var i = unchecked(v * 0x7c4acdd) >> 27;
            int r = multiplyDeBruijnBitPosition[i];

            return r;
        }
```

### Log 2 of a Number

Find the Log 2 of a number.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SystemLog2(int value)
        {
            return (int)Round(Log(value, 2));
        }
```

