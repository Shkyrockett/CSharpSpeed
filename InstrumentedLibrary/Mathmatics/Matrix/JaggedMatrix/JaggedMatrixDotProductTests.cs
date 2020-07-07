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
    //[DisplayName("Dot product of Matrix.")]
    //[Description("Finds the dot product of a Matrix.")]
    //[SourceCodeLocationProvider]
    public static class JaggedMatrixDotProductTests
    {
        /// <summary>
        /// Dots the product.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double DotProduct(double[][] a, double[][] b)
            => DotProduct1(a, b);

        /// <summary>
        /// Dots the product.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        //[DisplayName("Dot product of Matrix.")]
        //[Description("Finds the dot product of a Matrix.")]
        //[SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DotProduct1(double[][] a, double[][] b)
        {
            var rowsA = a?.Length;
            var colsA = a[0]?.Length;
            var rowsB = b?.Length;
            var colsB = b[0]?.Length;

            if (rowsA != rowsB || colsA != colsB) throw new Exception();

            double result = 0;
            for (var i = 0; i < rowsA; i++)
            {
                for (var j = 0; j < colsA; j++)
                {
                    result += a[i][j] * b[i][j];
                }
            }

            return result;
        }
    }
}
