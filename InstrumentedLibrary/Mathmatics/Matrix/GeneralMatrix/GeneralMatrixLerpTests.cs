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
    public static class GeneralMatrixLerpTests
    {
        /// <summary>
        /// Lerps the specified a.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="amount">The amount.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Lerp(double[,] a, double[,] b, double amount)
        {
            var aRows = a.GetLength(0);
            var bRows = b.GetLength(0);
            var aCols = a.GetLength(1);
            var bCols = b.GetLength(1);
            if (aRows != bRows || aCols != bCols) throw new Exception();

            var results = new double[aRows, bRows];
            for (var i = 0; i < aRows; i++)
            {
                for (var j = 0; j < aCols; j++)
                {
                    results[i, j] = a[i, j] + ((b[i, j] - a[i, j]) * amount);
                }
            }

            return results;
        }
    }
}
