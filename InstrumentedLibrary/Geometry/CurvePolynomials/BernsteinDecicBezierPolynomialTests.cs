using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The decic bezier coefficients tests class.
    /// </summary>
    [DisplayName("Decic Polynomial Coefficients")]
    [Description("Find the Polynomial Coefficients of a Decic Bezier Curve.")]
    [SourceCodeLocationProvider]
    public static class BernsteinDecicBezierPolynomialTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(BernsteinDecicBezierPolynomialTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 1000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 2d, 3d, 4d, 5d, 6d, 7d, 8d, 9d, 10d, 11d }, new TestCaseResults(description: "Dumb Polynomial test.", trials: trials, expectedReturnValue: (0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 10d, 1d), epsilon: double.Epsilon) },
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
        /// <param name="e"></param>
        /// <param name="f"></param>
        /// <param name="g"></param>
        /// <param name="h"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double A, double B, double C, double D, double E, double F, double G, double H, double I, double J, double K) DecicBezierCoefficients(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j, double k)
            => DecicBezierCoefficients0(a, b, c, d, e, f, g, h, i, j, k);

        /// <summary>
        /// Coefficients for a Decic Bézier curve.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <param name="f"></param>
        /// <param name="g"></param>
        /// <param name="h"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        [DisplayName("Decic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Decic Bezier Curve.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F, double G, double H, double I, double J, double K) DecicBezierCoefficients0(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j, double k)
        {
            return (k - (10 * j) + (45 * i) - (120 * h) + (210 * g) - (252 * f) + (210 * e) - (120 * d) + (45 * c) - (10 * b) + a,
                    (10 * j) - (90d * i) + (360d * h) - (840d * g) + (1260d * f) - (1260d * e) + (840d * d) - (360d * c) + (90d * b) - (10 * a),
                    (45d * i) - (360d * h) + (1260d * g) - (2520d * f) + (3150d * e) - (2520d * d) + (1260d * c) - (360d * b) + (45d * a),
                    (120d * h) - (840d * g) + (2520d * f) - (4200d * e) + (4200d * d) - (2520d * c) + (840d * b) - (120d * a),
                    (210d * g) - (1260d * f) + (3150d * e) - (4200d * d) + (3150d * c) - (1260d * b) + (210d * a),
                    (252d * f) - (1260d * e) + (2520d * d) - (2520d * c) + (1260d * b) - (252d * a),
                    (210d * e) - (840d * d) + (1260d * c) - (840d * b) + (210d * a),
                    (120d * d) - (360d * c) + (360d * b) - (120d * a),
                    (45d * c) - (90d * b) + (45d * a),
                    (10d * b) - (10d * a),
                    a);
        }

        /// <summary>
        /// The decic bezier coefficients general.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <param name="e">The e.</param>
        /// <param name="f">The f.</param>
        /// <param name="g">The g.</param>
        /// <param name="h">The h.</param>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <param name="k">The k.</param>
        /// <returns>The <see cref="Polynomial"/>.</returns>
        [DisplayName("Decic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Decic Bezier Curve.")]
        [Acknowledgment("https://github.com/superlloyd/Poly")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F, double G, double H, double I, double J, double K) DecicBezierCoefficientsGeneral0(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j, double k)
        {
            var polynomial = BernsteinRecursiveBezierPolynomialTests.BezierCoefficientsRecursive(a, b, c, d, e, f, g, h, i, j, k);
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c], polynomial[PolynomialTerm.d], polynomial[PolynomialTerm.e], polynomial[PolynomialTerm.f], polynomial[PolynomialTerm.g], polynomial[PolynomialTerm.h], polynomial[PolynomialTerm.i], polynomial[PolynomialTerm.j], polynomial[PolynomialTerm.k]);
        }

        /// <summary>
        /// Coefficients for a Decic Bézier curve.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <param name="f"></param>
        /// <param name="g"></param>
        /// <param name="h"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/superlloyd/Poly
        /// </acknowledgment>
        [DisplayName("Decic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Decic Bezier Curve.")]
        [Acknowledgment("https://github.com/superlloyd/Poly")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F, double G, double H, double I, double J, double K) DecicBezierCoefficientsRecursive(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j, double k)
        {
            var polynomial = (Polynomial.OneMinusT * BernsteinNonicBezierPolynomialTests.NonicBezierCoefficients(a, b, c, d, e, f, g, h, i, j)) + (Polynomial.T * BernsteinNonicBezierPolynomialTests.NonicBezierCoefficients(b, c, d, e, f, g, h, i, j, k));
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c], polynomial[PolynomialTerm.d], polynomial[PolynomialTerm.e], polynomial[PolynomialTerm.f], polynomial[PolynomialTerm.g], polynomial[PolynomialTerm.h], polynomial[PolynomialTerm.i], polynomial[PolynomialTerm.j], polynomial[PolynomialTerm.k]);
        }
    }
}
