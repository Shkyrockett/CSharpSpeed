using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    public static class ValidateHSVATests
    {
        /// <summary>
        /// Check whether a hue saturation value color is valid.
        /// </summary>
        /// <param name="h">The h.</param>
        /// <param name="s">The s.</param>
        /// <param name="v">The v.</param>
        /// <param name="a"></param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ValidateHSVA(double h, double s, double v, double a)
        {
            return ValueBetweenDoubleTests.Between(a, PercentMin, PercentMax)
                       && ValueBetweenDoubleTests.Between(h, HueMin, HueMax)
                       && ValueBetweenDoubleTests.Between(s, PercentMin, PercentMax)
                       && ValueBetweenDoubleTests.Between(v, PercentMin, PercentMax);
        }
    }
}
