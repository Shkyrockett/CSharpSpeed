using CSharpSpeed;
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
    [DisplayName("Validate a HSLA color")]
    [Description("Validate a HSLA color.")]
    [SourceCodeLocationProvider]
    public static class ValidateHSLATests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(ValidateHSLATests))]
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
        /// Check whether a hue saturation luminance color is valid.
        /// </summary>
        /// <param name="h">The h.</param>
        /// <param name="s">The s.</param>
        /// <param name="l">The l.</param>
        /// <param name="a"></param>
        /// <returns>The <see cref="bool"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool ValidateHSLA(double h, double s, double l, double a)
            => ValidateHSLA_(h, s, l, a);

        /// <summary>
        /// Check whether a hue saturation luminance color is valid.
        /// </summary>
        /// <param name="h">The h.</param>
        /// <param name="s">The s.</param>
        /// <param name="l">The l.</param>
        /// <param name="a"></param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        [DisplayName("Validate a HSLA color")]
        [Description("Validate a HSLA color.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ValidateHSLA_(double h, double s, double l, double a)
        {
            return ValueBetweenDoubleTests.Between(a, PercentMin, PercentMax)
                       && ValueBetweenDoubleTests.Between(h, HueMin, HueMax)
                       && ValueBetweenDoubleTests.Between(s, PercentMin, PercentMax)
                       && ValueBetweenDoubleTests.Between(l, PercentMin, PercentMax);
        }
    }
}
