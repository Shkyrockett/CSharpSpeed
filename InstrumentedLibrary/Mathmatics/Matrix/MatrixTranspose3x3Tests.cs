using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    public static class MatrixTranspose3x3Tests
    {
        /// <summary>
        /// Swap the rows of the matrix with the columns.
        /// </summary>
        /// <returns>A transposed Matrix.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double a, double b, double c,
            double d, double e, double f,
            double g, double h, double i
            ) Transpose(
            double a, double b, double c,
            double d, double e, double f,
            double g, double h, double i)
        {
            return (
                a, d, g,
                b, e, h,
                c, f, i
            );
        }
    }
}
