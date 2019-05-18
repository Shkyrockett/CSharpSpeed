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
    [DisplayName("Validate a CYMKA color")]
    [Description("Validate a CYMKA color.")]
    [SourceCodeLocationProvider]
    public static class ValidateCYMKAByteTests
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
                { new object[] { (byte)0, (byte)0, (byte)0, (byte)0, (byte)255 }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: true) },
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
        /// Check whether a cyan yellow magenta black color is valid.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="y">The y.</param>
        /// <param name="m">The m.</param>
        /// <param name="k">The k.</param>
        /// <param name="a"></param>
        /// <returns>The <see cref="bool"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static bool ValidateCYMKA(byte c, byte y, byte m, byte k, byte a)
            => ValidateCYMKA1(c, y, m, k, a);

        /// <summary>
        /// Check whether a cyan yellow magenta black color is valid.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="y">The y.</param>
        /// <param name="m">The m.</param>
        /// <param name="k">The k.</param>
        /// <param name="a"></param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <remarks>https://www.codeproject.com/articles/4488/xcmyk-cmyk-to-rgb-calculator-with-source-code</remarks>
        [DisplayName("Validate a CYMKA color")]
        [Description("Validate a CYMKA color.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ValidateCYMKA1(byte c, byte y, byte m, byte k, byte a)
        {
            return ValueBetweenByteTests.Between(a, CYMKMin, CYMKMax)
                   && ValueBetweenByteTests.Between(c, CYMKMin, CYMKMax)
                   && ValueBetweenByteTests.Between(y, CYMKMin, CYMKMax)
                   && ValueBetweenByteTests.Between(m, CYMKMin, CYMKMax)
                   && ValueBetweenByteTests.Between(k, CYMKMin, CYMKMax);
        }
    }
}
