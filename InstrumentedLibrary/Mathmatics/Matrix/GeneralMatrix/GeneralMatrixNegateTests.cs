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
    public static class GeneralMatrixNegateTests
    {
        /// <summary>
        /// Applies the plus operator to the specified augend.
        /// </summary>
        /// <param name="augend">The augend.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/different-operation-matrices/
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Negate(double[,] augend)
        {
            var rows = augend.GetLength(0);
            var cols = augend.GetLength(1);

            var result = new double[rows, cols];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    result[i, j] = -augend[i, j];
                }
            }

            return result;
        }
    }
}
