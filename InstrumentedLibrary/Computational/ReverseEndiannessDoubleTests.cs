using CSharpSpeed;
using System;
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
    [DisplayName("Reverse Endianness Float Tests")]
    [Description("Reverse Endianness Float Tests.")]
    [SourceCodeLocationProvider]
    public static class ReverseEndiannessDoubleTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 2D cubic interpolation of a point.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(ReverseEndiannessDoubleTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 3.1415926d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: 3.60248731275491E+52d, epsilon: double.Epsilon) },
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
        public static double ReverseEndianness(double value)
            => ReverseEndianness_(value);

        /// <summary>
        /// Reverse the endianness of a value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/SystemExt/SystemExt.Buffers.Binary/blob/master/src/SystemExt.Buffers.Binary/BinaryPrimitives.Reverse.cs
        /// </acknowledgment>
        [DisplayName("Reverse Endianness Float Tests")]
        [Description("Reverse Endianness Float Tests.")]
        [Acknowledgment("https://github.com/SystemExt/SystemExt.Buffers.Binary/blob/master/src/SystemExt.Buffers.Binary/BinaryPrimitives.Reverse.cs")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ReverseEndianness_(double value)
        {
            var span = BitConverter.GetBytes(value).AsSpan();
            span.Reverse();
            return BitConverter.ToDouble(span.ToArray(), 0);
        }
    }
}
