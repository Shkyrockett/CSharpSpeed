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
    public static class MatrixAdd5x5x5x5Tests
    {
        /// <summary>
        /// Used to add two matrices together.
        /// </summary>
        /// <param name="augendM0x0"></param>
        /// <param name="augendM0x1"></param>
        /// <param name="augendM0x2"></param>
        /// <param name="augendM0x3"></param>
        /// <param name="augendM0x4"></param>
        /// <param name="augendM1x0"></param>
        /// <param name="augendM1x1"></param>
        /// <param name="augendM1x2"></param>
        /// <param name="augendM1x3"></param>
        /// <param name="augendM1x4"></param>
        /// <param name="augendM2x0"></param>
        /// <param name="augendM2x1"></param>
        /// <param name="augendM2x2"></param>
        /// <param name="augendM2x3"></param>
        /// <param name="augendM2x4"></param>
        /// <param name="augendM3x0"></param>
        /// <param name="augendM3x1"></param>
        /// <param name="augendM3x2"></param>
        /// <param name="augendM3x3"></param>
        /// <param name="augendM3x4"></param>
        /// <param name="augendM4x0"></param>
        /// <param name="augendM4x1"></param>
        /// <param name="augendM4x2"></param>
        /// <param name="augendM4x3"></param>
        /// <param name="augendM4x4"></param>
        /// <param name="addendM0x0"></param>
        /// <param name="addendM0x1"></param>
        /// <param name="addendM0x2"></param>
        /// <param name="addendM0x3"></param>
        /// <param name="addendM0x4"></param>
        /// <param name="addendM1x0"></param>
        /// <param name="addendM1x1"></param>
        /// <param name="addendM1x2"></param>
        /// <param name="addendM1x3"></param>
        /// <param name="addendM1x4"></param>
        /// <param name="addendM2x0"></param>
        /// <param name="addendM2x1"></param>
        /// <param name="addendM2x2"></param>
        /// <param name="addendM2x3"></param>
        /// <param name="addendM2x4"></param>
        /// <param name="addendM3x0"></param>
        /// <param name="addendM3x1"></param>
        /// <param name="addendM3x2"></param>
        /// <param name="addendM3x3"></param>
        /// <param name="addendM3x4"></param>
        /// <param name="addendM4x0"></param>
        /// <param name="addendM4x1"></param>
        /// <param name="addendM4x2"></param>
        /// <param name="addendM4x3"></param>
        /// <param name="addendM4x4"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m0x0, double m0x1, double m0x2, double m0x3, double m0x4,
            double m1x0, double m1x1, double m1x2, double m1x3, double m1x4,
            double m2x0, double m2x1, double m2x2, double m2x3, double m2x4,
            double m3x0, double m3x1, double m3x2, double m3x3, double m3x4,
            double m4x0, double m4x1, double m4x2, double m4x3, double m4x4
            ) Add5x5x5x5(
            double augendM0x0, double augendM0x1, double augendM0x2, double augendM0x3, double augendM0x4,
            double augendM1x0, double augendM1x1, double augendM1x2, double augendM1x3, double augendM1x4,
            double augendM2x0, double augendM2x1, double augendM2x2, double augendM2x3, double augendM2x4,
            double augendM3x0, double augendM3x1, double augendM3x2, double augendM3x3, double augendM3x4,
            double augendM4x0, double augendM4x1, double augendM4x2, double augendM4x3, double augendM4x4,
            double addendM0x0, double addendM0x1, double addendM0x2, double addendM0x3, double addendM0x4,
            double addendM1x0, double addendM1x1, double addendM1x2, double addendM1x3, double addendM1x4,
            double addendM2x0, double addendM2x1, double addendM2x2, double addendM2x3, double addendM2x4,
            double addendM3x0, double addendM3x1, double addendM3x2, double addendM3x3, double addendM3x4,
            double addendM4x0, double addendM4x1, double addendM4x2, double addendM4x3, double addendM4x4)
        {
            return (augendM0x0 + addendM0x0, augendM0x1 + addendM0x1, augendM0x2 + addendM0x2, augendM0x3 + addendM0x3, augendM0x4 + addendM0x4,
                           augendM1x0 + addendM1x0, augendM1x1 + addendM1x1, augendM1x2 + addendM1x2, augendM1x3 + addendM1x3, augendM1x4 + addendM1x4,
                           augendM2x0 + addendM2x0, augendM2x1 + addendM2x1, augendM2x2 + addendM2x2, augendM2x3 + addendM2x3, augendM2x4 + addendM2x4,
                           augendM3x0 + addendM3x0, augendM3x1 + addendM3x1, augendM3x2 + addendM3x2, augendM3x3 + addendM3x3, augendM3x4 + addendM3x4,
                           augendM4x0 + addendM4x0, augendM4x1 + addendM4x1, augendM4x2 + addendM4x2, augendM4x3 + addendM4x3, augendM4x4 + addendM4x4);
        }
    }
}
