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
    public static class RGBAFColorToRGBAColorTests
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
                { new object[] { 0d, 0d, 0d, 1d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: ((byte)100, (byte)100, (byte)100, (byte)0), epsilon: (byte)0) },
            };

            var results = new List<SpeedTester>();
            foreach (var method in ReflectionHelper.ListStaticMethodsWithAttribute(MethodBase.GetCurrentMethod().DeclaringType, typeof(SourceCodeLocationProviderAttribute)))
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
        public static (byte red, byte green, byte blue, byte alpha) RGBAFColorToRGBAColor(double red, double green, double blue, double alpha)
            => RGBAFColorToRGBAColor1(red, green, blue, alpha);

        /// <summary>
        /// Convert an red green blue alpha color from double floating point format to byte.
        /// </summary>
        /// <param name="red">The r.</param>
        /// <param name="green">The g.</param>
        /// <param name="blue">The b.</param>
        /// <param name="alpha"></param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        [DisplayName("Convert a color in RGBA to RGBAF")]
        [Description("Convert a color in RGBA to RGBAF.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (byte red, byte green, byte blue, byte alpha) RGBAFColorToRGBAColor1(double red, double green, double blue, double alpha)
        {
            if (!ValidateRGBAFloatTests.ValidateRGBAF(red, green, blue, alpha))
            {
                throw new ArgumentOutOfRangeException("A parameter is out of range.");
            }

            var d = RGBMax + 0.5d;
            return (
                red: (byte)(red * d),
                green: (byte)(green * d),
                blue: (byte)(blue * d),
                alpha: (byte)(alpha * d)
                );
        }

        /// <summary>
        /// Convert an red green blue alpha color from double floating point format to byte.
        /// </summary>
        /// <param name="tuple"></param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        //[DisplayName("Convert a color in RGBA to RGBAF")]
        //[Description("Convert a color in RGBA to RGBAF.")]
        //[SourceCodeLocationProvider]
        //[DebuggerStepThrough]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (byte red, byte green, byte blue, byte alpha) RGBAFColorToRGBAColor1((double red, double green, double blue, double alpha) tuple)
        {
            if (!ValidateRGBAFloatTests.ValidateRGBAF(tuple.red, tuple.green, tuple.blue, tuple.alpha))
            {
                throw new ArgumentOutOfRangeException(nameof(tuple), "A parameter is out of range.");
            }

            var d = RGBMax + 0.5d;
            return (
                red: (byte)(tuple.red * d),
                green: (byte)(tuple.green * d),
                blue: (byte)(tuple.blue * d),
                alpha: (byte)(tuple.alpha * d)
                );
        }
    }
}
