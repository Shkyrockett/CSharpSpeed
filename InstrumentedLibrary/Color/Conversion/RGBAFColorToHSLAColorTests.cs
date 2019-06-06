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
    [DisplayName("Convert a color in RGBA to HSLA")]
    [Description("Convert a color in RGBA to HSLA.")]
    [SourceCodeLocationProvider]
    public static class RGBAFColorToHSLAColorTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(RGBAFColorToHSLAColorTests))]
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
        /// Given a Color (RGB class) in range of 0-255 Return H,S,L in range of 0-1
        /// </summary>
        /// <param name="alpha">Alpha value out.</param>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double hue, double saturation, double lumanance, double alpha) RGBAFColorToHSLAColor(double red, double green, double blue, double alpha)
            => RGBAFColorToHSLAColor_(red, green, blue, alpha);

        /// <summary>
        /// The hsl create from rgb f.
        /// </summary>
        /// <param name="red">The r.</param>
        /// <param name="green">The g.</param>
        /// <param name="blue">The b.</param>
        /// <param name="alpha"></param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        [DisplayName("Convert a color in RGBA to HSLA")]
        [Description("Convert a color in RGBA to HSLA.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double hue, double saturation, double lumanance, double alpha) RGBAFColorToHSLAColor_(double red, double green, double blue, double alpha)
        {
            (double hue, double saturation, double lumanance, double alpha) color = (0d, 0d, 0d, alpha);
            if (ValidateRGBAFloatTests.ValidateRGBAF(red, green, blue, alpha) == true)
            {
                var M = Max3Double.Max(red, green, blue);
                var m = Min3DoubleTests.Min(red, green, blue);
                var c = M - m;
                color.lumanance = 0.5d * (M + m);
                if (c != 0d)
                {
                    if (M == red)
                    {
                        color.hue = IEEERemainder((green - blue) / c, 6d);
                    }
                    else if (M == green)
                    {
                        color.hue = ((blue - red) / c) + 2d;
                    }
                    else/*if(M==b)*/
                    {
                        color.hue = ((red - green) / c) + 4d;
                    }
                    color.hue *= 60d;
                    color.saturation = c / (1d - Abs((2d * color.lumanance) - 1d));
                }
            }
            return color;
        }
    }
}
