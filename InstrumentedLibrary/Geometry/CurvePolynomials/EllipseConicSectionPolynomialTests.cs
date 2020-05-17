using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class EllipseConicSectionPolynomialTests
    {
        /// <summary>
        /// Calculates a conic section polynomial that represents the provided rotated ellipse.
        /// </summary>
        /// <param name="h">The center X coordinate.</param>
        /// <param name="k">The center Y coordinate.</param>
        /// <param name="a">The width of the ellipse.</param>
        /// <param name="b">The height of the ellipse.</param>
        /// <param name="cos">The cosine of the angle of the ellipse.</param>
        /// <param name="sin">The sine of the angle of the ellipse.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://en.wikipedia.org/wiki/Ellipse#General_ellipse
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double a, double b, double c, double d, double e, double f) EllipseConicSectionPolynomial(double h, double k, double a, double b, double cos, double sin)
        {
            // Fix imprecise handling of Cos(PI/2) which breaks ellipses at right angles to each other.
            // Partial Fix for Oblique Ellipse, Oblique Ellipse intersection Test Case 2.
            if (sin == 1d || sin == -1d) cos = 0d;

            var coefA = a * a * sin * sin + b * b * cos * cos;
            var coefB = 2d * (b * b - a * a) * sin * cos;
            var coefC = a * a * cos * cos + b * b * sin * sin;
            return (
                a: coefA,
                b: coefB,
                c: coefC,
                d: -2d * coefA * h - coefB * k,
                e: -2d * coefC * k - coefB * h,
                f: coefA * h * h + coefB * h * k + coefC * k * k - a * a * b * b);
        }
    }
}
