using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    public static class CYMKAColorToRGBAFColorTests
    {
        /// <summary>
        /// CMYK --> RGB
        /// Red   = 1-minimum(1,Cyan*(1-Black)+Black)
        /// Green = 1-minimum(1,Magenta*(1-Black)+Black)
        /// Blue  = 1-minimum(1,Yellow*(1-Black)+Black)
        /// </summary>
        /// <param name="cyan"></param>
        /// <param name="yellow"></param>
        /// <param name="magenta"></param>
        /// <param name="black"></param>
        /// <param name="alpha"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://www.codeproject.com/Articles/4488/XCmyk-CMYK-to-RGB-Calculator-with-source-code
        /// The algorithms for these routines were taken from: http://web.archive.org/web/20030416004239/http://www.neuro.sfc.keio.ac.jp/~aly/polygon/info/color-space-faq.html
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double red, double green, double blue, double alpha) CYMKAColorToRGBAFColor(byte cyan, byte yellow, byte magenta, byte black, byte alpha)
        {
            var c = cyan / 100d; //255d;
            var m = magenta / 100d; //255d;
            var y = yellow / 100d; //255d;
            var k = black / 100d; //255d;

            var r = (c * (1d - k)) + k;
            var g = (m * (1d - k)) + k;
            var b = (y * (1d - k)) + k;
            var a = (alpha / 100d * 255d) + 0.5d;

            r = ((1d - r) * 255d) + 0.5d;
            g = ((1d - g) * 255d) + 0.5d;
            b = ((1d - b) * 255d) + 0.5d;

            return ((byte)r, (byte)g, (byte)b, a);
        }
    }
}
