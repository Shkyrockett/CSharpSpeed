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
    [DisplayName("Convert a color in RGBA to HSIA")]
    [Description("Convert a color in RGBA to HSIA.")]
    [SourceCodeLocationProvider]
    public static class RGBAColorToHSIAColorTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(RGBAColorToHSIAColorTests))]
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
        /// 
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <param name="alpha"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double hue, double saturation, double intensity, double alpha) RGBAColorToHSIAColor(byte red, byte green, byte blue, byte alpha)
            => RGBAColorToHSIAColor1(red, green, blue, alpha);

        /// <summary>
        /// The hsi create from rgb.
        /// </summary>
        /// <param name="red">The r.</param>
        /// <param name="green">The g.</param>
        /// <param name="blue">The b.</param>
        /// <param name="alpha"></param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        [DisplayName("Convert a color in RGBA to HSIA")]
        [Description("Convert a color in RGBA to HSIA.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double hue, double saturation, double intensity, double alpha) RGBAColorToHSIAColor1(byte red, byte green, byte blue, byte alpha)
        {
            return RGBAFColorToHSIAColorTests.RGBAFColorToHSIAColor(red / 256d, green / 256d, blue / 256d, alpha / 256d);
        }
    }
}
