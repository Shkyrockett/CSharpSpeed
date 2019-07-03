using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The smooth step tests class.
    /// </summary>
    [DisplayName("Smooth Step Between Two Values")]
    [Description("Smooth step between two values.")]
    [SourceCodeLocationProvider]
    public static class SmoothStepTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(SmoothStepTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0.5d, 0d, 1d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: 0.5d, epsilon: double.Epsilon) },
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
        /// <param name="amount"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double SmoothStep(double amount, double value1, double value2)
            => SmoothStep_(amount, value1, value2);

        /// <summary>
        /// Interpolates between two values using a cubic equation.
        /// </summary>
        /// <param name="amount">Weighting value.</param>
        /// <param name="value1">Source value.</param>
        /// <param name="value2">Source value.</param>
        /// <returns>Interpolated value.</returns>
        [DisplayName("Smooth Step Between Two Values")]
        [Description("Smooth step between two values.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SmoothStep_(double amount, double value1, double value2)
        {
            // It is expected that 0 < amount < 1
            // If amount < 0, return value1
            // If amount > 1, return value2
            var result = ClampTests.Clamp(amount, 0d, 1d);
            result = HermiteInterpolate1DTests.Hermite(result, value1, 0d, value2, 0d, 1d, 0d);

            return result;
        }
    }
}
