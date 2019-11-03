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
    public static class MatrixSubtract6x6x6x6Tests
    {
        /// <summary>
        /// Used to subtract two matrices.
        /// </summary>
        /// <param name="minuendM0x0"></param>
        /// <param name="minuendM0x1"></param>
        /// <param name="minuendM0x2"></param>
        /// <param name="minuendM0x3"></param>
        /// <param name="minuendM0x4"></param>
        /// <param name="minuendM0x5"></param>
        /// <param name="minuendM1x0"></param>
        /// <param name="minuendM1x1"></param>
        /// <param name="minuendM1x2"></param>
        /// <param name="minuendM1x3"></param>
        /// <param name="minuendM1x4"></param>
        /// <param name="minuendM1x5"></param>
        /// <param name="minuendM2x0"></param>
        /// <param name="minuendM2x1"></param>
        /// <param name="minuendM2x2"></param>
        /// <param name="minuendM2x3"></param>
        /// <param name="minuendM2x4"></param>
        /// <param name="minuendM2x5"></param>
        /// <param name="minuendM3x0"></param>
        /// <param name="minuendM3x1"></param>
        /// <param name="minuendM3x2"></param>
        /// <param name="minuendM3x3"></param>
        /// <param name="minuendM3x4"></param>
        /// <param name="minuendM3x5"></param>
        /// <param name="minuendM4x0"></param>
        /// <param name="minuendM4x1"></param>
        /// <param name="minuendM4x2"></param>
        /// <param name="minuendM4x3"></param>
        /// <param name="minuendM4x4"></param>
        /// <param name="minuendM4x5"></param>
        /// <param name="minuendM5x0"></param>
        /// <param name="minuendM5x1"></param>
        /// <param name="minuendM5x2"></param>
        /// <param name="minuendM5x3"></param>
        /// <param name="minuendM5x4"></param>
        /// <param name="minuendM5x5"></param>
        /// <param name="subtrahendM0x0"></param>
        /// <param name="subtrahendM0x1"></param>
        /// <param name="subtrahendM0x2"></param>
        /// <param name="subtrahendM0x3"></param>
        /// <param name="subtrahendM0x4"></param>
        /// <param name="subtrahendM0x5"></param>
        /// <param name="subtrahendM1x0"></param>
        /// <param name="subtrahendM1x1"></param>
        /// <param name="subtrahendM1x2"></param>
        /// <param name="subtrahendM1x3"></param>
        /// <param name="subtrahendM1x4"></param>
        /// <param name="subtrahendM1x5"></param>
        /// <param name="subtrahendM2x0"></param>
        /// <param name="subtrahendM2x1"></param>
        /// <param name="subtrahendM2x2"></param>
        /// <param name="subtrahendM2x3"></param>
        /// <param name="subtrahendM2x4"></param>
        /// <param name="subtrahendM2x5"></param>
        /// <param name="subtrahendM3x0"></param>
        /// <param name="subtrahendM3x1"></param>
        /// <param name="subtrahendM3x2"></param>
        /// <param name="subtrahendM3x3"></param>
        /// <param name="subtrahendM3x4"></param>
        /// <param name="subtrahendM3x5"></param>
        /// <param name="subtrahendM4x0"></param>
        /// <param name="subtrahendM4x1"></param>
        /// <param name="subtrahendM4x2"></param>
        /// <param name="subtrahendM4x3"></param>
        /// <param name="subtrahendM4x4"></param>
        /// <param name="subtrahendM4x5"></param>
        /// <param name="subtrahendM5x0"></param>
        /// <param name="subtrahendM5x1"></param>
        /// <param name="subtrahendM5x2"></param>
        /// <param name="subtrahendM5x3"></param>
        /// <param name="subtrahendM5x4"></param>
        /// <param name="subtrahendM5x5"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m0x0, double m0x1, double m0x2, double m0x3, double m0x4, double m0x5,
            double m1x0, double m1x1, double m1x2, double m1x3, double m1x4, double m1x5,
            double m2x0, double m2x1, double m2x2, double m2x3, double m2x4, double m2x5,
            double m3x0, double m3x1, double m3x2, double m3x3, double m3x4, double m3x5,
            double m4x0, double m4x1, double m4x2, double m4x3, double m4x4, double m4x5,
            double m5x0, double m5x1, double m5x2, double m5x3, double m5x4, double m5x5
            ) Subtract6x6x6x6(
            double minuendM0x0, double minuendM0x1, double minuendM0x2, double minuendM0x3, double minuendM0x4, double minuendM0x5,
            double minuendM1x0, double minuendM1x1, double minuendM1x2, double minuendM1x3, double minuendM1x4, double minuendM1x5,
            double minuendM2x0, double minuendM2x1, double minuendM2x2, double minuendM2x3, double minuendM2x4, double minuendM2x5,
            double minuendM3x0, double minuendM3x1, double minuendM3x2, double minuendM3x3, double minuendM3x4, double minuendM3x5,
            double minuendM4x0, double minuendM4x1, double minuendM4x2, double minuendM4x3, double minuendM4x4, double minuendM4x5,
            double minuendM5x0, double minuendM5x1, double minuendM5x2, double minuendM5x3, double minuendM5x4, double minuendM5x5,
            double subtrahendM0x0, double subtrahendM0x1, double subtrahendM0x2, double subtrahendM0x3, double subtrahendM0x4, double subtrahendM0x5,
            double subtrahendM1x0, double subtrahendM1x1, double subtrahendM1x2, double subtrahendM1x3, double subtrahendM1x4, double subtrahendM1x5,
            double subtrahendM2x0, double subtrahendM2x1, double subtrahendM2x2, double subtrahendM2x3, double subtrahendM2x4, double subtrahendM2x5,
            double subtrahendM3x0, double subtrahendM3x1, double subtrahendM3x2, double subtrahendM3x3, double subtrahendM3x4, double subtrahendM3x5,
            double subtrahendM4x0, double subtrahendM4x1, double subtrahendM4x2, double subtrahendM4x3, double subtrahendM4x4, double subtrahendM4x5,
            double subtrahendM5x0, double subtrahendM5x1, double subtrahendM5x2, double subtrahendM5x3, double subtrahendM5x4, double subtrahendM5x5)
        {
            return (minuendM0x0 - subtrahendM0x0, minuendM0x1 - subtrahendM0x1, minuendM0x2 - subtrahendM0x2, minuendM0x3 - subtrahendM0x3, minuendM0x4 - subtrahendM0x4, minuendM0x5 - subtrahendM0x5,
                           minuendM1x0 - subtrahendM1x0, minuendM1x1 - subtrahendM1x1, minuendM1x2 - subtrahendM1x2, minuendM1x3 - subtrahendM1x3, minuendM1x4 - subtrahendM1x4, minuendM1x5 - subtrahendM1x5,
                           minuendM2x0 - subtrahendM2x0, minuendM2x1 - subtrahendM2x1, minuendM2x2 - subtrahendM2x2, minuendM2x3 - subtrahendM2x3, minuendM2x4 - subtrahendM2x4, minuendM2x5 - subtrahendM2x5,
                           minuendM3x0 - subtrahendM3x0, minuendM3x1 - subtrahendM3x1, minuendM3x2 - subtrahendM3x2, minuendM3x3 - subtrahendM3x3, minuendM3x4 - subtrahendM3x4, minuendM3x5 - subtrahendM3x5,
                           minuendM4x0 - subtrahendM4x0, minuendM4x1 - subtrahendM4x1, minuendM4x2 - subtrahendM4x2, minuendM4x3 - subtrahendM4x3, minuendM4x4 - subtrahendM4x4, minuendM4x5 - subtrahendM4x5,
                           minuendM5x0 - subtrahendM5x0, minuendM5x1 - subtrahendM5x1, minuendM5x2 - subtrahendM5x2, minuendM5x3 - subtrahendM5x3, minuendM5x4 - subtrahendM5x4, minuendM5x5 - subtrahendM5x5);
        }
    }
}
