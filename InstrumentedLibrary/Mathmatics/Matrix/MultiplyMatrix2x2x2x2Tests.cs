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
    public static class MultiplyMatrix2x2x2x2Tests
    {
        /// <summary>
        /// Used to multiply (concatenate) two Matrix2x2s.
        /// </summary>
        /// <param name="leftM0x0"></param>
        /// <param name="leftM0x1"></param>
        /// <param name="leftM1x0"></param>
        /// <param name="leftM1x1"></param>
        /// <param name="rightM0x0"></param>
        /// <param name="rightM0x1"></param>
        /// <param name="rightM1x0"></param>
        /// <param name="rightM1x1"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m0x0, double m0x1,
            double m1x0, double m1x1
            ) Multiply2x2x2x2(
            double leftM0x0, double leftM0x1,
            double leftM1x0, double leftM1x1,
            double rightM0x0, double rightM0x1,
            double rightM1x0, double rightM1x1)
        {
            return ((leftM0x0 * rightM0x0) + (leftM0x1 * rightM1x0), (leftM0x0 * rightM0x1) + (leftM0x1 * rightM1x1),
                           (leftM1x0 * rightM0x0) + (leftM1x1 * rightM1x0), (leftM1x0 * rightM0x1) + (leftM1x1 * rightM1x1));
        }
    }
}
