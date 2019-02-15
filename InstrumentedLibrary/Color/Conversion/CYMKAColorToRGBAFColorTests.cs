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
        public static (float red, float green, float blue, float alpha) CYMKAColorToRGBAFColor(byte cyan, byte yellow, byte magenta, byte black, byte alpha)
        {
            var c = cyan / 100f; //255f;
            var m = magenta / 100f; //255f;
            var y = yellow / 100f; //255f;
            var k = black / 100f; //255f;
            var a = alpha / 100f; //255f;

            var r = (c * (1f - k)) + k;
            var g = (m * (1f - k)) + k;
            var b = (y * (1f - k)) + k;
            var a2 = (a * (1f - k)) + k;

            r = ((1f - r) * 255f) + 0.5f;
            g = ((1f - g) * 255f) + 0.5f;
            b = ((1f - b) * 255f) + 0.5f;

            return (r, g, b, a2);
        }
    }
}
