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
    /// 
    /// </summary>
    [DisplayName("Convert an angle in Radians to Degrees")]
    [Description("Convert an angle in Radians to Degrees.")]
    [SourceCodeLocationProvider]
    public static class ToDegreesTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the 1D Hermite interpolation of points.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(ToDegreesTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { Math.PI }, new TestCaseResults(description: "180 degrees", trials: trials, expectedReturnValue: 180d, epsilon: double.Epsilon) },
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
        /// <param name="radiens"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double ToDegrees(this double radiens)
            => ToDegrees0(radiens);

        /// <summary>
        /// Convert Radians to Degrees.
        /// </summary>
        /// <param name="radiens">Angle in Radians.</param>
        /// <returns>Angle in Degrees.</returns>
        [DisplayName("Convert an angle in Radians to Degrees")]
        [Description("Convert an angle in Radians to Degrees.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDegrees0(double radiens)
        {
            return radiens * Degree;
        }
    }
}
