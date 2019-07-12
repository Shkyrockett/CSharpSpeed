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
    /// 
    /// </summary>
    [DisplayName("Rotate Vector About Y Yaw Test")]
    [Description("Rotate Vector About Y Yaw.")]
    [SourceCodeLocationProvider]
    public static class YawRotateYOffsetTests
    {
        /// <summary>
        /// Set of tests to run testing methods.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(ToDegreesTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 0d, 1d, 1d, PI }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (1.9999999999999998d, 0d, 2d), epsilon: double.Epsilon) },
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
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="z1"></param>
        /// <param name="yOff"></param>
        /// <param name="zOff"></param>
        /// <param name="rad"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y, double Z) RotateY(double x1, double y1, double z1, double yOff, double zOff, double rad)
            => RotateY1(x1, y1, z1, yOff, zOff, rad);

        /// <summary>
        /// The rotate y.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="z1">The z1.</param>
        /// <param name="xOff">The xOff.</param>
        /// <param name="zOff">The zOff.</param>
        /// <param name="rad">The rad.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <acknowledgment>
        /// http://www.codeproject.com/Articles/17425/A-Vector-Type-for-C
        /// </acknowledgment>
        [DisplayName("Rotate Vector About Y Yaw")]
        [Description("Rotate Vector About Y Yaw.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) RotateY1(double x1, double y1, double z1, double xOff, double zOff, double rad)
        {
            var sin = Sin(rad);
            var cos = Cos(rad);
            return (
                    (z1 * sin) + (x1 * cos) + (xOff * (1 - cos) - zOff * sin),
                    y1,
                    (z1 * cos) - (x1 * sin) + (zOff * (1 - cos) + xOff * sin)
                    );
        }
    }
}
