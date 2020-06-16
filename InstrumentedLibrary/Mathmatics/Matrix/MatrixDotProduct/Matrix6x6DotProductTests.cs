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
    public static class Matrix6x6DotProductTests
    {
        /// <summary>
        /// Dots the product matrix6x6.
        /// </summary>
        /// <param name="m1x1A">The M1X1 a.</param>
        /// <param name="m1x2A">The M1X2 a.</param>
        /// <param name="m1x3A">The M1X3 a.</param>
        /// <param name="m1x4A">The M1X4 a.</param>
        /// <param name="m1x5A">The M1X5 a.</param>
        /// <param name="m1x6A">The M1X6 a.</param>
        /// <param name="m2x1A">The M2X1 a.</param>
        /// <param name="m2x2A">The M2X2 a.</param>
        /// <param name="m2x3A">The M2X3 a.</param>
        /// <param name="m2x4A">The M2X4 a.</param>
        /// <param name="m2x5A">The M2X5 a.</param>
        /// <param name="m2x6A">The M2X6 a.</param>
        /// <param name="m3x1A">The M3X1 a.</param>
        /// <param name="m3x2A">The M3X2 a.</param>
        /// <param name="m3x3A">The M3X3 a.</param>
        /// <param name="m3x4A">The M3X4 a.</param>
        /// <param name="m3x5A">The M3X5 a.</param>
        /// <param name="m3x6A">The M3X6 a.</param>
        /// <param name="m4x1A">The M4X1 a.</param>
        /// <param name="m4x2A">The M4X2 a.</param>
        /// <param name="m4x3A">The M4X3 a.</param>
        /// <param name="m4x4A">The M4X4 a.</param>
        /// <param name="m4x5A">The M4X5 a.</param>
        /// <param name="m4x6A">The M4X6 a.</param>
        /// <param name="m5x1A">The M5X1 a.</param>
        /// <param name="m5x2A">The M5X2 a.</param>
        /// <param name="m5x3A">The M5X3 a.</param>
        /// <param name="m5x4A">The M5X4 a.</param>
        /// <param name="m5x5A">The M5X5 a.</param>
        /// <param name="m5x6A">The M5X6 a.</param>
        /// <param name="m6x1A">The M6X1 a.</param>
        /// <param name="m6x2A">The M6X2 a.</param>
        /// <param name="m6x3A">The M6X3 a.</param>
        /// <param name="m6x4A">The M6X4 a.</param>
        /// <param name="m6x5A">The M6X5 a.</param>
        /// <param name="m6x6A">The M6X6 a.</param>
        /// <param name="m1x1B">The M1X1 b.</param>
        /// <param name="m1x2B">The M1X2 b.</param>
        /// <param name="m1x3B">The M1X3 b.</param>
        /// <param name="m1x4B">The M1X4 b.</param>
        /// <param name="m1x5B">The M1X5 b.</param>
        /// <param name="m1x6B">The M1X6 b.</param>
        /// <param name="m2x1B">The M2X1 b.</param>
        /// <param name="m2x2B">The M2X2 b.</param>
        /// <param name="m2x3B">The M2X3 b.</param>
        /// <param name="m2x4B">The M2X4 b.</param>
        /// <param name="m2x5B">The M2X5 b.</param>
        /// <param name="m2x6B">The M2X6 b.</param>
        /// <param name="m3x1B">The M3X1 b.</param>
        /// <param name="m3x2B">The M3X2 b.</param>
        /// <param name="m3x3B">The M3X3 b.</param>
        /// <param name="m3x4B">The M3X4 b.</param>
        /// <param name="m3x5B">The M3X5 b.</param>
        /// <param name="m3x6B">The M3X6 b.</param>
        /// <param name="m4x1B">The M4X1 b.</param>
        /// <param name="m4x2B">The M4X2 b.</param>
        /// <param name="m4x3B">The M4X3 b.</param>
        /// <param name="m4x4B">The M4X4 b.</param>
        /// <param name="m4x5B">The M4X5 b.</param>
        /// <param name="m4x6B">The M4X6 b.</param>
        /// <param name="m5x1B">The M5X1 b.</param>
        /// <param name="m5x2B">The M5X2 b.</param>
        /// <param name="m5x3B">The M5X3 b.</param>
        /// <param name="m5x4B">The M5X4 b.</param>
        /// <param name="m5x5B">The M5X5 b.</param>
        /// <param name="m5x6B">The M5X6 b.</param>
        /// <param name="m6x1B">The M6X1 b.</param>
        /// <param name="m6x2B">The M6X2 b.</param>
        /// <param name="m6x3B">The M6X3 b.</param>
        /// <param name="m6x4B">The M6X4 b.</param>
        /// <param name="m6x5B">The M6X5 b.</param>
        /// <param name="m6x6B">The M6X6 b.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.physicsforums.com/threads/dot-product-2x2-matrix.688717/
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DotProductMatrix6x6(
            double m1x1A, double m1x2A, double m1x3A, double m1x4A, double m1x5A, double m1x6A,
            double m2x1A, double m2x2A, double m2x3A, double m2x4A, double m2x5A, double m2x6A,
            double m3x1A, double m3x2A, double m3x3A, double m3x4A, double m3x5A, double m3x6A,
            double m4x1A, double m4x2A, double m4x3A, double m4x4A, double m4x5A, double m4x6A,
            double m5x1A, double m5x2A, double m5x3A, double m5x4A, double m5x5A, double m5x6A,
            double m6x1A, double m6x2A, double m6x3A, double m6x4A, double m6x5A, double m6x6A,
            double m1x1B, double m1x2B, double m1x3B, double m1x4B, double m1x5B, double m1x6B,
            double m2x1B, double m2x2B, double m2x3B, double m2x4B, double m2x5B, double m2x6B,
            double m3x1B, double m3x2B, double m3x3B, double m3x4B, double m3x5B, double m3x6B,
            double m4x1B, double m4x2B, double m4x3B, double m4x4B, double m4x5B, double m4x6B,
            double m5x1B, double m5x2B, double m5x3B, double m5x4B, double m5x5B, double m5x6B,
            double m6x1B, double m6x2B, double m6x3B, double m6x4B, double m6x5B, double m6x6B)
        {
            return (m1x1A * m1x1B) + (m1x2A * m1x2B) + (m1x3A * m1x3B) + (m1x4A * m1x4B) + (m1x5A * m1x5B) + (m1x6A * m1x6B)
                 + (m2x1A * m2x1B) + (m2x2A * m2x2B) + (m2x3A * m2x3B) + (m2x4A * m2x4B) + (m2x5A * m2x5B) + (m2x6A * m2x6B)
                 + (m3x1A * m3x1B) + (m3x2A * m3x2B) + (m3x3A * m3x3B) + (m3x4A * m3x4B) + (m3x5A * m3x5B) + (m3x6A * m3x6B)
                 + (m4x1A * m4x1B) + (m4x2A * m4x2B) + (m4x3A * m4x3B) + (m4x4A * m4x4B) + (m4x5A * m4x5B) + (m4x6A * m4x6B)
                 + (m5x1A * m5x1B) + (m5x2A * m5x2B) + (m5x3A * m5x3B) + (m5x4A * m5x4B) + (m5x5A * m5x5B) + (m5x6A * m5x6B)
                 + (m6x1A * m6x1B) + (m6x2A * m6x2B) + (m6x3A * m6x3B) + (m6x4A * m6x4B) + (m6x5A * m6x5B) + (m6x6A * m6x6B);
        }
    }
}
