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
    [DisplayName("Reverse Endianness Short Tests")]
    [Description("Reverse Endianness Short Tests.")]
    [SourceCodeLocationProvider]
    public static class ReverseEndiannessShortTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 2D cubic interpolation of a point.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(ReverseEndiannessShortTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { (short)0xDEA }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (short)-5619, epsilon: double.Epsilon) },
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
        public static short ReverseEndianness(short value)
            => ReverseEndiannessCore(value);

        /// <summary>
        /// Reverse the endianness of a value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [DisplayName("Reverse Endianness Short Tests")]
        [Description("Reverse Endianness Short Tests.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ReverseEndiannessCore(short value)
        {
            return BinaryPrimitives.ReverseEndianness(value);
        }

        /// <summary>
        /// Reverses a primitive value - performs an endianness swap
        /// </summary> 
        /// <acknowledgment>
        /// https://github.com/dotnet/corefx/blob/master/src/Common/src/CoreLib/System/Buffers/Binary/Reader.cs
        /// </acknowledgment>
        [DisplayName("Reverse Endianness Short Tests")]
        [Description("Reverse Endianness Short Tests.")]
        [Acknowledgment("https://github.com/dotnet/corefx/blob/master/src/Common/src/CoreLib/System/Buffers/Binary/Reader.cs")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ReverseEndianness1(short value)
        {
            return (short)ReverseEndiannessUShortTests.ReverseEndianness1((ushort)value);
        }

        /// <summary>
        /// Converts a short value from host byte order to network byte order.
        /// </summary>
        /// <param name="host">The number to convert, expressed in host byte order. </param>
        /// <returns>A short value, expressed in network byte order.</returns>
        /// <remarks>http://referencesource.microsoft.com/#System/net/System/Net/IPAddress.cs</remarks>
        [DisplayName("Reverse Endianness Short Tests")]
        [Description("Reverse Endianness Short Tests.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short HostToNetworkOrder(short host)
        {
            return (short)(((host & 0xff) << 8) | ((host >> 8) & 0xff));
        }

        /// <summary>
        /// Converts a short value from network byte order to host byte order.
        /// </summary>
        /// <param name="network"> The number to convert, expressed in network byte order. </param>
        /// <returns> A short value, expressed in host byte order.</returns>
        /// <remarks>http://referencesource.microsoft.com/#System/net/System/Net/IPAddress.cs</remarks>
        [DisplayName("Reverse Endianness Short Tests")]
        [Description("Reverse Endianness Short Tests.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short NetworkToHostOrder(short network)
        {
            return HostToNetworkOrder(network);
        }
    }
}
