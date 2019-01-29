using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    public static class ValueBetweenDoubleTests
    {
        /// <summary>
        /// Check whether the double value is between lower and upper bounds.
        /// </summary>
        /// <param name="value">The <paramref name="value"/>.</param>
        /// <param name="lowerLimit">The lower limit.</param>
        /// <param name="upperLimit">The upper limit.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Between(double value, double lowerLimit, double upperLimit)
        {
            return value >= lowerLimit && value <= upperLimit;
        }
    }
}
