using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    public static class MatrixCofactor3x3Tests
    {
        /// <summary>
        /// The cofactor.
        /// </summary>
        /// <returns>The <see cref="Matrix3x3D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m0x0, double m0x1, double m0x2,
            double m1x0, double m1x1, double m1x2,
            double m2x0, double m2x1, double m2x2
            ) Cofactor(
            double m0x0, double m0x1, double m0x2,
            double m1x0, double m1x1, double m1x2,
            double m2x0, double m2x1, double m2x2)
        {
            return (-((m1x1 * m2x2) - (m1x2 * m2x1)), (m0x1 * m2x2) - (m0x2 * m2x1), -((m0x1 * m1x2) - (m0x2 * m1x1)),
                    (m1x0 * m2x2) - (m1x2 * m2x0), -((m0x0 * m2x2) - (m0x2 * m2x0)), (m0x0 * m1x2) - (m0x2 * m1x0),
                    -((m1x0 * m2x1) - (m1x1 * m2x0)), (m0x0 * m2x1) - (m0x1 * m2x0), -((m0x0 * m1x1) - (m0x1 * m1x0)));
        }
    }
}
