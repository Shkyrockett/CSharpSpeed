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
    /// <summary>
    /// 
    /// </summary>
    public static class MultiplyMatrix3x3x3x3Tests
    {
        /// <summary>
        /// Used to multiply (concatenate) two <see cref="Matrix3x3D"/>s.
        /// </summary>
        /// <param name="leftM0x0"></param>
        /// <param name="leftM0x1"></param>
        /// <param name="leftM0x2"></param>
        /// <param name="leftM1x0"></param>
        /// <param name="leftM1x1"></param>
        /// <param name="leftM1x2"></param>
        /// <param name="leftM2x0"></param>
        /// <param name="leftM2x1"></param>
        /// <param name="leftM2x2"></param>
        /// <param name="rightM0x0"></param>
        /// <param name="rightM0x1"></param>
        /// <param name="rightM0x2"></param>
        /// <param name="rightM1x0"></param>
        /// <param name="rightM1x1"></param>
        /// <param name="rightM1x2"></param>
        /// <param name="rightM2x0"></param>
        /// <param name="rightM2x1"></param>
        /// <param name="rightM2x2"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m0x0, double m0x1, double m0x2,
            double m1x0, double m1x1, double m1x2,
            double m2x0, double m2x1, double m2x2
            ) Multiply3x3x3x3(
            double leftM0x0, double leftM0x1, double leftM0x2,
            double leftM1x0, double leftM1x1, double leftM1x2,
            double leftM2x0, double leftM2x1, double leftM2x2,
            double rightM0x0, double rightM0x1, double rightM0x2,
            double rightM1x0, double rightM1x1, double rightM1x2,
            double rightM2x0, double rightM2x1, double rightM2x2)
        {
            return ((leftM0x0 * rightM0x0) + (leftM0x1 * rightM1x0) + (leftM0x2 * rightM2x0), (leftM0x0 * rightM0x1) + (leftM0x1 * rightM1x1) + (leftM0x2 * rightM2x1), (leftM0x0 * rightM0x2) + (leftM0x1 * rightM1x2) + (leftM0x2 * rightM2x2),
                           (leftM1x0 * rightM0x0) + (leftM1x1 * rightM1x0) + (leftM1x2 * rightM2x0), (leftM1x0 * rightM0x1) + (leftM1x1 * rightM1x1) + (leftM1x2 * rightM2x1), (leftM1x0 * rightM0x2) + (leftM1x1 * rightM1x2) + (leftM1x2 * rightM2x2),
                           (leftM2x0 * rightM0x0) + (leftM2x1 * rightM1x0) + (leftM2x2 * rightM2x0), (leftM2x0 * rightM0x1) + (leftM2x1 * rightM1x1) + (leftM2x2 * rightM2x1), (leftM2x0 * rightM0x2) + (leftM2x1 * rightM1x2) + (leftM2x2 * rightM2x2));
        }
    }
}
