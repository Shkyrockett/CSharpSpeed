using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class GeneralMatrixSubtractTests
    {
        /// <summary>
        /// Subtracts the specified minuend.
        /// </summary>
        /// <param name="minuend">The minuend.</param>
        /// <param name="subtrahend">The subtrahend.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/different-operation-matrices/
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Subtract(double[,] minuend, double[,] subtrahend)
        {
            if (minuend is null)
            {
                throw new ArgumentNullException(nameof(minuend));
            }

            if (subtrahend is null)
            {
                throw new ArgumentNullException(nameof(subtrahend));
            }

            var rows = minuend.GetLength(0);
            var cols = minuend.GetLength(1);

            var result = new double[rows, cols];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    result[i, j] = minuend[i, j] - subtrahend[i, j];
                }
            }

            return result;
        }
    }
}
