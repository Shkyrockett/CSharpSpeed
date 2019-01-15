# Linear Interpolate Tests

Find a point on a line.

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

../../InstrumentedLibrary/Geometry/Interpolation/InterpolateLinear1DTests.cs

The required method signature for this API is as follows:

```CSharp
public static double LinearInterpolate1D(double v1, double v2, double t)
```

## Test Case Index

- [Test Case: (0, 1, 0.5)](#0,-1,-0.5)

### (0, 1, 0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [LinearInterpolate1D_0(0, 1, 0.5)](#Linear-Interpolate-1) | 0.5 == 0.5 | 10000 in 7 ms. 0.0007 ms. average |  |
| [LinearInterpolate1D_1(0, 1, 0.5)](#Linear-Interpolate-2) | 0.5 == 0.5 | 10000 in 6 ms. 0.0006 ms. average |  |
| [LinearInterpolate1D_2(0, 1, 0.5)](#Linear-Interpolate-3) | 0.5 == 0.5 | 10000 in 7 ms. 0.0007 ms. average |  |

## The Code

The code for the methods tested follows below.

### Linear Interpolate 1

Simple Linear Interpolation.  
- [https://en.wikipedia.org/wiki/Linear_interpolation](https://en.wikipedia.org/wiki/Linear_interpolation)

```CSharp
        [Acknowledgment("https://en.wikipedia.org/wiki/Linear_interpolation")]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double LinearInterpolate1D_0(
            double v1, double v2, double t)
            => ((1 - t) * v1) + (t * v2);

        /// <summary>
        /// Imprecise method which does not guarantee v = v1 when t = 1, due to floating-point arithmetic error.
        /// This form may be used when the hardware has a native Fused Multiply-Add instruction.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://en.wikipedia.org/wiki/Linear_interpolation
        /// </acknowledgment>
        [DisplayName("Linear Interpolate 2")]
        [Description("Simple Linear Interpolation.")]
        [Acknowledgment("https://en.wikipedia.org/wiki/Linear_interpolation")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double LinearInterpolate1D_1(
            double v1, double v2, double t)
            => v1 + (t * (v2 - v1));

        /// <summary>
        /// The linear interpolate1d 3.
        /// </summary>
        /// <param name="v1">The v1.</param>
        /// <param name="v2">The v2.</param>
        /// <param name="t">The t.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// https://en.wikipedia.org/wiki/Linear_interpolation
        /// </acknowledgment>
        [DisplayName("Linear Interpolate 3")]
        [Description("Simple Linear Interpolation.")]
        [Acknowledgment("https://en.wikipedia.org/wiki/Linear_interpolation")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double LinearInterpolate1D_2(
            double v1, double v2, double t)
            => (Abs(v1 - v2) < DoubleEpsilon) ? 0 : v1 - (1 / (v1 - v2) * t);
    }
}
```

### Linear Interpolate 2

Simple Linear Interpolation.  
- [https://en.wikipedia.org/wiki/Linear_interpolation](https://en.wikipedia.org/wiki/Linear_interpolation)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double LinearInterpolate1D_1(
            double v1, double v2, double t)
            => v1 + (t * (v2 - v1));

        /// <summary>
        /// The linear interpolate1d 3.
        /// </summary>
        /// <param name="v1">The v1.</param>
        /// <param name="v2">The v2.</param>
        /// <param name="t">The t.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <acknowledgment>
        /// https://en.wikipedia.org/wiki/Linear_interpolation
        /// </acknowledgment>
        [DisplayName("Linear Interpolate 3")]
        [Description("Simple Linear Interpolation.")]
        [Acknowledgment("https://en.wikipedia.org/wiki/Linear_interpolation")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double LinearInterpolate1D_2(
            double v1, double v2, double t)
            => (Abs(v1 - v2) < DoubleEpsilon) ? 0 : v1 - (1 / (v1 - v2) * t);
    }
}
```

### Linear Interpolate 3

Simple Linear Interpolation.  
- [https://en.wikipedia.org/wiki/Linear_interpolation](https://en.wikipedia.org/wiki/Linear_interpolation)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double LinearInterpolate1D_2(
            double v1, double v2, double t)
            => (Abs(v1 - v2) < DoubleEpsilon) ? 0 : v1 - (1 / (v1 - v2) * t);
    }
}
```

