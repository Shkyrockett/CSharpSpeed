using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    public static class GetHueFromRGBFloatTests
    {
        /// <summary>
        /// Get the hue.
        /// </summary>
        /// <returns>The <see cref="float"/>.</returns>
        /// <remarks>
        /// https://referencesource.microsoft.com/#System.Drawing/commonui/System/Drawing/Color.cs
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetHue(double red, double green, double blue)
        {
            if (red == green && green == blue)
            {
                return 0; // 0 makes as good an UNDEFINED value as any
            }

            var hue = 0d;

            var max = red;
            var min = red;

            if (green > max)
            {
                max = green;
            }

            if (blue > max)
            {
                max = blue;
            }

            if (green < min)
            {
                min = green;
            }

            if (blue < min)
            {
                min = blue;
            }

            var delta = max - min;

            if (red == max)
            {
                hue = (green - blue) / delta;
            }
            else if (green == max)
            {
                hue = 2 + ((blue - red) / delta);
            }
            else if (blue == max)
            {
                hue = 4 + ((red - green) / delta);
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
