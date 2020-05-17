using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class GetSepticPolynomialFromQuarticBezierAndPointTests
    {
        /// <summary>
        /// Gets the quintic polynomial from cubic bezier and point.
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
        /// <param name="eY">The e y.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://jwezorek.com/2015/01/my-code-for-doing-two-things-that-sooner-or-later-you-will-want-to-do-with-bezier-curves/
        /// </acknowledgment>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double a, double b, double c, double d, double e, double f, double g, double h) GetSepticPolynomialFromQuarticBezierAndPoint(
            double aX, double aY,
            double bX, double bY,
            double cX, double cY,
            double dX, double dY,
            double eX, double eY,
            double x, double y)
        {
            var t7 = (4d * aX * aX) - (32d * aX * bX) + (64d * bX * bX) + (48d * aX * cX) - (192d * bX * cX) + (144d * cX * cX) - (32d * aX * dX) + (128d * bX * dX) - (192d * cX * dX) + (64d * dX * dX) + (8d * aX * eX) - (32d * bX * eX) + (48d * cX * eX) - (32d * dX * eX) + (4d * eX * eX) + (4d * aY * aY) - (32 * aY * bY) + (64d * bY * bY) + (48d * aY * cY) - (192d * bY * cY) + (144d * cY * cY) - (32d * aY * dY) + (128d * bY * dY) - (192d * cY * dY) + (64d * dY * dY) + (8d * aY * eY) - (32d * bY * eY) + (48d * cY * eY) - (32d * dY * eY) + (4d * eY * eY);
            var t6 = (-28d * aX * aX) + (196d * aX * bX) - (336d * bX * bX) - (252d * aX * cX) + (840d * bX * cX) - (504d * cX * cX) + (140d * aX * dX) - (448d * bX * dX) + (504d * cX * dX) - (112d * dX * dX) - (28d * aX * eX) + (84d * bX * eX) - (84d * cX * eX) + (28d * dX * eX) - (28d * aY * aY) + (196d * aY * bY) - (336d * bY * bY) - (252d * aY * cY) + (840d * bY * cY) - (504d * cY * cY) + (140d * aY * dY) - (448d * bY * dY) + (504d * cY * dY) - (112d * dY * dY) - (28d * aY * eY) + (84d * bY * eY) - (84d * cY * eY) + (28d * dY * eY);
            var t5 = (84d * aX * aX) - (504d * aX * bX) + (720d * bX * bX) + (540d * aX * cX) - (1440d * bX * cX) + (648d * cX * cX) - (240d * aX * dX) + (576d * bX * dX) - (432d * cX * dX) + (48d * dX * dX) + (36d * aX * eX) - (72d * bX * eX) + (36d * cX * eX) + (84d * aY * aY) - (504d * aY * bY) + (720d * bY * bY) + (540d * aY * cY) - (1440d * bY * cY) + (648d * cY * cY) - (240d * aY * dY) + (576d * bY * dY) - (432d * cY * dY) + (48d * dY * dY) + (36d * aY * eY) - (72d * bY * eY) + (36d * cY * eY);
            var t4 = (-140d * aX * aX) + (700d * aX * bX) - (800d * bX * bX) - (600d * aX * cX) + (1200d * bX * cX) - (360d * cX * cX) + (200d * aX * dX) - (320d * bX * dX) + (120d * cX * dX) - (20d * aX * eX) + (20d * bX * eX) - (140d * aY * aY) + (700d * aY * bY) - (800d * bY * bY) - (600d * aY * cY) + (1200d * bY * cY) - (360d * cY * cY) + (200d * aY * dY) - (320d * bY * dY) + (120d * cY * dY) - (20d * aY * eY) + (20d * bY * eY);
            var t3 = (-4d * x * aX) + (140d * aX * aX) + (16d * x * bX) - (560d * aX * bX) + (480d * bX * bX) - (24d * x * cX) + (360d * aX * cX) - (480d * bX * cX) + (72d * cX * cX) + (16d * x * dX) - (80d * aX * dX) + (64d * bX * dX) - (4d * x * eX) + (4d * aX * eX) - (4d * y * aY) + (140d * aY * aY) + (16d * y * bY) - (560d * aY * bY) + (480d * bY * bY) - (24d * y * cY) + (360d * aY * cY) - (480d * bY * cY) + (72d * cY * cY) + (16d * y * dY) - (80d * aY * dY) + (64d * bY * dY) - (4d * y * eY) + (4d * aY * eY);
            var t2 = (12d * x * aX) - (84d * aX * aX) - (36d * x * bX) + (252d * aX * bX) - (144d * bX * bX) + (36d * x * cX) - (108d * aX * cX) + (72d * bX * cX) - (12d * x * dX) + (12d * aX * dX) + (12d * y * aY) - (84d * aY * aY) - (36d * y * bY) + (252d * aY * bY) - (144d * bY * bY) + (36d * y * cY) - (108d * aY * cY) + (72d * bY * cY) - (12d * y * dY) + (12d * aY * dY);
            var t1 = (-12d * x * aX) + (28d * aX * aX) + (24d * x * bX) - (56d * aX * bX) + (16d * bX * bX) - (12d * x * cX) + (12d * aX * cX) - (12d * y * aY) + (28d * aY * aY) + (24d * y * bY) - (56d * aY * bY) + (16d * bY * bY) - (12d * y * cY) + (12d * aY * cY);
            var t0 = (4d * x * aX) - (4d * aX * aX) - (4d * x * bX) + (4d * aX * bX) + (4d * y * aY) - (4d * aY * aY) - (4d * y * bY) + (4d * aY * bY);

            return t7 == 0 ? (t0, t1, t2, t3, t4, t5, t6, 1d) : (t0 / t7, t1 / t7, t2 / t7, t3 / t7, t4 / t7, t5 / t7, t6 / t7, 1d);
        }
    }
}
