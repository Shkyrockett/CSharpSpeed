using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The linear d roots tests class.
    /// </summary>
    [DisplayName("Linear D Roots")]
    [Description("Find the real D roots of a Linear polynomial.")]
    [SourceCodeLocationProvider]
    public static class LinearDRootsTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(LinearDRootsTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 2d, Epsilon }, new TestCaseResults(description: "Dumb Polynomial test.", trials: trials, expectedReturnValue: new List<double>{-2d }, epsilon: double.Epsilon) },
                { new object[] { 2d, 1d, Epsilon }, new TestCaseResults(description: "Dumb Polynomial test.", trials: trials, expectedReturnValue: new List<double>{-0.5d }, epsilon: double.Epsilon) },
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
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static List<double> LinearDRoots(double a, double b, double epsilon = Epsilon)
            => LinearDRootsPoMax(a, b, epsilon);

        /// <summary>
        /// The linear roots.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns>The <see cref="T:List{double}"/>.</returns>
        /// <acknowledgment>
        /// http://pomax.github.io/bezierinfo
        /// </acknowledgment>
        [DisplayName("Linear D Roots")]
        [Description("Find real Linear D Roots.")]
        [Acknowledgment("http://pomax.github.io/bezierinfo")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<double> LinearDRootsPoMax(double a, double b, double epsilon = Epsilon)
        {
            if (a != b)
            {
                return new List<double> { a / (a - b) };
            }

            return new List<double>();
        }

        /// <summary>
        /// The linear d roots.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns>The <see cref="T:IList{double}"/>.</returns>
        /// <acknowledgment>
        /// http://pomax.github.io/bezierinfo/
        /// https://github.com/Pomax/bezierjs/blob/gh-pages/lib/utils.js
        /// </acknowledgment>
        [DisplayName("Linear D Roots")]
        [Description("Find real Linear D Roots.")]
        [Acknowledgment("http://pomax.github.io/bezierinfo/", "https://github.com/Pomax/bezierjs/blob/gh-pages/lib/utils.js")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IList<double> LinearDRoots0(double a, double b, double epsilon = Epsilon)
        {
            return a != b ? (new double[] { a / (a - b) }) : (new double[] { });
        }
    }
}
