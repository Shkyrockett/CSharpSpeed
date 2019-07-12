using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Convert a color in RGBA to RGBAF")]
    [Description("Convert a color in RGBA to RGBAF.")]
    [SourceCodeLocationProvider]
    public static class RGBAColorToRGBAFColorTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(RGBAColorToRGBAFColorTests))]
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
        /// Converts a byte red green blue alpha color to the double floating point form.
        /// </summary>
        /// <param name="red">The red channel.</param>
        /// <param name="green">The green channel.</param>
        /// <param name="blue">The blue channel.</param>
        /// <param name="alpha">The alpha channel.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3, T4}"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double red, double green, double blue, double alpha) RGBAColorToRGBAFColor(byte red, byte green, byte blue, byte alpha)
            => RGBAColorToRGBAFColor1(red, green, blue, alpha);

        /// <summary>
        /// Converts a byte red green blue alpha color to the double floating point form.
        /// </summary>
        /// <param name="red">The red channel.</param>
        /// <param name="green">The green channel.</param>
        /// <param name="blue">The blue channel.</param>
        /// <param name="alpha">The alpha channel.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3, T4}"/>.</returns>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        [DisplayName("Convert a color in RGBA to RGBAF")]
        [Description("Convert a color in RGBA to RGBAF.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double red, double green, double blue, double alpha) RGBAColorToRGBAFColor1(byte red, byte green, byte blue, byte alpha)
        {
            if (!ValidateRGBAByteTests.ValidateRGBA(red, green, blue, alpha))
            {
                throw new ArgumentOutOfRangeException("A parameter is out of range.");
            }

            var d = 1d / RGBMax;
            return (
                red: red * d,
                green: green * d,
                blue: blue * d,
                alpha: alpha * d
                );
        }

        /// <summary>
        /// Convert an red green blue alpha byte color format to red green blue alpha color in double precision float format.
        /// </summary>
        /// <param name="red">The red component.</param>
        /// <param name="green">The green component.</param>
        /// <param name="blue">The blue component.</param>
        /// <param name="alpha">The alpha component.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3, T4}"/>.</returns>
        [DisplayName("Convert a color in RGBA to RGBAF")]
        [Description("Convert a color in RGBA to RGBAF.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double red, double green, double blue, double alpha) RGBAColorToRGBAFColor2(byte red, byte green, byte blue, byte alpha)
        {
            return (
                red: red / 255d,
                green: green / 255d,
                blue: blue / 255d,
                alpha: alpha / 255d
                );
        }
    }
}
