using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The a sin tests class.
    /// </summary>
    [DisplayName("ASin Tests")]
    [Description("Returns the ASin of a value.")]
    [SourceCodeLocationProvider]
    public static class ASinTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(ASinTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 100000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:1.5707963267948966d, epsilon: double.Epsilon) },
                { new object[] { 0.25d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:0.25268025514207865d, epsilon: double.Epsilon) },
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
        /// <param name="d"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double ASin(double d)
            => ASin0(d);

        /// <summary>
        /// Returns the angle whose sine is the specified number.
        /// </summary>
        /// <param name="d">A number representing a sine, where d must be greater than or equal to -1, but less than or equal to 1.</param>
        /// <returns>
        /// An angle, θ, measured in radians, such that -π/2 ≤θ≤π/2 -or- <see cref="double.NaN"/> if d &lt; -1 or d &gt; 1 or d equals <see cref="double.NaN"/>.
        /// </returns>
        [DisplayName("System.Math.Asin")]
        [Description("")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ASin0(double d)
        {
            return Asin(d);
        }

        /// <summary>
        /// Returns the angle whose sine is the specified number.
        /// </summary>
        /// <param name="d">A number representing a sine, where d must be greater than or equal to -1, but less than or equal to 1.</param>
        /// <returns>
        /// An angle, θ, measured in radians, such that -π/2 ≤θ≤π/2 -or- <see cref="double.NaN"/> if d &lt; -1 or d &gt; 1 or d equals <see cref="double.NaN"/>.
        /// </returns>
        /// <acknowledgment>
        /// https://stackoverflow.com/q/40917676
        /// </acknowledgment>
        [DisplayName("ASin")]
        [Description("")]
        [Acknowledgment("https://stackoverflow.com/q/40917676")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ASin1(double d)
        {
            return Atan2(d, Sqrt(1d - d * d));
        }
    }
}
