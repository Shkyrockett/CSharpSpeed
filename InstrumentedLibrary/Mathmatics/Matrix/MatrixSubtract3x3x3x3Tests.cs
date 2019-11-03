using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class MatrixSubtract3x3x3x3Tests
    {
        /// <summary>
        /// Used to subtract two matrices.
        /// </summary>
        /// <param name="minuendM0x0"></param>
        /// <param name="minuendM0x1"></param>
        /// <param name="minuendM0x2"></param>
        /// <param name="minuendM1x0"></param>
        /// <param name="minuendM1x1"></param>
        /// <param name="minuendM1x2"></param>
        /// <param name="minuendM2x0"></param>
        /// <param name="minuendM2x1"></param>
        /// <param name="minuendM2x2"></param>
        /// <param name="subtrahendM0x0"></param>
        /// <param name="subtrahendM0x1"></param>
        /// <param name="subtrahendM0x2"></param>
        /// <param name="subtrahendM1x0"></param>
        /// <param name="subtrahendM1x1"></param>
        /// <param name="subtrahendM1x2"></param>
        /// <param name="subtrahendM2x0"></param>
        /// <param name="subtrahendM2x1"></param>
        /// <param name="subtrahendM2x2"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m0x0, double m0x1, double m0x2,
            double m1x0, double m1x1, double m1x2,
            double m2x0, double m2x1, double m2x2
            ) Subtract3x3x3x3(
            double minuendM0x0, double minuendM0x1, double minuendM0x2,
            double minuendM1x0, double minuendM1x1, double minuendM1x2,
            double minuendM2x0, double minuendM2x1, double minuendM2x2,
            double subtrahendM0x0, double subtrahendM0x1, double subtrahendM0x2,
            double subtrahendM1x0, double subtrahendM1x1, double subtrahendM1x2,
            double subtrahendM2x0, double subtrahendM2x1, double subtrahendM2x2)
        {
            return (minuendM0x0 - subtrahendM0x0, minuendM0x1 - subtrahendM0x1, minuendM0x2 - subtrahendM0x2,
                           minuendM1x0 - subtrahendM1x0, minuendM1x1 - subtrahendM1x1, minuendM1x2 - subtrahendM1x2,
                           minuendM2x0 - subtrahendM2x0, minuendM2x1 - subtrahendM2x1, minuendM2x2 - subtrahendM2x2);
        }
    }
}
