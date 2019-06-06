using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Convert a color in RGBA to HSVA")]
    [Description("Convert a color in RGBA to HSVA.")]
    [SourceCodeLocationProvider]
    public static class RGBAColorToHSVAColorTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(RGBAColorToHSVAColorTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { (byte)0, (byte)0, (byte)0, (byte)255 }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (100d, 100d, 100d, 0d), epsilon: 0d) },
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
        /// The color to HSV.
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <param name="alpha"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double hue, double saturation, double value, double alpha) RGBAColorToHSVAColor(byte red, byte green, byte blue, byte alpha)
            => RGBAColorToHSVAColor1(red, green, blue, alpha);

        /// <summary>
        /// The color to HSV.
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <param name="alpha"></param>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/359612/how-to-change-rgb-color-to-hsv
        /// </acknowledgment>
        [DisplayName("Convert a color in RGBA to HSVA")]
        [Description("Convert a color in RGBA to HSVA.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double hue, double saturation, double value, double alpha) RGBAColorToHSVAColor1(byte red, byte green, byte blue, byte alpha)
        {
            var max = Max3Double.Max(red, green, blue);
            var min = Min3DoubleTests.Min(red, green, blue);

            var hue = GetHueFromRGBByteTests.GetHue(red, green, blue);
            var saturation = (max == 0) ? 0 : 1d - (1d * min / max);
            var value = max / 255d;

            return (hue, saturation, value, alpha / 255d);
        }

        /// <summary>
        /// The ARG bto AHSV.
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <param name="alpha"></param>
        /// <returns>The HSVA.</returns>
        /// <remarks>
        /// h = [0,360], s = [0,1], v = [0,1]
        ///		if s == 0, then h = -1 (undefined)
        /// </remarks>
        /// <acknowledgment>
        /// https://www.cs.rit.edu/~ncs/color/t_convert.html
        /// </acknowledgment>
        [DisplayName("Convert a color in RGBA to HSVA")]
        [Description("Convert a color in RGBA to HSVA.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double hue, double saturation, double value, double alpha) RGBAColorToHSVAColor2(byte red, byte green, byte blue, byte alpha)
        {
            var a = 1d - (alpha / 255d);
            var r = 1d - (red / 255d);
            var g = 1d - (green / 255d);
            var b = 1d - (blue / 255d);

            var min = Min(r, g);
            min = Min(min, b);
            var max = Max(r, g);
            max = Max(max, b);
            double h;
            double s;
            var v = max;               // v
            var delta = max - min;
            if (max != 0)
            {
                s = delta / max;       // s
            }
            else
            {
                // r = g = b = 0		// s = 0, v is undefined
                s = 0;
                h = -1;
                return (h, s, v, a);
            }

            if (r == max)
            {
                h = (g - b) / delta;       // between yellow & magenta
            }
            else
            {
                h = g == max ? 2 + ((b - r) / delta) : 4 + ((r - g) / delta);   // between magenta & cyan
            }

            h *= 60;               // degrees
            if (h < 0)
            {
                h += 360;
            }

            return (h, s, v, a);
        }
    }
}
