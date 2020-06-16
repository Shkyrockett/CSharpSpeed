using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class GeneralMatrixDotProductTests
    {
        /// <summary>
        /// Dots the product.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DotProduct(double[,] a, double[,] b)
        {
            var rowsA = a?.GetLength(0);
            var colsA = a?.GetLength(1);
            var rowsB = b?.GetLength(0);
            var colsB = b?.GetLength(1);

            if (rowsA != rowsB || colsA != colsB) throw new Exception();

            double result = 0;
            for (var i = 0; i < rowsA; i++)
            {
                for (var j = 0; j < colsA; j++)
                {
                    result += a[i, j] * b[i, j];
                }
            }

            return result;
        }
    }
}
