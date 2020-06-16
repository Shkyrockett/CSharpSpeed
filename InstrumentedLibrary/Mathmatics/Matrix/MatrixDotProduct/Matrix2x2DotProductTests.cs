using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class Matrix2x2DotProductTests
    {
        /// <summary>
        /// Dots the product matrix2x2.
        /// </summary>
        /// <param name="m1x1A">The M1X1 a.</param>
        /// <param name="m1x2A">The M1X2 a.</param>
        /// <param name="m2x1A">The M2X1 a.</param>
        /// <param name="m2x2A">The M2X2 a.</param>
        /// <param name="m1x1B">The M1X1 b.</param>
        /// <param name="m1x2B">The M1X2 b.</param>
        /// <param name="m2x1B">The M2X1 b.</param>
        /// <param name="m2x2B">The M2X2 b.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.physicsforums.com/threads/dot-product-2x2-matrix.688717/
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DotProductMatrix2x2(
            double m1x1A, double m1x2A,
            double m2x1A, double m2x2A,
            double m1x1B, double m1x2B,
            double m2x1B, double m2x2B)
        {
            return (m1x1A * m1x1B) + (m1x2A * m1x2B)
                 + (m2x1A * m2x1B) + (m2x2A * m2x2B);
        }
    }
}
