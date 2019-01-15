using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;
using static InstrumentedLibrary.Maths;
using System.Linq;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The quadratic roots tests class.
    /// </summary>
    [DisplayName("Quadratic Roots")]
    [Description("Find the real roots of a Quadratic polynomial.")]
    [SourceCodeLocationProvider]
    public static class QuadraticRootsTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(QuadraticRootsTests))]
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
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static IList<double> QuadraticRoots(double a, double b, double c, double epsilon = Epsilon)
            => QuadraticRootsKevinLinDev(a, b, c, epsilon);

        /// <summary>
        /// The quadratic roots.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name = "epsilon"> The minimal value to represent a change.</param>
        /// <returns>The <see cref="T:List{double}"/>.</returns>
        /// <acknowledgment>
        /// http://www.kevlindev.com/geometry/2D/intersections/
        /// </acknowledgment>
        [DisplayName("Quadratic Roots Kevin Lin Dev")]
        [Description("Find real Quadratic Roots.")]
        [Acknowledgment("http://www.kevlindev.com/geometry/2D/intersections/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IList<double> QuadraticRootsKevinLinDev(double a, double b, double c, double epsilon = Epsilon)
        {
            // If a is 0 the polynomial is linear.
            if (a is 0d)
            {
                return LinearRootsTests.LinearRoots(b, c, epsilon);
            }

            var b_ = b / a;
            var c_ = c / a;

            // Polynomial discriminant.
            var discriminant = (b_ * b_) - (4d * c_);
            if (Abs(discriminant) <= epsilon)
            {
                discriminant = 0d;
            }

            // ToDo: May need to switch from a hash set to a list for scan-beams.
            var results = new HashSet<double>();
            if (discriminant > 0d)
            {
                // Complex or duplicate roots.
                var e = Sqrt(discriminant);
                results.Add(OneHalf * (-b_ + e));
                results.Add(OneHalf * (-b_ - e));
            }
            else if (discriminant == 0)
            {
                // There should actually be two roots with same value, but we will only return one.
                results.Add(OneHalf * -b_);
            }

            return results.ToList();
        }

        /// <summary>
        /// The quadratic equation.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns>The <see cref="T:List{double}"/>.</returns>
        [DisplayName("Quadratic Equation")]
        [Description("Quadratic Equation.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IList<double> QuadraticEquation(double a, double b, double c, double epsilon = Epsilon)
        {
            // If a is 0 the polynomial is linear.
            if (a is 0d)
            {
                return LinearRootsTests.LinearRoots(b, c, epsilon);
            }

            return new List<double>{
                (-b - Sqrt((b * b) - (4d * a * c))) / (2d * a),
                (-b + Sqrt((b * b) - (4d * a * c))) / (2d * a),
            };
        }
    }
}
