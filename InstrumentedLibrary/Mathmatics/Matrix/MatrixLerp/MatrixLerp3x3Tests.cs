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
    public static class MatrixLerp3x3Tests
    {
        /// <summary>
        /// Linearly interpolates between the corresponding values of two matrices.
        /// </summary>
        /// <param name="m1x1A">The M1X1 a.</param>
        /// <param name="m1x2A">The M1X2 a.</param>
        /// <param name="m1x3A">The M1X3 a.</param>
        /// <param name="m2x1A">The M2X1 a.</param>
        /// <param name="m2x2A">The M2X2 a.</param>
        /// <param name="m2x3A">The M2X3 a.</param>
        /// <param name="m3x1A">The M3X1 a.</param>
        /// <param name="m3x2A">The M3X2 a.</param>
        /// <param name="m3x3A">The M3X3 a.</param>
        /// <param name="m1x1B">The M1X1 b.</param>
        /// <param name="m1x2B">The M1X2 b.</param>
        /// <param name="m1x3B">The M1X3 b.</param>
        /// <param name="m2x1B">The M2X1 b.</param>
        /// <param name="m2x2B">The M2X2 b.</param>
        /// <param name="m2x3B">The M2X3 b.</param>
        /// <param name="m3x1B">The M3X1 b.</param>
        /// <param name="m3x2B">The M3X2 b.</param>
        /// <param name="m3x3B">The M3X3 b.</param>
        /// <param name="amount">The relative weight of the second source matrix.</param>
        /// <returns>
        /// The interpolated matrix.
        /// </returns>
        /// <acknowledgment>
        /// https://referencesource.microsoft.com/#System.Numerics/System/Numerics/Matrix4x4.cs,48ce53b7e55d0436
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (
            double m1x1, double m1x2, double m1x3,
            double m2x1, double m2x2, double m2x3,
            double m3x1, double m3x2, double m3x3)
            LerpMatrix3x3(
            double m1x1A, double m1x2A, double m1x3A,
            double m2x1A, double m2x2A, double m2x3A,
            double m3x1A, double m3x2A, double m3x3A,
            double m1x1B, double m1x2B, double m1x3B,
            double m2x1B, double m2x2B, double m2x3B,
            double m3x1B, double m3x2B, double m3x3B,
            double amount)
        {
            return (
                // First row
                m1x1A + ((m1x1B - m1x1A) * amount),
                m1x2A + ((m1x2B - m1x2A) * amount),
                m1x3A + ((m1x3B - m1x3A) * amount),

                // Second row
                m2x1A + ((m2x1B - m2x1A) * amount),
                m2x2A + ((m2x2B - m2x2A) * amount),
                m2x3A + ((m2x3B - m2x3A) * amount),

                // Third row
                m3x1A + ((m3x1B - m3x1A) * amount),
                m3x2A + ((m3x2B - m3x2A) * amount),
                m3x3A + ((m3x3B - m3x3A) * amount)
                );
        }
    }
}
