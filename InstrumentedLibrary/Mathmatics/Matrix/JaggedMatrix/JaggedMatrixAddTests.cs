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
    //[DisplayName("Add matrix.")]
    //[Description("Adds Two matrices together.")]
    //[SourceCodeLocationProvider]
    public static class JaggedMatrixAddTests
    {
        /// <summary>
        /// Adds the specified augend.
        /// </summary>
        /// <param name="augend">The augend.</param>
        /// <param name="addend">The addend.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double[][] Add(double[][] augend, double[][] addend)
            => Add1(augend, addend);

        /// <summary>
        /// Adds the specified augend.
        /// </summary>
        /// <param name="augend">The augend.</param>
        /// <param name="addend">The addend.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/different-operation-matrices/
        /// </acknowledgment>
        //[DisplayName("Add matrix.")]
        //[Description("Adds Two matrices together.")]
        //[Acknowledgment("https://www.geeksforgeeks.org/different-operation-matrices/")]
        //[SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[][] Add1(double[][] augend, double[][] addend)
        {
            if (augend is null)
            {
                throw new ArgumentNullException(nameof(augend));
            }

            if (addend is null)
            {
                throw new ArgumentNullException(nameof(addend));
            }

            var rows = (augend?.Length).Value;
            var cols = (augend[0]?.Length).Value;

            var result = new double[rows][];
            for (var i = 0; i < rows; i++)
            {
                result[i] = new double[cols];
                for (var j = 0; j < cols; j++)
                {
                    result[i][j] = augend[i][j] + addend[i][j];
                }
            }

            return result;
        }
    }
}
