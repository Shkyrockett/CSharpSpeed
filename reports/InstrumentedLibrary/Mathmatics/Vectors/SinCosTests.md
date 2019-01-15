# Sin and Cos

Calculate the tuple of Sin and Cos.

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

../../InstrumentedLibrary/Mathmatics/Vectors/SinCosTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double Cos, double Sin) SinCos(double angle)
```

## Test Case Index

- [Test Case: (0)](#0)
- [Test Case: (0.523598775598299)](#0.523598775598299)
- [Test Case: (0.785398163397448)](#0.785398163397448)
- [Test Case: (1.0471975511966)](#1.0471975511966)
- [Test Case: (1.5707963267949)](#1.5707963267949)

### (0)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [SinCos_0(0)](#Sin-and-Cos-Reference) | (1, 0) == (1, 0) | 10000 in 6 ms. 0.0006 ms. average | . |
| [SinCos0(0)](#Sin-and-Cos-Lookup) | (1, 0) == (1, 0) | 10000 in 7 ms. 0.0007 ms. average | . |
| [SinCos1(0)](#Sin-and-Cos-Lookup) | (1, 0) == (1, 0) | 10000 in 7 ms. 0.0007 ms. average | . |
| [SinCos2(0)](#Sin-and-Cos-Lookup) | (1, 0) == (1, 0) | 10000 in 12 ms. 0.0012 ms. average | . |
| [SinCos3(0)](#Sin-and-Cos-Lookup) | (1, 0) == (1, 0) | 10000 in 20 ms. 0.002 ms. average | . |
| [SinCos4(0)](#Sin-and-Cos-Lookup) | (1, 0) == (1, 0) | 10000 in 8 ms. 0.0008 ms. average | . |
| [SinCosHighPrecision(0)](#Sin-and-Cos) | (0.99999998958681424, 0) != (1, 0) | 10000 in 5 ms. 0.0005 ms. average | . |
| [SinCosLowPrecision(0)](#Sin-and-Cos) | (0.99999999149944019, 0) != (1, 0) | 10000 in 5 ms. 0.0005 ms. average | . |

### (0.523598775598299)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [SinCos_0(0.523598775598299)](#Sin-and-Cos-Reference) | (0.86602540378443871, 0.49999999999999994) == (0.86602540378443871, 0.49999999999999994) | 10000 in 6 ms. 0.0006 ms. average | . |
| [SinCos0(0.523598775598299)](#Sin-and-Cos-Lookup) | (0.86602540378443871, 0.49999999999999994) == (0.86602540378443871, 0.49999999999999994) | 10000 in 12 ms. 0.0012 ms. average | . |
| [SinCos1(0.523598775598299)](#Sin-and-Cos-Lookup) | (0.86602540378443871, 0.49999999999999994) == (0.86602540378443871, 0.49999999999999994) | 10000 in 7 ms. 0.0007 ms. average | . |
| [SinCos2(0.523598775598299)](#Sin-and-Cos-Lookup) | (0.86602540378443871, 0.49999999999999994) == (0.86602540378443871, 0.49999999999999994) | 10000 in 11 ms. 0.0011 ms. average | . |
| [SinCos3(0.523598775598299)](#Sin-and-Cos-Lookup) | (0.86602540378443871, 0.49999999999999994) == (0.86602540378443871, 0.49999999999999994) | 10000 in 7 ms. 0.0007 ms. average | . |
| [SinCos4(0.523598775598299)](#Sin-and-Cos-Lookup) | (0.86602540378443871, 0.49999999999999994) == (0.86602540378443871, 0.49999999999999994) | 10000 in 7 ms. 0.0007 ms. average | . |
| [SinCosHighPrecision(0.523598775598299)](#Sin-and-Cos) | (0.86666665279421828, 0.499999997337675) != (0.86602540378443871, 0.49999999999999994) | 10000 in 5 ms. 0.0005 ms. average | . |
| [SinCosLowPrecision(0.523598775598299)](#Sin-and-Cos) | (0.88888887708254982, 0.55555555295816528) != (0.86602540378443871, 0.49999999999999994) | 10000 in 5 ms. 0.0005 ms. average | . |

### (0.785398163397448)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [SinCos_0(0.785398163397448)](#Sin-and-Cos-Reference) | (0.70710678118654757, 0.70710678118654757) == (0.70710678118654757, 0.70710678118654757) | 10000 in 12 ms. 0.0012 ms. average | . |
| [SinCos0(0.785398163397448)](#Sin-and-Cos-Lookup) | (0.70710678118654757, 0.70710678118654757) == (0.70710678118654757, 0.70710678118654757) | 10000 in 7 ms. 0.0007 ms. average | . |
| [SinCos1(0.785398163397448)](#Sin-and-Cos-Lookup) | (0.70710678118654757, 0.70710678118654757) == (0.70710678118654757, 0.70710678118654757) | 10000 in 13 ms. 0.0013 ms. average | . |
| [SinCos2(0.785398163397448)](#Sin-and-Cos-Lookup) | (0.70710678118654757, 0.70710678118654757) == (0.70710678118654757, 0.70710678118654757) | 10000 in 9 ms. 0.0009 ms. average | . |
| [SinCos3(0.785398163397448)](#Sin-and-Cos-Lookup) | (0.70710678118654757, 0.70710678118654757) == (0.70710678118654757, 0.70710678118654757) | 10000 in 11 ms. 0.0011 ms. average | . |
| [SinCos4(0.785398163397448)](#Sin-and-Cos-Lookup) | (0.70710678118654757, 0.70710678118654757) == (0.70710678118654757, 0.70710678118654757) | 10000 in 9 ms. 0.0009 ms. average | . |
| [SinCosHighPrecision(0.785398163397448)](#Sin-and-Cos) | (0.707812484928098, 0.70781249556709469) != (0.70710678118654757, 0.70710678118654757) | 10000 in 8 ms. 0.0008 ms. average | . |
| [SinCosLowPrecision(0.785398163397448)](#Sin-and-Cos) | (0.74999998645222288, 0.749999996015366) != (0.70710678118654757, 0.70710678118654757) | 10000 in 6 ms. 0.0006 ms. average | . |

### (1.0471975511966)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [SinCos_0(1.0471975511966)](#Sin-and-Cos-Reference) | (0.50000000000000011, 0.8660254037844386) == (0.50000000000000011, 0.8660254037844386) | 10000 in 12 ms. 0.0012 ms. average | . |
| [SinCos0(1.0471975511966)](#Sin-and-Cos-Lookup) | (0.50000000000000011, 0.8660254037844386) == (0.50000000000000011, 0.8660254037844386) | 10000 in 6 ms. 0.0006 ms. average | . |
| [SinCos1(1.0471975511966)](#Sin-and-Cos-Lookup) | (0.50000000000000011, 0.8660254037844386) == (0.50000000000000011, 0.8660254037844386) | 10000 in 8 ms. 0.0008 ms. average | . |
| [SinCos2(1.0471975511966)](#Sin-and-Cos-Lookup) | (0.50000000000000011, 0.8660254037844386) == (0.50000000000000011, 0.8660254037844386) | 10000 in 9 ms. 0.0009 ms. average | . |
| [SinCos3(1.0471975511966)](#Sin-and-Cos-Lookup) | (0.50000000000000011, 0.8660254037844386) == (0.50000000000000011, 0.8660254037844386) | 10000 in 6 ms. 0.0006 ms. average | . |
| [SinCos4(1.0471975511966)](#Sin-and-Cos-Lookup) | (0.50000000000000011, 0.8660254037844386) == (0.50000000000000011, 0.8660254037844386) | 10000 in 11 ms. 0.0011 ms. average | . |
| [SinCosHighPrecision(1.0471975511966)](#Sin-and-Cos) | (0.49999998426804654, 0.86666666028534722) != (0.50000000000000011, 0.8660254037844386) | 10000 in 5 ms. 0.0005 ms. average | . |
| [SinCosLowPrecision(1.0471975511966)](#Sin-and-Cos) | (0.55555554020730824, 0.88888888345797867) != (0.50000000000000011, 0.8660254037844386) | 10000 in 4 ms. 0.0004 ms. average | . |

### (1.5707963267949)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [SinCos_0(1.5707963267949)](#Sin-and-Cos-Reference) | (6.123233995736766E-17, 1) != (0, 1) | 10000 in 5 ms. 0.0005 ms. average | . |
| [SinCos0(1.5707963267949)](#Sin-and-Cos-Lookup) | (6.123233995736766E-17, 1) != (0, 1) | 10000 in 7 ms. 0.0007 ms. average | . |
| [SinCos1(1.5707963267949)](#Sin-and-Cos-Lookup) | (6.123233995736766E-17, 1) != (0, 1) | 10000 in 7 ms. 0.0007 ms. average | . |
| [SinCos2(1.5707963267949)](#Sin-and-Cos-Lookup) | (6.123233995736766E-17, 1) != (0, 1) | 10000 in 6 ms. 0.0006 ms. average | . |
| [SinCos3(1.5707963267949)](#Sin-and-Cos-Lookup) | (6.123233995736766E-17, 1) != (0, 1) | 10000 in 7 ms. 0.0007 ms. average | . |
| [SinCos4(1.5707963267949)](#Sin-and-Cos-Lookup) | (6.123233995736766E-17, 1) != (0, 1) | 10000 in 7 ms. 0.0007 ms. average | . |
| [SinCosHighPrecision(1.5707963267949)](#Sin-and-Cos) | (-1.4822872334160088E-08, 0.99999998958681424) != (0, 1) | 10000 in 6 ms. 0.0006 ms. average | . |
| [SinCosLowPrecision(1.5707963267949)](#Sin-and-Cos) | (-1.91262867765829E-08, 0.99999999149944019) != (0, 1) | 10000 in 5 ms. 0.0005 ms. average | . |

## The Code

The code for the methods tested follows below.

### Sin and Cos Reference

Calculate the tuple of Sin and Cos.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double Cos, double Sin) SinCos_0(double angle)
        {
            return (Cos(angle), Sin(angle));
        }
```

