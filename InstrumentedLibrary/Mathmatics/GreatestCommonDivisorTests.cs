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
    /// The greatest common divisor tests class.
    /// </summary>
    [DisplayName("greatest common divisor Tests")]
    [Description("greatest common divisor.")]
    [Signature("public static long GCD(long a, long b)")]
    [SourceCodeLocationProvider]
    public static class GreatestCommonDivisorTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(GreatestCommonDivisorTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 6L, 9L }, new TestCaseResults(description:"", trials:trials, expectedReturnValue:true, epsilon:double.Epsilon) },
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
        /// Return the greatest common divisor (GCD) of a and b.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="long"/>.</returns>
        [DisplayName("greatest common divisor Tests")]
        [Description("greatest common divisor.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long GCD(long a, long b)
        {
            long remainder;

            // Pull out remainders.
            for (; ; )
            {
                remainder = a % b;
                if (remainder == 0)
                {
                    break;
                }

                a = b;
                b = remainder;
            }

            return b;
        }
    }
}
