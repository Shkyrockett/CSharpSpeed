using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    public static class ValidateRGBAFloatTests
    {
        /// <summary>
        /// Check whether a red green blue double floating point color is valid.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <param name="g">The g.</param>
        /// <param name="b">The b.</param>
        /// <param name="a"></param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ValidateRGBAF(double r, double g, double b, double a)
            => ValueBetweenDoubleTests.Between(a, PercentMin, PercentMax)
            && ValueBetweenDoubleTests.Between(r, PercentMin, PercentMax)
            && ValueBetweenDoubleTests.Between(g, PercentMin, PercentMax)
            && ValueBetweenDoubleTests.Between(b, PercentMin, PercentMax);
    }
}
