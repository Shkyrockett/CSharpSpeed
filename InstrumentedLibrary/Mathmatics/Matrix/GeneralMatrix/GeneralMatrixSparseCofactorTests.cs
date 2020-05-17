using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class GeneralMatrixSparseCofactorTests
    {
        /// <summary>
        /// Cofactors the specified a.
        /// </summary>
        /// <param name="matrix">a.</param>
        /// <param name="p">The p.</param>
        /// <param name="q">The q.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/determinant-of-a-matrix/
        /// https://www.geeksforgeeks.org/adjoint-inverse-matrix/
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Cofactor(double[,] matrix, int p, int q)
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
                    // Copying into temporary matrix only those element 
                    // which are not in given row and column 
                    if (row != p && col != q)
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
            }

            return temp;
        }
    }
}
