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
    [DisplayName("Check whether a value is between two others")]
    [Description("Check whether a value is between two others.")]
    [SourceCodeLocationProvider]
    public static class ValueBetweenTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(LineSegmentsOverlapTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 15000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 0d, 3d }, new TestCaseResults(description: "The test value is between.", trials: trials, expectedReturnValue: true) },
                { new object[] { 0d, 1d, 3d }, new TestCaseResults(description: "The test value is before.", trials: trials, expectedReturnValue: false) },
                { new object[] { 3d, 1d, 2d }, new TestCaseResults(description: "The test value is after.", trials: trials, expectedReturnValue: false) },
                { new object[] { 2d, 1d, 2d }, new TestCaseResults(description: "The test value is at the end.", trials: trials, expectedReturnValue: true) },
                { new object[] { 1d, 1d, 2d }, new TestCaseResults(description: "The test value is at the beginning.", trials: trials, expectedReturnValue: true) },
                { new object[] { 1d, 3d, 0d }, new TestCaseResults(description: "The test value is between, and the end is smaller than the beginning.", trials: trials, expectedReturnValue: true) },
                { new object[] { 0d, 3d, 1d }, new TestCaseResults(description: "The test value is before, and the end is smaller than the beginning.", trials: trials, expectedReturnValue: false) },
                { new object[] { 3d, 2d, 1d }, new TestCaseResults(description: "The test value is after, and the end is smaller than the beginning.", trials: trials, expectedReturnValue: false) },
                { new object[] { 2d, 2d, 1d }, new TestCaseResults(description: "The test value is at the end, and the end is smaller than the beginning.", trials: trials, expectedReturnValue: true) },
                { new object[] { 1d, 2d, 1d }, new TestCaseResults(description: "The test value is at the beginning, and the end is smaller than the beginning.", trials: trials, expectedReturnValue: true) },
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
        public static bool ValueBetween(double value, double lowerLimit, double upperLimit)
            => Between(value, lowerLimit, upperLimit);

        /// <summary>
        /// Check whether the double value is between lower and upper bounds.
        /// </summary>
        /// <param name="value">The <paramref name="value"/>.</param>
        /// <param name="lowerLimit">The lower limit.</param>
        /// <param name="upperLimit">The upper limit.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <acknowledgment>
        /// https://github.com/dystopiancode/colorspace-conversions/
        /// </acknowledgment>
        [DisplayName("Check whether a value is between two others")]
        [Description("Check whether a value is between two others.")]
        [Acknowledgment("https://github.com/dystopiancode/colorspace-conversions/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Between(double value, double lowerLimit, double upperLimit)
        {
            return value >= lowerLimit && value <= upperLimit;
        }

        /// <summary>
        /// Return true iff c is between a and b.  Normalize all parameters wrt c, then ask if a and b are on opposite sides of zero.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <acknowledgment>
        /// https://www.khanacademy.org/computer-programming/c/5567955982876672
        /// </acknowledgment>
        [DisplayName("Check whether a value is between two others")]
        [Description("Check whether a value is between two others.")]
        [Acknowledgment("https://www.khanacademy.org/computer-programming/c/5567955982876672")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsBetween(double c, double a, double b)
        {
            return (a - c) * (b - c) <= 0;
        }
    }
}
