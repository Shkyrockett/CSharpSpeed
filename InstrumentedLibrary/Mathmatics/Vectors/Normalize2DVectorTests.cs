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
    /// The normalize2d tests class.
    /// </summary>
    [DisplayName("Normalize 2D Vector Tests")]
    [Description("Normalizes a 2D Vector.")]
    [Signature("public static (double i, double j) Normalize(double i, double j)")]
    [SourceCodeLocationProvider]
    public static class Normalize2DVectorTests
    {
        /// <summary>
        /// The normalize2d test.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(Normalize2DVectorTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 0d, 1d }, new TestCaseResults(description:"0, 1.", trials:trials, expectedReturnValue:(0d, 1d), epsilon:double.Epsilon) }
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
        /// The normalize.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns>The <see cref="T:(double X, double Y)"/>.</returns>
        [DisplayName("Normalize 2D Vector")]
        [Description("Normalize a 2D Vector.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double i, double j) Normalize(double i, double j)
        {
            return (
                i / Sqrt((i * i) + (j * j)),
                j / Sqrt((i * i) + (j * j))
                );
        }
    }
}
