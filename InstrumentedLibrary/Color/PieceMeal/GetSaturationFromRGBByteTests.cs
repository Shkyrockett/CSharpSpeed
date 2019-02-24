using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    // ToDo:
    public static class GetSaturationFromRGBByteTests
    {
        /// <summary>
        /// Get the saturation.
        /// </summary>
        /// <returns>The <see cref="double"/>.</returns>
        /// <remarks>
        /// https://referencesource.microsoft.com/#System.Drawing/commonui/System/Drawing/Color.cs
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetSaturation(byte red, byte green, byte blue)
        {
            var r = red / 255d;
            var g = green / 255d;
            var b = blue / 255d;
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

            var s = 0d;
            // if max == min, then there is no color and
            // the saturation is zero.
            if (max != min)
            {
                var l = (max + min) * 0.5d;

                s = l <= 0.5d ? (max - min) / (max + min) : (max - min) / (2d - max - min);
            }
            return s;
        }
    }
}
