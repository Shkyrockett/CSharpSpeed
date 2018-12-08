using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Math;
using static InstrumentedLibrary.Maths;
using System.Linq;
using System.Numerics;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The cubic roots tests class.
    /// </summary>
    [DisplayName("Cubic Roots")]
    [Description("Find the real roots of a Cubic polynomial.")]
    [Signature("public static IList<double> CubicRoots(double aCube, double bSquare, double cLinear, double dConstant, double epsilon = Epsilon)")]
    [SourceCodeLocationProvider]
    public static class CubicRootsTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(CubicRootsTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 2d, 3d, 4d, Epsilon }, new TestCaseResults(description:"Dumb Polynomial test.", trials:trials, expectedReturnValue:new List<double>{-1.6506291914393882d }, epsilon:double.Epsilon) },
                { new object[] { 4d, 3d, 2d, 1d, Epsilon }, new TestCaseResults(description:"Dumb Polynomial test.", trials:trials, expectedReturnValue:new List<double>{-0.605829586188268d }, epsilon:double.Epsilon) },
                { new object[] { 1d, 3d, -6d, 18d, Epsilon }, new TestCaseResults(description:"Dumb Polynomial test.", trials:trials, expectedReturnValue:new List<double>{-4.9478859233751713d }, epsilon:double.Epsilon) },
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
        /// Cubic Roots
        /// </summary>
        /// <param name="a">t^3</param>
        /// <param name="b">t^2</param>
        /// <param name="c">t</param>
        /// <param name="d">1</param>
        /// <param name="epsilon">The <paramref name="epsilon"/> or minimal value to represent a change.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// based on https://web.archive.org/web/20170322034124/http://abecedarical.com/javascript/script_exact_cubic.html
        /// </acknowledgment>
        [DisplayName("Cubic Roots")]
        [Description("Find real Cubic Roots  Stephen R. Schmitt.")]
        [Acknowledgment("https://web.archive.org/web/20170322034124/http://abecedarical.com/javascript/script_exact_cubic.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IList<double> CubicRootsStephenRSchmitt(double a, double b, double c, double d, double epsilon = Epsilon)
        {
            // If a is 0 the polynomial is quadratic.
            if (a is 0d)
            {
                return QuadraticRootsTests.QuadraticRootsKevinLinDev(b, c, d, epsilon);
            }

            var A = b / a;
            var B = c / a;
            var C = d / a;

            var Q = ((3d * B) - (A * A)) / 9d;
            var R = (-(2d * A * A * A) + (9d * A * B) - (27d * C)) / 54d;

            var offset = A * OneThird;

            // Polynomial discriminant
            var discriminant = (R * R) + (Q * Q * Q);

            // ToDo: May need to switch from a hash set to a list for scan-beams.
            var results = new HashSet<double>();

            if (Abs(discriminant) <= epsilon)
            {
                discriminant = 0d;
            }

            if (discriminant == 0d)
            {
                var t = Sign(R) * Pow(Abs(R), OneThird);

                // Real root.
                results.Add(-offset + (t + t));

                // Real part of complex root.
                results.Add(-offset - ((t + t) * OneHalf));
            }
            if (discriminant > 0)
            {
                var s = Sign(R + Sqrt(discriminant)) * Pow(Abs(R + Sqrt(discriminant)), OneThird);
                var t = Sign(R - Sqrt(discriminant)) * Pow(Abs(R - Sqrt(discriminant)), OneThird);

                // Real root.
                results.Add(-offset + (s + t));

                // Complex part of root pair.
                var Im = Abs(Sqrt(3d) * (s - t) * OneHalf);
                if (Im == 0d)
                {
                    // Real part of complex root.
                    results.Add(-offset - ((s + t) * OneHalf));
                }
            }
            else if (discriminant < 0)
            {
                // Distinct real roots.
                var th = Acos(R / Sqrt(-Q * Q * Q));

                results.Add((2d * Sqrt(-Q) * Cos(th * OneThird)) - offset);
                results.Add((2d * Sqrt(-Q) * Cos((th + Tau) * OneThird)) - offset);
                results.Add((2d * Sqrt(-Q) * Cos((th + (4d * PI)) * OneThird)) - offset);
            }

            return results.ToList();
        }

        /// <summary>
        /// The cubic roots.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>The <see cref="T:List{double}"/>.</returns>
        /// <acknowledgment>
        /// http://www.kevlindev.com/geometry/2D/intersections/
        /// </acknowledgment>
        [DisplayName("Cubic Roots Kevin Lin")]
        [Description("Find real Cubic Roots.")]
        [Acknowledgment("http://www.kevlindev.com/geometry/2D/intersections/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IList<double> CubicRootsKevinLinDev(double a, double b, double c, double d, double epsilon = Epsilon)
        {
            // If a is 0 the polynomial is quadratic.
            if (a is 0d)
            {
                return QuadraticRootsTests.QuadraticRootsKevinLinDev(b, c, d, epsilon);
            }

            var results = new List<double>();
            var c2 = b / a;
            var c1 = c / a;
            var c0 = d / a;

            var Q = ((3 * c1) - (c2 * c2)) * OneThird;
            var R = ((2 * c2 * c2 * c2) - (9 * c1 * c2) + (27 * c0)) * OneTwentySeventh;

            var offset = c2 * OneThird;
            var discriminant = (R * R * OneQuarter) + (Q * Q * Q * OneTwentySeventh);

            var halfB = OneHalf * R;
            //var ZEROepsilon = ZeroErrorEstimate();

            if (Abs(discriminant) <= epsilon)//ZEROepsilon)
            {
                discriminant = 0;
            }

            if (discriminant > 0)
            {
                var e = Sqrt(discriminant);
                var tmp = -halfB + e;
                double root;
                root = tmp >= 0 ? Pow(tmp, OneThird) : -Pow(-tmp, OneThird);
                tmp = -halfB - e;
                if (tmp >= 0)
                {
                    root += Pow(tmp, OneThird);
                }
                else
                {
                    root -= Pow(-tmp, OneThird);
                }

                results.Add(root - offset);
            }
            else if (discriminant < 0)
            {
                var distance = Sqrt(-Q * OneThird);
                var angle = Atan2(Sqrt(-discriminant), -halfB) * OneThird;
                var cos = Cos(angle);
                var sin = Sin(angle);
                results.Add((2 * distance * cos) - offset);
                results.Add((-distance * (cos + (Sqrt3 * sin))) - offset);
                results.Add((-distance * (cos - (Sqrt3 * sin))) - offset);
            }
            else
            {
                double tmp;
                tmp = halfB >= 0 ? -Pow(halfB, OneThird) : Pow(-halfB, OneThird);
                results.Add((2 * tmp) - offset);
                // really should return next root twice, but we return only one
                results.Add(-tmp - offset);
            }
            return results;
        }

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
