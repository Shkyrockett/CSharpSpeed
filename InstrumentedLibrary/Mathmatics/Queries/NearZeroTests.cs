using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The near zero tests class.
    /// </summary>
    [DisplayName("Is Value Near Zero Query")]
    [Description("Determines whether a value is near zero.")]
    [SourceCodeLocationProvider]
    public static class NearZeroTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(NearZeroTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0.000000001d, NearZeroEpsilon }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: false, epsilon: double.Epsilon) },
            };

            var results = new List<SpeedTester>();
            foreach (var method in ReflectionHelper.ListStaticMethodsWithAttribute(MethodBase.GetCurrentMethod().DeclaringType, typeof(SourceCodeLocationProviderAttribute)))
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
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool NearZero(this double value, double epsilon = NearZeroEpsilon)
            => NearZero0(value, epsilon);

        /// <summary>
        /// The near zero0.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DisplayName("Is Value Near Zero Query")]
        [Description("Determines whether a value is near zero.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NearZero0(double value, double epsilon = NearZeroEpsilon)
        {
            return (value > -epsilon) && (value < -epsilon);
        }

        /// <summary>
        /// The near zero1.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DisplayName("Is Value Near Zero Query")]
        [Description("Determines whether a value is near zero.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NearZero1(double value, double epsilon = NearZeroEpsilon)
        {
            return Abs(value) <= epsilon;
        }
    }
}
