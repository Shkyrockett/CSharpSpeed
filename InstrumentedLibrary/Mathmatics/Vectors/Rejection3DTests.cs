using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    public static class Rejection3DTests
    {
        /// <summary>
        /// The rejection.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="z1">The z1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="z2">The z2.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <acknowledgment>
        /// http://www.codeproject.com/Articles/17425/A-Vector-Type-for-C
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) Rejection(
            double x1, double y1, double z1,
            double x2, double y2, double z2)
        {
            var magnitude = VectorMagnitude3D.Magnitude(x2, y2, z2);
            var dotProduct = DotProduct2Vector3DTests.DotProduct(x1, y1, z1, x2, y2, z2);
            return (x1 - x2 * dotProduct / magnitude * magnitude,
                    z1 - y2 * dotProduct / magnitude * magnitude,
                    z1 - z2 * dotProduct / magnitude * magnitude);
        }
    }
}
