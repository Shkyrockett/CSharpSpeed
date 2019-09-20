using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class RotatedEllipseConicSectionPolynomialTests
    {
        /// <summary>
        /// Ellipses the polynomial.
        /// </summary>
        /// <param name="h">The center X coordinate.</param>
        /// <param name="k">The center Y coordinate.</param>
        /// <param name="a">The width of the ellipse.</param>
        /// <param name="b">The height of the ellipse.</param>
        /// <param name="cosA">The cosine of the angle of the ellipse.</param>
        /// <param name="sinA">The sine of the angle of the ellipse.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://en.wikipedia.org/wiki/Ellipse#General_ellipse
        /// </acknowledgment>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double a, double b, double c, double d, double e, double f) EllipseConicPolynomial(double h, double k, double a, double b, double cosA, double sinA)
        {
            // Fix imprecise handling of Cos(PI/2) which breaks ellipses at right angles to each other.
            if (sinA == 1d || sinA == -1d) cosA = 0d;

            var coefA = a * a * sinA * sinA + b * b * cosA * cosA;
            var coefB = 2d * (b * b - a * a) * sinA * cosA;
            var coefC = a * a * cosA * cosA + b * b * sinA * sinA;
            return (
                a: coefA,
                b: coefB,
                c: coefC,
                d: -2d * coefA * h - coefB * k,
                e: -2d * coefC * k - coefB * h,
                f: coefA * h * h + coefB * h * k + coefC * k * k - a * a * b * b);
        }

        /// <summary>
        /// Converts the ellipse to conic section sextic.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="h">The h.</param>
        /// <param name="k">The k.</param>
        /// <param name="cos">The cos.</param>
        /// <param name="sin">The sin.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://math.stackexchange.com/a/2989928
        /// </acknowledgment>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double a, double b, double c, double d, double e, double f) ConvertEllipseToConicSectionSextic(double a, double b, double h, double k, double cos, double sin)
        {
            var cos2 = cos * cos;
            var sin2 = sin * sin;
            var sin2t = 2d * sin * cos;
            var a2 = a * a;
            var b2 = b * b;
            var h2 = h * h;
            var k2 = k * k;

            var c0 = cos2 / a2 + sin2 / b2;
            var c1 = sin2 / a2 + cos2 / b2;
            var c2 = sin2t / a2 - sin2t / b2;
            var c3 = -(2d * h * cos2) / a2 - k * sin2t / a2 - 2d * h * sin2 / b2 + k * sin2t / b2;
            var c4 = -(h * sin2t) / a2 - 2d * k * sin2 / a2 + h * sin2t / b2 - 2d * k * cos2 / b2;
            var c5 = h2 * cos2 / a2 + h * k * sin2t / a2 + k2 * sin2 / a2 + h2 * sin2 / b2 - h * k * sin2t / b2 + k2 * cos2 / b2 - 1d;

            return (c0, c1, c2, c3, c4, c5);
        }
    }
}
