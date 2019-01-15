# Interpolate Rotated Elliptical Arc Tests

Find a point on an rotated elliptical arc.

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

../../InstrumentedLibrary/Geometry/Interpolation/InterpolateRotatedEllipseTests.cs

The required method signature for this API is as follows:

```CSharp
public static (double X, double Y) Ellipse(double cX, double cY, double r1, double r2, double angle, double t)
```

## Test Case Index

- [Test Case: (0, 0, 3, 4, 0, 0.5)](#0,-0,-3,-4,-0,-0.5)

### (0, 0, 3, 4, 0, 0.5)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [Ellipse_(0, 0, 3, 4, 0, 0.5)](#Interpolate-Unrotated-Ellipse-1) | (2.6327476856711183, 1.917702154416812) == (2.6327476856711183, 1.917702154416812) | 10000 in 9 ms. 0.0009 ms. average | Find the point halfway around an ellipse 3:4 centered about the origin. |

## The Code

The code for the methods tested follows below.

### Interpolate Unrotated Ellipse 1

Interpolates the unrotated ellipse.  
- [http://www.vbforums.com/showthread.php?686351-RESOLVED-Elliptical-orbit](http://www.vbforums.com/showthread.php?686351-RESOLVED-Elliptical-orbit)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) Ellipse_(
            double cX, double cY,
            double r1, double r2,
            double angle,
            double t)
            => Ellipse(cX, cY, r1, r2, Cos(angle), Sin(angle), Cos(t), Sin(t));

        /// <summary>
        /// Interpolate a point on an Ellipse.
        /// </summary>
        /// <param name="cX">Center x-coordinate.</param>
        /// <param name="cY">Center y-coordinate.</param>
        /// <param name="r1">The first radius of the Ellipse.</param>
        /// <param name="r2">The second radius of the Ellipse.</param>
        /// <param name="cosAngle">Horizontal rotation transform of the Ellipse.</param>
        /// <param name="sinAngle">Vertical rotation transform of the Ellipse.</param>
        /// <param name="cosTheta">Theta cosine of interpolation.</param>
        /// <param name="sinTheta">Theta sine of interpolation.</param>
        /// <returns>Interpolated point at theta.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) Ellipse(
            double cX, double cY,
            double r1, double r2,
            double cosAngle, double sinAngle,
            double cosTheta, double sinTheta)
        {
            // Ellipse equation for an ellipse at origin.
            var u = r1 * cosTheta;
            var v = -(r2 * sinTheta);

            // Apply the rotation transformation and translate to new center.
            return (
                cX + ((u * cosAngle) + (v * sinAngle)),
                cY + ((u * sinAngle) - (v * cosAngle)));
        }
```

