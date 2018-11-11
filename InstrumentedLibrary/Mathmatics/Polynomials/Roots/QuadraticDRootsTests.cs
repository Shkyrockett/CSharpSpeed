using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;
using static InstrumentedLibrary.Maths;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The quadratic d roots tests class.
    /// </summary>
    [DisplayName("Quadratic D Roots")]
    [Description("Find the real D roots of a Quadratic polynomial.")]
    [Signature("public static IList<double> QuadraticDRoots(double aSquare, double bLinear, double cConstant, double epsilon = Epsilon)")]
    [SourceCodeLocationProvider]
    public static class QuadraticDRootsTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(PolynomialRealOrderTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { -2d,  2d, 12d, Epsilon }, new TestCaseResults(description:"A test to find the roots of the Polynomial: -2x² + 2x + 12", trials:trials, expectedReturnValue:new List<double> {3d, -2d}, epsilon:double.Epsilon) },
                { new object[] {  1d,  2d,  1d, Epsilon }, new TestCaseResults(description:"A test to find the roots of the Polynomial: x² + 2x + 1", trials:trials, expectedReturnValue:new List<double> {-1d}, epsilon:double.Epsilon) },
                { new object[] {  3d,  9d,  6d, Epsilon }, new TestCaseResults(description:"A test to find the roots of the Polynomial: 3x² + 9x + 6", trials:trials, expectedReturnValue:new List<double> {-1d, -2d}, epsilon:double.Epsilon) },
                { new object[] { -4d, 16d, 19d, Epsilon }, new TestCaseResults(description:"A test to find the roots of the Polynomial: -4x² + 16x, 19", trials:trials, expectedReturnValue:new List<double> {4.9580398915498076d, -0.95803989154980806d}, epsilon:double.Epsilon) },
                { new object[] {  1d,  2d,  1d, Epsilon }, new TestCaseResults(description:"A test to find the roots of the Polynomial: x² + 2x + 1", trials:trials, expectedReturnValue:new List<double> {-1}, epsilon:double.Epsilon) },
                { new object[] {  3d,  6d,  5d, Epsilon }, new TestCaseResults(description:"A test to find the roots of the Polynomial: 3x² + 6x + 5", trials:trials, expectedReturnValue:new List<double> {}, epsilon:double.Epsilon) },
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
        /// The quadratic roots.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns>The <see cref="T:List{double}"/>.</returns>
        /// <acknowledgment>
        /// http://pomax.github.io/bezierinfo
        /// https://github.com/Pomax/bezierjs/blob/gh-pages/lib/utils.js
        /// </acknowledgment>
        [DisplayName("Quadratic Roots PoMax")]
        [Description("Find real Quadratic Roots.")]
        [Acknowledgment("http://pomax.github.io/bezierinfo", "https://github.com/Pomax/bezierjs/blob/gh-pages/lib/utils.js")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IList<double> QuadraticDRootsPoMax(double a, double b, double c, double epsilon = Epsilon)
        {
            // If a is 0 the polynomial is linear.
            if (a is 0d) return LinearRootsTests.LinearRoots(b, c, epsilon);

            var d = a - (2d * b) + c;
            if (d != 0)
            {
                // The 4 is missing?
                var m1 = -Sqrt((b * b) - (a * c));
                var m2 = -a + b;
                var v1 = -(m1 + m2) / d;
                var v2 = -(-m1 + m2) / d;
                return new List<double> { v1, v2 };
            }
            else if (b != c && d == 0d)
            {
                return new List<double> { ((2d * b) - c) / (2d * (b - c)) };
            }

            return new List<double>();
        }
    }
}
