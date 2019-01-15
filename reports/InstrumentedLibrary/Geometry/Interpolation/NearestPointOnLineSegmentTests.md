# Nearest Point on Line Segment

Find the nearest point on a line segment to a point.

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

../../InstrumentedLibrary/Geometry/Interpolation/NearestPointOnLineSegmentTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double X, double Y) ClosestPointOnLineSegment(double aX, double aY, double bX, double bY, double pX, double pY)
```

## Test Case Index

- [Test Case: (0, 0, 1, 0, 1, 1)](#0,-0,-1,-0,-1,-1)

### (0, 0, 1, 0, 1, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [ClosestPointOnLineDarienPardinas(0, 0, 1, 0, 1, 1)](#Nearest-Point-on-Line-Segment) | (1, 0) == (1, 0) | 10000 in 8 ms. 0.0008 ms. average | . |
| [ClosestPointOnLineSegmentDarienPardinas(0, 0, 1, 0, 1, 1)](#Nearest-Point-on-Line-Segment) | (1, 0) == (1, 0) | 10000 in 13 ms. 0.0013 ms. average | . |
| [ClosestPointOnLineSegmentMvG(0, 0, 1, 0, 1, 1)](#Nearest-Point-on-Line-Segment) | (1, 0) == (1, 0) | 10000 in 13 ms. 0.0013 ms. average | . |

## The Code

The code for the methods tested follows below.

### Nearest Point on Line Segment

Find the nearest point on a line segment to a point.  
- [http://stackoverflow.com/questions/3120357/get-closest-point-to-a-line](http://stackoverflow.com/questions/3120357/get-closest-point-to-a-line)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) ClosestPointOnLineDarienPardinas(
            double aX, double aY,
            double bX, double bY,
            double pX, double pY)
        {
            // Vector A->P
            var diffAP = (X: pX - aX, Y: pY - aY);
            // Vector A->B
            var diffAB = (X: bX - aX, Y: bY - aY);
            var dotAB = diffAB.X * diffAB.X + diffAB.Y * diffAB.Y;
            // The dot product of diffAP and diffAB
            var dotABAP = diffAP.X * diffAB.X + diffAP.Y * diffAB.Y;
            // The normalized "distance" from a to the closest point
            var dist = dotABAP / dotAB;
            return (aX + diffAB.X * dist, aY + diffAB.Y * dist);
        }
```

### Nearest Point on Line Segment

Find the nearest point on a line segment to a point.  
- [http://stackoverflow.com/questions/3120357/get-closest-point-to-a-line](http://stackoverflow.com/questions/3120357/get-closest-point-to-a-line)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) ClosestPointOnLineSegmentDarienPardinas(
            double aX, double aY,
            double bX, double bY,
            double pX, double pY)
        {
            // Vector A->P
            var diffAP = (X: pX - aX, Y: pY - aY);
            // Vector A->B
            var diffAB = (X: bX - aX, Y: bY - aY);
            var dotAB = diffAB.X * diffAB.X + diffAB.Y * diffAB.Y;
            // The dot product of diffAP and diffAB
            var dotABAP = diffAP.X * diffAB.X + diffAP.Y * diffAB.Y;
            //  # The normalized "distance" from a to the closest point
            var dist = dotABAP / dotAB;
            if (dist < 0)
            {
                return (aX, aY);
            }
            else if (dist > dotABAP)
            {
                return (bX, bY);
            }
            else
            {
                return (aX + diffAB.X * dist, aY + diffAB.Y * dist);
            }
        }
```

### Nearest Point on Line Segment

Find the nearest point on a line segment to a point.  
- [http://stackoverflow.com/questions/3120357/get-closest-point-to-a-line](http://stackoverflow.com/questions/3120357/get-closest-point-to-a-line)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) ClosestPointOnLineSegmentMvG(
            double aX, double aY,
            double bX, double bY,
            double pX, double pY)
        {
            // Vector A->B
            var diffAB = (X: aX - bX, Y: aY - bY);
            var det = aY * bX - aX * bY;
            var dot = diffAB.X * pX + diffAB.Y * pY;
            var val = (X: dot * diffAB.X + det * diffAB.Y, Y: dot * diffAB.Y - det * diffAB.X);
            var magnitude = diffAB.X * diffAB.X + diffAB.Y * diffAB.Y;
            var inverseDist = 1 / magnitude;
            return (val.X * inverseDist, val.Y * inverseDist);
        }
```

