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
    [DisplayName("Normalize two 2D Vectors Tests")]
    [Description("Normalizes two 2D Vectors.")]
    [SourceCodeLocationProvider]
    public static class NormalizeTwoVectors2DTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(NormalizeTwoVectors2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 1d, 1d, 2d }, new TestCaseResults(description: "0, 1.", trials: trials, expectedReturnValue:(0d, 1d), epsilon: double.Epsilon) },
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
        /// <param name="aI"></param>
        /// <param name="aJ"></param>
        /// <param name="bI"></param>
        /// <param name="bJ"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double I, double J) Normalize(double aI, double aJ, double bI, double bJ)
            => Normalize0(aI, aJ, bI, bJ);

        /// <summary>
        /// Find the Normal of Two points.
        /// </summary>
        /// <param name="aI">The x component of the first Point.</param>
        /// <param name="aJ">The y component of the first Point.</param>
        /// <param name="bI">The x component of the second Point.</param>
        /// <param name="bJ">The y component of the second Point.</param>
        /// <returns>The Normal of two Points</returns>
        [DisplayName("Normalize two 2D Vectors")]
        [Description("Normalize two 2D Vectors.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double I, double J) Normalize0(
            double aI, double aJ,
            double bI, double bJ)
        {
            return (
                aI / Sqrt((aI * bI) + (aJ * bJ)),
                aJ / Sqrt((aI * bI) + (aJ * bJ))
                );
        }
    }
}
