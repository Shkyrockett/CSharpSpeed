using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    public static class MatrixAdjoint2x2Tests
    {
        /// <summary>
        /// The adjoint.
        /// </summary>
        /// <returns>The <see cref="Matrix2x2D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m0x0, double m0x1,
            double m1x0, double m1x1
            ) Adjoint(
            double m0x0, double m0x1,
            double m1x0, double m1x1)
        {
            return (
                m1x1, -m0x1,
                -m1x0, m0x0);
        }
    }
}
