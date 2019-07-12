using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The linear roots tests class.
    /// </summary>
    [DisplayName("Linear Roots")]
    [Description("Find the real roots of a Linear polynomial.")]
    [SourceCodeLocationProvider]
    public static class LinearRootsTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(LinearRootsTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 2d, Epsilon }, new TestCaseResults(description: "Dumb Polynomial test.", trials: trials, expectedReturnValue: new List<double>{-2d }, epsilon: double.Epsilon) },
                { new object[] { 2d, 1d, Epsilon }, new TestCaseResults(description: "Dumb Polynomial test.", trials: trials, expectedReturnValue: new List<double>{-0.5d }, epsilon: double.Epsilon) },
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
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static IList<double> LinearRoots(double a, double b, double epsilon = Epsilon)
            => LinearRoots0(a, b, epsilon);

        /// <summary>
        /// The linear roots.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns>The <see cref="List{T}"/>.</returns>
        /// <acknowledgment>
        /// http://www.kevlindev.com/geometry/2D/intersections/
        /// </acknowledgment>
        [DisplayName("Linear Roots")]
        [Description("Find real Linear Roots.")]
        [Acknowledgment("http://www.kevlindev.com/geometry/2D/intersections/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IList<double> LinearRoots0(double a, double b, double epsilon = Epsilon)
        {
            // If a is 0 the polynomial is a constant expression.
            if (a is 0d)
            {
                return new List<double> { b };
            }

            var result = new HashSet<double>();
            if (!(Abs(a) <= epsilon))
            {
                result.Add(-b / a);
            }

            return result.ToList();
        }
    }
}
