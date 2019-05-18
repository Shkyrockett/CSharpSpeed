using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The is multiplication safe tests class.
    /// </summary>
    [DisplayName("Is Multiplication Safe")]
    [Description("Determines whether the multiplication of two values is likely to overflow.")]
    [SourceCodeLocationProvider]
    public static class IsMultiplicationSafeTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the safety of operations.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(IsMultiplicationSafeTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 2, int.MaxValue / 2 }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: false, epsilon: double.Epsilon) },
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
        public static bool IsMultiplicationSafe(int a, int b)
            => IsMultiplicationSafe0(a, b);

        /// <summary>
        /// The is multiplication safe.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c
        /// </acknowledgment>
        [DisplayName("Is Multiplication Safe")]
        [Description("Determines whether the multiplication of two values is likely to overflow.")]
        [Acknowledgment("http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c?rq=1")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsMultiplicationSafe0(int a, int b)
        {
            return Log2Tests.Log2(a) + Log2Tests.Log2(b) <= sizeof(int);
        }

        /// <summary>
        /// The is multiplication safe1.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DisplayName("Is Multiplication Safe")]
        [Description("Determines whether the multiplication of two values is likely to overflow.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsMultiplicationSafe1(int a, int b)
        {
            return Round(Log(a, 2) + Log(b, 2), MidpointRounding.AwayFromZero) <= sizeof(int);
        }

        /// <summary>
        /// The is multiplication safe2.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c
        /// </acknowledgment>
        [DisplayName("Is Multiplication Safe")]
        [Description("Determines whether the multiplication of two values is likely to overflow.")]
        [Acknowledgment("http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c?rq=1")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsMultiplicationSafe2(int a, int b)
        {
            if (a == 0)
            {
                return true;
            }
            // a * b would overflow
            return b > int.MaxValue / a;
        }

        /// <summary>
        /// The is multiplication safe3.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c?rq=1
        /// </acknowledgment>
        [DisplayName("Is Multiplication Safe")]
        [Description("Determines whether the multiplication of two values is likely to overflow.")]
        [Acknowledgment("http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c?rq=1")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsMultiplicationSafe3(int a, int b)
        {
            if (a == 0)
            {
                return true;
            }

            if (a > int.MaxValue / b)
            {
                return false /* `a * x` would overflow */;
            }

            if (a < int.MinValue / b)
            {
                return false /* `a * x` would underflow */;
            }
            // there may be need to check for -1 for two's complement machines
            if ((a == -1) && (b == int.MinValue))
            {
                return false /* `a * x` can overflow */;
            }

            if ((b == -1) && (a == int.MinValue))
            {
                return false /* `a * x` (or `a / x`) can overflow */;
            }

            return true;
        }
    }
}
