﻿using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    public static class MatrixInverseDeterminant4x4Tests
    {
        /// <summary>
        /// Find the inverse of the determinant of a 4 by 4 matrix.
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
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/onlyuser/Legacy/blob/master/msvb/Dex3d/Math.bas
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double InverseDeterminant(
            double a, double b, double c, double d,
            double e, double f, double g, double h,
            double i, double j, double k, double l,
            double m, double n, double o, double p)
        {
            return 1 / ((a * MatrixDeterminant3x3Tests.Determinant(f, g, h, j, k, l, n, o, p))
                    - (b * MatrixDeterminant3x3Tests.Determinant(e, g, h, i, k, l, m, o, p))
                    + (c * MatrixDeterminant3x3Tests.Determinant(e, f, h, i, j, l, m, n, p))
                    - (d * MatrixDeterminant3x3Tests.Determinant(e, f, g, i, j, k, m, n, o)));
        }
    }
}
