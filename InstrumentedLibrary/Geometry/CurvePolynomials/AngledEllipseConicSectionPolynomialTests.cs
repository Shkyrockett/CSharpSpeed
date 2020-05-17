using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class AngledEllipseConicSectionPolynomialTests
    {
        /// <summary>
        /// Converts the ellipse to conic section sextic.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="h">The h.</param>
        /// <param name="k">The k.</param>
        /// <param name="theta">The theta.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://math.stackexchange.com/a/2989928
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double a, double b, double c, double d, double e, double f) ConvertEllipseToConicSectionSextic(double a, double b, double h, double k, double theta)
            => RotatedEllipseConicSectionPolynomialTests.ConvertEllipseToConicSectionSextic(a, b, h, k, Cos(theta), Sin(theta));
    }
}
