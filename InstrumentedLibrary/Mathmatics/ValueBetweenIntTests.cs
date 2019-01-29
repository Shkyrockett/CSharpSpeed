using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    public static class ValueBetweenIntTests
    {
        /// <summary>
        /// Check whether the integer value is between lower and upper bounds.
        /// </summary>
        /// <param name="value">The <paramref name="value"/>.</param>
        /// <param name="lowerLimit">The lower limit.</param>
        /// <param name="upperLimit">The upper limit.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <acknowledgment>
        /// https://github.com/dystopiancode/colorspace-conversions/
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Between(int value, int lowerLimit, int upperLimit)
        {
            return value >= lowerLimit && value <= upperLimit;
        }
    }
}
