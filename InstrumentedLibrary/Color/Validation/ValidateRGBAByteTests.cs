using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    public static class ValidateRGBAByteTests
    {
        /// <summary>
        /// Check whether a red green blue color is valid.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <param name="g">The g.</param>
        /// <param name="b">The b.</param>
        /// <param name="a"></param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ValidateRGBA(byte r, byte g, byte b, byte a)
        {
            return ValueBetweenByteTests.Between(a, RGBMin, RGBMax)
                   && ValueBetweenByteTests.Between(r, RGBMin, RGBMax)
                   && ValueBetweenByteTests.Between(g, RGBMin, RGBMax)
                   && ValueBetweenByteTests.Between(b, RGBMin, RGBMax);
        }
    }
}
