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
    [Signature("public static IList<double> DecicBezierCoefficients(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j, double k)")]
    [SourceCodeLocationProvider]
    public static class DecicBezierCoefficientsTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(DecicBezierCoefficientsTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 1000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 2d, 3d, 4d, 5d, 6d, 7d, 8d, 9d, 10d, 11d }, new TestCaseResults(description:"Dumb Polynomial test.", trials:trials, expectedReturnValue:null, epsilon:double.Epsilon) },
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
        public static Polynomial DecicBezierCoefficientsGeneral(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j, double k)
        {
            return GeneralBezierCoefficientsTests.BezierCoefficientsRecursive(a, b, c, d, e, f, g, h, i, j, k);
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
        public static Polynomial DecicBezierCoefficientsRecursive(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j, double k)
        {
            return (Polynomial.OneMinusT * NonicBezierCoefficientsTests.NonicBezierCoefficientsRecursive(a, b, c, d, e, f, g, h, i, j)) + (Polynomial.T * NonicBezierCoefficientsTests.NonicBezierCoefficientsRecursive(b, c, d, e, f, g, h, i, j, k));
        }
    }
}
