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
    public static class GeneralVectorMultipliedByGeneralMatrixTests
    {
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
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[] Multiply(double[] multiplicand, double[,] multiplier)
        {
            var multiplicandRows = 1;
            var multiplicandCols = multiplicand.Length;
            var multiplierRows = multiplier.GetLength(0);

            if (multiplicandCols != multiplierRows) throw new Exception("Columns of multiplicand must be the same length as the rows of multiplier.");

            var multiplierCols = multiplier.GetLength(1);

            var result = new double[multiplicandCols];
            for (var i = 0; i < multiplicandRows; i++)
            {
                for (var j = 0; j < multiplierCols; j++)
                {
                    result[j] = 0;
                    for (var k = 0; k < multiplicandCols; k++)
                    {
                        result[j] += multiplicand[i] * multiplier[k, j];
                    }
                }
            }

            return result;
        }
    }
}
