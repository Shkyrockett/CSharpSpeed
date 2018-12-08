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
    [Signature("public static IList<double> NonicBezierCoefficients(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j)")]
    [SourceCodeLocationProvider]
    public static class NonicBezierCoefficientsTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(NonicBezierCoefficientsTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 1000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 2d, 3d, 4d, 5d, 6d, 7d, 8d, 9d, 10d }, new TestCaseResults(description:"Dumb Polynomial test.", trials:trials, expectedReturnValue:null, epsilon:double.Epsilon) },
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
        /// <returns>The <see cref="Polynomial"/>.</returns>
        [DisplayName("Nonic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Nonic Bezier Curve.")]
        [Acknowledgment("https://github.com/superlloyd/Poly")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Polynomial NonicBezierCoefficientsGeneral(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j)
        {
            return GeneralBezierCoefficientsTests.BezierCoefficientsRecursive(a, b, c, d, e, f, g, h, i, j);
        }

        /// <summary>
        /// Coefficients for a Nonic Bézier curve.
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
        public static Polynomial NonicBezierCoefficientsRecursive(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j)
        {
            return (Polynomial.OneMinusT * OcticBezierCoefficientsTests.OcticBezierCoefficientsRecursive(a, b, c, d, e, f, g, h, i)) + (Polynomial.T * OcticBezierCoefficientsTests.OcticBezierCoefficientsRecursive(b, c, d, e, f, g, h, i, j));
        }
    }
}
