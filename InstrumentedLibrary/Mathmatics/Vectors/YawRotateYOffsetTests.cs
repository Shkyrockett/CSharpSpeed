using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Math;

namespace InstrumentedLibrary
{
    public static class YawRotateYOffsetTests
    {
        /// <summary>
        /// The rotate y.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="z1">The z1.</param>
        /// <param name="xOff">The xOff.</param>
        /// <param name="zOff">The zOff.</param>
        /// <param name="rad">The rad.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <acknowledgment>
        /// http://www.codeproject.com/Articles/17425/A-Vector-Type-for-C
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) RotateY(double x1, double y1, double z1, double xOff, double zOff, double rad)
        {
            var sin = Sin(rad);
            var cos = Cos(rad);
            return (
                    (z1 * sin) + (x1 * cos) + (xOff * (1 - cos) - zOff * sin),
                    y1,
                    (z1 * cos) - (x1 * sin) + (zOff * (1 - cos) + xOff * sin)
                    );
        }
    }
}
