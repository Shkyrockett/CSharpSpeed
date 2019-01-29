using System;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    public static class Min3DoubleTests
    {
        /// <summary>
        /// Find the minimum value of three variables.
        /// </summary>
        /// <param name="x">The first variable.</param>
        /// <param name="y">The second variable.</param>
        /// <param name="z">The third variable.</param>
        /// <returns>The <see cref="double"/>.</returns>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Min(double x, double y, double z)
        {
            return x < y ? x < z ? x : z : y < z ? y : z;
        }

        /// <summary>
        /// Find the minimum value of three variables.
        /// </summary>
        /// <param name="x">The first variable.</param>
        /// <param name="y">The second variable.</param>
        /// <param name="z">The third variable.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/6800838/in-c-sharp-is-there-a-method-to-find-the-max-of-3-numbers
        /// </acknowledgment>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Min2(double x, double y, double z)
            => Math.Min(x, Math.Min(y, z));
    }
}
