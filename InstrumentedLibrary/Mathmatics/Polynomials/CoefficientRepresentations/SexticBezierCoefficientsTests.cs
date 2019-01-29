using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The sextic bezier coefficients stack class.
    /// </summary>
    [DisplayName("Sextic Polynomial Coefficients")]
    [Description("Find the Polynomial Coefficients of a Sextic Bezier Curve.")]
    [SourceCodeLocationProvider]
    public static class SexticBezierCoefficientsTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(SexticBezierCoefficientsTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 1000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 2d, 3d, 4d, 5d, 6d, 7d }, new TestCaseResults(description: "Dumb Polynomial test.", trials: trials, expectedReturnValue: (0d, 0d, 0d, 0d, 0d, 6d, 1d), epsilon: double.Epsilon) },
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
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <param name="f"></param>
        /// <param name="g"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double A, double B, double C, double D, double E, double F, double G) SexticBezierCoefficients(double a, double b, double c, double d, double e, double f, double g)
            => SexticBezierCoefficients0(a, b, c, d, e, f, g);

        /// <summary>
        /// Coefficients for a Sextic Bézier curve.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <param name="f"></param>
        /// <param name="g"></param>
        /// <returns></returns>
        [DisplayName("Sextic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Sextic Bezier Curve.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F, double G) SexticBezierCoefficients0(double a, double b, double c, double d, double e, double f, double g)
        {
            return (g - (6d * f) + (15d * e) - (20d * d) + (15d * c) - (6d * b) + a,
                    (6d * f) - (30d * e) + (60d * d) - (60d * c) + (30d * b) - (6d * a),
                    (15d * e) - (60d * d) + (90d * c) - (60d * b) + (15d * a),
                    (20d * d) - (60d * c) + (60d * b) - (20d * a),
                    (15d * c) - (30d * b) + (15d * a),
                    (6d * b) - (6d * a),
                    a);
        }

        /// <summary>
        /// The sextic bezier coefficients general.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <param name="e">The e.</param>
        /// <param name="f">The f.</param>
        /// <param name="g">The g.</param>
        /// <returns>The <see cref="Polynomial"/>.</returns>
        [DisplayName("Sextic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Sextic Bezier Curve.")]
        [Acknowledgment("https://github.com/superlloyd/Poly")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F, double G) SexticBezierCoefficientsGeneral(double a, double b, double c, double d, double e, double f, double g)
        {
            Polynomial polynomial = RecursiveBezierCoefficientsTests.BezierCoefficientsRecursive(a, b, c, d, e, f, g);
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c], polynomial[PolynomialTerm.d], polynomial[PolynomialTerm.e], polynomial[PolynomialTerm.f], polynomial[PolynomialTerm.g]);
        }

        /// <summary>
        /// Coefficients for a Sextic Bézier curve.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <param name="f"></param>
        /// <param name="g"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/superlloyd/Poly
        /// </acknowledgment>
        [DisplayName("Sextic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Sextic Bezier Curve.")]
        [Acknowledgment("https://github.com/superlloyd/Poly")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F, double G) SexticBezierCoefficientsRecursive(double a, double b, double c, double d, double e, double f, double g)
        {
            Polynomial polynomial = (Polynomial.OneMinusT * QuinticBezierCoefficientsTests.QuinticBezierCoefficients(a, b, c, d, e, f)) + (Polynomial.T * QuinticBezierCoefficientsTests.QuinticBezierCoefficients(b, c, d, e, f, g));
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c], polynomial[PolynomialTerm.d], polynomial[PolynomialTerm.e], polynomial[PolynomialTerm.f], polynomial[PolynomialTerm.g]);
        }
    }
}
