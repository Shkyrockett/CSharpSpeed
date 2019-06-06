using CSharpSpeed;
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
    [DisplayName("Value Between Int")]
    [Description("Value Between Int.")]
    [SourceCodeLocationProvider]
    public static class ValueBetweenIntTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(ValueBetweenIntTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1, 2, 3 }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:true, epsilon: double.Epsilon) },
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
        /// <param name="value"></param>
        /// <param name="lowerLimit"></param>
        /// <param name="upperLimit"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool Between(int value, int lowerLimit, int upperLimit)
            => Between0(value, lowerLimit, upperLimit);

        /// <summary>
        /// Check whether the integer value is between lower and upper bounds.
        /// </summary>
        /// <param name="value">The <paramref name="value"/>.</param>
        /// <param name="lowerLimit">The lower limit.</param>
        /// <param name="upperLimit">The upper limit.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <acknowledgment>
        /// https://github.com/dystopiancode/colorspace-conversions/
        /// </acknowledgment>
        [DisplayName("Value Between Int")]
        [Description("Value Between Int.")]
        [Acknowledgment("https://github.com/dystopiancode/colorspace-conversions/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Between0(int value, int lowerLimit, int upperLimit)
        {
            return value >= lowerLimit && value <= upperLimit;
        }
    }
}
