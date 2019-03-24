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
    [DisplayName("Get the Luminance from an RGB color")]
    [Description("Get the Luminance from an RGB color.")]
    [SourceCodeLocationProvider]
    public static class GetLuminanceFromRGBByteTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(ToDegreesTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { (byte)0, (byte)0,(byte) 0 }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: 1d, epsilon: 0f) },
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
        /// Get the brightness.
        /// </summary>
        /// <returns>The <see cref="float"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double GetLuminance(byte red, byte green, byte blue)
            => GetLuminance1(red, green, blue);

        /// <summary>
        /// Get the brightness.
        /// </summary>
        /// <returns>The <see cref="float"/>.</returns>
        /// <remarks>
        /// https://referencesource.microsoft.com/#System.Drawing/commonui/System/Drawing/Color.cs
        /// </remarks>
        [DisplayName("Get the Luminance from an RGB color")]
        [Description("Get the Luminance from an RGB color.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetLuminance1(byte red, byte green, byte blue)
        {
            var r = red / 255d;
            var g = green / 255d;
            var b = blue / 255d;

            var max = r;
            if (g > max)
            {
                max = g;
            }

            if (b > max)
            {
                max = b;
            }

            var min = r;
            if (g < min)
            {
                min = g;
            }

            if (b < min)
            {
                min = b;
            }

            return (max + min) / 2d;
        }
    }
}
