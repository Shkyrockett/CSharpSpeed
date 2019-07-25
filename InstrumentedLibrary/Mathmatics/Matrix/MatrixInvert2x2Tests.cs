using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    public static class MatrixInvert2x2Tests
    {
        /// <summary>
        /// The invert.
        /// </summary>
        /// <returns>The <see cref="Matrix2x2D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m0x0, double m0x1,
            double m1x0, double m1x1
            ) Invert(
            double m0x0, double m0x1,
            double m1x0, double m1x1)
        {
            var detInv = 1d / ((m0x0 * m1x1) - (m0x1 * m1x0));
            return (
                detInv * m1x1, detInv * -m0x1,
                detInv * -m1x0, detInv * m0x0);
        }
    }
}
