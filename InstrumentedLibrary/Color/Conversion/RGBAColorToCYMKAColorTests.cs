using System;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    public static class RGBAColorToCYMKAColorTests
    {
        /// <summary>
        /// Convert an alpha red green blue byte color format to alpha cyan yellow magenta black format.
        /// </summary>
        /// <param name="red">The red component.</param>
        /// <param name="green">The green component.</param>
        /// <param name="blue">The blue component.</param>
        /// <param name="alpha">The alpha component.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3, T4, T5}"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (byte cyan, byte yellow, byte magenta, byte black, byte alpha) RGBAColorToCYMKAColor(byte red, byte green, byte blue, byte alpha)
        {
            return RGBAFColorToCYMKAColorTests.RGBAFColorToCYMKAColor(red / 255d, green / 255d, blue / 255d, alpha / 255d);
        }

        /// <summary>
        /// RGB --> CMYK
        /// Black   = minimum(1-Red,1-Green,1-Blue)
        /// Cyan    = (1-Red-Black)/(1-Black)
        /// Magenta = (1-Green-Black)/(1-Black)
        /// Yellow  = (1-Blue-Black)/(1-Black)
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <param name="alpha"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://www.codeproject.com/Articles/4488/XCmyk-CMYK-to-RGB-Calculator-with-source-code
        /// The algorithms for these routines were taken from: http://web.archive.org/web/20030416004239/http://www.neuro.sfc.keio.ac.jp/~aly/polygon/info/color-space-faq.html
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (byte cyan, byte yellow, byte magenta, byte black, byte alpha) RGBAColorToCYMKAColor2(byte red, byte green, byte blue, byte alpha)
        {
            var r = 1d - (red / 255d);
            var g = 1d - (green / 255d);
            var b = 1d - (blue / 255d);

            var K = r < g ? r : g;
            if (b < K)
            {
                K = b;
            }

            var c = (r - K) / (1d - K);
            var m = (g - K) / (1d - K);
            var y = (b - K) / (1d - K);

            c = (c * 100d) + 0.5d;
            m = (m * 100d) + 0.5d;
            y = (y * 100d) + 0.5d;
            K = (K * 100d) + 0.5d;

            return ((byte)c, (byte)y, (byte)m, (byte)K, alpha);
        }
    }
}
