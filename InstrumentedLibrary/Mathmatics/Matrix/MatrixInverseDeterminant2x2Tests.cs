using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    public static class MatrixInverseDeterminant2x2Tests
    {
        /// <summary>
        /// Find the inverse of the determinant of a 2 by 2 matrix.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double InverseDeterminant(
            double a, double b,
            double c, double d)
        {
            return 1 / ((a * d)
                    - (b * c));
        }
    }
}
