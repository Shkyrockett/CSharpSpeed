using CSharpSpeed;
using System;
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
    [DisplayName("Vector Rejection Test")]
    [Description("Vector Rejection.")]
    [SourceCodeLocationProvider]
    public static class Rejection3DTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DisplayName(nameof(ToDegreesTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 0d, 0d, 1d, 0d, 0d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (0d, 0d, 0d), epsilon: double.Epsilon) },
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
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="z2"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y, double Z) Rejection(double x1, double y1, double z1, double x2, double y2, double z2)
            => Rejection_(x1, y1, z1, x2, y2, z2);

        /// <summary>
        /// The rejection.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="z1">The z1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="z2">The z2.</param>
        /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
        /// <acknowledgment>
        /// http://www.codeproject.com/Articles/17425/A-Vector-Type-for-C
        /// </acknowledgment>
        [DisplayName("Vector Rejection Test")]
        [Description("Vector Rejection.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z) Rejection_(
            double x1, double y1, double z1,
            double x2, double y2, double z2)
        {
            var magnitude = VectorMagnitude3D.Magnitude(x2, y2, z2);
            var dotProduct = DotProduct2Vector3DTests.DotProduct(x1, y1, z1, x2, y2, z2);
            return (x1 - x2 * dotProduct / magnitude * magnitude,
                    z1 - y2 * dotProduct / magnitude * magnitude,
                    z1 - z2 * dotProduct / magnitude * magnitude);
        }
    }
}
