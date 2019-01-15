using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Math;

namespace InstrumentedLibrary
{
    class PitchRotateXTests
    {
        /// <summary>
        /// The pitch.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="z1">The z1.</param>
        /// <param name="rad">The rad.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <acknowledgment>
        /// http://www.codeproject.com/Articles/17425/A-Vector-Type-for-C
        /// </acknowledgment>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) Pitch(double x1, double y1, double z1, double rad)
            => RotateX(x1, y1, z1, rad);

        /// <summary>
        /// The rotate x.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="z1">The z1.</param>
        /// <param name="rad">The rad.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <acknowledgment>
        /// http://www.codeproject.com/Articles/17425/A-Vector-Type-for-C
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) RotateX(double x1, double y1, double z1, double rad)
        {
            var cos = Cos(rad);
            var sin = Sin(rad);
            return (
                    x1,
                    (y1 * cos) - (z1 * sin),
                    (y1 * sin) + (z1 * cos)
                    );
        }
    }
}
