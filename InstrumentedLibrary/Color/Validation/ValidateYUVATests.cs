using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    public static class ValidateYUVATests
    {
        /// <summary>
        /// Check whether a yuv color is valid.
        /// </summary>
        /// <param name="y">The y.</param>
        /// <param name="u">The u.</param>
        /// <param name="v">The v.</param>
        /// <param name="a"></param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ValidateYUVA(double y, double u, double v, double a)
        {
            return ValueBetweenDoubleTests.Between(a, PercentMin, PercentMax)
                       && ValueBetweenDoubleTests.Between(y, PercentMin, PercentMax)
                       && ValueBetweenDoubleTests.Between(u, YUVMinU, YUVMaxU)
                       && ValueBetweenDoubleTests.Between(v, YUVMinV, YUVMaxV);
        }
    }
}
