using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The quartic bezier coefficients tests class.
    /// </summary>
    [DisplayName("Quartic Polynomial Coefficients")]
    [Description("Find the Polynomial Coefficients of a Quartic Bezier Curve.")]
    [Signature("public static IList<double> QuarticBezierCoefficients(double a, double b, double c, double d, double e)")]
    [SourceCodeLocationProvider]
    public static class QuarticBezierCoefficientsTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(QuadraticBezierCoefficientsTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 10000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 2d, 3d, 4d, 5d }, new TestCaseResults(description:"Dumb Polynomial test.", trials:trials, expectedReturnValue:null, epsilon:double.Epsilon) },
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
        /// Coefficients for a Quartic Bézier curve.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// Coefficient calculation found in the matrix representation at:
        /// http://www.dglr.de/publikationen/2016/420062.pdf
        /// </acknowledgment>
        [DisplayName("Quartic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Quartic Bezier Curve.")]
        [Acknowledgment("http://www.dglr.de/publikationen/2016/420062.pdf")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E) QuarticBezierCoefficients(double a, double b, double c, double d, double e)
        {
            return (e - (4d * d) + (6d * c) - (4d * b) + a,
                    (4d * d) - (12d * c) + (12d * b) - (4d * a),
                    (6d * c) - (12d * b) + (6d * a),
                    4d * (b - a),
                    a);
        }

        /// <summary>
        /// The quartic bezier coefficients general.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <param name="e">The e.</param>
        /// <returns>The <see cref="Polynomial"/>.</returns>
        [DisplayName("Quartic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Quartic Bezier Curve.")]
        [Acknowledgment("https://github.com/superlloyd/Poly")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Polynomial QuarticBezierCoefficientsGeneral(double a, double b, double c, double d, double e)
        {
            return GeneralBezierCoefficientsTests.BezierCoefficientsRecursive(a, b, c, d, e);
        }

        /// <summary>
        /// Coefficients for a Quartic Bézier curve.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/superlloyd/Poly
        /// </acknowledgment>
        [DisplayName("Quartic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Quartic Bezier Curve.")]
        [Acknowledgment("https://github.com/superlloyd/Poly")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Polynomial QuarticBezierCoefficientsRecursive(double a, double b, double c, double d, double e)
        {
            return (Polynomial.OneMinusT * CubicBezierCoefficientsTests.CubicBezierCoefficients(a, b, c, d)) + (Polynomial.T * CubicBezierCoefficientsTests.CubicBezierCoefficients(b, c, d, e));
        }
    }
}
