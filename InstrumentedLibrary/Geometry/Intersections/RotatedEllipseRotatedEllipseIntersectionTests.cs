using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class RotatedEllipseRotatedEllipseIntersectionTests
    {
        /// <summary>
        /// Find the intersection between two ellipses.
        /// </summary>
        /// <param name="h1">The h1.</param>
        /// <param name="k1">The k1.</param>
        /// <param name="a1">The r x1.</param>
        /// <param name="b1">The r y1.</param>
        /// <param name="cos1">The cos1.</param>
        /// <param name="sin1">The sin1.</param>
        /// <param name="h2">The h2.</param>
        /// <param name="k2">The k2.</param>
        /// <param name="a2">The r x2.</param>
        /// <param name="b2">The r y2.</param>
        /// <param name="cos2">The cos2.</param>
        /// <param name="sin2">The sin2.</param>
        /// <param name="epsilon">The <paramref name="epsilon" /> or minimal value to represent a change.</param>
        /// <returns>
        /// Returns an <see cref="Intersection" /> struct with a <see cref="Intersection.State" />, and an array of <see cref="Point2D" /> structs containing any points of intersection found.
        /// </returns>
        /// <acknowledgment>
        /// http://www.kevlindev.com/
        /// https://www.geometrictools.com/Documentation/IntersectionOfEllipses.pdf
        /// </acknowledgment>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Intersection EllipseEllipseIntersection(
            double h1, double k1, double a1, double b1, double cos1, double sin1,
            double h2, double k2, double a2, double b2, double cos2, double sin2,
            double epsilon = double.Epsilon)
        {
            if (sin2 == 1d || sin2 == -1d) cos2 = 0d;

            // Polynomials representing the Ellipses.
            var a = RotatedEllipseConicSectionPolynomialTests.EllipseConicPolynomial(h1, k1, a1, b1, cos1, sin1);
            var b = RotatedEllipseConicSectionPolynomialTests.EllipseConicPolynomial(h2, k2, a2, b2, cos2, sin2);

            var yRoots = new Polynomial(EllipseBezoutPolynomialTests.Bezout(a, b)).Trim().Roots();

            var norm0 = ((a.a * a.a) + (2d * a.b * a.b) + (a.c * a.c)) * epsilon;
            //var norm1 = ((b.a * b.a) + (2d * b.b * b.b) + (b.c * b.c)) * epsilon;

            var result = new Intersection(IntersectionStates.NoIntersection);
            for (var y = 0; y < yRoots.Length; y++)
            {
                var xRoots = new Polynomial(
                    a.a,
                    a.d + (yRoots[y] * a.b),
                    a.f + (yRoots[y] * (a.e + (yRoots[y] * a.c))),
                    epsilon).Trim().Roots();
                for (var x = 0; x < xRoots.Length; x++)
                {
                    var test = (((a.a * xRoots[x]) + (a.b * yRoots[y]) + a.d) * xRoots[x]) + (((a.c * yRoots[y]) + a.e) * yRoots[y]) + a.f;
                    if (Abs(test) < norm0)
                    {
                        test = (((b.a * xRoots[x]) + (b.b * yRoots[y]) + b.d) * xRoots[x]) + (((b.c * yRoots[y]) + b.e) * yRoots[y]) + b.f;
                        if (Abs(test) < 1d)//norm1) // Using norm1 breaks when an ellipse intersects certain other ellipses. 
                        {
                            result.AppendPoint(new Point2D(xRoots[x], yRoots[y]));
                        }
                    }
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
