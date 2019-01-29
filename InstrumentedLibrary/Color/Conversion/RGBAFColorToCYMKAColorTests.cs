using System;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    public static class RGBAFColorToCYMKAColorTests
    {
        /// <summary>
        /// Convert an alpha red green blue color in double precision float format to alpha cyan yellow magenta black color format.
        /// </summary>
        /// <param name="red">The red.</param>
        /// <param name="green">The green.</param>
        /// <param name="blue">The blue.</param>
        /// <param name="alpha">The alpha.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3, T4, T5}"/>.</returns>
        /// <remarks>
        /// Black   = minimum(1-Red, 1-Green, 1-Blue)
        /// Cyan    = (1-Red-Black)/(1-Black)
        /// Magenta = (1-Green-Black)/(1-Black)
        /// Yellow  = (1-Blue-Black)/(1-Black)
        /// </remarks>
        /// <acknowledgment>
        /// http://www.codeproject.com/Articles/4488/XCmyk-CMYK-to-RGB-Calculator-with-source-code
        /// The algorithms for these routines were taken from: http://web.archive.org/web/20030416004239/http://www.neuro.sfc.keio.ac.jp/~aly/polygon/info/color-space-faq.html
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (byte cyan, byte yellow, byte magenta, byte black, byte alpha) RGBAFColorToCYMKAColor(double red, double green, double blue, double alpha)
        {
            var k = red < green ? red : green;
            k = blue < k ? blue : k;
            var d = 1d / (1d - k);

            // ToDo: Figure out if messing with alpha like this is worth while.
            var a = (1d - alpha - k) * d;
            var c = (1d - red - k) * d;
            var m = (1d - green - k) * d;
            var y = (1d - blue - k) * d;

            return (
                cyan: (byte)((c * 100) + 0.5),
                yellow: (byte)((y * 100) + 0.5),
                magenta: (byte)((m * 100) + 0.5),
                black: (byte)((k * 100) + 0.5),
                alpha: (byte)((a * 100) + 0.5)
                );
        }
    }
}
