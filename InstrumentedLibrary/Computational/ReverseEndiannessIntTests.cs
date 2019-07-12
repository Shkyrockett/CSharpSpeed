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
    [DisplayName("Reverse Endianness Int Tests")]
    [Description("Reverse Endianness Int Tests.")]
    [SourceCodeLocationProvider]
    public static class ReverseEndiannessIntTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 2D cubic interpolation of a point.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(ReverseEndiannessIntTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { (int)0xDEADBEE }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (int)-287577587, epsilon: double.Epsilon) },
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
        public static int ReverseEndianness(int value)
            => ReverseEndiannessCore(value);

        /// <summary>
        /// Reverse the endianness of a value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [DisplayName("Reverse Endianness Int Tests")]
        [Description("Reverse Endianness Int Tests.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ReverseEndiannessCore(int value)
        {
            return BinaryPrimitives.ReverseEndianness(value);
        }

        /// <summary>
        /// Reverses a primitive value - performs an endianness swap
        /// </summary> 
        /// <acknowledgment>
        /// https://github.com/dotnet/corefx/blob/master/src/Common/src/CoreLib/System/Buffers/Binary/Reader.cs
        /// </acknowledgment>
        [DisplayName("Reverse Endianness Int Tests")]
        [Description("Reverse Endianness Int Tests.")]
        [Acknowledgment("https://github.com/dotnet/corefx/blob/master/src/Common/src/CoreLib/System/Buffers/Binary/Reader.cs")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ReverseEndianness1(int value)
        {
            return (int)ReverseEndiannessUIntTests.ReverseEndianness1((uint)value);
        }

        /// <summary>
        /// Converts an integer value from host byte order to network byte order.
        /// </summary>
        /// <param name="host">The number to convert, expressed in host byte order. </param>
        /// <returns>An integer value, expressed in network byte order.</returns>
        /// <acknowledgment>
        /// http://referencesource.microsoft.com/#System/net/System/Net/IPAddress.cs
        /// </acknowledgment>
        [DisplayName("Reverse Endianness Int Tests")]
        [Description("Reverse Endianness Int Tests.")]
        [Acknowledgment("http://referencesource.microsoft.com/#System/net/System/Net/IPAddress.cs")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int HostToNetworkOrder(int host)
        {
            return ((ReverseEndiannessShortTests.HostToNetworkOrder((short)host) & 0xffff) << 0x10) | (ReverseEndiannessShortTests.HostToNetworkOrder((short)(host >> 0x10)) & 0xffff);
        }

        /// <summary>
        /// Converts an integer value from network byte order to host byte order.
        /// </summary>
        /// <param name="network">The number to convert, expressed in network byte order. </param>
        /// <acknowledgment>
        /// http://referencesource.microsoft.com/#System/net/System/Net/IPAddress.cs
        /// </acknowledgment>
        [DisplayName("Reverse Endianness Int Tests")]
        [Description("Reverse Endianness Int Tests.")]
        [Acknowledgment("http://referencesource.microsoft.com/#System/net/System/Net/IPAddress.cs")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int NetworkToHostOrder(int network)
        {
            return HostToNetworkOrder(network);
        }
    }
}
