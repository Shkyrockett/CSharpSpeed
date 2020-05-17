using System.Diagnostics;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class EllipseConicSectionPolynomialAngleTests
    {

        /// <summary>
        /// Calculates a conic section polynomial that represents the provided angled ellipse.
        /// </summary>
        /// <param name="h">The center X coordinate.</param>
        /// <param name="k">The center Y coordinate.</param>
        /// <param name="a">The width of the ellipse.</param>
        /// <param name="b">The angle of the ellipse in pi radians.</param>
        /// <param name="angle">The angle.</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double a, double b, double c, double d, double e, double f) EllipseConicSectionPolynomial(double h, double k, double a, double b, double angle) => EllipseConicSectionPolynomialTests.EllipseConicSectionPolynomial(h, k, a, b, Cos(angle), Sin(angle));
    }
}
