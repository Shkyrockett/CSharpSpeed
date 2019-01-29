using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    public static class ValidateYIQATests
    {
        /// <summary>
        /// Check whether a yiq color is valid.
        /// </summary>
        /// <param name="y">The y.</param>
        /// <param name="i">The i.</param>
        /// <param name="q">The q.</param>
        /// <param name="a"></param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ValidateYIQA(double y, double i, double q, double a)
        {
            return ValueBetweenDoubleTests.Between(a, PercentMin, PercentMax)
                       && ValueBetweenDoubleTests.Between(y, PercentMin, PercentMax)
                       && ValueBetweenDoubleTests.Between(i, YIQMinI, YIQMaxI)
                       && ValueBetweenDoubleTests.Between(q, YIQMinQ, YIQMaxQ);
        }
    }
}
