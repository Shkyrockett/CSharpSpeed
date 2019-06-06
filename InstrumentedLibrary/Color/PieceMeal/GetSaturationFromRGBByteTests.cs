using CSharpSpeed;
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
    [DisplayName("Get the Saturation from an RGB color")]
    [Description("Get the Saturation from an RGB color.")]
    [SourceCodeLocationProvider]
    public static class GetSaturationFromRGBByteTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(GetSaturationFromRGBByteTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { (byte)0, (byte)0, (byte)0}, new TestCaseResults(description: "", trials: trials, expectedReturnValue: 1d, epsilon: 0d) },
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
        /// Get the saturation.
        /// </summary>
        /// <returns>The <see cref="double"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double GetSaturation(byte red, byte green, byte blue)
            => GetSaturation1(red, green, blue);

        /// <summary>
        /// Get the saturation.
        /// </summary>
        /// <returns>The <see cref="double"/>.</returns>
        /// <remarks>
        /// https://referencesource.microsoft.com/#System.Drawing/commonui/System/Drawing/Color.cs
        /// </remarks>
        [DisplayName("Get the Saturation from an RGB color")]
        [Description("Get the Saturation from an RGB color.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetSaturation1(byte red, byte green, byte blue)
        {
            var r = red / 255d;
            var g = green / 255d;
            var b = blue / 255d;
            var max = r;
            var min = r;

            if (g > max)
            {
                max = g;
            }

            if (b > max)
            {
                max = b;
            }

            if (g < min)
            {
                min = g;
            }

            if (b < min)
            {
                min = b;
            }

            var s = 0d;
            // if max == min, then there is no color and
            // the saturation is zero.
            if (max != min)
            {
                var l = (max + min) * 0.5d;

                s = l <= 0.5d ? (max - min) / (max + min) : (max - min) / (2d - max - min);
            }
            return s;
        }
    }
}
