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
    //[DisplayName("Multiply Matrix by Vector.")]
    //[Description("Multiplies a matrix by a Vector.")]
    //[SourceCodeLocationProvider]
    public static class GeneralMatrixMultipliedByGeneralVectorTests
    {
        /// <summary>
        /// Multiplies the specified multiplicand.
        /// </summary>
        /// <param name="multiplicand">The multiplicand.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double[] Multiply(double[,] multiplicand, double[] multiplier)
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
        //[DisplayName("Multiply Matrix by Vector.")]
        //[Description("Multiplies a matrix by a Vector.")]
        //[Acknowledgment("https://www.geeksforgeeks.org/different-operation-matrices/")]
        //[SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[] Multiply1(double[,] multiplicand, double[] multiplier)
        {
            var multiplicandRows = multiplicand.GetLength(0);
            var multiplicandCols = multiplicand.GetLength(1);
            var multiplierRows = multiplier.Length;

            if (multiplicandCols != multiplierRows) throw new Exception("Columns of multiplicand must be the same length as the rows of multiplier.");

            var multiplierCols = multiplier.GetLength(1);

            var result = new double[multiplicandRows];
            for (var i = 0; i < multiplicandRows; i++)
            {
                for (var j = 0; j < multiplierCols; j++)
                {
                    result[i] = 0;
                    for (var k = 0; k < multiplicandCols; k++)
                    {
                        result[i] += multiplicand[i, k] * multiplier[j];
                    }
                }
            }

            return result;
        }
    }
}
