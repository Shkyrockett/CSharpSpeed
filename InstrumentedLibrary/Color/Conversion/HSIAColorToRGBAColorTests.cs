using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    public static class HSIAColorToRGBAColorTests
    {
        /// <summary>
        /// Function example takes H, S, I, and a pointer to the
        /// in the calling function. After calling hsi2rgb
        /// the vector RGB will contain red, green, and blue
        /// calculated values.
        /// </summary>
        /// <param name="hue"></param>
        /// <param name="saturation"></param>
        /// <param name="intensity"></param>
        /// <param name="alpha"></param>
        /// <returns>RGB color-space converted vector.</returns>
        /// <acknowledgment>
        /// http://blog.saikoled.com/post/44677718712/how-to-convert-from-hsi-to-rgb-white
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (byte red, byte green, byte blue, byte alpha) HSIAColorToRGBAColor(double hue, double saturation, double intensity, double alpha)
        {
            var h = hue;
            var s = saturation;
            var i = intensity;

            h = IEEERemainder(h, 360d); // cycle H around to 0-360 degrees
            h = PI * h / 180d; // Convert to radians.
            s = s > 0 ? (s < 1d ? s : 1d) : 0d; // clamp S and I to interval [0,1]
            i = i > 0 ? (i < 1d ? i : 1d) : 0d;

            byte r, g, b;

            // Math! Thanks in part to Kyle Miller.
            if (h < 2.09439d)
            {
                r = (byte)(255d * i / 3d * (1d + (s * Cos(h) / Cos(1.047196667d - h))));
                g = (byte)(255d * i / 3d * (1d + (s * (1d - (Cos(h) / Cos(1.047196667d - h))))));
                b = (byte)(255d * i / 3d * (1d - s));
            }
            else if (h < 4.188787d)
            {
                h -= 2.09439d;
                g = (byte)(255d * i / 3d * (1 + (s * Cos(h) / Cos(1.047196667d - h))));
                b = (byte)(255d * i / 3d * (1 + (s * (1 - (Cos(h) / Cos(1.047196667d - h))))));
                r = (byte)(255d * i / 3d * (1 - s));
            }
            else
            {
                h -= 4.188787d;
                b = (byte)(255d * i / 3d * (1d + (s * Cos(h) / Cos(1.047196667d - h))));
                r = (byte)(255d * i / 3d * (1d + (s * (1d - (Cos(h) / Cos(1.047196667d - h))))));
                g = (byte)(255d * i / 3d * (1d - s));
            }

            return (r, g, b, (byte)(255 * alpha));
        }
    }
}
