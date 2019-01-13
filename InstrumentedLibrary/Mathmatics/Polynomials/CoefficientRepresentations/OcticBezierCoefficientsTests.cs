using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The octic bezier coefficients stack class.
    /// </summary>
    [DisplayName("Octic Polynomial Coefficients")]
    [Description("Find the Polynomial Coefficients of a Octic Bezier Curve.")]
    [Signature("public static IList<double> OcticBezierCoefficients(double a, double b, double c, double d, double e, double f, double g, double h, double i)")]
    [SourceCodeLocationProvider]
    public static class OcticBezierCoefficientsTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(OcticBezierCoefficientsTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 1000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 2d, 3d, 4d, 5d, 6d, 7d, 8d, 9d }, new TestCaseResults(description:"Dumb Polynomial test.", trials:trials, expectedReturnValue: (0d, 0d, 0d, 0d, 0d, 0d, 0d, 8d, 1d), epsilon:double.Epsilon) },
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
        /// <param name="h"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double A, double B, double C, double D, double E, double F, double G, double H, double I) OcticBezierCoefficients(double a, double b, double c, double d, double e, double f, double g, double h, double i)
            => OcticBezierCoefficients0(a, b, c, d, e, f, g, h, i);

        /// <summary>
        /// Coefficients for a Octic Bézier curve.
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
        /// <returns></returns>
        [DisplayName("Octic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Octic Bezier Curve.")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F, double G, double H, double I) OcticBezierCoefficients0(double a, double b, double c, double d, double e, double f, double g, double h, double i)
        {
            return (i - (8d * h) + (28d * g) - (56d * f) + (70d * e) - (56d * d) + (28d * c) - (8d * b) + a,
                    (8d * h) - (56d * g) + (168d * f) - (280d * e) + (280d * d) - (168d * c) + (56d * b) - (8d * a),
                    (28d * g) - (168d * f) + (420d * e) - (560d * d) + (420d * c) - (168d * b) + (28d * a),
                    (56d * f) - (280d * e) + (560d * d) - (560d * c) + (280d * b) - (56d * a),
                    (70d * e) - (280d * d) + (420d * c) - (280d * b) + (70d * a),
                    (56d * d) - (168d * c) + (168d * b) - (56d * a),
                    (28d * c) - (56d * b) + (28d * a),
                    (8d * b) - (8d * a),
                    a);
        }

        /// <summary>
        /// The octic bezier coefficients stack.
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
        /// <returns>The <see cref="Polynomial"/>.</returns>
        [DisplayName("Octic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Octic Bezier Curve.")]
        [Acknowledgment("https://github.com/superlloyd/Poly")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F, double G, double H, double I) OcticBezierCoefficientsGeneral(double a, double b, double c, double d, double e, double f, double g, double h, double i)
        {
            Polynomial polynomial = RecursiveBezierCoefficientsTests.BezierCoefficientsRecursive(a, b, c, d, e, f, g, h, i);
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c], polynomial[PolynomialTerm.d], polynomial[PolynomialTerm.e], polynomial[PolynomialTerm.f], polynomial[PolynomialTerm.g], polynomial[PolynomialTerm.h], polynomial[PolynomialTerm.i]);
        }

        /// <summary>
        /// Coefficients for a Octic Bézier curve.
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
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/superlloyd/Poly
        /// </acknowledgment>
        [DisplayName("Octic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Octic Bezier Curve.")]
        [Acknowledgment("https://github.com/superlloyd/Poly")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F, double G, double H, double I) OcticBezierCoefficientsRecursive(double a, double b, double c, double d, double e, double f, double g, double h, double i)
        {
            Polynomial polynomial = (Polynomial.OneMinusT * SepticBezierCoefficientsTests.SepticBezierCoefficients(a, b, c, d, e, f, g, h)) + (Polynomial.T * SepticBezierCoefficientsTests.SepticBezierCoefficients(b, c, d, e, f, g, h, i));
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c], polynomial[PolynomialTerm.d], polynomial[PolynomialTerm.e], polynomial[PolynomialTerm.f], polynomial[PolynomialTerm.g], polynomial[PolynomialTerm.h], polynomial[PolynomialTerm.i]);
        }
    }
}
