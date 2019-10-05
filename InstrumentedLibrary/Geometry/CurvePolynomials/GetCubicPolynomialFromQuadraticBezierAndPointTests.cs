using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class GetCubicPolynomialFromQuadraticBezierAndPointTests
    {
        /// <summary>
        /// Gets the cubic polynomial from quadratic bezier and point.
        /// </summary>
        /// <param name="aX">a x.</param>
        /// <param name="aY">a y.</param>
        /// <param name="bX">The b x.</param>
        /// <param name="bY">The b y.</param>
        /// <param name="cX">The c x.</param>
        /// <param name="cY">The c y.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://jwezorek.com/2015/01/my-code-for-doing-two-things-that-sooner-or-later-you-will-want-to-do-with-bezier-curves/
        /// </acknowledgment>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double a, double b, double c, double d) GetCubicPolynomialFromQuadraticBezierAndPoint(
            double aX, double aY,
            double bX, double bY,
            double cX, double cY,
            double x, double y)
        {
            var t3 = (2d * aX * aX) - (8d * aX * bX) + (8d * bX * bX) + (4d * aX * cX) - (8d * bX * cX) + (2d * cX * cX) + (2d * aY * aY) - (8d * aY * bY) + (8d * bY * bY) + (4d * aY * cY) - (8d * bY * cY) + (2d * cY * cY);
            var t2 = (-6d * aX * aX) + (18d * aX * bX) - (12d * bX * bX) - (6d * aX * cX) + (6d * bX * cX) - (6d * aY * aY) + (18d * aY * bY) - (12d * bY * bY) - (6d * aY * cY) + (6d * bY * cY);
            var t1 = (-2d * x * aX) + (6d * aX * aX) + (4d * x * bX) - (12d * aX * bX) + (4d * bX * bX) - (2d * x * cX) + (2d * aX * cX) - (2d * y * aY) + (6d * aY * aY) + (4d * y * bY) - (12d * aY * bY) + (4d * bY * bY) - (2d * y * cY) + (2d * aY * cY);
            var t0 = (2d * x * aX) - (2d * aX * aX) - (2d * x * bX) + (2d * aX * bX) + (2d * y * aY) - (2d * aY * aY) - (2d * y * bY) + (2d * aY * bY);

            return t3 == 0 ? (t0, t1, t2, 1d) : (t0 / t3, t1 / t3, t2 / t3, 1d);
        }
    }
}
