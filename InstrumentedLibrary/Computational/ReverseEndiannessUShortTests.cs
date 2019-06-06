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
    [DisplayName("Reverse Endianness UShort Tests")]
    [Description("Reverse Endianness UShort Tests.")]
    [SourceCodeLocationProvider]
    public static class ReverseEndiannessUShortTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 2D cubic interpolation of a point.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(ReverseEndiannessUShortTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { (ushort)0xDEAD }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (ushort)0xADDE, epsilon: double.Epsilon) },
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
        public static ushort ReverseEndianness(ushort value)
            => ReverseEndiannessCore(value);

        /// <summary>
        /// Reverse the endianness of a value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [DisplayName("Reverse Endianness UShort Tests")]
        [Description("Reverse Endianness UShort Tests.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort ReverseEndiannessCore(ushort value)
        {
            return BinaryPrimitives.ReverseEndianness(value);
        }

        /// <summary>
        /// Reverses a primitive value - performs an endianness swap
        /// </summary> 
        /// <acknowledgment>
        /// https://github.com/dotnet/corefx/blob/master/src/Common/src/CoreLib/System/Buffers/Binary/Reader.cs
        /// </acknowledgment>
        [DisplayName("Reverse Endianness UShort Tests")]
        [Description("Reverse Endianness UShort Tests.")]
        [Acknowledgment("https://github.com/dotnet/corefx/blob/master/src/Common/src/CoreLib/System/Buffers/Binary/Reader.cs")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort ReverseEndianness_(ushort value)
        {
            // Don't need to AND with 0xFF00 or 0x00FF since the final
            // cast back to ushort will clear out all bits above [ 15 .. 00 ].
            // This is normally implemented via "movzx eax, ax" on the return.
            // Alternatively, the compiler could elide the movzx instruction
            // entirely if it knows the caller is only going to access "ax"
            // instead of "eax" / "rax" when the function returns.

            return (ushort)((value >> 8) + (value << 8));
        }

        /// <summary>
        /// Converts a ushort value from host byte order to network byte order.
        /// </summary>
        /// <param name="host">The number to convert, expressed in host byte order. </param>
        /// <returns>A short value, expressed in network byte order.</returns>
        /// <acknowledgment>
        /// http://referencesource.microsoft.com/#System/net/System/Net/IPAddress.cs
        /// </acknowledgment>
        [DisplayName("Reverse Endianness UShort Tests")]
        [Description("Reverse Endianness UShort Tests.")]
        [Acknowledgment("http://referencesource.microsoft.com/#System/net/System/Net/IPAddress.cs")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort HostToNetworkOrder(ushort host)
        {
            return (ushort)(((host & 0xff) << 8) | ((host >> 8) & 0xff));
        }

        /// <summary>
        /// Converts a ushort value from network byte order to host byte order.
        /// </summary>
        /// <param name="network"> The number to convert, expressed in network byte order. </param>
        /// <returns> A ushort value, expressed in host byte order.</returns>
        /// <acknowledgment>
        /// http://referencesource.microsoft.com/#System/net/System/Net/IPAddress.cs
        /// </acknowledgment>
        [DisplayName("Reverse Endianness UShort Tests")]
        [Description("Reverse Endianness UShort Tests.")]
        [Acknowledgment("http://referencesource.microsoft.com/#System/net/System/Net/IPAddress.cs")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort NetworkToHostOrder(ushort network)
        {
            return HostToNetworkOrder(network);
        }
    }
}
