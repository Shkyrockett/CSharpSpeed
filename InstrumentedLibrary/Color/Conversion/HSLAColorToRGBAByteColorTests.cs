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
    /// 
    /// </summary>
    [DisplayName("Convert a color in HSLA to RGBA")]
    [Description("Convert a color in HSLA to RGBA.")]
    [SourceCodeLocationProvider]
    public static class HSLAColorToRGBAByteColorTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(HSLAColorToRGBAByteColorTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 0d, 1d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: ((byte)100, (byte)100, (byte)100, (byte)0), epsilon: (byte)0) },
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
        /// <param name="hue"></param>
        /// <param name="saturation"></param>
        /// <param name="luminance"></param>
        /// <param name="alpha"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (byte red, byte green, byte blue, byte alpha) HSLAColorToRGBAColor(double hue, double saturation, double luminance, double alpha)
            => HSLAColorToRGBAColor1(hue, saturation, luminance, alpha);

        /// <summary>
        /// Given H,S,L in range of 0-1
        /// Returns a Color (RGB class) in range of 0-255
        /// </summary>
        /// <param name="hue">Hue value.</param>
        /// <param name="saturation">Saturation value.</param>
        /// <param name="luminance">Luminance value.</param>
        /// <param name="alpha">Alpha value.</param>
        /// <returns>An ARGB color structure.</returns>
        /// <acknowledgment>
        /// http://www.geekymonkey.com/Programming/CSharp/RGB2HSL_HSL2RGB.htm
        /// </acknowledgment>
        [DisplayName("Convert a color in HSLA to RGBA")]
        [Description("Convert a color in HSLA to RGBA.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (byte red, byte green, byte blue, byte alpha) HSLAColorToRGBAColor1(double hue, double saturation, double luminance, double alpha)
        {
            // default to gray
            var red = luminance;
            var green = luminance;
            var blue = luminance;
            var vertex = (luminance <= 0.5d) ? (luminance * (1d + saturation)) : (luminance + saturation - (luminance * saturation));

            if (vertex > 0)
            {
                var m = luminance + luminance - vertex;
                var sv = (vertex - m) / vertex;
                hue *= 6d;
                var sextant = (int)hue;
                var fract = hue - sextant;
                var vsf = vertex * sv * fract;
                var mid1 = m + vsf;
                var mid2 = vertex - vsf;
                switch (sextant)
                {
                    case 0:
                        red = vertex;
                        green = mid1;
                        blue = m;
                        break;
                    case 1:
                        red = mid2;
                        green = vertex;
                        blue = m;
                        break;
                    case 2:
                        red = m;
                        green = vertex;
                        blue = mid1;
                        break;
                    case 3:
                        red = m;
                        green = mid2;
                        blue = vertex;
                        break;
                    case 4:
                        red = mid1;
                        green = m;
                        blue = vertex;
                        break;
                    case 5:
                        red = vertex;
                        green = m;
                        blue = mid2;
                        break;
                }
            }

            return (
                Convert.ToByte(red * 255d),
                Convert.ToByte(green * 255d),
                Convert.ToByte(blue * 255d),
                Convert.ToByte(alpha * 255d)
                );
        }
    }
}