### Sin and Cos Lookup

Calculate the tuple of Sin and Cos.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double Cos, double Sin) SinCos0(double radian)
        {
            return sinCosTable.GetValueOrDefault(radian) ?? (sinCosTable[radian] = (Cos(radian), Sin(radian))).Value;
        }
```

### Sin and Cos Lookup

Calculate the tuple of Sin and Cos.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double Cos, double Sin) SinCos1(double radian)
        {
            return (sinCosTable[radian] = sinCosTable.GetValueOrDefault(radian) ?? (Cos(radian), Sin(radian))).Value;
        }
```

### Sin and Cos Lookup

Calculate the tuple of Sin and Cos.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double Cos, double Sin) SinCos2(double radian)
        {
            if (!sinCosTable.ContainsKey(radian))
            {
                sinCosTable.Add(radian, (Cos(radian), Sin(radian)));
            }

            return sinCosTable[radian].Value;
        }
```

### Sin and Cos Lookup

Calculate the tuple of Sin and Cos.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double Cos, double Sin) SinCos3(double radian)
        {
            if (!sinCosTable.ContainsKey(radian))
            {
                var value = (Cos(radian), Sin(radian));
                sinCosTable.Add(radian, value);
                return value;
            }

            return sinCosTable[radian].Value;
        }
```

