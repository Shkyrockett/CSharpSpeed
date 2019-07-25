using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.ComponentModel;
using CSharpSpeed;
using System.Reflection;

namespace InstrumentedLibrary
{
    public static class MultiplyMatrix4x4x2x2Tests
    {
        /// <summary>
        /// Used to multiply (concatenate) two <see cref="Matrix4x4D"/>s.
        /// </summary>
        /// <param name="leftM0x0"></param>
        /// <param name="leftM0x1"></param>
        /// <param name="leftM0x2"></param>
        /// <param name="leftM0x3"></param>
        /// <param name="leftM1x0"></param>
        /// <param name="leftM1x1"></param>
        /// <param name="leftM1x2"></param>
        /// <param name="leftM1x3"></param>
        /// <param name="leftM2x0"></param>
        /// <param name="leftM2x1"></param>
        /// <param name="leftM2x2"></param>
        /// <param name="leftM2x3"></param>
        /// <param name="leftM3x0"></param>
        /// <param name="leftM3x1"></param>
        /// <param name="leftM3x2"></param>
        /// <param name="leftM3x3"></param>
        /// <param name="rightM0x0"></param>
        /// <param name="rightM0x1"></param>
        /// <param name="rightM1x0"></param>
        /// <param name="rightM1x1"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m0x0, double m0x1, double m0x2, double m0x3,
            double m1x0, double m1x1, double m1x2, double m1x3,
            double m2x0, double m2x1, double m2x2, double m2x3,
            double m3x0, double m3x1, double m3x2, double m3x3
            ) Multiply4x4x2x2(
            double leftM0x0, double leftM0x1, double leftM0x2, double leftM0x3,
            double leftM1x0, double leftM1x1, double leftM1x2, double leftM1x3,
            double leftM2x0, double leftM2x1, double leftM2x2, double leftM2x3,
            double leftM3x0, double leftM3x1, double leftM3x2, double leftM3x3,
            double rightM0x0, double rightM0x1,
            double rightM1x0, double rightM1x1)
        {
            return ((leftM0x0 * rightM0x0) + (leftM0x1 * rightM1x0), (leftM0x0 * rightM0x1) + (leftM0x1 * rightM1x1), leftM0x2, leftM0x3,
                    (leftM1x0 * rightM0x0) + (leftM1x1 * rightM1x0), (leftM1x0 * rightM0x1) + (leftM1x1 * rightM1x1), leftM1x2, leftM1x3,
                    (leftM2x0 * rightM0x0) + (leftM2x1 * rightM1x0), (leftM2x0 * rightM0x1) + (leftM2x1 * rightM1x1), leftM2x2, leftM2x3,
                    (leftM3x0 * rightM0x0) + (leftM3x1 * rightM1x0), (leftM3x0 * rightM0x1) + (leftM3x1 * rightM1x1), leftM3x2, leftM3x3);
        }
    }
}
