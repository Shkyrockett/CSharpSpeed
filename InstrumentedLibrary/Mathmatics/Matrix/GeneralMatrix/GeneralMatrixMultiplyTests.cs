using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class GeneralMatrixMultiplyTests
    {
        /// <summary>
        /// Multiplies the specified multiplicand.
        /// </summary>
        /// <param name="multiplicand">The multiplicand.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Columns of multiplicand must be the same length as the rows of multiplier.</exception>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/different-operation-matrices/
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Multiply(double[,] multiplicand, double[,] multiplier)
        {
            if (multiplicand is null)
            {
                throw new ArgumentNullException(nameof(multiplicand));
            }

            if (multiplier is null)
            {
                throw new ArgumentNullException(nameof(multiplier));
            }

            var multiplicandRows = multiplicand.GetLength(0);
            var multiplicandCols = multiplicand.GetLength(1);
            var multiplierRows = multiplier.GetLength(0);

            if (multiplicandCols != multiplierRows) throw new Exception("Columns of multiplicand must be the same length as the rows of multiplier.");

            var multiplierCols = multiplier.GetLength(1);

            var result = new double[multiplicandRows, multiplicandCols];
            for (var i = 0; i < multiplicandRows; i++)
            {
                for (var j = 0; j < multiplierCols; j++)
                {
                    result[i, j] = 0;
                    for (var k = 0; k < multiplicandCols; k++)
                    {
                        result[i, j] += multiplicand[i, j] * multiplier[i, j];
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Multiplies the specified multiplicand.
        /// </summary>
        /// <param name="multiplicand">The multiplicand.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Columns of multiplicand must be the same length as the rows of multiplier.</exception>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/different-operation-matrices/
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Multiply2(double[,] multiplicand, double[,] multiplier)
        {
            var multiplicandRows = multiplicand.GetLength(0);
            var multiplicandCols = multiplicand.GetLength(1);
            var multiplierRows = multiplier.GetLength(0);

            if (multiplicandCols != multiplierRows) throw new Exception("Columns of multiplicand must be the same length as the rows of multiplier.");

            var multiplierCols = multiplier.GetLength(1);

            var result = new double[multiplicandRows, multiplierCols];
            for (var i = 0; i < multiplicandRows; i++)
            {
                for (var j = 0; j < multiplierCols; j++)
                {
                    result[i, j] = 0;
                    for (var k = 0; k < multiplicandCols; k++)
                    {
                        result[i, j] += multiplicand[i, k] * multiplier[k, j];
                    }
                }
            }

            return result;
        }
    }
}
