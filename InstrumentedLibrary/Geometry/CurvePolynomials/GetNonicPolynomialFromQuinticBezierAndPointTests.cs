using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class GetNonicPolynomialFromQuinticBezierAndPointTests
    {
        /// <summary>
        /// Gets the nonic polynomial from quintic bezier and point.
        /// </summary>
        /// <param name="aX">a x.</param>
        /// <param name="aY">a y.</param>
        /// <param name="bX">The b x.</param>
        /// <param name="bY">The b y.</param>
        /// <param name="cX">The c x.</param>
        /// <param name="cY">The c y.</param>
        /// <param name="dX">The d x.</param>
        /// <param name="dY">The d y.</param>
        /// <param name="eX">The e x.</param>
        /// <param name="fX">The f x.</param>
        /// <param name="fY">The f y.</param>
        /// <param name="eY">The e y.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://jwezorek.com/2015/01/my-code-for-doing-two-things-that-sooner-or-later-you-will-want-to-do-with-bezier-curves/
        /// </acknowledgment>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double a, double b, double c, double d, double e, double f, double g, double h, double i, double j) GetNonicPolynomialFromQuinticBezierAndPoint(double aX, double aY, double bX, double bY, double cX, double cY, double dX, double dY, double eX, double fX, double fY, double eY, double x, double y)
        {
            var t9 = (5 * aX * aX) + (5 * aY * aY) - (50 * aX * bX) + (125 * bX * bX) - (50 * aY * bY) + (125 * bY * bY) + (100 * aX * cX) - (500 * bX * cX) + (500 * cX * cX) + (100 * aY * cY) - (500 * bY * cY) + (500 * cY * cY) - (100 * aX * dX) + (500 * bX * dX) - (1000 * cX * dX) + (500 * dX * dX) - (100 * aY * dY) + (500 * bY * dY) - (1000 * cY * dY) + (500 * dY * dY) + (50 * aX * eX) - (250 * bX * eX) + (500 * cX * eX) - (500 * dX * eX) + (125 * eX * eX) + (50 * aY * eY) - (250 * bY * eY) + (500 * cY * eY) - (500 * dY * eY) + (125 * eY * eY) - (10 * aX * fX) + (50 * bX * fX) - (100 * cX * fX) + (100 * dX * fX) - (50 * eX * fX) + (5 * fX * fX) - (10 * aY * fY) + (50 * bY * fY) - (100 * cY * fY) + (100 * dY * fY) - (50 * eY * fY) + (5 * fY * fY);
            var t8 = (-45 * aX * aX) - (45 * aY * aY) + (405 * aX * bX) - (900 * bX * bX) + (405 * aY * bY) - (900 * bY * bY) - (720 * aX * cX) + (3150 * bX * cX) - (2700 * cX * cX) - (720 * aY * cY) + (3150 * bY * cY) - (2700 * cY * cY) + (630 * aX * dX) - (2700 * bX * dX) + (4500 * cX * dX) - (1800 * dX * dX) + (630 * aY * dY) - (2700 * bY * dY) + (4500 * cY * dY) - (1800 * dY * dY) - (270 * aX * eX) + (1125 * bX * eX) - (1800 * cX * eX) + (1350 * dX * eX) - (225 * eX * eX) - (270 * aY * eY) + (1125 * bY * eY) - (1800 * cY * eY) + (1350 * dY * eY) - (225 * eY * eY) + (45 * aX * fX) - (180 * bX * fX) + (270 * cX * fX) - (180 * dX * fX) + (45 * eX * fX) + (45 * aY * fY) - (180 * bY * fY) + (270 * cY * fY) - (180 * dY * fY) + (45 * eY * fY);
            var t7 = (180 * aX * aX) + (180 * aY * aY) - (1440 * aX * bX) + (2800 * bX * bX) - (1440 * aY * bY) + (2800 * bY * bY) + (2240 * aX * cX) - (8400 * bX * cX) + (6000 * cX * cX) + (2240 * aY * cY) - (8400 * bY * cY) + (6000 * cY * cY) - (1680 * aX * dX) + (6000 * bX * dX) - (8000 * cX * dX) + (2400 * dX * dX) - (1680 * aY * dY) + (6000 * bY * dY) - (8000 * cY * dY) + (2400 * dY * dY) + (600 * aX * eX) - (2000 * bX * eX) + (2400 * cX * eX) - (1200 * dX * eX) + (100 * eX * eX) + (600 * aY * eY) - (2000 * bY * eY) + (2400 * cY * eY) - (1200 * dY * eY) + (100 * eY * eY) - (80 * aX * fX) + (240 * bX * fX) - (240 * cX * fX) + (80 * dX * fX) - (80 * aY * fY) + (240 * bY * fY) - (240 * cY * fY) + (80 * dY * fY);
            var t6 = (-420 * aX * aX) - (420 * aY * aY) + (2940 * aX * bX) - (4900 * bX * bX) + (2940 * aY * bY) - (4900 * bY * bY) - (3920 * aX * cX) + (12250 * bX * cX) - (7000 * cX * cX) - (3920 * aY * cY) + (12250 * bY * cY) - (7000 * cY * cY) + (2450 * aX * dX) - (7000 * bX * dX) + (7000 * cX * dX) - (1400 * dX * dX) + (2450 * aY * dY) - (7000 * bY * dY) + (7000 * cY * dY) - (1400 * dY * dY) - (700 * aX * eX) + (1750 * bX * eX) - (1400 * cX * eX) + (350 * dX * eX) - (700 * aY * eY) + (1750 * bY * eY) - (1400 * cY * eY) + (350 * dY * eY) + (70 * aX * fX) - (140 * bX * fX) + (70 * cX * fX) + (70 * aY * fY) - (140 * bY * fY) + (70 * cY * fY);
            var t5 = (630 * aX * aX) + (630 * aY * aY) - (3780 * aX * bX) + (5250 * bX * bX) - (3780 * aY * bY) + (5250 * bY * bY) + (4200 * aX * cX) - (10500 * bX * cX) + (4500 * cX * cX) + (4200 * aY * cY) - (10500 * bY * cY) + (4500 * cY * cY) - (2100 * aX * dX) + (4500 * bX * dX) - (3000 * cX * dX) + (300 * dX * dX) - (2100 * aY * dY) + (4500 * bY * dY) - (3000 * cY * dY) + (300 * dY * dY) + (450 * aX * eX) - (750 * bX * eX) + (300 * cX * eX) + (450 * aY * eY) - (750 * bY * eY) + (300 * cY * eY) - (30 * aX * fX) + (30 * bX * fX) - (30 * aY * fY) + (30 * bY * fY);
            var t4 = (-630 * aX * aX) - (630 * aY * aY) + (3150 * aX * bX) - (3500 * bX * bX) + (3150 * aY * bY) - (3500 * bY * bY) - (2800 * aX * cX) + (5250 * bX * cX) - (1500 * cX * cX) - (2800 * aY * cY) + (5250 * bY * cY) - (1500 * cY * cY) + (1050 * aX * dX) - (1500 * bX * dX) + (500 * cX * dX) + (1050 * aY * dY) - (1500 * bY * dY) + (500 * cY * dY) - (150 * aX * eX) + (125 * bX * eX) - (150 * aY * eY) + (125 * bY * eY) + (5 * aX * fX) + (5 * aY * fY) + (5 * aX * x) - (25 * bX * x) + (50 * cX * x) - (50 * dX * x) + (25 * eX * x) - (5 * fX * x) + (5 * aY * y) - (25 * bY * y) + (50 * cY * y) - (50 * dY * y) + (25 * eY * y) - (5 * fY * y);
            var t3 = (420 * aX * aX) + (420 * aY * aY) - (1680 * aX * bX) + (1400 * bX * bX) - (1680 * aY * bY) + (1400 * bY * bY) + (1120 * aX * cX) - (1400 * bX * cX) + (200 * cX * cX) + (1120 * aY * cY) - (1400 * bY * cY) + (200 * cY * cY) - (280 * aX * dX) + (200 * bX * dX) - (280 * aY * dY) + (200 * bY * dY) + (20 * aX * eX) + (20 * aY * eY) - (20 * aX * x) + (80 * bX * x) - (120 * cX * x) + (80 * dX * x) - (20 * eX * x) - (20 * aY * y) + (80 * bY * y) - (120 * cY * y) + (80 * dY * y) - (20 * eY * y);
            var t2 = (-180 * aX * aX) - (180 * aY * aY) + (540 * aX * bX) - (300 * bX * bX) + (540 * aY * bY) - (300 * bY * bY) - (240 * aX * cX) + (150 * bX * cX) - (240 * aY * cY) + (150 * bY * cY) + (30 * aX * dX) + (30 * aY * dY) + (30 * aX * x) - (90 * bX * x) + (90 * cX * x) - (30 * dX * x) + (30 * aY * y) - (90 * bY * y) + (90 * cY * y) - (30 * dY * y);
            var t1 = (45 * aX * aX) + (45 * aY * aY) - (90 * aX * bX) + (25 * bX * bX) - (90 * aY * bY) + (25 * bY * bY) + (20 * aX * cX) + (20 * aY * cY) - (20 * aX * x) + (40 * bX * x) - (20 * cX * x) - (20 * aY * y) + (40 * bY * y) - (20 * cY * y);
            var t0 = (-5 * aX * aX) - (5 * aY * aY) + (5 * aX * bX) + (5 * aY * bY) + (5 * aX * x) - (5 * bX * x) + (5 * aY * y) - (5 * bY * y);

            return t9 == 0 ? (t0, t1, t2, t3, t4, t5, t6, t7, t8, 1d) : (t0 / t9, t1 / t9, t2 / t9, t3 / t9, t4 / t9, t5 / t9, t6 / t9, t7 / t9, t8 / t9, 1d);
        }
    }
}
