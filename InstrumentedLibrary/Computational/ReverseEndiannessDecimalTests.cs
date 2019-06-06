using CSharpSpeed;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    //[DisplayName("Reverse Endianness Decimal Tests")]
    //[Description("Reverse Endianness Decimal Tests.")]
    //[SourceCodeLocationProvider]
    public static class ReverseEndiannessDecimalTests
    {
        ///// <summary>
        ///// Set of tests to run testing methods that calculate the 2D cubic interpolation of a point.
        ///// </summary>
        ///// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        //[DisplayName(nameof(InterpolateCubic2DTests))]
        //public static List<SpeedTester> TestHarness()
        //{
        //    var trials = 10000;
        //    var tests = new Dictionary<object[], TestCaseResults> {
        //        { new object[] { 3.1415926m }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: 0m, epsilon: double.Epsilon) },
        //    };

        //    var results = new List<SpeedTester>();
        //    foreach (var method in HelperExtensions.ListStaticMethodsWithAttribute(MethodBase.GetCurrentMethod().DeclaringType, typeof(SourceCodeLocationProviderAttribute)))
        //    {
        //        var methodDescription = ((DescriptionAttribute)method.GetCustomAttribute(typeof(DescriptionAttribute)))?.Description;
        //        results.Add(new SpeedTester(method, methodDescription, tests));
        //    }
        //    return results;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //[Signature]
        //public static decimal ReverseEndianness(decimal value)
        //    => ReverseEndianness_(value);

        ///// <summary>
        ///// Reverse the endianness of a value
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        ///// <acknowledgment>
        ///// https://github.com/SystemExt/SystemExt.Buffers.Binary/blob/master/src/SystemExt.Buffers.Binary/BinaryPrimitives.Reverse.cs
        ///// </acknowledgment>
        //[DisplayName("Reverse Endianness Float Tests")]
        //[Description("Reverse Endianness Float Tests.")]
        //[Acknowledgment("https://github.com/SystemExt/SystemExt.Buffers.Binary/blob/master/src/SystemExt.Buffers.Binary/BinaryPrimitives.Reverse.cs")]
        //[SourceCodeLocationProvider]
        //[DebuggerStepThrough]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static decimal ReverseEndianness_(decimal value)
        //{
        //    var span = value.GetBytes().AsSpan();
        //    span.Reverse();
        //    return span.ToArray().ToDecimal();
        //}

        ///// <summary>
        ///// Reverse the endianness of a value
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        ///// <acknowledgment>
        ///// https://github.com/SystemExt/SystemExt.Buffers.Binary/blob/master/src/SystemExt.Buffers.Binary/BinaryPrimitives.Reverse.cs
        ///// </acknowledgment>
        //[DisplayName("Reverse Endianness Float Tests")]
        //[Description("Reverse Endianness Float Tests.")]
        //[Acknowledgment("https://github.com/SystemExt/SystemExt.Buffers.Binary/blob/master/src/SystemExt.Buffers.Binary/BinaryPrimitives.Reverse.cs")]
        //[SourceCodeLocationProvider]
        //[DebuggerStepThrough]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static decimal ReverseEndianness2(decimal value)
        //{
        //    using var memoryStream = new MemoryStream();
        //    using var binaryWriter = new BinaryWriter(memoryStream);
        //    binaryWriter.Write(value);
        //    var span = memoryStream.ToArray().AsSpan();
        //    span.Reverse();
        //    using var memoryStream2 = new MemoryStream(span.ToArray());
        //    using var binaryReader = new BinaryReader(memoryStream2);
        //    return binaryReader.ReadDecimal();
        //}

        ///// <summary>
        ///// http://abundantcode.com/how-to-convert-decimal-to-byte-array-in-c/
        ///// </summary>
        ///// <param name="dec"></param>
        ///// <returns></returns>
        //private static byte[] GetBytes(this decimal dec)
        //{
        //    using var memoryStream = new MemoryStream();
        //    var binaryWriter = new BinaryWriter(memoryStream);
        //    binaryWriter.Write(dec);
        //    return memoryStream.ToArray();
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="bytes"></param>
        ///// <returns></returns>
        //private static decimal ToDecimal(this byte[] bytes)
        //{
        //    using var memoryStream = new MemoryStream(bytes);
        //    var binaryReader = new BinaryReader(memoryStream);
        //    return binaryReader.ReadDecimal();
        //}

        ///// <summary>
        ///// https://social.technet.microsoft.com/wiki/contents/articles/19055.net-convert-system-decimal-to-and-from-byte-arrays.aspx
        ///// </summary>
        ///// <param name="dec"></param>
        ///// <returns></returns>
        //private static byte[] GetBytesTechnet(this decimal dec)
        //{
        //    //Load four 32 bit integers from the Decimal.GetBits function
        //    var bits = decimal.GetBits(dec);
        //    //Create a temporary list to hold the bytes
        //    var bytes = new List<byte>();
        //    //iterate each 32 bit integer
        //    foreach (var i in bits)
        //    {
        //        //add the bytes of the current 32bit integer
        //        //to the bytes list
        //        bytes.AddRange(BitConverter.GetBytes(i));
        //    }
        //    //return the bytes list as an array
        //    return bytes.ToArray();
        //}

        ///// <summary>
        ///// https://social.technet.microsoft.com/wiki/contents/articles/19055.net-convert-system-decimal-to-and-from-byte-arrays.aspx
        ///// </summary>
        ///// <param name="bytes"></param>
        ///// <returns></returns>
        //private static decimal ToDecimalTechnet(this byte[] bytes)
        //{
        //    //check that it is even possible to convert the array
        //    if (bytes.Length != 16)
        //        throw new Exception("A decimal must be created from exactly 16 bytes");
        //    //make an array to convert back to int32's
        //    var bits = new int[4];
        //    for (var i = 0; i <= 15; i += 4)
        //    {
        //        //convert every 4 bytes into an int32
        //        bits[i / 4] = BitConverter.ToInt32(bytes, i);
        //    }
        //    //Use the decimal's new constructor to
        //    //create an instance of decimal
        //    return new decimal(bits);
        //}
    }
}
