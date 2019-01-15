using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The cubic bezier coefficients tests class.
    /// </summary>
    [DisplayName("Cubic Polynomial Coefficients")]
    [Description("Find the Polynomial Coefficients of a Cubic Bezier Curve.")]
    [SourceCodeLocationProvider]
    public static class CubicBezierCoefficientsTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(CubicBezierCoefficientsTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 1000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 2d, 3d, 4d }, new TestCaseResults(description:"Dumb Polynomial test.", trials:trials, expectedReturnValue: (0d, 0d, 3d, 1d), epsilon:double.Epsilon) },
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
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Signature]
        public static (double A, double B, double C, double D) CubicBezierCoefficients(double a, double b, double c, double d)
            => CubicBezierCoefficients0(a, b, c, d);

        /// <summary>
        /// Coefficients for a Cubic Bézier curve.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://www.gamedev.net/topic/643117-coefficients-for-bezier-curves/
        /// http://fontforge.github.io/bezier.html
        /// http://idav.ucdavis.edu/education/CAGDNotes/Matrix-Cubic-Bezier-Curve/Matrix-Cubic-Bezier-Curve.html
        /// </acknowledgment>
        [DisplayName("Cubic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Cubic Bezier Curve.")]
        [Acknowledgment("http://www.gamedev.net/topic/643117-coefficients-for-bezier-curves/", "http://fontforge.github.io/bezier.html", "http://idav.ucdavis.edu/education/CAGDNotes/Matrix-Cubic-Bezier-Curve/Matrix-Cubic-Bezier-Curve.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D) CubicBezierCoefficients0(double a, double b, double c, double d)
        {
            return (d - (3d * c) + (3d * b) - a,
                    (3d * c) - (6d * b) + (3d * a),
                    3d * (b - a),
                    a);
        }

        /// <summary>
        /// The bezier coefficients1.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <returns>The <see cref="T:ValueTuple{T1, T2, T3, T4}"/>.</returns>
        /// <acknowledgment>
        /// https://www.particleincell.com/2013/cubic-line-intersection/
        /// </acknowledgment>
        [DisplayName("Cubic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Cubic Bezier Curve.")]
        [Acknowledgment("https://www.particleincell.com/2013/cubic-line-intersection/")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D) BezierCoefficients1(double a, double b, double c, double d)
            => (-a + (3d * b) + (-3d * c) + d,
                (3d * a) - (6d * b) + (3d * c),
                (-3d * a) + (3d * b),
                a);

        /// <summary>
        /// The cubic bezier coefficients.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <returns>The <see cref="Polynomial"/>.</returns>
        [DisplayName("Cubic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Cubic Bezier Curve.")]
        [Acknowledgment("https://github.com/superlloyd/Poly")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D) CubicBezierCoefficientsGeneral(double a, double b, double c, double d)
        {
            Polynomial polynomial = RecursiveBezierCoefficientsTests.BezierCoefficientsRecursive(a, b, c, d);
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c], polynomial[PolynomialTerm.d]);
        }

        /// <summary>
        /// Coefficients for a Cubic Bézier curve.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/superlloyd/Poly
        /// </acknowledgment>
        [DisplayName("Cubic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Cubic Bezier Curve.")]
        [Acknowledgment("https://github.com/superlloyd/Poly")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D) CubicBezierCoefficientsRecursive(double a, double b, double c, double d)
        {
            Polynomial polynomial = (Polynomial.OneMinusT * QuadraticBezierCoefficientsTests.QuadraticBezierCoefficients(a, b, c)) + (Polynomial.T * QuadraticBezierCoefficientsTests.QuadraticBezierCoefficients(b, c, d));
            return (polynomial[PolynomialTerm.a], polynomial[PolynomialTerm.b], polynomial[PolynomialTerm.c], polynomial[PolynomialTerm.d]);
        }
    }
}
