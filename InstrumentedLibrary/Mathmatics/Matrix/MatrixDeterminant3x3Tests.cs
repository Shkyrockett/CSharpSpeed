using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    public static class MatrixDeterminant3x3Tests
    {
        /// <summary>
        /// Find the determinant of a 3 by 3 matrix.
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
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/onlyuser/Legacy/blob/master/msvb/Dex3d/Math.bas
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Determinant(
            double a, double b, double c,
            double d, double e, double f,
            double g, double h, double i)
        {
            return (a * MatrixDeterminant2x2Tests.Determinant(e, f, h, i))
                - (b * MatrixDeterminant2x2Tests.Determinant(d, f, g, i))
                + (c * MatrixDeterminant2x2Tests.Determinant(d, e, g, h));
        }
    }
}
