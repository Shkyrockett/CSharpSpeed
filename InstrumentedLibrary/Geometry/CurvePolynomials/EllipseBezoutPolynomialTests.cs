using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class EllipseBezoutPolynomialTests
    {
        /// <summary>
        /// Calculate the intersection polynomial coefficients of two ellipses.
        /// </summary>
        /// <param name="a">The first ellipse.</param>
        /// <param name="b">The first ellipse.</param>
        /// <returns>
        /// Returns a <see cref="Polynomial" /> of the ellipse.
        /// </returns>
        /// <acknowledgment>
        /// http://www.kevlindev.com/
        /// This code is based on MgcIntr2DElpElp.cpp written by David Eberly.
        /// His code along with many other excellent examples formerly available
        /// at his site but the latest version now at: https://www.geometrictools.com/
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double a, double b, double c, double d, double e) Bezout(
            (double a, double b, double c, double d, double e, double f) a,
            (double a, double b, double c, double d, double e, double f) b)
        {
            // 1 | a | b | c | d | e | f |
            // 2 | a | b | c | d | e | f |

            var ab = (a.a * b.b) - (b.a * a.b);
            var ac = (a.a * b.c) - (b.a * a.c);
            var ad = (a.a * b.d) - (b.a * a.d);
            var ae = (a.a * b.e) - (b.a * a.e);
            var af = (a.a * b.f) - (b.a * a.f);

            var bc = (a.b * b.c) - (b.b * a.c);
            var be = (a.b * b.e) - (b.b * a.e);
            var bf = (a.b * b.f) - (b.b * a.f);

            var cd = (a.c * b.d) - (b.c * a.d);

            var de = (a.d * b.e) - (b.d * a.e);
            var df = (a.d * b.f) - (b.d * a.f);

            var bfPde = bf + de;
            var beMcd = be - cd;

            return (
                /* x⁴ */ (ab * bc) - (ac * ac),
                /* x³ */ (ab * beMcd) + (ad * bc) - (2d * ac * ae),
                /* x² */ (ab * bfPde) + (ad * beMcd) - (ae * ae) - (2d * ac * af),
                /* x¹ */ (ab * df) + (ad * bfPde) - (2d * ae * af),
                /* c  */ (ad * df) - (af * af));
            // (-a2 * d1 * d1 * f2) + (a1 * d2) + (a2 * f1) - (a1 * f2) + (a1 * a2 f1 * f2) - (d2 * f1)
        }

        /// <summary>
        /// Calculate the coefficient of the quartic.
        /// The solution to intersecting ellipses are the solutions to f(y), a quartic function where f(y) = z0 + z1 * y + z2 * y^2 + z3 * y^3 + z4 * y^4  = 0
        /// getQuartic generates the coefficients z0 .. z4 given the two ellipses el and el1 in "bivariate" form.
        /// See http://www.math.niu.edu/~rusin/known-math/99/2ellipses
        /// </summary>
        /// <param name="a">The el1.</param>
        /// <param name="b">The el2.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3, T4, T5}"/>.</returns>
        /// <acknowledgment>
        /// https://www.khanacademy.org/computer-programming/handbook-of-collisions-and-interiors/5567955982876672
        /// https://www.khanacademy.org/computer-programming/ellipse-collision-detector/5514890244521984
        /// https://www.khanacademy.org/computer-programming/c/5567955982876672
        /// https://gist.github.com/drawable/92792f59b6ff8869d8b1
        /// </acknowledgment>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double a, double b, double c, double d, double e) GetEllipseQuartic(
            (double a, double b, double c, double d, double e, double f) a,
            (double a, double b, double c, double d, double e, double f) b)
        {
            return (
                a: (a.a * a.a * b.c * b.c) - (2d * a.a * b.c * b.a * a.c) + (b.a * b.a * a.c * a.c) - (a.b * a.a * b.b * b.c) - (a.b * b.b * b.a * a.c) + (a.b * a.b * b.a * b.c) + (a.c * a.a * b.b * b.b),
                b: (-2d * a.a * b.a * a.c * b.e) + (b.e * b.a * a.b * a.b) + (2d * b.c * a.b * b.a * a.d) - (a.c * b.a * b.b * a.d) + (b.b * b.b * a.a * a.e) - (b.e * b.b * a.a * a.b) - (2d * a.a * b.c * b.a * a.e) - (a.e * b.a * b.b * a.b) - (b.c * b.b * a.a * a.d) + (2d * b.e * b.c * a.a * a.a) + (2d * a.e * a.c * b.a * b.a) - (a.c * b.a * b.d * a.b) + (2d * b.d * b.b * a.a * a.c) - (b.c * b.d * a.a * a.b),
                c: (b.e * b.e * a.a * a.a) + (2d * b.c * b.f * a.a * a.a) - (a.e * b.a * b.d * a.b) + (b.f * b.a * a.b * a.b) - (a.e * b.a * b.b * a.d) - (b.f * b.b * a.a * a.b) - (2d * a.a * b.e * b.a * a.e) + (2d * b.d * b.b * a.a * a.e) - (b.c * b.d * a.a * a.d) - (2d * a.a * b.c * b.a * a.f) + (b.b * b.b * a.a * a.f) + (2d * b.e * a.b * b.a * a.d) + (a.e * a.e * b.a * b.a) - (a.c * b.a * b.d * a.d) - (b.e * b.b * a.a * a.d) + (2d * a.f * a.c * b.a * b.a) - (a.f * b.a * b.b * a.b) + (b.c * a.d * a.d * b.a) + (b.d * b.d * a.a * a.c) - (b.e * b.d * a.a * a.b) - (2d * a.a * b.f * b.a * a.c),
                d: (b.e * a.d * a.d * b.a) - (b.f * b.d * a.a * a.b) - (2d * a.a * b.f * b.a * a.e) - (a.f * b.a * b.b * a.d) + (2d * b.d * b.b * a.a * a.f) + (2d * b.e * b.f * a.a * a.a) + (b.d * b.d * a.a * a.e) - (b.e * b.d * a.a * a.d) - (2d * a.a * b.e * b.a * a.f) - (a.f * b.a * b.d * a.b) + (2d * a.f * a.e * b.a * b.a) - (b.f * b.b * a.a * a.d) - (a.e * b.a * b.d * a.d) + (2d * b.f * a.b * b.a * a.d),
                e: (a.f * a.a * b.d * b.d) + (a.a * a.a * b.f * b.f) - (a.d * a.a * b.d * b.f) + (b.a * b.a * a.f * a.f) - (2d * a.a * b.f * b.a * a.f) - (a.d * b.d * b.a * a.f) + (b.a * a.d * a.d * b.f)
            );
        }
    }
}
