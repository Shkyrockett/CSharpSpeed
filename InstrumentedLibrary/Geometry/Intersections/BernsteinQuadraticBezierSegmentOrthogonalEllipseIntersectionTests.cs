using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class BernsteinQuadraticBezierSegmentOrthogonalEllipseIntersectionTests
    {
        /// <summary>
        /// Find the intersection between a quadratic Bézier and an orthogonal ellipse.
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
        public static Intersection QuadraticBezierSegmentOrthogonalEllipseIntersection(
            Polynomial xCurve, Polynomial yCurve,
            double h, double k, double a, double b,
            double epsilon = double.Epsilon)
        {
            _ = epsilon;

            (var ax, var bx, var cx) = (xCurve[0], xCurve[1], xCurve[2]);
            (var ay, var by, var cy) = (yCurve[0], yCurve[1], yCurve[2]);

            var aa = a * a;
            var bb = b * b;

            // Find the polynomial that represents the intersections.
            var roots = new Polynomial((
                a: (bb * ax * ax) + (aa * ay * ay),
                b: 2d * ((bb * ax * bx) + (aa * ay * by)),
                c: (bb * ((2d * ax * cx) + (bx * bx))) + (aa * ((2d * ay * cy) + (by * by))) - (2d * ((bb * h * ax) + (aa * k * ay))),
                d: 2d * ((bb * bx * (cx - h)) + (aa * by * (cy - k))),
                e: (bb * ((cx * cx) + (h * h))) + (aa * ((cy * cy) + (k * k))) - (2d * ((bb * h * cx) + (aa * k * cy))) - (aa * bb)
            )).Trim().RootsInInterval();

            // Initialize intersection.
            var result = new Intersection(IntersectionStates.NoIntersection);
            foreach (var s in roots)
            {
                if (0d <= s && s <= 1d)
                {
                    result.Items.Add((
                        X: (ax * s * s) + (bx * s) + cx,
                        Y: (ay * s * s) + (by * s) + cy
                        ));
                }
            }

            if (result.Items.Count > 0)
            {
                result.State = IntersectionStates.Intersection;
            }

            return result;
        }
    }
}
