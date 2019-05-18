using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The is exponentiation safe tests class.
    /// </summary>
    [DisplayName("Is Exponentiation Safe")]
    [Description("Determines whether the Exponentiation of two values is likely to overflow.")]
    [SourceCodeLocationProvider]
    public static class IsExponentiationSafeTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the safety of operations.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(IsExponentiationSafeTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 2, 39 }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: false, epsilon: double.Epsilon) },
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
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool IsExponentiationSafe(int a, int b)
            => IsExponentiationSafe0(a, b);

        /// <summary>
        /// The is exponentiation safe.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c
        /// </acknowledgment>
        [DisplayName("Is Exponentiation Safe")]
        [Description("Determines whether the Exponentiation of two values is likely to overflow.")]
        [Acknowledgment("http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsExponentiationSafe0(int a, int b)
        {
            return Log2Tests.Log2(a) * b <= sizeof(int);
        }
    }
}
