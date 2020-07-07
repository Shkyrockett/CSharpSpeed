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
    //[DisplayName("Multiply Matrix.")]
    //[Description("Multiplies two matrices.")]
    //[SourceCodeLocationProvider]
    public static class JaggedMatrixMultiplyTests
    {
        /// <summary>
        /// Multiplies the specified multiplicand.
        /// </summary>
        /// <param name="multiplicand">The multiplicand.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double[][] Multiply(double[][] multiplicand, double[][] multiplier)
            => Multiply1(multiplicand, multiplier);

        /// <summary>
        /// Multiplies the specified multiplicand.
        /// </summary>
        /// <param name="multiplicand">The multiplicand.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Columns of multiplicand must be the same length as the rows of multiplier.</exception>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/different-operation-matrices/
        /// </acknowledgment>
        //[DisplayName("Multiply Matrix.")]
        //[Description("Multiplies two matrices.")]
        //[Acknowledgment("https://www.geeksforgeeks.org/different-operation-matrices/")]
        //[SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[][] Multiply1(double[][] multiplicand, double[][] multiplier)
        {
            if (multiplicand is null)
            {
                throw new ArgumentNullException(nameof(multiplicand));
            }

            if (multiplier is null)
            {
                throw new ArgumentNullException(nameof(multiplier));
            }

            var multiplicandRows = multiplicand.Length;
            var multiplicandCols = multiplicand[0].Length;
            var multiplierRows = multiplier.Length;

            if (multiplicandCols != multiplierRows) throw new Exception("Columns of multiplicand must be the same length as the rows of multiplier.");

            var multiplierCols = multiplier[0].Length;

            var result = new double[multiplicandRows][];
            for (var i = 0; i < multiplicandRows; i++)
            {
                result[i] = new double[multiplicandCols];
                for (var j = 0; j < multiplierCols; j++)
                {
                    result[i][j] = 0;
                    for (var k = 0; k < multiplicandCols; k++)
                    {
                        result[i][j] += multiplicand[i][j] * multiplier[i][j];
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Multiplies the specified multiplicand.
        /// </summary>
        /// <param name="multiplicand">The multiplicand.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Columns of multiplicand must be the same length as the rows of multiplier.</exception>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/different-operation-matrices/
        /// </acknowledgment>
        //[DisplayName("Multiply Matrix.")]
        //[Description("Multiplies two matrices.")]
        //[Acknowledgment("https://www.geeksforgeeks.org/different-operation-matrices/")]
        //[SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[][] Multiply2(double[][] multiplicand, double[][] multiplier)
        {
            var multiplicandRows = multiplicand.Length;
            var multiplicandCols = multiplicand[0].Length;
            var multiplierRows = multiplier.Length;

            if (multiplicandCols != multiplierRows) throw new Exception("Columns of multiplicand must be the same length as the rows of multiplier.");

            var multiplierCols = multiplier[0].Length;

            var result = new double[multiplicandRows][];
            for (var i = 0; i < multiplicandRows; i++)
            {
                result[i] = new double[multiplierCols];
                for (var j = 0; j < multiplierCols; j++)
                {
                    result[i][j] = 0;
                    for (var k = 0; k < multiplicandCols; k++)
                    {
                        result[i][j] += multiplicand[i][k] * multiplier[k][j];
                    }
                }
            }

            return result;
        }
    }
}
