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
    public static class GetHueFromRGBByteTests
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
                { new object[] { (byte)0f, (byte)0f, (byte)0f }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: 1d, epsilon: 0f) },
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
        /// Get the hue.
        /// </summary>
        /// <returns>The <see cref="float"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double GetHue(byte red, byte green, byte blue)
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
        public static double GetHue1(byte red, byte green, byte blue)
        {
            if (red == green && green == blue)
            {
                return 0; // 0 makes as good an UNDEFINED value as any
            }

            var r = red / 255d;
            var g = green / 255d;
            var b = blue / 255d;

            var hue = 0d;

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

            var delta = max - min;

            if (r == max)
            {
                hue = (g - b) / delta;
            }
            else if (g == max)
            {
                hue = 2d + ((b - r) / delta);
            }
            else if (b == max)
            {
                hue = 4d + ((r - g) / delta);
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
