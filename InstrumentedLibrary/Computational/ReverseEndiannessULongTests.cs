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
    [DisplayName("Reverse Endianness ULong Tests")]
    [Description("Reverse Endianness ULong Tests.")]
    [SourceCodeLocationProvider]
    public static class ReverseEndiannessULongTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 2D cubic interpolation of a point.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(ReverseEndiannessULongTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { (ulong)0xDEADBEEFDEADBEEF }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (ulong)0xEFBEADDEEFBEADDE, epsilon: double.Epsilon) },
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
        public static ulong ReverseEndianness(ulong value)
            => ReverseEndiannessCore(value);

        /// <summary>
        /// Reverse the endianness of a value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [DisplayName("Reverse Endianness Long Tests")]
        [Description("Reverse Endianness Long Tests.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong ReverseEndiannessCore(ulong value)
        {
            return BinaryPrimitives.ReverseEndianness(value);
        }

        /// <summary>
        /// Reverses a primitive value - performs an endianness swap
        /// </summary> 
        /// <acknowledgment>
        /// https://github.com/dotnet/corefx/blob/master/src/Common/src/CoreLib/System/Buffers/Binary/Reader.cs
        /// </acknowledgment>
        [DisplayName("Reverse Endianness Long Tests")]
        [Description("Reverse Endianness Long Tests.")]
        [Acknowledgment("https://github.com/dotnet/corefx/blob/master/src/Common/src/CoreLib/System/Buffers/Binary/Reader.cs")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong ReverseEndianness_(ulong value)
        {
            // Operations on 32-bit values have higher throughput than
            // operations on 64-bit values, so decompose.

            return ((ulong)ReverseEndiannessUIntTests.ReverseEndianness_((uint)value) << 32)
                + ReverseEndiannessUIntTests.ReverseEndianness_((uint)(value >> 32));
        }

        /// <summary>
        /// Converts a long value from host byte order to network byte order.
        /// </summary>
        /// <param name="host">The number to convert, expressed in host byte order. </param>
        /// <returns>A long value, expressed in network byte order.</returns>
        /// <acknowledgment>
        /// http://referencesource.microsoft.com/#System/net/System/Net/IPAddress.cs
        /// </acknowledgment>
        [DisplayName("Reverse Endianness Long Tests")]
        [Description("Reverse Endianness Long Tests.")]
        [Acknowledgment("http://referencesource.microsoft.com/#System/net/System/Net/IPAddress.cs")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong HostToNetworkOrder(ulong host)
        {
            return (ulong)((ReverseEndiannessUIntTests.HostToNetworkOrder((uint)host) & 0xffffffffL) << 0x20) | (ulong)(ReverseEndiannessUIntTests.HostToNetworkOrder((uint)(host >> 0x20)) & 0xffffffffL);
        }

        /// <summary>
        /// Converts a long value from network byte order to host byte order.
        /// </summary>
        /// <param name="network">The number to convert, expressed in network byte order. </param>
        /// <returns>A long value, expressed in host byte order.</returns>
        /// <acknowledgment>
        /// http://referencesource.microsoft.com/#System/net/System/Net/IPAddress.cs
        /// </acknowledgment>
        [DisplayName("Reverse Endianness Long Tests")]
        [Description("Reverse Endianness Long Tests.")]
        [Acknowledgment("http://referencesource.microsoft.com/#System/net/System/Net/IPAddress.cs")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong NetworkToHostOrder(ulong network)
        {
            return HostToNetworkOrder(network);
        }
    }
}
