using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    // ToDo:
    public static class SetRGBByteLuminanceTests
    {
        /// <summary>
        /// Sets the absolute brightness of a color
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <param name="alpha"></param>
        /// <param name="luminance">The luminance level to impose</param>
        /// <returns>an adjusted color</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (byte red, byte green, byte blue, byte alpha) SetLuminance(byte red, byte green, byte blue, byte alpha, double luminance)
        {
            var hsl = RGBAByteColorToHSLAColorTests.RGBAColorToHSLAColor(red, green, blue, alpha);
            return HSLAColorToRGBAByteColorTests.HSLAColorToRGBAColor(hsl.hue, hsl.saturation, luminance, hsl.alpha);
        }
    }
}
