using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class BernsteinCubicBezierSegmentOrthogonalEllipseIntersectionTests
    {

        /// <summary>
        /// Find the intersection between a cubic Bézier and an orthogonal ellipse.
        /// </summary>
        /// <param name="xCurve">The set of Polynomial Bézier Coefficients of the x coordinates of the Bézier curve.</param>
        /// <param name="yCurve">The set of Polynomial Bézier Coefficients of the y coordinates of the Bézier curve.</param>
        /// <param name="h">The ecX.</param>
        /// <param name="k">The ecY.</param>
        /// <param name="a">The rx.</param>
        /// <param name="b">The ry.</param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns>Returns an <see cref="Intersection"/> struct with a <see cref="Intersection.State"/>, and an array of <see cref="Point2D"/> structs containing any points of intersection found.</returns>
        /// <acknowledgment>
        /// http://www.kevlindev.com/
        /// </acknowledgment>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection CubicBezierSegmentOrthogonalEllipseIntersection(
            Polynomial xCurve, Polynomial yCurve,
            double h, double k, double a, double b,
            double epsilon = double.Epsilon)
        {
            _ = epsilon;

            // Initialize intersection.
            var result = new Intersection(IntersectionStates.NoIntersection);

            (var ax, var bx, var cx, var dx) = (xCurve[0], xCurve[1], xCurve[2], xCurve[3]);
            (var ay, var by, var cy, var dy) = (yCurve[0], yCurve[1], yCurve[2], yCurve[3]);

            // Find the polynomial that represents the intersections.
            var roots = new Polynomial((
                a: ((ax * ax) * (b * b)) + ((ay * ay) * (a * a)),
                b: 2d * ((ax * bx * (b * b)) + (ay * by * (a * a))),
                c: (2d * ((ax * cx * (b * b)) + (ay * cy * (a * a)))) + ((bx * bx) * (b * b)) + ((by * by) * (a * a)),
                d: (2d * ax * (b * b) * (dx - h)) + (2d * ay * (a * a) * (dy - k)) + (2d * ((bx * cx * (b * b)) + (by * cy * (a * a)))),
                e: (2d * bx * (b * b) * (dx - h)) + (2d * by * (a * a) * (dy - k)) + ((cx * cx) * (b * b)) + ((cy * cy) * (a * a)),
                f: (2d * cx * (b * b) * (dx - h)) + (2d * cy * (a * a) * (dy - k)),
                g: (dx * dx * (b * b)) - (2d * dy * k * (a * a)) - (2d * dx * h * (b * b)) + ((dy * dy) * (a * a)) + ((h * h) * (b * b)) + ((k * k) * (a * a)) - ((a * a) * (b * b))
                )).Trim().RootsInInterval();

            foreach (var s in roots)
            {
                var point = new Point2D(
                    (ax * s * s * s) + (bx * s * s) + (cx * s) + dx,
                    (ay * s * s * s) + (by * s * s) + (cy * s) + dy);

                result.Items.Add(point);
            }

            if (result.Items.Count > 0)
            {
                result.State = IntersectionStates.Intersection;
            }

            return result;
        }
    }
}
