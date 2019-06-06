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
    public static class GetSaturationFromRGBFloatTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(GetSaturationFromRGBFloatTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 0d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: 1d, epsilon: 0d) },
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
        public static double GetSaturation(double red, double green, double blue)
            => GetSaturation_(red, green, blue);

        /// <summary>
        /// Get the saturation.
        /// </summary>
        /// <returns>The <see cref="float"/>.</returns>
        /// <remarks>
        /// https://referencesource.microsoft.com/#System.Drawing/commonui/System/Drawing/Color.cs
        /// </remarks>
        [DisplayName("Get the Saturation from an RGB color")]
        [Description("Get the Saturation from an RGB color.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetSaturation_(double red, double green, double blue)
        {
            var max = red;
            if (green > max)
            {
                max = green;
            }

            if (blue > max)
            {
                max = blue;
            }

            var min = red;
            if (green < min)
            {
                min = green;
            }

            if (blue < min)
            {
                min = blue;
            }

            var s = 0d;
            // if max == min, then there is no color and
            // the saturation is zero.
            if (max != min)
            {
                var l = (max + min) / 2d;
                s = l <= 0.5d ? (max - min) / (max + min) : (max - min) / (2d - max - min);
            }
            return s;
        }
    }
}
