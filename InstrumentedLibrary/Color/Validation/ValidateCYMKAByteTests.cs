using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    // ToDo:
    public static class ValidateCYMKAByteTests
    {
        /// <summary>
        /// Check whether a cyan yellow magenta black color is valid.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="y">The y.</param>
        /// <param name="m">The m.</param>
        /// <param name="k">The k.</param>
        /// <param name="a"></param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <remarks>https://www.codeproject.com/articles/4488/xcmyk-cmyk-to-rgb-calculator-with-source-code</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ValidateCYMKA(byte c, byte y, byte m, byte k, byte a)
        {
            return ValueBetweenByteTests.Between(a, CYMKMin, CYMKMax)
                   && ValueBetweenByteTests.Between(c, CYMKMin, CYMKMax)
                   && ValueBetweenByteTests.Between(y, CYMKMin, CYMKMax)
                   && ValueBetweenByteTests.Between(m, CYMKMin, CYMKMax)
                   && ValueBetweenByteTests.Between(k, CYMKMin, CYMKMax);
        }
    }
}
