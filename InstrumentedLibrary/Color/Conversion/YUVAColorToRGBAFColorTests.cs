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
    [DisplayName("Convert a color in YUVA to RGBA")]
    [Description("Convert a color in YUVA to RGBA.")]
    [SourceCodeLocationProvider]
    public static class YUVAColorToRGBAFColorTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(YUVAColorToRGBAFColorTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 0d, 1d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (100d, 100d, 100d, 0d), epsilon: 0d) },
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
        /// The rgb f create from yuv.
        /// </summary>
        /// <param name="y">The y.</param>
        /// <param name="u">The u.</param>
        /// <param name="v">The v.</param>
        /// <param name="alpha"></param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double red, double green, double blue, double alpha) YUVAColorToRGBAFColor(double y, double u, double v, double alpha)
            => YUVAColorToRGBAFColor1(y, u, v, alpha);

        /// <summary>
        /// The rgb f create from yuv.
        /// </summary>
        /// <param name="y">The y.</param>
        /// <param name="u">The u.</param>
        /// <param name="v">The v.</param>
        /// <param name="alpha"></param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        [DisplayName("Convert a color in YUVA to RGBA")]
        [Description("Convert a color in YUVA to RGBA.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double red, double green, double blue, double alpha) YUVAColorToRGBAFColor1(double y, double u, double v, double alpha)
        {
            if (!ValidateYUVATests.ValidateYUVA(y, u, v, alpha))
            {
                throw new ArgumentOutOfRangeException("A parameter is out of range.");
            }

            return (
                red: y + (1.140d * v),
                green: y - (0.395d * u) - (0.581d * v),
                blue: y + (2.032d * u), alpha
                );
        }
    }
}
