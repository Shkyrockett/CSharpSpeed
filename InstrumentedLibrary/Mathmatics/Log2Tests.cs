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
    /// The log2tests class.
    /// </summary>
    [DisplayName("Log 2 of a Number")]
    [Description("Find the Log 2 of a number.")]
    [SourceCodeLocationProvider]
    public static class Log2Tests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 1D Hermite interpolation of points.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(Log2Tests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 12 }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:4, epsilon: double.Epsilon) },
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
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static int Log2(int value)
            => Log2_0(value);

        /// <summary>
        /// The system log2.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="double"/>.</returns>
        [DisplayName("Log 2 of a Number")]
        [Description("Find the Log 2 of a number.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SystemLog2(int value)
        {
            return (int)Round(Log(value, 2));
        }

        /// <summary>
        /// Determine the position of the highest one-bit in a number.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c
        /// </acknowledgment>
        [DisplayName("Log 2 of a Number")]
        [Description("Find the Log 2 of a number.")]
        [Acknowledgment("http://stackoverflow.com/questions/199333/how-to-detect-integer-overflow-in-c-c")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Log2_0(int value)
        {
            byte bits = 0;
            while (value != 0)
            {
                ++bits;
                value >>= 1;
            }
            return bits;
        }

        /// <summary>
        /// The multiply de bruijn bit position (readonly). Value: new byte[32] { 0, 9, 1, 10, 13, 21, 2, 29, 11, 14, 16, 18, 22, 25, 3, 30, 8, 12, 20, 28, 15, 17, 24, 7, 19, 27, 23, 6, 26, 5, 4, 31 }.
        /// </summary>
        /// <acknowledgment>
        /// http://graphics.stanford.edu/~seander/bithacks.html
        /// </acknowledgment>
        public static readonly byte[] multiplyDeBruijnBitPosition = new byte[32]
            {
                0, 9, 1, 10, 13, 21, 2, 29, 11, 14, 16, 18, 22, 25, 3, 30,
                8, 12, 20, 28, 15, 17, 24, 7, 19, 27, 23, 6, 26, 5, 4, 31
            };

        /// <summary>
        /// Returns log2(x) for positive values of x.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="int"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">must be positive</exception>
        /// <acknowledgment>
        /// http://graphics.stanford.edu/~seander/bithacks.html
        /// </acknowledgment>
        [DisplayName("Log 2 of a Number")]
        [Description("Find the Log 2 of a number.")]
        [Acknowledgment("http://graphics.stanford.edu/~seander/bithacks.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Log2_1(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "must be positive");
            }

            if (value == 1)
            {
                return 0;
            }

            // Locate the highest set bit.
            var v = unchecked((uint)value);
            v |= v >> 1;
            v |= v >> 2;
            v |= v >> 4;
            v |= v >> 8;
            v |= v >> 16;

            var i = unchecked(v * 0x7c4acdd) >> 27;
            int r = multiplyDeBruijnBitPosition[i];

            return r;
        }
    }
}
