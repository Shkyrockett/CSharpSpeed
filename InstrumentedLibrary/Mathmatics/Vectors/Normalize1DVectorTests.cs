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
    [DisplayName("Find the Normal of a value")]
    [Description("Find the Normal of a value.")]
    [SourceCodeLocationProvider]
    public static class Normalize1DVectorTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(GetUnitNormal2DTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 5 }, new TestCaseResults(description: "", trials: trials, expectedReturnValue: 1d, epsilon: double.Epsilon) },
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
        /// <param name="v"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static double Normalize1D(double v)
            => Normalize1D_0(v);

        /// <summary>
        /// Normalize a Vector.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [DisplayName("Find the Normal of a value")]
        [Description("Find the Normal of a value.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Normalize1D_0(double v)
        {
            return v / Sqrt(v * v);
        }
    }
}
