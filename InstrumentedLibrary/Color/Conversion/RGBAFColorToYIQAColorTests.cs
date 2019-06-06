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
    [DisplayName("Convert a color in RGBA to YIQA")]
    [Description("Convert a color in RGBA to YIQA.")]
    [SourceCodeLocationProvider]
    public static class RGBAFColorToYIQAColorTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(RGBAFColorToYIQAColorTests))]
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
        /// Converts a byte red green blue alpha color to the double floating point form.
        /// </summary>
        /// <param name="red">The red channel.</param>
        /// <param name="green">The green channel.</param>
        /// <param name="blue">The blue channel.</param>
        /// <param name="alpha">The alpha channel.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3, T4}"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double y, double i, double q, double alpha) RGBAFColorToYIQAColor(double red, double green, double blue, double alpha)
            => RGBAFColorToYIQAColor1(red, green, blue, alpha);

        /// <summary>
        /// The yiq create from rgb f.
        /// </summary>
        /// <param name="red">The r.</param>
        /// <param name="green">The g.</param>
        /// <param name="blue">The b.</param>
        /// <param name="alpha"></param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <remarks>
        /// https://github.com/dystopiancode/colorspace-conversions/
        /// Correction from: https://stackoverflow.com/q/22131920
        /// </remarks>
        [DisplayName("Convert a color in RGBA to YIQA")]
        [Description("Convert a color in RGBA to YIQA.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double y, double i, double q, double alpha) RGBAFColorToYIQAColor1(double red, double green, double blue, double alpha)
        {
            if (!ValidateRGBAFloatTests.ValidateRGBAF(red, green, blue, alpha))
            {
                throw new ArgumentOutOfRangeException("A parameter is out of range.");
            }

            return (
                y: (0.299900d * red) + (0.587000d * green) + (0.114000d * blue),
                i: (0.595716d * red) - (0.274453d * green) - (0.321264d * blue),
                q: (0.211456d * red) - (0.522591d * green) + (0.311350d * blue),
                alpha
                );
        }
    }
}
