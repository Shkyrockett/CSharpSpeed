using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class GeneralMatrixAddTests
    {
        /// <summary>
        /// Adds the specified augend.
        /// </summary>
        /// <param name="augend">The augend.</param>
        /// <param name="addend">The addend.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/different-operation-matrices/
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Add(double[,] augend, double[,] addend)
        {
            if (augend is null)
            {
                throw new ArgumentNullException(nameof(augend));
            }

            if (addend is null)
            {
                throw new ArgumentNullException(nameof(addend));
            }

            var rows = augend.GetLength(0);
            var cols = augend.GetLength(1);

            var result = new double[rows, cols];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    result[i, j] = augend[i, j] + addend[i, j];
                }
            }

            return result;
        }
    }
}
