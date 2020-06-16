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
    public static class GeneralTruncateMatrixTests
    {
        /// <summary>
        /// Truncate a matrix
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="rowStart">The row start.</param>
        /// <param name="rowEnd">The row end.</param>
        /// <param name="columnStart">The column start.</param>
        /// <param name="columnEnd">The column end.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L100
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Truncate(double[,] matrix, int rowStart, int rowEnd, int columnStart, int columnEnd)
        {
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            var minimumIndex = rowStart == 0 || rowEnd == 0 || columnStart == 0 || columnEnd == 0;
            var coherenceIndex = rowEnd < rowStart || columnEnd < columnStart;
            var boundIndex = rowEnd > rows || columnEnd > cols;

            if (minimumIndex || coherenceIndex || boundIndex)
            {
                return new double[1, 1];
            }

            var result = new double[rowEnd - rowStart + 1, columnEnd - columnStart + 1];

            for (var i = rowStart - 1; i < rowEnd; i++)
            {
                for (var j = columnStart - 1; j < columnEnd; j++)
                {
                    result[i - rowStart + 1, j - columnStart + 1] = matrix[i, j];
                }
            }

            return result;
        }
    }
}
