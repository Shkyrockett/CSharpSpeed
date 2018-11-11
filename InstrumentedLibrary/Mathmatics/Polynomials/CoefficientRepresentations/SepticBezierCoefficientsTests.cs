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
    [Signature("public static IList<double> SepticBezierCoefficients(double a, double b, double c, double d, double e, double f, double g, double h)")]
    [SourceCodeLocationProvider]
    public static class SepticBezierCoefficientsTests
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
                { new object[] { 1d, 2d, 3d, 4d, 5d, 6d, 7d, 8d }, new TestCaseResults(description:"Dumb Polynomial test.", trials:trials, expectedReturnValue:null, epsilon:double.Epsilon) },
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
        public static Polynomial SepticBezierCoefficientsGeneral(double a, double b, double c, double d, double e, double f, double g, double h)
        {
            return GeneralBezierCoefficientsTests.BezierCoefficientsRecursive(a, b, c, d, e, f, g, h);
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
        public static Polynomial SepticBezierCoefficientsRecursive(double a, double b, double c, double d, double e, double f, double g, double h)
        {
            return (Polynomial.OneMinusT * SexticBezierCoefficientsTests.SexticBezierCoefficientsRecursive(a, b, c, d, e, f, g)) + (Polynomial.T * SexticBezierCoefficientsTests.SexticBezierCoefficientsRecursive(b, c, d, e, f, g, h));
        }
    }
}
