using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    public static class ValidateHSLATests
    {
        /// <summary>
        /// Check whether a hue saturation luminance color is valid.
        /// </summary>
        /// <param name="h">The h.</param>
        /// <param name="s">The s.</param>
        /// <param name="l">The l.</param>
        /// <param name="a"></param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ValidateHSLA(double h, double s, double l, double a)
        {
            return ValueBetweenDoubleTests.Between(a, PercentMin, PercentMax)
                       && ValueBetweenDoubleTests.Between(h, HueMin, HueMax)
                       && ValueBetweenDoubleTests.Between(s, PercentMin, PercentMax)
                       && ValueBetweenDoubleTests.Between(l, PercentMin, PercentMax);
        }
    }
}
