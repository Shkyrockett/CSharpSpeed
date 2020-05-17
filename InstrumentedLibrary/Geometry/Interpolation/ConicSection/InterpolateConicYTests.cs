using System;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class InterpolateConicYTests
    {
        /// <summary>
        /// Calculate G1(x).
        /// root_sign is -1 or 1.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <param name="e">The e.</param>
        /// <param name="f">The f.</param>
        /// <param name="rootSign">The root sign.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/11/draw-a-conic-section-from-its-polynomial-equation-in-c/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double G(double x, double a, double b, double c, double d, double e, double f, int rootSign)
        {
            var result = b * x + e;
            result *= result;
            result -= 4d * c * (a * x * x + d * x + f);
            result = rootSign * Math.Sqrt(result);
            result = -(b * x + e) + result;
            result = result / 2d / c;
            return result;
        }

        /// <summary>
        /// Calculate G1'(x).
        /// root_sign is -1 or 1.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <param name="e">The e.</param>
        /// <param name="f">The f.</param>
        /// <param name="rootSign">The root sign.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/11/draw-a-conic-section-from-its-polynomial-equation-in-c/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GPrime(double x, double a, double b, double c, double d, double e, double f, int rootSign)
        {
            var numerator = 2d * (b * x + e) * b - 4d * c * (2d * a * x + d);
            var denominator = 2f * (float)Math.Sqrt((b * x + e) * (b * x + e) - 4d * c * (a * x * x + d * x + f));
            var result = -b + rootSign * numerator / denominator;
            result = result / 2d / c;

            return result;
        }
    }
}
