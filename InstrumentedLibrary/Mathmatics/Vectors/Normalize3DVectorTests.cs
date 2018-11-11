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
    /// The normalize3d vector tests class.
    /// </summary>
    [DisplayName("Normalize 3D Vector Tests")]
    [Description("Normalizes a 3D Vector.")]
    [Signature("public static (double i, double j, double k) Normalize(double i, double j, double k)")]
    [SourceCodeLocationProvider]
    public static class Normalize3DVectorTests
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
                { new object[] { 0d, 1d, 0d }, new TestCaseResults(description:"0, 1, 0.", trials:trials, expectedReturnValue:(0d, 1d, 0d), epsilon:double.Epsilon) }
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
        /// <param name="k">The k.</param>
        /// <returns>The <see cref="T:(double X, double Y, double Z)"/>.</returns>
        [DisplayName("Normalize 3D Vector")]
        [Description("Normalize a 3D Vector.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double i, double j, double k) Normalize(double i, double j, double k)
        {
            return (
                i / Sqrt((i * i) + (j * j) + (k * k)),
                j / Sqrt((i * i) + (j * j) + (k * k)),
                k / Sqrt((i * i) + (j * j) + (k * k))
                );
        }
    }
}
