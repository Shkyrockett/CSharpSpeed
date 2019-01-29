using System;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    public static class RGBAColorToHSIAColorTests
    {
        /// <summary>
        /// The hsi create from rgb.
        /// </summary>
        /// <param name="red">The r.</param>
        /// <param name="green">The g.</param>
        /// <param name="blue">The b.</param>
        /// <param name="alpha"></param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double hue, double saturation, double intensity, double alpha) RGBAColorToHSIAColor(byte red, byte green, byte blue, byte alpha)
        {
            return RGBAFColorToHSIAColorTests.RGBAFColorToHSIAColor(red / 256d, green / 256d, blue / 256d, alpha / 256d);
        }
    }
}
