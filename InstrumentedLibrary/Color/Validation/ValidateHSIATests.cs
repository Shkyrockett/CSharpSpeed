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
    [DisplayName("Validate a HSIA color")]
    [Description("Validate a HSIA color.")]
    [SourceCodeLocationProvider]
    public static class ValidateHSIATests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(ValidateHSIATests))]
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
        /// Check whether a hue saturation intensity color is valid.
        /// </summary>
        /// <param name="h">The h.</param>
        /// <param name="s">The s.</param>
        /// <param name="i">The i.</param>
        /// <param name="a"></param>
        /// <returns>The <see cref="bool"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool ValidateHSIA(double h, double s, double i, double a)
            => ValidateHSIA_(h, s, i, a);

        /// <summary>
        /// Check whether a hue saturation intensity color is valid.
        /// </summary>
        /// <param name="h">The h.</param>
        /// <param name="s">The s.</param>
        /// <param name="i">The i.</param>
        /// <param name="a"></param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        [DisplayName("Validate a HSIA color")]
        [Description("Validate a HSIA color.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ValidateHSIA_(double h, double s, double i, double a)
        {
            return ValueBetweenDoubleTests.Between(a, PercentMin, PercentMax)
                && ValueBetweenDoubleTests.Between(h, HueMin, HueMax)
                && ValueBetweenDoubleTests.Between(s, PercentMin, PercentMax)
                && ValueBetweenDoubleTests.Between(i, PercentMin, PercentMax);
        }
    }
}
