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
    /// Convert a color in RGBA to CYMKA
    /// </summary>
    [DisplayName("Convert a color in RGBA to CYMKA")]
    [Description("Convert a color in RGBA to CYMKA.")]
    [SourceCodeLocationProvider]
    public static class RGBAColorToCYMKAColorTests
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
                { new object[] { (byte)0, (byte)0, (byte)0, (byte)255 }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: ((byte)100, (byte)100, (byte)100, (byte)0, (byte)0), epsilon: 0d) },
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
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <param name="alpha"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (byte cyan, byte yellow, byte magenta, byte black, byte alpha) RGBAColorToCYMKAColor(byte red, byte green, byte blue, byte alpha)
            => RGBAColorToCYMKAColor2(red, green, blue, alpha);

        /// <summary>
        /// Convert an alpha red green blue byte color format to alpha cyan yellow magenta black format.
        /// </summary>
        /// <param name="red">The red component.</param>
        /// <param name="green">The green component.</param>
        /// <param name="blue">The blue component.</param>
        /// <param name="alpha">The alpha component.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3, T4, T5}"/>.</returns>
        [DisplayName("Convert a color in RGBA to CYMKA")]
        [Description("Convert a color in RGBA to CYMKA.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (byte cyan, byte yellow, byte magenta, byte black, byte alpha) RGBAColorToCYMKAColor1(byte red, byte green, byte blue, byte alpha)
        {
            return RGBAFColorToCYMKAColorTests.RGBAFColorToCYMKAColor(red / 255f, green / 255f, blue / 255f, alpha / 255f);
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
        [DisplayName("Convert a color in RGBA to CYMKA")]
        [Description("Convert a color in RGBA to CYMKA.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (byte cyan, byte yellow, byte magenta, byte black, byte alpha) RGBAColorToCYMKAColor2(byte red, byte green, byte blue, byte alpha)
        {
            const float multiplier = 100f;

            var r = 1f - (red / 255f);
            var g = 1f - (green / 255f);
            var b = 1f - (blue / 255f);
            var a = alpha / 255f;

            var k = r < g ? r : g;
            k = b < k ? b : k;

            var d = 1f / (1f - k);

            var c = (r - k) * d;
            var m = (g - k) * d;
            var y = (b - k) * d;

            c = (c * multiplier) + 0.5f;
            m = (m * multiplier) + 0.5f;
            y = (y * multiplier) + 0.5f;
            k = (k * multiplier) + 0.5f;
            a = (a * multiplier) + 0.5f;

            return ((byte)c, (byte)y, (byte)m, (byte)k, (byte)a);
        }
    }
}
