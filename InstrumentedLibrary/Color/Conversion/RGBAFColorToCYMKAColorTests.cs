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
    /// Convert a color in RGBA Float to CYMKA byte.
    /// </summary>
    [DisplayName("Convert a color in RGBA Float to CYMKA byte")]
    [Description("Convert a color in RGBA Float to CYMKA byte.")]
    [SourceCodeLocationProvider]
    public static class RGBAFColorToCYMKAColorTests
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
                { new object[] { (byte)0, (byte)0, (byte)0, (byte)255 }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: ((byte)1, (byte)1, (byte)1, (byte)0, (byte)0), epsilon: 0d) },
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
        public static (byte cyan, byte yellow, byte magenta, byte black, byte alpha) RGBAFColorToCYMKAColor(float red, float green, float blue, float alpha)
            => RGBAFColorToCYMKAColor0(red, green, blue, alpha);

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
        [DisplayName("Convert a color in RGBA Float to CYMKA byte")]
        [Description("Convert a color in RGBA Float to CYMKA byte.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (byte cyan, byte yellow, byte magenta, byte black, byte alpha) RGBAFColorToCYMKAColor0(float red, float green, float blue, float alpha)
        {
            var k = 1 - red < 1 - green ? 1 - red : 1 - green;
            k = 1 - blue < k ? 1 - blue : k;

            var d = 1f / (1f - k);

            var c = (1f - red - k) * d;
            var m = (1f - green - k) * d;
            var y = (1f - blue - k) * d;
            // ToDo: Figure out if messing with alpha like this is worth while.
            var a = alpha;

            return (
                cyan: (byte)((c * 100f) + 0.5f),
                yellow: (byte)((y * 100f) + 0.5f),
                magenta: (byte)((m * 100f) + 0.5f),
                black: (byte)((k * 100f) + 0.5f),
                alpha: (byte)((a * 100f) + 0.5f)
                );
        }
    }
}
