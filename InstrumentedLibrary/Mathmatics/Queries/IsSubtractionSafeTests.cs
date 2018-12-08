using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The is subtraction safe tests class.
    /// </summary>
    [DisplayName("Is Subtraction Safe")]
    [Description("Determines whether the subtraction of two values is likely to overflow.")]
    [Signature("public static int IsSubtractionSafe(int a, int b)")]
    [SourceCodeLocationProvider]
    public static class IsSubtractionSafeTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the safety of operations.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(IsSubtractionSafeTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { int.MaxValue / 2, int.MaxValue / 2 }, new TestCaseResults(description:".", trials:trials, expectedReturnValue:false, epsilon:double.Epsilon) },
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
        /// The is subtraction safe.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c?rq=1
        /// </acknowledgment>
        [DisplayName("Is Subtraction Safe")]
        [Description("Determines whether the subtraction of two values is likely to overflow.")]
        [Acknowledgment("http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c?rq=1")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSubtractionSafe(int a, int b)
        {
            if (a == 0 || b == 0 || a == -0 || b == -0)
            {
                return true;
            }

            if (b < 0)
            {
                return a > int.MaxValue + b;
            }

            if (b > 0)
            {
                return a < int.MinValue + b;
            }

            return true;
        }
    }
}
