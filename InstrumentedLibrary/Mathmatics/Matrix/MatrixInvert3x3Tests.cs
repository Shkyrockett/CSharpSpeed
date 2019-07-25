using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    public static class MatrixInvert3x3Tests
    {
        /// <summary>
        /// The invert.
        /// </summary>
        /// <returns>The <see cref="Matrix3x3D"/>.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m0x0, double m0x1, double m0x2,
            double m1x0, double m1x1, double m1x2,
            double m2x0, double m2x1, double m2x2
            ) Invert(
            double m0x0, double m0x1, double m0x2,
            double m1x0, double m1x1, double m1x2,
            double m2x0, double m2x1, double m2x2)
        {
            var m11m22m12m21 = (m1x1 * m2x2) - (m1x2 * m2x1);
            var m10m22m12m20 = (m1x0 * m2x2) - (m1x2 * m2x0);
            var m10m21m11m20 = (m1x0 * m2x1) - (m1x1 * m2x0);
            var detInv = 1d / ((m0x0 * m11m22m12m21) - (m0x1 * m10m22m12m20) + (m0x2 * m10m21m11m20));
            return (
                detInv * m11m22m12m21,
                detInv * (-((m0x1 * m2x2) - (m0x2 * m2x1))),
                detInv * ((m0x1 * m1x2) - (m0x2 * m1x1)),
                detInv * (-m10m22m12m20),
                detInv * ((m0x0 * m2x2) - (m0x2 * m2x0)),
                detInv * (-((m0x0 * m1x2) - (m0x2 * m1x0))),
                detInv * m10m21m11m20,
                detInv * (-((m0x0 * m2x1) - (m0x1 * m2x0))),
                detInv * ((m0x0 * m1x1) - (m0x1 * m1x0)));
        }
    }
}
