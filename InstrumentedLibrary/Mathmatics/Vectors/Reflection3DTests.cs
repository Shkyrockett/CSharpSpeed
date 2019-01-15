using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    public static class Reflection3DTests
    {
        /// <summary>
        /// The reflection.
        /// </summary>
        /// <param name="i1">The i1.</param>
        /// <param name="j1">The j1.</param>
        /// <param name="k1">The k1.</param>
        /// <param name="i2">The i2.</param>
        /// <param name="j2">The j2.</param>
        /// <param name="k2">The k2.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <acknowledgment>
        /// http://www.codeproject.com/Articles/17425/A-Vector-Type-for-C
        /// </acknowledgment>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) Reflection(
            double i1, double j1, double k1,
            double i2, double j2, double k2)
        {
            // if v2 has a right angle to vector, return -vector and stop
            if (Math.Abs(Math.Abs(Angle3DTests.Angle(i1, j1, k1, i2, j2, k2)) - Math.PI / 2) < double.Epsilon)
            {
                return (-i1, -j1, -k1);
            }

            (var x, var y, var z) = Projection3DTests.Projection(i1, j1, k1, i2, j2, k2);
            var magnitude = VectorMagnitude3D.Magnitude(i1, j1, k1);
            return (
                (2 * x - i1) * magnitude,
                (2 * y - j1) * magnitude,
                (2 * z - k1) * magnitude);
        }
    }
}
