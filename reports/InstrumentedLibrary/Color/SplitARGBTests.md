# Split Int Color to ARGB

Split an integer based ARGB color into the individual components.

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

../../InstrumentedLibrary/Color/SplitARGBTests.cs

The required method signature for this API is as follows:

```CSharp
public static (byte Red, byte Green, byte Blue, byte Alpha) SplitARGB(uint color)
```

## Test Case Index

- [Test Case: (3735928559)](#3735928559)
- [Test Case: (4294967295)](#4294967295)
- [Test Case: (16776960)](#16776960)
- [Test Case: (16711935)](#16711935)

### (3735928559)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [SplitARGBBitConverter(3735928559)](#Split-Int-Color-to-ARGB) | (222, 173, 190, 239) == (222, 173, 190, 239) | 10000 in 19 ms. 0.0019 ms. average | . |
| [SplitARGBBitShifting(3735928559)](#Split-Int-Color-to-ARGB) | (222, 173, 190, 239) == (222, 173, 190, 239) | 10000 in 21 ms. 0.0021 ms. average | . |
| [SplitARGBGetBytes(3735928559)](#Split-Int-Color-to-ARGB) | (222, 173, 190, 239) == (222, 173, 190, 239) | 10000 in 19 ms. 0.0019 ms. average | . |
| [SplitRGB01(3735928559)](#Split-Int-Color-to-ARGB) | (222, 173, 190, 239) == (222, 173, 190, 239) | 10000 in 15 ms. 0.0015 ms. average | . |
| [SplitRGB02(3735928559)](#Split-Int-Color-to-ARGB) | (222, 173, 190, 239) == (222, 173, 190, 239) | 10000 in 43 ms. 0.0043 ms. average | . |

### (4294967295)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [SplitARGBBitConverter(4294967295)](#Split-Int-Color-to-ARGB) | (255, 255, 255, 255) == (255, 255, 255, 255) | 10000 in 19 ms. 0.0019 ms. average | . |
| [SplitARGBBitShifting(4294967295)](#Split-Int-Color-to-ARGB) | (255, 255, 255, 255) == (255, 255, 255, 255) | 10000 in 17 ms. 0.0017 ms. average | . |
| [SplitARGBGetBytes(4294967295)](#Split-Int-Color-to-ARGB) | (255, 255, 255, 255) == (255, 255, 255, 255) | 10000 in 23 ms. 0.0023 ms. average | . |
| [SplitRGB01(4294967295)](#Split-Int-Color-to-ARGB) | (255, 255, 255, 255) == (255, 255, 255, 255) | 10000 in 15 ms. 0.0015 ms. average | . |
| [SplitRGB02(4294967295)](#Split-Int-Color-to-ARGB) | (255, 255, 255, 255) == (255, 255, 255, 255) | 10000 in 62 ms. 0.0062 ms. average | . |

### (16776960)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [SplitARGBBitConverter(16776960)](#Split-Int-Color-to-ARGB) | (0, 255, 255, 0) == (0, 255, 255, 0) | 10000 in 20 ms. 0.002 ms. average | . |
| [SplitARGBBitShifting(16776960)](#Split-Int-Color-to-ARGB) | (0, 255, 255, 0) == (0, 255, 255, 0) | 10000 in 20 ms. 0.002 ms. average | . |
| [SplitARGBGetBytes(16776960)](#Split-Int-Color-to-ARGB) | (0, 255, 255, 0) == (0, 255, 255, 0) | 10000 in 16 ms. 0.0016 ms. average | . |
| [SplitRGB01(16776960)](#Split-Int-Color-to-ARGB) | (0, 255, 255, 0) == (0, 255, 255, 0) | 10000 in 16 ms. 0.0016 ms. average | . |
| [SplitRGB02(16776960)](#Split-Int-Color-to-ARGB) | (0, 255, 255, 0) == (0, 255, 255, 0) | 10000 in 59 ms. 0.0059 ms. average | . |

### (16711935)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [SplitARGBBitConverter(16711935)](#Split-Int-Color-to-ARGB) | (0, 255, 0, 255) == (0, 255, 0, 255) | 10000 in 36 ms. 0.0036 ms. average | . |
| [SplitARGBBitShifting(16711935)](#Split-Int-Color-to-ARGB) | (0, 255, 0, 255) == (0, 255, 0, 255) | 10000 in 19 ms. 0.0019 ms. average | . |
| [SplitARGBGetBytes(16711935)](#Split-Int-Color-to-ARGB) | (0, 255, 0, 255) == (0, 255, 0, 255) | 10000 in 22 ms. 0.0022 ms. average | . |
| [SplitRGB01(16711935)](#Split-Int-Color-to-ARGB) | (0, 255, 0, 255) == (0, 255, 0, 255) | 10000 in 14 ms. 0.0014 ms. average | . |
| [SplitRGB02(16711935)](#Split-Int-Color-to-ARGB) | (0, 255, 0, 255) == (0, 255, 0, 255) | 10000 in 14 ms. 0.0014 ms. average | . |

## The Code

The code for the methods tested follows below.

### Split Int Color to ARGB

Split an integer based ARGB color into the individual components.  
- [https://stackoverflow.com/a/1318948](https://stackoverflow.com/a/1318948)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (byte Alpha, byte Red, byte Green, byte Blue) SplitARGBBitConverter(uint color)
        {
            var buffer = BitConverter.GetBytes(color);
            return (buffer[3], buffer[2], buffer[1], buffer[0]);
        }
```

### Split Int Color to ARGB

Split an integer based ARGB color into the individual components.  
- [https://stackoverflow.com/a/1328254](https://stackoverflow.com/a/1328254)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (byte Alpha, byte Red, byte Green, byte Blue) SplitARGBBitShifting(uint color)
        {
            return (
                Alpha: (byte)((color >> 24) & 0xFF),
                Red: (byte)((color >> 16) & 0xFF),
                Green: (byte)((color >> 8) & 0xFF),
                Blue: (byte)(color & 0xFF)
                );
        }
```

### Split Int Color to ARGB

Split an integer based ARGB color into the individual components.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe (byte Alpha, byte Red, byte Green, byte Blue) SplitARGBGetBytes(uint color)
        {
            var buffer = new byte[4];
            fixed (byte* bufferRef = buffer)
            {
                *(uint*)bufferRef = color;
            }
            return (buffer[3], buffer[2], buffer[1], buffer[0]);
        }
```

### Split Int Color to ARGB

Split an integer based ARGB color into the individual components.  
- [http://xbeat.net/vbspeed/c_SplitRGB.htm](http://xbeat.net/vbspeed/c_SplitRGB.htm)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (byte Alpha, byte Red, byte Green, byte Blue) SplitRGB01(uint color)
        {
            var blue = (byte)(color % 0x100);
            color = color / 0x100;
            var green = (byte)(color % 0x100);
            color = color / 0x100;
            var red = (byte)(color % 0x100);
            color = color / 0x100;
            var alpha = (byte)(color % 0x100);
            return (alpha, red, green, blue);
        }
```

### Split Int Color to ARGB

Split an integer based ARGB color into the individual components.  
- [http://xbeat.net/vbspeed/c_SplitRGB.htm](http://xbeat.net/vbspeed/c_SplitRGB.htm)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (byte Alpha, byte Red, byte Green, byte Blue) SplitRGB02(uint color)
        {
            return (
                Alpha: (byte)((color & 0xFF000000) / 0x1000000),
                Red: (byte)((color & 0x00FF0000) / 0x0010000),
                Green: (byte)((color & 0x0000FF00) / 0x0000100),
                Blue: (byte)(color & 0x000000FF)
            );
        }
```

