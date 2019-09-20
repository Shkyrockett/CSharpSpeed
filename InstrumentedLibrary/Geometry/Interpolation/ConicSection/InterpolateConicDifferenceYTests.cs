using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class InterpolateConicDifferenceYTests
    {
        /// <summary>
        /// Calculate G(x).
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="a1">The a1.</param>
        /// <param name="b1">The b1.</param>
        /// <param name="c1">The c1.</param>
        /// <param name="d1">The d1.</param>
        /// <param name="e1">The e1.</param>
        /// <param name="f1">The f1.</param>
        /// <param name="sign1">The sign1.</param>
        /// <param name="a2">The a2.</param>
        /// <param name="b2">The b2.</param>
        /// <param name="c2">The c2.</param>
        /// <param name="d2">The d2.</param>
        /// <param name="e2">The e2.</param>
        /// <param name="f2">The f2.</param>
        /// <param name="sign2">The sign2.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/11/draw-a-conic-section-from-its-polynomial-equation-in-c/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double InterpolateConicDifferenceY(double x,
            double a1, double b1, double c1, double d1, double e1, double f1, int sign1,
            double a2, double b2, double c2, double d2, double e2, double f2, int sign2)
        {
            return InterpolateConicYTests.G(x, a1, b1, c1, d1, e1, f1, sign1) - InterpolateConicYTests.G(x, a2, b2, c2, d2, e2, f2, sign2);
        }

        /// <summary>
        /// Calculate G'(x).
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="a1">The a1.</param>
        /// <param name="b1">The b1.</param>
        /// <param name="c1">The c1.</param>
        /// <param name="d1">The d1.</param>
        /// <param name="e1">The e1.</param>
        /// <param name="f1">The f1.</param>
        /// <param name="sign1">The sign1.</param>
        /// <param name="a2">The a2.</param>
        /// <param name="b2">The b2.</param>
        /// <param name="c2">The c2.</param>
        /// <param name="d2">The d2.</param>
        /// <param name="e2">The e2.</param>
        /// <param name="f2">The f2.</param>
        /// <param name="sign2">The sign2.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/11/draw-a-conic-section-from-its-polynomial-equation-in-c/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double InterpolateConicDifferencePrimeY(double x,
            double a1, double b1, double c1, double d1, double e1, double f1, int sign1,
            double a2, double b2, double c2, double d2, double e2, double f2, int sign2)
        {
            return InterpolateConicYTests.GPrime(x, a1, b1, c1, d1, e1, f1, sign1) - InterpolateConicYTests.GPrime(x, a2, b2, c2, d2, e2, f2, sign2);
        }
    }
}