### Sin and Cos Lookup

Calculate the tuple of Sin and Cos.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double Cos, double Sin) SinCos4(double radian)
        {
            if (!sinCosTable.ContainsKey(radian))
            {
                return (sinCosTable[radian] = (Cos(radian), Sin(radian))).Value;
            }

            return sinCosTable[radian].Value;
        }
```

### Sin and Cos

Calculate the tuple of Sin and Cos.  
- [http://web.archive.org/web/20110925033606/http://lab.polygonal.de/2007/07/18/fast-and-accurate-sinecosine-approximation/](http://web.archive.org/web/20110925033606/http://lab.polygonal.de/2007/07/18/fast-and-accurate-sinecosine-approximation/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double Cos, double Sin) SinCosHighPrecision(double x)
        {
            // Always wrap input angle to -PI..PI
            if (x < -PI)
            {
                x += Tau;
            }
            else
            {
                if (x > PI)
                {
                    x -= Tau;
                }
            }

            // Compute sine
            var sin = 0d;
            if (x < 0)
            {
                sin = 1.27323954 * x + 0.405284735 * x * x;

                sin = sin < 0 ? 0.225d * (sin * -sin - sin) + sin : 0.225d * (sin * sin - sin) + sin;
            }
            else
            {
                sin = 1.27323954d * x - 0.405284735d * x * x;

                sin = sin < 0 ? 0.225d * (sin * -sin - sin) + sin : 0.225d * (sin * sin - sin) + sin;
            }

            // Compute cosine: sin(x + PI/2) = cos(x)
            x += HalfPi;
            if (x > PI)
            {
                x -= Tau;
            }

            var cos = 0d;
            if (x < 0)
            {
                cos = 1.27323954d * x + 0.405284735d * x * x;

                cos = cos < 0 ? 0.225d * (cos * -cos - cos) + cos : 0.225d * (cos * cos - cos) + cos;
            }
            else
            {
                cos = 1.27323954d * x - 0.405284735d * x * x;

                cos = cos < 0d ? 0.225d * (cos * -cos - cos) + cos : 0.225d * (cos * cos - cos) + cos;
            }

            return (cos, sin);
        }
```

### Sin and Cos

Calculate the tuple of Sin and Cos.  
- [http://web.archive.org/web/20110925033606/http://lab.polygonal.de/2007/07/18/fast-and-accurate-sinecosine-approximation/](http://web.archive.org/web/20110925033606/http://lab.polygonal.de/2007/07/18/fast-and-accurate-sinecosine-approximation/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double Cos, double Sin) SinCosLowPrecision(double x)
        {
            // Always wrap input angle to -PI..PI.
            if (x < -PI)
            {
                x += Tau;
            }
            else
            {
                if (x > PI)
                {
                    x -= Tau;
                }
            }

            // Compute sine.
            var sin = x < 0 ? 1.27323954 * x + 0.405284735 * x * x : 1.27323954 * x - 0.405284735 * x * x;

            // Compute cosine: sin(x + PI/2) = cos(x).
            x += HalfPi;
            if (x > PI)
            {
                x -= Tau;
            }

            var cos = x < 0 ? 1.27323954 * x + 0.405284735 * x * x : 1.27323954 * x - 0.405284735 * x * x;

            return (cos, sin);
        }
```

