using CSharpSpeed;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Reverse Endianness Float Tests")]
    [Description("Reverse Endianness Float Tests.")]
    [SourceCodeLocationProvider]
    public static class ReverseEndiannessFloatTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 2D cubic interpolation of a point.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(ReverseEndiannessFloatTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 3.1415926f }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: -1.0082865E+16f, epsilon: double.Epsilon) },
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
        public static float ReverseEndianness(float value)
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
        public static float ReverseEndianness_(float value)
        {
            var span = BitConverter.GetBytes(value).AsSpan();
            span.Reverse();
            return BitConverter.ToSingle(span.ToArray(), 0);
        }
    }
}
