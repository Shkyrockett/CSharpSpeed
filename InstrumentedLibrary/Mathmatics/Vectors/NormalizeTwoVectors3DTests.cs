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
    /// The normalize two vectors tests class.
    /// </summary>
    [DisplayName("Normalize two 3D Vectors Tests")]
    [Description("Normalizes two 3D Vectors.")]
    [SourceCodeLocationProvider]
    public static class NormalizeTwoVectors3DTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(NormalizeTwoVectors3DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 1d, 0d, 1d, 2d, 0d }, new TestCaseResults(description: "", trials: trials, expectedReturnValue:(0d, 1d), epsilon: double.Epsilon) },
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
        /// <param name="aI"></param>
        /// <param name="aJ"></param>
        /// <param name="aK"></param>
        /// <param name="bI"></param>
        /// <param name="bJ"></param>
        /// <param name="bK"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double I, double J, double K) Normalize(double aI, double aJ, double aK, double bI, double bJ, double bK)
            => Normalize0(aI, aJ, aK, bI, bJ, bK);

        /// <summary>
        /// Find the Normal of Two points.
        /// </summary>
        /// <param name="aI">The x component of the first Point.</param>
        /// <param name="aJ">The y component of the first Point.</param>
        /// <param name="aK">The z component of the first Point.</param>
        /// <param name="bI">The x component of the second Point.</param>
        /// <param name="bJ">The y component of the second Point.</param>
        /// <param name="bK">The z component of the second Point.</param>
        /// <returns>The Normal of two Points</returns>
        /// <acknowledgment>
        /// http://www.fundza.com/vectors/normalize/
        /// </acknowledgment>
        [DisplayName("Normalize two 3D Vectors")]
        [Description("Normalize two 3D Vectors.")]
        [Acknowledgment("http://www.fundza.com/vectors/normalize/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double I, double J, double K) Normalize0(
            double aI, double aJ, double aK,
            double bI, double bJ, double bK)
        {
            return (
                aI / Sqrt((aI * bI) + (aJ * bJ) + (aK * bK)),
                aJ / Sqrt((aI * bI) + (aJ * bJ) + (aK * bK)),
                aK / Sqrt((aI * bI) + (aJ * bJ) + (aK * bK))
                );
        }
    }
}
