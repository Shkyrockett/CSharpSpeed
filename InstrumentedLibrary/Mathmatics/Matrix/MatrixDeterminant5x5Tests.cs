using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    public static class MatrixDeterminant5x5Tests
    {
        /// <summary>
        /// Find the determinant of a 5 by 5 matrix.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <param name="f"></param>
        /// <param name="g"></param>
        /// <param name="h"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="k"></param>
        /// <param name="l"></param>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="o"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <param name="r"></param>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Determinant(
            double a, double b, double c, double d, double e,
            double f, double g, double h, double i, double j,
            double k, double l, double m, double n, double o,
            double p, double q, double r, double s, double t,
            double u, double v, double w, double x, double y)
        {
            return (a * MatrixDeterminant4x4Tests.Determinant(g, h, i, j, l, m, n, o, q, r, s, t, v, w, x, y))
                - (b * MatrixDeterminant4x4Tests.Determinant(f, h, i, j, k, m, n, o, p, r, s, t, u, w, x, y))
                + (c * MatrixDeterminant4x4Tests.Determinant(f, g, i, j, k, l, n, o, p, q, s, t, u, v, x, y))
                - (d * MatrixDeterminant4x4Tests.Determinant(f, g, h, j, k, l, m, o, p, q, r, t, u, v, w, y))
                + (e * MatrixDeterminant4x4Tests.Determinant(f, g, h, i, k, l, m, n, p, q, r, s, u, v, w, x));
        }
    }
}
