﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    public static class UnaryAddMatrix6x6Tests
    {
        /// <summary>
        ///	Posates a Matrix6x6D.
        /// </summary>
        /// <param name="sourceM0x0"></param>
        /// <param name="sourceM0x1"></param>
        /// <param name="sourceM0x2"></param>
        /// <param name="sourceM0x3"></param>
        /// <param name="sourceM0x4"></param>
        /// <param name="sourceM0x5"></param>
        /// <param name="sourceM1x0"></param>
        /// <param name="sourceM1x1"></param>
        /// <param name="sourceM1x2"></param>
        /// <param name="sourceM1x3"></param>
        /// <param name="sourceM1x4"></param>
        /// <param name="sourceM1x5"></param>
        /// <param name="sourceM2x0"></param>
        /// <param name="sourceM2x1"></param>
        /// <param name="sourceM2x2"></param>
        /// <param name="sourceM2x3"></param>
        /// <param name="sourceM2x4"></param>
        /// <param name="sourceM2x5"></param>
        /// <param name="sourceM3x0"></param>
        /// <param name="sourceM3x1"></param>
        /// <param name="sourceM3x2"></param>
        /// <param name="sourceM3x3"></param>
        /// <param name="sourceM3x4"></param>
        /// <param name="sourceM3x5"></param>
        /// <param name="sourceM4x0"></param>
        /// <param name="sourceM4x1"></param>
        /// <param name="sourceM4x2"></param>
        /// <param name="sourceM4x3"></param>
        /// <param name="sourceM4x4"></param>
        /// <param name="sourceM4x5"></param>
        /// <param name="sourceM5x0"></param>
        /// <param name="sourceM5x1"></param>
        /// <param name="sourceM5x2"></param>
        /// <param name="sourceM5x3"></param>
        /// <param name="sourceM5x4"></param>
        /// <param name="sourceM5x5"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m0x0, double m0x1, double m0x2, double m0x3, double m0x4, double m0x5,
            double m1x0, double m1x1, double m1x2, double m1x3, double m1x4, double m1x5,
            double m2x0, double m2x1, double m2x2, double m2x3, double m2x4, double m2x5,
            double m3x0, double m3x1, double m3x2, double m3x3, double m3x4, double m3x5,
            double m4x0, double m4x1, double m4x2, double m4x3, double m4x4, double m4x5,
            double m5x0, double m5x1, double m5x2, double m5x3, double m5x4, double m5x5
            ) UnaryPosate(
            double sourceM0x0, double sourceM0x1, double sourceM0x2, double sourceM0x3, double sourceM0x4, double sourceM0x5,
            double sourceM1x0, double sourceM1x1, double sourceM1x2, double sourceM1x3, double sourceM1x4, double sourceM1x5,
            double sourceM2x0, double sourceM2x1, double sourceM2x2, double sourceM2x3, double sourceM2x4, double sourceM2x5,
            double sourceM3x0, double sourceM3x1, double sourceM3x2, double sourceM3x3, double sourceM3x4, double sourceM3x5,
            double sourceM4x0, double sourceM4x1, double sourceM4x2, double sourceM4x3, double sourceM4x4, double sourceM4x5,
            double sourceM5x0, double sourceM5x1, double sourceM5x2, double sourceM5x3, double sourceM5x4, double sourceM5x5)
        {
            return (+sourceM0x0, +sourceM0x1, +sourceM0x2, +sourceM0x3, +sourceM0x4, +sourceM0x5,
                           +sourceM1x0, +sourceM1x1, +sourceM1x2, +sourceM1x3, +sourceM1x4, +sourceM1x5,
                           +sourceM2x0, +sourceM2x1, +sourceM2x2, +sourceM2x3, +sourceM2x4, +sourceM2x5,
                           +sourceM3x0, +sourceM3x1, +sourceM3x2, +sourceM3x3, +sourceM3x4, +sourceM3x5,
                           +sourceM4x0, +sourceM4x1, +sourceM4x2, +sourceM4x3, +sourceM4x4, +sourceM4x5,
                           +sourceM5x0, +sourceM5x1, +sourceM5x2, +sourceM5x3, +sourceM5x4, +sourceM5x5);
        }
    }
}