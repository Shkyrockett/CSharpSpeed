using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Convert a color in CYMKA to RGBA")]
    [Description("Convert a color in CYMKA to RGBA.")]
    [SourceCodeLocationProvider]
    public static class CYMKAColorToRGBAFColorTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(ToDegreesTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { (byte)0, (byte)0, (byte)0, (byte)0, (byte)255 }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (100f, 100f, 100f, 0f), epsilon: 0f) },
            };

            var results = new List<SpeedTester>();
            foreach (var method in HelperExtensions.ListStaticMethodsWithAttribute(MethodBase.GetCurrentMethod().DeclaringType, typeof(SourceCodeLocationProviderAttribute)))
            {
                var methodDescription = ((DescriptionAttribute)method.GetCustomAttribute(typeof(DescriptionAttribute)))?.Description;
                results.Add(new SpeedTester(method, methodDescription, tests));
            }
            return results;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cyan"></param>
        /// <param name="yellow"></param>
        /// <param name="magenta"></param>
        /// <param name="black"></param>
        /// <param name="alpha"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (float red, float green, float blue, float alpha) CYMKAColorToRGBAFColor(byte cyan, byte yellow, byte magenta, byte black, byte alpha)
            => CYMKAColorToRGBAFColor_(cyan, yellow, magenta, black, alpha);

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
        [DisplayName("Convert a color in CYMKA to RGBA")]
        [Description("Convert a color in CYMKA to RGBA.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (float red, float green, float blue, float alpha) CYMKAColorToRGBAFColor_(byte cyan, byte yellow, byte magenta, byte black, byte alpha)
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
