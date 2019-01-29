using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using CSharpSpeed;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The split ARGB tests class.
    /// </summary>
    [DisplayName("Split Int Color to ARGB")]
    [Description("Split an integer based ARGB color into the individual components.")]
    [SourceCodeLocationProvider]
    public static class SplitARGBTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(SplitARGBTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                //               0xAARRGGBBu
                { new object[] { 0xDEADBEEFu }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:((byte)0xDE, (byte)0xAD, (byte)0xBE, (byte)0xEF), epsilon: double.Epsilon) },
                { new object[] { 0xFFFFFFFFu }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:((byte)0xFF, (byte)0xFF, (byte)0xFF, (byte)0xFF), epsilon: double.Epsilon) },
                { new object[] { 0x00FFFF00u }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:((byte)0x00, (byte)0xFF, (byte)0xFF, (byte)0x00), epsilon: double.Epsilon) },
                { new object[] { 0x00FF00FFu }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:((byte)0x00, (byte)0xFF, (byte)0x00, (byte)0xFF), epsilon: double.Epsilon) },
            };

            var results = new List<SpeedTester>();
            foreach (var method in ReflectionHelper.ListStaticMethodsWithAttribute(MethodBase.GetCurrentMethod().DeclaringType, typeof(SourceCodeLocationProviderAttribute)))
            {
                var methodDescription = ((DescriptionAttribute)method.GetCustomAttribute(typeof(DescriptionAttribute)))?.Description;
                results.Add(new SpeedTester(method, methodDescription, tests));
            }

            return results;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (byte Red, byte Green, byte Blue, byte Alpha) SplitARGB(uint color)
            => SplitARGBBitShifting(color);

        /// <summary>
        /// The split ARGB. 
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>The <see cref="T:(byte Red, byte Green, byte Blue, byte Alpha)"/>.</returns>
        /// <acknowledgment>
        /// https://stackoverflow.com/a/1328254
        /// </acknowledgment>
        [DisplayName("Split Int Color to ARGB")]
        [Description("Split an integer based ARGB color into the individual components.")]
        [Acknowledgment("https://stackoverflow.com/a/1328254")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (byte Alpha, byte Red, byte Green, byte Blue) SplitARGBBitShifting(uint color)
        {
            return (
                Alpha: (byte)((color >> 24) & 0xFF),
                Red: (byte)((color >> 16) & 0xFF),
                Green: (byte)((color >> 8) & 0xFF),
                Blue: (byte)(color & 0xFF)
                );
        }

        /// <summary>
        /// The split ARGB bit converter.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>The <see cref="T:(byte Alpha, byte Red, byte Green, byte Blue)"/>.</returns>
        [DisplayName("Split Int Color to ARGB")]
        [Description("Split an integer based ARGB color into the individual components.")]
        [Acknowledgment("https://stackoverflow.com/a/1318948")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (byte Alpha, byte Red, byte Green, byte Blue) SplitARGBBitConverter(uint color)
        {
            var buffer = BitConverter.GetBytes(color);
            return (buffer[3], buffer[2], buffer[1], buffer[0]);
        }

        /// <summary>
        /// The split ARGB get bytes.
        /// </summary>
        /// <param name="color">The value.</param>
        /// <returns>The <see cref="T:(byte Alpha, byte Red, byte Green, byte Blue)"/>.</returns>
        [DisplayName("Split Int Color to ARGB")]
        [Description("Split an integer based ARGB color into the individual components.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe (byte Alpha, byte Red, byte Green, byte Blue) SplitARGBGetBytes(uint color)
        {
            var buffer = new byte[4];
            fixed (byte* bufferRef = buffer)
            {
                *(uint*)bufferRef = color;
            }
            return (buffer[3], buffer[2], buffer[1], buffer[0]);
        }

        //public static unsafe (byte Alpha, byte Red, byte Green, byte Blue) SplitARGBGetBytess(uint color)
        //{
        //    var buffer = new ValueTuple<byte, byte, byte, byte>();
        //    fixed (byte* bufferRef = buffer)
        //    {
        //        *(uint*)bufferRef = color;
        //    }
        //    return buffer;
        //}

        /// <summary>
        /// Split Int Color to ARGB
        /// </summary>
        /// <param name="color"></param>
        /// <acknowledgment>
        /// http://xbeat.net/vbspeed/c_SplitRGB.htm
        /// by www.Abstractvb.com, Date: 3/9/2001 9:26:43 PM, 20010922
        /// </acknowledgment>
        [DisplayName("Split Int Color to ARGB")]
        [Description("Split an integer based ARGB color into the individual components.")]
        [Acknowledgment("http://xbeat.net/vbspeed/c_SplitRGB.htm")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (byte Alpha, byte Red, byte Green, byte Blue) SplitRGB01(uint color)
        {
            var blue = (byte)(color % 0x100);
            color /= 0x100;
            var green = (byte)(color % 0x100);
            color /= 0x100;
            var red = (byte)(color % 0x100);
            color /= 0x100;
            var alpha = (byte)(color % 0x100);
            return (alpha, red, green, blue);
        }

        /// <summary>
        /// Split Int Color to ARGB
        /// </summary>
        /// <param name="color"></param>
        /// <acknowledgment>
        /// http://xbeat.net/vbspeed/c_SplitRGB.htm
        /// by Donald, donald@xbeat.net, 20010922
        /// </acknowledgment>
        [DisplayName("Split Int Color to ARGB")]
        [Description("Split an integer based ARGB color into the individual components.")]
        [Acknowledgment("http://xbeat.net/vbspeed/c_SplitRGB.htm")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (byte Alpha, byte Red, byte Green, byte Blue) SplitRGB02(uint color)
        {
            return (
                Alpha: (byte)((color & 0xFF000000) / 0x1000000),
                Red: (byte)((color & 0x00FF0000) / 0x0010000),
                Green: (byte)((color & 0x0000FF00) / 0x0000100),
                Blue: (byte)(color & 0x000000FF)
            );
        }
    }
}
