using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    // ToDo:
    public static class ValidateHSIATests
    {
        /// <summary>
        /// Check whether a hue saturation intensity color is valid.
        /// </summary>
        /// <param name="h">The h.</param>
        /// <param name="s">The s.</param>
        /// <param name="i">The i.</param>
        /// <param name="a"></param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ValidateHSIA(double h, double s, double i, double a)
            => ValueBetweenDoubleTests.Between(a, PercentMin, PercentMax)
            && ValueBetweenDoubleTests.Between(h, HueMin, HueMax)
            && ValueBetweenDoubleTests.Between(s, PercentMin, PercentMax)
            && ValueBetweenDoubleTests.Between(i, PercentMin, PercentMax);
    }
}
