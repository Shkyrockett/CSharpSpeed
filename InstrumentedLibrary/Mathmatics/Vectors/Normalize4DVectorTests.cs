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
    /// 
    /// </summary>
    [DisplayName("Normalize 4D Vector Tests")]
    [Description("Normalizes a 4D Vector.")]
    [SourceCodeLocationProvider]
    public static class Normalize4DVectorTests
    {
        /// <summary>
        /// The normalize3d test.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(Normalize3DVectorTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 1d, 0d, 0d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: (0d, 0.70710678118654746d, 0d, 0d), epsilon: double.Epsilon) },
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
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="k"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double i, double j, double k, double L) Normalize(double i, double j, double k, double l)
            => Normalize4D0(i, j, k, l);

        /// <summary>
        /// Normalize a Vector.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="k"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        [DisplayName("Normalize 4D Vector")]
        [Description("Normalize a 4D Vector.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z, double W) Normalize4D0(
            double i, double j, double k, double l)
        {
            return (i / Sqrt((i * i) + (j * j) + (k * k) + (l * l)),
                    j / Sqrt((i * i) + (j * j) + (k * k) + (l * l)),
                    k / Sqrt((i * i) + (j * j) + (k * k) + (l * l)),
                    l / Sqrt((i * i) + (j * j) + (k * k) + (l * l)));
        }
    }
}
