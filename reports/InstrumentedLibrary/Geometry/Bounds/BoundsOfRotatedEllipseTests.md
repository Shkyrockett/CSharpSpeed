# Bounds Rotated Ellipse Tests

Finds the Bounds of a rotated ellipse.

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

../../InstrumentedLibrary/Geometry/Bounds/BoundsOfRotatedEllipseTests.cs

The required method signature for this API is as follows:

```CSharp
public static Rectangle2D EllipseBounds(double x, double y, double r1, double r2, double angle)
```

## Test Case Index

- [Test Case: (5, 5, 5, 4, 0.785398163397448)](#5,-5,-5,-4,-0.785398163397448)

### (5, 5, 5, 4, 0.785398163397448)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [EllipseBoundingBox(5, 5, 5, 4, 0.785398163397448)](#Bounds-Rotated-Ellipse-1) | Rectangle2D{X:0.47230743093129135, Y:0.47230743093129135, Width:9.0553851381374173, Height:9.0553851381374173 } == Rectangle2D{X:0.47230743093129135, Y:0.47230743093129135, Width:9.0553851381374173, Height:9.0553851381374173 } | 10000 in 23 ms. 0.0023 ms. average |  Test for bounding box of ellipse. |
| [EllipseBounds0(5, 5, 5, 4, 0.785398163397448)](#Bounds-Rotated-Ellipse-2) | Rectangle2D{X:0.47230743093129135, Y:0.47230743093129135, Width:9.0553851381374173, Height:9.0553851381374173 } == Rectangle2D{X:0.47230743093129135, Y:0.47230743093129135, Width:9.0553851381374173, Height:9.0553851381374173 } | 10000 in 57 ms. 0.0057 ms. average |  Test for bounding box of ellipse. |
| [EllipseBounds2(5, 5, 5, 4, 0.785398163397448)](#Bounds-Rotated-Ellipse-3) | Rectangle2D{X:0.47230743093129135, Y:0.47230743093129135, Width:9.0553851381374173, Height:9.0553851381374173 } == Rectangle2D{X:0.47230743093129135, Y:0.47230743093129135, Width:9.0553851381374173, Height:9.0553851381374173 } | 10000 in 46 ms. 0.0046 ms. average |  Test for bounding box of ellipse. |

## The Code

The code for the methods tested follows below.

### Bounds Rotated Ellipse 1

Finds the Bounds of a rotated ellipse.  
- [http://stackoverflow.com/questions/87734/how-do-you-calculate-the-axis-aligned-bounding-box-of-an-ellipse](http://stackoverflow.com/questions/87734/how-do-you-calculate-the-axis-aligned-bounding-box-of-an-ellipse)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rectangle2D EllipseBoundingBox(double x, double y, double r1, double r2, double angle)
        {
            var a = r1 * Cos(angle);
            var b = r2 * Sin(angle);
            var c = r1 * Sin(angle);
            var d = r2 * Cos(angle);
            var width = Sqrt((a * a) + (b * b)) * 2d;
            var height = Sqrt((c * c) + (d * d)) * 2d;
            var x2 = x - (width * 0.5d);
            var y2 = y - (height * 0.5d);
            return new Rectangle2D(x2, y2, width, height);
        }
```

### Bounds Rotated Ellipse 2

Finds the Bounds of a rotated ellipse.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rectangle2D EllipseBounds0(double x, double y, double r1, double r2, double angle)
        {
            var phi = angle;
            var aspect = r2 / r1;
            var ux = r1 * Cos(phi);
            var uy = r1 * Sin(phi);
            var vx = r1 * aspect * Cos(phi + (PI / 2d));
            var vy = r1 * aspect * Sin(phi + (PI / 2d));

            var bbox_halfwidth = Sqrt((ux * ux) + (vx * vx));
            var bbox_halfheight = Sqrt((uy * uy) + (vy * vy));

            return Rectangle2D.FromLTRB(
                x - bbox_halfwidth,
                y - bbox_halfheight,
                x + bbox_halfwidth,
                y + bbox_halfheight
                );
        }
```

### Bounds Rotated Ellipse 3

Finds the Bounds of a rotated ellipse.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rectangle2D EllipseBounds2(double x, double y, double r1, double r2, double angle)
        {
            var phi = angle;
            var aspect = r2 / r1;
            var ux = r1 * Cos(phi);
            var uy = r1 * Sin(phi);
            var vx = r1 * aspect * Cos(phi + (PI * 0.5d));
            var vy = r1 * aspect * Sin(phi + (PI * 0.5d));

            var bbox_halfwidth = Sqrt((ux * ux) + (vx * vx));
            var bbox_halfheight = Sqrt((uy * uy) + (vy * vy));

            return Rectangle2D.FromLTRB(
                x - bbox_halfwidth,
                y - bbox_halfheight,
                x + bbox_halfwidth,
                y + bbox_halfheight
                );
        }
```

