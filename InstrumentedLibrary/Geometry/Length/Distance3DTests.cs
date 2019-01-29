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
    /// The distance3d tests class.
    /// </summary>
    [DisplayName("3D Distance Tests")]
    [Description("Find the distance between two 3D points.")]
    [SourceCodeLocationProvider]
    public static class Distance3DTests
    {
        /// <summary>
        /// Set of tests to run testing methods that calculate the distance between two 3D points.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(Distance3DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 0d, 0d, 1d, 0d, 0d }, new TestCaseResults(description: "Horizontal Line.", trials: trials, expectedReturnValue:1d, epsilon: double.Epsilon) },
                { new object[] { 0d, 0d, 0d, 1d, 0d, 1d }, new TestCaseResults(description: "Horizontal Line.", trials: trials, expectedReturnValue:1d, epsilon: double.Epsilon) },
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
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="z1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="z2"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double Distance3D(double x1, double y1, double z1, double x2, double y2, double z2)
            => Distance3D_1(x1, y1, z1, x2, y2, z2);

        /// <summary>
        /// Distance between two 3D points.
        /// </summary>
        /// <param name="x1">First X component.</param>
        /// <param name="y1">First Y component.</param>
        /// <param name="z1">First Z component.</param>
        /// <param name="x2">Second X component.</param>
        /// <param name="y2">Second Y component.</param>
        /// <param name="z2">Second Z component.</param>
        /// <returns>The distance between two points.</returns>
        [DisplayName("Distance Method 1")]
        [Description("This is the simple, most obvious implementation of the distance method.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Distance3D_1(
            double x1, double y1, double z1,
            double x2, double y2, double z2)
        {
            return Sqrt(((x2 - x1) * (x2 - x1))
                           + ((y2 - y1) * (y2 - y1))
                           + ((z2 - z1) * (z2 - z1)));
        }

        /// <summary>
        /// Distance between two 3D points.
        /// </summary>
        /// <param name="x1">First X component.</param>
        /// <param name="y1">First Y component.</param>
        /// <param name="z1">First Z component.</param>
        /// <param name="x2">Second X component.</param>
        /// <param name="y2">Second Y component.</param>
        /// <param name="z2">Second Z component.</param>
        /// <returns>The distance between two points.</returns>
        [DisplayName("Distance Method 2")]
        [Description("This method uses two delta local variables. The allocation of the variables seems to make the method slightly slower.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Distance3D_2(
            double x1, double y1, double z1,
            double x2, double y2, double z2)
        {
            var x = x2 - x1;
            var y = y2 - y1;
            var z = z2 - z1;
            return Sqrt((x * x) + (y * y) + (z * z));
        }
    }
}
