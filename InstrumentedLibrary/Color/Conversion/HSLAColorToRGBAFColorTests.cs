using System;
using System.Runtime.CompilerServices;
using static System.Math;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    public static class HSLAColorToRGBAFColorTests
    {
        /// <summary>
        /// The rgb f create from hsl.
        /// </summary>
        /// <param name="hue">The h.</param>
        /// <param name="saturation">The s.</param>
        /// <param name="luminance">The l.</param>
        /// <param name="alpha"></param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double red, double green, double blue, double alpha) HSLAColorToRGBAFColor(double hue, double saturation, double luminance, double alpha)
        {
            (double red, double green, double blue, double alpha) color = (0d, 0d, 0d, alpha);
            if (ValidateHSLATests.ValidateHSLA(hue, saturation, luminance, alpha) == true)
            {
                var c = (1d - Abs((2d * luminance) - 1d)) * saturation;
                var m = 1d * (luminance - (0.5d * c));
                var x = c * (1d - Abs(IEEERemainder(hue / 60d, 2) - 1d));
                if (hue >= 0d && hue < (HueMax / 6d))
                {
                    color = (c + m, x + m, m, alpha);
                }
                else if (hue >= (HueMax / 6d) && hue < (HueMax / 3d))
                {
                    color = (x + m, c + m, m, alpha);
                }
                else if (hue < (HueMax / 3d) && hue < (HueMax / 2d))
                {
                    color = (m, c + m, x + m, alpha);
                }
                else if (hue >= (HueMax / 2d) && hue < (2d * HueMax / 3d))
                {
                    color = (m, x + m, c + m, alpha);
                }
                else if (hue >= (2d * HueMax / 3d) && hue < (5d * HueMax / 6d))
                {
                    color = (x + m, m, c + m, alpha);
                }
                else if (hue >= (5d * HueMax / 6d) && hue < HueMax)
                {
                    color = (c + m, m, x + m, alpha);
                }
                else
                {
                    color = (m, m, m, alpha);
                }
            }
            return color;
        }
    }
}
