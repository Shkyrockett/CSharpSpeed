using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static InstrumentedLibrary.Maths;
using static System.Math;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The cubic roots tests class.
    /// </summary>
    [DisplayName("Complex Cubic Roots")]
    [Description("Find the Complex roots of a Cubic polynomial.")]
    [SourceCodeLocationProvider]
    public static class ComplexCubicRootsTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(ComplexCubicRootsTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 2d, 3d, 4d, Epsilon }, new TestCaseResults(description: "Dumb Polynomial test.", trials: trials, expectedReturnValue: new List<Complex> {new Complex(-1.6506291914393878d, -0), new Complex(-0.17468540428030593d, 1.546868887231396), new Complex(-0.17468540428030593d, -1.546868887231396d)}, epsilon: double.Epsilon) },
                { new object[] { 4d, 3d, 2d, 1d, Epsilon }, new TestCaseResults(description: "Dumb Polynomial test.", trials: trials, expectedReturnValue: new List<Complex> {new Complex(-0.60582958618826788d, -0), new Complex(-0.07208520690586602d, 0.63832673514837635), new Complex(-0.07208520690586602d, -0.63832673514837635d)}, epsilon: double.Epsilon) },
                { new object[] { 1d, 3d, -6d, 18d, Epsilon }, new TestCaseResults(description: "Dumb Polynomial test.", trials: trials, expectedReturnValue: new List<Complex> { new Complex(-4.94788592337517d, -0), new Complex(0.97394296168758532d, 1.6399245250888428), new Complex(0.97394296168758532d, -1.6399245250888428d)}, epsilon: double.Epsilon) },
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
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static IList<Complex> ComplexCubicRoots(double a, double b, double c, double d, double epsilon = Epsilon)
            => SolveCubicDDanbe(a, b, c, d, epsilon);

        /// <summary>
        /// Solve ax^3+bx^2+cx+d=0 for x.
        /// Calculation of the 3 roots of a cubic equation according to
        /// Using the complex struct from System.Numerics
        /// Visual Studio 2010, .NET version 4.0
        /// </summary>
        /// <param name="a">real coefficient of x to the 3th power</param>
        /// <param name="b">real coefficient of x to the 2nd power</param>
        /// <param name="c">real coefficient of x to the 1th power</param>
        /// <param name="d">real coefficient of x to the zeroth power</param>
        /// <param name="epsilon"></param>
        /// <returns>A list of 3 complex numbers</returns>
        /// <acknowledgment>
        /// https://www.daniweb.com/programming/software-development/code/454493/solving-the-cubic-equation-using-the-complex-struct
        /// http://en.wikipedia.org/wiki/Cubic_function#General_formula_for_roots
        /// </acknowledgment>
        [DisplayName("Solve Cubic Roots")]
        [Description("Find real Cubic Roots.")]
        [Acknowledgment("https://www.daniweb.com/programming/software-development/code/454493/solving-the-cubic-equation-using-the-complex-struct", "http://en.wikipedia.org/wiki/Cubic_function#General_formula_for_roots")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IList<Complex> SolveCubicDDanbe(double a, double b, double c, double d, double epsilon = Epsilon)
        {
            _ = epsilon;
            const int NRoots = 3;
            var SquareRootof3 = Sqrt(3);

            // the 3 cubic roots of 1
            var CubicUnity = new List<Complex>(NRoots) { new Complex(1, 0), new Complex(-0.5d, -SquareRootof3 / 2d), new Complex(-0.5d, SquareRootof3 / 2d) };

            // intermediate calculations
            var DELTA = (18d * a * b * c * d) - (4d * b * b * b * d) + (b * b * c * c) - (4d * a * c * c * c) - (27d * a * a * d * d);
            var DELTA0 = (b * b) - (3d * a * c);
            var DELTA1 = (2d * b * b * b) - (9d * a * b * c) + (27d * a * a * d);
            Complex DELTA2 = -27d * a * a * DELTA;
            var C = Complex.Pow((DELTA1 + Complex.Pow(DELTA2, 0.5d)) / 2d, 1d / 3d); //Phew...

            var R = new List<Complex>(NRoots);
            for (var i = 0; i < NRoots; i++)
            {
                var M = CubicUnity[i] * C;
                var Root = -1d / (3d * a) * (b + M + (DELTA0 / M));
                R.Add(Root);
            }
            return R;
        }
    }
}
