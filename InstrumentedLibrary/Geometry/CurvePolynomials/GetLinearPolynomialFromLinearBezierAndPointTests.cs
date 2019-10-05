using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class GetLinearPolynomialFromLinearBezierAndPointTests
    {
        /// <summary>
        /// Gets the linear polynomial from linear bezier and point.
        /// </summary>
        /// <param name="aX">a x.</param>
        /// <param name="aY">a y.</param>
        /// <param name="bX">The b x.</param>
        /// <param name="bY">The b y.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://jwezorek.com/2015/01/my-code-for-doing-two-things-that-sooner-or-later-you-will-want-to-do-with-bezier-curves/
        /// </acknowledgment>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double a, double b) GetLinearPolynomialFromLinearBezierAndPoint(
            double aX, double aY,
            double bX, double bY,
            double x, double y)
        {
            var t1 = (aX * aX) - (2d * aX * bX) + (bX * bX) + (aY * aY) - (2d * aY * bY) + (bY * bY);
            var t0 = (x * aX) - (aX * aX) - (x * bX) + (aX * bX) + (y * aY) - (aY * aY) - (y * bY) + (aY * bY);

            return (t1 == 0 ? t0 : t0 / t1, 1d);
        }
    }
}
