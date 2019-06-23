using System;
using System.Collections.Generic;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class BisectQuadraticBezierTests
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
        /// <param name="t"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://jwezorek.com/2015/01/my-code-for-doing-two-things-that-sooner-or-later-you-will-want-to-do-with-bezier-curves/
        /// https://developer.roblox.com/articles/Bezier-curves
        /// </acknowledgment>
        public static (QuadraticBezier2D A, QuadraticBezier2D B) BisectQuadraticBezier(double aX, double aY, double bX, double bY, double cX, double cY, double t)
        {
            var (dX, dY) = InterpolateLinear2DTests.LinearInterpolate2D(aX, aY, bX, bY, t);
            var (eX, eY) = InterpolateLinear2DTests.LinearInterpolate2D(bX, bY, cX, cY, t);
            var (fX, fY) = InterpolateLinear2DTests.LinearInterpolate2D(dX, dY, eX, eY, t);

            return (
                new QuadraticBezier2D(aX, aY, dX, dY, fX, fY),
                new QuadraticBezier2D(fX, fY, eX, eY, cX, cY)
            );
        }
    }
}
