using CSharpSpeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The min point tests class.
    /// </summary>
    [DisplayName("Min Point")]
    [Description("Finds the minimum of two points.")]
    [SourceCodeLocationProvider]
    public static class MinPointTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(MinPointTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 1d, 1d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (0d, 0d), epsilon: double.Epsilon) },
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
        /// <param name="point1X"></param>
        /// <param name="point1Y"></param>
        /// <param name="point2X"></param>
        /// <param name="point2Y"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y) MinPoint(double point1X, double point1Y, double point2X, double point2Y)
            => MinPoint0(point1X, point1Y, point2X, point2Y);

        /// <summary>
        /// The min point.
        /// </summary>
        /// <param name="point1X">The point1X.</param>
        /// <param name="point1Y">The point1Y.</param>
        /// <param name="point2X">The point2X.</param>
        /// <param name="point2Y">The point2Y.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
        /// <acknowledgment>
        /// http://www.kevlindev.com/
        /// </acknowledgment>
        [DisplayName("Min Point")]
        [Description("Finds the minimum of two points.")]
        [Acknowledgment("http://www.kevlindev.com/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y) MinPoint0(double point1X, double point1Y, double point2X, double point2Y)
        {
            return (Min(point1X, point2X), Min(point1Y, point2Y));
        }
    }
}
