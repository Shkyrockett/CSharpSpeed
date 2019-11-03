using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The nonic bezier coefficients tests class.
    /// </summary>
    [DisplayName("Nonic Polynomial Coefficients")]
    [Description("Find the Polynomial Coefficients of a Nonic Bezier Curve.")]
    [SourceCodeLocationProvider]
    public static class NonicBezierBernsteinBasisTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(NonicBezierBernsteinBasisTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 1000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 2d, 3d, 4d, 5d, 6d, 7d, 8d, 9d, 10d }, new TestCaseResults(description: "Dumb Polynomial test.", trials: trials, expectedReturnValue: (0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 9d, 1d), epsilon: double.Epsilon) },
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
        /// Nonics the bezier bernstein basis.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <param name="e">The e.</param>
        /// <param name="f">The f.</param>
        /// <param name="g">The g.</param>
        /// <param name="h">The h.</param>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double A, double B, double C, double D, double E, double F, double G, double H, double I, double J) NonicBezierBernsteinBasis(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j)
            => NonicBezierCoefficients0(a, b, c, d, e, f, g, h, i, j);

        /// <summary>
        /// Coefficients for a Nonic Bézier curve.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <param name="e">The e.</param>
        /// <param name="f">The f.</param>
        /// <param name="g">The g.</param>
        /// <param name="h">The h.</param>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns></returns>
        [DisplayName("Nonic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Nonic Bezier Curve.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F, double G, double H, double I, double J) NonicBezierCoefficients0(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j)
        {
            return (j - (9d * i) + (36d * h) - (84d * g) + (126d * f) - (126d * e) + (84d * d) - (36d * c) + (9d * b) - a,
                    (9d * i) - (72d * h) + (252d * g) - (504d * f) + (630d * e) - (504d * d) + (252d * c) - (72d * b) + (9d * a),
                    (36d * h) - (252d * g) + (756d * f) - (1260d * e) + (1260d * d) - (756d * c) + (252 * b) - (36 * a),
                    (84d * g) - (504 * f) + (1260d * e) - (1680d * d) + (1260d * c) - (504d * b) + (84d * a),
                    (126d * f) - (630d * e) + (1260d * d) - (1260d * c) + (630d * b) - (126d * a),
                    (126d * e) - (504d * d) + (756d * c) - (504d * b) + (126d * a),
                    (84d * d) - (252d * c) + (252d * b) - (84d * a),
                    (36d * c) - (72d * b) + (36d * a),
                    (9d * b) - (9d * a),
                    a);
        }

        /// <summary>
        /// The nonic bezier coefficients general.
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
        /// <returns>
        /// The <see cref="Polynomial" />.
        /// </returns>
        [DisplayName("Nonic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Nonic Bezier Curve.")]
        [Acknowledgment("https://github.com/superlloyd/Poly")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F, double G, double H, double I, double J) NonicBezierCoefficientsGeneral(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j)
        {
            var polynomial = RecursiveBezierBernsteinBasisTests.BezierCoefficientsRecursive(a, b, c, d, e, f, g, h, i, j);
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c], polynomial[PolynomialTerm.d], polynomial[PolynomialTerm.e], polynomial[PolynomialTerm.f], polynomial[PolynomialTerm.g], polynomial[PolynomialTerm.h], polynomial[PolynomialTerm.i], polynomial[PolynomialTerm.j]);
        }

        /// <summary>
        /// Coefficients for a Nonic Bézier curve.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <param name="e">The e.</param>
        /// <param name="f">The f.</param>
        /// <param name="g">The g.</param>
        /// <param name="h">The h.</param>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/superlloyd/Poly
        /// </acknowledgment>
        [DisplayName("Nonic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Nonic Bezier Curve.")]
        [Acknowledgment("https://github.com/superlloyd/Poly")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F, double G, double H, double I, double J) NonicBezierCoefficientsRecursive(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j)
        {
            var polynomial = (Polynomial.OneMinusT * OcticBezierBernsteinBasisTests.OcticBezierBernsteinBasis(a, b, c, d, e, f, g, h, i)) + (Polynomial.T * OcticBezierBernsteinBasisTests.OcticBezierBernsteinBasis(b, c, d, e, f, g, h, i, j));
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c], polynomial[PolynomialTerm.d], polynomial[PolynomialTerm.e], polynomial[PolynomialTerm.f], polynomial[PolynomialTerm.g], polynomial[PolynomialTerm.h], polynomial[PolynomialTerm.i], polynomial[PolynomialTerm.j]);
        }
    }
}
