using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class GetQuinticPolynomialFromCubicBezierAndPointTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <param name="dX"></param>
        /// <param name="dY"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://jwezorek.com/2015/01/my-code-for-doing-two-things-that-sooner-or-later-you-will-want-to-do-with-bezier-curves/
        /// </acknowledgment>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double a, double b, double c, double d, double e, double f) GetQuinticPolynomialFromCubicBezierAndPoint(
            double aX, double aY,
            double bX, double bY,
            double cX, double cY,
            double dX, double dY,
            double x, double y)
        {
            var t5 = (3d * aX * aX) - (18d * aX * bX) + (27d * bX * bX) + (18d * aX * cX) - (54d * bX * cX) + (27d * cX * cX) - (6d * aX * dX) + (18d * bX * dX) - (18d * cX * dX) + (3d * dX * dX) + (3d * aY * aY) - (18d * aY * bY) + (27d * bY * bY) + (18d * aY * cY) - (54d * bY * cY) + (27d * cY * cY) - (6d * aY * dY) + (18d * bY * dY) - (18d * cY * dY) + (3d * dY * dY);
            var t4 = (-15d * aX * aX) + (75d * aX * bX) - (90d * bX * bX) - (60d * aX * cX) + (135d * bX * cX) - (45d * cX * cX) + (15d * aX * dX) - (30d * bX * dX) + (15d * cX * dX) - (15d * aY * aY) + (75d * aY * bY) - (90d * bY * bY) - (60d * aY * cY) + (135d * bY * cY) - (45d * cY * cY) + (15d * aY * dY) - (30d * bY * dY) + (15d * cY * dY);
            var t3 = (30d * aX * aX) - (120d * aX * bX) + (108d * bX * bX) + (72d * aX * cX) - (108d * bX * cX) + (18d * cX * cX) - (12d * aX * dX) + (12d * bX * dX) + (30d * aY * aY) - (120d * aY * bY) + (108d * bY * bY) + (72d * aY * cY) - (108d * bY * cY) + (18d * cY * cY) - (12d * aY * dY) + (12d * bY * dY);
            var t2 = (3d * x * aX) - (30d * aX * aX) - (9d * x * bX) + (90d * aX * bX) - (54d * bX * bX) + (9d * x * cX) - (36d * aX * cX) + (27d * bX * cX) - (3d * x * dX) + (3d * aX * dX) + (3d * y * aY) - (30d * aY * aY) - (9d * y * bY) + (90d * aY * bY) - (54d * bY * bY) + (9d * y * cY) - (36d * aY * cY) + (27d * bY * cY) - (3d * y * dY) + (3d * aY * dY);
            var t1 = (-6d * x * aX) + (15d * aX * aX) + (12d * x * bX) - (30d * aX * bX) + (9d * bX * bX) - (6d * x * cX) + (6d * aX * cX) - (6d * y * aY) + (15d * aY * aY) + (12d * y * bY) - (30d * aY * bY) + (9d * bY * bY) - (6d * y * cY) + (6d * aY * cY);
            var t0 = (3d * x * aX) - (3d * aX * aX) - (3d * x * bX) + (3d * aX * bX) + (3d * y * aY) - (3d * aY * aY) - (3d * y * bY) + (3d * aY * bY);

            return (t0 / t5, t1 / t5, t2 / t5, t3 / t5, t4 / t5, 1d);
        }
    }
}
