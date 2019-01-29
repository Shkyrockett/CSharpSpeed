using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    public static class GetHueFromRGBByteTests
    {
        /// <summary>
        /// Get the hue.
        /// </summary>
        /// <returns>The <see cref="float"/>.</returns>
        /// <remarks>
        /// https://referencesource.microsoft.com/#System.Drawing/commonui/System/Drawing/Color.cs
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetHue(byte red, byte green, byte blue)
        {
            if (red == green && green == blue)
            {
                return 0; // 0 makes as good an UNDEFINED value as any
            }

            var r = red / 255d;
            var g = green / 255d;
            var b = blue / 255d;

            var hue = 0d;

            var max = r;
            var min = r;

            if (g > max)
            {
                max = g;
            }

            if (b > max)
            {
                max = b;
            }

            if (g < min)
            {
                min = g;
            }

            if (b < min)
            {
                min = b;
            }

            var delta = max - min;

            if (r == max)
            {
                hue = (g - b) / delta;
            }
            else if (g == max)
            {
                hue = 2d + ((b - r) / delta);
            }
            else if (b == max)
            {
                hue = 4d + ((r - g) / delta);
            }
            hue *= 60d;

            if (hue < 0d)
            {
                hue += 360d;
            }
            return hue;
        }
    }
}
