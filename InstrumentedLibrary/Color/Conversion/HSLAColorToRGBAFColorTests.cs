using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Convert a color in HSLA to RGBA")]
    [Description("Convert a color in HSLA to RGBA.")]
    [SourceCodeLocationProvider]
    public static class HSLAColorToRGBAFColorTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(HSLAColorToRGBAFColorTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0f, 0f, 0f, 255f }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (100f, 100f, 100f, 0f), epsilon: 0f) },
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
        public static (double red, double green, double blue, double alpha) HSLAColorToRGBAFColor(double hue, double saturation, double luminance, double alpha)
            => HSLAColorToRGBAFColor1(hue, saturation, luminance, alpha);

        /// <summary>
        /// The rgb f create from hsl.
        /// </summary>
        /// <param name="hue">The h.</param>
        /// <param name="saturation">The s.</param>
        /// <param name="luminance">The l.</param>
        /// <param name="alpha"></param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        [DisplayName("Convert a color in HSLA to RGBA")]
        [Description("Convert a color in HSLA to RGBA.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double red, double green, double blue, double alpha) HSLAColorToRGBAFColor1(double hue, double saturation, double luminance, double alpha)
        {
            (double red, double green, double blue, double alpha) color = (0d, 0d, 0d, alpha);
            if (ValidateHSLATests.ValidateHSLA(hue, saturation, luminance, alpha) == true)
            {
                var c = (1d - Abs((2d * luminance) - 1d)) * saturation;
                var m = 1d * (luminance - (0.5d * c));
                var x = c * (1d - Abs(IEEERemainder(hue / 60d, 2) - 1d));
                if (hue >= 0d && hue < (HueMax / 6d))
                {
                    color = (c + m, x + m, m, alpha);
                }
                else if (hue >= (HueMax / 6d) && hue < (HueMax / 3d))
                {
                    color = (x + m, c + m, m, alpha);
                }
                else if (hue < (HueMax / 3d) && hue < (HueMax / 2d))
                {
                    color = (m, c + m, x + m, alpha);
                }
                else if (hue >= (HueMax / 2d) && hue < (2d * HueMax / 3d))
                {
                    color = (m, x + m, c + m, alpha);
                }
                else if (hue >= (2d * HueMax / 3d) && hue < (5d * HueMax / 6d))
                {
                    color = (x + m, m, c + m, alpha);
                }
                else if (hue >= (5d * HueMax / 6d) && hue < HueMax)
                {
                    color = (c + m, m, x + m, alpha);
                }
                else
                {
                    color = (m, m, m, alpha);
                }
            }
            return color;
        }
    }
}
