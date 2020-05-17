using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class GeneralMatrixInverseTests
    {
        /// <summary>
        /// Function to calculate the inverse of the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Singular matrix, can't find its inverse</exception>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/adjoint-inverse-matrix/
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Inverse(double[,] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            // Find determinant of [,]A 
            var det = GeneralMatrixDeterminantTests.Determinant(matrix);
            if (det == 0)
            {
                throw new Exception("Singular matrix, can't find its inverse");
            }

            // Find adjoint 
            var adj = GeneralMatrixAdjointTests.Adjoint(matrix);

            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);
            var inverse = new double[rows, cols];

            // Find Inverse using formula "inverse(A) = adj(A)/det(A)" 
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    inverse[i, j] = adj[i, j] / det;
                }
            }

            return inverse;
        }
    }
}
