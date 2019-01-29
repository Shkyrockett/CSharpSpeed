using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    public static class SetRGBByteSaturationTests
    {
        /// <summary>
        /// Sets the absolute saturation level
        /// </summary>
        /// <remarks>Accepted values 0-1</remarks>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <param name="alpha"></param>
        /// <param name="Saturation">The saturation value to impose</param>
        /// <returns>An adjusted color</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (byte red, byte green, byte blue, byte alpha) SetSaturation(byte red, byte green, byte blue, byte alpha, double Saturation)
        {
            var hsl = RGBAByteColorToHSLAColorTests.RGBAColorToHSLAColor(red, green, blue, alpha);
            return HSLAColorToRGBAByteColorTests.HSLAColorToRGBAColor(hsl.hue, Saturation, hsl.luminance, hsl.alpha);
        }
    }
}
