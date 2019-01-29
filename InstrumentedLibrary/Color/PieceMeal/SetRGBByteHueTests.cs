using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    public static class SetRGBByteHueTests
    {
        /// <summary>
        /// Sets the absolute Hue level.
        /// </summary>
        /// <remarks>Accepted values 0-1</remarks>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <param name="alpha"></param>
        /// <param name="Hue">The Hue value to impose</param>
        /// <returns>An adjusted color</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (byte red, byte green, byte blue, byte alpha) SetHue(byte red, byte green, byte blue, byte alpha, double Hue)
        {
            var hsl = RGBAByteColorToHSLAColorTests.RGBAColorToHSLAColor(red, green, blue, alpha);
            return HSLAColorToRGBAByteColorTests.HSLAColorToRGBAColor(Hue, hsl.saturation, hsl.luminance, hsl.alpha);
        }
    }
}
