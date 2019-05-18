using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// Convert a color in CYMKA to RGBA.
    /// </summary>
    [DisplayName("Convert a color in CYMKA to RGBA")]
    [Description("Convert a color in CYMKA to RGBA.")]
    [SourceCodeLocationProvider]
    public static class CYMKAColorToRGBAColorTests
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
                { new object[] { (byte)0, (byte)0, (byte)0, (byte)0, (byte)255 }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: ((byte)100, (byte)100, (byte)100, (byte)0, (byte)0, (byte)0), epsilon: (byte)0) },
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
        public static (byte red, byte green, byte blue, byte alpha) CYMKAColorToRGBAColor(byte cyan, byte yellow, byte magenta, byte black, byte alpha)
            => CYMKAColorToRGBAColor_(cyan, yellow, magenta, black, alpha);

        /// <summary>
        /// Convert an alpha cyan yellow magenta black color format to alpha red green blue byte color format.
        /// </summary>
        /// <param name="cyan">The cyan.</param>
        /// <param name="yellow">The yellow.</param>
        /// <param name="magenta">The magenta.</param>
        /// <param name="black">The black.</param>
        /// <param name="alpha">The alpha.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <remarks>
        /// Red   = 1-minimum(1,Cyan*(1-Black)+Black)
        /// Green = 1-minimum(1,Magenta*(1-Black)+Black)
        /// Blue  = 1-minimum(1,Yellow*(1-Black)+Black)
        /// </remarks>
        /// <acknowledgment>
        /// http://www.codeproject.com/Articles/4488/XCmyk-CMYK-to-RGB-Calculator-with-source-code
        /// The algorithms for these routines were taken from: http://web.archive.org/web/20030416004239/http://www.neuro.sfc.keio.ac.jp/~aly/polygon/info/color-space-faq.html
        /// </acknowledgment>
        [DisplayName("Convert a color in CYMKA to RGBA")]
        [Description("Convert a color in CYMKA to RGBA.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (byte red, byte green, byte blue, byte alpha) CYMKAColorToRGBAColor_(byte cyan, byte yellow, byte magenta, byte black, byte alpha)
        {
            var d = 1d / 100d;//255d;

            // ToDo: Figure out if messing with alpha like this is worth while.
            var a = alpha * d;
            var c = cyan * d;
            var m = magenta * d;
            var y = yellow * d;
            var k = black * d;

            a = (a * (1d - k)) + k;
            var r = (c * (1d - k)) + k;
            var g = (m * (1d - k)) + k;
            var b = (y * (1d - k)) + k;

            return (
                red: (byte)(((1d - r) * 255d) + 0.5d),
                green: (byte)(((1d - g) * 255d) + 0.5d),
                blue: (byte)(((1d - b) * 255d) + 0.5d),
                alpha: (byte)(((1d - a) * 255d) + 0.5d)
                );
        }
    }
}
