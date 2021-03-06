﻿using CSharpSpeed;
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
    //[DisplayName("Lerp Matrix.")]
    //[Description("Linearly interpolates between two Matrices.")]
    //[SourceCodeLocationProvider]
    public static class GeneralMatrixLerpTests
    {
        /// <summary>
        /// Lerps the specified a.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="amount">The amount.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double[,] Lerp(double[,] a, double[,] b, double amount)
            => Lerp1(a, b, amount);

        /// <summary>
        /// Lerps the specified a.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="amount">The amount.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        //[DisplayName("Lerp Matrix.")]
        //[Description("Linearly interpolates between two Matrices.")]
        //[SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Lerp1(double[,] a, double[,] b, double amount)
        {
            var aRows = a.GetLength(0);
            var bRows = b.GetLength(0);
            var aCols = a.GetLength(1);
            var bCols = b.GetLength(1);
            if (aRows != bRows || aCols != bCols) throw new Exception();

            var results = new double[aRows, bRows];
            for (var i = 0; i < aRows; i++)
            {
                for (var j = 0; j < aCols; j++)
                {
                    results[i, j] = a[i, j] + ((b[i, j] - a[i, j]) * amount);
                }
            }

            return results;
        }
    }
}
