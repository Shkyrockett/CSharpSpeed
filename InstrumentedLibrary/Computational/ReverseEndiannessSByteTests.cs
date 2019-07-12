using CSharpSpeed;
using System.Buffers.Binary;
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
    [DisplayName("Reverse Endianness SByte Tests")]
    [Description("Reverse Endianness SByte Tests.")]
    [SourceCodeLocationProvider]
    public static class ReverseEndiannessSByteTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 2D cubic interpolation of a point.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(ReverseEndiannessSByteTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { (sbyte)0xD }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (sbyte)0xD, epsilon: double.Epsilon) },
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
        public static sbyte ReverseEndianness(sbyte value)
            => ReverseEndiannessCore(value);

        /// <summary>
        /// Reverse the endianness of a value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [DisplayName("Reverse Endianness SByte Tests")]
        [Description("Reverse Endianness SByte Tests.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte ReverseEndiannessCore(sbyte value)
        {
            return BinaryPrimitives.ReverseEndianness(value);
        }

        /// <summary>
        /// This is a no-op and added only for consistency.
        /// This allows the caller to read a struct of numeric primitives and reverse each field
        /// rather than having to skip sbyte fields.
        /// </summary> 
        /// <acknowledgment>
        /// https://github.com/dotnet/corefx/blob/master/src/Common/src/CoreLib/System/Buffers/Binary/Reader.cs
        /// </acknowledgment>
        [DisplayName("Reverse Endianness SByte Tests")]
        [Description("Reverse Endianness SByte Tests.")]
        [Acknowledgment("https://github.com/dotnet/corefx/blob/master/src/Common/src/CoreLib/System/Buffers/Binary/Reader.cs")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte ReverseEndianness1(sbyte value)
        {
            return value;
        }
    }
}
