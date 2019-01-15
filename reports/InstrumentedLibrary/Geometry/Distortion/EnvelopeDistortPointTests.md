# Envelope Distort Point Tests

Use a Bezier envelope to distort the location of a point.

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

../../InstrumentedLibrary/Geometry/Distortion/EnvelopeDistortPointTests.cs

The required method signature for this API is as follows:

```CSharp
public static Point2D EnvelopeDistortPoint(Point2D point, Rectangle2D bounds, Point2D topLeft, Point2D topLeftH, Point2D topLeftV, Point2D topRight, Point2D topRightH, Point2D topRightV, Point2D bottomRight, Point2D bottomRightH, Point2D bottomRightV, Point2D bottomLeft, Point2D bottomLeftH, Point2D bottomLeftV)
```

## Test Case Index

- [Test Case: (Point2D{X:5, Y:5 }, Rectangle2D{X:0, Y:0, Width:10, Height:10 }, Point2D{X:0, Y:0 }, Point2D{X:0.5, Y:-0.5 }, Point2D{X:0.5, Y:0.5 }, Point2D{X:10, Y:0 }, Point2D{X:0.5, Y:-0.5 }, Point2D{X:0.5, Y:0.5 }, Point2D{X:10, Y:10 }, Point2D{X:0.5, Y:0.5 }, Point2D{X:0.5, Y:0.5 }, Point2D{X:0, Y:10 }, Point2D{X:0.5, Y:0.5 }, Point2D{X:0.5, Y:0.5 })](#Point2D{X:5,-Y:5-},-Rectangle2D{X:0,-Y:0,-Width:10,-Height:10-},-Point2D{X:0,-Y:0-},-Point2D{X:0.5,-Y:-0.5-},-Point2D{X:0.5,-Y:0.5-},-Point2D{X:10,-Y:0-},-Point2D{X:0.5,-Y:-0.5-},-Point2D{X:0.5,-Y:0.5-},-Point2D{X:10,-Y:10-},-Point2D{X:0.5,-Y:0.5-},-Point2D{X:0.5,-Y:0.5-},-Point2D{X:0,-Y:10-},-Point2D{X:0.5,-Y:0.5-},-Point2D{X:0.5,-Y:0.5-})

### (Point2D{X:5, Y:5 }, Rectangle2D{X:0, Y:0, Width:10, Height:10 }, Point2D{X:0, Y:0 }, Point2D{X:0.5, Y:-0.5 }, Point2D{X:0.5, Y:0.5 }, Point2D{X:10, Y:0 }, Point2D{X:0.5, Y:-0.5 }, Point2D{X:0.5, Y:0.5 }, Point2D{X:10, Y:10 }, Point2D{X:0.5, Y:0.5 }, Point2D{X:0.5, Y:0.5 }, Point2D{X:0, Y:10 }, Point2D{X:0.5, Y:0.5 }, Point2D{X:0.5, Y:0.5 })

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Envelope1(Point2D{X:5, Y:5 }, Rectangle2D{X:0, Y:0, Width:10, Height:10 }, Point2D{X:0, Y:0 }, Point2D{X:0.5, Y:-0.5 }, Point2D{X:0.5, Y:0.5 }, Point2D{X:10, Y:0 }, Point2D{X:0.5, Y:-0.5 }, Point2D{X:0.5, Y:0.5 }, Point2D{X:10, Y:10 }, Point2D{X:0.5, Y:0.5 }, Point2D{X:0.5, Y:0.5 }, Point2D{X:0, Y:10 }, Point2D{X:0.5, Y:0.5 }, Point2D{X:0.5, Y:0.5 })](#Envelope-Warp-Method-All-Interpolation-Calls) | Point2D{X:1.625, Y:1.25 } == Point2D{X:1.625, Y:1.25 } | 10000 in 34 ms. 0.0034 ms. average | Warp a point |
| [Envelope2(Point2D{X:5, Y:5 }, Rectangle2D{X:0, Y:0, Width:10, Height:10 }, Point2D{X:0, Y:0 }, Point2D{X:0.5, Y:-0.5 }, Point2D{X:0.5, Y:0.5 }, Point2D{X:10, Y:0 }, Point2D{X:0.5, Y:-0.5 }, Point2D{X:0.5, Y:0.5 }, Point2D{X:10, Y:10 }, Point2D{X:0.5, Y:0.5 }, Point2D{X:0.5, Y:0.5 }, Point2D{X:0, Y:10 }, Point2D{X:0.5, Y:0.5 }, Point2D{X:0.5, Y:0.5 })](#Envelope-Warp-Method-Inlined-Interpolation) | Point2D{X:1.625, Y:1.25 } == Point2D{X:1.625, Y:1.25 } | 10000 in 27 ms. 0.0027 ms. average | Warp a point |

## The Code

The code for the methods tested follows below.

### Envelope Warp Method All Interpolation Calls

A method of warping a point using an envelope of Cubic Beziers.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D Envelope1(
            Point2D point,
            Rectangle2D bounds,
            Point2D topLeft, Point2D topLeftH, Point2D topLeftV,
            Point2D topRight, Point2D topRightH, Point2D topRightV,
            Point2D bottomRight, Point2D bottomRightH, Point2D bottomRightV,
            Point2D bottomLeft, Point2D bottomLeftH, Point2D bottomLeftV)
        {
            var norm = NormalizeBoundedPoint2DTests.NormalizePoint(bounds, point);
            var left = InterpolateCubicBezier1DTests.CubicBezier(topLeft.X, topLeftV.X, bottomLeftV.X, bottomLeft.X, norm.Y);
            var right = InterpolateCubicBezier1DTests.CubicBezier(topRight.X, topRightV.X, bottomRightV.X, bottomRight.X, norm.Y);
            var top = InterpolateCubicBezier1DTests.CubicBezier(topLeft.Y, topLeftH.Y, topRightH.Y, topRight.Y, norm.X);
            var bottom = InterpolateCubicBezier1DTests.CubicBezier(bottomLeft.Y, bottomLeftH.Y, bottomRightH.Y, bottomRight.Y, norm.X);
            var x = InterpolateLinear1DTests.LinearInterpolate1D(left, right, norm.X);
            var y = InterpolateLinear1DTests.LinearInterpolate1D(top, bottom, norm.Y);
            return new Point2D(x, y);
        }
```

### Envelope Warp Method Inlined Interpolation

A method of warping a point using an envelope of Cubic Beziers.  

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point2D Envelope2(
            Point2D point,
            Rectangle2D bounds,
            Point2D topLeft, Point2D topLeftH, Point2D topLeftV,
            Point2D topRight, Point2D topRightH, Point2D topRightV,
            Point2D bottomRight, Point2D bottomRightH, Point2D bottomRightV,
            Point2D bottomLeft, Point2D bottomLeftH, Point2D bottomLeftV)
        {
            // Normalize the point to the bounding box.
            var (normX, normY) = ((point.X - bounds.X) / bounds.Width, (point.Y - bounds.Top) / bounds.Height);

            // Set up Interpolation variables.
            var (minusNormX, minusNormY) = (1d - normX, 1d - normY);
            var (minusNormXSquared, minusNormYSquared) = (minusNormX * minusNormX, minusNormY * minusNormY);
            var (minusNormXCubed, minusNormYCubed) = (minusNormXSquared * minusNormX, minusNormYSquared * minusNormY);
            var (normXSquared, normYSquared) = (normX * normX, normY * normY);
            var (normXCubed, normYCubed) = (normXSquared * normX, normYSquared * normY);

            // Interpolate the normalized point along the Cubic Bézier curves
            var left = (minusNormYCubed * topLeft.X) + (3d * normY * minusNormYSquared * topLeftV.X) + (3d * normYSquared * minusNormY * bottomLeftV.X) + (normYCubed * bottomLeft.X);
            var right = (minusNormYCubed * topRight.X) + (3d * normY * minusNormYSquared * topRightV.X) + (3d * normYSquared * minusNormY * bottomRightV.X) + (normYCubed * bottomRight.X);
            var top = (minusNormXCubed * topLeft.Y) + (3d * normX * minusNormXSquared * topLeftH.Y) + (3d * normXSquared * minusNormX * topRightH.Y) + (normXCubed * topRight.Y);
            var bottom = (minusNormXCubed * bottomLeft.Y) + (3d * normX * minusNormXSquared * bottomLeftH.Y) + (3d * normXSquared * minusNormX * bottomRightH.Y) + (normXCubed * bottomRight.Y);

            // Linearly interpolate the point between the Bézier curves.
            return new Point2D(
                (minusNormX * left) + (normX * right),
                (minusNormY * top) + (normY * bottom)
                );
        }
```

