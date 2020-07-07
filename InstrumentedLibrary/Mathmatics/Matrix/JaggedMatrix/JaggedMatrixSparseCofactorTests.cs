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
    public static class JaggedMatrixSparseCofactorTests
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
        public static double[][] Cofactor(double[][] matrix, int p, int q)
            => Cofactor1(matrix, p, q);

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
        //[DisplayName("Cofactor Matrix.")]
        //[Description("Finds the Cofactor of a Matrix.")]
        //[Acknowledgment("https://www.geeksforgeeks.org/determinant-of-a-matrix/", "https://www.geeksforgeeks.org/adjoint-inverse-matrix/")]
        //[SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[][] Cofactor1(double[][] matrix, int p, int q)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            var i = 0;
            var j = 0;
            var rows = matrix.Length;
            var cols = matrix[0].Length;
            var temp = new double[rows][];

            // Looping for each element of the matrix 
            for (var row = 0; row < rows; row++)
            {
                temp[row] = new double[cols];
                for (var col = 0; col < cols; col++)
                {
                    // Copying into temporary matrix only those element 
                    // which are not in given row and column 
                    if (row != p && col != q)
                    {
                        temp[i][j++] = matrix[row][col];

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
