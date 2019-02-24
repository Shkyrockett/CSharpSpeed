using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    // ToDo:
    public static class GetSaturationFromRGBFloatTests
    {
        /// <summary>
        /// Get the saturation.
        /// </summary>
        /// <returns>The <see cref="float"/>.</returns>
        /// <remarks>
        /// https://referencesource.microsoft.com/#System.Drawing/commonui/System/Drawing/Color.cs
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetSaturation(double red, double green, double blue)
        {
            var max = red;
            if (green > max)
            {
                max = green;
            }

            if (blue > max)
            {
                max = blue;
            }

            var min = red;
            if (green < min)
            {
                min = green;
            }

            if (blue < min)
            {
                min = blue;
            }

            var s = 0d;
            // if max == min, then there is no color and
            // the saturation is zero.
            if (max != min)
            {
                var l = (max + min) / 2d;
                s = l <= 0.5d ? (max - min) / (max + min) : (max - min) / (2d - max - min);
            }
            return s;
        }
    }
}
