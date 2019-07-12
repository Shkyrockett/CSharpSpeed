using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// Convert an angle in Radians to Degrees.
    /// </summary>
    [DisplayName("Convert an angle in Radians to Degrees")]
    [Description("Convert an angle in Radians to Degrees.")]
    [SourceCodeLocationProvider]
    public static class ToDegreesTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(ToDegreesTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { Math.PI }, new TestCaseResults(description: "180 degrees", trials: trials, expectedReturnValue: 180d, epsilon: double.Epsilon) },
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
        /// <param name="radians"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double ToDegrees(this double radians)
            => ToDegrees0(radians);

        /// <summary>
        /// Convert Radians to Degrees.
        /// </summary>
        /// <param name="radians">Angle in Radians.</param>
        /// <returns>Angle in Degrees.</returns>
        [DisplayName("Convert an angle in Radians to Degrees")]
        [Description("Convert an angle in Radians to Degrees.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDegrees0(double radians)
        {
            return radians * Degree;
        }
    }
}
