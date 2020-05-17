using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class OrthagonalEllipseConicSectionPolynomialTests
    {
        /// <summary>
        /// Calculates a polynomial that represents the provided orthogonal ellipse.
        /// </summary>
        /// <param name="h">The h.</param>
        /// <param name="k">The k.</param>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://www.kevlindev.com/
        /// https://www.geometrictools.com/Documentation/IntersectionOfEllipses.pdf
        /// </acknowledgment>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double a, double b, double c, double d, double e, double f) OrthogonalEllipseConicPolynomial(double h, double k, double a, double b)
        {
            var coefA = b * b;
            var coefC = a * a;
            return (
                a: coefA,
                b: 0d,
                c: coefC,
                d: -2d * coefA * h,
                e: -2d * coefC * k,
                f: coefA * h * h + coefC * k * k - a * a * b * b);
        }

        /// <summary>
        /// Converts the ellipse to conic section sextic.
        /// </summary>
        /// <param name="h">The h.</param>
        /// <param name="k">The k.</param>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/11/calculate-the-formula-for-an-ellipse-selected-by-the-user-in-c/
        /// </acknowledgment>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double a, double b, double c, double d, double e, double f) ConvertEllipseToConicSectionSextic(double h, double k, double a, double b)
        {
            var a2 = a * a;
            var b2 = b * b;
            var h2 = h * h;
            var k2 = k * k;

            var c0 = 1d / a2;
            var c1 = 1d / b2;
            var c2 = 0d;
            var c3 = -2d * h / a2;
            var c4 = -2d * k / b2;
            var c5 = h2 / a2 + k2 / b2 - 1d;
            return (c0, c1, c2, c3, c4, c5);
        }
    }
}
