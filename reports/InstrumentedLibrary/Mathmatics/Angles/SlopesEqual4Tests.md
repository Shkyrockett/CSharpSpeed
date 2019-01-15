# Slopes Equal Tests

Determines whether slopes are Equal.

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

../../InstrumentedLibrary/Mathmatics/Angles/SlopesEqual4Tests.cs

The required method signature for this API is as follows:

```CSharp
public static bool SlopesEqual(Point2D a, Point2D b, Point2D c, Point2D d, bool UseFullRange = false)
```

## Test Case Index

- [Test Case: (Point2D{X:1, Y:2 }, Point2D{X:2, Y:1 }, Point2D{X:1, Y:2 }, Point2D{X:2, Y:1 }, True)](#Point2D{X:1,-Y:2-},-Point2D{X:2,-Y:1-},-Point2D{X:1,-Y:2-},-Point2D{X:2,-Y:1-},-True)

### (Point2D{X:1, Y:2 }, Point2D{X:2, Y:1 }, Point2D{X:1, Y:2 }, Point2D{X:2, Y:1 }, True)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [SlopesEqual0(Point2D{X:1, Y:2 }, Point2D{X:2, Y:1 }, Point2D{X:1, Y:2 }, Point2D{X:2, Y:1 }, True)](#Slopes-Equal) | True == True | 10000 in 12 ms. 0.0012 ms. average | 1, 2, 3, 4, 5 |

## The Code

The code for the methods tested follows below.

### Slopes Equal

Determines whether slopes are Equal.  
- [http://www.angusj.com/delphi/clipper.php](http://www.angusj.com/delphi/clipper.php)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SlopesEqual0(Point2D a, Point2D b, Point2D c, Point2D d, bool UseFullRange = false)
        {
            return UseFullRange ? BigInteger.Multiply((BigInteger)(a.Y - b.Y), (BigInteger)(b.X - c.X)) == BigInteger.Multiply((BigInteger)(a.X - b.X), (BigInteger)(b.Y - c.Y))
                : (int)(a.Y - b.Y) * (c.X - d.X) - (int)(a.X - b.X) * (c.Y - d.Y) == 0;
        }
```

