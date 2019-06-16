using CSharpSpeed;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Reverse Endianness UInt Tests")]
    [Description("Reverse Endianness UInt Tests.")]
    [SourceCodeLocationProvider]
    public static class ReverseEndiannessUIntTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 2D cubic interpolation of a point.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(ReverseEndiannessUIntTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { (uint)0xDEADBEEF }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (uint)0xEFBEADDE, epsilon: double.Epsilon) },
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
        public static uint ReverseEndianness(uint value)
            => ReverseEndiannessCore(value);

        /// <summary>
        /// Reverse the endianness of a value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [DisplayName("Reverse Endianness UInt Tests")]
        [Description("Reverse Endianness UInt Tests.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ReverseEndiannessCore(uint value)
        {
            return BinaryPrimitives.ReverseEndianness(value);
        }

        /// <summary>
        /// Reverses a primitive value - performs an endianness swap
        /// </summary> 
        /// <acknowledgment>
        /// https://github.com/dotnet/corefx/blob/master/src/Common/src/CoreLib/System/Buffers/Binary/Reader.cs
        /// </acknowledgment>
        [DisplayName("Reverse Endianness UInt Tests")]
        [Description("Reverse Endianness UInt Tests.")]
        [Acknowledgment("https://github.com/dotnet/corefx/blob/master/src/Common/src/CoreLib/System/Buffers/Binary/Reader.cs")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ReverseEndianness_(uint value)
        {
            // This takes advantage of the fact that the JIT can detect
            // ROL32 / ROR32 patterns and output the correct intrinsic.
            //
            // Input: value = [ ww xx yy zz ]
            //
            // First line generates : [ ww xx yy zz ]
            //                      & [ 00 FF 00 FF ]
            //                      = [ 00 xx 00 zz ]
            //             ROR32(8) = [ zz 00 xx 00 ]
            //
            // Second line generates: [ ww xx yy zz ]
            //                      & [ FF 00 FF 00 ]
            //                      = [ ww 00 yy 00 ]
            //             ROL32(8) = [ 00 yy 00 ww ]
            //
            //                (sum) = [ zz yy xx ww ]
            //
            // Testing shows that throughput increases if the AND
            // is performed before the ROL / ROR.

            return BitOperations.RotateRight(value & 0x00FF00FFu, 8) // xx zz
                + BitOperations.RotateLeft(value & 0xFF00FF00u, 8); // ww yy
        }

        /// <summary>
        /// Converts an integer value from host byte order to network byte order.
        /// </summary>
        /// <param name="host">The number to convert, expressed in host byte order. </param>
        /// <returns>An integer value, expressed in network byte order.</returns>
        /// <acknowledgment>
        /// http://referencesource.microsoft.com/#System/net/System/Net/IPAddress.cs
        /// </acknowledgment>
        [DisplayName("Reverse Endianness UInt Tests")]
        [Description("Reverse Endianness UInt Tests.")]
        [Acknowledgment("http://referencesource.microsoft.com/#System/net/System/Net/IPAddress.cs")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint HostToNetworkOrder(uint host)
        {
            return (uint)((ReverseEndiannessUShortTests.HostToNetworkOrder((ushort)host) & 0xffff) << 0x10) | (uint)(ReverseEndiannessUShortTests.HostToNetworkOrder((ushort)(host >> 0x10)) & 0xffff);
        }

        /// <summary>
        /// Converts an integer value from network byte order to host byte order.
        /// </summary>
        /// <param name="network">The number to convert, expressed in network byte order. </param>
        /// <returns>An integer value, expressed in host byte order.</returns>
        /// <acknowledgment>
        /// http://referencesource.microsoft.com/#System/net/System/Net/IPAddress.cs
        /// </acknowledgment>
        [DisplayName("Reverse Endianness UInt Tests")]
        [Description("Reverse Endianness UInt Tests.")]
        [Acknowledgment("http://referencesource.microsoft.com/#System/net/System/Net/IPAddress.cs")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint NetworkToHostOrder(uint network)
        {
            return HostToNetworkOrder(network);
        }
    }
}
