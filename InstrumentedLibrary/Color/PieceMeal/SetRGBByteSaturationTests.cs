﻿using CSharpSpeed;
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
    [DisplayName("Set the Saturation to an RGB color")]
    [Description("Set the Saturation to an RGB color.")]
    [SourceCodeLocationProvider]
    public static class SetRGBByteSaturationTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(SetRGBByteSaturationTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { (byte)0, (byte)0, (byte)0, (byte)255, 1d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: ((byte)0, (byte)0, (byte)0, (byte)255), epsilon: 0d) },
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
        /// Sets the absolute saturation level
        /// </summary>
        /// <remarks>Accepted values 0-1</remarks>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <param name="alpha"></param>
        /// <param name="Saturation">The saturation value to impose</param>
        /// <returns>An adjusted color</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (byte red, byte green, byte blue, byte alpha) SetSaturation(byte red, byte green, byte blue, byte alpha, double Saturation)
            => SetSaturation1(red, green, blue, alpha, Saturation);

        /// <summary>
        /// Sets the absolute saturation level
        /// </summary>
        /// <remarks>Accepted values 0-1</remarks>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <param name="alpha"></param>
        /// <param name="Saturation">The saturation value to impose</param>
        /// <returns>An adjusted color</returns>
        [DisplayName("Set the Saturation to an RGB color")]
        [Description("Set the Saturation to an RGB color.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (byte red, byte green, byte blue, byte alpha) SetSaturation1(byte red, byte green, byte blue, byte alpha, double Saturation)
        {
            var hsl = RGBAByteColorToHSLAColorTests.RGBAColorToHSLAColor(red, green, blue, alpha);
            return HSLAColorToRGBAByteColorTests.HSLAColorToRGBAColor(hsl.hue, Saturation, hsl.luminance, hsl.alpha);
        }
    }
}
