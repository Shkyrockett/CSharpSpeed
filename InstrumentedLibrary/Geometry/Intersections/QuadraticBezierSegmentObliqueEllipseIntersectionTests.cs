using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class QuadraticBezierSegmentObliqueEllipseIntersectionTests
    {
        /// <summary>
        /// Quadratics the bezier segment oblique ellipse intersection.
        /// </summary>
        /// <param name="b1X">The b1 x.</param>
        /// <param name="b1Y">The b1 y.</param>
        /// <param name="b2X">The b2 x.</param>
        /// <param name="b2Y">The b2 y.</param>
        /// <param name="b3X">The b3 x.</param>
        /// <param name="b3Y">The b3 y.</param>
        /// <param name="h">The h.</param>
        /// <param name="k">The k.</param>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="cos">The cos.</param>
        /// <param name="sin">The sin.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns></returns>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection QuadraticBezierSegmentObliqueEllipseIntersection(
            double b1X, double b1Y, double b2X, double b2Y, double b3X, double b3Y,
            double h, double k, double a, double b, double cos, double sin, double epsilon = double.Epsilon)
        {
            // ToDo: This does work. But rotating the points seems inefficient.

            // Rotate the points of the Bezier in the reverse angle about the center of the ellipse to align with it.
            (b1X, b1Y) = RotatePointAboutPointTests.RotatePoint(b1X, b1Y, cos, -sin, h, k);
            (b2X, b2Y) = RotatePointAboutPointTests.RotatePoint(b2X, b2Y, cos, -sin, h, k);
            (b3X, b3Y) = RotatePointAboutPointTests.RotatePoint(b3X, b3Y, cos, -sin, h, k);

            // Find the points of intersection.
            var intersection = QuadraticBezierSegmentOrthogonalEllipseIntersectionTests.QuadraticBezierSegmentOrthogonalEllipseIntersection(b1X, b1Y, b2X, b2Y, b3X, b3Y, h, k, a, b, epsilon);

            // Rotate the points back forwards to the locations of the intersection.
            for (var i = 0; i < intersection.Items.Count; i++)
            {
                // Rotate point.
                intersection.Items[i] = RotatePointAboutPointTests.RotatePoint(intersection.Items[i].X, intersection.Items[i].Y, cos, sin, h, k);
            }

            // Return result.
            return intersection;
        }

        /// <summary>
        /// Find the intersection between a quadratic Bézier and an orthogonal ellipse.
        /// </summary>
        /// <param name="xCurve">The set of Polynomial Bézier Coefficients of the x coordinates of the Bézier curve.</param>
        /// <param name="yCurve">The set of Polynomial Bézier Coefficients of the y coordinates of the Bézier curve.</param>
        /// <param name="h">The ecX.</param>
        /// <param name="k">The ecY.</param>
        /// <param name="a">The rx.</param>
        /// <param name="b">The ry.</param>
        /// <param name="cos">The cos.</param>
        /// <param name="sin">The sin.</param>
        /// <param name="epsilon">The <paramref name="epsilon" /> or minimal value to represent a change.</param>
        /// <returns>
        /// Returns an <see cref="Intersection" /> struct with a <see cref="Intersection.State" />, and an array of <see cref="Point2D" /> structs containing any points of intersection found.
        /// </returns>
        /// <acknowledgment>
        /// http://www.kevlindev.com/
        /// </acknowledgment>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection QuadraticBezierSegmentObliqueEllipseIntersection(
            Polynomial xCurve, Polynomial yCurve,
            double h, double k, double a, double b, double cos, double sin,
            double epsilon = double.Epsilon)
        {
            _ = epsilon;

            (var ax, var bx, var cx) = (xCurve[0], xCurve[1], xCurve[2]);
            (var ay, var by, var cy) = (yCurve[0], yCurve[1], yCurve[2]);

            var cxh = (cos * (cx - h)) + (sin * (cy - k));
            var cyk = (cos * (cy - k)) - (sin * (cx - h));
            var aa = a * a;
            var bb = b * b;

            // Find the polynomial that represents the intersections.
            var roots = new Polynomial((
                a: (bb * (ax * ax)) + (aa * (ay * ay)),
                b: 2d * ((bb * (ax * bx)) + (aa * (ay * by))),
                c: (bb * ((2d * ax * cx) + (bx * bx))) - (2d * ((bb * h * ax) + (aa * k * ay))) + (aa * ((2d * ay * cy) + (by * by))),
                d: 2d * ((bb * bx * cxh) + (aa * by * cyk)),
                e: (bb * ((cx * cx) + (k * k))) - (2d * ((bb * h * cx) + (aa * k * cy))) + (aa * ((cy * cy) + (k * k))) - (aa * bb)
                )).Trim().Roots();

            // Initialize intersection.
            var result = new Intersection(IntersectionStates.NoIntersection);
            foreach (var s in roots)
            {
                var point = (
                    X: (ax * s * s) + (bx * s) + cx,
                    Y: (ay * s * s) + (by * s) + cy);

                if (0d <= s && s <= 1d)
                {
                    result.Items.Add(point);
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
