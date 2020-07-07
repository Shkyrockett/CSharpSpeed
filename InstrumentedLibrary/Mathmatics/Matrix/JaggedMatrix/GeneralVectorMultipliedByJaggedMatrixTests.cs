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
    //[DisplayName("Multiply Vector by Matrix.")]
    //[Description("Multiplies a Vector by a Matrix.")]
    //[SourceCodeLocationProvider]
    public static class GeneralVectorMultipliedByJaggedMatrixTests
    {
        /// <summary>
        /// Multiplies the specified multiplicand.
        /// </summary>
        /// <param name="multiplicand">The multiplicand.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double[] Multiply(double[] multiplicand, double[][] multiplier)
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
        //[DisplayName("Multiply Vector by Matrix.")]
        //[Description("Multiplies a Vector by a Matrix.")]
        //[Acknowledgment("https://www.geeksforgeeks.org/different-operation-matrices/")]
        //[SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[] Multiply1(double[] multiplicand, double[][] multiplier)
        {
            var multiplicandRows = 1;
            var multiplicandCols = multiplicand.Length;
            var multiplierRows = multiplier.Length;

            if (multiplicandCols != multiplierRows) throw new Exception("Columns of multiplicand must be the same length as the rows of multiplier.");

            var multiplierCols = multiplier[0].Length;

            var result = new double[multiplicandCols];
            for (var i = 0; i < multiplicandRows; i++)
            {
                for (var j = 0; j < multiplierCols; j++)
                {
                    result[j] = 0;
                    for (var k = 0; k < multiplicandCols; k++)
                    {
                        result[j] += multiplicand[i] * multiplier[k][j];
                    }
                }
            }

            return result;
        }
    }
}
