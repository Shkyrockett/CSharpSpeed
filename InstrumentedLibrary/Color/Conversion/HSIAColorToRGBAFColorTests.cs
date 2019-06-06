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
    [DisplayName("Convert a color in HSIA to RGBA")]
    [Description("Convert a color in HSIA to RGBA.")]
    [SourceCodeLocationProvider]
    public static class HSIAColorToRGBAFColorTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(HSIAColorToRGBAFColorTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 0d, 0d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (100d, 100d, 100d, 0d), epsilon: 0d) },
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
        /// <param name="intensity"></param>
        /// <param name="alpha"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double red, double green, double blue, double alpha) HSIAColorToRGBAFColor(double hue, double saturation, double intensity, double alpha)
            => HSIAColorToRGBAFColor1(hue, saturation, intensity, alpha);

        /// <summary>
        /// The rgbaf create from hsi.
        /// </summary>
        /// <param name="hue">The h.</param>
        /// <param name="saturation">The s.</param>
        /// <param name="intensity">The i.</param>
        /// <param name="alpha"></param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <remarks>
        /// https://github.com/dystopiancode/colorspace-conversions/
        /// Correction from: https://gist.github.com/rzhukov/9129585
        /// </remarks>
        [DisplayName("Convert a color in HSIA to RGBA")]
        [Description("Convert a color in HSIA to RGBA.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double red, double green, double blue, double alpha) HSIAColorToRGBAFColor1(double hue, double saturation, double intensity, double alpha)
        {
            if (!ValidateHSIATests.ValidateHSIA(hue, saturation, intensity, alpha))
            {
                throw new ArgumentOutOfRangeException("A parameter is out of range.");
            }

            var x = intensity * (1d - saturation);
            if (hue < 2d * PI / 3d)
            {
                var y = intensity * (1d + (saturation * Cos(hue) / Cos((PI / 3d) - hue)));
                var z = (3d * intensity) - (x + y);
                return (red: y, green: z, blue: x, alpha);
            }
            else if (hue < 4d * PI / 3d)
            {
                var y = intensity * (1d + (saturation * Cos(hue - (2d * PI / 3d)) / Cos((PI / 3d) - (hue - (2d * PI / 3d)))));
                var z = (3d * intensity) - (x + y);
                return (red: x, green: y, blue: z, alpha);
            }
            else
            {
                var y = intensity * (1d + (saturation * Cos(hue - (4d * PI / 3d)) / Cos((PI / 3d) - (hue - (4d * PI / 3d)))));
                var z = (3 * intensity) - (x + y);
                return (red: z, green: x, blue: y, alpha);
            }
        }

        /// <summary>
        /// The rgb f create from hsi.
        /// </summary>
        /// <param name="hue"></param>
        /// <param name="saturation"></param>
        /// <param name="intensity"></param>
        /// <param name="alpha"></param>
        /// <returns>The RGBA.</returns>
        /// <acknowledgment>
        /// http://dystopiancode.blogspot.com/2012/02/hsi-rgb-conversion-algorithms-in-c.html
        /// https://github.com/dystopiancode/colorspace-conversions
        /// </acknowledgment>
        [DisplayName("Convert a color in HSIA to RGBA")]
        [Description("Convert a color in HSIA to RGBA.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double red, double green, double blue, double alpha) HSIAColorToRGBAFColor2(double hue, double saturation, double intensity, double alpha)
        {
            const double HueUpperLimit = 360d;
            var h = hue;
            var s = saturation;
            var i = intensity;
            double r;
            double g;
            double b;
            if (h >= 0d && h <= (HueUpperLimit / 3d))
            {
                b = i * (1d - s) / 3d;
                r = i * (s * Cos(h) / Cos(60d - h)) / 3d;
                g = i - (b + r);
            }
            else if (h > (HueUpperLimit / 3d) && h <= (2d * HueUpperLimit / 3d))
            {
                h -= HueUpperLimit / 3d;
                r = i * (1d - s) / 3d;
                g = i * (s * Cos(h) / Cos(60d - h)) / 3d;
                b = i - (g + r);
            }
            else /* h>240 h<360 */
            {
                h -= 2d * HueUpperLimit / 3d;
                g = i * (1d - s) / 3d;
                b = i * (s * Cos(h) / Cos(60d - h)) / 3d;
                r = i - (g + b);
            }

            return (r, g, b, alpha);
        }
    }
}
