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
    //[DisplayName("Subtract Matrix.")]
    //[Description("Subtracts one Matrix from another Matrix.")]
    //[SourceCodeLocationProvider]
    public static class JaggedMatrixSubtractTests
    {
        /// <summary>
        /// Subtracts the specified minuend.
        /// </summary>
        /// <param name="minuend">The minuend.</param>
        /// <param name="subtrahend">The subtrahend.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double[][] Subtract(double[][] minuend, double[][] subtrahend)
            => Subtract1(minuend, subtrahend);

        /// <summary>
        /// Subtracts the specified minuend.
        /// </summary>
        /// <param name="minuend">The minuend.</param>
        /// <param name="subtrahend">The subtrahend.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/different-operation-matrices/
        /// </acknowledgment>
        //[DisplayName("Subtract Matrix.")]
        //[Description("Subtracts one Matrix from another Matrix.")]
        //[Acknowledgment("https://www.geeksforgeeks.org/different-operation-matrices/")]
        //[SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[][] Subtract1(double[][] minuend, double[][] subtrahend)
        {
            if (minuend is null)
            {
                throw new ArgumentNullException(nameof(minuend));
            }

            if (subtrahend is null)
            {
                throw new ArgumentNullException(nameof(subtrahend));
            }

            var rows = minuend.Length;
            var cols = minuend[0].Length;

            var result = new double[rows][];
            for (var i = 0; i < rows; i++)
            {
                result[i] = new double[cols];
                for (var j = 0; j < cols; j++)
                {
                    result[i][j] = minuend[i][j] - subtrahend[i][j];
                }
            }

            return result;
        }
    }
}
