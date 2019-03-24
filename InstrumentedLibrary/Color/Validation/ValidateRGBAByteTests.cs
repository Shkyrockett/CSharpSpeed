using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Validate a RGBA color")]
    [Description("Validate a RGBA color.")]
    [SourceCodeLocationProvider]
    public static class ValidateRGBAByteTests
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
                { new object[] { (byte)0, (byte)0, (byte)0, (byte)255 }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: true) },
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
        /// Check whether a red green blue color is valid.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <param name="g">The g.</param>
        /// <param name="b">The b.</param>
        /// <param name="a"></param>
        /// <returns>The <see cref="bool"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool ValidateRGBA(byte r, byte g, byte b, byte a)
            => ValidateRGBA1(r, g, b, a);

        /// <summary>
        /// Check whether a red green blue color is valid.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <param name="g">The g.</param>
        /// <param name="b">The b.</param>
        /// <param name="a"></param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <remarks>https://github.com/dystopiancode/colorspace-conversions/</remarks>
        [DisplayName("Validate a RGBA color")]
        [Description("Validate a RGBA color.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ValidateRGBA1(byte r, byte g, byte b, byte a)
        {
            return ValueBetweenByteTests.Between(a, RGBMin, RGBMax)
                   && ValueBetweenByteTests.Between(r, RGBMin, RGBMax)
                   && ValueBetweenByteTests.Between(g, RGBMin, RGBMax)
                   && ValueBetweenByteTests.Between(b, RGBMin, RGBMax);
        }
    }
}
