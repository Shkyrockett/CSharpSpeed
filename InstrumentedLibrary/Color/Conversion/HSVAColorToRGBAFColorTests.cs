using CSharpSpeed;
using System;
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
    [DisplayName("Convert a color in HSVA to RGBA")]
    [Description("Convert a color in HSVA to RGBA.")]
    [SourceCodeLocationProvider]
    public static class HSVAColorToRGBAFColorTests
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
        /// <param name="saturaion"></param>
        /// <param name="value"></param>
        /// <param name="alpha"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double red, double green, double blue, double alpha) HSVAColorToRGBAFColor(double hue, double saturaion, double value, double alpha)
            => HSVAColorToRGBAFColor_(hue, saturaion, value, alpha);

        /// <summary>
        /// The rgb f create from hsv.
        /// </summary>
        /// <param name="hue">The h.</param>
        /// <param name="saturaion">The s.</param>
        /// <param name="value">The v.</param>
        /// <param name="alpha"></param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        [DisplayName("Convert a color in HSVA to RGBA")]
        [Description("Convert a color in HSVA to RGBA.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double red, double green, double blue, double alpha) HSVAColorToRGBAFColor_(double hue, double saturaion, double value, double alpha)
        {
            (double red, double green, double blue, double alpha) color = (0d, 0d, 0d, alpha);
            if (ValidateHSVATests.ValidateHSVA(hue, saturaion, value, alpha) == true)
            {
                var c = value * saturaion;
                var x = c * (1d - Abs(IEEERemainder(hue / 60d, 2) - 1d));
                var m = value - c;
                if (hue >= 0d && hue < 60d)
                {
                    color = (c + m, x + m, m, alpha);
                }
                else if (hue >= 60d && hue < 120d)
                {
                    color = (x + m, c + m, m, alpha);
                }
                else if (hue >= 120d && hue < 180d)
                {
                    color = (m, c + m, x + m, alpha);
                }
                else if (hue >= 180d && hue < 240d)
                {
                    color = (m, x + m, c + m, alpha);
                }
                else if (hue >= 240d && hue < 300d)
                {
                    color = (x + m, m, c + m, alpha);
                }
                else if (hue >= 300d && hue < 360d)
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
