# Angle of a 2D Vector Tests

Find the angle of a 2D vector.

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

../../InstrumentedLibrary/Geometry/Bounds/BoundsOfRotatedEllipticalArcTests.cs

The required method signature for this API is as follows:

```CSharp
public static Rectangle2D EllipticalArc(double cX, double cY, double r1, double r2, double angle, double startAngle, double sweepAngle)
```

## Test Case Index

- [Test Case: (0, 0, 3, 4, 0.523598775598299, -0.523598775598299, 1.5707963267949)](#0,-0,-3,-4,-0.523598775598299,--0.523598775598299,-1.5707963267949)

### (0, 0, 3, 4, 0.523598775598299, -0.523598775598299, 1.5707963267949)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [EllipticalArc0(0, 0, 3, 4, 0.523598775598299, -0.523598775598299, 1.5707963267949)](#Interpolate-Unrotated-Ellipse-1) | Rectangle2D{X:2.2204460492503131E-16, Y:-2.2204460492503131E-16, Width:3.1788776569561055, Height:3.6599656879825124 } == Rectangle2D{X:2.2204460492503131E-16, Y:-2.2204460492503131E-16, Width:3.1788776569561055, Height:3.6599656879825124 } | 10000 in 133 ms. 0.0133 ms. average | Test for bounding box of elliptical arc. |
| [EllipticalArc1(0, 0, 3, 4, 0.523598775598299, -0.523598775598299, 1.5707963267949)](#Interpolate-Unrotated-Ellipse-1) | Rectangle2D{X:2.2204460492503131E-16, Y:-2.2204460492503131E-16, Width:3.1788776569561055, Height:3.6599656879825124 } == Rectangle2D{X:2.2204460492503131E-16, Y:-2.2204460492503131E-16, Width:3.1788776569561055, Height:3.6599656879825124 } | 10000 in 72 ms. 0.0072 ms. average | Test for bounding box of elliptical arc. |
| [EllipticalArc2(0, 0, 3, 4, 0.523598775598299, -0.523598775598299, 1.5707963267949)](#Interpolate-Unrotated-Ellipse-1) | Rectangle2D{X:2.2204460492503131E-16, Y:-2.2204460492503131E-16, Width:3.1788776569561055, Height:3.6599656879825124 } == Rectangle2D{X:2.2204460492503131E-16, Y:-2.2204460492503131E-16, Width:3.1788776569561055, Height:3.6599656879825124 } | 10000 in 52 ms. 0.0052 ms. average | Test for bounding box of elliptical arc. |
| [EllipticalArc3(0, 0, 3, 4, 0.523598775598299, -0.523598775598299, 1.5707963267949)](#Interpolate-Unrotated-Ellipse-1) | Rectangle2D{X:2.2204460492503131E-16, Y:-2.2204460492503131E-16, Width:3.1788776569561055, Height:3.6599656879825124 } == Rectangle2D{X:2.2204460492503131E-16, Y:-2.2204460492503131E-16, Width:3.1788776569561055, Height:3.6599656879825124 } | 10000 in 68 ms. 0.0068 ms. average | Test for bounding box of elliptical arc. |

## The Code

The code for the methods tested follows below.

### Interpolate Unrotated Ellipse 1

Interpolates the unrotated ellipse.  
- [http://fridrich.blogspot.com/2011/06/bounding-box-of-svg-elliptical-arc.html](http://fridrich.blogspot.com/2011/06/bounding-box-of-svg-elliptical-arc.html)
- [http://bazaar.launchpad.net/~inkscape.dev/inkscape/trunk/view/head:/src/2geom/elliptical-arc.cpp](http://bazaar.launchpad.net/~inkscape.dev/inkscape/trunk/view/head:/src/2geom/elliptical-arc.cpp)
- [http://stackoverflow.com/questions/87734/how-do-you-calculate-the-axis-aligned-bounding-box-of-an-ellipse](http://stackoverflow.com/questions/87734/how-do-you-calculate-the-axis-aligned-bounding-box-of-an-ellipse)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rectangle2D EllipticalArc0(
            double cX, double cY,
            double r1, double r2,
            double angle,
            double startAngle, double sweepAngle)
        {
            // Get the ellipse rotation transform.
            var cosT = Cos(angle);
            var sinT = Sin(angle);

            var i = (r1 - r2) * (r1 + r2) * sinT * cosT;

            // Find the angles of the Cartesian extremes.
            var angles = new double[4] {
                Atan2(i, (r2 * r2 * sinT * sinT) + (r1 * r1 * cosT * cosT)),
                Atan2((r1 * r1 * sinT * sinT) + (r2 * r2 * cosT * cosT), i),
                Atan2(i, (r2 * r2 * sinT * sinT) + (r1 * r1 * cosT * cosT)) + PI,
                Atan2((r1 * r1 * sinT * sinT) + (r2 * r2 * cosT * cosT), i) + PI };

            // Sort the angles so that like sides are consistently at the same index.
            Array.Sort(angles);

            // Get the start and end angles adjusted to polar coordinates.
            var t0 = EllipticalPolarAngleTests.EllipticalPolarAngle(startAngle, r1, r2);
            var t1 = EllipticalPolarAngleTests.EllipticalPolarAngle(startAngle + sweepAngle, r1, r2);

            // Interpolate the ratios of height and width of the chord.
            var sinT0 = Sin(t0);
            var cosT0 = Cos(t0);
            var sinT1 = Sin(t1);
            var cosT1 = Cos(t1);

            // Get the end points of the chord.
            var bounds = new Rectangle2D(
                // Apply the rotation transformation and translate to new center.
                new Point2D(
                    cX + ((r1 * cosT0 * cosT) - (r2 * sinT0 * sinT)),
                    cY + ((r1 * cosT0 * sinT) + (r2 * sinT0 * cosT))),
                // Apply the rotation transformation and translate to new center.
                new Point2D(
                    cX + ((r1 * cosT1 * cosT) - (r2 * sinT1 * sinT)),
                    cY + ((r1 * cosT1 * sinT) + (r2 * sinT1 * cosT))));

            // Find the parent ellipse's horizontal and vertical radii extremes.
            var halfWidth = Sqrt((r1 * r1 * cosT * cosT) + (r2 * r2 * sinT * sinT));
            var halfHeight = Sqrt((r1 * r1 * sinT * sinT) + (r2 * r2 * cosT * cosT));

            // Expand the elliptical boundaries if any of the extreme angles fall within the sweep angle.
            if (AngleWithinAngleTests.Within(angles[0], angle + startAngle, sweepAngle))
            {
                bounds.Right = cX + halfWidth;
            }

            if (AngleWithinAngleTests.Within(angles[1], angle + startAngle, sweepAngle))
            {
                bounds.Bottom = cY + halfHeight;
            }

            if (AngleWithinAngleTests.Within(angles[2], angle + startAngle, sweepAngle))
            {
                bounds.Left = cX - halfWidth;
            }

            if (AngleWithinAngleTests.Within(angles[3], angle + startAngle, sweepAngle))
            {
                bounds.Top = cY - halfHeight;
            }

            // Return the points of the Cartesian extremes of the rotated elliptical arc.
            return bounds;
        }
```

### Interpolate Unrotated Ellipse 1

Interpolates the unrotated ellipse.  
- [http://fridrich.blogspot.com/2011/06/bounding-box-of-svg-elliptical-arc.html](http://fridrich.blogspot.com/2011/06/bounding-box-of-svg-elliptical-arc.html)
- [http://bazaar.launchpad.net/~inkscape.dev/inkscape/trunk/view/head:/src/2geom/elliptical-arc.cpp](http://bazaar.launchpad.net/~inkscape.dev/inkscape/trunk/view/head:/src/2geom/elliptical-arc.cpp)
- [http://stackoverflow.com/questions/87734/how-do-you-calculate-the-axis-aligned-bounding-box-of-an-ellipse](http://stackoverflow.com/questions/87734/how-do-you-calculate-the-axis-aligned-bounding-box-of-an-ellipse)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rectangle2D EllipticalArc1(
            double cX, double cY,
            double r1, double r2,
            double angle,
            double startAngle, double sweepAngle)
        {
            // Get the ellipse rotation transform.
            var cosT = Cos(angle);
            var sinT = Sin(angle);

            // Find the angles of the Cartesian extremes.
            var angles = new double[4] {
                Atan2((r1 - r2) * (r1 + r2) * sinT * cosT, (r2 * r2 * sinT * sinT) + (r1 * r1 * cosT * cosT)),
                Atan2((r1 * r1 * sinT * sinT) + (r2 * r2 * cosT * cosT), (r1 - r2) * (r1 + r2) * sinT * cosT),
                Atan2((r1 - r2) * (r1 + r2) * sinT * cosT, (r2 * r2 * sinT * sinT) + (r1 * r1 * cosT * cosT)) + PI,
                Atan2((r1 * r1 * sinT * sinT) + (r2 * r2 * cosT * cosT), (r1 - r2) * (r1 + r2) * sinT * cosT) + PI };

            // Sort the angles so that like sides are consistently at the same index.
            Array.Sort(angles);

            // Get the start and end angles adjusted to polar coordinates.
            var t0 = EllipticalPolarAngleTests.EllipticalPolarAngle(startAngle, r1, r2);
            var t1 = EllipticalPolarAngleTests.EllipticalPolarAngle(startAngle + sweepAngle, r1, r2);

            // Interpolate the ratios of height and width of the chord.
            var sinT0 = Sin(t0);
            var cosT0 = Cos(t0);
            var sinT1 = Sin(t1);
            var cosT1 = Cos(t1);

            // Get the end points of the chord.
            var bounds = new Rectangle2D(
                // Apply the rotation transformation and translate to new center.
                new Point2D(
                    cX + ((r1 * cosT0 * cosT) - (r2 * sinT0 * sinT)),
                    cY + ((r1 * cosT0 * sinT) + (r2 * sinT0 * cosT))),
                // Apply the rotation transformation and translate to new center.
                new Point2D(
                    cX + ((r1 * cosT1 * cosT) - (r2 * sinT1 * sinT)),
                    cY + ((r1 * cosT1 * sinT) + (r2 * sinT1 * cosT))));

            // Find the parent ellipse's horizontal and vertical radii extremes.
            var halfWidth = Sqrt((r1 * r1 * cosT * cosT) + (r2 * r2 * sinT * sinT));
            var halfHeight = Sqrt((r1 * r1 * sinT * sinT) + (r2 * r2 * cosT * cosT));

            // Expand the elliptical boundaries if any of the extreme angles fall within the sweep angle.
            if (AngleWithinAngleTests.Within(angles[0], angle + startAngle, sweepAngle))
            {
                bounds.Right = cX + halfWidth;
            }

            if (AngleWithinAngleTests.Within(angles[1], angle + startAngle, sweepAngle))
            {
                bounds.Bottom = cY + halfHeight;
            }

            if (AngleWithinAngleTests.Within(angles[2], angle + startAngle, sweepAngle))
            {
                bounds.Left = cX - halfWidth;
            }

            if (AngleWithinAngleTests.Within(angles[3], angle + startAngle, sweepAngle))
            {
                bounds.Top = cY - halfHeight;
            }

            // Return the points of the Cartesian extremes of the rotated elliptical arc.
            return bounds;
        }
```

### Interpolate Unrotated Ellipse 1

Interpolates the unrotated ellipse.  
- [http://fridrich.blogspot.com/2011/06/bounding-box-of-svg-elliptical-arc.html](http://fridrich.blogspot.com/2011/06/bounding-box-of-svg-elliptical-arc.html)
- [http://bazaar.launchpad.net/~inkscape.dev/inkscape/trunk/view/head:/src/2geom/elliptical-arc.cpp](http://bazaar.launchpad.net/~inkscape.dev/inkscape/trunk/view/head:/src/2geom/elliptical-arc.cpp)
- [http://stackoverflow.com/questions/87734/how-do-you-calculate-the-axis-aligned-bounding-box-of-an-ellipse](http://stackoverflow.com/questions/87734/how-do-you-calculate-the-axis-aligned-bounding-box-of-an-ellipse)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rectangle2D EllipticalArc2(
            double cX, double cY,
            double r1, double r2,
            double angle,
            double startAngle, double sweepAngle)
        {
            // Get the ellipse rotation transform.
            var cosT = Cos(angle);
            var sinT = Sin(angle);

            // Find the angles of the Cartesian extremes.
            var angles = new List<double>(4) {
                Atan2((r1 - r2) * (r1 + r2) * sinT * cosT, (r2 * r2 * sinT * sinT) + (r1 * r1 * cosT * cosT)),
                Atan2((r1 * r1 * sinT * sinT) + (r2 * r2 * cosT * cosT), (r1 - r2) * (r1 + r2) * sinT * cosT),
                Atan2((r1 - r2) * (r1 + r2) * sinT * cosT, (r2 * r2 * sinT * sinT) + (r1 * r1 * cosT * cosT)) + PI,
                Atan2((r1 * r1 * sinT * sinT) + (r2 * r2 * cosT * cosT), (r1 - r2) * (r1 + r2) * sinT * cosT) + PI };

            // Sort the angles so that like sides are consistently at the same index.
            angles.Sort();

            // Calculate the radii of the angle of rotation.
            var a = r1 * cosT;
            var b = r2 * sinT;
            var c = r1 * sinT;
            var d = r2 * cosT;

            // Find the parent ellipse's horizontal and vertical radii extremes.
            var halfWidth = Sqrt((a * a) + (b * b));
            var halfHeight = Sqrt((c * c) + (d * d));

            // Get the end points of the chord.
            var bounds = new Rectangle2D(
                InterpolateRotatedEllipticalArcTests.EllipticalArc(cX, cY, r1, r2, angle, startAngle, sweepAngle, 0),
                InterpolateRotatedEllipticalArcTests.EllipticalArc(cX, cY, r1, r2, angle, startAngle, sweepAngle, 1));

            // Expand the elliptical boundaries if any of the extreme angles fall within the sweep angle.
            if (AngleWithinAngleTests.Within(angles[0], angle + startAngle, sweepAngle))
            {
                bounds.Right = cX + halfWidth;
            }

            if (AngleWithinAngleTests.Within(angles[1], angle + startAngle, sweepAngle))
            {
                bounds.Bottom = cY + halfHeight;
            }

            if (AngleWithinAngleTests.Within(angles[2], angle + startAngle, sweepAngle))
            {
                bounds.Left = cX - halfWidth;
            }

            if (AngleWithinAngleTests.Within(angles[3], angle + startAngle, sweepAngle))
            {
                bounds.Top = cY - halfHeight;
            }

            // Return the points of the Cartesian extremes of the rotated elliptical arc.
            return bounds;
        }
```

### Interpolate Unrotated Ellipse 1

Interpolates the unrotated ellipse.  
- [http://fridrich.blogspot.com/2011/06/bounding-box-of-svg-elliptical-arc.html](http://fridrich.blogspot.com/2011/06/bounding-box-of-svg-elliptical-arc.html)
- [http://bazaar.launchpad.net/~inkscape.dev/inkscape/trunk/view/head:/src/2geom/elliptical-arc.cpp](http://bazaar.launchpad.net/~inkscape.dev/inkscape/trunk/view/head:/src/2geom/elliptical-arc.cpp)
- [http://stackoverflow.com/questions/87734/how-do-you-calculate-the-axis-aligned-bounding-box-of-an-ellipse](http://stackoverflow.com/questions/87734/how-do-you-calculate-the-axis-aligned-bounding-box-of-an-ellipse)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rectangle2D EllipticalArc3(
            double cX, double cY,
            double r1, double r2,
            double angle,
            double startAngle, double sweepAngle)
        {
            // Get the ellipse rotation transform.
            var cosT = Cos(angle);
            var sinT = Sin(angle);

            // Calculate the radii of the angle of rotation.
            var a = r1 * cosT;
            var b = r2 * sinT;
            var c = r1 * sinT;
            var d = r2 * cosT;

            // Calculate the vectors of the Cartesian extremes.
            var u1 = r1 * Cos(Atan2(d, c));
            var v1 = -(r2 * Sin(Atan2(d, c)));
            var u2 = r1 * Cos(Atan2(-b, a));
            var v2 = -(r2 * Sin(Atan2(-b, a)));

            // Find the angles of the Cartesian extremes.
            var angles = new List<double>(4) {
                Atan2((u1 * sinT) - (v1 * cosT), (u1 * cosT) + (v1 * sinT)),
                Atan2((u2 * sinT) - (v2 * cosT), (u2 * cosT) + (v2 * sinT)),
                Atan2((u1 * sinT) - (v1 * cosT), (u1 * cosT) + (v1 * sinT)) + PI,
                Atan2((u2 * sinT) - (v2 * cosT), (u2 * cosT) + (v2 * sinT)) + PI };

            // Sort the angles so that like sides are consistently at the same index.
            angles.Sort();

            // Find the parent ellipse's horizontal and vertical radii extremes.
            var halfWidth = Sqrt((a * a) + (b * b));
            var halfHeight = Sqrt((c * c) + (d * d));

            // Get the end points of the chord.
            var bounds = new Rectangle2D(
                InterpolateRotatedEllipticalArcTests.EllipticalArc(cX, cY, r1, r2, angle, startAngle, sweepAngle, 0),
                InterpolateRotatedEllipticalArcTests.EllipticalArc(cX, cY, r1, r2, angle, startAngle, sweepAngle, 1));

            // Expand the elliptical boundaries if any of the extreme angles fall within the sweep angle.
            if (AngleWithinAngleTests.Within(angles[0], angle + startAngle, sweepAngle))
            {
                bounds.Right = cX + halfWidth;
            }

            if (AngleWithinAngleTests.Within(angles[1], angle + startAngle, sweepAngle))
            {
                bounds.Bottom = cY + halfHeight;
            }

            if (AngleWithinAngleTests.Within(angles[2], angle + startAngle, sweepAngle))
            {
                bounds.Left = cX - halfWidth;
            }

            if (AngleWithinAngleTests.Within(angles[3], angle + startAngle, sweepAngle))
            {
                bounds.Top = cY - halfHeight;
            }

            // Return the points of the Cartesian extremes of the rotated elliptical arc.
            return bounds;
        }
```

