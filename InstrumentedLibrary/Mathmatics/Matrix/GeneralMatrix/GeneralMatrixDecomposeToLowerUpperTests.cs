using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentedLibrary
{
    public static class GeneralMatrixDecomposeToLowerUpperTests
    {
        /// <summary>
        /// Compute LU decomposition on a squared matrix
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L219
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double[,] Lower, double[,] Upper) DecomposeToLowerUpper(double[,] matrix)
        {
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            if (!GeneralMatrixIsSquareMatrixTests.IsSquareMatrix(matrix))
            {
                return (new double[1, 1], new double[1, 1]);
            }
            else
            {
                var lower = new double[rows, cols];
                var upper = new double[rows, cols];

                for (var i = 0; i < rows; i++)
                {
                    lower[i, i] = 1;
                }

                for (var i = 0; i < rows; i++)
                {
                    for (var j = i; j < rows; j++)
                    {
                        var sumU = 0d;
                        for (var k = 0; k < i; k++)
                        {
                            sumU += lower[i, k] * upper[k, j];
                        }

                        upper[i, j] = matrix[i, j] - sumU;
                    }

                    for (var j = i; j < rows; j++)
                    {
                        var sumL = 0d;
                        for (var k = 0; k < i; k++)
                        {
                            sumL += lower[j, k] * upper[k, i];
                        }

                        lower[j, i] = (matrix[j, i] - sumL) / upper[i, i];
                    }
                }

                return (lower, upper);
            }
        }
    }
}
