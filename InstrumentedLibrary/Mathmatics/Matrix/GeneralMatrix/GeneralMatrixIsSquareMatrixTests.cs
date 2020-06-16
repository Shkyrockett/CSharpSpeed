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
    public static class GeneralMatrixIsSquareMatrixTests
    {
        /// <summary>
        /// Check if a matrix is has the same number of rows as columns.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>
        ///   <see langword="true" /> if [is square matrix] [the specified matrix]; otherwise, <see langword="false" />.
        /// </returns>
        /// <acknowledgment>
        /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L173
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSquareMatrix(double[,] matrix)
        {
            var rows = matrix?.GetLength(0);
            var cols = matrix?.GetLength(1);
            return rows == cols;
        }
    }
}
