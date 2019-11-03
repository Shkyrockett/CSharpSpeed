using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Math;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class ObliqueEllipseObliqueEllipseIntersectionTests
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
        public static Intersection ObliqueEllipseObliqueEllipseIntersection(
            double h1, double k1, double a1, double b1, double cos1, double sin1,
            double h2, double k2, double a2, double b2, double cos2, double sin2,
            double epsilon = double.Epsilon)
        {
            // If the ellipses aren't rotated, use the slightly faster Orthogonal method.
            if (cos1 == Cos0 && cos2 == Cos0 && sin1 == Sin0 && sin2 == Sin0)
            {
                return OrthogonalEllipseOrthogonalEllipseIntersectionTests.OrthogonalEllipseOrthogonalEllipseIntersection(h1, k1, a1, b1, h2, k2, a2, b2, epsilon);
            }

            // If the angles are reflections of each other with slight loss of precision in sin cos, and they are the same height and size, the angle needs to be corrected.
            if (Abs(cos1 - cos2) < epsilon && Abs(sin1 + sin2) < epsilon && k1 == k2 && a1 == a2 && b1 == b2)
            {
                // Fix for Case 0.
                cos1 = cos2;
                sin1 = -sin2;
                // ToDo: Verify this fix with more tests.
                // What happens when the ellipses are swapped?
            }

            // If the ellipses are rotated at 90 degrees to each other, and their sizes are opposites, everything gets messed up. So, let's use Orthogonal intersection code.
            if (CrossProduct2Vector2DTests.CrossProduct2Vector2D(cos1, sin1, cos2, sin2) == 1d && a1 == b2 && a2 == b1)
            {
                // Rotate the center point of the second ellipse in the reverse angle about the center of the first ellipse to align with it.
                (h2, k2) = RotatePointAboutPointTests.RotatePoint(h2, k2, cos1, -sin1, h1, k1);

                // Rotate second ellipse Orthogonally.
                SwapTests.Swap(ref a2, ref b2);

                // Find the points of intersection.
                var intersection = OrthogonalEllipseOrthogonalEllipseIntersectionTests.OrthogonalEllipseOrthogonalEllipseIntersection(h1, k1, a1, b1, h2, k2, a2, b2, epsilon);

                // Rotate the points back forwards to the locations of the intersection.
                for (var i = 0; i < intersection.Items.Count; i++)
                {
                    // Rotate point.
                    intersection.Items[i] = RotatePointAboutPointTests.RotatePoint(intersection.Items[i].X, intersection.Items[i].Y, cos1, sin1, h1, k1);
                }

                // Return result.
                return intersection;
            }

            // Polynomials representing the Ellipses.
            var e1 = EllipseConicSectionPolynomialTests.EllipseConicSectionPolynomial(h1, k1, a1, b1, cos1, sin1);
            var e2 = EllipseConicSectionPolynomialTests.EllipseConicSectionPolynomial(h2, k2, a2, b2, cos2, sin2);

            var yRoots = new Polynomial(ConicSectionBezoutTests.ConicSectionBezout(e1, e2)).Trim().Roots();

            // Double epsilon is too small for here.
            epsilon = 1e-6; //1e-3;
            var norm0 = ((e1.a * e1.a) + (2d * e1.b * e1.b) + (e1.c * e1.c)) * epsilon;
            var norm1 = ((e2.a * e2.a) + (2d * e2.b * e2.b) + (e2.c * e2.c)) * epsilon;

            var result = new Intersection(IntersectionStates.NoIntersection);
            foreach (var s in yRoots)
            {
                var xRoots = new Polynomial((
                    a: e1.a,
                    b: e1.d + s * e1.b,
                    c: e1.f + s * (e1.e + s * e1.c)
                )).Trim().Roots();
                foreach (var t in xRoots)
                {
                    var test = (((e1.a * t) + (e1.b * s) + e1.d) * t) + (((e1.c * s) + e1.e) * s) + e1.f;
                    if (Abs(test) < norm0)
                    {
                        test = (((e2.a * t) + (e2.b * s) + e2.d) * t) + (((e2.c * s) + e2.e) * s) + e2.f;
                        if (Abs(test) < norm1)
                        {
                            result.AppendPoint(new Point2D(t, s));
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
