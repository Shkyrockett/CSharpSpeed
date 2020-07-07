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
    //[DisplayName("Cofactor Matrix.")]
    //[Description("Finds the Cofactor of a Matrix.")]
    //[SourceCodeLocationProvider]
    public static class GeneralMatrixSparseCofactorCellTests
    {
        /// <summary>
        /// Cofactors the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="p">The p.</param>
        /// <param name="q">The q.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double CoFactor(double[,] matrix, int p, int q)
            => CoFactor1(matrix, p, q);

        /// <summary>
        /// The co-factor is the determinant of the matrix that remains when the row and column containing the
        /// specified element is removed. The co-factor may also be multiplied by -1, depending on the element's position:
        /// + - + -
        /// - + - +
        /// + - + -
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="col">column number (starting at 0)</param>
        /// <param name="row">row number (starting at 0)</param>
        /// <returns>
        /// The cofactor of the specified element
        /// </returns>
        /// <exception cref="InvalidOperationException">Matrix must have the same number of rows and columns for the co-factor to be calculated</exception>
        public static double CoFactor1(double[,] matrix, int col, int row)
        {
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);
            if (cols != rows)
            {
                throw new InvalidOperationException("Matrix must have the same number of rows and columns for the co-factor to be calculated");
            }
            var array = GeneralGetMatrixMinorTests.GetMinor(matrix, col, row);
            var cofactor = GeneralMatrixDeterminantTests.Determinant(array);
            // need to work out sign:
            var i = col - row;
            if ((i % 2) != 0)
            {
                cofactor = -cofactor;
            }

            return cofactor;
        }
    }
}
