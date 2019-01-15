# Distance to line segment from point

Calculates the distance from a point to the nearest point on a line segment.

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

../../InstrumentedLibrary/Geometry/Length/DistanceToLineSegmentTests.cs

The required method signature for this API is as follows:

```CSharp
public static double DistanceToSegment(double px, double py, double x1, double y1, double x2, double y2)
```

## Test Case Index

- [Test Case: (1, 1, 2, 2, 1.5, 1.5)](#1,-1,-2,-2,-1.5,-1.5)

### (1, 1, 2, 2, 1.5, 1.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [DistanceToSegment1(1, 1, 2, 2, 1.5, 1.5)](#Distance-to-line-segment-from-point) | (0.707106781186548, (1.5, 1.5)) != 15 | 10000 in 12 ms. 0.0012 ms. average | 1, 2, 3, 4, 5 |
| [DistFromSeg(1, 1, 2, 2, 1.5, 1.5)](#Distance-to-line-segment-from-point) | 0 != 15 | 10000 in 8 ms. 0.0008 ms. average | 1, 2, 3, 4, 5 |
| [DistToSegment(1, 1, 2, 2, 1.5, 1.5)](#Distance-to-line-segment-from-point) | 1.4142135623730951 != 15 | 10000 in 11 ms. 0.0011 ms. average | 1, 2, 3, 4, 5 |
| [DistToSegment2(1, 1, 2, 2, 1.5, 1.5)](#Distance-to-line-segment-from-point) | 1.4142135623730951 != 15 | 10000 in 23 ms. 0.0023 ms. average | 1, 2, 3, 4, 5 |

## The Code

The code for the methods tested follows below.

### Distance to line segment from point

Calculates the distance from a point to the nearest point on a line segment.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double distance, (double, double)) DistanceToSegment1(double px, double py, double x1, double y1, double x2, double y2)
        {
            var RetNear = (X: 0d, Y: 0d);
            var Delta = (X: x2 - x1, Y: y2 - y1);
            if ((Abs(Delta.X) < DoubleEpsilon) && (Abs(Delta.Y) < DoubleEpsilon))
            {
                //  It's a point not a line segment.
                Delta.X = px - x1;
                Delta.Y = py - y1;
                RetNear.X = x1;
                RetNear.Y = y1;
                return (Sqrt((Delta.X * Delta.X) + (Delta.Y * Delta.Y)), RetNear);
            }
            //  Calculate the t that minimizes the distance.
            var t = (((px - x1) * Delta.X) + ((py - y1) * Delta.Y)) / ((Delta.X * Delta.X) + (Delta.Y * Delta.Y));
            if (t < 0)
            {
                Delta.X = px - x1;
                Delta.Y = py - y1;
                RetNear.X = x1;
                RetNear.Y = y1;
            }
            else if (t > 1)
            {
                Delta.X = px - x2;
                Delta.Y = py - y2;
                RetNear.X = x2;
                RetNear.Y = y2;
            }
            else
            {
                RetNear.X = x1 + (t * Delta.X);
                RetNear.Y = y1 + (t * Delta.Y);
                Delta.X = px - RetNear.X;
                Delta.Y = py - RetNear.Y;
            }
            return (Sqrt((Delta.X * Delta.X) + (Delta.Y * Delta.Y)), RetNear);
        }
```

### Distance to line segment from point

Calculates the distance from a point to the nearest point on a line segment.  
- [http://stackoverflow.com/questions/2255842/detecting-coincident-subset-of-two-coincident-line-segments/2255848](http://stackoverflow.com/questions/2255842/detecting-coincident-subset-of-two-coincident-line-segments/2255848)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DistFromSeg(double px, double py, double x1, double y1, double x2, double y2)
        {
            (double X, double Y) p = (px, py);
            (double X, double Y) q0 = (x1, y1);
            (double X, double Y) q1 = (x2, y2);
            // formula here:
            // http://mathworld.wolfram.com/Point-LineDistance2-Dimensional.html
            // where x0,y0 = p
            //       x1,y1 = q0
            //       x2,y2 = q1
            var dx21 = q1.X - q0.X;
            var dy21 = q1.Y - q0.Y;
            var dx10 = q0.X - p.X;
            var dy10 = q0.Y - p.Y;
            var segLength = Sqrt(dx21 * dx21 + dy21 * dy21);
            if (segLength < Epsilon)
            {
                throw new Exception("Expected line segment, not point.");
            }

            var num = Abs(dx21 * dy10 - dx10 * dy21);
            var d = num / segLength;
            return d;
        }
```

### Distance to line segment from point

Calculates the distance from a point to the nearest point on a line segment.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DistToSegment(double px, double py, double x1, double y1, double x2, double y2)
        {
            var dx = x2 - x1;
            var dy = y2 - y1;
            if ((Abs(dx) < DoubleEpsilon) && (Abs(dy) < DoubleEpsilon))
            {
                //  It's a point not a line segment.
                dx = px - x1;
                dy = py - y1;
                return Sqrt((dx * dx) + (dy * dy));
            }
            var t = (px + (py - (x1 - y1))) / (dx + dy);
            if (t < 0)
            {
                dx = px - x1;
                dy = py - y1;
            }
            else if (t > 1)
            {
                dx = px - x2;
                dy = py - y2;
            }
            else
            {
                var x3 = x1 + (t * dx);
                var y3 = y1 + (t * dy);
                dx = px - x3;
                dy = py - y3;
            }
            return Sqrt((dx * dx) + (dy * dy));
        }
```

### Distance to line segment from point

Calculates the distance from a point to the nearest point on a line segment.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DistToSegment2(double px, double py, double x1, double y1, double x2, double y2)
        {
            double dx;
            double dy;
            double t;
            dx = x2 - x1;
            dy = y2 - y1;
            if ((Abs(dx) < DoubleEpsilon) && (Abs(dy) < DoubleEpsilon))
            {
                //  It's a point not a line segment.
                dx = px - x1;
                dy = py - y1;
                return Sqrt((dx * dx) + (dy * dy));
            }
            t = (px + (py - (x1 - y1))) / (dx + dy);
            if (t < 0)
            {
                dx = px - x1;
                dy = py - y1;
            }
            else if (t > 1)
            {
                dx = px - x2;
                dy = py - y2;
            }
            else
            {
                var x3 = x1 + (t * dx);
                var y3 = y1 + (t * dy);
                dx = px - x3;
                dy = py - y3;
            }
            return Sqrt((dx * dx) + (dy * dy));
        }
```

