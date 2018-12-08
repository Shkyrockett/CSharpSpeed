using CSharpSpeed;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InstrumentedLibrary
{
    /// <summary>
    /// The quintic bezier coefficients tests class.
    /// </summary>
    [DisplayName("Quintic Polynomial Coefficients")]
    [Description("Find the Polynomial Coefficients of a Quintic Bezier Curve.")]
    [Signature("public static IList<double> CubicRoots(double aCube, double bSquare, double cLinear, double dConstant, double epsilon = Epsilon)")]
    [SourceCodeLocationProvider]
    public static class QuinticBezierCoefficientsTests
    {
        /// <summary>
        /// Test the harness.
        /// </summary>
        /// <returns>The <see cref="T:List{SpeedTester}"/>.</returns>
        [DisplayName(nameof(QuinticBezierCoefficientsTests))]
        public static List<SpeedTester> TestHarness()
        {
            var trials = 1000;
            var tests = new Dictionary<object[], TestCaseResults> {
                { new object[] { 1d, 2d, 3d, 4d, 5d, 6d }, new TestCaseResults(description:"Dumb Polynomial test.", trials:trials, expectedReturnValue:null, epsilon:double.Epsilon) },
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
        /// Coefficients for a Quintic Bézier curve.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// Based off of pseudo-code for the matrix found at:
        /// https://simtk.org/api_docs/opensim/api_docs/classOpenSim_1_1SegmentedQuinticBezierToolkit.html
        /// </acknowledgment>
        [DisplayName("Quintic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Quintic Bezier Curve.")]
        [Acknowledgment("https://simtk.org/api_docs/opensim/api_docs/classOpenSim_1_1SegmentedQuinticBezierToolkit.html")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double A, double B, double C, double D, double E, double F) QuinticBezierCoefficients(double a, double b, double c, double d, double e, double f)
        {
            return (f - (5d * e) + (10d * d) - (10d * c) + (5d * b) - a,
                    (5d * e) - (20d * d) + (30d * c) - (20d * b) + (5 * a),
                    (10d * d) - (30d * c) + (30d * b) - (10d * a),
                    (10d * c) - (20d * b) + (10d * a),
                    5d * (b - a),
                    a);
        }

        /// <summary>
        /// The quintic bezier coefficients general.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <param name="e">The e.</param>
        /// <param name="f">The f.</param>
        /// <returns>The <see cref="Polynomial"/>.</returns>
        [DisplayName("Quintic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Quintic Bezier Curve.")]
        [Acknowledgment("https://github.com/superlloyd/Poly")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Polynomial QuinticBezierCoefficientsGeneral(double a, double b, double c, double d, double e, double f)
        {
            return GeneralBezierCoefficientsTests.BezierCoefficientsRecursive(a, b, c, d, e, f);
        }

        /// <summary>
        /// Coefficients for a Quintic Bézier curve.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/superlloyd/Poly
        /// </acknowledgment>
        [DisplayName("Quintic Polynomial Coefficients")]
        [Description("Find the Polynomial Coefficients of a Quintic Bezier Curve.")]
        [Acknowledgment("https://github.com/superlloyd/Poly")]
        [SourceCodeLocationProvider]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Polynomial QuinticBezierCoefficientsRecursive(double a, double b, double c, double d, double e, double f)
        {
            return (Polynomial.OneMinusT * QuarticBezierCoefficientsTests.QuarticBezierCoefficients(a, b, c, d, e)) + (Polynomial.T * QuarticBezierCoefficientsTests.QuarticBezierCoefficients(b, c, d, e, f));
        }
    }
}
