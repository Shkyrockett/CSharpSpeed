using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class GeneralMatrixAdjointTests
    {
        /// <summary>
        /// Function to get adjoint of the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/adjoint-inverse-matrix/
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Adjoint(double[,] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            if (rows == 1)
            {
                return new double[1, 1] { { 1d } };
            }

            var adj = new double[rows, cols];

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    // Get cofactor of A[i,j] 
                    var temp = GeneralMatrixSparseCofactorTests.Cofactor(matrix, i, j);

                    // Sign of adj[j,i] positive if sum of row and column indexes is even. 
                    var sign = ((i + j) % 2d == 0d) ? 1d : -1d;

                    // Interchanging rows and columns to get the  transpose of the cofactor matrix 
                    adj[j, i] = sign * GeneralMatrixDeterminantTests.Determinant(temp);
                }
            }

            return adj;
        }
    }
}
