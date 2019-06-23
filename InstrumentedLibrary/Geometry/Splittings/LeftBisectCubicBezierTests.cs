using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class LeftBisectCubicBezierTests
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
        /// <param name="t"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://jwezorek.com/2015/01/my-code-for-doing-two-things-that-sooner-or-later-you-will-want-to-do-with-bezier-curves/
        /// </acknowledgment>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CubicBezier2D LeftBisectCubicBezier(double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY, double t)
        {
            var (eX, eY) = InterpolateLinear2DTests.LinearInterpolate2D(aX, aY, bX, bY, t);
            var (fX, fY) = InterpolateLinear2DTests.LinearInterpolate2D(bX, bY, cX, cY, t);
            var (gX, gY) = InterpolateLinear2DTests.LinearInterpolate2D(cX, cY, dX, dY, t);
            var (hX, hY) = InterpolateLinear2DTests.LinearInterpolate2D(eX, eY, fX, fY, t);
            var (jX, jY) = InterpolateLinear2DTests.LinearInterpolate2D(fX, fY, gX, gY, t);
            var (kX, kY) = InterpolateLinear2DTests.LinearInterpolate2D(hX, hY, jX, jY, t);

            return (aX, aY, eX, eY, hX, hY, kX, kY);
        }
    }
}
