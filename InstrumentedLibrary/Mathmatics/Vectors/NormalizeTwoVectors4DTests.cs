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
    [DisplayName("Normalize two 4D Vectors Tests")]
    [Description("Normalizes two 4D Vectors.")]
    [SourceCodeLocationProvider]
    public static class NormalizeTwoVectors4DTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(NormalizeTwoVectors3DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 1d, 0d, 0d, 1d, 2d, 0d, 0d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:(0d, 1d, 0d, 0d, 1d, 2d, 0d, 0d), epsilon: double.Epsilon) },
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
        /// <param name="i1"></param>
        /// <param name="j1"></param>
        /// <param name="k1"></param>
        /// <param name="l1"></param>
        /// <param name="i2"></param>
        /// <param name="j2"></param>
        /// <param name="k2"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double X, double Y, double Z, double W) Normalize4D(double i1, double j1, double k1, double l1, double i2, double j2, double k2, double l2)
            => Normalize4D0(i1, j1, k1, l1, i2, j2, k2, l2);

        /// <summary>
        /// Find the Normal of Two vectors.
        /// </summary>
        /// <param name="i1">The x component of the first Point.</param>
        /// <param name="j1">The y component of the first Point.</param>
        /// <param name="k1">The z component of the first Point.</param>
        /// <param name="l1"></param>
        /// <param name="i2">The x component of the second Point.</param>
        /// <param name="j2">The y component of the second Point.</param>
        /// <param name="k2">The z component of the second Point.</param>
        /// <param name="l2"></param>
        /// <returns>The Normal of two Points</returns>
        /// <acknowledgment>
        /// http://www.fundza.com/vectors/normalize/
        /// </acknowledgment>
        [DisplayName("Normalize two 4D Vectors")]
        [Description("Normalize two 4D Vectors.")]
        [Acknowledgment("http://www.fundza.com/vectors/normalize/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double X, double Y, double Z, double W) Normalize4D0(
            double i1, double j1, double k1, double l1,
            double i2, double j2, double k2, double l2)
        {
            return (
                    i1 / Sqrt((i1 * i2) + (j1 * j2) + (k1 * k2) + (l1 * l2)),
                    j1 / Sqrt((i1 * i2) + (j1 * j2) + (k1 * k2) + (l1 * l2)),
                    k1 / Sqrt((i1 * i2) + (j1 * j2) + (k1 * k2) + (l1 * l2)),
                    l1 / Sqrt((i1 * i2) + (j1 * j2) + (k1 * k2) + (l1 * l2)));
        }
    }
}
