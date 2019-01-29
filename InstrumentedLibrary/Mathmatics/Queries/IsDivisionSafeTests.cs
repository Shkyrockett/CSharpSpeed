using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The is division safe tests class.
    /// </summary>
    [DisplayName("Is Division Safe")]
    [Description("Determines whether the division of two values is likely to overflow.")]
    [SourceCodeLocationProvider]
    public static class IsDivisionSafeTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the safety of operations.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(IsDivisionSafeTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { int.MaxValue / 2, int.MaxValue / 2 }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: true, epsilon: double.Epsilon) },
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
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool IsDivisionSafe(int a, int b)
            => IsDivisionSafe0(a,b);

        /// <summary>
        /// The is division safe.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c?rq=1
        /// </acknowledgment>
        [DisplayName("Is division Safe")]
        [Description("Determines whether the division of two values is likely to overflow.")]
        [Acknowledgment("http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c?rq=1")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsDivisionSafe0(int a, int b)
        {
            if (b == 0)
            {
                return false;
            }
            //for division(except for the INT_MIN and - 1 special case) there is no possibility of going over INT_MIN or INT_MAX.
            if (a == int.MinValue && b == -1)
            {
                return false;
            }

            return true;
        }
    }
}
