using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The septic bezier coefficients tests class.
    /// </summary>
    [DisplayName("Septic Polynomial Coefficients")]
    [Description("Find the Polynomial Coefficients of a Septic Bezier Curve.")]
    [SourceCodeLocationProvider]
    public static class SepticBezierCoefficientsTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        [DisplayName(nameof(SepticBezierCoefficientsTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 1000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 2d, 3d, 4d, 5d, 6d, 7d, 8d }, new TestCaseResults(description: "Dumb Polynomial test.", trials: trials, expectedReturnValue: (0d, 0d, 0d, 0d, 0d, 0d, 7d, 1d), epsilon: double.Epsilon) },
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
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double A, double B, double C, double D, double E, double F, double G, double H) SepticBezierCoefficients(double a, double b, double c, double d, double e, double f, double g, double h)
            => SepticBezierCoefficients0(a, b, c, d, e, f, g, h);

        /// <summary>
        /// Coefficients for a Septic Bézier curve.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <param name="f"></param>
        /// <param name="g"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        [DisplayName("Septic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Septic Bezier Curve.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F, double G, double H) SepticBezierCoefficients0(double a, double b, double c, double d, double e, double f, double g, double h)
        {
            return (h - (7d * g) + (21d * f) - (35d * e) + (35d * d) - (21d * c) + (7d * b) - a,
                    (7d * g) - (42d * f) + (105d * e) - (140d * d) + (105d * c) - (42d * b) + (7d * a),
                    (21d * f) - (105d * e) + (210d * d) - (210d * c) + (105d * b) - (21d * a),
                    (35d * e) - (140d * d) + (210d * c) - (140d * b) + (35d * a),
                    (35d * d) - (105d * c) + (105d * b) - (35d * a),
                    (21d * c) - (42d * b) + (21d * a),
                    (7d * b) - (7d * a),
                    a);
        }

        /// <summary>
        /// The septic bezier coefficients general.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <param name="e">The e.</param>
        /// <param name="f">The f.</param>
        /// <param name="g">The g.</param>
        /// <param name="h">The h.</param>
        /// <returns>The <see cref="Polynomial"/>.</returns>
        [DisplayName("Septic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Septic Bezier Curve.")]
        [Acknowledgment("https://github.com/superlloyd/Poly")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F, double G, double H) SepticBezierCoefficientsGeneral(double a, double b, double c, double d, double e, double f, double g, double h)
        {
            var polynomial = RecursiveBezierCoefficientsTests.BezierCoefficientsRecursive(a, b, c, d, e, f, g, h);
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c], polynomial[PolynomialTerm.d], polynomial[PolynomialTerm.e], polynomial[PolynomialTerm.f], polynomial[PolynomialTerm.g], polynomial[PolynomialTerm.h]);
        }

        /// <summary>
        /// Coefficients for a Septic Bézier curve.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <param name="f"></param>
        /// <param name="g"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/superlloyd/Poly
        /// </acknowledgment>
        [DisplayName("Septic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Septic Bezier Curve.")]
        [Acknowledgment("https://github.com/superlloyd/Poly")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F, double G, double H) SepticBezierCoefficientsRecursive(double a, double b, double c, double d, double e, double f, double g, double h)
        {
            var polynomial = (Polynomial.OneMinusT * SexticBezierCoefficientsTests.SexticBezierCoefficients(a, b, c, d, e, f, g)) + (Polynomial.T * SexticBezierCoefficientsTests.SexticBezierCoefficients(b, c, d, e, f, g, h));
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c], polynomial[PolynomialTerm.d], polynomial[PolynomialTerm.e], polynomial[PolynomialTerm.f], polynomial[PolynomialTerm.g], polynomial[PolynomialTerm.h]);
        }
    }
}
