using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    //[DisplayName("Truncate Matrix.")]
    //[Description("Truncates a Matrix.")]
    //[SourceCodeLocationProvider]
    public static class JaggedTruncateMatrixTests
    {
        /// <summary>
        /// Truncates the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="rowStart">The row start.</param>
        /// <param name="rowEnd">The row end.</param>
        /// <param name="columnStart">The column start.</param>
        /// <param name="columnEnd">The column end.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double[][] Truncate(double[][] matrix, int rowStart, int rowEnd, int columnStart, int columnEnd)
            => Truncate1(matrix, rowStart, rowEnd, columnStart, columnEnd);

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
        //[DisplayName("Truncate Matrix.")]
        //[Description("Truncates a Matrix.")]
        //[Acknowledgment("https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L100")]
        //[SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[][] Truncate1(double[][] matrix, int rowStart, int rowEnd, int columnStart, int columnEnd)
        {
            var rows = matrix.Length;
            var cols = matrix[0].Length;

            var minimumIndex = rowStart == 0 || rowEnd == 0 || columnStart == 0 || columnEnd == 0;
            var coherenceIndex = rowEnd < rowStart || columnEnd < columnStart;
            var boundIndex = rowEnd > rows || columnEnd > cols;

            if (minimumIndex || coherenceIndex || boundIndex)
            {
                return new double[1][] { new double[1] };
            }

            var result = new double[rowEnd - rowStart + 1][];

            for (var i = rowStart - 1; i < rowEnd; i++)
            {
                result[i] = new double[columnEnd - columnStart + 1];
                for (var j = columnStart - 1; j < columnEnd; j++)
                {
                    result[i - rowStart + 1][j - columnStart + 1] = matrix[i][j];
                }
            }

            return result;
        }
    }
}
