using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class GeneralMatrixDeterminantTests
    {
        /// <summary>
        /// Recursive function for finding determinant of matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/determinant-of-a-matrix/
        /// https://www.geeksforgeeks.org/adjoint-inverse-matrix/
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Determinant(double[,] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            var rows = matrix.GetLength(0);
            //var cols = matrix.GetLength(1);

            var result = 0d; // Initialize result 

            // Base case : if matrix contains single element 
            if (rows == 1)
                return matrix[0, 0];

            var sign = 1d; // To store sign multiplier 

            // Iterate for each element of first row 
            for (var f = 0; f < rows; f++)
            {
                // Getting Cofactor of A[0,f] 
                var temp = GeneralMatrixSparseCofactorTests.Cofactor(matrix, 0, f);
                result += sign * matrix[0, f] * Determinant(temp);

                // terms are to be added with alternate sign 
                sign = -sign;
            }

            return result;
        }
    }
}
