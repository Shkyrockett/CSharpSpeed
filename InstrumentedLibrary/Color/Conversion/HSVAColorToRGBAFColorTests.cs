using System;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    public static class HSVAColorToRGBAFColorTests
    {
        /// <summary>
        /// The rgb f create from hsv.
        /// </summary>
        /// <param name="hue">The h.</param>
        /// <param name="saturaion">The s.</param>
        /// <param name="value">The v.</param>
        /// <param name="alpha"></param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double red, double green, double blue, double alpha) HSVAColorToRGBAFColor(double hue, double saturaion, double value, double alpha)
        {
            (double red, double green, double blue, double alpha) color = (0d, 0d, 0d, alpha);
            if (ValidateHSVATests.ValidateHSVA(hue, saturaion, value, alpha) == true)
            {
                var c = value * saturaion;
                var x = c * (1d - Abs(IEEERemainder(hue / 60d, 2) - 1d));
                var m = value - c;
                if (hue >= 0d && hue < 60d)
                {
                    color = (c + m, x + m, m, alpha);
                }
                else if (hue >= 60d && hue < 120d)
                {
                    color = (x + m, c + m, m, alpha);
                }
                else if (hue >= 120d && hue < 180d)
                {
                    color = (m, c + m, x + m, alpha);
                }
                else if (hue >= 180d && hue < 240d)
                {
                    color = (m, x + m, c + m, alpha);
                }
                else if (hue >= 240d && hue < 300d)
                {
                    color = (x + m, m, c + m, alpha);
                }
                else if (hue >= 300d && hue < 360d)
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
