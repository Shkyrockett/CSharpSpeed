using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The circle area tests class.
    /// </summary>
    [DisplayName("Area of Circle")]
    [Description("Find the area of a circle.")]
    [SourceCodeLocationProvider]
    public static class CircleAreaTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(CircleAreaTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d }, new TestCaseResults(description:"Unit Circle.", trials:trials, expectedReturnValue:1.2283696986087567d, epsilon:double.Epsilon) },
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
        /// <param name="radius"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double CircleArea(double radius)
            => StandardCircleArea(radius);

        /// <summary>
        /// Calculates the area of a circle.
        /// </summary>
        /// <param name="r">The radius of the circle.</param>
        /// <returns>Returns the area of the circle.</returns>
        [DisplayName("Area of Circle")]
        [Description("Find the area of a circle.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double StandardCircleArea(double r)
        {
            return PI * r * r;
        }
    }
}
