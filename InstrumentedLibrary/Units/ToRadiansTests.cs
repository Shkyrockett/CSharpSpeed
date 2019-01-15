using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("Convert an angle in Degrees to Radians")]
    [Description("Convert an angle in Degrees to Radians.")]
    [SourceCodeLocationProvider]
    public static class ToRadiansTests
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
                { new object[] { 180d }, new TestCaseResults(description:"180 degrees", trials:trials, expectedReturnValue: Math.PI, epsilon: double.Epsilon) },
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
        /// <param name="degrees"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double ToRadians(this double degrees)
            => ToRadians0(degrees);

        /// <summary>
        /// Convert Degrees to Radians.
        /// </summary>
        /// <param name="degrees">Angle in Degrees.</param>
        /// <returns>Angle in Radians.</returns>
        [DisplayName("Convert an angle in Degrees to Radians")]
        [Description("Convert an angle in Degrees to Radians.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToRadians0(double degrees)
        {
            return degrees * Radian;
        }
    }
}
