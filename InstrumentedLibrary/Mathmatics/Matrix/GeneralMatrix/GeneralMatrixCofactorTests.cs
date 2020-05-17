using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class GeneralMatrixCofactorTests
    {
        /// <summary>
        /// Cofactors the specified a.
        /// </summary>
        /// <param name="matrix">a.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/determinant-of-a-matrix/
        /// https://www.geeksforgeeks.org/adjoint-inverse-matrix/
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Cofactor(double[,] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            var i = 0;
            var j = 0;
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);
            var temp = new double[rows, cols];

            // Looping for each element of the matrix 
            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    temp[i, j++] = matrix[row, col];

                    // Row is filled, so increase row index and 
                    // reset col index 
                    if (j == cols - 1)
                    {
                        j = 0;
                        i++;
                    }
                }
            }

            return temp;
        }
    }
}
