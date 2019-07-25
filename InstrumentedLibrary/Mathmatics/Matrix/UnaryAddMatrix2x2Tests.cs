using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    public static class UnaryAddMatrix2x2Tests
    {
        /// <summary>
        ///	Posates a <see cref="Matrix2x2D"/>.
        /// </summary>
        /// <param name="sourceM0x0"></param>
        /// <param name="sourceM0x1"></param>
        /// <param name="sourceM1x0"></param>
        /// <param name="sourceM1x1"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m0x0, double m0x1,
            double m1x0, double m1x1
            ) UnaryPosate(
            double sourceM0x0, double sourceM0x1,
            double sourceM1x0, double sourceM1x1)
        {
            return (+sourceM0x0, +sourceM0x1,
                           +sourceM1x0, +sourceM1x1);
        }
    }
}
