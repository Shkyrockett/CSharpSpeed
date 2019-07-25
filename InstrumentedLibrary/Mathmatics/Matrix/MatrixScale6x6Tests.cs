using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    public static class MatrixScale6x6Tests
    {
        /// <summary>
        /// Used to multiply (concatenate) two Matrix5x5Ds.
        /// </summary>
        /// <param name="leftM0x0"></param>
        /// <param name="leftM0x1"></param>
        /// <param name="leftM0x2"></param>
        /// <param name="leftM0x3"></param>
        /// <param name="leftM0x4"></param>
        /// <param name="leftM0x5"></param>
        /// <param name="leftM1x0"></param>
        /// <param name="leftM1x1"></param>
        /// <param name="leftM1x2"></param>
        /// <param name="leftM1x3"></param>
        /// <param name="leftM1x4"></param>
        /// <param name="leftM1x5"></param>
        /// <param name="leftM2x0"></param>
        /// <param name="leftM2x1"></param>
        /// <param name="leftM2x2"></param>
        /// <param name="leftM2x3"></param>
        /// <param name="leftM2x4"></param>
        /// <param name="leftM2x5"></param>
        /// <param name="leftM3x0"></param>
        /// <param name="leftM3x1"></param>
        /// <param name="leftM3x2"></param>
        /// <param name="leftM3x3"></param>
        /// <param name="leftM3x4"></param>
        /// <param name="leftM3x5"></param>
        /// <param name="leftM4x0"></param>
        /// <param name="leftM4x1"></param>
        /// <param name="leftM4x2"></param>
        /// <param name="leftM4x3"></param>
        /// <param name="leftM4x4"></param>
        /// <param name="leftM4x5"></param>
        /// <param name="leftM5x0"></param>
        /// <param name="leftM5x1"></param>
        /// <param name="leftM5x2"></param>
        /// <param name="leftM5x3"></param>
        /// <param name="leftM5x4"></param>
        /// <param name="leftM5x5"></param>
        /// <param name="scalar"></param>
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
            ) Scale6x6(
            double leftM0x0, double leftM0x1, double leftM0x2, double leftM0x3, double leftM0x4, double leftM0x5,
            double leftM1x0, double leftM1x1, double leftM1x2, double leftM1x3, double leftM1x4, double leftM1x5,
            double leftM2x0, double leftM2x1, double leftM2x2, double leftM2x3, double leftM2x4, double leftM2x5,
            double leftM3x0, double leftM3x1, double leftM3x2, double leftM3x3, double leftM3x4, double leftM3x5,
            double leftM4x0, double leftM4x1, double leftM4x2, double leftM4x3, double leftM4x4, double leftM4x5,
            double leftM5x0, double leftM5x1, double leftM5x2, double leftM5x3, double leftM5x4, double leftM5x5,
            double scalar)
        {
            return (leftM0x0 * scalar, leftM0x1 * scalar, leftM0x2 * scalar, leftM0x3 * scalar, leftM0x4 * scalar, leftM0x5 * scalar,
                           leftM1x0 * scalar, leftM1x1 * scalar, leftM1x2 * scalar, leftM1x3 * scalar, leftM1x4 * scalar, leftM1x5 * scalar,
                           leftM2x0 * scalar, leftM2x1 * scalar, leftM2x2 * scalar, leftM2x3 * scalar, leftM2x4 * scalar, leftM2x5 * scalar,
                           leftM3x0 * scalar, leftM3x1 * scalar, leftM3x2 * scalar, leftM3x3 * scalar, leftM3x4 * scalar, leftM3x5 * scalar,
                           leftM4x0 * scalar, leftM4x1 * scalar, leftM4x2 * scalar, leftM4x3 * scalar, leftM4x4 * scalar, leftM4x5 * scalar,
                           leftM5x0 * scalar, leftM5x1 * scalar, leftM5x2 * scalar, leftM5x3 * scalar, leftM5x4 * scalar, leftM5x5 * scalar);
        }
    }
}
