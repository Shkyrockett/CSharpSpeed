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
    [DisplayName("Get the Hue from an RGB color")]
    [Description("Get the Hue from an RGB color.")]
    [SourceCodeLocationProvider]
    public static class GetHueFromRGBFloatTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(GetHueFromRGBFloatTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 0d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: 1d, epsilon: 0f) },
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
        /// Get the hue.
        /// </summary>
        /// <returns>The <see cref="float"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double GetHue(double red, double green, double blue)
            => GetHue1(red, green, blue);

        /// <summary>
        /// Get the hue.
        /// </summary>
        /// <returns>The <see cref="float"/>.</returns>
        /// <remarks>
        /// https://referencesource.microsoft.com/#System.Drawing/commonui/System/Drawing/Color.cs
        /// </remarks>
        [DisplayName("Get the Hue from an RGB color")]
        [Description("Get the Hue from an RGB color.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetHue1(double red, double green, double blue)
        {
            if (red == green && green == blue)
            {
                return 0; // 0 makes as good an UNDEFINED value as any
            }

            var hue = 0d;

            var max = red;
            var min = red;

            if (green > max)
            {
                max = green;
            }

            if (blue > max)
            {
                max = blue;
            }

            if (green < min)
            {
                min = green;
            }

            if (blue < min)
            {
                min = blue;
            }

            var delta = max - min;

            if (red == max)
            {
                hue = (green - blue) / delta;
            }
            else if (green == max)
            {
                hue = 2 + ((blue - red) / delta);
            }
            else if (blue == max)
            {
                hue = 4 + ((red - green) / delta);
            }
            hue *= 60d;

            if (hue < 0d)
            {
                hue += 360d;
            }
            return hue;
        }
    }
}
