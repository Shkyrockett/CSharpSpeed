using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class GeneralMatrixIsIdentityTests
    {
        /// <summary>
        /// Determines whether the specified matrix is identity.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>
        ///   <c>true</c> if the specified matrix is identity; otherwise, <c>false</c>.
        /// </returns>
        /// <acknowledgment>
        /// https://www.tutorialgateway.org/c-program-to-check-matrix-is-an-identity-matrix/
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsIdentity(double[,] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    if (matrix[i, j] != 1 && matrix[j, i] != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
